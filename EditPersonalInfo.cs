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
            tableLayoutPanel1.ColumnStyles[0].Width=33;
            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[1].Width = 33;
            tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[2].Width = 33;
            button1.Text = "Сохранить";
           
            tableLayoutPanel1.Controls.Add(button4, 2, 0);
            button4.Dock=DockStyle.Fill;
            button4.Click += (e, a) => {
                new Sections((int a,int b, int c) => { 
                

                }).ShowDialog();
            };
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
    }
}
