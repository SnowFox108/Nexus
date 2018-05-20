SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL';

CREATE SCHEMA IF NOT EXISTS `e2CMS` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `e2CMS`;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Props`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Props` (`Page_PropertyID`, `PageIndexID`, `IsOnMenu`, `IsOnNavigator`, `IsPrivacy_Inherited`, `IsAttribute_Inherited`, `IsTemplate_Inherited`, `IsSSL`) VALUES (1, '-1', 1, 0, 0, 0, 0, 0);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Attributes`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Attributes` (`Page_AttributeID`, `PageIndexID`, `Page_Title`, `Page_Keyword`, `Page_Description`) VALUES (1, '-1', '', '', '');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Categories`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (1, 'Lived Pages', True);
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (2, 'Inactived Pages', True);
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (3, 'Drafts', False);
INSERT INTO `NexusCore_Page_Categories` (`Page_CategoryID`, `Name`, `IsTreeView`) VALUES (4, 'Deleted Pages', False);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Categories`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Categories` (`CategoryID`, `Parent_CategoryID`, `Category_Name`) VALUES ('73B48270-1307-4A74-89E5-52143E82B9A9', '-1', 'Uncategorized');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Templates`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Templates` (`Page_TemplateID`, `PageIndexID`, `MasterPageIndexID`) VALUES (1, '-1', '82C9EF99930741CCB76E1B4D4A77D0D9');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_Privacies`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_Privacies` (`PrivacyID`, `PageIndexID`, `UserGroupID`, `Allow_View`, `Allow_Create`, `Allow_Modify`, `Allow_Delete`, `Allow_Rollback`, `Allow_ChangePermissions`, `Allow_Approve`, `Allow_Publish`, `Allow_DesignMode`) VALUES (1, '-1', 'B117D66E-3A2F-45b9-8329-2119426F9311', 1, 1, 1, 1, 1, 1, 1, 1, 1);
INSERT INTO `NexusCore_Page_Privacies` (`PrivacyID`, `PageIndexID`, `UserGroupID`, `Allow_View`, `Allow_Create`, `Allow_Modify`, `Allow_Delete`, `Allow_Rollback`, `Allow_ChangePermissions`, `Allow_Approve`, `Allow_Publish`, `Allow_DesignMode`) VALUES (2, '-1', '522BF6CC-7095-4e38-82F0-B21A0CD85255', 1, 0, 0, 0, 0, 0, 0, 0, 0);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Page_PrivacyURL`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Page_PrivacyURL` (`PrivacyID`, `PageIndexID`, `ReturnURL`) VALUES (1, '-1', '/');

COMMIT;
