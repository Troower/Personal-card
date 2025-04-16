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
    public partial class AdvTraining : Form
    {
        ProfessionalDevelopmentInf professional;
        Action<ProfessionalDevelopmentInf> action;
        public AdvTraining(ProfessionalDevelopmentInf professional, Action<ProfessionalDevelopmentInf> action)
        {
            InitializeComponent();
            this.professional = professional;
            this.action = action;
            if (professional.Date_give_doc <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker1.Value=professional.Date_start > DateTime.MinValue ? professional.Date_start : DateTime.Now; 
            dateTimePicker2.Value=professional.Date_end > DateTime.MinValue ? professional.Date_end : DateTime.Now;
            dateTimePicker3.Value=professional.Date_give_doc > DateTime.MinValue ? professional.Date_give_doc : DateTime.Now; 
            textBox1.Text =professional.Type_cvalification;
            textBox2.Text =professional.Name_education_company;
            textBox3.Text =professional.Name_doc;
            textBox4.Text =professional.Ser_doc;
            textBox6.Text =professional.Num_doc;
            textBox5.Text =professional.Reason;
        }
        public AdvTraining()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
           String.IsNullOrEmpty(textBox2.Text) ||
           String.IsNullOrEmpty(textBox3.Text) ||
           String.IsNullOrEmpty(textBox6.Text) ||
           String.IsNullOrEmpty(textBox4.Text) ||
           String.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            professional.Type_cvalification = textBox1.Text;
            professional.Name_education_company = textBox2.Text;
            professional.Name_doc = textBox3.Text;
            professional.Ser_doc = textBox4.Text;
            professional.Num_doc = textBox6.Text;
            professional.Reason = textBox5.Text;
            professional.Date_start = dateTimePicker1.Value;
            professional.Date_end = dateTimePicker2.Value;
            professional.Date_give_doc = dateTimePicker3.Value;
            action?.Invoke(professional);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
