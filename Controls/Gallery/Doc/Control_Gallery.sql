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
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Gallery', '/App_Control_Style/Nexus_Gallery/Icons/Nexus_Gallery', 'Customer Addon', '1.0.0', '2012-01-30', 'e2Tech.Ltd', 'Photo Gallery');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('3C7439E5-A998-46E5-A092-463C70A3AA0B', '-1', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Photo List', '/App_Control_Style/Nexus_Gallery/Icons/gallery_itemlist', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('1B925E9F-3D19-4588-969E-8C6AE631828B', '-1', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Photo Detail', '/App_Control_Style/Nexus_Gallery/Icons/gallery_itemdetail', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('4FC9A582-8AAF-4951-87C1-0B8C70BFAEBB', '-1', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Gallery Manager', '/App_Control_Style/Nexus_Gallery/Icons/gallery_itemdetail', 'ControlPanel', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('6182CB1A-107E-4C14-B91E-4C9DE15B9074', '3C7439E5-A998-46E5-A092-463C70A3AA0B', 'Gallery', 'Photo List', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('6182CB1A-107E-4C14-B91E-4C9DE15B9074', '1B925E9F-3D19-4588-969E-8C6AE631828B', 'Gallery', 'Photo Detail', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('3C7439E5-A998-46E5-A092-463C70A3AA0B', '3AF83F98-C56E-42EF-8B0C-3FB13A8DE9EF', 'Photo List', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('1B925E9F-3D19-4588-969E-8C6AE631828B', '3AF83F98-C56E-42EF-8B0C-3FB13A8DE9EF', 'Photo Detail', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('23F920C0-18E7-4656-A5FB-725C4367816D', '3C7439E5-A998-46E5-A092-463C70A3AA0B', 'Photo List', 'WebView', 'Nexus.Controls.Gallery.ItemList.ItemList_WebView', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('3CE6731B-9553-4E52-8122-EC37C686FB82', '3C7439E5-A998-46E5-A092-463C70A3AA0B', 'Photo List Advanced', 'Advanced', 'Nexus.Controls.Gallery.ItemList.ItemList_Advanced', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('64F7F6DA-561F-4F47-A0DE-B478A3F78CD6', '3C7439E5-A998-46E5-A092-463C70A3AA0B', 'Photo List Editor', 'Editor', 'Nexus.Controls.Gallery.ItemList.ItemList_Editor', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('119F491D-666D-4CB2-A337-B0A328546F51', '1B925E9F-3D19-4588-969E-8C6AE631828B', 'Photo Detail', 'WebView', 'Nexus.Controls.Gallery.ItemDetail.ItemDetail_WebView', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('BA46CFBA-09AA-47F9-983D-2F2613A63600', '1B925E9F-3D19-4588-969E-8C6AE631828B', 'Photo Detail Advanced', 'Advanced', 'Nexus.Controls.Gallery.ItemDetail.ItemDetail_Advanced', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('0D8EA8BB-8045-476E-93EA-8B0DAEFDAD3A', '1B925E9F-3D19-4588-969E-8C6AE631828B', 'Photo Detail Editor', 'Editor', 'Nexus.Controls.Gallery.ItemDetail.ItemDetail_Editor', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('E11A5389-44BF-47C8-AF90-B2EA485A2849', '4FC9A582-8AAF-4951-87C1-0B8C70BFAEBB', 'Gallery Setting', 'Management', 'Nexus.Controls.Gallery.Management.Management_PhotoSetting', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('4979A4B0-3F09-4579-9520-90AC64257116', '4FC9A582-8AAF-4951-87C1-0B8C70BFAEBB', 'Manage Items', 'Management', 'Nexus.Controls.Gallery.Management.Management_ManageItems', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('43D902AF-A0DC-4036-BC46-C98EC84B6698', '4FC9A582-8AAF-4951-87C1-0B8C70BFAEBB', 'Edit Items', 'ControlPanel', 'Nexus.Controls.Gallery.ControlPanel.ControlPanel_EditItem', 'Nexus.Controls.Gallery, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('3AF83F98-C56E-42EF-8B0C-3FB13A8DE9EF', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Gallery', true, false);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('9473F482-CC30-4963-946A-28CA4AD44041', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Photo Item');

COMMIT;
