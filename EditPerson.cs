using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCard
{
    public class GeneralInformationRepository
    {
        private readonly string _connectionString;

        public GeneralInformationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(GeneralInformation info)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO General_information 
                (ID_empl, Last_name, Name, Surname, Birthday, Place_birth, Citizenship, Marital_status, 
                Nam_passport, Serial_passport, Date_give_passport, Who_give, Number_phone, Date_create_card, 
                T_num_card, INN, Num_pensia, First_char_lastname, Nature_work, Type_work, Male_Female) 
                VALUES 
                (@ID_empl, @Last_name, @Name, @Surname, @Birthday, @Place_birth, @Citizenship, @Marital_status, 
                @Nam_passport, @Serial_passport, @Date_give_passport, @Who_give, @Number_phone, @Date_create_card, 
                @T_num_card, @INN, @Num_pensia, @First_char_lastname, @Nature_work, @Type_work, @Male_Female)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, info);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(GeneralInformation info)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE General_information SET 
                Last_name = @Last_name, Name = @Name, Surname = @Surname, Birthday = @Birthday, 
                Place_birth = @Place_birth, Citizenship = @Citizenship, Marital_status = @Marital_status, 
                Nam_passport = @Nam_passport, Serial_passport = @Serial_passport, Date_give_passport = @Date_give_passport, 
                Who_give = @Who_give, Number_phone = @Number_phone, Date_create_card = @Date_create_card, 
                T_num_card = @T_num_card, INN = @INN, Num_pensia = @Num_pensia, First_char_lastname = @First_char_lastname, 
                Nature_work = @Nature_work, Type_work = @Type_work, Male_Female = @Male_Female 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, info);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM General_information WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, GeneralInformation info)
        {
            cmd.Parameters.AddWithValue("@ID_empl", info.ID_empl);
            cmd.Parameters.AddWithValue("@Last_name", info.Last_name);
            cmd.Parameters.AddWithValue("@Name", info.Name);
            cmd.Parameters.AddWithValue("@Surname", info.Surname);
            cmd.Parameters.AddWithValue("@Birthday", info.Birthday);
            cmd.Parameters.AddWithValue("@Place_birth", info.Place_birth);
            cmd.Parameters.AddWithValue("@Citizenship", info.Citizenship);
            cmd.Parameters.AddWithValue("@Marital_status", info.Marital_status);
            cmd.Parameters.AddWithValue("@Nam_passport", info.Nam_passport);
            cmd.Parameters.AddWithValue("@Serial_passport", info.Serial_passport);
            cmd.Parameters.AddWithValue("@Date_give_passport", info.Date_give_passport);
            cmd.Parameters.AddWithValue("@Who_give", info.Who_give);
            cmd.Parameters.AddWithValue("@Number_phone", info.Number_phone);
            cmd.Parameters.AddWithValue("@Date_create_card", info.Date_create_card);
            cmd.Parameters.AddWithValue("@T_num_card", info.T_num_card);
            cmd.Parameters.AddWithValue("@INN", info.INN);
            cmd.Parameters.AddWithValue("@Num_pensia", info.Num_pensia);
            cmd.Parameters.AddWithValue("@First_char_lastname", info.First_char_lastname);
            cmd.Parameters.AddWithValue("@Nature_work", info.Nature_work);
            cmd.Parameters.AddWithValue("@Type_work", info.Type_work);
            cmd.Parameters.AddWithValue("@Male_Female", info.Male_Female);
        }
    }

    public class AddressOfResidenceRepository
    {
        private readonly string _connectionString;

        public AddressOfResidenceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(AddressOfResidenceInf address)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO address_of_residence 
                (ID_empl, by_registration, actual, Index_by_register, index_actual, date_registration) 
                VALUES 
                (@ID_empl, @By_registration, @Actual, @Index_by_register, @Index_actual, @Date_registration)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, address);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(AddressOfResidenceInf address)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE address_of_residence SET 
                by_registration = @By_registration, actual = @Actual, 
                Index_by_register = @Index_by_register, index_actual = @Index_actual, 
                date_registration = @Date_registration 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, address);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM address_of_residence WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, AddressOfResidenceInf address)
        {
            cmd.Parameters.AddWithValue("@ID_empl", address.ID_empl);
            cmd.Parameters.AddWithValue("@By_registration", address.By_registration);
            cmd.Parameters.AddWithValue("@Actual", address.Actual);
            cmd.Parameters.AddWithValue("@Index_by_register", address.Index_by_register);
            cmd.Parameters.AddWithValue("@Index_actual", address.Index_actual);
            cmd.Parameters.AddWithValue("@Date_registration", address.Date_registration);
        }
    }

    public class AfterEducationRepository
    {
        private readonly string _connectionString;

        public AfterEducationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(AfterEducationInf afterEducation)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO After_Education 
                (ID_empl, Name_organisation, Name_education_docAfter, Serial_doc_education, 
                Num_doc_education, Year_end, Date_give_doc, Direction_or_speciality, Type_education) 
                VALUES 
                (@ID_empl, @Name_organisation, @Name_education_docAfter, @Serial_doc_education, 
                @Num_doc_education, @Year_end, @Date_give_doc, @Direction_or_speciality, @Type_education)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, afterEducation);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(AfterEducationInf afterEducation)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE After_Education SET 
                Name_organisation = @Name_organisation, 
                Name_education_docAfter = @Name_education_docAfter, 
                Serial_doc_education = @Serial_doc_education, 
                Num_doc_education = @Num_doc_education, 
                Year_end = @Year_end, 
                Date_give_doc = @Date_give_doc, 
                Direction_or_speciality = @Direction_or_speciality, 
                Type_education = @Type_education 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, afterEducation);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM After_Education WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, AfterEducationInf afterEducation)
        {
            cmd.Parameters.AddWithValue("@ID_empl", afterEducation.ID_empl);
            cmd.Parameters.AddWithValue("@Name_organisation", afterEducation.Name_organisation);
            cmd.Parameters.AddWithValue("@Name_education_docAfter", afterEducation.Name_education_docAfter);
            cmd.Parameters.AddWithValue("@Serial_doc_education", afterEducation.Serial_doc_education);
            cmd.Parameters.AddWithValue("@Num_doc_education", afterEducation.Num_doc_education);
            cmd.Parameters.AddWithValue("@Year_end", afterEducation.Year_end);
            cmd.Parameters.AddWithValue("@Date_give_doc", afterEducation.Date_give_doc);
            cmd.Parameters.AddWithValue("@Direction_or_speciality", afterEducation.Direction_or_speciality);
            cmd.Parameters.AddWithValue("@Type_education", afterEducation.Type_education);
        }
    }

    public class AwardRepository
    {
        private readonly string _connectionString;

        public AwardRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(AwardInf award)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO awards 
                (ID_empl, Name_reward, Name_doc, Num_doc, Date_give_doc) 
                VALUES 
                (@ID_empl, @Name_reward, @Name_doc, @Num_doc, @Date_give_doc)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, award);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(AwardInf award)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE awards SET 
                Name_reward = @Name_reward, Name_doc = @Name_doc, 
                Num_doc = @Num_doc, Date_give_doc = @Date_give_doc 
                WHERE ID_reward = @ID_reward";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, award);
                cmd.Parameters.AddWithValue("@ID_reward", award.ID_reward);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int awardId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM awards WHERE ID_reward = @ID_reward";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_reward", awardId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, AwardInf award)
        {
            cmd.Parameters.AddWithValue("@ID_empl", award.ID_empl);
            cmd.Parameters.AddWithValue("@Name_reward", award.Name_reward);
            cmd.Parameters.AddWithValue("@Name_doc", award.Name_doc);
            cmd.Parameters.AddWithValue("@Num_doc", award.Num_doc);
            cmd.Parameters.AddWithValue("@Date_give_doc", award.Date_give_doc);
        }
    }

    public class CertificationRepository
    {
        private readonly string _connectionString;

        public CertificationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(CertificationInf certification)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO certification 
                (ID_empl, Decision, Num_doc, Date_doc, Reason, Date_att) 
                VALUES 
                (@ID_empl, @Decision, @Num_doc, @Date_doc, @Reason, @Date_att)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, certification);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(CertificationInf certification)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE certification SET 
                Decision = @Decision, Num_doc = @Num_doc, 
                Date_doc = @Date_doc, Reason = @Reason, Date_att = @Date_att 
                WHERE ID_att = @ID_att";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, certification);
                cmd.Parameters.AddWithValue("@ID_att", certification.ID_att);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int certificationId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM certification WHERE ID_att = @ID_att";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_att", certificationId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, CertificationInf certification)
        {
            cmd.Parameters.AddWithValue("@ID_empl", certification.ID_empl);
            cmd.Parameters.AddWithValue("@Decision", certification.Decision);
            cmd.Parameters.AddWithValue("@Num_doc", certification.Num_doc);
            cmd.Parameters.AddWithValue("@Date_doc", certification.Date_doc);
            cmd.Parameters.AddWithValue("@Reason", certification.Reason);
            cmd.Parameters.AddWithValue("@Date_att", certification.Date_att);
        }
    }

    public class DismissalRepository
    {
        private readonly string _connectionString;

        public DismissalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(DismissalInf dismissal)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO dismissal 
                (ID_empl, Date_dismiss, Num_order, Date_order, Reason) 
                VALUES 
                (@ID_empl, @Date_dismiss, @Num_order, @Date_order, @Reason)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, dismissal);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(DismissalInf dismissal)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE dismissal SET 
                Date_dismiss = @Date_dismiss, Num_order = @Num_order, 
                Date_order = @Date_order, Reason = @Reason 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, dismissal);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM dismissal WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, DismissalInf dismissal)
        {
            cmd.Parameters.AddWithValue("@ID_empl", dismissal.ID_empl);
            cmd.Parameters.AddWithValue("@Date_dismiss", dismissal.Date_dismiss);
            cmd.Parameters.AddWithValue("@Num_order", dismissal.Num_order);
            cmd.Parameters.AddWithValue("@Date_order", dismissal.Date_order);
            cmd.Parameters.AddWithValue("@Reason", dismissal.Reason);
        }
    }

    public class EducationRepository
    {
        private readonly string _connectionString;

        public EducationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(EducationInf education)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Education 
                (ID_empl, Name_orgnisation, Name_doc_education, Serial_doc_education, Num_doc_education, 
                Year_end, Qualification_doc_education, direction_or_specialty, Code_OKSO, Type_education) 
                VALUES 
                (@ID_empl, @Name_orgnisation, @Name_doc_education, @Serial_doc_education, @Num_doc_education, 
                @Year_end, @Qualification_doc_education, @Direction_or_specialty, @Code_OKSO, @Type_education)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, education);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(EducationInf education)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Education SET 
                Name_orgnisation = @Name_orgnisation, Name_doc_education = @Name_doc_education, 
                Serial_doc_education = @Serial_doc_education, Num_doc_education = @Num_doc_education, 
                Year_end = @Year_end, Qualification_doc_education = @Qualification_doc_education, 
                direction_or_specialty = @Direction_or_specialty, Code_OKSO = @Code_OKSO, Type_education = @Type_education 
                WHERE ID_education = @ID_education";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, education);
                cmd.Parameters.AddWithValue("@ID_education", education.ID_education);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int educationId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Education WHERE ID_education = @ID_education";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_education", educationId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, EducationInf education)
        {
            cmd.Parameters.AddWithValue("@ID_empl", education.ID_empl);
            cmd.Parameters.AddWithValue("@Name_orgnisation", education.Name_orgnisation);
            cmd.Parameters.AddWithValue("@Name_doc_education", education.Name_doc_education);
            cmd.Parameters.AddWithValue("@Serial_doc_education", education.Serial_doc_education);
            cmd.Parameters.AddWithValue("@Num_doc_education", education.Num_doc_education);
            cmd.Parameters.AddWithValue("@Year_end", education.Year_end);
            cmd.Parameters.AddWithValue("@Qualification_doc_education", education.Qualification_doc_education);
            cmd.Parameters.AddWithValue("@Direction_or_specialty", education.Direction_or_specialty);
            cmd.Parameters.AddWithValue("@Code_OKSO", education.Code_OKSO);
            cmd.Parameters.AddWithValue("@Type_education", education.Type_education);
        }
    }

    public class FamilyCompositionRepository
    {
        private readonly string _connectionString;

        public FamilyCompositionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(FamilyCompositionInf familyMember)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO family_composition 
                (ID_empl, FIO, Degree_of_kinship, date_birth) 
                VALUES 
                (@ID_empl, @FIO, @Degree_of_kinship, @Date_birth)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, familyMember);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(FamilyCompositionInf familyMember)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE family_composition SET 
                FIO = @FIO, Degree_of_kinship = @Degree_of_kinship, date_birth = @Date_birth 
                WHERE ID_person = @ID_person";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, familyMember);
                cmd.Parameters.AddWithValue("@ID_person", familyMember.ID_person);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int familyMemberId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM family_composition WHERE ID_person = @ID_person";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_person", familyMemberId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, FamilyCompositionInf familyMember)
        {
            cmd.Parameters.AddWithValue("@ID_empl", familyMember.ID_empl);
            cmd.Parameters.AddWithValue("@FIO", familyMember.FIO);
            cmd.Parameters.AddWithValue("@Degree_of_kinship", familyMember.Degree_of_kinship);
            cmd.Parameters.AddWithValue("@Date_birth", familyMember.Date_birth);
        }
    }

    public class HiringTransferRepository
    {
        private readonly string _connectionString;

        public HiringTransferRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(HiringTransferInf transfer)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO hiring_transfer 
                (ID_empl, Date, Struct, position_category, Tariff_rate, Reason) 
                VALUES 
                (@ID_empl, @Date, @Struct, @Position_category, @Tariff_rate, @Reason)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, transfer);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(HiringTransferInf transfer)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE hiring_transfer SET 
                Date = @Date, Struct = @Struct, position_category = @Position_category, 
                Tariff_rate = @Tariff_rate, Reason = @Reason 
                WHERE ID_ht = @ID_ht";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, transfer);
                cmd.Parameters.AddWithValue("@ID_ht", transfer.ID_ht);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int transferId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM hiring_transfer WHERE ID_ht = @ID_ht";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_ht", transferId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, HiringTransferInf transfer)
        {
            cmd.Parameters.AddWithValue("@ID_empl", transfer.ID_empl);
            cmd.Parameters.AddWithValue("@Date", transfer.Date);
            cmd.Parameters.AddWithValue("@Struct", transfer.Struct);
            cmd.Parameters.AddWithValue("@Position_category", transfer.Position_category);
            cmd.Parameters.AddWithValue("@Tariff_rate", transfer.Tariff_rate);
            cmd.Parameters.AddWithValue("@Reason", transfer.Reason);
        }
    }

    public class LanguageRepository
    {
        private readonly string _connectionString;

        public LanguageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(LanguageInf language)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Language 
                (ID_empl, Language_name, Degree_of_knowledge) 
                VALUES 
                (@ID_empl, @Language_name, @Degree_of_knowledge)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, language);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(LanguageInf language)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Language SET 
                Language_name = @Language_name, Degree_of_knowledge = @Degree_of_knowledge 
                WHERE ID_language = @ID_language";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, language);
                cmd.Parameters.AddWithValue("@ID_language", language.ID_language);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int languageId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Language WHERE ID_language = @ID_language";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_language", languageId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, LanguageInf language)
        {
            cmd.Parameters.AddWithValue("@ID_empl", language.ID_empl);
            cmd.Parameters.AddWithValue("@Language_name", language.Language_name);
            cmd.Parameters.AddWithValue("@Degree_of_knowledge", language.Degree_of_knowledge);
        }
    }

    public class MilitaryRegistrationRepository
    {
        private readonly string _connectionString;

        public MilitaryRegistrationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(MilitaryRegistrationInf registration)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO military_registration 
                (ID_empl, Category, Military_rank,  Structure, Code_mas, Category_life, 
                Military_commissariat_name, de_registration, Name_type, Additional_information) 
                VALUES 
                (@ID_empl, @Category, @Military_rank,  @Structure, @Code_mas, @Category_life, 
                @Military_commissariat_name, @De_registration, @Name_type, @Additional_information)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, registration);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(MilitaryRegistrationInf registration)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE military_registration SET 
                Category = @Category, Military_rank = @Military_rank,  Structure = @Structure, 
                Code_mas = @Code_mas, Category_life = @Category_life, 
                Military_commissariat_name = @Military_commissariat_name, de_registration = @De_registration, 
                Name_type = @Name_type, Additional_information = @Additional_information 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, registration);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM military_registration WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, MilitaryRegistrationInf registration)
        {
            cmd.Parameters.AddWithValue("@ID_empl", registration.ID_empl);
            cmd.Parameters.AddWithValue("@Category", registration.Category);
            cmd.Parameters.AddWithValue("@Military_rank", registration.Military_rank);
            
            cmd.Parameters.AddWithValue("@Structure", registration.Structure);
            cmd.Parameters.AddWithValue("@Code_mas", registration.Code_mas);
            cmd.Parameters.AddWithValue("@Category_life", registration.Category_life);
            cmd.Parameters.AddWithValue("@Military_commissariat_name", registration.Military_commissariat_name);
            cmd.Parameters.AddWithValue("@De_registration", registration.De_registration);
            cmd.Parameters.AddWithValue("@Name_type", registration.Name_type);
            cmd.Parameters.AddWithValue("@Additional_information", registration.Additional_information ?? (object)DBNull.Value);
        }
    }

    public class ProfessionRepository
    {
        private readonly string _connectionString;

        public ProfessionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(ProfessionInf profession)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Profession 
                (ID_empl, basic, another) 
                VALUES 
                (@ID_empl, @Basic, @Another)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, profession);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(ProfessionInf profession)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Profession SET 
                basic = @Basic, another = @Another 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, profession);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Profession WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, ProfessionInf profession)
        {
            cmd.Parameters.AddWithValue("@ID_empl", profession.ID_empl);
            cmd.Parameters.AddWithValue("@Basic", profession.Basic);
            cmd.Parameters.AddWithValue("@Another", profession.Another ?? (object)DBNull.Value);
        }
    }

    public class ProfessionalDevelopmentRepository
    {
        private readonly string _connectionString;

        public ProfessionalDevelopmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(ProfessionalDevelopmentInf development)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO professional_development 
                (ID_empl, Date_start, Date_end, Type_cvalification, Name_education_company, 
                Name_doc, Ser_doc, Num_doc, Date_give_doc, Reason) 
                VALUES 
                (@ID_empl, @Date_start, @Date_end, @Type_cvalification, @Name_education_company, 
                @Name_doc, @Ser_doc, @Num_doc, @Date_give_doc, @Reason)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, development);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(ProfessionalDevelopmentInf development)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE professional_development SET 
                Date_start = @Date_start, Date_end = @Date_end, Type_cvalification = @Type_cvalification, 
                Name_education_company = @Name_education_company, Name_doc = @Name_doc, 
                Ser_doc = @Ser_doc, Num_doc = @Num_doc, Date_give_doc = @Date_give_doc, Reason = @Reason 
                WHERE ID_cval = @ID_cval";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, development);
                cmd.Parameters.AddWithValue("@ID_cval", development.ID_cval);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int developmentId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM professional_development WHERE ID_cval = @ID_cval";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_cval", developmentId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, ProfessionalDevelopmentInf development)
        {
            cmd.Parameters.AddWithValue("@ID_empl", development.ID_empl);
            cmd.Parameters.AddWithValue("@Date_start", development.Date_start);
            cmd.Parameters.AddWithValue("@Date_end", development.Date_end);
            cmd.Parameters.AddWithValue("@Type_cvalification", development.Type_cvalification);
            cmd.Parameters.AddWithValue("@Name_education_company", development.Name_education_company);
            cmd.Parameters.AddWithValue("@Name_doc", development.Name_doc);
            cmd.Parameters.AddWithValue("@Ser_doc", development.Ser_doc);
            cmd.Parameters.AddWithValue("@Num_doc", development.Num_doc);
            cmd.Parameters.AddWithValue("@Date_give_doc", development.Date_give_doc);
            cmd.Parameters.AddWithValue("@Reason", development.Reason);
        }
    }

    public class ProfessionalRetrainingRepository
    {
        private readonly string _connectionString;

        public ProfessionalRetrainingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(ProfessionalRetrainingInf retraining)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO professional_retraining 
                (ID_empl, Date_start, Date_end, Name_doc, Ser_doc, Num_doc, Date_give_doc, Reason, Speciality) 
                VALUES 
                (@ID_empl, @Date_start, @Date_end, @Name_doc, @Ser_doc, @Num_doc, @Date_give_doc, @Reason, @Speciality)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, retraining);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(ProfessionalRetrainingInf retraining)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE professional_retraining SET 
                Date_start = @Date_start, Date_end = @Date_end, Name_doc = @Name_doc, 
                Ser_doc = @Ser_doc, Num_doc = @Num_doc, Date_give_doc = @Date_give_doc, 
                Reason = @Reason, Speciality = @Speciality 
                WHERE ID_retr = @ID_retr";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, retraining);
                cmd.Parameters.AddWithValue("@ID_retr", retraining.ID_retr);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int retrainingId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM professional_retraining WHERE ID_retr = @ID_retr";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_retr", retrainingId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, ProfessionalRetrainingInf retraining)
        {
            cmd.Parameters.AddWithValue("@ID_empl", retraining.ID_empl);
            cmd.Parameters.AddWithValue("@Date_start", retraining.Date_start);
            cmd.Parameters.AddWithValue("@Date_end", retraining.Date_end);
            cmd.Parameters.AddWithValue("@Name_doc", retraining.Name_doc);
            cmd.Parameters.AddWithValue("@Ser_doc", retraining.Ser_doc);
            cmd.Parameters.AddWithValue("@Num_doc", retraining.Num_doc);
            cmd.Parameters.AddWithValue("@Date_give_doc", retraining.Date_give_doc);
            cmd.Parameters.AddWithValue("@Reason", retraining.Reason);
            cmd.Parameters.AddWithValue("@Speciality", retraining.Speciality);
        }
    }

    public class SocialBenefitRepository
    {
        private readonly string _connectionString;

        public SocialBenefitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(SocialBenefitInf benefit)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO social_benefits 
                (ID_empl, Name_benefit, Num_doc, Date_give_doc, Reason) 
                VALUES 
                (@ID_empl, @Name_benefit, @Num_doc, @Date_give_doc, @Reason)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, benefit);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(SocialBenefitInf benefit)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE social_benefits SET 
                Name_benefit = @Name_benefit, Num_doc = @Num_doc, 
                Date_give_doc = @Date_give_doc, Reason = @Reason 
                WHERE ID_ben = @ID_ben";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, benefit);
                cmd.Parameters.AddWithValue("@ID_ben", benefit.ID_ben);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int benefitId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM social_benefits WHERE ID_ben = @ID_ben";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_ben", benefitId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, SocialBenefitInf benefit)
        {
            cmd.Parameters.AddWithValue("@ID_empl", benefit.ID_empl);
            cmd.Parameters.AddWithValue("@Name_benefit", benefit.Name_benefit);
            cmd.Parameters.AddWithValue("@Num_doc", benefit.Num_doc);
            cmd.Parameters.AddWithValue("@Date_give_doc", benefit.Date_give_doc);
            cmd.Parameters.AddWithValue("@Reason", benefit.Reason ?? (object)DBNull.Value);
        }
    }

    public class VacationRepository
    {
        private readonly string _connectionString;

        public VacationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(VacationInf vacation)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO vacation 
                (ID_empl, Type_vacation, Period_work_start, Period_work_end, Quantity_day, Date_start, Date_end, Reason) 
                VALUES 
                (@ID_empl, @Type_vacation, @Period_work_start, @Period_work_end, @Quantity_day, @Date_start, @Date_end, @Reason)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, vacation);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(VacationInf vacation)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE vacation SET 
                Type_vacation = @Type_vacation, Period_work_start = @Period_work_start, 
                Period_work_end = @Period_work_end, Quantity_day = @Quantity_day, 
                Date_start = @Date_start, Date_end = @Date_end, Reason = @Reason 
                WHERE ID_vac = @ID_vac";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, vacation);
                cmd.Parameters.AddWithValue("@ID_vac", vacation.ID_vac);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int vacationId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM vacation WHERE ID_vac = @ID_vac";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_vac", vacationId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, VacationInf vacation)
        {
            cmd.Parameters.AddWithValue("@ID_empl", vacation.ID_empl);
            cmd.Parameters.AddWithValue("@Type_vacation", vacation.Type_vacation);
            cmd.Parameters.AddWithValue("@Period_work_start", vacation.Period_work_start);
            cmd.Parameters.AddWithValue("@Period_work_end", vacation.Period_work_end ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Quantity_day", vacation.Quantity_day);
            cmd.Parameters.AddWithValue("@Date_start", vacation.Date_start);
            cmd.Parameters.AddWithValue("@Date_end", vacation.Date_end ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Reason", vacation.Reason);
        }
    }

    public class WorkExperienceRepository
    {
        private readonly string _connectionString;

        public WorkExperienceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(WorkExperienceInf experience)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO work_experience 
                (ID_empl, common_day, common_year, common_month, continuous_day, 
                continuous_month, continuous_year, giver_day, giver_month, giver_year) 
                VALUES 
                (@ID_empl, @Common_day, @Common_year, @Common_month, @Continuous_day, 
                @Continuous_month, @Continuous_year, @Giver_day, @Giver_month, @Giver_year)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, experience);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(WorkExperienceInf experience)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE work_experience SET 
                common_day = @Common_day, common_year = @Common_year, common_month = @Common_month, 
                continuous_day = @Continuous_day, continuous_month = @Continuous_month, continuous_year = @Continuous_year, 
                giver_day = @Giver_day, giver_month = @Giver_month, giver_year = @Giver_year 
                WHERE ID_empl = @ID_empl";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, experience);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int employeeId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM work_experience WHERE ID_empl = @ID_empl";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_empl", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, WorkExperienceInf experience)
        {
            cmd.Parameters.AddWithValue("@ID_empl", experience.ID_empl);
            cmd.Parameters.AddWithValue("@Common_day", experience.Common_day );
            cmd.Parameters.AddWithValue("@Common_year", experience.Common_year );
            cmd.Parameters.AddWithValue("@Common_month", experience.Common_month );
            cmd.Parameters.AddWithValue("@Continuous_day", experience.Continuous_day);
            cmd.Parameters.AddWithValue("@Continuous_month", experience.Continuous_month );
            cmd.Parameters.AddWithValue("@Continuous_year", experience.Continuous_year );
            cmd.Parameters.AddWithValue("@Giver_day", experience.Giver_day );
            cmd.Parameters.AddWithValue("@Giver_month", experience.Giver_month );
            cmd.Parameters.AddWithValue("@Giver_year", experience.Giver_year );
        }
    }

    public class AdditionalInformationRepository
    {
        private readonly string _connectionString;

        public AdditionalInformationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(AdditionalInformationInf info)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Additional_information 
                (ID_empl, Information) 
                VALUES 
                (@ID_empl, @Information)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, info);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(AdditionalInformationInf info)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Additional_information SET 
                Information = @Information 
                WHERE ID_mixing = @ID_mixing";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, info);
                cmd.Parameters.AddWithValue("@ID_mixing", info.ID_mixing);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int infoId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Additional_information WHERE ID_mixing = @ID_mixing";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID_mixing", infoId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, AdditionalInformationInf info)
        {
            cmd.Parameters.AddWithValue("@ID_empl", info.ID_empl);
            cmd.Parameters.AddWithValue("@Information", info.Information);
        }
    }

    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Insert(UserInf user)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO Users 
                (Name, LastName, Surname, login, password, role, lock) 
                VALUES 
                (@Name, @LastName, @Surname, @Login, @Password, @Role, @Lock)";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, user);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(UserInf user)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE Users SET 
                Name = @Name, LastName = @LastName, Surname = @Surname, 
                login = @Login, password = @Password, role = @Role, lock = @Lock 
                WHERE id_User = @Id_User";

                var cmd = new MySqlCommand(query, conn);
                AddParameters(cmd, user);
                cmd.Parameters.AddWithValue("@Id_User", user.Id_User);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int userId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE id_User = @Id_User";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id_User", userId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private void AddParameters(MySqlCommand cmd, UserInf user)
        {
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Surname", user.Surname ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Login", user.Login);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.Parameters.AddWithValue("@Role", user.Role);
            cmd.Parameters.AddWithValue("@Lock", user.Lock);
        }
    }
}
