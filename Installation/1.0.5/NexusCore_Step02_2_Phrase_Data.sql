-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.5.9


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema e2cms
--

CREATE DATABASE IF NOT EXISTS e2cms;
USE e2cms;

--
-- Dumping data for table `nexuscore_phrases`
--

/*!40000 ALTER TABLE `nexuscore_phrases` DISABLE KEYS */;
INSERT INTO `nexuscore_phrases` (`Language`,`VarName`,`FieldName`,`PhraseName`,`PhraseValue`,`SortOrder`,`ModuleID`) VALUES 
 ('0','NexusCore_HomepageID','NexusCore setting',NULL,'0BB9B04795A54871851FC6181936E1C9',0,'NexusCore'),
 ('0','NexusCore_HomeSwitch','NexusCore setting',NULL,'True',0,'NexusCore'), 
 ('0','NexusCore_Version','NexusCore setting',NULL,'1.0.5',0,'NexusCore'),  
 ('0','NexusCore_Email_MailFrom_Default','Email setting',NULL,'service@e2tech.co.uk',0,'NexusCore'),
 ('0','NexusCore_Email_SMTP','Email setting',NULL,'localhost',0,'NexusCore'),
 ('0','NexusCore_File_All_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_All_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_All_Types','NexusCore Files setting',NULL,'*.*',0,'NexusCore'),
 ('0','NexusCore_File_All_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_All_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Documents_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Documents_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Documents_Types','NexusCore Files setting',NULL,'*.doc,*.docx,*.pdf',0,'NexusCore'),
 ('0','NexusCore_File_Documents_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Documents_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Image_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Image_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Image_Types','NexusCore Files setting',NULL,'*.gif,*.jpg,*.jpeg,*.png',0,'NexusCore'),
 ('0','NexusCore_File_Image_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Image_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Media_DeletePaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Media_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Media_Types','NexusCore Files setting',NULL,'*.swf',0,'NexusCore'),
 ('0','NexusCore_File_Media_UploadPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Media_ViewPaths','NexusCore Files setting',NULL,'~/User_Files',0,'NexusCore'),
 ('0','NexusCore_File_Templates_DeletePaths','NexusCore Files setting',NULL,'~/App_Template,~/App_Themes',0,'NexusCore'),
 ('0','NexusCore_File_Templates_MaxUploadFileSize','NexusCore Files setting',NULL,'2097152',0,'NexusCore'),
 ('0','NexusCore_File_Templates_Types','NexusCore Files setting',NULL,'*.*',0,'NexusCore'),
 ('0','NexusCore_File_Templates_UploadPaths','NexusCore Files setting',NULL,'~/App_Template,~/App_Themes',0,'NexusCore'),
 ('0','NexusCore_File_Templates_ViewPaths','NexusCore Files setting',NULL,'~/App_Template,~/App_Themes',0,'NexusCore'),
 ('0','NexusCore_LivePage_ToolBar','javascript',NULL,'$(document).ready(function(){\r\n	$(\".nexusCore_toolPanel_trigger\").click(function(){\r\n		$(\".nexusCore_slidingOut_toolPanel\").toggle(\"fast\");\r\n		$(this).toggleClass(\"active\");\r\n		return false;\r\n	});\r\n});',0,'NexusCore'),
 ('0','NexusCore_PageEditor_Dock','javascript','','        // Dock Section\r\n        var isNodeDragged = false;\r\n        //parameter can be dock or treeNode   \r\n        Telerik.Web.UI.RadDockZone.prototype._showPlaceholder = function (obj, location) {\r\n            if (Object.getTypeName(obj) == \"Telerik.Web.UI.RadTreeNode\") {\r\n                isNodeDragged = true;\r\n                var node = obj;\r\n                this._repositionPlaceholder(node.get_element(), location);\r\n                var placeholderStyle = this._placeholder.style;\r\n                placeholderStyle.height = \"30px\";\r\n                placeholderStyle.width = \"100%\";\r\n                placeholderStyle.display = \"block\";\r\n                isNodeDragged = false;\r\n            }\r\n            else {\r\n                var dock = obj;\r\n                this._repositionPlaceholder(dock.get_element(), location);\r\n                var dockBounds = dock._getBoundsWithBorderAndMargin();\r\n                var placeholderMargin = dock._getMarginBox(this._placeholder);\r\n                var placeholderBorder = dock._getBorderBox(this._placeholder);\r\n                var horizontal = this.get_isHorizontal();\r\n                var placeholderStyle = this._placeholder.style;\r\n                placeholderStyle.height = dockBounds.height - (placeholderMargin.vertical + placeholderBorder.vertical) + \"px\";\r\n                placeholderStyle.width = this.get_fitDocks() && !horizontal ? \"100%\" : dockBounds.width - (placeholderMargin.horizontal + placeholderBorder.horizontal) + \"px\";\r\n                placeholderStyle.display = \"block\";\r\n            }\r\n        }\r\n\r\n        Telerik.Web.UI.RadDockZone.prototype._repositionPlaceholder = function (dock_element, location)//TEKI: Add location\r\n        {\r\n            //fix TreeNode drag   \r\n            if (isNodeDragged == true) {\r\n                location = new Sys.UI.Point(currentTreeView._mousePos.x, currentTreeView._mousePos.y);\r\n            }\r\n            //end fix   \r\n\r\n            var nearestChild = this._findItemAt(location, dock_element);\r\n\r\n            var zone_element = this.get_element();\r\n\r\n            if (null == nearestChild) {\r\n                //Bug fix: ID 9516\r\n                // _clearElement must be after all docks and _placeholder\r\n                zone_element.insertBefore(this._placeholder, this._clearElement);\r\n            }\r\n            else {\r\n                if (nearestChild.previousSibling != this._placeholder) {\r\n                    zone_element.insertBefore(this._placeholder, nearestChild);\r\n                }\r\n            }\r\n            //GET placeholder position   \r\n            for (var i = 0; i < zone_element.childNodes.length; i++) {\r\n                if (zone_element.childNodes[i] == this._placeholder) {\r\n                    var currentPos = i;\r\n                    var diff = 0;\r\n                    if (!navigator.appName.match(\"Microsoft Internet Explorer\")) {\r\n                        diff++;\r\n                    }\r\n                    document.title = currentPos - diff;\r\n                    $get(\'ctl00_currentPlaceholderPosition\').value = currentPos - diff;\r\n                }\r\n            }\r\n            //end Get \r\n        }         \r\n\r\n',0,'NexusCore'),
 ('0','NexusCore_PageEditor_PoPWindow','javascript','','            function Show_ControlManager(paraCommand) {\r\n                var oWnd = window.radopen(paraCommand, \'RadWindow_ControlManager\');\r\n                oWnd.add_close(OnClientClose);\r\n            }\r\n  \r\n            function OnClientClose(oWnd) {\r\n                oWnd.setUrl(\'about:blank\'); // Sets url to blank \r\n                oWnd.remove_close(OnClientClose); //remove the close handler - it will be set again on the next opening \r\n            }\r\n\r\n            function refreshControl(arg) {\r\n            //    $find(\'<%= Get_RadAjaxManager_ClientID() %>\').ajaxRequest(arg);\r\n                $find(\'ctl00_RadAjaxManager_ControlManger\').ajaxRequest(arg);\r\n            }',0,'NexusCore');
/*!40000 ALTER TABLE `nexuscore_phrases` ENABLE KEYS */;
