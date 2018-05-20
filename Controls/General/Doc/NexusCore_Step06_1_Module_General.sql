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
  `LastUpdate_UserID` INT(10) NULL ,
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
  `LastUpdate_UserID` INT(10) NULL ,
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
