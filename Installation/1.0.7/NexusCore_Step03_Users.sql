SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Table `e2CMS`.`NexusUser_Users`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `e2CMS`.`NexusUser_Users` (
  `UserID` INT(10) NOT NULL AUTO_INCREMENT ,
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
  `UserID` INT(10) NOT NULL ,
  `UserGroupID` VARCHAR(36) NOT NULL ,
  PRIMARY KEY (`RelationID`, `UserID`, `UserGroupID`) )
ENGINE = InnoDB;



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
