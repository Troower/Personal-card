using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;

namespace PersonalCard
{
    public partial class EditPersonalInfo : Form
    {
        public EditPersonalInfo()
        {
            InitializeComponent();
        }

        public EditPersonalInfo(int a)
        {
            InitializeComponent();

            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[0].Width = 33;
            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[1].Width = 33;
            tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[2].Width = 33;
            button1.Text = "Сохранить";

            tableLayoutPanel1.Controls.Add(button4, 2, 0);
            button4.Dock = DockStyle.Fill;

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Sections((int a,int b,int c) => {
                if (a == 1) { new Profesion().ShowDialog(); }
                else if (a == 2) { new Benefit().ShowDialog(); }
                else if (a == 3) { new Vacation().ShowDialog(); }
                else if (a == 4) { new Military().ShowDialog(); }
                else if (a == 5) { new Education().ShowDialog(); }
                else if (a == 6) { new HiringTransfer().ShowDialog(); }
                else if (a == 7) { new Family().ShowDialog(); }
                else if (a == 8) { new AdvTraining().ShowDialog(); }
                else if (a == 9) {  }
                else if (a == 10) { new Education().ShowDialog(); }
                else if (a == 11) { new ProfTraining().ShowDialog(); }
                else if (a == 12) { new Сertification().ShowDialog(); }
                else if (a == 13) { new Profesion().ShowDialog(); }
                else if (a == 14) { new Award().ShowDialog(); }
                else { new Additional().ShowDialog(); }
                

            },1).ShowDialog();
        }
    }
}
