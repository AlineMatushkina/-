using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFControlLibrary
{
    public partial class ColorControl : UserControl
    {
        public Color Color
        {
            get => sq.Color;
            set
            {
                OnColorChanged(value);
            }
        }

        public event EventHandler ColorChanged;

        public ColorControl()
        {
            InitializeComponent();
            rbDec.Checked = true;
        }

        private void ctbRed_TextChanged(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void ctbGreen_TextChanged(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void ctbBlue_TextChanged(object sender, EventArgs e)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            Color = Color.FromArgb(ctbRed.Number, ctbGreen.Number, ctbBlue.Number);
        }

        private void rbDec_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDec.Checked == true) ctbBlue.CurNumSys = ctbGreen.CurNumSys = ctbRed.CurNumSys = ColorTextBox.NumSys.Dec;
            else ctbBlue.CurNumSys = ctbGreen.CurNumSys = ctbRed.CurNumSys = ColorTextBox.NumSys.Hex;
        }

        protected void OnColorChanged(Color value)
        {
            sq.Color = value;
            ctbRed.Number = Convert.ToInt32(value.R);
            ctbGreen.Number = Convert.ToInt32(value.G);
            ctbBlue.Number = Convert.ToInt32(value.B);

            if (ColorChanged != null)
                ColorChanged(this, new EventArgs());
        }
    }
}
