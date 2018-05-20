SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_MasterPageIndex`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_MasterPageIndex` (`MasterPageIndexID`, `MasterPage_Name`, `TemplateID`, `Template_MasterPageID`, `ThemeID`, `MasterPage_Description`) VALUES ('82C9EF99930741CCB76E1B4D4A77D0D9', 'Default Simple', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'E8FDEB85-B620-48B5-95C3-EFEEEB075F58', '8CC17810-E591-402A-9453-066681A43ADE', 'System default simple');
INSERT INTO `NexusCore_MasterPageIndex` (`MasterPageIndexID`, `MasterPage_Name`, `TemplateID`, `Template_MasterPageID`, `ThemeID`, `MasterPage_Description`) VALUES ('06BF339C09864B6698D7B243D25D889E', 'Default 2 Column Left', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', '641D2726-F692-4F5E-80C6-2416688CA408', '8CC17810-E591-402A-9453-066681A43ADE', 'System default 2 column left');
INSERT INTO `NexusCore_MasterPageIndex` (`MasterPageIndexID`, `MasterPage_Name`, `TemplateID`, `Template_MasterPageID`, `ThemeID`, `MasterPage_Description`) VALUES ('D8CD0F317AD542FEBD7ED326391850CC', 'Default 2 Column Right', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'E97B0BB5-961E-4346-80C6-722003E02C5B', '8CC17810-E591-402A-9453-066681A43ADE', 'System default 2 column right');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_MasterPages`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_MasterPages` (`MasterPageID`, `MasterPageIndexID`, `MasterPage_Version`, `Create_Date`, `LastUpdate_Date`, `LastUpdate_UserID`, `IsActive`, `IsDelete`) VALUES ('89E3775819994C8193659476CFF2028D', '82C9EF99930741CCB76E1B4D4A77D0D9', 1, '2011-06-01', '2011-06-01', 1, 1, 0);
INSERT INTO `NexusCore_MasterPages` (`MasterPageID`, `MasterPageIndexID`, `MasterPage_Version`, `Create_Date`, `LastUpdate_Date`, `LastUpdate_UserID`, `IsActive`, `IsDelete`) VALUES ('B82F96BB4E804B51B4E61B455125A478', '06BF339C09864B6698D7B243D25D889E', 1, '2011-06-01', '2011-06-01', 1, 1, 0);
INSERT INTO `NexusCore_MasterPages` (`MasterPageID`, `MasterPageIndexID`, `MasterPage_Version`, `Create_Date`, `LastUpdate_Date`, `LastUpdate_UserID`, `IsActive`, `IsDelete`) VALUES ('6BBBEB003C734087B7609F9B8B132B43', 'D8CD0F317AD542FEBD7ED326391850CC', 1, '2011-06-01', '2011-06-01', 1, 1, 0);

COMMIT;
