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
