/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : pureinit

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2018-11-21 16:49:54
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for adminuser
-- ----------------------------
DROP TABLE IF EXISTS `adminuser`;
CREATE TABLE `adminuser` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `PassWord` varchar(255) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `HeadIcon` varchar(255) DEFAULT NULL,
  `Gender` int(1) DEFAULT NULL,
  `TelPhone` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `RoleName` varchar(50) DEFAULT NULL,
  `RoleSid` varchar(50) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of adminuser
-- ----------------------------
INSERT INTO `adminuser` VALUES ('adminuser_00000000000000000000000000000000', '2018-11-20 15:51:57', '2018-11-20 15:55:36', '0', 'admin', '670B14728AD9902AECBA32E22FA4F6BD', '超级管理员', '1', 'http://pihm5zzam.bkt.clouddn.com/e4544b55a55e443586e0ad6d1d9f5a6c.png?e=1700476476&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:QDp4SGCbdk6Oy33k07h8j4uFtGg=', '1', '&nbsp;', '&nbsp;', '超级管理员', 'role_56dad1da0fe147dd9ed9197b414196fd', '1', '&nbsp;');
INSERT INTO `adminuser` VALUES ('adminuser_8a9967e0cffe488fa9b5f1da97aecdef', '2018-11-20 18:24:07', null, '0', 'Guest', 'E10ADC3949BA59ABBE56E057F20F883E', '游客', '2', null, '1', null, null, '游客', 'role_87521bfd09ec4ceaada9697b9f1056c2', '1', null);
INSERT INTO `adminuser` VALUES ('adminuser_3faeb5b827fc4d39a599b858e1583daa', '2018-11-21 09:16:26', null, '0', 'wxy', 'E10ADC3949BA59ABBE56E057F20F883E', '吴新宇', '3', 'http://pihm5zzam.bkt.clouddn.com/04064927bd0740ea8be9994a64ad66c3.png?e=1700529374&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:EcXW04nqaser_5W0t9e5tPo0EbI=', '1', null, null, '超级管理员', 'role_56dad1da0fe147dd9ed9197b414196fd', '1', null);
INSERT INTO `adminuser` VALUES ('adminuser_19eb58c598884569982849ee1b232db5', '2018-11-21 09:16:53', null, '0', 'zl', 'E10ADC3949BA59ABBE56E057F20F883E', '张乐', '4', 'http://pihm5zzam.bkt.clouddn.com/3e741e02dcf645c884c1327edea15055.png?e=1700529402&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:gKgYZC0FkWxxSLpLw87asKfwGIE=', '1', '&nbsp;', '&nbsp;', '超级管理员', 'role_56dad1da0fe147dd9ed9197b414196fd', '1', '&nbsp;');

-- ----------------------------
-- Table structure for area
-- ----------------------------
DROP TABLE IF EXISTS `area`;
CREATE TABLE `area` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `EnCode` varchar(20) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `Sort` int(4) DEFAULT '0',
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of area
-- ----------------------------

-- ----------------------------
-- Table structure for banner
-- ----------------------------
DROP TABLE IF EXISTS `banner`;
CREATE TABLE `banner` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `ComClass` varchar(10) DEFAULT NULL,
  `ComClassSid` varchar(50) DEFAULT NULL,
  `Path` varchar(500) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Link` varchar(255) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of banner
-- ----------------------------

-- ----------------------------
-- Table structure for client
-- ----------------------------
DROP TABLE IF EXISTS `client`;
CREATE TABLE `client` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `AccountNo` varchar(50) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `Mobile` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `HeadPortrait` varchar(255) DEFAULT NULL,
  `Age` int(3) DEFAULT NULL,
  `Birthday` varchar(50) DEFAULT NULL,
  `Gender` int(1) DEFAULT NULL,
  `PassWord` varchar(50) DEFAULT NULL,
  `Token` varchar(255) DEFAULT NULL,
  `DeviceNo` varchar(255) DEFAULT NULL,
  `Lat` varchar(50) DEFAULT NULL,
  `Lng` varchar(50) DEFAULT NULL,
  `SpreadCode` varchar(50) DEFAULT NULL,
  `Integral` decimal(10,0) DEFAULT NULL,
  `Balance` decimal(10,6) DEFAULT NULL,
  `Role` varchar(50) DEFAULT NULL,
  `RoleID` varchar(50) DEFAULT NULL,
  `IdCard` varchar(18) DEFAULT NULL,
  `WechatNo` varchar(50) DEFAULT NULL,
  `Province` varchar(50) DEFAULT NULL,
  `City` varchar(50) DEFAULT NULL,
  `Region` varchar(50) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `QQNumber` varchar(50) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of client
-- ----------------------------

-- ----------------------------
-- Table structure for comclass
-- ----------------------------
DROP TABLE IF EXISTS `comclass`;
CREATE TABLE `comclass` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `Title` varchar(50) DEFAULT NULL,
  `Subtitle` varchar(50) DEFAULT NULL,
  `Sort` int(10) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  `BGImages` varchar(255) DEFAULT NULL,
  `Logo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of comclass
