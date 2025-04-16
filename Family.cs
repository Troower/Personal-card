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
            comboBox1.Text = famaly.Degree_of_kinship;
            textBox2.Text = famaly.FIO;
            dateTimePicker1.Value = famaly.Date_birth;
        }
        public Family(int id, Action<FamilyCompositionInf> action)
        {
            InitializeComponent();
            this.id = id;
            this.action = action;
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
            if (String.IsNullOrEmpty(textBox2.Text)||comboBox1.SelectedIndex==-1) { 
            MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (id != 0)
            {
                FamilyCompositionInf famaly = new FamilyCompositionInf();
                famaly.ID_empl = id;
                famaly.Degree_of_kinship = comboBox1.Text;
                famaly.FIO = textBox2.Text;
                famaly.Date_birth = dateTimePicker1.Value;
                action?.Invoke(famaly);
            }
            else
            {
                famaly.Degree_of_kinship = comboBox1.Text;
                famaly.FIO = textBox2.Text;
                famaly.Date_birth = dateTimePicker1.Value;
                action?.Invoke(famaly);
                MessageBox.Show("Редактирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            this.Close();
        }
    }
}
