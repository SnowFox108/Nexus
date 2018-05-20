SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusUser_UserGroups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('522BF6CC-7095-4e38-82F0-B21A0CD85255', 'Guests', 1, 'as know as everyone', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('9C3C4A1F-1F78-4946-9D79-F4D247072C54', 'Registered Users', 2, 'Normal User', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('30E245C7-9D7F-4649-911C-CC6313076830', 'Users Awaiting Email Confirmation', 3, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('2DF310C3-81C5-4087-9CEC-3F1803AB1213', 'Users Awaiting Moderation', 4, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('70039070-F69E-431b-9B05-46756BC65636', 'Super Moderators', 5, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('B117D66E-3A2F-45b9-8329-2119426F9311', 'Administrators', 6, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('5DACAE1C-32B9-4c16-983B-13CD74B7EB64', 'Moderators', 7, '', 1);
INSERT INTO `NexusUser_UserGroups` (`UserGroupID`, `UserGroup_Name`, `SortOrder`, `Description`, `IsSystemGroup`) VALUES ('8C361793-7A9E-4a6c-BEF8-ACCBDB6A1931', 'System AI', 8, '', 1);

COMMIT;
