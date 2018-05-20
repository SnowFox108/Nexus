SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Templates`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Templates` (`TemplateID`, `Template_Name`, `LanguageCode`, `Template_Version`, `Release_Date`, `Author`, `Description`) VALUES ('C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default', 'GB', '1.0.0', '2011-06-01', 'e2Tech.Ltd', 'System default template');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Template_MasterPages`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Template_MasterPages` (`Template_MasterPageID`, `TemplateID`, `MasterPage_Template_Name`, `MasterPage_Version`, `MasterPage_URL`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default Simple', '1.0.0', '~/App_Template/Default/Default_Simple.master');
INSERT INTO `NexusCore_Template_MasterPages` (`Template_MasterPageID`, `TemplateID`, `MasterPage_Template_Name`, `MasterPage_Version`, `MasterPage_URL`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default 2 Column Left side', '1.0.0', '~/App_Template/Default/Default_Left_Column.master');
INSERT INTO `NexusCore_Template_MasterPages` (`Template_MasterPageID`, `TemplateID`, `MasterPage_Template_Name`, `MasterPage_Version`, `MasterPage_URL`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default 2 Column Right side', '1.0.0', '~/App_Template/Default/Default_Right_Column.master');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Themes`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Themes` (`ThemeID`, `TemplateID`, `Theme_Name`, `LanguageCode`, `Theme_Version`, `Theme_Code`, `Release_Date`, `Author`, `Description`) VALUES ('8CC17810-E591-402A-9453-066681A43ADE', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default Blue', 'GB', '1.0.0', 'Default_Blue', '2011-06-01', 'e2Tech.Ltd', 'Default Blue Theme');
INSERT INTO `NexusCore_Themes` (`ThemeID`, `TemplateID`, `Theme_Name`, `LanguageCode`, `Theme_Version`, `Theme_Code`, `Release_Date`, `Author`, `Description`) VALUES ('55FA99FE-86FB-40D1-ABF9-0B6F3751A840', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default Green', 'GB', '1.0.0', 'Default_Green', '2011-06-01', 'e2Tech.Ltd', 'Default Green Theme');
INSERT INTO `NexusCore_Themes` (`ThemeID`, `TemplateID`, `Theme_Name`, `LanguageCode`, `Theme_Version`, `Theme_Code`, `Release_Date`, `Author`, `Description`) VALUES ('F6F3AD00-9B39-402A-ABFC-759E63B8DBBB', 'C055B1B4-E698-49D7-B2A7-9C2B1CF4BF29', 'Default Red', 'GB', '1.0.0', 'Default_Red', '2011-06-01', 'e2Tech.Ltd', 'Default Red Theme');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Template_MasterPage_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;

INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'ContentPlaceHolder_Logo', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'ContentPlaceHolder_Header', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'ContentPlaceHolder_MainMenu', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'ContentPlaceHolder_PageContent', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'ContentPlaceHolder_Footer', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E8FDEB85-B620-48B5-95C3-EFEEEB075F58', 'ContentPlaceHolder_Scripts', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_Logo', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_Header', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_MainMenu', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_Side', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_PageContent', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_Footer', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('641D2726-F692-4F5E-80C6-2416688CA408', 'ContentPlaceHolder_Scripts', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_Logo', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_Header', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_MainMenu', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_Side', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_PageContent', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_Footer', 250, 10, 10, 10, 'Vertical');
INSERT INTO `NexusCore_Template_MasterPage_Controls` (`Template_MasterPageID`, `PlaceHolderID`, `MinWidth`, `MinHeight`, `Width`, `Height`, `Orientation`) VALUES ('E97B0BB5-961E-4346-80C6-722003E02C5B', 'ContentPlaceHolder_Scripts', 250, 10, 10, 10, 'Vertical');

COMMIT;

