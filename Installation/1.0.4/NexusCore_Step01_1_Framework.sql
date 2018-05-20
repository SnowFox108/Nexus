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
  `Page_LinkID` INT(10) NOT NULL ,
  `PageIndexID` VARCHAR(36) NOT NULL ,
  `Page_URL` TEXT NOT NULL ,
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
  `UserID` INT(10) NOT NULL ,
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
  `UserID` INT(10) NULL ,
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
  `LastUpdate_UserID` INT(10) NULL ,
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
  `LastUpdate_UserID` INT(10) NULL ,
  `IsActive` TINYINT(1) NULL DEFAULT 0 ,
  `IsDelete` TINYINT(1) NULL DEFAULT 0 ,
  PRIMARY KEY (`MasterPageID`, `MasterPageIndexID`) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
