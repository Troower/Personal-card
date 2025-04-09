using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalCard
{
    public partial class Sections : Form
    {
        Action<int, int, int> action;
        int a = 0;
        public Sections(Action<int, int, int> action)
        {
            InitializeComponent();
            this.action = action;
        }

        public Sections(Action<int, int, int> action, int a)
        {
            InitializeComponent();
            this.action = action;
            this.a = a;
            tableLayoutPanel1.RowStyles[0].Height = 0;
            bool flag = true;
            foreach (RowStyle row in tableLayoutPanel1.RowStyles)
            {
                if (flag) flag = false;
                else row.Height = 20;

            }
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
            if (a == 0)
                action?.Invoke(0, 2, 2);
            else
            {
                this.Hide();
                action?.Invoke(13, 0, 0);

            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(4, 4, 0);
            else
            {
                this.Hide();
                action?.Invoke(14, 0, 0);

            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(0, 2, 2);
            else
            {
                this.Hide();
                action?.Invoke(1, 0, 0);

            }
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(4, 4, 2);
            else
            {
                this.Hide();
                action?.Invoke(2, 0, 0);

            }
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(4, 4, 1);
            else
            {
                this.Hide();
                action?.Invoke(3, 0, 0);

            }
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(1, -1, 0);
            else
            {
                this.Hide();
                action?.Invoke(4, 0, 0);

            }
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(0, 2, 1);
            else
            {
                this.Hide();
                action?.Invoke(5, 0, 0);

            }
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(2, -1, 0);
            else
            {
                this.Hide();
                action?.Invoke(6, 0, 0);

            }
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(0, 2, 3);
            else
            {
                this.Hide();
                action?.Invoke(7, 0, 0);

            }
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(3, 3, 1);
            else
            {
                this.Hide();
                action?.Invoke(8, 0, 0);

            }
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(0, 2, 0);
            else
            {
                this.Hide();
                action?.Invoke(9, 0, 0);

            }
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(0, 2, 1);
            else
            {
                this.Hide();
                action?.Invoke(10, 0, 0);

            }
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(3, 3, 2);
            else
            {
                this.Hide();
                action?.Invoke(11, 0, 0);

            }
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (a == 0)
                action?.Invoke(3, 3, 0);
            else
            {
                this.Hide();
                action?.Invoke(12, 0, 0);

            }
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
            if (a == 0)
                action?.Invoke(5, -1, 0);
            else
            {
                this.Hide();
                action?.Invoke(15, 0, 0);

            }
            this.Close();
        }
    }
}
