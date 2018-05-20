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
INSERT INTO `NexusCore_Modules` (`ModuleID`, `Module_Name`, `Module_Icon`, `Module_Type`, `Module_Version`, `Release_Date`, `Author`, `Description`) VALUES ('243A64A8-095F-4E33-982B-EFA15F684312', 'Web User Controls', '/App_Control_Style/Web_User_Controls/Icons/web_user_control', 'System Addon', '1.0.0', '2010-09-20', 'e2Tech.Ltd', 'Web User Controls');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Components`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Components` (`ComponentID`, `Parent_ComponentID`, `ModuleID`, `Component_Name`, `Component_Icon`, `Component_Type`, `Component_Version`) VALUES ('3862AEBA-6E83-4114-B62E-BCC36601239D', '-1', '243A64A8-095F-4E33-982B-EFA15F684312', 'Customer Controls', '/App_Control_Style/Web_User_Controls/Icons/customer_control', 'Addon', '1.0.0');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Options`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Options` (`ModuleID`, `ComponentID`, `Module_Name`, `Component_Name`, `Component_Version`, `IsActive`) VALUES ('243A64A8-095F-4E33-982B-EFA15F684312', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Web User Controls', 'Customer Control', '1.0.0', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Tools`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Tools` (`ComponentID`, `GroupID`, `Tool_Name`, `IsActive`) VALUES ('3862AEBA-6E83-4114-B62E-BCC36601239D', 'CFFCAA1E-BC12-4ED5-878A-9A26455FFCFA', 'Customer Control', true);

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Component_Controls`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('8FFB3379-32A6-4445-814B-03B36952A2A7', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Customer Control', 'WebView', 'Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_WebView', 'Nexus.Controls.WebUserControl, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('C8EDE421-29CF-4DCB-B383-4C08EEA44269', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Customer Control Advanced', 'Advanced', 'Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_Advanced', 'Nexus.Controls.WebUserControl, Culture=neutral, PublicKeyToken=null');
INSERT INTO `NexusCore_Component_Controls` (`ControlID`, `ComponentID`, `Control_Name`, `Control_Type`, `Class_Name`, `Assembly_Name`) VALUES ('33B48477-53A9-4563-998D-E85AEEA509E7', '3862AEBA-6E83-4114-B62E-BCC36601239D', 'Customer Control Editor', 'Editor', 'Nexus.Controls.WebUserControls.CustomerControl.CustomerControl_Editor', 'Nexus.Controls.WebUserControl, Culture=neutral, PublicKeyToken=null');

COMMIT;

-- -----------------------------------------------------
-- Data for table `e2CMS`.`NexusCore_Module_Toolbox_Groups`
-- -----------------------------------------------------
SET AUTOCOMMIT=0;
USE `e2CMS`;
INSERT INTO `NexusCore_Module_Toolbox_Groups` (`GroupID`, `ModuleID`, `Group_Name`, `IsDefault`, `IsOpened`) VALUES ('CFFCAA1E-BC12-4ED5-878A-9A26455FFCFA', '243A64A8-095F-4E33-982B-EFA15F684312', 'Web User Controls', true, true);

COMMIT;
