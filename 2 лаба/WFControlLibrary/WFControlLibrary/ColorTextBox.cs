using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WFControlLibrary
{
    public partial class ColorTextBox : TextBox
    {
        private readonly Regex hexPattern = new Regex("(\\d|[a-f])");

        private readonly Regex decPattern = new Regex("\\d");

        private int number = 0;

        public int Number
        {
            get => number;
            set
            {
                number = value;
                NumberChanged();
            }
        }

        private void NumberChanged()
        {
            if (curNumSys == NumSys.Dec) Text = Number.ToString();
            else Text = Number.ToString("X");
        }

        public enum NumSys { Dec, Hex }

        protected NumSys curNumSys = NumSys.Dec;

        public NumSys CurNumSys
        {
            get => curNumSys;
            set
            {
                curNumSys = value;
                CurNumSysChanged();
            }
        }

        private void CurNumSysChanged()
        {
            if (curNumSys == NumSys.Dec) Text = Number.ToString();
            else Text = Number.ToString("X");
        }

        protected override void OnTextChanged(EventArgs e)
        {
            foreach(var letter in Text)
            {
                if (curNumSys == NumSys.Hex && Regex.IsMatch(letter.ToString(), hexPattern.ToString(), RegexOptions.IgnoreCase) 
                    || curNumSys == NumSys.Dec && Regex.IsMatch(letter.ToString(), decPattern.ToString(), RegexOptions.IgnoreCase)) continue;
                if (Text.Length > 0) Text = Text.Substring(0, Text.Length - 1);
                return;
            }
            
            if (Text != string.Empty)
            {
                Text = Text.ToUpper();
                int n;
                if (curNumSys == NumSys.Hex)
                {
                    n = Convert.ToInt32(Text, 16);
                    if (n > 255)
                    {
                        Text = @"FF";
                    }
                    Number = Convert.ToInt32(Text, 16);
                }
                else
                {
                    if (!int.TryParse(Text, out _))
                    {
                        Text = @"0";
                    }
                    else
                    {
                        n = Convert.ToInt32(Text);
                        if (n > 255)
                        {
                            Text = @"255";
                        }
                    }
                    Number = Convert.ToInt32(Text);
                }
            }
            else Text = @"0";

            base.OnTextChanged(e);
        }

        public ColorTextBox()
        {
            InitializeComponent();
            Text = "0";
        }

        public ColorTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