-- ----------------------------
INSERT INTO `comclass` VALUES ('comclass_24e925b708444195ac46d2636642ff81', '2018-11-21 12:01:13', null, '0', '香菇菌类', null, '4', 'comclass_45e7e627480c4188854c9c1ecd4866d5', '1', null, '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_3ae712f8a70846a5b1e3a100f7097d7e', '2018-11-21 15:23:48', null, '0', '轮播图分类', null, '2', '0', '1', null, '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_45e7e627480c4188854c9c1ecd4866d5', '2018-11-21 11:59:50', '2018-11-21 16:46:56', '0', '商城分类', '&nbsp;', '1', '0', '1', '&nbsp;', '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_5b32d97d578247e4b757b2b7df96dfc1', '2018-11-21 12:00:25', '2018-11-21 16:41:09', '0', '农副产品', '&nbsp;', '1', 'comclass_45e7e627480c4188854c9c1ecd4866d5', '1', '&nbsp;', '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_a8662eaf3b014f08af4c3a199816761f', '2018-11-21 15:56:29', null, '0', '普通会员', null, '1', 'comclass_b5fe1f4a9ce44d258be2b8f8e63ad1e7', '1', null, '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_b5fe1f4a9ce44d258be2b8f8e63ad1e7', '2018-11-21 15:56:19', null, '0', '会员角色', null, '3', '0', '1', null, '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_bde189f1978d499eb70359c0a8497077', '2018-11-21 12:00:47', null, '0', '蔬菜系列', '&nbsp;', '3', 'comclass_45e7e627480c4188854c9c1ecd4866d5', '1', '&nbsp;', '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_d0634cc522524b1e8d77271bdd6d0a02', '2018-11-21 12:00:34', null, '0', '水果系列', '&nbsp;', '2', 'comclass_45e7e627480c4188854c9c1ecd4866d5', '1', '&nbsp;', '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_d0f610c0ff49482f8294b0dc90ba0d0e', '2018-11-21 15:24:26', null, '0', '微信轮播图', null, '1', 'comclass_3ae712f8a70846a5b1e3a100f7097d7e', '1', null, '/Content/img/covering.png', '/Content/img/covering.png');
INSERT INTO `comclass` VALUES ('comclass_e44ad379efce4237b99b826ea46af77b', '2018-11-21 12:01:22', null, '0', '五谷杂粮', '&nbsp;', '5', 'comclass_45e7e627480c4188854c9c1ecd4866d5', '1', '&nbsp;', '/Content/img/covering.png', '/Content/img/covering.png');

-- ----------------------------
-- Table structure for deviceversion
-- ----------------------------
DROP TABLE IF EXISTS `deviceversion`;
CREATE TABLE `deviceversion` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Version` varchar(20) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Path` varchar(500) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of deviceversion
-- ----------------------------

-- ----------------------------
-- Table structure for log
-- ----------------------------
DROP TABLE IF EXISTS `log`;
CREATE TABLE `log` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `LogType` int(2) DEFAULT NULL,
  `IP` varchar(50) DEFAULT NULL,
  `Source` varchar(255) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  `CreateUser` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log
-- ----------------------------

-- ----------------------------
-- Table structure for module
-- ----------------------------
DROP TABLE IF EXISTS `module`;
CREATE TABLE `module` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `FullName` varchar(30) DEFAULT NULL,
  `Icon` varchar(30) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `Type` int(2) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `JsEvent` varchar(20) DEFAULT NULL,
  `Encode` varchar(20) DEFAULT NULL,
  `Location` int(2) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of module
