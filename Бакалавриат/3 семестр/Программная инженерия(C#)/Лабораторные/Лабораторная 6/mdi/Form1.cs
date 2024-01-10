using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MdiFigures {
	public enum ChildFormFigureEnum {
		Triangle,
		Circle,
		Rectangle,
		Parallelogram
	}
	public partial class Form1 : Form {
		public Form1() {
			InitializeComponent();
		}

		private void треугольникToolStripMenuItem_Click(object sender, EventArgs e) {
			Form2 f2= new Form2(this, ChildFormFigureEnum.Triangle);
			f2.Show();
		}

		private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e) {
			Form2 f2 = new Form2(this, ChildFormFigureEnum.Rectangle);
			f2.Show();
		}

		private void окружностьToolStripMenuItem_Click(object sender, EventArgs e) {
			Form2 f2 = new Form2(this, ChildFormFigureEnum.Circle);
			f2.Show();
		}

		private void параллелограммToolStripMenuItem_Click(object sender, EventArgs e) {
			Form2 f2 = new Form2(this, ChildFormFigureEnum.Parallelogram);
			f2.Show();
		}

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void фигурыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
