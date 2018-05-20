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
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('862ED33D-83E3-4569-87C5-B93670BD9D50', 'Blog (Multi-user)', '/App_Control_Style/Nexus_mBlog/Icons/Nexus_Blog', 'Customer Addon', '1.0.0', '2011-03-26', 'e2Tech.Ltd', 'Multi users blog');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('046523CB-295C-4689-9DCA-6D51CDACBEE4', '-1', '862ED33D-83E3-4569-87C5-B93670BD9D50', 'Blog Posts', '/App_Control_Style/Nexus_mBlog/Icons/blogposts', 'Addon', '1.0.0');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('5A6FCCEE-04C0-4AA3-8CA3-CFAEE549D5A7', '-1', '862ED33D-83E3-4569-87C5-B93670BD9D50', 'Post View', '/App_Control_Style/Nexus_mBlog/Icons/postview', 'Addon', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('862ED33D-83E3-4569-87C5-B93670BD9D50', '046523CB-295C-4689-9DCA-6D51CDACBEE4', 'Blog (Multi-user)', 'Blog Postsr', '1.0.0', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('862ED33D-83E3-4569-87C5-B93670BD9D50', '5A6FCCEE-04C0-4AA3-8CA3-CFAEE549D5A7', 'Blog (Multi-user)', 'Post View', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('046523CB-295C-4689-9DCA-6D51CDACBEE4', 'E8361167-FF67-45E7-8BC5-23A5A1EEA763', 'Blog Posts', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('5A6FCCEE-04C0-4AA3-8CA3-CFAEE549D5A7', 'E8361167-FF67-45E7-8BC5-23A5A1EEA763', 'Post View', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('15150B31-3186-4B32-BCFA-326C490ADBF8', '046523CB-295C-4689-9DCA-6D51CDACBEE4', 'Blog Postsr', 'WebView', 'Nexus.Controls.Blog.mBlogPosts.mBlogPosts_WebView', 'Nexus.Controls.mBlog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('4836D928-DA3B-4CF2-9D4C-C97F7CBF85A6', '046523CB-295C-4689-9DCA-6D51CDACBEE4', 'Blog Posts Advanced', 'Advanced', 'Nexus.Controls.Blog.mBlogPosts.mBlogPosts_Advanced', 'Nexus.Controls.mBlog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('9A719CF9-0466-4196-8349-AA421C619B30', '046523CB-295C-4689-9DCA-6D51CDACBEE4', 'Blog Posts Editor', 'Editor', 'Nexus.Controls.Blog.mBlogPosts.mBlogPosts_Editor', 'Nexus.Controls.mBlog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('1775E2E0-FED3-4C0E-815F-B0428EC771A0', '5A6FCCEE-04C0-4AA3-8CA3-CFAEE549D5A7', 'Post View', 'WebView', 'Nexus.Controls.Blog.mPostView.mPostView_WebView', 'Nexus.Controls.mBlog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('2DF297B8-F67F-422A-95E4-A78E879F4E69', '5A6FCCEE-04C0-4AA3-8CA3-CFAEE549D5A7', 'Post View Advanced', 'Advanced', 'Nexus.Controls.Blog.mPostView.mPostView_Advanced', 'Nexus.Controls.mBlog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('D987FA0C-D245-41CB-B0FF-22A5A1AB4C96', '5A6FCCEE-04C0-4AA3-8CA3-CFAEE549D5A7', 'Post View Editor', 'Editor', 'Nexus.Controls.Blog.mPostView.mPostView_Editor', 'Nexus.Controls.mBlog, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('E8361167-FF67-45E7-8BC5-23A5A1EEA763', '862ED33D-83E3-4569-87C5-B93670BD9D50', 'Blog (Multi-user)', true, false);

COMMIT;
