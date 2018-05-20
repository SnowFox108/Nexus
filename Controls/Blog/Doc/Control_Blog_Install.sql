SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusBlog_Posts`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusBlog_Posts` (
  `PostID` INT(10) NOT NULL AUTO_INCREMENT ,
  `Ownership_UserID` INT(10) NOT NULL ,
  `UserID` INT(10) NOT NULL ,
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
  `UserID` INT(10) NOT NULL ,
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
  `UserID` INT(10) NOT NULL ,
  `BlogGroupID` INT(10) NOT NULL ,
  `UserRoles` ENUM('Administrator','Editor','Author','Reader') NOT NULL ,
  PRIMARY KEY (`RelationID`, `UserID`) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;


-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('931FB834-AA0F-4548-955F-0972E68F82C7', 'Blog', '/App_Control_Style/Nexus_Blog/Icons/Nexus_Blog', 'Customer Addon', '1.0.2', '2011-11-28', 'e2Tech.Ltd', 'Single user blog');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('E0E3D043-82FD-4714-A05F-F4FF1BF1F09F', '-1', '931FB834-AA0F-4548-955F-0972E68F82C7', 'Blog Posts', '/App_Control_Style/Nexus_Blog/Icons/blogposts', 'Addon', '1.0.2');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('2F4A75E1-C8C5-480A-BCA7-9D7FF08BFF85', '-1', '931FB834-AA0F-4548-955F-0972E68F82C7', 'Post View', '/App_Control_Style/Nexus_Blog/Icons/postview', 'Addon', '1.0.1');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('931FB834-AA0F-4548-955F-0972E68F82C7', 'E0E3D043-82FD-4714-A05F-F4FF1BF1F09F', 'Blog', 'Blog Postsr', '1.0.2', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('931FB834-AA0F-4548-955F-0972E68F82C7', '2F4A75E1-C8C5-480A-BCA7-9D7FF08BFF85', 'Blog', 'Post View', '1.0.1', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('E0E3D043-82FD-4714-A05F-F4FF1BF1F09F', 'A51C9001-9A8F-4FD8-B3F4-B3FAA532A948', 'Blog Posts', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('2F4A75E1-C8C5-480A-BCA7-9D7FF08BFF85', 'A51C9001-9A8F-4FD8-B3F4-B3FAA532A948', 'Post View', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('CC21E243-E1F4-4351-9555-8653EE90F93A', 'E0E3D043-82FD-4714-A05F-F4FF1BF1F09F', 'Blog Postsr', 'WebView', 'Nexus.Controls.Blog.BlogPosts.BlogPosts_WebView', 'Nexus.Controls.Blog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('755B7F11-96A6-4E77-B481-998F83877649', 'E0E3D043-82FD-4714-A05F-F4FF1BF1F09F', 'Blog Posts Advanced', 'Advanced', 'Nexus.Controls.Blog.BlogPosts.BlogPosts_Advanced', 'Nexus.Controls.Blog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('3B06485F-6048-486F-B92D-5A834CAEDB2D', 'E0E3D043-82FD-4714-A05F-F4FF1BF1F09F', 'Blog Posts Editor', 'Editor', 'Nexus.Controls.Blog.BlogPosts.BlogPosts_Editor', 'Nexus.Controls.Blog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('7A8A66A2-B45B-4D2E-9BAB-22B6652CD5E6', '2F4A75E1-C8C5-480A-BCA7-9D7FF08BFF85', 'Post View', 'WebView', 'Nexus.Controls.Blog.PostView.PostView_WebView', 'Nexus.Controls.Blog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('148C8A30-1360-4A65-B7EC-CA8248BA5338', '2F4A75E1-C8C5-480A-BCA7-9D7FF08BFF85', 'Post View Advanced', 'Advanced', 'Nexus.Controls.Blog.PostView.PostView_Advanced', 'Nexus.Controls.Blog, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('DA568BE4-D2D6-4B6B-A833-D60F5FE3C212', '2F4A75E1-C8C5-480A-BCA7-9D7FF08BFF85', 'Post View Editor', 'Editor', 'Nexus.Controls.Blog.PostView.PostView_Editor', 'Nexus.Controls.Blog, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('A51C9001-9A8F-4FD8-B3F4-B3FAA532A948', '931FB834-AA0F-4548-955F-0972E68F82C7', 'Blog', true, false);

COMMIT;
