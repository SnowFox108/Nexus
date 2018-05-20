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
