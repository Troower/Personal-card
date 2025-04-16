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
    public partial class Profesion : Form
    {
        ProfessionInf profession;
        WorkExperienceInf workExperience;
        Action<ProfessionInf, WorkExperienceInf> action;
        public Profesion()
        {
            InitializeComponent();
        }
        public Profesion(ProfessionInf profession, WorkExperienceInf workExperience, Action<ProfessionInf, WorkExperienceInf> action)
        {
            InitializeComponent();
            this.profession = profession;
            this.workExperience = workExperience;
            this.action = action;
            numericUpDown1.Value = workExperience.Common_day;
            numericUpDown2.Value = workExperience.Common_month;
            numericUpDown3.Value = workExperience.Common_year;
            numericUpDown4.Value = workExperience.Continuous_day;
            numericUpDown5.Value = workExperience.Continuous_month;
            numericUpDown6.Value = workExperience.Continuous_year;
            numericUpDown7.Value = workExperience.Giver_day;
            numericUpDown8.Value = workExperience.Giver_month;
            numericUpDown9.Value = workExperience.Giver_year;
            textBox1.Text = profession.Basic;
            textBox2.Text=profession.Another;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            workExperience.Common_day = ((int)numericUpDown1.Value);
            workExperience.Common_month = ((int)numericUpDown2.Value);
            workExperience.Common_year = ((int)numericUpDown3.Value);
            workExperience.Continuous_day = ((int)numericUpDown4.Value);
            workExperience.Continuous_month = ((int)numericUpDown5.Value);
            workExperience.Continuous_year = ((int)numericUpDown6.Value);
            workExperience.Giver_day = ((int)numericUpDown7.Value);
            workExperience.Giver_month = ((int)numericUpDown8.Value);
            workExperience.Giver_year = ((int)numericUpDown9.Value);
            profession.Basic = textBox1.Text;
            profession.Another = textBox2.Text;
            action?.Invoke(profession, workExperience);
            MessageBox.Show("Редактирование прошло успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }
    }
}
