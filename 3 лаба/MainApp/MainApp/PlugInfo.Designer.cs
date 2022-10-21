
namespace MainApp
{
    partial class InfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.okButton = new System.Windows.Forms.Button();
            this.pluginListBox = new System.Windows.Forms.ListBox();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(409, 415);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "ОК";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // pluginListBox
            // 
            this.pluginListBox.FormattingEnabled = true;
            this.pluginListBox.HorizontalScrollbar = true;
            this.pluginListBox.ItemHeight = 16;
            this.pluginListBox.Location = new System.Drawing.Point(12, 64);
            this.pluginListBox.Name = "pluginListBox";
            this.pluginListBox.Size = new System.Drawing.Size(490, 324);
            this.pluginListBox.TabIndex = 1;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(156, 27);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(207, 17);
            this.label.TabIndex = 2;
            this.label.Text = "Список загруженных плагинов";
            // 
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 450);
            this.Controls.Add(this.label);
            this.Controls.Add(this.pluginListBox);
            this.Controls.Add(this.okButton);
            this.Name = "InfoForm";
            this.Text = "Plugin Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ListBox pluginListBox;
        private System.Windows.Forms.Label label;
    }
}