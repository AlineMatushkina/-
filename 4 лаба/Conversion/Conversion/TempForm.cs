using System;
using System.Windows.Forms;
using Conversion.ServiceReference;

namespace Conversion
{
    public partial class TempForm : System.Windows.Forms.Form
    {
        public TempForm()
        {
            InitializeComponent();
            edComboBox.Items.Add("Градусы Цельсия");
            edComboBox.Items.Add("Градусы Фаренгейта");
            edComboBox.SelectedIndex = 0;
        }

        private void valueTextBox_TextChanged(object sender, EventArgs e)
        {
            resultLabel.Text = "";
        }
        private void edComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultLabel.Text = "";
        }

        private void convButton_Click(object sender, EventArgs e)
        {
            double temp;
            try
            {
                temp = Convert.ToDouble(valueTextBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неверное значение температуры! " + ex.Message);
                return;
            }

            var csClient = new ConversionServiceClient();
            if (edComboBox.SelectedIndex == 0)
                resultLabel.Text = "В градусах Фаренгейта: " + Math.Round(csClient.CelsiusToFahrenheit(temp), 3).ToString();
            else
                resultLabel.Text = "В градусах Цельсия: " + Math.Round(csClient.FahrenheitToCelsius(temp), 3).ToString();
        }
    }
}