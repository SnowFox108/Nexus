SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusNews_Posts`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusNews_Posts` (
  `NewsID` INT(10) NOT NULL AUTO_INCREMENT ,
  `CategoryID` VARCHAR(36) NOT NULL ,
  `UserID` INT(10) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `News_Date` DATETIME NOT NULL ,
  `News_ModifyDate` DATETIME NOT NULL ,
  `News_Title` TEXT NOT NULL ,
  `News_Brief` TEXT NULL ,
  `News_Content` TEXT NOT NULL ,
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
  `UserID` INT(10) NOT NULL ,
  `UserName` VARCHAR(40) NOT NULL ,
  `UserEmail` VARCHAR(150) NULL DEFAULT '' ,
  `UserURL` VARCHAR(200) NULL DEFAULT '' ,
  `UserIPaddress` VARCHAR(40) NULL ,
  `Post_Date` DATETIME NOT NULL ,
  `Post_Content` TEXT NOT NULL ,
  `Comment_Approved` TINYINT(1) NOT NULL DEFAULT 1 ,
  PRIMARY KEY (`CommentID`, `NewsID`) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Modules`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('EC7098A9-2C03-4B6E-BF48-8395C78F74B7', 'News', '/App_Control_Style/Nexus_News/Icons/Nexus_News', 'Customer Addon', '1.0.2', '2011-11-28', 'e2Tech.Ltd', 'Web News');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('9B2333C6-55F3-4A28-A162-8AC2D61362BF', '-1', 'EC7098A9-2C03-4B6E-BF48-8395C78F74B7', 'News List', '/App_Control_Style/Nexus_News/Icons/newslist', 'Addon', '1.0.1');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('34E0CE1D-2163-4E8E-A2C2-846519F114BC', '-1', 'EC7098A9-2C03-4B6E-BF48-8395C78F74B7', 'News Detail', '/App_Control_Style/Nexus_News/Icons/newsdetail', 'Addon', '1.0.1');
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('156B3CC5-F2A5-4133-9097-83C551C6B402', '-1', 'EC7098A9-2C03-4B6E-BF48-8395C78F74B7', 'News Manager', '/App_Control_Style/Nexus_News/Icons/newsbrief', 'ControlPanel', '1.0.2');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('EC7098A9-2C03-4B6E-BF48-8395C78F74B7', '9B2333C6-55F3-4A28-A162-8AC2D61362BF', 'News', 'News List', '1.0.1', true);
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('EC7098A9-2C03-4B6E-BF48-8395C78F74B7', '34E0CE1D-2163-4E8E-A2C2-846519F114BC', 'News', 'News Detail', '1.0.1', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('9B2333C6-55F3-4A28-A162-8AC2D61362BF', '97F2794C-8F8F-4C62-ADD5-1408B625DEBE', 'News List', true);
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('34E0CE1D-2163-4E8E-A2C2-846519F114BC', '97F2794C-8F8F-4C62-ADD5-1408B625DEBE', 'News Detail', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('C8AF0795-8A43-467C-8DD3-C41186E80F69', '9B2333C6-55F3-4A28-A162-8AC2D61362BF', 'News List', 'WebView', 'Nexus.Controls.News.NewsList.NewsList_WebView', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B45FBCDF-A33E-462B-A61C-0C1E3AC42F58', '9B2333C6-55F3-4A28-A162-8AC2D61362BF', 'News List Advanced', 'Advanced', 'Nexus.Controls.News.NewsList.NewsList_Advanced', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('D9099F4F-25B4-4FE5-BC4B-4B7B9448CDA2', '9B2333C6-55F3-4A28-A162-8AC2D61362BF', 'News List Editor', 'Editor', 'Nexus.Controls.News.NewsList.NewsList_Editor', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('C1E48BA5-746E-4C2C-AD74-FFB762339266', '34E0CE1D-2163-4E8E-A2C2-846519F114BC', 'News Detail', 'WebView', 'Nexus.Controls.News.NewsDetail.NewsDetail_WebView', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('48BFBDEE-26F2-471A-A1B9-30F6EC341EFD', '34E0CE1D-2163-4E8E-A2C2-846519F114BC', 'News Detail Advanced', 'Advanced', 'Nexus.Controls.News.NewsDetail.NewsDetail_Advanced', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('B2C53278-845A-4B65-B5A3-4870FF5C97BF', '34E0CE1D-2163-4E8E-A2C2-846519F114BC', 'News Detail Editor', 'Editor', 'Nexus.Controls.News.NewsDetail.NewsDetail_Editor', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('4332BEFC-F5B1-4017-B004-1F813F4EC81C', '156B3CC5-F2A5-4133-9097-83C551C6B402', 'Create News', 'Management', 'Nexus.Controls.News.Management.Management_CreateNews', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('541FB98B-F95B-4618-BD5F-BEA7DAA21995', '156B3CC5-F2A5-4133-9097-83C551C6B402', 'Manage News', 'Management', 'Nexus.Controls.News.Management.Management_ManageNews', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('60B08E61-40DA-4989-B401-81B75A619F85', '156B3CC5-F2A5-4133-9097-83C551C6B402', 'Edit News', 'ControlPanel', 'Nexus.Controls.News.ControlPanel.ControlPanel_EditNews', 'Nexus.Controls.News, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('97F2794C-8F8F-4C62-ADD5-1408B625DEBE', 'EC7098A9-2C03-4B6E-BF48-8395C78F74B7', 'News', true, false);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Items`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Items` (`Module_ItemID`, `ModuleID`, `Item_Name`) VALUES ('3A79BF21-D0DF-4825-BFB2-7F6738C12BA7', 'EC7098A9-2C03-4B6E-BF48-8395C78F74B7', 'Nexus News Item');

COMMIT;
