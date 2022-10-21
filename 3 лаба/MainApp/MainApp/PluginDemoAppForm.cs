using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PluginInterface;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace MainApp
{
    public partial class PluginDemoApp : Form
    {
        Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        public PluginDemoApp()
        {
            InitializeComponent();
            GetPluginsFromConfiguration();
            CreatePluginsMenu();
            ShowPluginsInformation();
        }

        //Получение путей из конфигурационного файла
        private void GetPluginsFromConfiguration()
        {
            bool autoSearch = true;
            List<Plugin> dirs = null; 
            try
            {
                autoSearch = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("autoSearch"));
                dirs = ConfigurationManager.GetSection("pluginsPaths") as List<Plugin>;
            }
            catch (Exception e)
            {
                MessageBox.Show("Установлен автоматический режим поиска плагинов: " + e.Message);
            }

            if (!autoSearch && dirs != null)
                foreach (Plugin dir in dirs)
                    LoadPlugin(dir.Path);
            else FindPlugins();
        }

        //Автоматический поиск плагинов
        private void FindPlugins()
        {
            string folder = System.AppDomain.CurrentDomain.BaseDirectory;

            string[] files = Directory.GetFiles(folder, "*.dll");

            foreach (string file in files)
                LoadPlugin(file);
        }

        //Загрузка плагина
        private void LoadPlugin(string path)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(path);

                foreach (Type type in assembly.GetTypes())
                {
                    Type iface = type.GetInterface("PluginInterface.IPlugin");

                    if (iface != null)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin.Name, plugin);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
            }
        }

        //Добавление кнопок для фильтров
        private void CreatePluginsMenu()
        {
            foreach (IPlugin p in plugins.Values)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(p.Name);
                menuItem.Click += OnPluginClick;

                filtersToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }

        //Выполнение плагина
        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform((Bitmap)pictureBox.Image);
            pictureBox.Refresh();
        }

        // Вывод информации о плагинах
        private void ShowPluginsInformation()
        {
            List<string> plugInfo = GetPluginsInfo();
            InfoForm informationForm = new InfoForm(plugInfo);
            informationForm.ShowDialog();
        }

        //Получение загруженных плагинов
        private List<string> GetPluginsInfo()
        {
            List<string> plugInfo = new List<string>();

            foreach (var p in plugins.Values)
            {
                var attribute = p.GetType().GetCustomAttribute(typeof(VersionAttribute), false) as VersionAttribute;
                plugInfo.Add(p.Name + " " + attribute.Major.ToString() + "." + attribute.Minor.ToString() + " by " + p.Author);
            }

            return plugInfo;
        }
    }
}

