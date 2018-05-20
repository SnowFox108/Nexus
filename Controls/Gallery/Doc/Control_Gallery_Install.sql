SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

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
  `LastUpdate_UserID` INT(10) NULL ,
  PRIMARY KEY (`PhotoID`) )
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
-- Placeholder table for view `e2CMS`.`View_NexusPhoto_List`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `e2CMS`.`View_NexusPhoto_List` (`PhotoID` INT, `Photo_Title` INT, `Description` INT, `ImageURL` INT, `ImageURL_Type` INT, `AlternateText` INT, `LinkURL` INT, `Link_Target` INT, `IsActive` INT, `Create_Date` INT, `LastUpdate_Date` INT, `LastUpdate_UserID` INT, `Item_MapID` INT, `CategoryID` INT, `SortOrder` INT);

-- -----------------------------------------------------
-- View `e2CMS`.`View_NexusPhoto_List`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `e2CMS`.`View_NexusPhoto_List`;
CREATE  OR REPLACE VIEW `e2CMS`.`View_NexusPhoto_List` AS SELECT nexusphoto_items.PhotoID, nexusphoto_items.Photo_Title, nexusphoto_items.Description, nexusphoto_items.ImageURL, nexusphoto_items.ImageURL_Type, nexusphoto_items.AlternateText, nexusphoto_items.LinkURL, nexusphoto_items.Link_Target, nexusphoto_items.View_Count, nexusphoto_items.IsActive, nexusphoto_items.Create_Date, nexusphoto_items.LastUpdate_Date, nexusphoto_items.LastUpdate_UserID, nexusphoto_item_mapping.Item_MapID, nexusphoto_item_mapping.CategoryID, nexusphoto_item_mapping.SortOrder
FROM nexusphoto_items INNER JOIN nexusphoto_item_mapping ON nexusphoto_items.PhotoID = nexusphoto_item_mapping.PhotoID;




SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Photo Gallery', '/App_Control_Style/Nexus_Gallery/Icons/Nexus_Gallery', 'Customer Addon', '1.0.0', '2012-01-30', 'e2Tech.Ltd', 'Photo Gallery');

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
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('6182CB1A-107E-4C14-B91E-4C9DE15B9074', '3C7439E5-A998-46E5-A092-463C70A3AA0B', 'Photo Gallery', 'Photo List', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('6182CB1A-107E-4C14-B91E-4C9DE15B9074', '1B925E9F-3D19-4588-969E-8C6AE631828B', 'Photo Gallery', 'Photo Detail', '1.0.0', true);

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
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('3AF83F98-C56E-42EF-8B0C-3FB13A8DE9EF', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Photo Gallery', true, false);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('9473F482-CC30-4963-946A-28CA4AD44041', '6182CB1A-107E-4C14-B91E-4C9DE15B9074', 'Photo Item');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusPhoto_Settings`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusPhoto_Settings` (`SettingID`, `DisplayID`, `Image_BrokenURL`, `IsResize`, `Resize_Type`, `Resize_Height`, `Resize_Width`, `IsOverlay`, `Overlay_ImageURL`, `Overlay_Opacity`, `Overlay_Position`, `Overlay_PaddingX`, `Overlay_PaddingY`) VALUES (1, 'Default', '/App_Control_Style/Nexus_Gallery/Images/NoImg.jpg', 0, 'Fixed', 200, 200, 0, '', 80, 'TopLeft', 10, 10);

COMMIT;
