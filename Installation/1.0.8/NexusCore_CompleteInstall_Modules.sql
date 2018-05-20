-- -----------------------------------------------------
-- Step06_1 General
-- -----------------------------------------------------

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

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
  `LastUpdate_UserID` VARCHAR(36) NULL ,
  PRIMARY KEY (`RichTextID`) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('76DBDE57-8AA2-430c-B97E-5447589B5705', 'General Tools', '/App_Control_Style/General_Tools/Icons/general_tools', 'System Addon', '1.0.1', '2011-06-04', 'e2Tech.Ltd', 'General Tools');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('DC88B2A7-92EE-4a99-AF92-E78D4A738D89', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'HTML', '/App_Control_Style/General_Tools/Icons/html', 'Addon', '1.0.1');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('B6693021-B1FF-413d-AE62-BA7CAA348FAD', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Rich Text', '/App_Control_Style/General_Tools/Icons/richtext', 'Addon', '1.0.1');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('7620445B-9E53-4e9d-8B7F-DBD84E840E43', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Image', '/App_Control_Style/General_Tools/Icons/image', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('73BFBFAE-CBD7-4d03-894F-C9A5A61FDF9A', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Script', '/App_Control_Style/General_Tools/Icons/javascript', 'Addon', '1.0.1');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('FBF4ECD5-33FD-41F6-A7A3-96E833369D05', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'HTML', '/App_Control_Style/General_Tools/Icons/html', 'ControlPanel', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('D814D559-5D29-4245-ACC5-DFB358720AD5', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Rich Text', '/App_Control_Style/General_Tools/Icons/richtext', 'ControlPanel', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('7B07C6FE-D945-4741-8E1E-6FF8BF461EBF', '-1', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Script', '/App_Control_Style/General_Tools/Icons/javascript', 'ControlPanel', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('76DBDE57-8AA2-430c-B97E-5447589B5705', 'DC88B2A7-92EE-4a99-AF92-E78D4A738D89', 'General Tools', 'HTML', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('76DBDE57-8AA2-430c-B97E-5447589B5705', 'B6693021-B1FF-413d-AE62-BA7CAA348FAD', 'General Tools', 'Rich Text', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('76DBDE57-8AA2-430c-B97E-5447589B5705', '7620445B-9E53-4e9d-8B7F-DBD84E840E43', 'General Tools', 'Image', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('76DBDE57-8AA2-430c-B97E-5447589B5705', '73BFBFAE-CBD7-4d03-894F-C9A5A61FDF9A', 'General Tools', 'Script', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('DC88B2A7-92EE-4a99-AF92-E78D4A738D89', 'B173A5F1-18BC-4D09-9530-80742D6E436F', 'HTML', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('B6693021-B1FF-413d-AE62-BA7CAA348FAD', 'B173A5F1-18BC-4D09-9530-80742D6E436F', 'Rich Text', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('7620445B-9E53-4e9d-8B7F-DBD84E840E43', 'B173A5F1-18BC-4D09-9530-80742D6E436F', 'Image', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('73BFBFAE-CBD7-4d03-894F-C9A5A61FDF9A', 'B173A5F1-18BC-4D09-9530-80742D6E436F', 'Script', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('1C779E7D-B917-474a-9310-09DED202B501', 'DC88B2A7-92EE-4a99-AF92-E78D4A738D89', 'HTML', 'WebView', 'Nexus.Controls.General.HTML.HTML_WebView', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('3E63F2C5-F79F-44fd-A81D-757E8C577587', 'DC88B2A7-92EE-4a99-AF92-E78D4A738D89', 'HTML Advanced', 'Advanced', 'Nexus.Controls.General.HTML.HTML_Advanced', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('73325471-EF48-4064-A1D7-A31CA3D61499', 'DC88B2A7-92EE-4a99-AF92-E78D4A738D89', 'HTML Editor', 'Editor', 'Nexus.Controls.General.HTML.HTML_Editor', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('5FF1DFDB-F9A4-48f7-9CF3-9179FDC9A8B8', 'B6693021-B1FF-413d-AE62-BA7CAA348FAD', 'Rich Text', 'WebView', 'Nexus.Controls.General.RichText.RichText_WebView', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('67611EF9-5CE7-4f3e-8E2F-BA6AE161855D', 'B6693021-B1FF-413d-AE62-BA7CAA348FAD', 'Rich Text Advanced', 'Advanced', 'Nexus.Controls.General.RichText.RichText_Advanced', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('7A48C0A3-45EA-4c7f-8576-DE0BA7C6BEEE', 'B6693021-B1FF-413d-AE62-BA7CAA348FAD', 'Rich Text Editor', 'Editor', 'Nexus.Controls.General.RichText.RichText_Editor', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('FACF6570-C6EE-4fd1-A32E-8D2BA0432719', '7620445B-9E53-4e9d-8B7F-DBD84E840E43', 'Image', 'WebView', 'Nexus.Controls.General.Image.Image_WebView', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('ED9E2167-2C06-4CB8-82E0-E652DB50DDDD', '7620445B-9E53-4e9d-8B7F-DBD84E840E43', 'Image Advanced', 'Advanced', 'Nexus.Controls.General.Image.Image_Advanced', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('4E567183-B1F9-4E84-9030-03AA018D588E', '7620445B-9E53-4e9d-8B7F-DBD84E840E43', 'Image Editor', 'Editor', 'Nexus.Controls.General.Image.Image_Editor', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('FBFA9BB7-817C-4944-9558-3C5578CFD476', '73BFBFAE-CBD7-4d03-894F-C9A5A61FDF9A', 'Java Script', 'WebView', 'Nexus.Controls.General.Script.Script_WebView', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('EC03FC37-2E38-45B4-BBAE-F88C31A63AB9', '73BFBFAE-CBD7-4d03-894F-C9A5A61FDF9A', 'Java Script Advanced', 'Advanced', 'Nexus.Controls.General.Script.Script_Advanced', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('BBB1DE67-368C-4884-AC18-276C764728F7', '73BFBFAE-CBD7-4d03-894F-C9A5A61FDF9A', 'Java Script Editor', 'Editor', 'Nexus.Controls.General.Script.Script_Editor', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('4D83E2C0-32D5-4F5C-A8DD-27CBB2EFB1A5', 'FBF4ECD5-33FD-41F6-A7A3-96E833369D05', 'Create HTML', 'Management', 'Nexus.Controls.General.Management.Management_CreateHTML', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('E31A9FFC-BFAC-4DDE-A79D-BEB4A7B72A30', 'FBF4ECD5-33FD-41F6-A7A3-96E833369D05', 'Manage HTML', 'Management', 'Nexus.Controls.General.Management.Management_ManageHTML', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('01760835-8634-4C7F-92A0-15F751878F90', 'FBF4ECD5-33FD-41F6-A7A3-96E833369D05', 'Edit HTML', 'ControlPanel', 'Nexus.Controls.General.ControlPanel.ControlPanel_EditHTML', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('0C96A76C-D17F-47E7-B1C8-B213964B2F13', 'D814D559-5D29-4245-ACC5-DFB358720AD5', 'Create Rich Text', 'Management', 'Nexus.Controls.General.Management.Management_CreateRichText', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('761743A4-9D6E-4AE7-BC1D-4B384870F745', 'D814D559-5D29-4245-ACC5-DFB358720AD5', 'Manage Rich Text', 'Management', 'Nexus.Controls.General.Management.Management_ManageRichText', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('A9597348-D348-4938-AF75-4AA330DB26CD', 'D814D559-5D29-4245-ACC5-DFB358720AD5', 'Edit Rich Text', 'ControlPanel', 'Nexus.Controls.General.ControlPanel.ControlPanel_EditRichText', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('CEDD8B76-84BF-4221-9F44-932CF7BFEF33', '7B07C6FE-D945-4741-8E1E-6FF8BF461EBF', 'Create Script', 'Management', 'Nexus.Controls.General.Management.Management_CreateScript', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('286E7105-9A79-49F7-BF8F-86E8281D4E6A', '7B07C6FE-D945-4741-8E1E-6FF8BF461EBF', 'Manage Script', 'Management', 'Nexus.Controls.General.Management.Management_ManageScript', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('1DADE160-91DF-44E1-9ECB-9E790059978B', '7B07C6FE-D945-4741-8E1E-6FF8BF461EBF', 'Edit Script', 'ControlPanel', 'Nexus.Controls.General.ControlPanel.ControlPanel_EditScript', 'Nexus.Controls.General, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('B173A5F1-18BC-4D09-9530-80742D6E436F', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'General Tools', true, true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('B1CD6348-796C-4E92-8C39-5CEF3D600B7C', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'HTML');
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('A2E21E10-FF09-4D3F-9D70-DF9376FCF8B7', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Rich Text');
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('709E1CEF-C760-4D45-B0CB-12F11A7EE062', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Image');
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('076A591E-1BFE-47A7-8B40-D6621C7D3DF9', '76DBDE57-8AA2-430c-B97E-5447589B5705', 'Script');

COMMIT;

-- -----------------------------------------------------
-- Step06_2 Navigation
-- -----------------------------------------------------
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
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('EDBB8074-7246-46FA-902A-5C4DBA0946CF', 'Navigation', '/App_Control_Style/Navigation/Icons/navigation', 'System Addon', '1.0.1', '2011-09-20', 'e2Tech.Ltd', 'Navigation');

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

-- -----------------------------------------------------
-- Step06_3 WebUserControl
-- -----------------------------------------------------
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('243A64A8-095F-4E33-982B-EFA15F684312', 'Web User Controls', '/App_Control_Style/Web_User_Controls/Icons/web_user_control', 'System Addon', '1.0.0', '2010-09-20', 'e2Tech.Ltd', 'Web User Controls');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('3862AEBA-6E83-4114-B62E-BCC36601239D', '-1', '243A64A8-095F-4E33-982B-EFA15F684312', 'Customer Controls', '/App_Control_Style/Web_User_Controls/Icons/customer_control', 'Addon', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('243A64A8-095F-4E33-982B-EFA15F684312', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Web User Controls', 'Customer Control', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('3862AEBA-6E83-4114-B62E-BCC36601239D', 'CFFCAA1E-BC12-4ED5-878A-9A26455FFCFA', 'Customer Control', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('8FFB3379-32A6-4445-814B-03B36952A2A7', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Customer Control', 'WebView', 'Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_WebView', 'Nexus.Controls.WebUserControl, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('C8EDE421-29CF-4DCB-B383-4C08EEA44269', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Customer Control Advanced', 'Advanced', 'Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_Advanced', 'Nexus.Controls.WebUserControl, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('33B48477-53A9-4563-998D-E85AEEA509E7', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Customer Control Editor', 'Editor', 'Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_Editor', 'Nexus.Controls.WebUserControl, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('CFFCAA1E-BC12-4ED5-878A-9A26455FFCFA', '243A64A8-095F-4E33-982B-EFA15F684312', 'Web User Controls', true, true);

COMMIT;

-- -----------------------------------------------------
-- Step07_1 Template Default
-- -----------------------------------------------------
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

-- -----------------------------------------------------
-- Step07_2 Template Default Sample Data
-- -----------------------------------------------------
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
INSERT INTO `NexusCore_MasterPages` (`MasterPageID`, `MasterPageIndexID`, `MasterPage_Version`, `Create_Date`, `LastUpdate_Date`, `LastUpdate_UserID`, `IsActive`, `IsDelete`) VALUES ('89E3775819994C8193659476CFF2028D', '82C9EF99930741CCB76E1B4D4A77D0D9', 1, '2011-06-01', '2011-06-01', 'E24E5CDC-46D9-4B52-9D9F-32ECD4D9A186', 1, 0);
INSERT INTO `NexusCore_MasterPages` (`MasterPageID`, `MasterPageIndexID`, `MasterPage_Version`, `Create_Date`, `LastUpdate_Date`, `LastUpdate_UserID`, `IsActive`, `IsDelete`) VALUES ('B82F96BB4E804B51B4E61B455125A478', '06BF339C09864B6698D7B243D25D889E', 1, '2011-06-01', '2011-06-01', 'E24E5CDC-46D9-4B52-9D9F-32ECD4D9A186', 1, 0);
INSERT INTO `NexusCore_MasterPages` (`MasterPageID`, `MasterPageIndexID`, `MasterPage_Version`, `Create_Date`, `LastUpdate_Date`, `LastUpdate_UserID`, `IsActive`, `IsDelete`) VALUES ('6BBBEB003C734087B7609F9B8B132B43', 'D8CD0F317AD542FEBD7ED326391850CC', 1, '2011-06-01', '2011-06-01', 'E24E5CDC-46D9-4B52-9D9F-32ECD4D9A186', 1, 0);

COMMIT;
