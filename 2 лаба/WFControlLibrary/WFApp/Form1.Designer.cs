
namespace WFApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorControl1 = new WFControlLibrary.ColorControl();
            this.SuspendLayout();
            // 
            // colorControl1
            // 
            this.colorControl1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorControl1.Location = new System.Drawing.Point(12, 12);
            this.colorControl1.Name = "colorControl1";
            this.colorControl1.Size = new System.Drawing.Size(287, 145);
            this.colorControl1.TabIndex = 0;
            this.colorControl1.ColorChanged += new System.EventHandler(this.colorControl1_ColorChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 173);
            this.Controls.Add(this.colorControl1);
            this.Name = "Form1";
            this.Text = "Color";
            this.ResumeLayout(false);

        }

        #endregion

        private WFControlLibrary.ColorControl colorControl1;
    }
}

