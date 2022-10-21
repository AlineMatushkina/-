using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WFControlLibrary
{
    public partial class Square : Control
    {
        private Color color = Color.Black;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                Invalidate();
            }
        }

        public Square()
        {
            InitializeComponent();
        }

        public Square(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = CreateGraphics();
            g.FillRectangle(new SolidBrush(color), ClientRectangle);
        }
    }
}
