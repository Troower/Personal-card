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
    public partial class Award : Form
    {
        AwardInf award;
        Action<AwardInf> action;
        public Award()
        {
            InitializeComponent();
        }
        public Award(AwardInf award, Action<AwardInf> action)
        {
            InitializeComponent();
            this.award = award;
            this.action = action;
            if (award.Date_give_doc <= DateTime.MinValue)
            {
                button1.Text = "Добавить";
            }
            dateTimePicker1.Value = award.Date_give_doc > DateTime.MinValue ? award.Date_give_doc : DateTime.Now;
            textBox1.Text = award.Name_reward;
            textBox2.Text = award.Name_doc;
            textBox3.Text = award.Num_doc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) ||
           String.IsNullOrEmpty(textBox2.Text) ||
           String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            award.Date_give_doc = dateTimePicker1.Value;
            award.Name_reward = textBox1.Text;
            award.Name_doc = textBox2.Text;
            award.Num_doc = textBox3.Text;
            action?.Invoke(award);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
