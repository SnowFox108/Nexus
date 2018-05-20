SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Modules` (
  `ModuleID` VARCHAR(36) NOT NULL ,
  `Module_Name` VARCHAR(250) NOT NULL ,
  `Module_Icon` VARCHAR(150) NULL ,
  `Module_Type` ENUM('System Addon','System Library', 'System Addon Fixed', 'System Library Fixed', 'Customer Addon', 'Customer Library') NOT NULL ,
  `Module_Version` VARCHAR(10) NOT NULL ,
  `Release_Date` DATE NOT NULL ,
  `Author` VARCHAR(45) NULL ,
  `Description` TEXT NULL ,
  PRIMARY KEY (`ModuleID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Components` (
  `ComponentID` VARCHAR(36) NOT NULL ,
  `Parent_ComponentID` VARCHAR(36) NULL DEFAULT '-1' ,
  `ModuleID` VARCHAR(36) NOT NULL ,
  `Component_Name` VARCHAR(200) NULL ,
  `Component_Icon` VARCHAR(150) NULL ,
  `Component_Type` ENUM('Addon', 'Sub Addon', 'Template', 'Theme', 'ControlPanel') NULL ,
  `Component_Version` VARCHAR(10) NULL ,
  PRIMARY KEY (`ComponentID`, `ModuleID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Toolbox_Options` (
  `ModuleID` VARCHAR(36) NULL ,
  `ComponentID` VARCHAR(36) NULL ,
  `Module_Name` VARCHAR(250) NULL ,
  `Component_Name` VARCHAR(200) NULL ,
  `Component_Version` VARCHAR(10) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT true ,
  PRIMARY KEY (`ModuleID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Toolbox_Tools` (
  `ComponentID` VARCHAR(36) NOT NULL ,
  `GroupID` VARCHAR(36) NULL ,
  `Tool_Name` VARCHAR(100) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT 'true' ,
  PRIMARY KEY (`ComponentID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Component_Controls` (
  `ControlID` VARCHAR(36) NOT NULL ,
  `ComponentID` VARCHAR(36) NOT NULL ,
  `Control_Name` VARCHAR(150) NOT NULL ,
  `Control_Type` ENUM('WebView', 'Advanced', 'Editor', 'Management', 'Wizard', 'ControlPanel') NULL ,
  `Class_Name` TEXT NULL ,
  `Assembly_Name` TEXT NULL ,
  PRIMARY KEY (`ControlID`, `ComponentID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Toolbox_Groups` (
  `GroupID` VARCHAR(36) NOT NULL ,
  `ModuleID` VARCHAR(36) NULL ,
  `Group_Name` VARCHAR(100) NULL ,
  `IsDefault` TINYINT(1) NULL DEFAULT true ,
  `IsOpened` TINYINT(1) NULL DEFAULT false ,
  PRIMARY KEY (`GroupID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Phrases`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Phrases` (
  `Language` VARCHAR(45) NULL DEFAULT '1' ,
  `VarName` VARCHAR(50) NOT NULL ,
  `FieldName` VARCHAR(50) NULL ,
  `PhraseName` TEXT NULL ,
  `PhraseValue` TEXT NULL ,
  `SortOrder` TINYINT(3) NULL ,
  `ModuleID` VARCHAR(36) NULL )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Items` (
  `Module_ItemID` VARCHAR(36) NOT NULL ,
  `ModuleID` VARCHAR(36) NOT NULL ,
  `Item_Name` VARCHAR(200) NOT NULL ,
  PRIMARY KEY (`Module_ItemID`, `ModuleID`) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', 'Ebay', '/App_Control_Style/Nexus_Ebay/Icons/Nexus_Ebay', 'Customer Addon', '1.2.0', '2011-12-09', 'e2Tech.Ltd', 'Ebay Ecommerce Basic');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('50F2A460-537D-4D61-8C04-471C29AE93F0', '-1', 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', 'Ebay Item List', '/App_Control_Style/Nexus_Ebay/Icons/ebay_itemlist', 'Addon', '1.2.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('88DB5F51-4164-4A78-9E6D-0DF0F813FA09', '-1', 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', 'Ebay Item Detail', '/App_Control_Style/Nexus_Ebay/Icons/ebay_itemdetail', 'Addon', '1.2.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('8E024A45-4AC0-41CA-9D5E-0E8BAEE0E0E1', '-1', 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', 'Ebay Manager', '/App_Control_Style/Nexus_Ebay/Icons/ebay_itemdetail', 'ControlPanel', '1.2.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', '50F2A460-537D-4D61-8C04-471C29AE93F0', 'Ebay', 'Ebay Item List', '1.2.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', '88DB5F51-4164-4A78-9E6D-0DF0F813FA09', 'Ebay', 'Ebay Item Detail', '1.2.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('50F2A460-537D-4D61-8C04-471C29AE93F0', 'EE8205B4-E799-4CA0-9641-ECB82F947AF1', 'Ebay Item List', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('88DB5F51-4164-4A78-9E6D-0DF0F813FA09', 'EE8205B4-E799-4CA0-9641-ECB82F947AF1', 'Ebay Item Detail', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('230BC11A-DA36-4D12-A442-A359578EF0DD', '50F2A460-537D-4D61-8C04-471C29AE93F0', 'Ebay Item List', 'WebView', 'Nexus.Controls.Ebay.ItemList.ItemList_WebView', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('9531BFFC-BE67-482E-A6F4-5F9DED37B66D', '50F2A460-537D-4D61-8C04-471C29AE93F0', 'Ebay Item List Advanced', 'Advanced', 'Nexus.Controls.Ebay.ItemList.ItemList_Advanced', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('A3596A46-9C94-4F33-B6AF-75A43478357C', '50F2A460-537D-4D61-8C04-471C29AE93F0', 'Ebay Item List Editor', 'Editor', 'Nexus.Controls.Ebay.ItemList.ItemList_Editor', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('AC16C6A4-6BFC-43E3-8D9F-445F3565FD23', '88DB5F51-4164-4A78-9E6D-0DF0F813FA09', 'Ebay Item Detail', 'WebView', 'Nexus.Controls.Ebay.ItemDetail.ItemDetail_WebView', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('27534F5B-40EB-43FA-8A4F-0B82F1021F58', '88DB5F51-4164-4A78-9E6D-0DF0F813FA09', 'Ebay Item Detail Advanced', 'Advanced', 'Nexus.Controls.Ebay.ItemDetail.ItemDetail_Advanced', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('7B65C012-ECED-4E07-8CF5-7057ADDC42A4', '88DB5F51-4164-4A78-9E6D-0DF0F813FA09', 'Ebay Item Detail Editor', 'Editor', 'Nexus.Controls.Ebay.ItemDetail.ItemDetail_Editor', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B25DF783-A9A1-4E27-B71C-9F4DD0835F08', '8E024A45-4AC0-41CA-9D5E-0E8BAEE0E0E1', 'Ebay Setting', 'Management', 'Nexus.Controls.Ebay.Management.Management_EbaySetting', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('BB8163BF-70EA-4861-82ED-30D019815563', '8E024A45-4AC0-41CA-9D5E-0E8BAEE0E0E1', 'Manage Items', 'Management', 'Nexus.Controls.Ebay.Management.Management_ManageItems', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('833B051C-720F-46F5-9B63-4C10FCD7BBC2', '8E024A45-4AC0-41CA-9D5E-0E8BAEE0E0E1', 'Fetch Items', 'ControlPanel', 'Nexus.Controls.Ebay.ControlPanel.ControlPanel_FetchItem', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('8BF5ABB9-30D5-429E-8017-A168672AC15F', '8E024A45-4AC0-41CA-9D5E-0E8BAEE0E0E1', 'Edit Items', 'ControlPanel', 'Nexus.Controls.Ebay.ControlPanel.ControlPanel_EditItem', 'Nexus.Controls.Ebay, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('EE8205B4-E799-4CA0-9641-ECB82F947AF1', 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', 'Ebay', true, false);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Phrases`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Phrases` (`Language`, `VarName`, `FieldName`, `PhraseName`, `PhraseValue`, `SortOrder`, `ModuleID`) VALUES (0, 'NexusEbay_Environment_ApiServerUrl', 'NexusEbay setting', '', 'https://api.ebay.com/wsapi', 0, 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6');
INSERT INTO `NexusCore_Phrases` (`Language`, `VarName`, `FieldName`, `PhraseName`, `PhraseValue`, `SortOrder`, `ModuleID`) VALUES (0, 'NexusEbay_UserAccount_ApiToken', 'NexusEbay setting', '', '', 0, 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6');
INSERT INTO `NexusCore_Phrases` (`Language`, `VarName`, `FieldName`, `PhraseName`, `PhraseValue`, `SortOrder`, `ModuleID`) VALUES (0, 'NexusEbay_SiteCode', 'NexusEbay setting', '', 'UK', 0, 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6');
INSERT INTO `NexusCore_Phrases` (`Language`, `VarName`, `FieldName`, `PhraseName`, `PhraseValue`, `SortOrder`, `ModuleID`) VALUES (0, 'NexusEbay_DevID', 'NexusEbay setting', '', 'fa93ba08-b5f0-45f5-b7c2-d385727a2ff3', 0, 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6');
INSERT INTO `NexusCore_Phrases` (`Language`, `VarName`, `FieldName`, `PhraseName`, `PhraseValue`, `SortOrder`, `ModuleID`) VALUES (0, 'NexusEbay_AppID', 'NexusEbay setting', '', 'e2TechLt-8519-4070-ad98-a5d48205a63a', 0, 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6');
INSERT INTO `NexusCore_Phrases` (`Language`, `VarName`, `FieldName`, `PhraseName`, `PhraseValue`, `SortOrder`, `ModuleID`) VALUES (0, 'NexusEbay_CertID', 'NexusEbay setting', '', '990e7aa5-0551-414a-bdef-94f6f02b300e', 0, 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('707AF36D-CDFC-44EF-81B1-4D5FEFDDAEE6', 'B5281FAB-ECDE-4EC6-BD7F-6B413EECD8F6', 'Ebay Item');

COMMIT;
