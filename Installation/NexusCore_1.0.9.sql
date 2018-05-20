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
-- Table `e2CMS`.`NexusCore_Installation_Logs`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Installation_Logs` (
  `LogID` INT(10) NOT NULL AUTO_INCREMENT ,
  `InstallID` VARCHAR(36) NULL ,
  `Name` VARCHAR(45) NULL ,
  `Install_Type` ENUM('Module','Component','Template','Theme') NULL ,
  `Action_Name` VARCHAR(45) NULL ,
  `Action_Type` ENUM('Install', 'Upgrade', 'Uninstall') NULL ,
  `Action_UserID` VARCHAR(36) NOT NULL ,
  `Result` VARCHAR(45) NULL ,
  `Action_Date` DATETIME NULL ,
  PRIMARY KEY (`LogID`) )
ENGINE = InnoDB;


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
-- Table `e2CMS`.`NexusUser_Archives`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_Archives` (
  `ArchiveID` INT(10) NOT NULL AUTO_INCREMENT ,
  `UserID` VARCHAR(36) NOT NULL ,
  `Title` VARCHAR(20) NULL ,
  `FirstName` VARCHAR(20) NULL ,
  `LastName` VARCHAR(20) NULL ,
  `Gender` VARCHAR(6) NULL ,
  `DateOfBirth` DATE NULL ,
  `Country` VARCHAR(20) NULL ,
  `Phone` VARCHAR(40) NULL ,
  `Phone_Option` VARCHAR(40) NULL ,
  `HowYouFindUsID` INT(10) NULL ,
  `HowYouFindUs` VARCHAR(100) NULL ,
  PRIMARY KEY (`ArchiveID`, `UserID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusUser_Address`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_Address` (
  `UserAddID` INT(10) NOT NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `AddressType` VARCHAR(45) NULL ,
  `AddressLine1` VARCHAR(250) NULL ,
  `AddressLine2` VARCHAR(250) NULL ,
  `City` VARCHAR(20) NULL ,
  `PostalCode` VARCHAR(10) NULL ,
  `Country` VARCHAR(20) NULL ,
  `SortOrder` TINYINT(3) NULL ,
  `CreateDate` DATETIME NULL ,
  `LastUpdateDate` DATETIME NULL ,
  PRIMARY KEY (`UserAddID`, `UserID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusUser_HowYouFindUs`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_HowYouFindUs` (
  `HowYouFindUsID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Details` VARCHAR(45) NOT NULL ,
  `SortOrder` TINYINT(3) NULL DEFAULT 1 ,
  `IsActive` TINYINT(1) NULL DEFAULT 1 ,
  PRIMARY KEY (`HowYouFindUsID`) )
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
-- Table `e2CMS`.`NexusGeneral_HTML`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusGeneral_HTML` (
  `HTMLID` VARCHAR(36) NOT NULL ,
  `CategoryID` VARCHAR(36) NULL ,
  `Display_Name` VARCHAR(150) NULL ,
  `HTML_Content` TEXT NULL ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  PRIMARY KEY (`HTMLID`) )
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
-- Table `e2CMS`.`NexusGeneral_Scripts`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusGeneral_Scripts` (
  `ScriptID` VARCHAR(36) NOT NULL ,
  `CategoryID` VARCHAR(36) NULL ,
  `Display_Name` VARCHAR(150) NULL ,
  `Script_Type` ENUM('text/javascript', 'text/jscript', 'text/vbscript') NULL ,
  `Script_Content` TEXT NULL ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  PRIMARY KEY (`ScriptID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusGeneral_RichTexts`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusGeneral_RichTexts` (
  `RichTextID` VARCHAR(36) NOT NULL ,
  `CategoryID` VARCHAR(36) NULL ,
  `Display_Name` VARCHAR(150) NULL ,
  `RichText_Content` TEXT NULL ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` INT(10) NULL ,
  PRIMARY KEY (`RichTextID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusGeneral_Images`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusGeneral_Images` (
  `ImageID` VARCHAR(36) NOT NULL ,
  `CategoryID` VARCHAR(36) NULL ,
  `Display_Name` VARCHAR(150) NULL ,
  `ImageURL` VARCHAR(250) NULL ,
  `ImageURL_Type` ENUM('Internal', 'External') NULL ,
  `AlternateText` VARCHAR(150) NULL ,
  `LinkURL` VARCHAR(250) NULL ,
  `Link_Target` VARCHAR(50) NULL ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  PRIMARY KEY (`ImageID`) )
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
-- Table `e2CMS`.`NexusCore_Application_Logs`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusCore_Application_Logs` (
  `LogID` INT(10) NOT NULL AUTO_INCREMENT ,
  `ObjectID` VARCHAR(36) NOT NULL ,
  `Object_Type` ENUM('Template', 'Page', 'Control') NOT NULL ,
  `Action_Name` VARCHAR(100) NULL ,
  `Action_Type` ENUM('Create', 'Modify', 'Delete') NOT NULL ,
  `Action_UserID` VARCHAR(36) NOT NULL ,
  `Action_Date` DATETIME NOT NULL ,
  `Action_Detail` TEXT NULL ,
  `Result` VARCHAR(45) NULL ,
  PRIMARY KEY (`LogID`) )
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
  `Page_Keyword` VARCHAR(500) NULL ,
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
  `UserID` VARCHAR(36) NULL ,
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
-- Table `e2CMS`.`NexusBlog_Posts`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusBlog_Posts` (
  `PostID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Ownership_UserID` VARCHAR(36) NOT NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `BlogGroupID` INT(10) NOT NULL DEFAULT -1 ,
  `Post_Date` DATETIME NOT NULL ,
  `Post_ModifyDate` DATETIME NOT NULL ,
  `Post_Title` TEXT NOT NULL ,
  `Post_Content` TEXT NOT NULL ,
  `Post_Status` ENUM('Publish','Draft', 'Hidden', 'Protected') NOT NULL ,
  `Post_Password` VARCHAR(40) NOT NULL DEFAULT '' ,
  `View_Count` INT(10) NOT NULL DEFAULT 0 ,
  `Comment_Count` INT(10) NOT NULL DEFAULT 0 ,
  PRIMARY KEY (`PostID`, `UserID`, `Ownership_UserID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusBlog_Comments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusBlog_Comments` (
  `CommentID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Parent_CommentID` INT(10) NOT NULL DEFAULT -1 ,
  `PostID` INT(10) NOT NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `UserEmail` VARCHAR(150) NULL DEFAULT '' ,
  `UserURL` VARCHAR(200) NULL DEFAULT '' ,
  `UserIPaddress` VARCHAR(40) NULL ,
  `Post_Date` DATETIME NOT NULL ,
  `Post_Content` TEXT NOT NULL ,
  `Comment_Approved` TINYINT(1) NOT NULL DEFAULT 1 ,
  PRIMARY KEY (`CommentID`, `PostID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusBlog_Groups`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusBlog_Groups` (
  `BlogGroupID` INT(10) NOT NULL AUTO_INCREMENT ,
  `GroupName` VARCHAR(50) NOT NULL ,
  `Dexription` VARCHAR(250) NOT NULL ,
  PRIMARY KEY (`BlogGroupID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusBlog_UserInGroups`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusBlog_UserInGroups` (
  `RelationID` INT(20) NOT NULL AUTO_INCREMENT ,
  `UserID` VARCHAR(36) NOT NULL ,
  `BlogGroupID` INT(10) NOT NULL ,
  `UserRoles` ENUM('Administrator','Editor','Author','Reader') NOT NULL ,
  PRIMARY KEY (`RelationID`, `UserID`) )
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
-- Table `e2CMS`.`NexusNews_Posts`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusNews_Posts` (
  `NewsID` INT(10) NOT NULL AUTO_INCREMENT ,
  `CategoryID` VARCHAR(36) NOT NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `News_Date` DATETIME NOT NULL ,
  `News_ModifyDate` DATETIME NOT NULL ,
  `News_Title` TEXT NOT NULL ,
  `News_Brief` TEXT NULL ,
  `News_Content` LONGTEXT NOT NULL ,
  `News_Status` ENUM('Publish','Draft', 'Hidden', 'Protected') NOT NULL ,
  `News_Password` VARCHAR(40) NOT NULL DEFAULT '' ,
  `View_Count` INT(10) NOT NULL DEFAULT 0 ,
  `Comment_Count` INT(10) NOT NULL DEFAULT 0 ,
  `Author` VARCHAR(200) NULL ,
  `Source_Name` VARCHAR(200) NULL ,
  `Source_URL` VARCHAR(400) NULL ,
  PRIMARY KEY (`NewsID`, `UserID`, `CategoryID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusNews_Comments`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusNews_Comments` (
  `CommentID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Parent_CommentID` INT(10) NOT NULL DEFAULT -1 ,
  `NewsID` INT(10) NOT NULL ,
  `UserID` VARCHAR(36) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `UserEmail` VARCHAR(150) NULL DEFAULT '' ,
  `UserURL` VARCHAR(200) NULL DEFAULT '' ,
  `UserIPaddress` VARCHAR(40) NULL ,
  `Post_Date` DATETIME NOT NULL ,
  `Post_Content` TEXT NOT NULL ,
  `Comment_Approved` TINYINT(1) NOT NULL DEFAULT 1 ,
  PRIMARY KEY (`CommentID`, `NewsID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusEbay_Items`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusEbay_Items` (
  `Ebay_ItemID` BIGINT(20) NOT NULL ,
  `Ebay_ListType` VARCHAR(20) NOT NULL ,
  `Ebay_Title` TEXT NOT NULL ,
  `Ebay_SubTitle` TEXT NULL ,
  `Ebay_Picture` TEXT NULL ,
  `Ebay_Gallery` VARCHAR(400) NULL ,
  `Ebay_Description` TEXT NOT NULL ,
  `Item_Description` TEXT NULL ,
  `Currency` VARCHAR(5) NOT NULL ,
  `CurrentPrice` DECIMAL(10,2) NOT NULL ,
  `BuyItNowPrice` DECIMAL(10,2) NULL ,
  `StartTime` DATETIME NULL ,
  `EndTime` DATETIME NULL ,
  `Quantity` INT(10) NULL ,
  `QuantityAvailable` INT(10) NULL ,
  `QuantitySold` INT(10) NULL ,
  `BidCount` INT(10) NULL ,
  `HitCount` INT(10) NULL ,
  `View_Count` INT(10) NULL DEFAULT 0 ,
  `ViewItemURL` VARCHAR(400) NULL ,
  `IsActive` TINYINT(1) NULL ,
  `IsSync` TINYINT(1) NULL ,
  `LastSync_Date` DATETIME NULL ,
  PRIMARY KEY (`Ebay_ItemID`) )
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
-- Table `e2CMS`.`e2Tech_OnlineSurvey`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`e2Tech_OnlineSurvey` (
  `SurveyID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Q01` TEXT NULL ,
  `Q02` TEXT NULL ,
  PRIMARY KEY (`SurveyID`) )
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
-- Table `e2CMS`.`NexusPhoto_Items`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusPhoto_Items` (
  `PhotoID` VARCHAR(36) NOT NULL ,
  `Photo_Title` VARCHAR(250) NULL ,
  `Description` TEXT NULL ,
  `ImageURL` VARCHAR(400) NULL ,
  `ImageURL_Type` ENUM('Internal', 'External') NULL ,
  `AlternateText` VARCHAR(150) NULL ,
  `LinkURL` VARCHAR(400) NULL ,
  `Link_Target` VARCHAR(50) NULL ,
  `View_Count` INT(10) NULL ,
  `IsActive` TINYINT(1) NULL ,
  `Create_Date` DATETIME NULL ,
  `LastUpdate_Date` DATETIME NULL ,
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  PRIMARY KEY (`PhotoID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusEbay_Item_Mapping`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusEbay_Item_Mapping` (
  `Item_MapID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Ebay_ItemID` BIGINT(20) NOT NULL ,
  `CategoryID` VARCHAR(36) NOT NULL ,
  `IsFeatured` TINYINT(1) NULL DEFAULT 0 ,
  `SortOrder` TINYINT(3) NULL DEFAULT 1 ,
  PRIMARY KEY (`Item_MapID`, `Ebay_ItemID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusPhoto_Item_Mapping`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusPhoto_Item_Mapping` (
  `Item_MapID` INT(10) NOT NULL AUTO_INCREMENT ,
  `PhotoID` VARCHAR(36) NOT NULL ,
  `CategoryID` VARCHAR(36) NOT NULL ,
  `SortOrder` TINYINT(3) NULL ,
  PRIMARY KEY (`Item_MapID`, `PhotoID`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `e2CMS`.`NexusPhoto_Settings`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusPhoto_Settings` (
  `SettingID` INT(10) NOT NULL AUTO_INCREMENT ,
  `DisplayID` VARCHAR(100) NOT NULL ,
  `Image_BrokenURL` VARCHAR(500) NOT NULL ,
  `IsResize` TINYINT(1) NULL ,
  `Resize_Type` ENUM('Fixed','MaxHeight','MaxWidth','MaxHeight and MaxWidth','MinHeight','MinWidth','MinHeight and MinWidth') NULL ,
  `Resize_Height` INT(5) NULL ,
  `Resize_Width` INT(5) NULL ,
  `IsOverlay` TINYINT(1) NULL ,
  `Overlay_ImageURL` VARCHAR(500) NULL ,
  `Overlay_Opacity` INT(3) NULL ,
  `Overlay_Position` ENUM('TopLeft','TopRight','BottomLeft','BottomRight','Center') NULL ,
  `Overlay_PaddingX` INT(5) NULL ,
  `Overlay_PaddingY` INT(5) NULL ,
  PRIMARY KEY (`SettingID`, `DisplayID`) )
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
-- Placeholder table for view `e2CMS`.`view_NexusEbay_Items`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`view_NexusEbay_Items` (`Ebay_ItemID` INT, `Ebay_ListType` INT, `Ebay_Title` INT, `Ebay_SubTitle` INT, `Ebay_Picture` INT, `Ebay_Gallery` INT, `Ebay_Description` INT, `Item_Description` INT, `Currency` INT, `CurrentPrice` INT, `BuyItNowPrice` INT, `StartTime` INT, `EndTime` INT, `Quantity` INT, `QuantityAvailable` INT, `QuantitySold` INT, `BidCount` INT, `HitCount` INT, `View_Count` INT, `ViewItemURL` INT, `IsActive` INT, `IsSync` INT, `LastSync_Date` INT, `Item_MapID` INT, `CategoryID` INT, `IsFeatured` INT, `SortOrder` INT);

-- -----------------------------------------------------
-- Placeholder table for view `e2CMS`.`View_NexusPhoto_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusPhoto_List` (`PhotoID` INT, `Photo_Title` INT, `Description` INT, `ImageURL` INT, `ImageURL_Type` INT, `AlternateText` INT, `LinkURL` INT, `Link_Target` INT, `View_Count` INT, `IsActive` INT, `Create_Date` INT, `LastUpdate_Date` INT, `LastUpdate_UserID` INT, `Item_MapID` INT, `CategoryID` INT, `SortOrder` INT);

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_PageIndex_Menu`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_PageIndex_Menu`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_PageIndex_Menu` AS SELECT nexuscore_pageindex.PageIndexID, nexuscore_pageindex.Parent_PageIndexID, nexuscore_pageindex.Page_CategoryID, nexuscore_pageindex.Menu_Title, nexuscore_pageindex.Page_Name, nexuscore_pageindex.Page_Type, nexuscore_pageindex.SortOrder, IF(ChildrenCount IS NOT NULL, ChildrenCount, 0) AS ChildrenCount
FROM nexuscore_pageindex LEFT JOIN View_NexusCore_PageIndex_ChildrenCount AS nexuscore_pageindex_parent ON nexuscore_pageindex.PageIndexID = nexuscore_pageindex_parent.Parent_PageIndexID;;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_PageIndex_ChildrenCount` AS SELECT nexuscore_pageindex.Parent_PageIndexID, Count(*) As ChildrenCount FROM nexuscore_pageindex Group By (Parent_PageIndexID)
;

-- -----------------------------------------------------
-- View `e2CMS`.`view_Template_Masterpage_DropList`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_Template_Masterpage_DropList`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_Template_Masterpage_DropList` AS SELECT nexuscore_masterpageindex.MasterPageIndexID, nexuscore_masterpageindex.MasterPage_Name, nexuscore_masterpageindex.MasterPage_Description, nexuscore_themes.Theme_Code, nexuscore_template_masterpages.MasterPage_Template_Name
FROM nexuscore_themes INNER JOIN (nexuscore_template_masterpages INNER JOIN nexuscore_masterpageindex ON nexuscore_template_masterpages.Template_MasterPageID=nexuscore_masterpageindex.Template_MasterPageID) ON nexuscore_themes.ThemeID=nexuscore_masterpageindex.ThemeID;;

-- -----------------------------------------------------
-- View `e2CMS`.`view_Template_Masterpage_Count`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_Template_Masterpage_Count`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_Template_Masterpage_Count` AS SELECT nexuscore_page_templates.MasterPageIndexID, Count(nexuscore_page_templates.PageIndexID) AS UsageCount
FROM nexuscore_page_templates
GROUP BY nexuscore_page_templates.MasterPageIndexID;;

-- -----------------------------------------------------
-- View `e2CMS`.`view_Template_Masterpage_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_Template_Masterpage_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_Template_Masterpage_List` AS SELECT nexuscore_masterpageindex.MasterPageIndexID, nexuscore_masterpageindex.MasterPage_Name, nexuscore_template_masterpages.TemplateID, nexuscore_template_masterpages.Template_MasterPageID, nexuscore_template_masterpages.MasterPage_Template_Name, nexuscore_masterpageindex.ThemeID, nexuscore_themes.Theme_Name, nexuscore_themes.Theme_Code, nexuscore_template_masterpages.MasterPage_Version, nexuscore_masterpageindex.MasterPage_Description, IFNULL(UsageCount,0) AS UsageCounts
FROM (nexuscore_themes INNER JOIN (nexuscore_template_masterpages INNER JOIN nexuscore_masterpageindex ON nexuscore_template_masterpages.Template_MasterPageID = nexuscore_masterpageindex.Template_MasterPageID) ON nexuscore_themes.ThemeID = nexuscore_masterpageindex.ThemeID) LEFT JOIN View_Template_MasterPage_Count ON nexuscore_masterpageindex.MasterPageIndexID = View_Template_MasterPage_Count.MasterPageIndexID;;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_PageIndex_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_PageIndex_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_PageIndex_List` AS SELECT nexuscore_pageindex.PageIndexID, nexuscore_pageindex.Parent_PageIndexID, nexuscore_pageindex.Page_CategoryID, nexuscore_pageindex.Menu_Title, nexuscore_pageindex.Page_Name, nexuscore_pageindex.Page_Type, nexuscore_pageindex.SortOrder, IF(ChildrenCount Is Not Null,ChildrenCount,0) AS ChildrenCount, nexuscore_page_props.IsOnMenu, nexuscore_page_props.IsOnNavigator, nexuscore_page_props.IsPrivacy_Inherited, nexuscore_page_props.IsAttribute_Inherited, nexuscore_page_props.IsTemplate_Inherited, nexuscore_page_props.IsSSL
FROM (nexuscore_pageindex LEFT JOIN View_NexusCore_PageIndex_ChildrenCount AS nexuscore_pageindex_parent ON nexuscore_pageindex.PageIndexID = nexuscore_pageindex_parent.Parent_PageIndexID) INNER JOIN nexuscore_page_props ON nexuscore_pageindex.PageIndexID = nexuscore_page_props.PageIndexID;;

-- -----------------------------------------------------
-- View `e2CMS`.`View_Template_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_Template_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_Template_List` AS SELECT nexuscore_templates.TemplateID, nexuscore_template_masterpages.Template_MasterPageID, nexuscore_themes.ThemeID, nexuscore_template_masterpages.MasterPage_Template_Name, nexuscore_template_masterpages.MasterPage_Version, nexuscore_themes.Theme_Name, nexuscore_themes.Theme_Code
FROM (nexuscore_templates INNER JOIN nexuscore_template_masterpages ON nexuscore_templates.TemplateID = nexuscore_template_masterpages.TemplateID) INNER JOIN nexuscore_themes ON nexuscore_templates.TemplateID = nexuscore_themes.TemplateID;
;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_Page_Privacy_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_Page_Privacy_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_Page_Privacy_List` AS SELECT nexuscore_page_privacies.PrivacyID, nexuscore_page_privacies.PageIndexID, nexuscore_page_privacies.UserGroupID, nexususer_usergroups.UserGroup_Name, nexususer_usergroups.Description AS UserGroup_Description, nexuscore_page_privacies.Allow_View, nexuscore_page_privacies.Allow_Create, nexuscore_page_privacies.Allow_Modify, nexuscore_page_privacies.Allow_Delete, nexuscore_page_privacies.Allow_Rollback, nexuscore_page_privacies.Allow_ChangePermissions, nexuscore_page_privacies.Allow_Approve, nexuscore_page_privacies.Allow_Publish, nexuscore_page_privacies.Allow_DesignMode
FROM nexuscore_page_privacies INNER JOIN nexususer_usergroups ON nexuscore_page_privacies.UserGroupID = nexususer_usergroups.UserGroupID;
;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusCore_ComponentInCategory_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusCore_ComponentInCategory_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusCore_ComponentInCategory_List` AS SELECT nexuscore_componentincategories.RelationID, nexuscore_categories.CategoryID, nexuscore_categories.Parent_CategoryID, nexuscore_categories.Category_Name, nexuscore_modules.ModuleID, nexuscore_modules.Module_Name, nexuscore_module_items.Module_ItemID, nexuscore_module_items.Item_Name, nexuscore_componentincategories.Item_Count
FROM nexuscore_module_items INNER JOIN (nexuscore_modules INNER JOIN (nexuscore_categories INNER JOIN nexuscore_componentincategories ON nexuscore_categories.CategoryID = nexuscore_componentincategories.CategoryID) ON nexuscore_modules.ModuleID = nexuscore_componentincategories.ModuleID) ON nexuscore_module_items.Module_ItemID = nexuscore_componentincategories.Module_ItemID;
;

-- -----------------------------------------------------
-- View `e2CMS`.`view_NexusEbay_Items`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`view_NexusEbay_Items`;
CREATE  OR REPLACE VIEW `e2CMS`.`view_NexusEbay_Items` AS SELECT nexusebay_items.Ebay_ItemID, nexusebay_items.Ebay_ListType, nexusebay_items.Ebay_Title, nexusebay_items.Ebay_SubTitle, nexusebay_items.Ebay_Picture, nexusebay_items.Ebay_Gallery, nexusebay_items.Ebay_Description, nexusebay_items.Item_Description, nexusebay_items.Currency, nexusebay_items.CurrentPrice, nexusebay_items.BuyItNowPrice, nexusebay_items.StartTime, nexusebay_items.EndTime, nexusebay_items.Quantity, nexusebay_items.QuantityAvailable, nexusebay_items.QuantitySold, nexusebay_items.BidCount, nexusebay_items.HitCount, nexusebay_items.View_Count, nexusebay_items.ViewItemURL, nexusebay_items.IsActive, nexusebay_items.IsSync, nexusebay_items.LastSync_Date, nexusebay_item_mapping.Item_MapID, nexusebay_item_mapping.CategoryID, nexusebay_item_mapping.IsFeatured, nexusebay_item_mapping.SortOrder
FROM nexusebay_items INNER JOIN nexusebay_item_mapping ON nexusebay_items.Ebay_ItemID = nexusebay_item_mapping.Ebay_ItemID;
;

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusPhoto_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusPhoto_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusPhoto_List` AS SELECT nexusphoto_items.PhotoID, nexusphoto_items.Photo_Title, nexusphoto_items.Description, nexusphoto_items.ImageURL, nexusphoto_items.ImageURL_Type, nexusphoto_items.AlternateText, nexusphoto_items.LinkURL, nexusphoto_items.Link_Target, nexusphoto_items.View_Count, nexusphoto_items.IsActive, nexusphoto_items.Create_Date, nexusphoto_items.LastUpdate_Date, nexusphoto_items.LastUpdate_UserID, nexusphoto_item_mapping.Item_MapID, nexusphoto_item_mapping.CategoryID, nexusphoto_item_mapping.SortOrder
FROM nexusphoto_items INNER JOIN nexusphoto_item_mapping ON nexusphoto_items.PhotoID = nexusphoto_item_mapping.PhotoID;

;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusUser_Users`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusUser_Users` (`UserID`, `UserName`, `Email`, `UserPass`, `CreateDate`, `CreateIPaddress`, `LastLoginDate`, `LastPasswordChangedDate`, `FailedPassAttemptCount`, `IsLockedOut`, `DeleteMark`, `Activation_Code`) VALUES ('E24E5CDC-46D9-4B52-9D9F-32ECD4D9A186', 'Administrator', 'default@domain.com', '1234567', '2011-03-21 00:00:00', '127.0.0.1', 0, 0, 0, 0, 0, '');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusUser_HowYouFindUs`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (1, 'Please Select', 1, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (2, 'Google', 2, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (3, 'Yahoo', 3, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (4, 'MSN', 4, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (5, 'AOL', 5, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (6, 'Television', 6, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (7, 'Radio', 7, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (8, 'Friend', 8, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (9, 'Yellow Pages', 9, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (10, 'Website Link', 10, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (11, 'Email Advert', 11, 1);
INSERT INTO `NexusUser_HowYouFindUs` (`HowYouFindUsID`, `Details`, `SortOrder`, `IsActive`) VALUES (12, 'Other - Indicate Below', 12, 1);

COMMIT;

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
-- Data for table `e2CMS`.`NexusUser_UserInGroups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusUser_UserInGroups` (`RelationID`, `UserID`, `UserGroupID`) VALUES (1, 'E24E5CDC-46D9-4B52-9D9F-32ECD4D9A186', 'B117D66E-3A2F-45b9-8329-2119426F9311');

COMMIT;

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
INSERT INTO `NexusCore_Page_Templates` (`Page_TemplateID`, `PageIndexID`, `MasterPageIndexID`) VALUES (1, '-1', '6BB9205FDE8D4F22A432879FB1BC61C3');

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
-- Data for table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('07EB9C71-8751-4D42-AE97-CE4C8D213A12', 'NexusCore', 'Webpage');

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
-- Data for table `e2CMS`.`NexusPhoto_Settings`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusPhoto_Settings` (`SettingID`, `DisplayID`, `Image_BrokenURL`, `IsResize`, `Resize_Type`, `Resize_Height`, `Resize_Width`, `IsOverlay`, `Overlay_ImageURL`, `Overlay_Opacity`, `Overlay_Position`, `Overlay_PaddingX`, `Overlay_PaddingY`) VALUES (1, 'Default', '/App_Control_Style/Nexus_Gallery/Images/NoImg.jpg', 0, Fixed, 200, 200, 0, '', 80, TopLeft, 10, 10);

COMMIT;
