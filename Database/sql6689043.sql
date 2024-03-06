-- phpMyAdmin SQL Dump
-- version 4.7.1
-- https://www.phpmyadmin.net/
--
-- Host: sql6.freemysqlhosting.net
-- Generation Time: Mar 06, 2024 at 09:53 AM
-- Server version: 5.5.62-0ubuntu0.14.04.1
-- PHP Version: 7.0.33-0ubuntu0.16.04.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sql6689043`
--

-- --------------------------------------------------------

--
-- Table structure for table `MasterPass_Table`
--

CREATE TABLE `MasterPass_Table` (
  `ID` int(50) NOT NULL,
  `mail` varchar(50) NOT NULL,
  `masterPassword` varchar(50) NOT NULL,
  `signupCount` int(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `MasterPass_Table`
--

INSERT INTO `MasterPass_Table` (`ID`, `mail`, `masterPassword`, `signupCount`) VALUES
(1, 'dip.kumar020@gmail.com', 'admin', 0);

-- --------------------------------------------------------

--
-- Table structure for table `Password_Table`
--

CREATE TABLE `Password_Table` (
  `ID` int(50) NOT NULL,
  `date` varchar(50) NOT NULL,
  `siteLink` varchar(50) NOT NULL,
  `siteName` varchar(50) NOT NULL,
  `mail` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Password_Table`
--

INSERT INTO `Password_Table` (`ID`, `date`, `siteLink`, `siteName`, `mail`, `username`, `password`) VALUES
(1, '3/6/2024 2:37:43 PM', 'test.com', 'test name', 'test@gmail.com', 'test', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `Settings_Table`
--

CREATE TABLE `Settings_Table` (
  `ID` int(50) NOT NULL,
  `indicator` varchar(50) NOT NULL,
  `displaySiteLink` varchar(50) NOT NULL,
  `displaySiteName` varchar(50) NOT NULL,
  `displayMail` varchar(50) NOT NULL,
  `displayUserName` varchar(50) NOT NULL,
  `displayPassword` varchar(50) NOT NULL,
  `useSmallAlphabets` varchar(50) NOT NULL,
  `useCapitalAlphabets` varchar(50) NOT NULL,
  `useNumbers` varchar(50) NOT NULL,
  `useSpecialChar` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Settings_Table`
--

INSERT INTO `Settings_Table` (`ID`, `indicator`, `displaySiteLink`, `displaySiteName`, `displayMail`, `displayUserName`, `displayPassword`, `useSmallAlphabets`, `useCapitalAlphabets`, `useNumbers`, `useSpecialChar`) VALUES
(1, '1', '1', '1', '1', '1', '1', '1', '1', '1', '1');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `MasterPass_Table`
--
ALTER TABLE `MasterPass_Table`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Password_Table`
--
ALTER TABLE `Password_Table`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `Settings_Table`
--
ALTER TABLE `Settings_Table`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `MasterPass_Table`
--
ALTER TABLE `MasterPass_Table`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `Password_Table`
--
ALTER TABLE `Password_Table`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `Settings_Table`
--
ALTER TABLE `Settings_Table`
  MODIFY `ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
