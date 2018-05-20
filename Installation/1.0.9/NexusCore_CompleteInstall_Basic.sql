-- -----------------------------------------------------
-- Step01_1_ Framework
-- -----------------------------------------------------

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

DROP SCHEMA IF EXISTS `e2CMS` ;
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
-- Table `e2CMS`.`NexusCore_URLrewrite_Rules`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_URLrewrite_Rules` (
  `RuleID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_IndexID` VARCHAR(36) NULL DEFAULT 0 ,
  `Rule_Type` ENUM('Static','Dynamic','Field') NULL ,
  `Base_URL` VARCHAR(45) NULL ,
  `Orginal_URL` VARCHAR(45) NULL ,
  `Base_Value` VARCHAR(45) NULL ,
  `Destination_URL` VARCHAR(45) NULL ,
  PRIMARY KEY (`RuleID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Templates`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Templates` (
  `TemplateID` VARCHAR(36) NOT NULL ,
  `Template_Name` VARCHAR(250) NOT NULL ,
  `LanguageCode` VARCHAR(5) NULL ,
  `Template_Version` VARCHAR(10) NOT NULL ,
  `Release_Date` DATETIME NOT NULL ,
  `Author` VARCHAR(50) NULL ,
  `Description` TEXT NULL ,
  PRIMARY KEY (`TemplateID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Template_MasterPages`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Template_MasterPages` (
  `Template_MasterPageID` VARCHAR(36) NOT NULL ,
  `TemplateID` VARCHAR(36) NOT NULL ,
  `MasterPage_Template_Name` VARCHAR(250) NOT NULL ,
  `MasterPage_Version` VARCHAR(10) NULL ,
  `MasterPage_URL` VARCHAR(150) NULL ,
  PRIMARY KEY (`Template_MasterPageID`, `TemplateID`) )
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Themes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Themes` (
  `ThemeID` VARCHAR(36) NOT NULL ,
  `TemplateID` VARCHAR(36) NOT NULL ,
  `Theme_Name` VARCHAR(250) NOT NULL ,
  `LanguageCode` VARCHAR(5) NULL ,
  `Theme_Version` VARCHAR(10) NOT NULL ,
  `Theme_Code` VARCHAR(50) NOT NULL ,
  `Release_Date` DATETIME NOT NULL ,
  `Author` VARCHAR(45) NULL ,
  `Description` TEXT NULL ,
  PRIMARY KEY (`ThemeID`, `TemplateID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_PageIndex`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_PageIndex` (
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Parent_PageIndexID` VARCHAR(36) NULL DEFAULT -1 ,
  `Page_CategoryID` INT(10) NULL DEFAULT 1 ,
  `Menu_Title` VARCHAR(100) NULL ,
  `Page_Name` VARCHAR(100) NULL ,
  `Page_Type` ENUM('Normal Page', 'Category', 'Internal Page Pointer', 'External Link') NULL DEFAULT 'Normal Page' ,
  `SortOrder` TINYINT(3) NULL DEFAULT 0 ,
  PRIMARY KEY (`PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Props`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Props` (
  `Page_PropertyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `IsOnMenu` TINYINT(1) NULL DEFAULT 1 ,
  `IsOnNavigator` TINYINT(1) NULL DEFAULT 1 ,
  `IsPrivacy_Inherited` TINYINT(1) NULL DEFAULT 1 ,
  `IsAttribute_Inherited` TINYINT(1) NULL DEFAULT 1 ,
  `IsTemplate_Inherited` TINYINT(1) NULL DEFAULT 1 ,
  `IsSSL` TINYINT(1) NULL DEFAULT 0 ,
  PRIMARY KEY (`Page_PropertyID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Attributes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Attributes` (
  `Page_AttributeID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Page_Title` VARCHAR(100) NULL ,
  `Page_Keyword` VARCHAR(250) NULL ,
  `Page_Description` TEXT NULL ,
  PRIMARY KEY (`Page_AttributeID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Controls`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Controls` (
  `Page_ControlID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageID` VARCHAR(36) NOT NULL ,
  `PlaceHolderID` VARCHAR(100) NOT NULL ,
  `ComponentID` VARCHAR(36) NULL ,
  `SortOrder` TINYINT(3) NULL ,
  PRIMARY KEY (`Page_ControlID`, `PageID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_ExtLinks`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_ExtLinks` (
  `Page_LinkID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Page_URL` TEXT NOT NULL ,
  `Page_Target` VARCHAR(50) NULL ,
  PRIMARY KEY (`Page_LinkID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_IntLinks`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_IntLinks` (
  `Page_LinkID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `PagePointerID` VARCHAR(36) NOT NULL ,
  `Page_Target` VARCHAR(50) NULL ,
  PRIMARY KEY (`Page_LinkID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Categories`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Categories` (
  `Page_CategoryID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Name` VARCHAR(150) NOT NULL ,
  `IsTreeView` TINYINT(1) NULL DEFAULT False ,
  PRIMARY KEY (`Page_CategoryID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Toolbox_Options` (
  `ToolboxID` INT(10) NOT NULL AUTO_INCREMENT ,
  `ModuleID` VARCHAR(36) NULL ,
  `ComponentID` VARCHAR(36) NULL ,
  `Module_Name` VARCHAR(250) NULL ,
  `Component_Name` VARCHAR(200) NULL ,
  `Component_Version` VARCHAR(10) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT true ,
  PRIMARY KEY (`ToolboxID`, `ModuleID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Module_Toolbox_Tools` (
  `ToolID` INT(10) NOT NULL AUTO_INCREMENT ,
  `ComponentID` VARCHAR(36) NOT NULL ,
  `GroupID` VARCHAR(36) NULL ,
  `Tool_Name` VARCHAR(100) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT true ,
  PRIMARY KEY (`ToolID`, `ComponentID`) )
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
-- Table `e2CMS`.`NexusCore_Categories`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Categories` (
  `CategoryID` VARCHAR(36) NOT NULL ,
  `Parent_CategoryID` VARCHAR(36) NULL DEFAULT -1 ,
  `Category_Name` VARCHAR(100) NOT NULL ,
  PRIMARY KEY (`CategoryID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Templates`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Templates` (
  `Page_TemplateID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `MasterPageIndexID` VARCHAR(36) NOT NULL ,
  PRIMARY KEY (`Page_TemplateID`, `PageIndexID`, `MasterPageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Control_Properties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Control_Properties` (
  `Control_PropertyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_ControlID` INT(10) NOT NULL ,
  `Property_Name` VARCHAR(100) NOT NULL ,
  `Property_Value` TEXT NOT NULL ,
  PRIMARY KEY (`Control_PropertyID`, `Page_ControlID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPageIndex`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPageIndex` (
  `MasterPageIndexID` VARCHAR(36) NOT NULL ,
  `MasterPage_Name` VARCHAR(100) NOT NULL ,
  `TemplateID` VARCHAR(36) NOT NULL ,
  `Template_MasterPageID` VARCHAR(36) NOT NULL ,
  `ThemeID` VARCHAR(36) NOT NULL ,
  `MasterPage_Description` VARCHAR(250) NULL ,
  PRIMARY KEY (`MasterPageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPage_Controls`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPage_Controls` (
  `Page_ControlID` INT(10) NOT NULL AUTO_INCREMENT ,
  `MasterPageID` VARCHAR(36) NOT NULL ,
  `PlaceHolderID` VARCHAR(100) NOT NULL ,
  `ComponentID` VARCHAR(36) NOT NULL ,
  `SortOrder` TINYINT(3) NULL DEFAULT 1 ,
  PRIMARY KEY (`Page_ControlID`, `MasterPageID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPage_Control_Properties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPage_Control_Properties` (
  `Control_PropertyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_ControlID` INT(10) NOT NULL ,
  `Property_Name` VARCHAR(100) NOT NULL ,
  `Property_Value` TEXT NOT NULL ,
  PRIMARY KEY (`Control_PropertyID`, `Page_ControlID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Template_MasterPage_Controls`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Template_MasterPage_Controls` (
  `ControlID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Template_MasterPageID` VARCHAR(36) NOT NULL ,
  `PlaceHolderID` VARCHAR(100) NOT NULL ,
  `MinWidth` INT(5) NULL DEFAULT 10 ,
  `MinHeight` INT(5) NULL DEFAULT 10 ,
  `Width` INT(5) NULL DEFAULT 10 ,
  `Height` INT(5) NULL DEFAULT 10 ,
  `Orientation` ENUM('Vertical', 'Horizontal') NULL DEFAULT 'Vertical' ,
  PRIMARY KEY (`ControlID`, `Template_MasterPageID`) )
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Locks`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Locks` (
  `Page_LockID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Parent_PageIndexID` VARCHAR(36) NULL ,
  `PageID` VARCHAR(36) NULL ,
  `Page_CategoryID` INT(10) NULL ,
  `Page_Name` VARCHAR(100) NULL ,
  `Page_Type` ENUM('Normal Page', 'Category', 'Internal Page Pointer', 'External Link') NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `LockDate` DATETIME NOT NULL ,
  `IsDirty` TINYINT(1) NULL DEFAULT False ,
  `DockState` TEXT NULL ,
  PRIMARY KEY (`Page_LockID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Lock_Control_Properties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Lock_Control_Properties` (
  `Control_PropertyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_ControlID` INT(10) NOT NULL ,
  `Property_Name` VARCHAR(100) NOT NULL ,
  `Property_Value` TEXT NOT NULL ,
  PRIMARY KEY (`Control_PropertyID`, `Page_ControlID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Lock_Controls`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Lock_Controls` (
  `Page_ControlID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_LockID` INT(10) NOT NULL ,
  `PlaceHolderID` VARCHAR(100) NOT NULL ,
  `ComponentID` VARCHAR(36) NULL ,
  `SortOrder` TINYINT(3) NULL ,
  `IsDirty` TINYINT(1) NULL DEFAULT False ,
  PRIMARY KEY (`Page_ControlID`, `Page_LockID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_StartMenu`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_StartMenu` (
  `StartMenuID` INT(10) NOT NULL ,
  `ModuleID` VARCHAR(36) NULL ,
  `ComponentID` VARCHAR(36) NULL ,
  `Module_Name` VARCHAR(250) NULL ,
  `SortOrder` TINYINT(3) NULL ,
  PRIMARY KEY (`StartMenuID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Lock_Templates`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Lock_Templates` (
  `Page_TemplateID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_LockID` INT(10) NOT NULL ,
  `MasterPageIndexID` VARCHAR(36) NOT NULL ,
  `IsTemplate_Inherited` TINYINT(1) NULL ,
  `Original_MasterPageIndexID` VARCHAR(36) NULL ,
  PRIMARY KEY (`Page_TemplateID`, `Page_LockID`, `MasterPageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Lock_Attributes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Lock_Attributes` (
  `Page_AttributeID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_LockID` INT(10) NOT NULL ,
  `Page_Title` VARCHAR(100) NULL ,
  `Page_Keyword` VARCHAR(250) NULL ,
  `Page_Description` TEXT NULL ,
  PRIMARY KEY (`Page_AttributeID`, `Page_LockID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Phrases`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Phrases` (
  `PhraseID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Language` VARCHAR(45) NULL DEFAULT '0' ,
  `VarName` VARCHAR(50) NOT NULL ,
  `FieldName` VARCHAR(50) NULL ,
  `PhraseName` TEXT NULL ,
  `PhraseValue` TEXT NULL ,
  `SortOrder` TINYINT(3) NULL DEFAULT 0 ,
  `ModuleID` VARCHAR(36) NOT NULL ,
  PRIMARY KEY (`PhraseID`, `VarName`, `ModuleID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPage_Locks`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPage_Locks` (
  `MasterPage_LockID` INT(10) NOT NULL AUTO_INCREMENT ,
  `MasterPageIndexID` VARCHAR(36) NOT NULL ,
  `MasterPage_Name` VARCHAR(100) NULL ,
  `MasterPageID` VARCHAR(36) NULL ,
  `TemplateID` VARCHAR(36) NULL ,
  `Template_MasterPageID` VARCHAR(36) NULL ,
  `ThemeID` VARCHAR(36) NULL ,
  `MasterPage_Description` VARCHAR(250) NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `LockDate` DATETIME NULL ,
  `IsDirty` TINYINT(1) NULL DEFAULT False ,
  `DockState` TEXT NULL ,
  PRIMARY KEY (`MasterPage_LockID`, `MasterPageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPage_Lock_Controls`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPage_Lock_Controls` (
  `Page_ControlID` INT(10) NOT NULL AUTO_INCREMENT ,
  `MasterPage_LockID` INT(10) NOT NULL ,
  `PlaceHolderID` VARCHAR(100) NOT NULL ,
  `ComponentID` VARCHAR(36) NULL ,
  `SortOrder` TINYINT(3) NULL ,
  `IsDirty` TINYINT(1) NULL DEFAULT False ,
  PRIMARY KEY (`Page_ControlID`, `MasterPage_LockID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPage_Lock_Control_Properties`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPage_Lock_Control_Properties` (
  `Control_PropertyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Page_ControlID` INT(10) NOT NULL ,
  `Property_Name` VARCHAR(100) NOT NULL ,
  `Property_Value` TEXT NOT NULL ,
  PRIMARY KEY (`Control_PropertyID`, `Page_ControlID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_Privacies`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_Privacies` (
  `PrivacyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `UserGroupID` VARCHAR(36) NOT NULL ,
  `Allow_View` TINYINT(1) NOT NULL DEFAULT 1 ,
  `Allow_Create` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_Modify` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_Delete` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_Rollback` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_ChangePermissions` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_Approve` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_Publish` TINYINT(1) NOT NULL DEFAULT 0 ,
  `Allow_DesignMode` TINYINT(1) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`PrivacyID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_PrivacyURL`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_PrivacyURL` (
  `PrivacyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `ReturnURL` TEXT NOT NULL ,
  PRIMARY KEY (`PrivacyID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_ComponentInCategories`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_ComponentInCategories` (
  `RelationID` INT(20) NOT NULL AUTO_INCREMENT ,
  `ModuleID` VARCHAR(36) NOT NULL ,
  `Module_ItemID` VARCHAR(36) NOT NULL ,
  `CategoryID` VARCHAR(36) NOT NULL ,
  `Item_Count` INT(10) NULL DEFAULT 0 ,
  PRIMARY KEY (`RelationID`, `ModuleID`, `Module_ItemID`, `CategoryID`) )
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


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Pages`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Pages` (
  `PageID` VARCHAR(36) NOT NULL ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Page_Version` TINYINT(3) NULL DEFAULT 1 ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT 0 ,
  `IsDelete` TINYINT(1) NULL DEFAULT 0 ,
  PRIMARY KEY (`PageID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPages`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPages` (
  `MasterPageID` VARCHAR(36) NOT NULL ,
  `MasterPageIndexID` VARCHAR(36) NOT NULL ,
  `MasterPage_Version` TINYINT(3) NULL DEFAULT 1 ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT 0 ,
  `IsDelete` TINYINT(1) NULL DEFAULT 0 ,
  PRIMARY KEY (`MasterPageID`, `MasterPageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_Page_MetaTags`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Page_MetaTags` (
  `MetaTagID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Meta_Type` ENUM('JavaScript', 'StyleSheet') NOT NULL ,
  `Meta_Src` TEXT NOT NULL ,
  PRIMARY KEY (`MetaTagID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_MasterPage_MetaTags`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_MasterPage_MetaTags` (
  `MetaTagID` INT(10) NOT NULL AUTO_INCREMENT ,
  `MasterPageIndexID` VARCHAR(36) NOT NULL ,
  `Meta_Type` ENUM('JavaScript', 'StyleSheet') NOT NULL ,
  `Meta_Src` TEXT NOT NULL ,
  PRIMARY KEY (`MetaTagID`, `MasterPageIndexID`) )
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_PageTags`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_PageTags` (
  `PageTagID` VARCHAR(36) NOT NULL ,
  `Tag_Name` VARCHAR(400) NOT NULL ,
  PRIMARY KEY (`PageTagID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_ComponentInTags`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_ComponentInTags` (
  `RelationID` INT(20) NOT NULL ,
  `ModuleID` VARCHAR(36) NOT NULL ,
  `Module_ItemID` VARCHAR(36) NOT NULL ,
  `PageTagID` VARCHAR(36) NOT NULL ,
  `Item_Count` INT(10) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`RelationID`, `ModuleID`, `Module_ItemID`, `PageTagID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusCore_PageTag_Mapping`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_PageTag_Mapping` (
  `PageTag_MappingID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `PageTagID` VARCHAR(36) NOT NULL ,
  `IsFeatured` TINYINT(1) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`PageTag_MappingID`, `PageIndexID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Step02_1 Framework Data
-- -----------------------------------------------------

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Props`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Props` (`Page_PropertyID`, `PageIndexID`, `IsOnMenu`, `IsOnNavigator`, `IsPrivacy_Inherited`, `IsAttribute_Inherited`, `IsTemplate_Inherited`, `IsSSL`) VALUES (1, '-1', 1, 0, 0, 0, 0, 0);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Attributes`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Attributes` (`Page_AttributeID`, `PageIndexID`, `Page_Title`, `Page_Keyword`, `Page_Description`) VALUES (1, '-1', '', '', '');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Categories`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (1, 'Lived Pages', True);
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (2, 'Inactived Pages', True);
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (3, 'Drafts', False);
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (4, 'Deleted Pages', False);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Categories`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Categories` (`CategoryID`, `Parent_CategoryID`, `Category_Name`) VALUES ('73B48270-1307-4A74-89E5-52143E82B9A9', '-1', 'Uncategorized');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Templates`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Templates` (`Page_TemplateID`, `PageIndexID`, `MasterPageIndexID`) VALUES (1, '-1', '82C9EF99930741CCB76E1B4D4A77D0D9');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Privacies`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Privacies` (`PrivacyID`, `PageIndexID`, `UserGroupID`, `Allow_View`, `Allow_Create`, `Allow_Modify`, `Allow_Delete`, `Allow_Rollback`, `Allow_ChangePermissions`, `Allow_Approve`, `Allow_Publish`, `Allow_DesignMode`) VALUES (1, '-1', 'B117D66E-3A2F-45b9-8329-2119426F9311', 1, 1, 1, 1, 1, 1, 1, 1, 1);
INSERT INTO `NexusCore_Page_Privacies` (`PrivacyID`, `PageIndexID`, `UserGroupID`, `Allow_View`, `Allow_Create`, `Allow_Modify`, `Allow_Delete`, `Allow_Rollback`, `Allow_ChangePermissions`, `Allow_Approve`, `Allow_Publish`, `Allow_DesignMode`) VALUES (2, '-1', '522BF6CC-7095-4e38-82F0-B21A0CD85255', 1, 0, 0, 0, 0, 0, 0, 0, 0);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_PrivacyURL`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_PrivacyURL` (`PrivacyID`, `PageIndexID`, `ReturnURL`) VALUES (1, '-1', '/');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_MetaTags`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_MetaTags` (`MetaTagID`, `PageIndexID`, `Meta_Type`, `Meta_Src`) VALUES (1, '-1', 'JavaScript', '/App_Themes/NexusCore/Scripts/jquery-1.6.2.js');
INSERT INTO `NexusCore_Page_MetaTags` (`MetaTagID`, `PageIndexID`, `Meta_Type`, `Meta_Src`) VALUES (2, '-1', 'StyleSheet', '~/App_Themes/NexusCore/PageEditor_ToolBar.css');
INSERT INTO `NexusCore_Page_MetaTags` (`MetaTagID`, `PageIndexID`, `Meta_Type`, `Meta_Src`) VALUES (3, '-1', 'StyleSheet', '~/App_Themes/NexusCore/PageEditor_ToolPanel.css');

COMMIT;

-- -----------------------------------------------------
-- Step02_2 Phrase Data
-- -----------------------------------------------------

-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.9


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema e2cms
--

CREATE DATABASE IF NOT EXISTS e2cms;
USE e2cms;

--
-- Dumping data for table `nexuscore_phrases`
--

/*!40000 ALTER TABLE `nexuscore_phrases` DISABLE KEYS */;
INSERT INTO `nexuscore_phrases` (`Language`,`VarName`,`FieldName`,`PhraseName`,`PhraseValue`,`SortOrder`,`ModuleID`) VALUES 
 ('0','NexusCore_HomepageID','NexusCore setting',NULL,'0BB9B04795A54871851FC6181936E1C9',0,'NexusCore'),
 ('0','NexusCore_HomeSwitch','NexusCore setting',NULL,'True',0,'NexusCore'), 
 ('0','NexusCore_Version','NexusCore setting',NULL,'1.0.9',0,'NexusCore'),  
 ('0','NexusCore_Email_MailFrom_Default','Email setting',NULL,'service@e2tech.co.uk',0,'NexusCore'),
 ('0','NexusCore_Email_SMTP','Email setting',NULL,'localhost',0,'NexusCore'),
 ('0','NexusCore_File_All_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_All_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_All_Types','NexusCore Files setting',NULL,'*.*',0,'NexusCore'),
 ('0','NexusCore_File_All_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_All_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Documents_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Documents_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Documents_Types','NexusCore Files setting',NULL,'*.doc,*.docx,*.pdf',0,'NexusCore'),
 ('0','NexusCore_File_Documents_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Documents_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Image_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Image_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Image_Types','NexusCore Files setting',NULL,'*.gif,*.jpg,*.jpeg,*.png',0,'NexusCore'),
 ('0','NexusCore_File_Image_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Image_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Media_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Media_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Media_Types','NexusCore Files setting',NULL,'*.swf',0,'NexusCore'),
 ('0','NexusCore_File_Media_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Media_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Templates_DeletePaths','NexusCore Files setting',NULL,'~/App_Template,~/App_Themes',0,'NexusCore'),
 ('0','NexusCore_File_Templates_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Templates_Types','NexusCore Files setting',NULL,'*.*',0,'NexusCore'),
 ('0','NexusCore_File_Templates_UploadPaths','NexusCore Files setting',NULL,'~/App_Template,~/App_Themes',0,'NexusCore'),
 ('0','NexusCore_File_Templates_ViewPaths','NexusCore Files setting',NULL,'~/App_Template,~/App_Themes',0,'NexusCore'),
 ('0','NexusCore_File_ControlTemplates_DeletePaths','NexusCore Files setting',NULL,'~/App_Control_Style,~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_ControlTemplates_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_ControlTemplates_Types','NexusCore Files setting',NULL,'*.ascx',0,'NexusCore'),
 ('0','NexusCore_File_ControlTemplates_UploadPaths','NexusCore Files setting',NULL,'~/App_Control_Style,~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_ControlTemplates_ViewPaths','NexusCore Files setting',NULL,'~/App_Control_Style,~/User_Files',0,'NexusCore'), 
 ('0','NexusCore_LivePage_ToolBar','javascript',NULL,'$(document).ready(function(){\r\n	$(\".nexusCore_toolPanel_trigger\").click(function(){\r\n		$(\".nexusCore_slidingOut_toolPanel\").toggle(\"fast\");\r\n		$(this).toggleClass(\"active\");\r\n		return false;\r\n	});\r\n});',0,'NexusCore'),
 ('0','NexusCore_PageEditor_Dock','javascript','','		var $T = Telerik.Web.UI;\r\n		Telerik.Web.UI.RadTreeView.prototype._onDocumentMouseUp = function (e)\r\n		{\r\n			this._detachDragDropEvents();\r\n\r\n			if (!this._dragging)\r\n			{\r\n				this._initialDragMousePos = null;\r\n				this._initialDragNode = null;\r\n				return;\r\n			}\r\n\r\n			var sourceNodes = this._sourceDragNodes;\r\n\r\n			var destinationNode = null;\r\n			if (e.target == this._dropClue)\r\n			{\r\n				// If the event has hit the DropClue we take the node it is attached to\r\n				destinationNode = this._dropClue.treeNode;\r\n			}\r\n			else\r\n			{\r\n				destinationNode = this._extractNodeFromDomElement(e.target);\r\n			}\r\n\r\n			if (destinationNode)\r\n			{\r\n				if (destinationNode._isDescendantOf(this._initialDragNode) || this._initialDragNode == destinationNode)\r\n				{\r\n					this._clearDrag();\r\n					return;\r\n				}\r\n			}\r\n\r\n			var htmlElement = e.target;\r\n\r\n			var eventArgs = new $T.RadTreeNodeDroppingEventArgs(sourceNodes, destinationNode, htmlElement, this._draggingPosition, e);\r\n			this.raiseEvent(\"nodeDropping\", eventArgs);\r\n			if (eventArgs.get_cancel())\r\n			{\r\n				this._clearDrag();\r\n				return;\r\n			}\r\n\r\n			var htmlElement = eventArgs.get_htmlElement();\r\n			var command = this._getDropCommand(destinationNode, sourceNodes, htmlElement);\r\n\r\n			if (command.commandName)\r\n			{\r\n				var eventArgs = new $T.RadTreeNodeDroppedEventArgs(sourceNodes, e);\r\n				this.raiseEvent(\"nodeDropped\", eventArgs);\r\n				this._postback(command);\r\n			}\r\n\r\n			this._clearDrag();\r\n		}\r\n\r\n		var isNodeDragged = false;\r\n		//parameter can be dock or treeNode\r\n		Telerik.Web.UI.RadDockZone.prototype._showPlaceholder = function (obj, location)\r\n		{\r\n			if (Object.getTypeName(obj) == \"Telerik.Web.UI.RadTreeNode\")\r\n			{\r\n				isNodeDragged = true;\r\n				var node = obj;\r\n				this._repositionPlaceholder(node.get_element(), location);\r\n				var placeholderStyle = this._placeholder.style;\r\n				placeholderStyle.height = \"50px\";\r\n				placeholderStyle.width = \"100%\";\r\n				placeholderStyle.display = \"block\";\r\n				//placeholderStyle.backgroundColor = \"Red\";\r\n				isNodeDragged = false;\r\n			}\r\n			else\r\n			{\r\n				var dock = obj;\r\n				this._repositionPlaceholder(dock.get_element(), location);\r\n				var dockBounds = dock._getBounds();\r\n				var placeholderMargin = dock._getMarginBox(this._placeholder);\r\n				var placeholderBorder = dock._getBorderBox(this._placeholder);\r\n				var horizontal = this.get_isHorizontal();\r\n				var placeholderStyle = this._placeholder.style;\r\n				placeholderStyle.height = dockBounds.height - (placeholderMargin.vertical + placeholderBorder.vertical) + \"px\";\r\n				placeholderStyle.width = this.get_fitDocks() && !horizontal ? \"100%\" : dockBounds.width - (placeholderMargin.horizontal + placeholderBorder.horizontal) + \"px\";\r\n				placeholderStyle.display = \"block\";\r\n			}\r\n		}\r\n\r\n		Telerik.Web.UI.RadDockZone.prototype._repositionPlaceholder = function (dock_element, location)\r\n		{\r\n			//fix TreeNode drag   \r\n			if (isNodeDragged == true)\r\n			{\r\n				location = new Sys.UI.Point(currentTreeView._mousePos.x, currentTreeView._mousePos.y);\r\n			}\r\n			//end fix   \r\n\r\n			var nearestChild = this._findItemAt(location, dock_element);\r\n\r\n			var zone_element = this.get_element();\r\n\r\n			if (null == nearestChild)\r\n			{\r\n				// _clearElement must be after all docks and _placeholder\r\n				zone_element.insertBefore(this._placeholder, this._clearElement);\r\n			}\r\n			else\r\n			{\r\n				if (nearestChild.previousSibling != this._placeholder)\r\n				{\r\n					zone_element.insertBefore(this._placeholder, nearestChild);\r\n				}\r\n			}\r\n			//GET placeholder position   \r\n			for (var i = 0; i < zone_element.childNodes.length; i++)\r\n			{\r\n				if (zone_element.childNodes[i] == this._placeholder)\r\n				{\r\n					var currentPos = i;\r\n                    var diff = 0;\r\n                    if (!navigator.appName.match(\"Microsoft Internet Explorer\")) {\r\n                        diff++;\r\n                    }\r\n					document.title = currentPos - diff;\r\n					$get(\'ctl00_currentPlaceholderPosition\').value = currentPos - diff;\r\n				}\r\n			}\r\n			//end Get \r\n		}         \r\n      ',0,'NexusCore'),
 ('0','NexusCore_PageEditor_PoPWindow','javascript','','            function Show_ControlManager(paraCommand) {\r\n                var oWnd = window.radopen(paraCommand, \'RadWindow_ControlManager\');\r\n                oWnd.add_close(OnClientClose);\r\n            }\r\n  \r\n            function OnClientClose(oWnd) {\r\n                oWnd.setUrl(\'about:blank\'); // Sets url to blank \r\n                oWnd.remove_close(OnClientClose); //remove the close handler - it will be set again on the next opening \r\n            }\r\n\r\n            function refreshControl(arg) {\r\n            $find(\'ctl00_RadAjaxManager_ControlManger\').ajaxRequest(arg);\r\n            }',0,'NexusCore');
/*!40000 ALTER TABLE `nexuscore_phrases` ENABLE KEYS */;

-- -----------------------------------------------------
-- Step03 Users
-- -----------------------------------------------------

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusUser_Users`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_Users` (
  `UserID` VARCHAR(36) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `Email` VARCHAR(150) NOT NULL ,
  `UserPass` VARCHAR(40) NOT NULL ,
  `CreateDate` DATETIME NULL ,
  `CreateIPaddress` VARCHAR(40) NULL ,
  `LastLoginDate` DATETIME NULL ,
  `LastPasswordChangedDate` DATETIME NULL ,
  `FailedPassAttemptCount` TINYINT(3) NULL ,
  `IsLockedOut` TINYINT(1) NULL DEFAULT 0 ,
  `DeleteMark` TINYINT(1) NULL DEFAULT 0 ,
  `Activation_Code` VARCHAR(36) NULL ,
  PRIMARY KEY (`UserID`, `Email`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusUser_UserGroups`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_UserGroups` (
  `UserGroupID` VARCHAR(36) NOT NULL ,
  `UserGroup_Name` VARCHAR(50) NOT NULL ,
  `SortOrder` TINYINT(3) NULL DEFAULT 1 ,
  `Description` VARCHAR(250) NULL ,
  `IsSystemGroup` TINYINT(1) NULL DEFAULT 0 ,
  PRIMARY KEY (`UserGroupID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusUser_UserInGroups`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_UserInGroups` (
  `RelationID` INT(20) NOT NULL AUTO_INCREMENT ,
  `UserID` VARCHAR(36) NOT NULL ,
  `UserGroupID` VARCHAR(36) NOT NULL ,
  PRIMARY KEY (`RelationID`, `UserID`, `UserGroupID`) )
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Step04_1 Users Data
-- -----------------------------------------------------

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusUser_UserGroups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('522BF6CC-7095-4e38-82F0-B21A0CD85255', 'Guests', 1, 'as know as everyone', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('9C3C4A1F-1F78-4946-9D79-F4D247072C54', 'Registered Users', 2, 'Normal User', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('30E245C7-9D7F-4649-911C-CC6313076830', 'Users Awaiting Email Confirmation', 3, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('2DF310C3-81C5-4087-9CEC-3F1803AB1213', 'Users Awaiting Moderation', 4, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('70039070-F69E-431b-9B05-46756BC65636', 'Super Moderators', 5, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('B117D66E-3A2F-45b9-8329-2119426F9311', 'Administrators', 6, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('5DACAE1C-32B9-4c16-983B-13CD74B7EB64', 'Moderators', 7, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('8C361793-7A9E-4a6c-BEF8-ACCBDB6A1931', 'System AI', 8, '', 1);

COMMIT;

-- -----------------------------------------------------
-- Step05_1 Views of Framework
-- -----------------------------------------------------

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_NexusCore_PageIndex_Menu`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusCore_PageIndex_Menu` (`PageIndexID` INT, `Parent_PageIndexID` INT, `Page_CategoryID` INT, `Menu_Title` INT, `Page_Name` INT, `Page_Type` INT, `SortOrder` INT, `ChildrenCount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount` (`Parent_PageIndexID` INT, `ChildrenCount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`view_Template_Masterpage_DropList`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`view_Template_Masterpage_DropList` (`MasterPageIndexID` INT, `MasterPage_Name` INT, `MasterPage_Description` INT, `Theme_Code` INT, `MasterPage_Template_Name` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`view_Template_Masterpage_Count`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`view_Template_Masterpage_Count` (`MasterPageIndexID` INT, `UsageCount` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`view_Template_Masterpage_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`view_Template_Masterpage_List` (`MasterPageIndexID` INT, `MasterPage_Name` INT, `TemplateID` INT, `Template_MasterPageID` INT, `MasterPage_Template_Name` INT, `ThemeID` INT, `Theme_Name` INT, `Theme_Code` INT, `MasterPage_Version` INT, `MasterPage_Description` INT, `UsageCounts` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_NexusCore_PageIndex_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusCore_PageIndex_List` (`PageIndexID` INT, `Parent_PageIndexID` INT, `Page_CategoryID` INT, `Menu_Title` INT, `Page_Name` INT, `Page_Type` INT, `SortOrder` INT, `ChildrenCount` INT, `IsOnMenu` INT, `IsOnNavigator` INT, `IsPrivacy_Inherited` INT, `IsAttribute_Inherited` INT, `IsTemplate_Inherited` INT, `IsSSL` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_Template_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_Template_List` (`TemplateID` INT, `Template_MasterPageID` INT, `ThemeID` INT, `MasterPage_Template_Name` INT, `MasterPage_Version` INT, `Theme_Name` INT, `Theme_Code` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_NexusCore_Page_Privacy_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusCore_Page_Privacy_List` (`PrivacyID` INT, `PageIndexID` INT, `UserGroupID` INT, `UserGroup_Name` INT, `UserGroup_Description` INT, `Allow_View` INT, `Allow_Create` INT, `Allow_Modify` INT, `Allow_Delete` INT, `Allow_Rollback` INT, `Allow_ChangePermissions` INT, `Allow_Approve` INT, `Allow_Publish` INT, `Allow_DesignMode` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_NexusCore_ComponentInCategory_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusCore_ComponentInCategory_List` (`RelationID` INT, `CategoryID` INT, `Parent_CategoryID` INT, `Category_Name` INT, `ModuleID` INT, `Module_Name` INT, `Module_ItemID` INT, `Item_Name` INT, `Item_Count` INT);

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_PageIndex_Menu`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_PageIndex_Menu`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_PageIndex_Menu` AS SELECT nexuscore_pageindex.PageIndexID, nexuscore_pageindex.Parent_PageIndexID, nexuscore_pageindex.Page_CategoryID, nexuscore_pageindex.Menu_Title, nexuscore_pageindex.Page_Name, nexuscore_pageindex.Page_Type, nexuscore_pageindex.SortOrder, IF(ChildrenCount IS NOT NULL, ChildrenCount, 0) AS ChildrenCount
FROM nexuscore_pageindex LEFT JOIN View_NexusCore_PageIndex_ChildrenCount AS nexuscore_pageindex_parent ON nexuscore_pageindex.PageIndexID = nexuscore_pageindex_parent.Parent_PageIndexID;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount` AS SELECT nexuscore_pageindex.Parent_PageIndexID, Count(*) As ChildrenCount FROM nexuscore_pageindex Group By (Parent_PageIndexID);

-- -----------------------------------------------------
-- View `e2CMS`.`view_Template_Masterpage_DropList`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_Template_Masterpage_DropList`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_Template_Masterpage_DropList` AS SELECT nexuscore_masterpageindex.MasterPageIndexID, nexuscore_masterpageindex.MasterPage_Name, nexuscore_masterpageindex.MasterPage_Description, nexuscore_themes.Theme_Code, nexuscore_template_masterpages.MasterPage_Template_Name
FROM nexuscore_themes INNER JOIN (nexuscore_template_masterpages INNER JOIN nexuscore_masterpageindex ON nexuscore_template_masterpages.Template_MasterPageID=nexuscore_masterpageindex.Template_MasterPageID) ON nexuscore_themes.ThemeID=nexuscore_masterpageindex.ThemeID;

-- -----------------------------------------------------
-- View `e2CMS`.`view_Template_Masterpage_Count`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_Template_Masterpage_Count`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_Template_Masterpage_Count` AS SELECT nexuscore_page_templates.MasterPageIndexID, Count(nexuscore_page_templates.PageIndexID) AS UsageCount
FROM nexuscore_page_templates
GROUP BY nexuscore_page_templates.MasterPageIndexID;

-- -----------------------------------------------------
-- View `e2CMS`.`view_Template_Masterpage_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_Template_Masterpage_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_Template_Masterpage_List` AS SELECT nexuscore_masterpageindex.MasterPageIndexID, nexuscore_masterpageindex.MasterPage_Name, nexuscore_template_masterpages.TemplateID, nexuscore_template_masterpages.Template_MasterPageID, nexuscore_template_masterpages.MasterPage_Template_Name, nexuscore_masterpageindex.ThemeID, nexuscore_themes.Theme_Name, nexuscore_themes.Theme_Code, nexuscore_template_masterpages.MasterPage_Version, nexuscore_masterpageindex.MasterPage_Description, IFNULL(UsageCount,0) AS UsageCounts
FROM (nexuscore_themes INNER JOIN (nexuscore_template_masterpages INNER JOIN nexuscore_masterpageindex ON nexuscore_template_masterpages.Template_MasterPageID = nexuscore_masterpageindex.Template_MasterPageID) ON nexuscore_themes.ThemeID = nexuscore_masterpageindex.ThemeID) LEFT JOIN View_Template_MasterPage_Count ON nexuscore_masterpageindex.MasterPageIndexID = View_Template_MasterPage_Count.MasterPageIndexID;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_PageIndex_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_PageIndex_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_PageIndex_List` AS SELECT nexuscore_pageindex.PageIndexID, nexuscore_pageindex.Parent_PageIndexID, nexuscore_pageindex.Page_CategoryID, nexuscore_pageindex.Menu_Title, nexuscore_pageindex.Page_Name, nexuscore_pageindex.Page_Type, nexuscore_pageindex.SortOrder, IF(ChildrenCount Is Not Null,ChildrenCount,0) AS ChildrenCount, nexuscore_page_props.IsOnMenu, nexuscore_page_props.IsOnNavigator, nexuscore_page_props.IsPrivacy_Inherited, nexuscore_page_props.IsAttribute_Inherited, nexuscore_page_props.IsTemplate_Inherited, nexuscore_page_props.IsSSL
FROM (nexuscore_pageindex LEFT JOIN View_NexusCore_PageIndex_ChildrenCount AS nexuscore_pageindex_parent ON nexuscore_pageindex.PageIndexID = nexuscore_pageindex_parent.Parent_PageIndexID) INNER JOIN nexuscore_page_props ON nexuscore_pageindex.PageIndexID = nexuscore_page_props.PageIndexID;

-- -----------------------------------------------------
-- View `e2CMS`.`View_Template_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_Template_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_Template_List` AS SELECT nexuscore_templates.TemplateID, nexuscore_template_masterpages.Template_MasterPageID, nexuscore_themes.ThemeID, nexuscore_template_masterpages.MasterPage_Template_Name, nexuscore_template_masterpages.MasterPage_Version, nexuscore_themes.Theme_Name, nexuscore_themes.Theme_Code
FROM (nexuscore_templates INNER JOIN nexuscore_template_masterpages ON nexuscore_templates.TemplateID = nexuscore_template_masterpages.TemplateID) INNER JOIN nexuscore_themes ON nexuscore_templates.TemplateID = nexuscore_themes.TemplateID;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_Page_Privacy_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_Page_Privacy_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_Page_Privacy_List` AS SELECT nexuscore_page_privacies.PrivacyID, nexuscore_page_privacies.PageIndexID, nexuscore_page_privacies.UserGroupID, nexususer_usergroups.UserGroup_Name, nexususer_usergroups.Description AS UserGroup_Description, nexuscore_page_privacies.Allow_View, nexuscore_page_privacies.Allow_Create, nexuscore_page_privacies.Allow_Modify, nexuscore_page_privacies.Allow_Delete, nexuscore_page_privacies.Allow_Rollback, nexuscore_page_privacies.Allow_ChangePermissions, nexuscore_page_privacies.Allow_Approve, nexuscore_page_privacies.Allow_Publish, nexuscore_page_privacies.Allow_DesignMode
FROM nexuscore_page_privacies INNER JOIN nexususer_usergroups ON nexuscore_page_privacies.UserGroupID = nexususer_usergroups.UserGroupID;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_ComponentInCategory_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_ComponentInCategory_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_ComponentInCategory_List` AS SELECT nexuscore_componentincategories.RelationID, nexuscore_categories.CategoryID, nexuscore_categories.Parent_CategoryID, nexuscore_categories.Category_Name, nexuscore_modules.ModuleID, nexuscore_modules.Module_Name, nexuscore_module_items.Module_ItemID, nexuscore_module_items.Item_Name, nexuscore_componentincategories.Item_Count
FROM nexuscore_module_items INNER JOIN (nexuscore_modules INNER JOIN (nexuscore_categories INNER JOIN nexuscore_componentincategories ON nexuscore_categories.CategoryID = nexuscore_componentincategories.CategoryID) ON nexuscore_modules.ModuleID = nexuscore_componentincategories.ModuleID) ON nexuscore_module_items.Module_ItemID = nexuscore_componentincategories.Module_ItemID;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
