
namespace Conversion
{
    partial class TempForm
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
            this.edLabel = new System.Windows.Forms.Label();
            this.valueLabel = new System.Windows.Forms.Label();
            this.rLabel = new System.Windows.Forms.Label();
            this.edComboBox = new System.Windows.Forms.ComboBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.convButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // edLabel
            // 
            this.edLabel.AutoSize = true;
            this.edLabel.Location = new System.Drawing.Point(12, 9);
            this.edLabel.Name = "edLabel";
            this.edLabel.Size = new System.Drawing.Size(143, 17);
            this.edLabel.TabIndex = 0;
            this.edLabel.Text = "Единицы измерения";
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(12, 66);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(73, 17);
            this.valueLabel.TabIndex = 1;
            this.valueLabel.Text = "Значение";
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Location = new System.Drawing.Point(12, 158);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(76, 17);
            this.rLabel.TabIndex = 2;
            this.rLabel.Text = "Результат";
            // 
            // edComboBox
            // 
            this.edComboBox.CausesValidation = false;
            this.edComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edComboBox.FormattingEnabled = true;
            this.edComboBox.Location = new System.Drawing.Point(12, 29);
            this.edComboBox.Name = "edComboBox";
            this.edComboBox.Size = new System.Drawing.Size(348, 24);
            this.edComboBox.TabIndex = 3;
            this.edComboBox.SelectedIndexChanged += new System.EventHandler(this.edComboBox_SelectedIndexChanged);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(12, 86);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(348, 22);
            this.valueTextBox.TabIndex = 4;
            this.valueTextBox.TextChanged += new System.EventHandler(this.valueTextBox_TextChanged);
            // 
            // convButton
            // 
            this.convButton.Location = new System.Drawing.Point(134, 129);
            this.convButton.Name = "convButton";
            this.convButton.Size = new System.Drawing.Size(91, 31);
            this.convButton.TabIndex = 5;
            this.convButton.Text = "Перевод";
            this.convButton.UseVisualStyleBackColor = true;
            this.convButton.Click += new System.EventHandler(this.convButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 186);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 17);
            this.resultLabel.TabIndex = 6;
            // 
            // TempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 224);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.convButton);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.edComboBox);
            this.Controls.Add(this.rLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.edLabel);
            this.Name = "TempForm";
            this.Text = "Перевод температуры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label edLabel;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.ComboBox edComboBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.Button convButton;
        private System.Windows.Forms.Label resultLabel;
    }
}

