using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonalCard
{
    public partial class AfterEducation : Form
    {
        AfterEducationInf afterEducation;
        Action<AfterEducationInf> action;
        int add = 0;
        
        public AfterEducation(AfterEducationInf afterEducation, Action<AfterEducationInf> action)
        {
            InitializeComponent();
            this.afterEducation = afterEducation;
            this.action = action;
            if(!String.IsNullOrEmpty(afterEducation.Type_education)) comboBox1.Text = afterEducation.Type_education;
            textBox7.Text = afterEducation.Name_organisation;
            textBox1.Text=afterEducation.Name_education_docAfter;
            textBox3.Text = afterEducation.Num_doc_education;
            dateTimePicker1.Value = afterEducation.Date_give_doc >DateTime.MinValue ?  afterEducation.Date_give_doc:DateTime.Now ;
            textBox6.Text=afterEducation.Year_end.ToString();
            textBox5.Text = afterEducation.Direction_or_speciality;
        }

        public AfterEducation(int add)
        {
            InitializeComponent();
        }

        //Просмотр инф.
        public AfterEducation(AfterEducationInf afterEducation)
        {
            InitializeComponent();
            this.afterEducation = afterEducation;
            
            comboBox1.Text = afterEducation.Type_education;
            textBox7.Text = afterEducation.Name_organisation;
            textBox1.Text = afterEducation.Name_education_docAfter;
            textBox3.Text = afterEducation.Num_doc_education;
            dateTimePicker1.Value = afterEducation.Date_give_doc > DateTime.MinValue ? afterEducation.Date_give_doc : DateTime.Now;
            textBox6.Text = afterEducation.Year_end.ToString();
            textBox5.Text = afterEducation.Direction_or_speciality;
            comboBox1.Enabled = false;
            textBox1.Enabled = false;
            textBox7.Enabled = false;
            textBox3.Enabled = false;
            textBox6.Enabled = false;
            dateTimePicker1.Enabled = false;
            textBox5.Enabled = false;
            
            tableLayoutPanel1.Visible = false;
            this.Size = new System.Drawing.Size(this.Width, this.Height - tableLayoutPanel1.Height);
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
            String.IsNullOrEmpty(textBox7.Text) ||
            String.IsNullOrEmpty(textBox3.Text) ||
            String.IsNullOrEmpty(textBox6.Text) ||
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
            afterEducation.Type_education = comboBox1.Text;
            afterEducation.Name_organisation = textBox7.Text;
            afterEducation.Name_education_docAfter = textBox1.Text;
            afterEducation.Num_doc_education = textBox3.Text;
            afterEducation.Date_give_doc = dateTimePicker1.Value;
            afterEducation.Year_end = a;
            afterEducation.Direction_or_speciality = textBox5.Text;
            action?.Invoke(afterEducation);
            MessageBox.Show("Редактирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
