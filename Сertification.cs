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
    public partial class Сertification : Form
    {
        CertificationInf certification;
        Action<CertificationInf> action;
        public Сertification()
        {
            InitializeComponent();
        }
        public Сertification(CertificationInf certification, Action<CertificationInf> action)
        {
            InitializeComponent();
            this.action = action;
            this.certification = certification;
            if (certification.Date_att <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker1.Value = certification.Date_att > DateTime.MinValue ? certification.Date_att : DateTime.Now;
            dateTimePicker2.Value = certification.Date_doc > DateTime.MinValue ? certification.Date_doc : DateTime.Now; 
            textBox2.Text = certification.Decision;
            textBox3.Text = certification.Num_doc;
            textBox4.Text = certification.Reason;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) ||
           String.IsNullOrEmpty(textBox3.Text) ||
           String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            certification.Date_att=dateTimePicker1.Value;
            certification.Date_doc=dateTimePicker2.Value;
            certification.Decision=textBox2.Text;
            certification.Num_doc = textBox3.Text;
            certification.Reason=textBox4.Text;
            action?.Invoke(certification);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          this.Close();
        }
    }
}
