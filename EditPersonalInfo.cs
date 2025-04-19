using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.ApplicationServices;

namespace PersonalCard
{
    public partial class EditPersonalInfo : Form
    {
        //Редактирование
        GeneralInformation generalInformation;
        Action<GeneralInformation> action;
        public EditPersonalInfo(GeneralInformation generalInformation, Action<GeneralInformation> action)
        {
            InitializeComponent();
            this.generalInformation = generalInformation;
            this.action = action;
            textBox2.Text = generalInformation.Name;
            textBox1.Text = generalInformation.Last_name;
            textBox3.Text = generalInformation.Surname;
            dateTimePicker1.Value = generalInformation.Birthday;
            textBox4.Text = generalInformation.Place_birth;
            textBox5.Text = generalInformation.Citizenship;
            comboBox1.Text = generalInformation.Male_Female;
            comboBox2.Text = generalInformation.Nature_work;
            comboBox3.Text = generalInformation.Type_work;
            comboBox5.Text = generalInformation.Marital_status;
            textBox6.Text = generalInformation.Nam_passport;
            textBox7.Text = generalInformation.Serial_passport;
            dateTimePicker2.Value = generalInformation.Date_give_passport;
            textBox9.Text = generalInformation.Who_give;
            textBox10.Text = generalInformation.INN;
            textBox11.Text = generalInformation.Num_pensia;
            textBox16.Text = generalInformation.Address.Actual;
            textBox14.Text = generalInformation.Address.By_registration;
            textBox17.Text = generalInformation.Address.Index_actual;
            textBox15.Text = generalInformation.Address.Index_by_register;
            textBox8.Text= generalInformation.Number_phone ;
            textBox13.Text = generalInformation.T_num_card;
            dateTimePicker3.Value=generalInformation.Hirring_date;
            listBox1.Controls.Clear();
            foreach (LanguageInf l in generalInformation.Languages)
            {
                listBox1.Items.Add($"{l.Language_name}:{l.Degree_of_knowledge}");
            }

            ;
        }


