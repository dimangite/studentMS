-- phpMyAdmin SQL Dump
-- version 4.2.7
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: May 04, 2016 at 01:00 PM
-- Server version: 5.5.41-log
-- PHP Version: 7.0.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `studentmanagement`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE IF NOT EXISTS `attendance` (
`id` int(11) NOT NULL,
  `session` int(11) NOT NULL DEFAULT '0',
  `subUserId` int(11) NOT NULL DEFAULT '0',
  `stdId` int(11) NOT NULL DEFAULT '0',
  `attendance` text COLLATE utf16_unicode_ci
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=8 ;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`id`, `session`, `subUserId`, `stdId`, `attendance`) VALUES
(1, 0, 1, 3, '1-0-0-0-0-0-0-0-0-0-0-0-0-0-0'),
(2, 0, 1, 4, '1-0-1-1-0-0-0-0-0-0-0-0-0-0-1'),
(3, 0, 4, 12, '1-1-1-1-1-1-1-1-1-1-1-1-1-1-0'),
(4, 0, 4, 13, '1-1-1-1-1-1-1-1-1-1-1-1-1-1-0'),
(5, 0, 1, 14, '0-0-1-0-0-0-0-0-0-0-0-0-0-0-0'),
(6, 0, 5, 16, '0-1-1-0-1-1-0-0-0-0-0-0-0'),
(7, 0, 0, 17, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `score`
--

CREATE TABLE IF NOT EXISTS `score` (
`scoreId` int(11) NOT NULL,
  `stdId` int(11) NOT NULL,
  `subUserId` int(11) NOT NULL,
  `quiz` int(4) NOT NULL DEFAULT '0',
  `homework` int(4) NOT NULL DEFAULT '0',
  `assignment` int(4) NOT NULL DEFAULT '0',
  `midterm` int(4) NOT NULL DEFAULT '0',
  `final` int(4) NOT NULL DEFAULT '0',
  `totalScore` int(4) DEFAULT '0'
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=19 ;

--
-- Dumping data for table `score`
--

INSERT INTO `score` (`scoreId`, `stdId`, `subUserId`, `quiz`, `homework`, `assignment`, `midterm`, `final`, `totalScore`) VALUES
(3, 3, 1, 3, 2, 4, 24, 124, 0),
(4, 4, 1, 321, 13, 13, 31, 3, 0),
(11, 11, 1, 0, 0, 0, 0, 0, 0),
(12, 12, 4, 0, 0, 0, 0, 0, 0),
(13, 13, 4, 0, 0, 0, 0, 0, 0),
(14, 7, 1, 42, 42, 42, 242, 4, 0),
(15, 14, 1, 32, 324, 242, 24, 4, 0),
(16, 15, 2, 0, 0, 0, 0, 0, 0),
(17, 16, 5, 24, 32, 243, 42, 343, 0),
(18, 17, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `scoretype`
--

CREATE TABLE IF NOT EXISTS `scoretype` (
`scoreTypeId` int(11) NOT NULL,
  `name` varchar(30) COLLATE utf16_unicode_ci NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=6 ;

--
-- Dumping data for table `scoretype`
--

INSERT INTO `scoretype` (`scoreTypeId`, `name`) VALUES
(1, 'Quiz'),
(2, 'Homework'),
(3, 'Assignment'),
(4, 'Midterm'),
(5, 'Final');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE IF NOT EXISTS `student` (
`stdId` int(11) NOT NULL,
  `name` varchar(30) COLLATE utf16_unicode_ci NOT NULL,
  `gender` tinyint(1) NOT NULL,
  `subUserId` int(11) NOT NULL,
  `phone` varchar(15) COLLATE utf16_unicode_ci DEFAULT NULL,
  `photo` mediumblob,
  `photoPath` text COLLATE utf16_unicode_ci
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=18 ;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`stdId`, `name`, `gender`, `subUserId`, `phone`, `photo`, `photoPath`) VALUES
(3, 'sroin', 1, 1, '09292894', 0x53797374656d2e44726177696e672e4269746d6170, 'D:\\Heng MENGSROIN\\My Photos & Videos\\My Photos\\1057263_280538105425038_2129181287_o.jpg'),
(4, 'yulin', 1, 1, '02932374832', 0x53797374656d2e44726177696e672e4269746d6170, 'D:\\Heng MENGSROIN\\My Photos & Videos\\My Photos\\IMG_20130821_083609.jpg'),
(12, 'Sroin', 1, 4, '0938242874', NULL, NULL),
(13, 'Piseth', 1, 4, '0768767545', NULL, NULL),
(14, 'Meng', 1, 1, '0678576534', NULL, NULL),
(15, 'Nana', 0, 2, '093820242', NULL, NULL),
(16, 'sroin', 1, 5, '956746324', NULL, NULL),
(17, 'Nana', 0, 0, '096574345', 0x53797374656d2e44726177696e672e4269746d6170, 'D:\\Heng MENGSROIN\\My Photos & Videos\\My Photos\\IMG_20130820_160207.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE IF NOT EXISTS `subject` (
`subId` int(11) NOT NULL,
  `subName` varchar(30) COLLATE utf16_unicode_ci NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=11 ;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`subId`, `subName`) VALUES
(1, 'Programming'),
(7, 'Physics'),
(9, 'Math'),
(10, 'Math');

-- --------------------------------------------------------

--
-- Table structure for table `subjectuser`
--

CREATE TABLE IF NOT EXISTS `subjectuser` (
`subUserId` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `subId` int(11) NOT NULL,
  `startDate` date NOT NULL,
  `sessionNumber` int(11) NOT NULL,
  `year` int(4) NOT NULL,
  `semester` int(11) NOT NULL
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=6 ;

--
-- Dumping data for table `subjectuser`
--

INSERT INTO `subjectuser` (`subUserId`, `userId`, `subId`, `startDate`, `sessionNumber`, `year`, `semester`) VALUES
(1, 1, 1, '2016-04-05', 15, 1, 2),
(2, 1, 7, '2016-12-30', 15, 0, 0),
(3, 1, 8, '2016-12-23', 15, 2, 15),
(4, 2, 9, '2016-04-30', 15, 2, 15),
(5, 1, 10, '2016-05-04', 13, 3, 13);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
`userId` int(11) NOT NULL,
  `username` varchar(30) COLLATE utf16_unicode_ci NOT NULL,
  `password` varchar(30) COLLATE utf16_unicode_ci NOT NULL,
  `name` varchar(30) COLLATE utf16_unicode_ci NOT NULL,
  `gender` tinyint(1) NOT NULL,
  `role` tinyint(1) DEFAULT NULL,
  `photo` mediumblob,
  `photoPath` text COLLATE utf16_unicode_ci
) ENGINE=InnoDB  DEFAULT CHARSET=utf16 COLLATE=utf16_unicode_ci AUTO_INCREMENT=3 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `username`, `password`, `name`, `gender`, `role`, `photo`, `photoPath`) VALUES
(1, 'sroin', '1111', 'Heng Mengsroin', 0, NULL, 0x53797374656d2e44726177696e672e4269746d6170, 'D:\\Heng MENGSROIN\\My Photos & Videos\\My Photos\\myPhotoWhiteNew.jpg'),
(2, 'daly', '2222', 'Hong Daly', 0, NULL, NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
 ADD PRIMARY KEY (`id`);

--
-- Indexes for table `score`
--
ALTER TABLE `score`
 ADD PRIMARY KEY (`scoreId`);

--
-- Indexes for table `scoretype`
--
ALTER TABLE `scoretype`
 ADD PRIMARY KEY (`scoreTypeId`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
 ADD PRIMARY KEY (`stdId`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
 ADD PRIMARY KEY (`subId`);

--
-- Indexes for table `subjectuser`
--
ALTER TABLE `subjectuser`
 ADD PRIMARY KEY (`subUserId`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
 ADD PRIMARY KEY (`userId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendance`
--
ALTER TABLE `attendance`
MODIFY `id` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `score`
--
ALTER TABLE `score`
MODIFY `scoreId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=19;
--
-- AUTO_INCREMENT for table `scoretype`
--
ALTER TABLE `scoretype`
MODIFY `scoreTypeId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `student`
--
ALTER TABLE `student`
MODIFY `stdId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT for table `subject`
--
ALTER TABLE `subject`
MODIFY `subId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `subjectuser`
--
ALTER TABLE `subjectuser`
MODIFY `subUserId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
MODIFY `userId` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
