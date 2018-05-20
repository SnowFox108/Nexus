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
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('EDBB8074-7246-46FA-902A-5C4DBA0946CF', 'Navigation', '/App_Control_Style/Navigation/Icons/navigation', 'System Addon', '1.0.0', '2010-09-20', 'e2Tech.Ltd', 'Navigation');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('9257FB2E-34B2-450B-ABFC-8A43A4B91935', '-1', 'EDBB8074-7246-46FA-902A-5C4DBA0946CF', 'Css Menu', '/App_Control_Style/Navigation/Icons/css_menu', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('0CE8BAC0-B29E-493F-A549-3EC3281445CE', '-1', 'EDBB8074-7246-46FA-902A-5C4DBA0946CF', 'Menu', '/App_Control_Style/Navigation/Icons/menu', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('1E7EBF61-97B1-4625-892D-7AD0161CB48E', '-1', 'EDBB8074-7246-46FA-902A-5C4DBA0946CF', 'Navigator', '/App_Control_Style/Navigation/Icons/navigator', 'Addon', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('EDBB8074-7246-46FA-902A-5C4DBA0946CF', '9257FB2E-34B2-450B-ABFC-8A43A4B91935', 'Navigation', 'Css Menu', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('EDBB8074-7246-46FA-902A-5C4DBA0946CF', '0CE8BAC0-B29E-493F-A549-3EC3281445CE', 'Navigation', 'Menu', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('EDBB8074-7246-46FA-902A-5C4DBA0946CF', '1E7EBF61-97B1-4625-892D-7AD0161CB48E', 'Navigation', 'Navigator', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('9257FB2E-34B2-450B-ABFC-8A43A4B91935', '559E0155-5502-4710-9D24-99AD4DD25A11', 'Css Menu', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('0CE8BAC0-B29E-493F-A549-3EC3281445CE', '559E0155-5502-4710-9D24-99AD4DD25A11', 'Menu', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('1E7EBF61-97B1-4625-892D-7AD0161CB48E', '559E0155-5502-4710-9D24-99AD4DD25A11', 'Navigator', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('D5C38360-FA1F-480C-BEF5-6CADF8E53C35', '9257FB2E-34B2-450B-ABFC-8A43A4B91935', 'Css Menu', 'WebView', 'Nexus.Controls.Navigation.CSS_Menu.CSS_Menu_WebView', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('BC7B4BCF-7673-4B9F-B7F5-EF40C9649A59', '9257FB2E-34B2-450B-ABFC-8A43A4B91935', 'Css Menu Advanced', 'Advanced', 'Nexus.Controls.Navigation.CSS_Menu.CSS_Menu_Advanced', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('F11DE9CD-B3CF-4871-B2F8-6D6BBB1B966B', '9257FB2E-34B2-450B-ABFC-8A43A4B91935', 'Css Menu Editor', 'Editor', 'Nexus.Controls.Navigation.CSS_Menu.CSS_Menu_Editor', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('588CB005-E7BE-48B4-9DE0-45D8C7FB87AE', '0CE8BAC0-B29E-493F-A549-3EC3281445CE', 'Menu', 'WebView', 'Nexus.Controls.Navigation.Menu.Menu_WebView', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B52A4305-78A1-4289-97BC-1F0528583414', '0CE8BAC0-B29E-493F-A549-3EC3281445CE', 'Menu Advanced', 'Advanced', 'Nexus.Controls.Navigation.Menu.Menu_Advanced', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B8C03FC7-7F51-4B64-BCCD-F796ED6319BC', '0CE8BAC0-B29E-493F-A549-3EC3281445CE', 'Menu Editor', 'Editor', 'Nexus.Controls.Navigation.Menu.Menu_Editor', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('594F2CD7-57EE-472F-9636-51AAAFA6F072', '1E7EBF61-97B1-4625-892D-7AD0161CB48E', 'Navigator', 'WebView', 'Nexus.Controls.Navigation.Navigator.Navigator_WebView', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('FA22FE20-51E3-488E-BB83-0B06F38B01B2', '1E7EBF61-97B1-4625-892D-7AD0161CB48E', 'Navigator Advanced', 'Advanced', 'Nexus.Controls.Navigation.Navigator.Navigator_Advanced', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('BB9F1D26-BD8A-4AE9-8571-3CF52985451D', '1E7EBF61-97B1-4625-892D-7AD0161CB48E', 'Navigator Editor', 'Editor', 'Nexus.Controls.Navigation.Navigator.Navigator_Editor', 'Nexus.Controls.Navigation, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('559E0155-5502-4710-9D24-99AD4DD25A11', 'EDBB8074-7246-46FA-902A-5C4DBA0946CF', 'Navigation', true, true);

COMMIT;
