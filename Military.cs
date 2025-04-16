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
    public partial class Military : Form
    {
        MilitaryRegistrationInf military;
        Action<MilitaryRegistrationInf>action;
        public Military()
        {
            InitializeComponent();
        }
        public Military( MilitaryRegistrationInf military,Action<MilitaryRegistrationInf>action)
        {
            InitializeComponent();
            this.action = action;
            this.military = military;
            textBox1.Text=military.Category;
            textBox2.Text=military.Military_rank;
            textBox3.Text=military.Structure;
            textBox5.Text=military.Category_life;
            textBox6.Text=military.Military_commissariat_name;
            textBox4.Text = military.Code_mas;
            textBox8.Text = military.De_registration;
            comboBox1.Text = military.Name_type;
            textBox7.Text=military.Additional_information;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 ||
            String.IsNullOrEmpty(textBox1.Text) ||
            String.IsNullOrEmpty(textBox2.Text) ||
            String.IsNullOrEmpty(textBox3.Text) ||
            String.IsNullOrEmpty(textBox6.Text) ||
            String.IsNullOrEmpty(textBox4.Text) ||
            String.IsNullOrEmpty(textBox5.Text) ||
             String.IsNullOrEmpty(textBox7.Text) ||
            String.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            military.Category = textBox1.Text;
            military.Military_rank = textBox2.Text;
            military.Structure = textBox3.Text;
            military.Category_life = textBox5.Text;
            military.Military_commissariat_name = textBox6.Text;
            military.Code_mas = textBox4.Text;
            military.De_registration = textBox8.Text;
            military.Name_type = comboBox1.Text;
            military.Additional_information = textBox7.Text;
            action?.Invoke(military);
            MessageBox.Show("Редактирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
