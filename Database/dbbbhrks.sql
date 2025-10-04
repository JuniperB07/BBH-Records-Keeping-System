-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 04, 2025 at 11:17 AM
-- Server version: 9.1.0
-- PHP Version: 8.3.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbbbhrks`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbadditionals`
--

DROP TABLE IF EXISTS `tbadditionals`;
CREATE TABLE IF NOT EXISTS `tbadditionals` (
  `AdditionalID` int NOT NULL AUTO_INCREMENT,
  `TenantID` int NOT NULL,
  `EnforcementDate` date NOT NULL,
  `Details` text NOT NULL,
  `TotalFee` decimal(10,2) NOT NULL,
  `AmountPaid` decimal(10,2) NOT NULL,
  `RemainingBalance` decimal(10,2) NOT NULL,
  `Status` varchar(15) NOT NULL,
  PRIMARY KEY (`AdditionalID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbbillpreview_receipts`
--

DROP TABLE IF EXISTS `tbbillpreview_receipts`;
CREATE TABLE IF NOT EXISTS `tbbillpreview_receipts` (
  `BPRID` int NOT NULL AUTO_INCREMENT,
  `ORNumber` varchar(30) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `TransactionDateTime` datetime NOT NULL,
  `BillType` varchar(15) NOT NULL,
  `AmountPaid` double NOT NULL,
  PRIMARY KEY (`BPRID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbbills`
--

DROP TABLE IF EXISTS `tbbills`;
CREATE TABLE IF NOT EXISTS `tbbills` (
  `BillID` int NOT NULL AUTO_INCREMENT,
  `BillNumber` varchar(30) NOT NULL,
  `TenantID` int NOT NULL,
  `BillingDate` date NOT NULL,
  `DueDate` date NOT NULL,
  `WaterBillID` int NOT NULL,
  `ElectricityBillID` int NOT NULL,
  `RentalBillID` int NOT NULL,
  `InternetBillID` int NOT NULL,
  `BillTotal` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`BillID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbdashboard_overdues`
--

DROP TABLE IF EXISTS `tbdashboard_overdues`;
CREATE TABLE IF NOT EXISTS `tbdashboard_overdues` (
  `DOID` int NOT NULL AUTO_INCREMENT,
  `TenantName` varchar(50) NOT NULL,
  `DaysOverdue` int NOT NULL,
  `DueDate` date NOT NULL,
  `AmountDue` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  `BillNumber` varchar(30) NOT NULL,
  PRIMARY KEY (`DOID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbdashboard_unpaidbills`
--

DROP TABLE IF EXISTS `tbdashboard_unpaidbills`;
CREATE TABLE IF NOT EXISTS `tbdashboard_unpaidbills` (
  `DUBID` int NOT NULL AUTO_INCREMENT,
  `TenantName` varchar(50) NOT NULL,
  `DaysToDueDate` int NOT NULL,
  `DueDate` date NOT NULL,
  `AmountDue` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  `BillNumber` varchar(30) NOT NULL,
  PRIMARY KEY (`DUBID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbdeductions`
--

DROP TABLE IF EXISTS `tbdeductions`;
CREATE TABLE IF NOT EXISTS `tbdeductions` (
  `DeductionID` int NOT NULL AUTO_INCREMENT,
  `TenantID` int NOT NULL,
  `BillType` varchar(15) NOT NULL,
  `UnusedCredits` decimal(10,2) NOT NULL DEFAULT '0.00',
  `UnusedAdvances` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`DeductionID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbelectricitybill`
--

DROP TABLE IF EXISTS `tbelectricitybill`;
CREATE TABLE IF NOT EXISTS `tbelectricitybill` (
  `ElectricityBillID` int NOT NULL AUTO_INCREMENT,
  `BillNumber` varchar(30) NOT NULL,
  `TenantID` int NOT NULL,
  `PreviousReading` double NOT NULL,
  `PresentReading` double NOT NULL,
  `Consumption` decimal(10,2) NOT NULL,
  `CurrentCharge` decimal(10,2) NOT NULL,
  `RemainingBalance` decimal(10,2) NOT NULL,
  `Deductions` decimal(10,2) NOT NULL,
  `Subtotal` decimal(10,2) NOT NULL,
  `BillBalance` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`ElectricityBillID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbemergency`
--

DROP TABLE IF EXISTS `tbemergency`;
CREATE TABLE IF NOT EXISTS `tbemergency` (
  `EmergencyID` int NOT NULL AUTO_INCREMENT,
  `TenantID` int NOT NULL,
  `ContactPerson` varchar(50) NOT NULL,
  `Phone` varchar(50) NOT NULL,
  `Address` text NOT NULL,
  `Relationship` varchar(25) NOT NULL,
  PRIMARY KEY (`EmergencyID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbinternetbill`
--

DROP TABLE IF EXISTS `tbinternetbill`;
CREATE TABLE IF NOT EXISTS `tbinternetbill` (
  `InternetBillID` int NOT NULL AUTO_INCREMENT,
  `BillNumber` varchar(30) NOT NULL,
  `TenantID` int NOT NULL,
  `DueDate` date NOT NULL,
  `Plan` varchar(15) NOT NULL,
  `SubscriptionFee` decimal(10,2) NOT NULL,
  `RemainingBalance` decimal(10,2) NOT NULL,
  `Deductions` decimal(10,2) NOT NULL,
  `Subtotal` decimal(10,2) NOT NULL,
  `BillBalance` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`InternetBillID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbinternetplans`
--

DROP TABLE IF EXISTS `tbinternetplans`;
CREATE TABLE IF NOT EXISTS `tbinternetplans` (
  `PlanID` int NOT NULL AUTO_INCREMENT,
  `Details` varchar(15) NOT NULL,
  `PlanPrice` decimal(10,2) NOT NULL,
  `Status` varchar(15) NOT NULL,
  PRIMARY KEY (`PlanID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbmetadata`
--

DROP TABLE IF EXISTS `tbmetadata`;
CREATE TABLE IF NOT EXISTS `tbmetadata` (
  `MID` int NOT NULL AUTO_INCREMENT,
  `Category` varchar(50) NOT NULL,
  `Details` varchar(100) NOT NULL,
  `Value` varchar(50) NOT NULL,
  PRIMARY KEY (`MID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbpaymentmethod`
--

DROP TABLE IF EXISTS `tbpaymentmethod`;
CREATE TABLE IF NOT EXISTS `tbpaymentmethod` (
  `PMID` int NOT NULL AUTO_INCREMENT,
  `Method` varchar(100) NOT NULL,
  `AccountDetails` varchar(50) NOT NULL DEFAULT 'N/A',
  `Status` varchar(50) NOT NULL,
  PRIMARY KEY (`PMID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbpaymentpreview_receipts`
--

DROP TABLE IF EXISTS `tbpaymentpreview_receipts`;
CREATE TABLE IF NOT EXISTS `tbpaymentpreview_receipts` (
  `PPRID` int NOT NULL AUTO_INCREMENT,
  `ORNumber` varchar(30) NOT NULL,
  `TransactionDateTime` datetime NOT NULL,
  `BillType` varchar(15) NOT NULL,
  `AmountPaid` decimal(10,2) NOT NULL,
  PRIMARY KEY (`PPRID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbpayments`
--

DROP TABLE IF EXISTS `tbpayments`;
CREATE TABLE IF NOT EXISTS `tbpayments` (
  `PaymentID` int NOT NULL AUTO_INCREMENT,
  `ReceiptNumber` varchar(30) NOT NULL,
  `BillNumber` varchar(30) NOT NULL,
  `TenantID` int NOT NULL,
  `BillType` varchar(15) NOT NULL,
  `TransactionDateTime` datetime NOT NULL,
  `AmountPaid` decimal(10,2) NOT NULL,
  `TransactionBalance` decimal(10,2) NOT NULL,
  `PaymentMethod` varchar(100) NOT NULL,
  PRIMARY KEY (`PaymentID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbrentalbill`
--

DROP TABLE IF EXISTS `tbrentalbill`;
CREATE TABLE IF NOT EXISTS `tbrentalbill` (
  `RentalBillID` int NOT NULL AUTO_INCREMENT,
  `BillNumber` varchar(30) NOT NULL,
  `TenantID` int NOT NULL,
  `MonthlyDue` decimal(10,2) NOT NULL,
  `AdditionalCharges` decimal(10,2) NOT NULL,
  `CurrentCharges` decimal(10,2) NOT NULL,
  `RemainingBalance` decimal(10,2) NOT NULL,
  `Deductions` decimal(10,2) NOT NULL,
  `Subtotal` decimal(10,2) NOT NULL,
  `BillBalance` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`RentalBillID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbrooms`
--

DROP TABLE IF EXISTS `tbrooms`;
CREATE TABLE IF NOT EXISTS `tbrooms` (
  `RoomID` int NOT NULL AUTO_INCREMENT,
  `RoomName` varchar(15) NOT NULL,
  `Status` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`RoomID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbtenants`
--

DROP TABLE IF EXISTS `tbtenants`;
CREATE TABLE IF NOT EXISTS `tbtenants` (
  `TenantID` int NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(25) NOT NULL,
  `LastName` varchar(25) NOT NULL,
  `FullName` varchar(50) NOT NULL,
  `DateOfBirth` date NOT NULL DEFAULT '2000-01-01',
  `Phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` text NOT NULL,
  `RentType` varchar(15) NOT NULL,
  `Room` varchar(5) NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL DEFAULT '2000-01-01',
  `InternetPlan` varchar(15) NOT NULL,
  `Status` varchar(15) NOT NULL,
  PRIMARY KEY (`TenantID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbusers`
--

DROP TABLE IF EXISTS `tbusers`;
CREATE TABLE IF NOT EXISTS `tbusers` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(20) NOT NULL,
  `Password` text CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `Level` varchar(15) NOT NULL DEFAULT 'LOW',
  `Status` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbwaterbill`
--

DROP TABLE IF EXISTS `tbwaterbill`;
CREATE TABLE IF NOT EXISTS `tbwaterbill` (
  `WaterBillID` int NOT NULL AUTO_INCREMENT,
  `BillNumber` varchar(30) NOT NULL,
  `TenantID` int NOT NULL,
  `PreviousReading` double NOT NULL,
  `PresentReading` double NOT NULL,
  `Consumption` decimal(10,2) NOT NULL,
  `CurrentCharge` decimal(10,2) NOT NULL,
  `RemainingBalance` decimal(10,2) NOT NULL,
  `Deductions` decimal(10,2) NOT NULL,
  `Subtotal` decimal(10,2) NOT NULL,
  `BillBalance` decimal(10,2) NOT NULL,
  `Status` varchar(10) NOT NULL,
  PRIMARY KEY (`WaterBillID`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
