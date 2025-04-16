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
    public partial class ProfTraining : Form
    {
        ProfessionalRetrainingInf professional;
        Action<ProfessionalRetrainingInf> action;
        public ProfTraining()
        {
            InitializeComponent();
        }
        public ProfTraining(ProfessionalRetrainingInf professional, Action<ProfessionalRetrainingInf> action)
        {
            InitializeComponent();
            this.professional = professional;
            this.action = action;
            if (professional.Date_give_doc <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker1.Value = professional.Date_start > DateTime.MinValue ? professional.Date_start : DateTime.Now; 
            dateTimePicker2.Value = professional.Date_end > DateTime.MinValue ? professional.Date_end : DateTime.Now; 
            dateTimePicker3.Value = professional.Date_give_doc > DateTime.MinValue ? professional.Date_give_doc : DateTime.Now; 
            textBox1.Text = professional.Speciality;
            textBox2.Text = professional.Name_doc;
            textBox3.Text = professional.Num_doc;
            textBox4.Text = professional.Reason;
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
           String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            professional.Speciality = textBox1.Text;
            professional.Name_doc = textBox2.Text;
            professional.Num_doc = textBox3.Text;
            professional.Reason = textBox4.Text;
            professional.Date_start = dateTimePicker1.Value;
            professional.Date_end = dateTimePicker2.Value;
            professional.Date_give_doc = dateTimePicker3.Value;
            action?.Invoke(professional);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
