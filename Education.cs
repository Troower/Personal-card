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
    public partial class Education : Form
    {
        EducationInf education;
        Action<EducationInf> action;
        int add = 0;
        //редактирование
        public Education(EducationInf education, Action<EducationInf> action)
        {
            InitializeComponent();
            this.education = education;
            textBox7.Text=education.Name_orgnisation;
            comboBox1.Text = education.Type_education;
            textBox1.Text = education.Name_doc_education;
            textBox2.Text = education.Serial_doc_education;
            textBox3.Text = education.Num_doc_education;
            textBox6.Text = education.Year_end.ToString();
            textBox4.Text = education.Qualification_doc_education;
            textBox5.Text = education.Direction_or_specialty;
            this.action = action;
        }
        public Education(EducationInf education)
        {
            InitializeComponent();
            this.education = education;
            comboBox1.Text = education.Type_education;
            textBox7.Text = education.Name_orgnisation;
            textBox1.Text = education.Name_doc_education;
            textBox2.Text = education.Serial_doc_education;
            textBox3.Text = education.Num_doc_education;
            textBox6.Text = education.Year_end.ToString();
            textBox4.Text = education.Qualification_doc_education;
            textBox5.Text = education.Direction_or_specialty;
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox6.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            tableLayoutPanel1.Visible = false;
        }
        
        //добавление
        public Education(int id, Action<EducationInf> action)
        {
            InitializeComponent();
            add = id;
            this.action = action;
            button1.Text = "Добавить";
        }
        public Education()
        {
            InitializeComponent();
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (comboBox1.SelectedIndex == -1 ||
            String.IsNullOrEmpty(textBox1.Text) ||
            String.IsNullOrEmpty(textBox2.Text) ||
            String.IsNullOrEmpty(textBox3.Text) ||
            String.IsNullOrEmpty(textBox6.Text) ||
            String.IsNullOrEmpty(textBox4.Text) ||
            String.IsNullOrEmpty(textBox5.Text) ||
             String.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Int32.TryParse(textBox6.Text, out a) || a > DateTime.Now.Year || a < 1950)
            {
                MessageBox.Show("Год не соответствует требованиям!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (add != 0)
            {
                EducationInf education = new EducationInf();
                education.ID_empl = add;
                education.Name_orgnisation = textBox7.Text;
                education.Type_education = comboBox1.Text;
                education.Name_doc_education = textBox1.Text;
                education.Serial_doc_education = textBox2.Text;
                education.Num_doc_education = textBox3.Text;
                education.Year_end = a;
                education.Qualification_doc_education = textBox4.Text;
                education.Direction_or_specialty = textBox5.Text;
                action?.Invoke(education);

            }
            else
            {
                education.Name_orgnisation = textBox7.Text;
                education.Type_education = comboBox1.Text;
                education.Name_doc_education = textBox1.Text;
                education.Serial_doc_education = textBox2.Text;
                education.Num_doc_education = textBox3.Text;
                education.Year_end = a;
                education.Qualification_doc_education = textBox4.Text;
                education.Direction_or_specialty = textBox5.Text;
                action?.Invoke(education);
                MessageBox.Show("Редактирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }


            this.Close();
        }
    }
}
