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
