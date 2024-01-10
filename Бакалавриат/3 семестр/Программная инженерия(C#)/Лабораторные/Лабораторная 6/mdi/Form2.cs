using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MdiFigures {
	public partial class Form2 : Form {
		ChildFormFigureEnum figure;
		public Form2() {
			InitializeComponent();
		}
		public Form2(Form parent, ChildFormFigureEnum fig) {
			InitializeComponent();
			this.MdiParent = parent;
			figure = fig;
			switch (figure) {
				case ChildFormFigureEnum.Triangle:
					this.Text = "Трегольник";
					break;
				case ChildFormFigureEnum.Circle:
					this.Text = "Окружность";
					break;
				case ChildFormFigureEnum.Rectangle:
					this.Text = "Прямоугольник";
					break;
				case ChildFormFigureEnum.Parallelogram:
					this.Text = "Параллелограмм";
					break;
				default:
					break;
			}
		}
        int r = 0;
        int g = 0;
        int b = 0;
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void red_Scroll(object sender, EventArgs e)
        {

        }

        private void red_ValueChanged(object sender, EventArgs e)
        {
            r = red.Value;
            red_value.Text = Convert.ToString(red.Value);
            pictureBox1.Invalidate();
            }

        private void green_ValueChanged(object sender, EventArgs e)
        {
            g = green.Value;
            green_value.Text = Convert.ToString(green.Value);
            pictureBox1.Invalidate();
        }

        private void blue_ValueChanged(object sender, EventArgs e)
        {
            b = blue.Value;
            blue_value.Text = Convert.ToString(blue.Value);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(r, g, b));
            int w = this.pictureBox1.Size.Width, h = this.pictureBox1.Size.Height;
            switch (figure)
            {
                case ChildFormFigureEnum.Triangle:
                    e.Graphics.FillPolygon(solidBrush, new Point[3]
                    {
                        new Point(w / 2, 0),
                        new Point(w, h),
                        new Point(0, h)
                    });
                    break;
                case ChildFormFigureEnum.Circle:
                    e.Graphics.FillEllipse(solidBrush, new Rectangle(0, 0, Math.Min(w, h), Math.Min(w, h)));
                    break;
                case ChildFormFigureEnum.Rectangle:
                    e.Graphics.FillRectangle(solidBrush, new Rectangle(0, h / 5, w, 3 * h / 5));
                    break;
                case ChildFormFigureEnum.Parallelogram:
                    e.Graphics.FillPolygon(solidBrush, new Point[4]
                    {
                        new Point(w, 0),
                        new Point(4 * w / 5, h),
                        new Point(0, h),
                        new Point(w / 5, 0)
                    });
                    break;
                default:
                    break;
            }
        }
    }
}