        //Транзакция добавлеения!
        public EditPersonalInfo(int a, Action<GeneralInformation> action)
        {
            InitializeComponent();
            tableLayoutPanel1.ColumnStyles[0].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[0].Width = 33;
            tableLayoutPanel1.ColumnStyles[1].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[1].Width = 33;
            tableLayoutPanel1.ColumnStyles[2].SizeType = SizeType.Percent;
            tableLayoutPanel1.ColumnStyles[2].Width = 33;
            button1.Text = "Сохранить";
            tableLayoutPanel1.Controls.Add(button4, 2, 0);
            button4.Dock = DockStyle.Fill;
            generalInformation = new GeneralInformation();
            generalInformation.Address = new AddressOfResidenceInf();
            generalInformation.Languages = new List<LanguageInf>();
            this.action = action;
        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox12.Text) || comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Для добавление языка, должно быть введенно название языка и выбранна степень его знания", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                listBox1.Items.Add($"{textBox12.Text}:{comboBox4.Items[comboBox4.SelectedIndex]}");
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Sections((int a, int b, int c) =>
            {
                if (a == 1)
                {
                    ProfessionInf profession;
                    WorkExperienceInf workExperience;
                    if (HasData(generalInformation.Profession) || HasData(generalInformation.WorkExperience))
                    {
                        profession = generalInformation.Profession;
                        workExperience = generalInformation.WorkExperience;
                    }
                    else
                    {
                        profession = new ProfessionInf();
                        workExperience = new WorkExperienceInf();
                    }
                    new Profesion(profession, workExperience, (ProfessionInf profession, WorkExperienceInf workExperience) =>
                    {

                        generalInformation.Profession = profession;
                        generalInformation.WorkExperience = workExperience;
                    }).ShowDialog();
                }
                else if (a == 2)
                {
                    if (generalInformation.SocialBenefits == null)generalInformation.SocialBenefits = new();
                        SocialBenefitInf socialBenefit = new();
                    
                    new Benefit(socialBenefit, (SocialBenefitInf socialBenefit) =>
                    {

                        generalInformation.SocialBenefits.Add(socialBenefit);
                    }).ShowDialog();
                }
                else if (a == 3)
                {
                    if (generalInformation.Vacations == null) generalInformation.Vacations = new();
                    VacationInf vacation = new VacationInf();

                    new Vacation(vacation, (VacationInf vacation) =>
                    {

                        generalInformation.Vacations.Add(vacation);
                    }).ShowDialog();
                }
                else if (a == 4)
                {
                    MilitaryRegistrationInf militaryRegistration;
                    if (HasData(generalInformation.MilitaryRegistration))
                    {
                        militaryRegistration = generalInformation.MilitaryRegistration;
                    }
                    else
                    {
                        militaryRegistration = new MilitaryRegistrationInf();
                    }
                    new Military(militaryRegistration, (MilitaryRegistrationInf militaryRegistration) =>
                    {

                        generalInformation.MilitaryRegistration = militaryRegistration;
                    }).ShowDialog();
                }
                else if (a == 5)
                {
                    AfterEducationInf afterEducation;
                    if (HasData(generalInformation.AfterEducation))
                    {
                        afterEducation = generalInformation.AfterEducation;
                    }
                    else
                    {
                        afterEducation = new();
                    }
                    new AfterEducation(afterEducation, (AfterEducationInf afterEducation) =>
                    {

                        generalInformation.AfterEducation = afterEducation;
                    }).ShowDialog();
                }
                else if (a == 6)
                {
                    if (generalInformation.HiringTransfers == null)
                        generalInformation.HiringTransfers = new();
                    HiringTransferInf hiringTransfer = new HiringTransferInf();
                    new HiringTransfer(hiringTransfer, (HiringTransferInf hiringTransfer) =>
                    {
                        generalInformation.HiringTransfers.Add(hiringTransfer);
                    }).ShowDialog();
                }
                else if (a == 7)
                {
                    if (generalInformation.FamilyCompositions == null)
                        generalInformation.FamilyCompositions = new();
                    FamilyCompositionInf familyComposition = new FamilyCompositionInf();
                    new Family(familyComposition, (FamilyCompositionInf familyComposition) =>
                    {
                        generalInformation.FamilyCompositions.Add(familyComposition);
                    }).ShowDialog();
                }
                else if (a == 8)
                {
                    if (generalInformation.ProfessionalDevelopments == null)
                        generalInformation.ProfessionalDevelopments = new();
                    ProfessionalDevelopmentInf professionalDevelopment = new ProfessionalDevelopmentInf();
                    new AdvTraining(professionalDevelopment, (ProfessionalDevelopmentInf professionalDevelopment) =>
                    {
                        generalInformation.ProfessionalDevelopments.Add(professionalDevelopment);
                    }).ShowDialog();
                }
                else if (a == 10)
                {
                    if (generalInformation.Educations == null)
                        generalInformation.Educations = new();
                    EducationInf education = new EducationInf();
                    new Education(education, (EducationInf education) =>
                    {
                        generalInformation.Educations.Add(education);
                    }).ShowDialog();
                }
                else if (a == 11)
                {
                    if (generalInformation.ProfessionalRetrainings == null)
                        generalInformation.ProfessionalRetrainings = new();
                    ProfessionalRetrainingInf professionalRetraining = new ProfessionalRetrainingInf();
                    new ProfTraining(professionalRetraining, (ProfessionalRetrainingInf professionalRetraining) =>
                    {
                        generalInformation.ProfessionalRetrainings.Add(professionalRetraining);
                    }).ShowDialog();
                }
                else if (a == 12)
                {
                    if (generalInformation.Certifications == null)
                        generalInformation.Certifications = new();
                    CertificationInf certification = new CertificationInf();
                    new Сertification(certification, (CertificationInf certification) =>
                    {
                        generalInformation.Certifications.Add(certification);
                    }).ShowDialog();
                }
                else if (a == 13)
                {
                    ProfessionInf profession;
                    WorkExperienceInf workExperience;
                    if (HasData(generalInformation.Profession) || HasData(generalInformation.WorkExperience))
                    {
                        profession = generalInformation.Profession;
                        workExperience = generalInformation.WorkExperience;
                    }
                    else
                    {
                        profession = new ProfessionInf();
                        workExperience = new WorkExperienceInf();
                    }
                    new Profesion(profession, workExperience, (ProfessionInf profession, WorkExperienceInf workExperience) =>
                    {
                        generalInformation.Profession = profession;
                        generalInformation.WorkExperience = workExperience;
                    }).ShowDialog();
                }
                else if (a == 14)
                {
                    if (generalInformation.Awards == null)
                        generalInformation.Awards = new();
                    AwardInf award = new AwardInf();
                    new Award(award, (AwardInf award) =>
                    {
                        generalInformation.Awards.Add(award);
                    }).ShowDialog();
                }
                else
                {
                    if (generalInformation.AdditionalInformations == null)
                        generalInformation.AdditionalInformations = new();
                    AdditionalInformationInf additionalInformation = new AdditionalInformationInf();
                    new Additional(additionalInformation, (AdditionalInformationInf additionalInformation) =>
                    {
                        generalInformation.AdditionalInformations.Add(additionalInformation);
                    }).ShowDialog();
                }


            }, 1).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) return;
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox1.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox4.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox5.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox6.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox7.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox9.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox10.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox11.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox16.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox17.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox14.Text)) { alertNull(); return; }
            if (String.IsNullOrEmpty(textBox15.Text)) { alertNull(); return; }
            if (DateTime.Now.Year - dateTimePicker1.Value.Year < 16)
            {
                MessageBox.Show("Сотрудник должен быть старше 16 лет", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            if (comboBox1.SelectedIndex == -1) { alertNull(); return; }
            if (comboBox2.SelectedIndex == -1) { alertNull(); return; }
            if (comboBox3.SelectedIndex == -1) { alertNull(); return; }
            if (comboBox5.SelectedIndex == -1) { alertNull(); return; }



            generalInformation.Name = textBox2.Text;
            generalInformation.Last_name = textBox1.Text;
            generalInformation.Surname = textBox3.Text;
            generalInformation.Birthday = dateTimePicker1.Value;
            generalInformation.Place_birth = textBox4.Text;
            generalInformation.Citizenship = textBox5.Text;
            generalInformation.Male_Female = comboBox1.Text;
            generalInformation.Nature_work = comboBox2.Text;
            generalInformation.Type_work = comboBox3.Text;
            generalInformation.Marital_status = comboBox5.Text;
            generalInformation.Nam_passport = textBox6.Text;
            generalInformation.Serial_passport = textBox7.Text;
            generalInformation.Date_give_passport = dateTimePicker2.Value;
            generalInformation.Who_give = textBox9.Text;
            generalInformation.INN = textBox10.Text;
            generalInformation.Num_pensia = textBox11.Text;
            generalInformation.Address.Actual = textBox16.Text;
            generalInformation.Address.By_registration = textBox14.Text;
            generalInformation.Address.Index_actual = textBox17.Text;
            generalInformation.Address.Index_by_register = textBox15.Text;
            generalInformation.Number_phone=textBox8.Text;
            generalInformation.T_num_card=textBox13.Text;
            generalInformation.First_char_lastname = generalInformation.Last_name[0].ToString();
            generalInformation.Hirring_date =dateTimePicker3.Value;
            generalInformation.Languages.Clear();
            LanguageInf l;
            foreach (string s in listBox1.Items)
            {
                l = new LanguageInf();
                l.Language_name = s.Split(':')[0];
                l.Degree_of_knowledge = s.Split(':')[1];
                l.ID_empl = generalInformation.ID_empl;
                generalInformation.Languages.Add(l);
            }
            action?.Invoke(generalInformation);
            MessageBox.Show("Операция прошла успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.Close();
        }

        private void alertNull()
        {
            MessageBox.Show("Заполните все необходимые поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            foreach (Control c in this.Controls)
            {
                if (c is GroupBox)
                {
                    foreach (Control c2 in c.Controls)
                    {
                        if (c2 is FlowLayoutPanel)
                        {
                            foreach (Control c3 in c2.Controls)
                            {
                                if (c3 is Label)
                                {
                                    if (((Label)c3).Text.IndexOf('*') != -1)
                                    {

                                        ((Label)c3).ForeColor = Color.Red;

                                    }
                                }
                            }
                        }


                    }
                }

            }

        }
        public static bool HasData(object obj)
        {
            if (obj == null)
                return false;
            var type = obj.GetType();
            var properties = type.GetProperties();

            foreach (var property in properties)
            {

                if (property.Name == "ID_empl") continue;
                var value = property.GetValue(obj);
                if (value is string str && !string.IsNullOrEmpty(str)) return true;
                if (value is DateTime date && date != default(DateTime)) return true;
                if (value is int intValue && intValue != 0) return true;

            }
            return false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
