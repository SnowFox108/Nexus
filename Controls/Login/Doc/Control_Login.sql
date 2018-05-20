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
  `IsActive` TINYINT(1) NULL DEFAULT true ,
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
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login', '/App_Control_Style/Nexus_Login/Icons/Nexus_Login', 'Customer Addon', '1.0.0', '2011-03-21', 'e2Tech.Ltd', 'Login');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('8F4BCC97-8B08-4930-B823-8B9E2900CCE3', '-1', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Create User', '/App_Control_Style/Nexus_Login/Icons/createuser', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('D70341BF-3A26-45C1-BA4B-55CE9F66C952', '-1', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login', '/App_Control_Style/Nexus_Login/Icons/login', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('91EDF8DE-DEC5-4F9A-83BB-16B5AC9E0A3E', '-1', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login Name', '/App_Control_Style/Nexus_Login/Icons/loginname', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('9F8CFE21-F1E3-46E3-BD29-A44AFDAFBBA4', '-1', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login Refresh', '/App_Control_Style/Nexus_Login/Icons/loginrefresh', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('71A0D480-D212-48A4-A142-ED10B94E49D0', '-1', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login Status', '/App_Control_Style/Nexus_Login/Icons/loginstatus', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('2E6261C2-D797-4321-B7A9-F62FAC41D595', '-1', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login View', '/App_Control_Style/Nexus_Login/Icons/loginview', 'Addon', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', '8F4BCC97-8B08-4930-B823-8B9E2900CCE3', 'Login', 'Create User', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'D70341BF-3A26-45C1-BA4B-55CE9F66C952', 'Login', 'Login', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', '91EDF8DE-DEC5-4F9A-83BB-16B5AC9E0A3E', 'Login', 'Login Name', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', '9F8CFE21-F1E3-46E3-BD29-A44AFDAFBBA4', 'Login', 'Login Refresh', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', '71A0D480-D212-48A4-A142-ED10B94E49D0', 'Login', 'Login Status', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('842C4297-FA78-4264-B6CD-7A6B5ECC0758', '2E6261C2-D797-4321-B7A9-F62FAC41D595', 'Login', 'Login View', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('8F4BCC97-8B08-4930-B823-8B9E2900CCE3', '090AFBFC-C0F5-4022-BE44-A3CB8489AD97', 'Create User', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('D70341BF-3A26-45C1-BA4B-55CE9F66C952', '090AFBFC-C0F5-4022-BE44-A3CB8489AD97', 'Login', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('91EDF8DE-DEC5-4F9A-83BB-16B5AC9E0A3E', '090AFBFC-C0F5-4022-BE44-A3CB8489AD97', 'Login Name', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('9F8CFE21-F1E3-46E3-BD29-A44AFDAFBBA4', '090AFBFC-C0F5-4022-BE44-A3CB8489AD97', 'Login Refresh', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('71A0D480-D212-48A4-A142-ED10B94E49D0', '090AFBFC-C0F5-4022-BE44-A3CB8489AD97', 'Login Status', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('2E6261C2-D797-4321-B7A9-F62FAC41D595', '090AFBFC-C0F5-4022-BE44-A3CB8489AD97', 'Login View', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('1B7CEF8C-B7A0-49E2-9913-8F96E05A8EA1', '8F4BCC97-8B08-4930-B823-8B9E2900CCE3', 'Create User', 'WebView', 'Nexus.Controls.Login.CreateUser.CreateUser_WebView', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B8BE1004-D21C-4A2A-A139-B446BD210975', '8F4BCC97-8B08-4930-B823-8B9E2900CCE3', 'Create User Advanced', 'Advanced', 'Nexus.Controls.Login.CreateUser.CreateUser_Advanced', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('057CDEB6-1D2C-44FB-8545-EB28C2094C11', '8F4BCC97-8B08-4930-B823-8B9E2900CCE3', 'Create User Editor', 'Editor', 'Nexus.Controls.Login.CreateUser.CreateUser_Editor', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('A47E3DBE-5576-47E9-BA05-0E9D12C73BAF', 'D70341BF-3A26-45C1-BA4B-55CE9F66C952', 'Login', 'WebView', 'Nexus.Controls.Login.Login.Login_WebView', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('799C719A-11C1-4709-A0FA-C95AF4BCD4A5', 'D70341BF-3A26-45C1-BA4B-55CE9F66C952', 'Login Advanced', 'Advanced', 'Nexus.Controls.Login.Login.Login_Advanced', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('FD8F72B6-4E9B-477D-903C-A732143D81DD', 'D70341BF-3A26-45C1-BA4B-55CE9F66C952', 'Login Editor', 'Editor', 'Nexus.Controls.Login.Login.Login_Editor', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('26FB0B00-B566-406D-93E4-0E390650A886', '91EDF8DE-DEC5-4F9A-83BB-16B5AC9E0A3E', 'Login Name', 'WebView', 'Nexus.Controls.Login.LoginName.LoginName_WebView', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('4CB1EDDD-A38F-4121-A36F-DCBD60347FF5', '91EDF8DE-DEC5-4F9A-83BB-16B5AC9E0A3E', 'Login Name Advanced', 'Advanced', 'Nexus.Controls.Login.LoginName.LoginName_Advanced', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('2CD2D137-0F29-465C-A2EF-18EAD02C72BC', '91EDF8DE-DEC5-4F9A-83BB-16B5AC9E0A3E', 'Login Name Editor', 'Editor', 'Nexus.Controls.Login.LoginName.LoginName_Editor', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('096E1C84-A302-44D4-8933-25EA985AE831', '9F8CFE21-F1E3-46E3-BD29-A44AFDAFBBA4', 'Login Refresh', 'WebView', 'Nexus.Controls.Login.LoginRefresh.LoginRefresh_WebView', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('CA0CE4F4-724B-4273-88B7-26613061C48D', '9F8CFE21-F1E3-46E3-BD29-A44AFDAFBBA4', 'Login Refresh Advanced', 'Advanced', 'Nexus.Controls.Login.LoginRefresh.LoginRefresh_Advanced', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('6CE100CE-3183-46BE-8383-E865B1562A83', '9F8CFE21-F1E3-46E3-BD29-A44AFDAFBBA4', 'Login Refresh Editor', 'Editor', 'Nexus.Controls.Login.LoginRefresh.LoginRefresh_Editor', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('24A209B5-163F-40F0-A43A-3067AC47E6B8', '71A0D480-D212-48A4-A142-ED10B94E49D0', 'Login Status', 'WebView', 'Nexus.Controls.Login.LoginStatus.LoginStatus_WebView', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('42EB2A3F-8431-436D-B5D8-99312112EFFD', '71A0D480-D212-48A4-A142-ED10B94E49D0', 'Login Status Advanced', 'Advanced', 'Nexus.Controls.Login.LoginStatus.LoginStatus_Advanced', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('F89499C0-B237-4D9E-8552-BAD01D98AC37', '71A0D480-D212-48A4-A142-ED10B94E49D0', 'Login Status Editor', 'Editor', 'Nexus.Controls.Login.LoginStatus.LoginStatus_Editor', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B81B79C0-9770-4B41-8F20-9987F1DECD73', '2E6261C2-D797-4321-B7A9-F62FAC41D595', 'Login View', 'WebView', 'Nexus.Controls.Login.LoginView.LoginView_WebView', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('E703C5D5-BB6B-4B07-86CE-31E4A63D7573', '2E6261C2-D797-4321-B7A9-F62FAC41D595', 'Login View Advanced', 'Advanced', 'Nexus.Controls.Login.LoginView.LoginView_Advanced', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('90D5AD87-DA58-4DC7-89BD-F9CC4CC82707', '2E6261C2-D797-4321-B7A9-F62FAC41D595', 'Login View Editor', 'Editor', 'Nexus.Controls.Login.LoginView.LoginView_Editor', 'Nexus.Controls.Login, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('090AFBFC-C0F5-4022-BE44-A3CB8489AD97', '842C4297-FA78-4264-B6CD-7A6B5ECC0758', 'Login', true, false);

COMMIT;
