using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Modes;
using PersonalCard.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ZstdSharp.Unsafe;

namespace PersonalCard
{
    public partial class Authorization : Form
    {
        public Authorization()
        {

            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigConnection cnf = ConfigReader.ReadConfig();
            MySqlConnection conn = new MySqlConnection(cnf.ToString());
            conn.Open();
            string sql = $"SELECT `password`, `lock`, `role` from `Users` where `login` = @login";
           
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@login", textBox1.Text);
            string connectionString="";
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    MessageBox.Show("Данные для входа неверны!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (reader.Read())
                {
                    if (!PwdHash.VerifyPassword(textBox2.Text, reader.GetString(0)))
                    {
                        MessageBox.Show("Данные для входа неверны!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (reader.GetInt32(1) == 1)
                    {
                        MessageBox.Show("Пользователь заблокировани!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    connectionString= cnf.Server+cnf.Database+"UID="+reader.GetString(2)+";Pwd=;";
                }
            }
            conn.Close();
            MainWindow mainWindow = new MainWindow(connectionString);
            this.Hide();
            mainWindow.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            ConfigConnection cc = ConfigReader.ReadConfig();
            if (checkDatabase() == false)
            {
                if (MessageBox.Show($"База данных c именем '{cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}' отсутствует на сервере. Если база есть на сервере, нажмите отмена и проверьте соответствие имени в файле config.ini. Если вы хотите создать базу данных с таким именем, нажмите ок ",
                    "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    createDB();
                }
            }
        }



        private bool checkDatabase()
        {
            ConfigConnection cc = ConfigReader.ReadConfig();

            MySqlConnection conn = new MySqlConnection(cc.Server + cc.Uid + cc.Password);
            conn.Open();
            string sql = $"SHOW DATABASES";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))

            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2))
                        {
                            conn.Close();
                            return true;
                        }
                    }
                }

            }
            conn.Close();
            return false;
        }
        private void createPerson()
        {
            ConfigConnection cc = ConfigReader.ReadConfig();

            MySqlConnection conn = new MySqlConnection(cc.Server + cc.Uid + cc.Password);
            conn.Open();

            string sql = $"CREATE USER IF NOT EXISTS 'AdminHR'@'localhost' \r\nWITH MAX_QUERIES_PER_HOUR 0 \r\nMAX_CONNECTIONS_PER_HOUR 0 \r\nMAX_UPDATES_PER_HOUR 0 \r\nMAX_USER_CONNECTIONS 0;\r\n\r\nGRANT ALL PRIVILEGES ON {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}.* TO 'AdminHR'@'localhost';";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = $"CREATE USER IF NOT EXISTS 'ManagerHR'@'localhost'\r\nWITH MAX_QUERIES_PER_HOUR 0 \r\nMAX_CONNECTIONS_PER_HOUR 0 \r\nMAX_UPDATES_PER_HOUR 0 \r\nMAX_USER_CONNECTIONS 0;\r\n\r\nGRANT SELECT, INSERT, UPDATE, DELETE, EXECUTE \r\nON {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}.* TO 'ManagerHR'@'localhost';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = $"CREATE USER IF NOT EXISTS 'UserHR'@'localhost'\r\nWITH MAX_QUERIES_PER_HOUR 0 \r\nMAX_CONNECTIONS_PER_HOUR 0 \r\nMAX_UPDATES_PER_HOUR 0 \r\nMAX_USER_CONNECTIONS 0;\r\n\r\nGRANT SELECT, SHOW VIEW \r\nON {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}.* TO 'UserHR'@'localhost';";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void createDB()
        {
            ConfigConnection cc = ConfigReader.ReadConfig();

            MySqlConnection conn = new MySqlConnection(cc.Server + cc.Uid + cc.Password);
            conn.Open();

            string sql = $"Create database {cc.Database.Substring(cc.Database.IndexOf('=') + 1, cc.Database.Substring(cc.Database.IndexOf('=')).Length - 2)}";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn = new MySqlConnection(cc.ToString());
            conn.Open();
            sql = $"SET time_zone = \"+00:00\";\r\n\r\n\r\n/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;\r\n/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;\r\n/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;\r\n/*!40101 SET NAMES utf8mb4 */;\r\n\r\n--\r\n-- База данных: `Personal_card`\r\n--\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `Additional_information`\r\n--\r\n\r\nCREATE TABLE `Additional_information` (\r\n  `ID_mixing` int NOT NULL,\r\n  `Information` varchar(200) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `address_of_residence`\r\n--\r\n\r\nCREATE TABLE `address_of_residence` (\r\n  `by_registration` varchar(200) NOT NULL,\r\n  `actual` varchar(200) NOT NULL,\r\n  `Index_by_register` char(10) NOT NULL,\r\n  `index_actual` varchar(10) NOT NULL,\r\n  `date_registration` date NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n--\r\n-- Структура таблицы `Users`\r\n--\r\n\r\nCREATE TABLE `Users` (\r\n  `id_User` int NOT NULL,\r\n  `Name` varchar(100) NOT NULL,\r\n  `LastName` varchar(100) NOT NULL,\r\n  `Surname` varchar(100) DEFAULT NULL,\r\n  `login` varchar(100) NOT NULL,\r\n  `password` varchar(225) NOT NULL,\r\n  `role` varchar(20) NOT NULL,\r\n `lock` tinyint(2) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;\r\n\r\n-- --------------------------------------------------------\r\n--\r\n-- Структура таблицы `After_Education`\r\n--\r\n\r\nCREATE TABLE `After_Education` (\r\n  `Name_organisation` varchar(100) NOT NULL,\r\n  `Name_education_docAfter` varchar(50) NOT NULL,\r\n  `Num_doc_education` varchar(20) NOT NULL,\r\n  `Year_end` date NOT NULL,\r\n  `Date_give_doc` date NOT NULL,\r\n  `Direction_or_speciality` varchar(100) NOT NULL,\r\n  `Type_education` varchar(100) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n)ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `awards`\r\n--\r\n\r\nCREATE TABLE `awards` (\r\n  `Name_reward` varchar(100) NOT NULL,\r\n  `Name_doc` varchar(100) NOT NULL,\r\n  `Num_doc` varchar(20) NOT NULL,\r\n  `Date_give_doc` date NOT NULL,\r\n  `ID_reward` int NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `certification`\r\n--\r\n\r\nCREATE TABLE `certification` (\r\n  `ID_att` int NOT NULL,\r\n  `Decision` varchar(300) NOT NULL,\r\n  `Num_doc` varchar(20) NOT NULL,\r\n  `Date_doc` date NOT NULL,\r\n  `Reason` varchar(200) NOT NULL,\r\n  `Date_att` date NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `dismissal`\r\n--\r\n\r\nCREATE TABLE `dismissal` (\r\n  `Date_dismiss` date NOT NULL,\r\n  `Num_order` varchar(20) NOT NULL,\r\n  `Date_order` date NOT NULL,\r\n  `ID_empl` int NOT NULL,\r\n  `Reason` varchar(200) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `Education`\r\n--\r\n\r\nCREATE TABLE `Education` (\r\n  `ID_education` int NOT NULL,\r\n  `Name_orgnisation` varchar(100) NOT NULL,\r\n  `Name_doc_education` varchar(50) NOT NULL,\r\n  `Serial_doc_education` varchar(10) NOT NULL,\r\n  `Num_doc_education` varchar(20) NOT NULL,\r\n  `Year_end` int NOT NULL,\r\n  `Qualification_doc_education` varchar(100) NOT NULL,\r\n  `direction_or_specialty` varchar(50) NOT NULL,\r\n  `Code_OKSO` varchar(10) NOT NULL,\r\n  `Type_education` varchar(100) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `family_composition`\r\n--\r\n\r\nCREATE TABLE `family_composition` (\r\n  `FIO` varchar(200) NOT NULL,\r\n  `Degree_of_kinship` varchar(50) NOT NULL,\r\n  `date_birth` date NOT NULL,\r\n  `ID_person` int NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `General_information`\r\n--\r\n\r\nCREATE TABLE `General_information` (\r\n  `ID_empl` int NOT NULL,\r\n  `Last_name` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `Name` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `Surname` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,\r\n  `Birthday` date NOT NULL,\r\n  `Place_birth` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `citizenship` char(30) NOT NULL,\r\n  `marital_status` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `nam_passport` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `serial_passport` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `date_give_passport` date NOT NULL,\r\n  `who_give` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,\r\n  `number_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `Date_create_card` date NOT NULL,\r\n  `T_num_card` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `INN` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `Num_pensia` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,\r\n  `First_char_lastname` varchar(1) NOT NULL,\r\n  `Nature_work` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `Type_work` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `Male_Female` varchar(20) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `hiring_transfer`\r\n--\r\n\r\nCREATE TABLE `hiring_transfer` (\r\n  `ID_empl` int NOT NULL,\r\n  `ID_ht` int NOT NULL,\r\n  `Date` date NOT NULL,\r\n  `Struct` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,\r\n  `position_category` varchar(200) NOT NULL,\r\n  `Tariff_rate` decimal(19,4) NOT NULL,\r\n  `Reason` varchar(300) NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `Language`\r\n--\r\n\r\nCREATE TABLE `Language` (\r\n  `Language_name` varchar(100) NOT NULL,\r\n  `Degree_of_knowledge` varchar(30) NOT NULL,\r\n  `ID_language` int NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `military_registration`\r\n--\r\n\r\nCREATE TABLE `military_registration` (\r\n  `Category` varchar(50) NOT NULL,\r\n  `Military_rank` varchar(40) NOT NULL,\r\n  `Structure` varchar(50) NOT NULL,\r\n  `Code_mas` varchar(50) NOT NULL,\r\n  `Category_life` varchar(20) NOT NULL,\r\n  `Military_commissariat_name` varchar(150) NOT NULL,\r\n  `de_registration` varchar(50) NOT NULL,\r\n  `Name_type` varchar(50) NOT NULL,\r\n  `Additional_information` varchar(100) DEFAULT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `Profession`\r\n--\r\n\r\nCREATE TABLE `Profession` (\r\n  `basic` varchar(50) NOT NULL,\r\n  `another` varchar(50) DEFAULT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `professional_development`\r\n--\r\n\r\nCREATE TABLE `professional_development` (\r\n  `ID_cval` int NOT NULL,\r\n  `Date_start` date NOT NULL,\r\n  `Date_end` date NOT NULL,\r\n  `Type_cvalification` varchar(50) NOT NULL,\r\n  `Name_education_company` varchar(100) NOT NULL,\r\n  `Name_doc` varchar(100) NOT NULL,\r\n  `Ser_doc` varchar(20) NOT NULL,\r\n  `Num_doc` varchar(20) NOT NULL,\r\n  `Date_give_doc` date NOT NULL,\r\n  `Reason` varchar(200) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `professional_retraining`\r\n--\r\n\r\nCREATE TABLE `professional_retraining` (\r\n  `ID_retr` int NOT NULL,\r\n  `Date_start` date NOT NULL,\r\n  `Date_end` date NOT NULL,\r\n  `Name_doc` varchar(100) NOT NULL,\r\n  `Ser_doc` varchar(20) NOT NULL,\r\n  `Num_doc` varchar(20) NOT NULL,\r\n  `Date_give_doc` date NOT NULL,\r\n  `Reason` varchar(200) NOT NULL,\r\n  `Speciality` varchar(100) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `social_benefits`\r\n--\r\n\r\nCREATE TABLE `social_benefits` (\r\n  `ID_ben` int NOT NULL,\r\n  `Name_benefit` varchar(50) NOT NULL,\r\n  `Num_doc` varchar(20) NOT NULL,\r\n  `Date_give_doc` date NOT NULL,\r\n  `Reason` varchar(200) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `vacation`\r\n--\r\n\r\nCREATE TABLE `vacation` (\r\n  `ID_vac` int NOT NULL,\r\n  `Type_vacation` varchar(50) NOT NULL,\r\n  `Period_work_start` date NOT NULL,\r\n  `Period_work_end` date DEFAULT NULL,\r\n  `Quantity_day` int NOT NULL,\r\n  `Date_start` date NOT NULL,\r\n  `Date_end` date NOT NULL,\r\n  `Reason` varchar(200) NOT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n-- --------------------------------------------------------\r\n\r\n--\r\n-- Структура таблицы `work_experience`\r\n--\r\n\r\nCREATE TABLE `work_experience` (\r\n  `common_day` int DEFAULT NULL,\r\n  `common_year` int DEFAULT NULL,\r\n  `common_month` int DEFAULT NULL,\r\n  `continuous_day` int DEFAULT NULL,\r\n  `continuous_month` int DEFAULT NULL,\r\n  `continuous_year` int DEFAULT NULL,\r\n  `giver_day` int DEFAULT NULL,\r\n  `giver_month` int DEFAULT NULL,\r\n  `giver_year` int DEFAULT NULL,\r\n  `ID_empl` int NOT NULL\r\n) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;\r\n\r\n\r\n--\r\n-- Индексы сохранённых таблиц\r\n--\r\n\r\n--\r\n-- Индексы таблицы `Additional_information`\r\n--\r\nALTER TABLE `Additional_information`\r\n  ADD PRIMARY KEY (`ID_mixing`),\r\n  ADD KEY `ID_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `address_of_residence`\r\n--\r\nALTER TABLE `address_of_residence`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `After_Education`\r\n--\r\nALTER TABLE `After_Education`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `awards`\r\n--\r\nALTER TABLE `awards`\r\n  ADD PRIMARY KEY (`ID_reward`),\r\n  ADD KEY `fk_awards_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `certification`\r\n--\r\nALTER TABLE `certification`\r\n  ADD PRIMARY KEY (`ID_att`),\r\n  ADD KEY `fk_certification_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `dismissal`\r\n--\r\nALTER TABLE `dismissal`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `Education`\r\n--\r\nALTER TABLE `Education`\r\n  ADD PRIMARY KEY (`ID_education`),\r\n  ADD KEY `fk_education_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `family_composition`\r\n--\r\nALTER TABLE `family_composition`\r\n  ADD PRIMARY KEY (`ID_person`),\r\n  ADD KEY `fk_family_composition_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `General_information`\r\n--\r\nALTER TABLE `General_information`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `hiring_transfer`\r\n--\r\nALTER TABLE `hiring_transfer`\r\n  ADD PRIMARY KEY (`ID_ht`),\r\n  ADD KEY `fk_hiring_transfer_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `Language`\r\n--\r\nALTER TABLE `Language`\r\n  ADD PRIMARY KEY (`ID_language`),\r\n  ADD KEY `fk_language_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `military_registration`\r\n--\r\nALTER TABLE `military_registration`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `Profession`\r\n--\r\nALTER TABLE `Profession`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `professional_development`\r\n--\r\nALTER TABLE `professional_development`\r\n  ADD PRIMARY KEY (`ID_cval`),\r\n  ADD KEY `fk_professional_development_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `professional_retraining`\r\n--\r\nALTER TABLE `professional_retraining`\r\n  ADD PRIMARY KEY (`ID_retr`),\r\n  ADD KEY `fk_professional_retraining_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `social_benefits`\r\n--\r\nALTER TABLE `social_benefits`\r\n  ADD PRIMARY KEY (`ID_ben`),\r\n  ADD KEY `fk_social_benefits_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `vacation`\r\n--\r\nALTER TABLE `vacation`\r\n  ADD PRIMARY KEY (`ID_vac`),\r\n  ADD KEY `fk_vacation_empl` (`ID_empl`);\r\n\r\n--\r\n-- Индексы таблицы `work_experience`\r\n--\r\nALTER TABLE `work_experience`\r\n  ADD PRIMARY KEY (`ID_empl`);\r\n\r\n--\r\n-- AUTO_INCREMENT для сохранённых таблиц\r\n--\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `Additional_information`\r\n--\r\nALTER TABLE `Additional_information`\r\n  MODIFY `ID_mixing` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `awards`\r\n--\r\nALTER TABLE `awards`\r\n  MODIFY `ID_reward` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `certification`\r\n--\r\nALTER TABLE `certification`\r\n  MODIFY `ID_att` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `Education`\r\n--\r\nALTER TABLE `Education`\r\n  MODIFY `ID_education` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `family_composition`\r\n--\r\nALTER TABLE `family_composition`\r\n  MODIFY `ID_person` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `General_information`\r\n--\r\nALTER TABLE `General_information`\r\n  MODIFY `ID_empl` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `hiring_transfer`\r\n--\r\nALTER TABLE `hiring_transfer`\r\n  MODIFY `ID_ht` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `Language`\r\n--\r\nALTER TABLE `Language`\r\n  MODIFY `ID_language` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `professional_development`\r\n--\r\nALTER TABLE `professional_development`\r\n  MODIFY `ID_cval` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `professional_retraining`\r\n--\r\nALTER TABLE `professional_retraining`\r\n  MODIFY `ID_retr` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `social_benefits`\r\n--\r\nALTER TABLE `social_benefits`\r\n  MODIFY `ID_ben` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;\r\n\r\n--\r\n-- AUTO_INCREMENT для таблицы `vacation`\r\n--\r\nALTER TABLE `vacation`\r\n  MODIFY `ID_vac` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;\r\n\r\n--\r\n-- Ограничения внешнего ключа сохраненных таблиц\r\n--\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `Additional_information`\r\n--\r\nALTER TABLE `Additional_information`\r\n  ADD CONSTRAINT `additional_information_ibfk_1` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `address_of_residence`\r\n--\r\nALTER TABLE `address_of_residence`\r\n  ADD CONSTRAINT `fk_address_residence_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `After_Education`\r\n--\r\nALTER TABLE `After_Education`\r\n  ADD CONSTRAINT `fk_after_education_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `awards`\r\n--\r\nALTER TABLE `awards`\r\n  ADD CONSTRAINT `fk_awards_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `certification`\r\n--\r\nALTER TABLE `certification`\r\n  ADD CONSTRAINT `fk_certification_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `dismissal`\r\n--\r\nALTER TABLE `dismissal`\r\n  ADD CONSTRAINT `fk_dismissal_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `Education`\r\n--\r\nALTER TABLE `Education`\r\n  ADD CONSTRAINT `fk_education_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `family_composition`\r\n--\r\nALTER TABLE `family_composition`\r\n  ADD CONSTRAINT `fk_family_composition_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `hiring_transfer`\r\n--\r\nALTER TABLE `hiring_transfer`\r\n  ADD CONSTRAINT `fk_hiring_transfer_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `Language`\r\n--\r\nALTER TABLE `Language`\r\n  ADD CONSTRAINT `fk_language_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `military_registration`\r\n--\r\nALTER TABLE `military_registration`\r\n  ADD CONSTRAINT `fk_military_registration_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `Profession`\r\n--\r\nALTER TABLE `Profession`\r\n  ADD CONSTRAINT `fk_profession_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `professional_development`\r\n--\r\nALTER TABLE `professional_development`\r\n  ADD CONSTRAINT `fk_professional_development_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `professional_retraining`\r\n--\r\nALTER TABLE `professional_retraining`\r\n  ADD CONSTRAINT `fk_professional_retraining_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `social_benefits`\r\n--\r\nALTER TABLE `social_benefits`\r\n  ADD CONSTRAINT `fk_social_benefits_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `vacation`\r\n--\r\nALTER TABLE `vacation`\r\n  ADD CONSTRAINT `fk_vacation_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;\r\n\r\n--\r\n-- Ограничения внешнего ключа таблицы `work_experience`\r\n--\r\nALTER TABLE `work_experience`\r\n  ADD CONSTRAINT `fk_work_experience_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE; ALTER TABLE `Users` CHANGE `id_User` `id_User` INT NOT NULL AUTO_INCREMENT, add PRIMARY KEY (`id_User`);ALTER TABLE `Users` ADD UNIQUE(`login`);ALTER TABLE `vacation` CHANGE `Date_end` `Date_end` DATE NULL;ALTER TABLE `After_Education` CHANGE `Year_end` `Year_end` INT NOT NULL;ALTER TABLE `Education` DROP `Code_OKSO`;ALTER TABLE `professional_retraining` DROP `Ser_doc`;";
            cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = $"INSERT INTO `Users` (`id_User`, `Name`, `LastName`, `Surname`, `login`, `password`, `role`,`lock`) VALUES (NULL, 'admin', 'admin', 'admin', 'admin', '{PwdHash.HashPassword("admin")}', 'AdminHR',0); ";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
            createPerson();
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
    }
}
