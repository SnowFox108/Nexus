SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusUser_Users`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;

INSERT INTO `NexusUser_Users` (`UserID`, `UserName`, `Email`, `UserPass`, `CreateDate`, `CreateIPaddress`) VALUES (1, 'Administrator', 'default@domain.com', '1234567', '2011-03-21 00:00:00', '127.0.0.1');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusUser_UserInGroups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;

INSERT INTO `NexusUser_UserInGroups` (`RelationID`, `UserID`, `UserGroupID`) VALUES (1, 1, 'B117D66E-3A2F-45b9-8329-2119426F9311');

COMMIT;