-- ----------------------------
INSERT INTO `module` VALUES ('module_e090d31ce2304bb3a0511b3421a78428', '2018-11-20 17:41:25', null, '0', '角色管理', null, '2', '1', 'module_e0b01382e74341758333b18f4cb7e3f9', '/SystemManage/Role/Index', null, null, '0', '1', null);
INSERT INTO `module` VALUES ('module_1b95406413034515872ec36fed01c65e', '2018-11-20 17:42:07', null, '0', '系统管理员', null, '3', '1', 'module_e0b01382e74341758333b18f4cb7e3f9', '/SystemManage/AdminUser/Index', null, null, '0', '1', null);
INSERT INTO `module` VALUES ('module_e17060c12a2740a790e493c766f1a8c8', '2018-11-20 17:43:25', null, '0', '通用配置', 'fa fa-cog', '2', '1', '0', '&nbsp;', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_4e2c93079cf54080a08bf1d188aa5836', '2018-11-20 17:45:02', null, '0', '系统日志', null, '1', '1', 'module_e17060c12a2740a790e493c766f1a8c8', '/SystemManage/Log/Index', null, null, '0', '1', null);
INSERT INTO `module` VALUES ('module_a94a593cdb8d49d7ba513915cf7a3113', '2018-11-20 17:45:19', null, '0', '添加角色', '&nbsp;', '1', '2', 'module_e090d31ce2304bb3a0511b3421a78428', '/SystemManage/Role/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_2023d3c4ed3c409b9f0585ad505a08c3', '2018-11-20 17:45:19', null, '0', '编辑角色', '&nbsp;', '2', '2', 'module_e090d31ce2304bb3a0511b3421a78428', '/SystemManage/Role/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_e0b01382e74341758333b18f4cb7e3f9', '2018-11-20 17:09:36', '2018-11-21 15:16:04', '0', '权限配置', 'fa fa-user', '1', '1', '0', '&nbsp;', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_300b1d70eb154ec19847d2256a2c3e91', '2018-11-20 17:10:32', null, '0', '菜单管理', 'fa fa-th', '1', '1', 'module_e0b01382e74341758333b18f4cb7e3f9', '/SystemManage/Module/Index', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_899edbec6e124959887f9989c3f4d9da', '2018-11-20 17:17:17', null, '0', '添加菜单', null, '1', '2', 'module_300b1d70eb154ec19847d2256a2c3e91', '/SystemManage/Module/Form', 'btn_add()', 'NF-add', '1', '1', null);
INSERT INTO `module` VALUES ('module_f451056256894947a1ffe0addeb0c6b2', '2018-11-20 17:27:52', null, '0', '编辑菜单', '&nbsp;', '2', '2', 'module_300b1d70eb154ec19847d2256a2c3e91', '/SystemManage/Module/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_6f316c2bf44749d6b1ed37b5f19f722d', '2018-11-20 17:27:56', null, '0', '删除菜单', '&nbsp;', '3', '2', 'module_300b1d70eb154ec19847d2256a2c3e91', '/SystemManage/Module/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_1483316209f54668a063a50d9d6bbe8b', '2018-11-20 17:27:56', null, '0', '按钮管理', '&nbsp;', '4', '2', 'module_300b1d70eb154ec19847d2256a2c3e91', '/SystemManage/Module/BtnList', 'btn_modulebutton()', 'NF-modulebutton', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_3b3811b542d744c78022ef58e1fb03c2', '2018-11-20 17:45:19', null, '0', '删除角色', '&nbsp;', '3', '2', 'module_e090d31ce2304bb3a0511b3421a78428', '/SystemManage/Role/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_399146ec5f094a69ac8c8046f2b21183', '2018-11-20 17:46:22', null, '0', '添加管理员', '&nbsp;', '1', '2', 'module_1b95406413034515872ec36fed01c65e', '/SystemManage/AdminUser/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_29f9d33671354e258f474a567e85f330', '2018-11-20 17:46:22', null, '0', '编辑管理员', '&nbsp;', '2', '2', 'module_1b95406413034515872ec36fed01c65e', '/SystemManage/AdminUser/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_90374d3efe124b48abec0c1567eef4e6', '2018-11-20 17:46:22', null, '0', '删除管理员', '&nbsp;', '3', '2', 'module_1b95406413034515872ec36fed01c65e', '/SystemManage/AdminUser/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_b765b4600d6d420692e2c30aed43bdcb', '2018-11-20 17:47:10', null, '0', '清理日志', '&nbsp;', '1', '2', 'module_4e2c93079cf54080a08bf1d188aa5836', '/SystemManage/Log/RemoveLog', 'btn_removelog()', 'NF-removelog', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_4b255123f69e4bee9dd4ebd99d8c426e', '2018-11-20 18:36:07', null, '0', '重置密码', null, '4', '2', 'module_1b95406413034515872ec36fed01c65e', '/SystemManage/AdminUser/ResetPwd', 'btn_reset()', 'NF-reset', '2', '1', null);
INSERT INTO `module` VALUES ('module_761f591d528749829d4046d68c1ab209', '2018-11-21 10:39:30', null, '0', '综合分类', null, '2', '1', 'module_e17060c12a2740a790e493c766f1a8c8', '/PublicManage/ComClass/Index', null, null, '0', '1', null);
INSERT INTO `module` VALUES ('module_dd1c35cde42e40cb9f03f6348847ef3d', '2018-11-21 10:40:17', null, '0', '行政区域', null, '3', '1', 'module_e17060c12a2740a790e493c766f1a8c8', '/PublicManage/Area/Index', null, null, '0', '1', null);
INSERT INTO `module` VALUES ('module_f1b532ad70da4fdc9fa61d8efe4954c4', '2018-11-21 10:40:59', null, '0', '参数设置', '&nbsp;', '4', '1', 'module_e17060c12a2740a790e493c766f1a8c8', '/PublicManage/SysConfig/Index', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_8aa3e8e46a70401f91876ded50bc7fc4', '2018-11-21 10:41:19', null, '0', '添加分类', '&nbsp;', '1', '2', 'module_761f591d528749829d4046d68c1ab209', '/PublicManage/ComClass/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_e321346330c54a58b4ee46cbb6363e9c', '2018-11-21 10:41:19', null, '0', '编辑分类', '&nbsp;', '2', '2', 'module_761f591d528749829d4046d68c1ab209', '/PublicManage/ComClass/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_fc0bf4efca9746198429b738dccb2052', '2018-11-21 10:41:19', null, '0', '删除分类', '&nbsp;', '3', '2', 'module_761f591d528749829d4046d68c1ab209', '/PublicManage/ComClass/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_f40c4e935fa147288435abac473eddbc', '2018-11-21 10:42:30', null, '0', '添加区域', '&nbsp;', '1', '2', 'module_dd1c35cde42e40cb9f03f6348847ef3d', '/PublicManage/Area/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_ebcf6979dbb84cba85b7b64b111622dc', '2018-11-21 10:42:30', null, '0', '编辑区域', '&nbsp;', '2', '2', 'module_dd1c35cde42e40cb9f03f6348847ef3d', '/PublicManage/Area/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_d5190ba62eec45da89a161ea6e0442c6', '2018-11-21 10:42:30', null, '0', '删除区域', '&nbsp;', '3', '2', 'module_dd1c35cde42e40cb9f03f6348847ef3d', '/PublicManage/Area/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_288baa83a094480da6187e2224b23b7f', '2018-11-21 10:43:13', null, '0', '添加配置', '&nbsp;', '1', '2', 'module_f1b532ad70da4fdc9fa61d8efe4954c4', '/PublicManage/SysConfig/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_42eeff84aa4d4f85af12c9e7ae87ce89', '2018-11-21 10:43:13', null, '0', '编辑配置', '&nbsp;', '2', '2', 'module_f1b532ad70da4fdc9fa61d8efe4954c4', '/PublicManage/SysConfig/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_d3edbf7b9a354d59ba01c7be3ff4e233', '2018-11-21 10:43:13', null, '0', '删除配置', '&nbsp;', '3', '2', 'module_f1b532ad70da4fdc9fa61d8efe4954c4', '/PublicManage/SysConfig/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_fee9de156a89426cbe24b9eee0e5a62b', '2018-11-21 15:17:17', '2018-11-21 15:21:10', '0', '公共接口', 'fa fa-road', '3', '1', '0', '&nbsp;', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_ccfbda6958834066911527ec36bd96f0', '2018-11-21 15:17:37', '2018-11-21 15:18:12', '0', '轮播图管理', '&nbsp;', '1', '1', 'module_fee9de156a89426cbe24b9eee0e5a62b', '/PubAppManage/Banner/Index', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_dc22c8b44d884395ace6d9c0df3b12ac', '2018-11-21 15:17:50', '2018-11-21 15:18:26', '0', '会员管理', '&nbsp;', '2', '1', 'module_fee9de156a89426cbe24b9eee0e5a62b', '/PubAppManage/Client/Index', '&nbsp;', '&nbsp;', '0', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_1dfe5723a7d847bfa67116b107a0f8d5', '2018-11-21 15:18:34', '2018-11-21 15:19:21', '0', '添加轮播图', '&nbsp;', '1', '2', 'module_ccfbda6958834066911527ec36bd96f0', '/PubAppManage/Banner/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_58a1bc9a48384cd1a4654a6d2e46f935', '2018-11-21 15:18:34', '2018-11-21 15:19:36', '0', '编辑轮播图', '&nbsp;', '2', '2', 'module_ccfbda6958834066911527ec36bd96f0', '/PubAppManage/Banner/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_3850fb735ffe47e0bd6ea97122aced08', '2018-11-21 15:18:34', '2018-11-21 15:19:42', '0', '删除轮播图', '&nbsp;', '3', '2', 'module_ccfbda6958834066911527ec36bd96f0', '/PubAppManage/Banner/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_6ae70c119dfb487bacd5299a75be5dab', '2018-11-21 15:19:52', '2018-11-21 15:20:03', '0', '添加会员', '&nbsp;', '1', '2', 'module_dc22c8b44d884395ace6d9c0df3b12ac', '/PubAppManage/Client/Form', 'btn_add()', 'NF-add', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_3332ea7443094877a45e1882a62cfee6', '2018-11-21 15:19:52', '2018-11-21 15:20:10', '0', '编辑会员', '&nbsp;', '2', '2', 'module_dc22c8b44d884395ace6d9c0df3b12ac', '/PubAppManage/Client/Form', 'btn_edit()', 'NF-edit', '2', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_3004d7632e194d2c8335b3f50a211c14', '2018-11-21 15:19:52', '2018-11-21 15:20:18', '0', '删除会员', '&nbsp;', '3', '2', 'module_dc22c8b44d884395ace6d9c0df3b12ac', '/PubAppManage/Client/DeleteForm', 'btn_delete()', 'NF-delete', '2', '1', '&nbsp;');

-- ----------------------------
-- Table structure for news
-- ----------------------------
DROP TABLE IF EXISTS `news`;
CREATE TABLE `news` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `SubTitle` varchar(50) DEFAULT NULL,
  `Tag` varchar(20) DEFAULT NULL,
  `CoverImg` varchar(500) DEFAULT NULL,
  `ComClass` varchar(10) DEFAULT NULL,
  `ComClassSid` varchar(50) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Author` varchar(10) DEFAULT NULL,
  `Desc` varchar(255) DEFAULT NULL,
  `Content` text,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of news
-- ----------------------------

-- ----------------------------
-- Table structure for organize
-- ----------------------------
DROP TABLE IF EXISTS `organize`;
CREATE TABLE `organize` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Lead` varchar(30) DEFAULT NULL,
  `TelPhone` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of organize
-- ----------------------------

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `FullNameCN` varchar(50) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('role_56dad1da0fe147dd9ed9197b414196fd', '2018-11-20 18:16:59', '0', null, '超级管理员', 'GM', '1', '1', '&nbsp;');
INSERT INTO `role` VALUES ('role_87521bfd09ec4ceaada9697b9f1056c2', '2018-11-20 18:21:57', '0', null, '游客', 'Guest', '2', '1', '&nbsp;');

-- ----------------------------
-- Table structure for roleauthorize
-- ----------------------------
DROP TABLE IF EXISTS `roleauthorize`;
CREATE TABLE `roleauthorize` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `RoleId` varchar(50) DEFAULT NULL,
  `ModuleId` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of roleauthorize
-- ----------------------------
INSERT INTO `roleauthorize` VALUES ('roleauthor_e87eb697f94a4b3cba276c9a7e126dbb', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_1483316209f54668a063a50d9d6bbe8b');
INSERT INTO `roleauthorize` VALUES ('roleauthor_10fcf81b8ca14b0abb785c8e528e61cd', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_90374d3efe124b48abec0c1567eef4e6');
INSERT INTO `roleauthorize` VALUES ('roleauthor_5c7e1de279fd458990793cd8f9fd3c0b', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_3b3811b542d744c78022ef58e1fb03c2');
INSERT INTO `roleauthorize` VALUES ('roleauthor_e3cfbf2c931c4f3ab644a0d50e60b02a', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_6f316c2bf44749d6b1ed37b5f19f722d');
INSERT INTO `roleauthorize` VALUES ('roleauthor_33e3cebf96514cc8b5c7c3534ee14399', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_1b95406413034515872ec36fed01c65e');
INSERT INTO `roleauthorize` VALUES ('roleauthor_4ec81726a4734324aef1fcf4fbf22274', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_29f9d33671354e258f474a567e85f330');
INSERT INTO `roleauthorize` VALUES ('roleauthor_47615b60c0fa476f881bff8a9613ab88', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_f451056256894947a1ffe0addeb0c6b2');
INSERT INTO `roleauthorize` VALUES ('roleauthor_cc3485da6d194ca1a1952a3ac8fd2498', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_2023d3c4ed3c409b9f0585ad505a08c3');
INSERT INTO `roleauthorize` VALUES ('roleauthor_bc7ddd9517164840a86666ce06007d6b', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_e17060c12a2740a790e493c766f1a8c8');
INSERT INTO `roleauthorize` VALUES ('roleauthor_e71f7afd79cc4c30973d6a67de59b8b0', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_e090d31ce2304bb3a0511b3421a78428');
INSERT INTO `roleauthorize` VALUES ('roleauthor_f2d5a8764da446f6a84ff6cba3b12a83', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_b765b4600d6d420692e2c30aed43bdcb');
INSERT INTO `roleauthorize` VALUES ('roleauthor_6c424682d85d42a3822cade2779409b0', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_399146ec5f094a69ac8c8046f2b21183');
INSERT INTO `roleauthorize` VALUES ('roleauthor_340ca1a2785c423e8803cbeaee284f3a', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_899edbec6e124959887f9989c3f4d9da');
INSERT INTO `roleauthorize` VALUES ('roleauthor_ea5775923fd241a885fd60353791e5bb', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_300b1d70eb154ec19847d2256a2c3e91');
INSERT INTO `roleauthorize` VALUES ('roleauthor_f7d8183222914046953950071264032f', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_e0b01382e74341758333b18f4cb7e3f9');
INSERT INTO `roleauthorize` VALUES ('roleauthor_81a07489c71943eda27ecd852bbac51a', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_a94a593cdb8d49d7ba513915cf7a3113');
INSERT INTO `roleauthorize` VALUES ('roleauthor_b9865b5232fa4fb98a1d8a98acdd77cc', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_4e2c93079cf54080a08bf1d188aa5836');
INSERT INTO `roleauthorize` VALUES ('roleauthor_a8064b0b2a1f4cd1b558bcd3389d16cf', '2018-11-20 18:23:03', '0', null, '0', 'role_87521bfd09ec4ceaada9697b9f1056c2', 'module_300b1d70eb154ec19847d2256a2c3e91');
INSERT INTO `roleauthorize` VALUES ('roleauthor_84cd11bd8a204b7b9fab79116038e006', '2018-11-20 18:23:03', '0', null, '0', 'role_87521bfd09ec4ceaada9697b9f1056c2', 'module_e0b01382e74341758333b18f4cb7e3f9');
INSERT INTO `roleauthorize` VALUES ('roleauthor_4c100192095648018056ef32b5619daa', '2018-11-20 18:23:03', '0', null, '0', 'role_87521bfd09ec4ceaada9697b9f1056c2', 'module_4e2c93079cf54080a08bf1d188aa5836');
INSERT INTO `roleauthorize` VALUES ('roleauthor_496c43f916d241c5afb1adfab8a98b77', '2018-11-20 18:23:03', '0', null, '0', 'role_87521bfd09ec4ceaada9697b9f1056c2', 'module_899edbec6e124959887f9989c3f4d9da');
INSERT INTO `roleauthorize` VALUES ('roleauthor_f5013a0b3abf42ce98868e32bd8394d5', '2018-11-20 18:23:03', '0', null, '0', 'role_87521bfd09ec4ceaada9697b9f1056c2', 'module_b765b4600d6d420692e2c30aed43bdcb');
INSERT INTO `roleauthorize` VALUES ('roleauthor_92ede5ead1114285851d548bc1dba4ca', '2018-11-20 18:23:03', '0', null, '0', 'role_87521bfd09ec4ceaada9697b9f1056c2', 'module_e17060c12a2740a790e493c766f1a8c8');
INSERT INTO `roleauthorize` VALUES ('roleauthor_853f5bebdc3845fd8290349098e83aac', '2018-11-21 09:15:12', '0', null, '0', 'role_56dad1da0fe147dd9ed9197b414196fd', 'module_4b255123f69e4bee9dd4ebd99d8c426e');

-- ----------------------------
-- Table structure for systemconfig
-- ----------------------------
DROP TABLE IF EXISTS `systemconfig`;
CREATE TABLE `systemconfig` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `IsDelete` tinyint(1) DEFAULT NULL,
  `EditDate` datetime DEFAULT NULL,
  `Title` varchar(50) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Cmd` varchar(50) DEFAULT NULL,
  `Value` decimal(10,5) DEFAULT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of systemconfig
-- ----------------------------

-- ----------------------------
-- Function structure for GetAreaChildList
-- ----------------------------
DROP FUNCTION IF EXISTS `GetAreaChildList`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetAreaChildList`(Pid varchar(50)) RETURNS varchar(20000) CHARSET utf8
BEGIN   
DECLARE str varchar(20000);  
DECLARE cid varchar(10000);   
SET str = '$';   
SET cid = Pid;   
WHILE cid is not null DO   
    SET str = concat(str, ',', cid);
    SELECT group_concat(Sid) INTO cid FROM area where FIND_IN_SET(ParentId, cid) > 0;   
END WHILE;   
RETURN str;   
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for GetComClassChildIist
-- ----------------------------
DROP FUNCTION IF EXISTS `GetComClassChildIist`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetComClassChildIist`(Pid varchar(50)) RETURNS varchar(20000) CHARSET utf8
BEGIN   
DECLARE str varchar(20000);  
DECLARE cid varchar(10000);   
SET str = '$';   
SET cid = Pid;   
WHILE cid is not null DO   
    SET str = concat(str, ',', cid);
    SELECT group_concat(Sid) INTO cid FROM comclass where FIND_IN_SET(ParentId, cid) > 0;   
END WHILE;   
RETURN str;   
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for GetModuleChildList
-- ----------------------------
DROP FUNCTION IF EXISTS `GetModuleChildList`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetModuleChildList`(Pid varchar(50)) RETURNS varchar(20000) CHARSET utf8
BEGIN   
DECLARE str varchar(20000);  
DECLARE cid varchar(10000);   
SET str = '$';   
SET cid = Pid;   
WHILE cid is not null DO   
    SET str = concat(str, ',', cid);   
    SELECT group_concat(Sid) INTO cid FROM Module where FIND_IN_SET(ParentId, cid) > 0;   
END WHILE;   
RETURN str;   
END
;;
DELIMITER ;

-- ----------------------------
-- Function structure for GetSysCfgChildList
-- ----------------------------
DROP FUNCTION IF EXISTS `GetSysCfgChildList`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `GetSysCfgChildList`(Pid varchar(50)) RETURNS varchar(20000) CHARSET utf8
BEGIN   
DECLARE str varchar(20000);  
DECLARE cid varchar(10000);   
SET str = '$';   
SET cid = Pid;   
WHILE cid is not null DO   
    SET str = concat(str, ',', cid);
    SELECT group_concat(Sid) INTO cid FROM SystemConfig where FIND_IN_SET(ParentId, cid) > 0;   
END WHILE;   
RETURN str;   
END
;;
DELIMITER ;
