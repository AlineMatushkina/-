
namespace WFControlLibrary
{
    partial class ColorControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbDec = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.ctbBlue = new WFControlLibrary.ColorTextBox(this.components);
            this.ctbGreen = new WFControlLibrary.ColorTextBox(this.components);
            this.ctbRed = new WFControlLibrary.ColorTextBox(this.components);
            this.sq = new WFControlLibrary.Square(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Красный";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Зелёный";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Синий";
            // 
            // rbDec
            // 
            this.rbDec.AutoSize = true;
            this.rbDec.Location = new System.Drawing.Point(16, 107);
            this.rbDec.Name = "rbDec";
            this.rbDec.Size = new System.Drawing.Size(54, 21);
            this.rbDec.TabIndex = 7;
            this.rbDec.TabStop = true;
            this.rbDec.Text = "Dec";
            this.rbDec.UseVisualStyleBackColor = true;
            this.rbDec.CheckedChanged += new System.EventHandler(this.rbDec_CheckedChanged);
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Location = new System.Drawing.Point(95, 107);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(53, 21);
            this.rbHex.TabIndex = 8;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "Hex";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // ctbBlue
            // 
            this.ctbBlue.CurNumSys = WFControlLibrary.ColorTextBox.NumSys.Dec;
            this.ctbBlue.Location = new System.Drawing.Point(95, 68);
            this.ctbBlue.Name = "ctbBlue";
            this.ctbBlue.Number = 0;
            this.ctbBlue.Size = new System.Drawing.Size(63, 22);
            this.ctbBlue.TabIndex = 3;
            this.ctbBlue.Text = "0";
            this.ctbBlue.TextChanged += new System.EventHandler(this.ctbBlue_TextChanged);
            // 
            // ctbGreen
            // 
            this.ctbGreen.CurNumSys = WFControlLibrary.ColorTextBox.NumSys.Dec;
            this.ctbGreen.Location = new System.Drawing.Point(95, 39);
            this.ctbGreen.Name = "ctbGreen";
            this.ctbGreen.Number = 0;
            this.ctbGreen.Size = new System.Drawing.Size(63, 22);
            this.ctbGreen.TabIndex = 2;
            this.ctbGreen.Text = "0";
            this.ctbGreen.TextChanged += new System.EventHandler(this.ctbGreen_TextChanged);
            // 
            // ctbRed
            // 
            this.ctbRed.CurNumSys = WFControlLibrary.ColorTextBox.NumSys.Dec;
            this.ctbRed.Location = new System.Drawing.Point(95, 10);
            this.ctbRed.Name = "ctbRed";
            this.ctbRed.Number = 0;
            this.ctbRed.Size = new System.Drawing.Size(63, 22);
            this.ctbRed.TabIndex = 1;
            this.ctbRed.Text = "0";
            this.ctbRed.TextChanged += new System.EventHandler(this.ctbRed_TextChanged);
            // 
            // sq
            // 
            this.sq.Color = System.Drawing.Color.Black;
            this.sq.Location = new System.Drawing.Point(184, 10);
            this.sq.Name = "sq";
            this.sq.Size = new System.Drawing.Size(82, 80);
            this.sq.TabIndex = 0;
            this.sq.Text = "square";
            // 
            // ColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbHex);
            this.Controls.Add(this.rbDec);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctbBlue);
            this.Controls.Add(this.ctbGreen);
            this.Controls.Add(this.ctbRed);
            this.Controls.Add(this.sq);
            this.Name = "ColorControl";
            this.Size = new System.Drawing.Size(288, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Square sq;
        private ColorTextBox ctbRed;
        private ColorTextBox ctbGreen;
        private ColorTextBox ctbBlue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbDec;
        private System.Windows.Forms.RadioButton rbHex;
    }
}
