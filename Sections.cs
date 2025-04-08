using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalCard
{
    public partial class Sections : Form
    {
        Action<int, int, int> action;
        public Sections(Action<int, int, int> action)
        {
            InitializeComponent();
            this.action = action;
        }

        public Sections()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 0);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 2);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            action?.Invoke(4, 4, 0);
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 2);
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            action?.Invoke(4, 4, 2);
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            action?.Invoke(4, 4, 1);
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            action?.Invoke(1, -1, 0);
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 1);
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            action?.Invoke(2, -1, 0);
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 3);
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            action?.Invoke(3, 3, 1);
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 0);
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 1);
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            action?.Invoke(3, 3, 2);
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            action?.Invoke(3, 3, 0);
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            action?.Invoke(0, 2, 0);
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            action?.Invoke(6, -1, 0);
            this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            action?.Invoke(5, -1, 0);
            this.Close();
        }
    }
}
