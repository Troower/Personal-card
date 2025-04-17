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
    public partial class Family : Form
    {
        FamilyCompositionInf famaly;
        Action<FamilyCompositionInf> action;
        int id;
        public Family(FamilyCompositionInf famaly, Action<FamilyCompositionInf> action)
        {
            InitializeComponent();
            this.famaly = famaly;
            this.action = action;
            if (famaly.Date_birth <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker1.Value = famaly.Date_birth > DateTime.MinValue ? famaly.Date_birth : DateTime.Now;
            if (!String.IsNullOrEmpty(famaly.Degree_of_kinship)) comboBox1.Text = famaly.Degree_of_kinship;
            textBox2.Text = famaly.FIO;
        }

        public Family(FamilyCompositionInf famaly)
        {
            InitializeComponent();
            this.famaly = famaly;
            comboBox1.Text = famaly.Degree_of_kinship;
            textBox2.Text = famaly.FIO;
            dateTimePicker1.Value = famaly.Date_birth > DateTime.MinValue ? famaly.Date_birth : DateTime.Now;
            comboBox1.Enabled = false;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            tableLayoutPanel1.Visible = false;
            this.Size = new System.Drawing.Size(this.Width, this.Height - tableLayoutPanel1.Height);

        }
        public Family()
        {
            InitializeComponent();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            famaly.Degree_of_kinship = comboBox1.Text;
            famaly.FIO = textBox2.Text;
            famaly.Date_birth = dateTimePicker1.Value;
            action?.Invoke(famaly);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            this.Close();
        }
    }
}
