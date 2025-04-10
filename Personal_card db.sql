-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Апр 10 2025 г., 15:10
-- Версия сервера: 8.0.30
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `Personal_card`
--

-- --------------------------------------------------------

--
-- Структура таблицы `Additional_information`
--

CREATE TABLE `Additional_information` (
  `ID_mixing` int NOT NULL,
  `Information` varchar(200) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;




-- --------------------------------------------------------

--
-- Структура таблицы `address_of_residence`
--

CREATE TABLE `address_of_residence` (
  `by_registration` varchar(200) NOT NULL,
  `actual` varchar(200) NOT NULL,
  `Index_by_register` char(10) NOT NULL,
  `index_actual` varchar(10) NOT NULL,
  `date_registration` date NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------
--
-- Структура таблицы `Users`
--

CREATE TABLE `Users` (
  `id_User` int NOT NULL,
  `Name` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `Surname` varchar(100) DEFAULT NULL,
  `login` varchar(100) NOT NULL,
  `password` varchar(225) NOT NULL,
  `role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Структура таблицы `After_Education`
--

CREATE TABLE `After_Education` (
  `Name_organisation` varchar(100) NOT NULL,
  `Name_education_docAfter` varchar(50) NOT NULL,
  `Serial_doc_education` varchar(10) NOT NULL,
  `Num_doc_education` varchar(20) NOT NULL,
  `Year_end` date NOT NULL,
  `Date_give_doc` date NOT NULL,
  `Direction_or_speciality` varchar(100) NOT NULL,
  `Type_education` varchar(100) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `awards`
--

CREATE TABLE `awards` (
  `Name_reward` varchar(100) NOT NULL,
  `Name_doc` varchar(100) NOT NULL,
  `Num_doc` varchar(20) NOT NULL,
  `Date_give_doc` date NOT NULL,
  `ID_reward` int NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;

-- --------------------------------------------------------

--
-- Структура таблицы `certification`
--

CREATE TABLE `certification` (
  `ID_att` int NOT NULL,
  `Decision` varchar(300) NOT NULL,
  `Num_doc` varchar(20) NOT NULL,
  `Date_doc` date NOT NULL,
  `Reason` varchar(200) NOT NULL,
  `Date_att` date NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `dismissal`
--

CREATE TABLE `dismissal` (
  `Date_dismiss` date NOT NULL,
  `Num_order` varchar(20) NOT NULL,
  `Date_order` date NOT NULL,
  `ID_empl` int NOT NULL,
  `Reason` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `Education`
--

CREATE TABLE `Education` (
  `ID_education` int NOT NULL,
  `Name_orgnisation` varchar(100) NOT NULL,
  `Name_doc_education` varchar(50) NOT NULL,
  `Serial_doc_education` varchar(10) NOT NULL,
  `Num_doc_education` varchar(20) NOT NULL,
  `Year_end` int NOT NULL,
  `Qualification_doc_education` varchar(100) NOT NULL,
  `direction_or_specialty` varchar(50) NOT NULL,
  `Code_OKSO` varchar(10) NOT NULL,
  `Type_education` varchar(100) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `family_composition`
--

CREATE TABLE `family_composition` (
  `FIO` varchar(200) NOT NULL,
  `Degree_of_kinship` varchar(50) NOT NULL,
  `date_birth` date NOT NULL,
  `ID_person` int NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `General_information`
--

CREATE TABLE `General_information` (
  `ID_empl` int NOT NULL,
  `Last_name` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Surname` varchar(40) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Birthday` date NOT NULL,
  `Place_birth` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `citizenship` char(30) NOT NULL,
  `marital_status` char(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `nam_passport` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `serial_passport` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `date_give_passport` date NOT NULL,
  `who_give` varchar(60) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `number_phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Date_create_card` date NOT NULL,
  `T_num_card` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `INN` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Num_pensia` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `First_char_lastname` varchar(1) NOT NULL,
  `Nature_work` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type_work` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Male_Female` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `hiring_transfer`
--

CREATE TABLE `hiring_transfer` (
  `ID_empl` int NOT NULL,
  `ID_ht` int NOT NULL,
  `Date` date NOT NULL,
  `Struct` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `position_category` varchar(200) NOT NULL,
  `Tariff_rate` decimal(19,4) NOT NULL,
  `Reason` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `Language`
--

CREATE TABLE `Language` (
  `Language_name` varchar(100) NOT NULL,
  `Degree_of_knowledge` varchar(30) NOT NULL,
  `ID_language` int NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `military_registration`
--

CREATE TABLE `military_registration` (
  `Category` varchar(50) NOT NULL,
  `Military_rank` varchar(40) NOT NULL,
  `Structure` varchar(50) NOT NULL,
  `Code_mas` varchar(50) NOT NULL,
  `Category_life` varchar(20) NOT NULL,
  `Military_commissariat_name` varchar(150) NOT NULL,
  `de_registration` varchar(50) NOT NULL,
  `Name_type` varchar(50) NOT NULL,
  `Additional_information` varchar(100) DEFAULT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `Profession`
--

CREATE TABLE `Profession` (
  `basic` varchar(50) NOT NULL,
  `another` varchar(50) DEFAULT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `professional_development`
--

CREATE TABLE `professional_development` (
  `ID_cval` int NOT NULL,
  `Date_start` date NOT NULL,
  `Date_end` date NOT NULL,
  `Type_cvalification` varchar(50) NOT NULL,
  `Name_education_company` varchar(100) NOT NULL,
  `Name_doc` varchar(100) NOT NULL,
  `Ser_doc` varchar(20) NOT NULL,
  `Num_doc` varchar(20) NOT NULL,
  `Date_give_doc` date NOT NULL,
  `Reason` varchar(200) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `professional_retraining`
--

CREATE TABLE `professional_retraining` (
  `ID_retr` int NOT NULL,
  `Date_start` date NOT NULL,
  `Date_end` date NOT NULL,
  `Name_doc` varchar(100) NOT NULL,
  `Ser_doc` varchar(20) NOT NULL,
  `Num_doc` varchar(20) NOT NULL,
  `Date_give_doc` date NOT NULL,
  `Reason` varchar(200) NOT NULL,
  `Speciality` varchar(100) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `social_benefits`
--

CREATE TABLE `social_benefits` (
  `ID_ben` int NOT NULL,
  `Name_benefit` varchar(50) NOT NULL,
  `Num_doc` varchar(20) NOT NULL,
  `Date_give_doc` date NOT NULL,
  `Reason` varchar(200) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `vacation`
--

CREATE TABLE `vacation` (
  `ID_vac` int NOT NULL,
  `Type_vacation` varchar(50) NOT NULL,
  `Period_work_start` date NOT NULL,
  `Period_work_end` date DEFAULT NULL,
  `Quantity_day` int NOT NULL,
  `Date_start` date NOT NULL,
  `Date_end` date NOT NULL,
  `Reason` varchar(200) NOT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


-- --------------------------------------------------------

--
-- Структура таблицы `work_experience`
--

CREATE TABLE `work_experience` (
  `common_day` int DEFAULT NULL,
  `common_year` int DEFAULT NULL,
  `common_month` int DEFAULT NULL,
  `continuous_day` int DEFAULT NULL,
  `continuous_month` int DEFAULT NULL,
  `continuous_year` int DEFAULT NULL,
  `giver_day` int DEFAULT NULL,
  `giver_month` int DEFAULT NULL,
  `giver_year` int DEFAULT NULL,
  `ID_empl` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4   ;


--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `Additional_information`
--
ALTER TABLE `Additional_information`
  ADD PRIMARY KEY (`ID_mixing`),
  ADD KEY `ID_empl` (`ID_empl`);

--
-- Индексы таблицы `address_of_residence`
--
ALTER TABLE `address_of_residence`
  ADD PRIMARY KEY (`ID_empl`);

--
-- Индексы таблицы `After_Education`
--
ALTER TABLE `After_Education`
  ADD PRIMARY KEY (`ID_empl`);

--
-- Индексы таблицы `awards`
--
ALTER TABLE `awards`
  ADD PRIMARY KEY (`ID_reward`),
  ADD KEY `fk_awards_empl` (`ID_empl`);

--
-- Индексы таблицы `certification`
--
ALTER TABLE `certification`
  ADD PRIMARY KEY (`ID_att`),
  ADD KEY `fk_certification_empl` (`ID_empl`);

--
-- Индексы таблицы `dismissal`
--
ALTER TABLE `dismissal`
  ADD PRIMARY KEY (`ID_empl`);

--
-- Индексы таблицы `Education`
--
ALTER TABLE `Education`
  ADD PRIMARY KEY (`ID_education`),
  ADD KEY `fk_education_empl` (`ID_empl`);

--
-- Индексы таблицы `family_composition`
--
ALTER TABLE `family_composition`
  ADD PRIMARY KEY (`ID_person`),
  ADD KEY `fk_family_composition_empl` (`ID_empl`);

--
-- Индексы таблицы `General_information`
--
ALTER TABLE `General_information`
  ADD PRIMARY KEY (`ID_empl`);

--
-- Индексы таблицы `hiring_transfer`
--
ALTER TABLE `hiring_transfer`
  ADD PRIMARY KEY (`ID_ht`),
  ADD KEY `fk_hiring_transfer_empl` (`ID_empl`);

--
-- Индексы таблицы `Language`
--
ALTER TABLE `Language`
  ADD PRIMARY KEY (`ID_language`),
  ADD KEY `fk_language_empl` (`ID_empl`);

--
-- Индексы таблицы `military_registration`
--
ALTER TABLE `military_registration`
  ADD PRIMARY KEY (`ID_empl`);

--
-- Индексы таблицы `Profession`
--
ALTER TABLE `Profession`
  ADD PRIMARY KEY (`ID_empl`);

--
-- Индексы таблицы `professional_development`
--
ALTER TABLE `professional_development`
  ADD PRIMARY KEY (`ID_cval`),
  ADD KEY `fk_professional_development_empl` (`ID_empl`);

--
-- Индексы таблицы `professional_retraining`
--
ALTER TABLE `professional_retraining`
  ADD PRIMARY KEY (`ID_retr`),
  ADD KEY `fk_professional_retraining_empl` (`ID_empl`);

--
-- Индексы таблицы `social_benefits`
--
ALTER TABLE `social_benefits`
  ADD PRIMARY KEY (`ID_ben`),
  ADD KEY `fk_social_benefits_empl` (`ID_empl`);

--
-- Индексы таблицы `vacation`
--
ALTER TABLE `vacation`
  ADD PRIMARY KEY (`ID_vac`),
  ADD KEY `fk_vacation_empl` (`ID_empl`);

--
-- Индексы таблицы `work_experience`
--
ALTER TABLE `work_experience`
  ADD PRIMARY KEY (`ID_empl`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `Additional_information`
--
ALTER TABLE `Additional_information`
  MODIFY `ID_mixing` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `awards`
--
ALTER TABLE `awards`
  MODIFY `ID_reward` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `certification`
--
ALTER TABLE `certification`
  MODIFY `ID_att` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `Education`
--
ALTER TABLE `Education`
  MODIFY `ID_education` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `family_composition`
--
ALTER TABLE `family_composition`
  MODIFY `ID_person` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT для таблицы `General_information`
--
ALTER TABLE `General_information`
  MODIFY `ID_empl` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT для таблицы `hiring_transfer`
--
ALTER TABLE `hiring_transfer`
  MODIFY `ID_ht` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT для таблицы `Language`
--
ALTER TABLE `Language`
  MODIFY `ID_language` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `professional_development`
--
ALTER TABLE `professional_development`
  MODIFY `ID_cval` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `professional_retraining`
--
ALTER TABLE `professional_retraining`
  MODIFY `ID_retr` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT для таблицы `social_benefits`
--
ALTER TABLE `social_benefits`
  MODIFY `ID_ben` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `vacation`
--
ALTER TABLE `vacation`
  MODIFY `ID_vac` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `Additional_information`
--
ALTER TABLE `Additional_information`
  ADD CONSTRAINT `additional_information_ibfk_1` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `address_of_residence`
--
ALTER TABLE `address_of_residence`
  ADD CONSTRAINT `fk_address_residence_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `After_Education`
--
ALTER TABLE `After_Education`
  ADD CONSTRAINT `fk_after_education_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `awards`
--
ALTER TABLE `awards`
  ADD CONSTRAINT `fk_awards_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `certification`
--
ALTER TABLE `certification`
  ADD CONSTRAINT `fk_certification_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `dismissal`
--
ALTER TABLE `dismissal`
  ADD CONSTRAINT `fk_dismissal_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Education`
--
ALTER TABLE `Education`
  ADD CONSTRAINT `fk_education_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `family_composition`
--
ALTER TABLE `family_composition`
  ADD CONSTRAINT `fk_family_composition_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `hiring_transfer`
--
ALTER TABLE `hiring_transfer`
  ADD CONSTRAINT `fk_hiring_transfer_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Language`
--
ALTER TABLE `Language`
  ADD CONSTRAINT `fk_language_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `military_registration`
--
ALTER TABLE `military_registration`
  ADD CONSTRAINT `fk_military_registration_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Profession`
--
ALTER TABLE `Profession`
  ADD CONSTRAINT `fk_profession_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `professional_development`
--
ALTER TABLE `professional_development`
  ADD CONSTRAINT `fk_professional_development_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `professional_retraining`
--
ALTER TABLE `professional_retraining`
  ADD CONSTRAINT `fk_professional_retraining_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `social_benefits`
--
ALTER TABLE `social_benefits`
  ADD CONSTRAINT `fk_social_benefits_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `vacation`
--
ALTER TABLE `vacation`
  ADD CONSTRAINT `fk_vacation_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;

--
-- Ограничения внешнего ключа таблицы `work_experience`
--
ALTER TABLE `work_experience`
  ADD CONSTRAINT `fk_work_experience_empl` FOREIGN KEY (`ID_empl`) REFERENCES `General_information` (`ID_empl`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
