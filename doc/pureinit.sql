/*
Navicat MySQL Data Transfer

Source Server         : localhost
Source Server Version : 50720
Source Host           : localhost:3306
Source Database       : pureinit

Target Server Type    : MYSQL
Target Server Version : 50720
File Encoding         : 65001

Date: 2018-08-10 18:47:04
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for adminuser
-- ----------------------------
DROP TABLE IF EXISTS `adminuser`;
CREATE TABLE `adminuser` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Account` varchar(255) DEFAULT NULL,
  `PassWord` varchar(255) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `HeadIcon` varchar(255) DEFAULT NULL,
  `Gender` int(1) DEFAULT NULL,
  `Birthday` datetime DEFAULT NULL,
  `TelPhone` varchar(50) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `OrganizeName` varchar(50) DEFAULT NULL,
  `OrganizeSid` varchar(50) DEFAULT NULL,
  `RoleName` varchar(50) DEFAULT NULL,
  `RoleSid` varchar(50) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of adminuser
-- ----------------------------
INSERT INTO `adminuser` VALUES ('adminuser_kajdawkdpoakw', '2018-08-06 17:28:00', 'admin', '39DFA55283318D31AFE5A3FF4A0E3253E2045E43', '超级管理员', '1', 'http://p8pmfndis.bkt.clouddn.com/wy8gmqjuaz3xggzt.png?e=1691380644&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:KQeIjxB_pFg8gKv5UVujpAe-8EQ=', '1', '0001-01-01 00:00:00', '&nbsp;', '&nbsp;', 'Company', 'organize_tIqwSsIjT8UqHTbnseLXQEhRjC1rVpQQ', '管理员一号', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1', '&nbsp;');
INSERT INTO `adminuser` VALUES ('adminuser_kWj8MpD0a2wdpg3EWAQsxQ49HaFGX9BB', '2018-08-07 12:00:06', 'test01', '7C4A8D09CA3762AF61E59520943DC26494F8941B', '测试一号', '2', 'http://p8pmfndis.bkt.clouddn.com/hih5biijgrynfklv.png?e=1691391425&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:80uzrofdH0PLIWvAbiAmcHPQD9s=', '1', '0001-01-01 00:00:00', '&nbsp;', '&nbsp;', 'Company', 'organize_tIqwSsIjT8UqHTbnseLXQEhRjC1rVpQQ', '管理员一号', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1', '&nbsp;');

-- ----------------------------
-- Table structure for area
-- ----------------------------
DROP TABLE IF EXISTS `area`;
CREATE TABLE `area` (
  `Sid` varchar(50) NOT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Layers` int(11) DEFAULT '0',
  `EnCode` varchar(20) DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `SimpleSpelling` varchar(50) DEFAULT NULL,
  `SortCode` int(11) DEFAULT '0',
  `EnabledMark` tinyint(1) DEFAULT '0',
  `CreateDate` datetime DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of area
-- ----------------------------
INSERT INTO `area` VALUES ('area_L3Puuz7SRjWUzc69oW1RcR6kS47jeDnE', '0', '0', 'China', '中国', 'CN', '0', '1', '2018-08-07 15:26:56', '&nbsp;');
INSERT INTO `area` VALUES ('area_Z0R9haBa0vDCNlxb4y3XdF2UJacgUljP', 'area_L3Puuz7SRjWUzc69oW1RcR6kS47jeDnE', '0', 'Shan', '陕西省', '秦', '1', '1', '2018-08-07 15:29:20', null);
INSERT INTO `area` VALUES ('area_xMa1zEdrAcpKLixaEWInsuXYiBwm9QjK', 'area_Z0R9haBa0vDCNlxb4y3XdF2UJacgUljP', '0', '&nbsp;', '西安市', '&nbsp;', '2', '1', '2018-08-07 15:30:45', '&nbsp;');
INSERT INTO `area` VALUES ('area_jwUTqtiQYj4QQLhDdQ2EJ9ZqsCsU1Pmk', 'area_xMa1zEdrAcpKLixaEWInsuXYiBwm9QjK', '0', '&nbsp;', '长安区', '&nbsp;', '0', '1', '2018-08-07 15:31:02', '&nbsp;');

-- ----------------------------
-- Table structure for banner
-- ----------------------------
DROP TABLE IF EXISTS `banner`;
CREATE TABLE `banner` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
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
  `AccountNo` varchar(50) DEFAULT NULL,
  `NickName` varchar(50) DEFAULT NULL,
  `Mobile` char(11) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `HeadPortrait` varchar(255) DEFAULT NULL,
  `Age` int(3) DEFAULT NULL,
  `Birthday` datetime DEFAULT NULL,
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
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of client
-- ----------------------------
INSERT INTO `client` VALUES ('client_qicq8w13JMUawvdSvfG4fEojoXvzuIby', '2018-08-10 11:52:14', '0600958078165108', 'awdaw', '13802928231', '&nbsp;', '&nbsp;', '0', '0001-01-01 00:00:00', '0', '7C4A8D09CA3762AF61E59520943DC26494F8941B', '1b36f1f1a8226d600e268de08e769f23bc05f49f99bc8f1a13934e13dc6c066f', '&nbsp;', '&nbsp;', '&nbsp;', null, '0', '0.000000', '普通会员', 'comclass_94AaLiTo1eWvXehce1PndmJFiJQ0Zx0k', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;');
INSERT INTO `client` VALUES ('client_UL4jdH5gP6ShTYQS5KGdLYUTiI54zP8A', '2018-08-08 17:54:49', '9703270281828988', '靓仔', '13800000097', '&nbsp;', 'http://p8pmfndis.bkt.clouddn.com/pyog8t6m2chw3bi1.png?e=1691488476&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:0TQedp3g7kbSxt3UHo_onMpf_j0=', '0', '2018-08-08 00:00:00', '1', '7C4A8D09CA3762AF61E59520943DC26494F8941B', '2c3433d3390cde71575a035655b7df117df18bafb9e6470ab5f3ada74fe80216', '&nbsp;', '&nbsp;', '&nbsp;', 'wr2b7p', '0', '0.000000', '普通会员', 'comclass_94AaLiTo1eWvXehce1PndmJFiJQ0Zx0k', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;');

-- ----------------------------
-- Table structure for comclass
-- ----------------------------
DROP TABLE IF EXISTS `comclass`;
CREATE TABLE `comclass` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Title` varchar(50) DEFAULT NULL,
  `Subtitle` varchar(50) DEFAULT NULL,
  `Sort` int(10) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of comclass
-- ----------------------------
INSERT INTO `comclass` VALUES ('comclass_94AaLiTo1eWvXehce1PndmJFiJQ0Zx0k', '2018-08-08 09:28:04', '普通会员', null, '1', 'comclass_XJhAC7EhUZ4ukJtBCSJ16M0agbWOSeQm', '1', null);
INSERT INTO `comclass` VALUES ('comclass_bBOQG58ztwPosNwxWeWTS4AocXEVTiUp', '2018-08-07 15:53:42', 'APP', null, '2', 'comclass_bQ8uuUhZf7yAogYP3jDVhtd2ux1VZkBM', '1', null);
INSERT INTO `comclass` VALUES ('comclass_bQ8uuUhZf7yAogYP3jDVhtd2ux1VZkBM', '2018-08-07 15:44:15', '轮播图分类', 'Banner', '1', '0', '1', '&nbsp;');
INSERT INTO `comclass` VALUES ('comclass_O7JZltiehk5M7PG1emaVTlsBEA9OO7kA', '2018-08-07 15:44:54', '资讯分类', 'News', '2', '0', '1', null);
INSERT INTO `comclass` VALUES ('comclass_RFHFCxSrKbQjzlRkhiMfCPrDPCSor8Rb', '2018-08-07 15:53:33', 'PC', null, '1', 'comclass_bQ8uuUhZf7yAogYP3jDVhtd2ux1VZkBM', '1', null);
INSERT INTO `comclass` VALUES ('comclass_wG1zpCCIm9tB9FemZlgsxuSqeCUWH0oY', '2018-08-08 17:27:39', '资讯类型', null, '1', 'comclass_O7JZltiehk5M7PG1emaVTlsBEA9OO7kA', '1', null);
INSERT INTO `comclass` VALUES ('comclass_XJhAC7EhUZ4ukJtBCSJ16M0agbWOSeQm', '2018-08-08 09:27:36', '会员角色', null, '3', '0', '1', null);

-- ----------------------------
-- Table structure for deviceversion
-- ----------------------------
DROP TABLE IF EXISTS `deviceversion`;
CREATE TABLE `deviceversion` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
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
INSERT INTO `deviceversion` VALUES ('dversion_UD5IWURfj0W50VmtDCGPuefFqijf71v0', '2018-08-08 10:55:38', '第一版', '1.01', '1', 'http://p8pmfndis.bkt.clouddn.com/37j542d556k84mr4..jp?e=1691467138&token=9x4dvx5lZyz5U6iEbe93HoNZoBKaDJl3htdonLni:_49In7cQ6hzNaGqcFNV08xaV8ws=', '&nbsp;');

-- ----------------------------
-- Table structure for filestorage
-- ----------------------------
DROP TABLE IF EXISTS `filestorage`;
CREATE TABLE `filestorage` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `CreateUser` varchar(50) DEFAULT NULL,
  `FileType` varchar(25) DEFAULT NULL,
  `FileSize` int(11) DEFAULT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `Remark` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of filestorage
-- ----------------------------

-- ----------------------------
-- Table structure for log
-- ----------------------------
DROP TABLE IF EXISTS `log`;
CREATE TABLE `log` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `LogType` int(2) DEFAULT NULL,
  `IP` varchar(50) DEFAULT NULL,
  `Source` varchar(255) DEFAULT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Content` varchar(255) DEFAULT NULL,
  `Result` text,
  `Remark` varchar(255) DEFAULT NULL,
  `CreateUser` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log
-- ----------------------------
INSERT INTO `log` VALUES ('log_0CWUxhEEQPlkAhKmO3vK5DzHrCKyqMPr', '2018-08-10 18:08:41', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_U5DxwusfHXidMFxedNMqTvr0RkTOjs5Y', '2018-08-10 14:35:54', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_SlagedU3rqrFmonUPYD0T8JkyLfmLAHW', '2018-08-10 14:13:58', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_ckUyHc38KbNbacYe87CsM8y59dfIuBCM', '2018-08-10 11:57:35', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_7Z6A1MuvXxOuf5ScIKG2nnYF56RDMnFa', '2018-08-10 11:33:00', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_gVqyqZGBPpIKIgunUe8VV3RezwPaFp3S', '2018-08-09 16:18:07', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_QQ9Yinwwhkd3x8B5PihIX0ZRx4eMnoXr', '2018-08-09 16:09:53', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_Cukx3O2GvAno16BNGNqACWTXibiO6WhU', '2018-08-08 17:21:55', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_X3rQx3kcEpN5BMxWaCrsZ1Rn4P6X9AX4', '2018-08-08 15:04:59', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_bLGAnnBBBxvYslARNuniMyxpR53W8WIg', '2018-08-08 11:58:43', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_wvSvfHlfupSD4WSUFHx6laAop8Jh3ECq', '2018-08-08 10:48:24', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_KH4RY1Tjen4ceWNfeS5WBAcudubx8lKL', '2018-08-08 09:34:49', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');
INSERT INTO `log` VALUES ('log_SQ096kJawbWDuPG4sWgvDmUs1F5FjdzA', '2018-08-08 09:24:28', '1', '::1', '后台系统', 'Login', '登录成功', '', '', '超级管理员');

-- ----------------------------
-- Table structure for module
-- ----------------------------
DROP TABLE IF EXISTS `module`;
CREATE TABLE `module` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `FullName` varchar(30) DEFAULT NULL,
  `Icon` varchar(30) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `Layers` int(2) DEFAULT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `Target` varchar(50) DEFAULT NULL,
  `IsMenu` tinyint(1) DEFAULT NULL,
  `IsPublic` tinyint(1) DEFAULT NULL,
  `IsExpand` tinyint(1) DEFAULT NULL,
  `EnabledMark` tinyint(1) DEFAULT NULL,
  `AllowEdit` tinyint(1) DEFAULT NULL,
  `AllowDelete` tinyint(1) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of module
-- ----------------------------
INSERT INTO `module` VALUES ('module_mCXGRbYl4dxtUPORWGxdH2Gqf86Du7pv', '2018-08-07 10:53:43', null, '角色管理', '&nbsp;', '4', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '0', '/SystemManage/Role/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_T85uQCX9cFe6LX23nF2KTk7TQxmNdlvQ', '2018-08-07 09:52:41', null, '组织架构', 'fa fa-sunglasses', '3', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '0', '/SystemManage/Organize/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_Nh0c3mAOhOARSD4uqZf9osm46JN6iiSC', '2018-08-07 09:51:22', null, '菜单管理', 'fa fa-asterisk', '2', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '0', '/SystemManage/Module/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '2018-08-07 09:50:43', null, '系统设置', 'fa fa-gears', '1', '0', '0', '&nbsp;', 'expand', '0', '1', '1', '1', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '2018-08-07 10:54:39', null, '系统管理员', null, '5', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '0', '/SystemManage/AdminUser/Index', 'iframe', '1', '0', '0', '1', '0', '0', null);
INSERT INTO `module` VALUES ('module_pE65nBtQmfzvcJJXmksZQ18IciQCo9dv', '2018-08-07 10:55:40', null, '系统日志', null, '6', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '0', '/SystemManage/Log/Index', 'iframe', '1', '0', '0', '1', '0', '0', null);
INSERT INTO `module` VALUES ('module_HiblFf7DAjsvRdg2SBgLq9QIS9KAMsNh', '2018-08-07 10:56:14', null, '行政区域', null, '7', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', '0', '/SystemManage/Area/Index', 'iframe', '1', '0', '0', '1', '0', '0', null);
INSERT INTO `module` VALUES ('module_fz8Lal6WEYilxm0ELCSA1re0k3wBw8a6', '2018-08-07 10:57:02', null, '全局配置', 'fa fa-tag', '2', '0', '0', '&nbsp;', 'expand', '0', '0', '1', '1', '1', '1', '&nbsp;');
INSERT INTO `module` VALUES ('module_9QSLD8uDj3CVEPB5Y3i8Rp6G3QbWEtkG', '2018-08-07 10:57:30', null, '参数配置', null, '1', 'module_fz8Lal6WEYilxm0ELCSA1re0k3wBw8a6', '0', '/PublicBusines/SystemConfig/Index', 'iframe', '1', '0', '0', '1', '0', '0', null);
INSERT INTO `module` VALUES ('module_AtJ3CWPNVMrlAXe4YryjT8nqBiqjK2q8', '2018-08-07 10:58:09', null, '综合分类', null, '2', 'module_fz8Lal6WEYilxm0ELCSA1re0k3wBw8a6', '0', '/PublicBusines/ComClass/Index', 'iframe', '1', '0', '0', '1', '0', '0', null);
INSERT INTO `module` VALUES ('module_XAG54ecKDibloGpQLfjpKkUOrur36cF7', '2018-08-07 16:03:40', null, '常用模块', 'fa fa-road', '3', '0', '0', '&nbsp;', 'expand', '0', '0', '1', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_WnnqQT09MPLmzLJcSi5tkAYTajlySHBL', '2018-08-07 16:04:32', null, '会员管理', '&nbsp;', '1', 'module_XAG54ecKDibloGpQLfjpKkUOrur36cF7', '0', '/PublicBusines/Client/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_HI4HfCGyLPtJIEY20CkjHdD4A34XH7dG', '2018-08-07 16:05:20', null, '轮播图管理', '&nbsp;', '2', 'module_XAG54ecKDibloGpQLfjpKkUOrur36cF7', '0', '/PublicBusines/Banner/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_Ll1IgETV87zPuR4rdaooHoKYCSEGiYWY', '2018-08-07 16:05:38', null, '资讯管理', '&nbsp;', '3', 'module_XAG54ecKDibloGpQLfjpKkUOrur36cF7', '0', '/PublicBusines/News/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');
INSERT INTO `module` VALUES ('module_bY6QvKBFjfL0HsXOaIor8EV1AJuqaqEJ', '2018-08-07 16:06:28', null, '设备版本', '&nbsp;', '3', 'module_fz8Lal6WEYilxm0ELCSA1re0k3wBw8a6', '0', '/PublicBusines/DeviceVersion/Index', 'iframe', '1', '0', '0', '1', '0', '0', '&nbsp;');

-- ----------------------------
-- Table structure for modulebutton
-- ----------------------------
DROP TABLE IF EXISTS `modulebutton`;
CREATE TABLE `modulebutton` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `ModuleSid` varchar(50) DEFAULT NULL,
  `Sort` int(2) DEFAULT NULL,
  `EnCode` varchar(30) DEFAULT NULL,
  `Location` int(2) DEFAULT NULL,
  `JsEvent` varchar(50) DEFAULT NULL,
  `Path` varchar(255) DEFAULT NULL,
  `Isplit` tinyint(1) DEFAULT NULL,
  `IsPublic` tinyint(1) DEFAULT NULL,
  `AllowEdit` tinyint(1) DEFAULT NULL,
  `AllowDelete` tinyint(1) DEFAULT NULL,
  `EnabledMark` tinyint(1) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of modulebutton
-- ----------------------------
INSERT INTO `modulebutton` VALUES ('modulebutton_OOhoZJOPZVnsAQFT6sHoFFRX2GufwuAw', '2018-08-07 09:57:38', '删除菜单', 'module_Nh0c3mAOhOARSD4uqZf9osm46JN6iiSC', '3', 'NF-delete', '2', 'btn_delete()', '/SystemManage/Module/DeleteForm', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_Hpj9k1ESk6U2S3n8mchMev6QkaHOdWp5', '2018-08-07 09:56:55', '编辑菜单', 'module_Nh0c3mAOhOARSD4uqZf9osm46JN6iiSC', '2', 'NF-edit', '2', 'btn_edit()', '/SystemManage/Module/Form', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_AkAKOP5suRP5AOHsUFkmzpHjvncU2GD8', '2018-08-07 09:54:07', '添加菜单', 'module_Nh0c3mAOhOARSD4uqZf9osm46JN6iiSC', '1', 'NF-add', '1', 'btn_add()', '/SystemManage/Module/Form', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_toVbp9DDTiI0hxhOYqsQYaQUP2NK77b1', '2018-08-07 09:58:28', '按钮管理', 'module_Nh0c3mAOhOARSD4uqZf9osm46JN6iiSC', '4', 'NF-modulebutton', '2', 'btn_modulebutton()', '/SystemManage/ModuleButton/Index', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_9TtQZC5wTTiCyWjzsO8Y96erUoCIddDD', '2018-08-07 10:36:28', '删除组织结构', 'module_T85uQCX9cFe6LX23nF2KTk7TQxmNdlvQ', '3', 'NF-delete', '2', 'btn_delete()', '/SystemManage/Organize/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_dUhzMmfPoHZwCe1vDebLFmOmehUb7qoV', '2018-08-07 10:36:28', '编辑组织结构', 'module_T85uQCX9cFe6LX23nF2KTk7TQxmNdlvQ', '2', 'NF-edit', '2', 'btn_edit()', '/SystemManage/Organize/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_6kAvkd8GL2K80keN8XEmaiVw1P5W9JGa', '2018-08-07 10:36:28', '添加组织结构', 'module_T85uQCX9cFe6LX23nF2KTk7TQxmNdlvQ', '1', 'NF-add', '1', 'btn_add()', '/SystemManage/Organize/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_ISgJUR0EpczYtiWddN4PG5u0wANedm2x', '2018-08-07 10:59:55', '添加角色', 'module_mCXGRbYl4dxtUPORWGxdH2Gqf86Du7pv', '1', 'NF-add', '1', 'btn_add()', '/SystemManage/Role/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_FQs077QlToS4o0fh2n12aPU5cGvLk9hg', '2018-08-07 10:59:55', '编辑角色', 'module_mCXGRbYl4dxtUPORWGxdH2Gqf86Du7pv', '2', 'NF-edit', '2', 'btn_edit()', '/SystemManage/Role/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_Mra4ygXvw48s1U2ZyEzqETNVp9k0iRY1', '2018-08-07 10:59:55', '删除角色', 'module_mCXGRbYl4dxtUPORWGxdH2Gqf86Du7pv', '3', 'NF-delete', '2', 'btn_delete()', '/SystemManage/Role/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_z2h6Cd3dj1VFIrvb66YdC2ijIj6Sco2s', '2018-08-07 11:34:39', '添加管理员', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '1', 'NF-add', '1', 'btn_add()', '/SystemManage/AdminUser/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_GCZa3manWGa3lljTCowB66a9VMV795Kd', '2018-08-07 11:34:39', '编辑管理员', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '2', 'NF-edit', '2', 'btn_edit()', '/SystemManage/AdminUser/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_CBbqgC03qSt9g3BXqYtOAQBeCSDEgSYV', '2018-08-07 11:34:39', '删除管理员', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '3', 'NF-delete', '2', 'btn_delete()', '/SystemManage/AdminUser/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_XgnLnhytDRl0niznXXwy1lijqjAYpdyn', '2018-08-07 11:36:31', '重置密码', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '4', 'NF-reset', '2', 'btn_reset()', '/SystemManage/AdminUser/ResetPwd', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_8kPirUEiuouSpjbVT9lKSJuibA8ZeRDy', '2018-08-07 11:37:09', '启用账号', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '5', 'NF-enabled', '2', 'btn_enabled()', '/SystemManage/AdminUser/EnabledAccount', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_A3bcY5pjTPVZ7C9KPpV5Bzwaym8RnZu7', '2018-08-07 11:37:38', '禁用账号', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', '6', 'NF-disabled', '2', 'btn_disabled()', '/SystemManage/AdminUser/DisabledAccount', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_Z6O5cTQJ0Zi1FdqeCZaW01Tl5PXRkxeQ', '2018-08-07 15:01:16', '清理日志', 'module_pE65nBtQmfzvcJJXmksZQ18IciQCo9dv', '1', 'NF-removelog', '1', 'btn_removelog()', '/SystemManage/Log/RemoveLog', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_rLvthD7iVO8BmYhZwM4Zh7PKlsflcwnl', '2018-08-07 15:13:05', '添加区域', 'module_HiblFf7DAjsvRdg2SBgLq9QIS9KAMsNh', '1', 'NF-add', '1', 'btn_add()', '/SystemManage/Area/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_nKHJvTXYp0rHiGA3lm1cLRfP1yXSiiC3', '2018-08-07 15:13:05', '修改区域', 'module_HiblFf7DAjsvRdg2SBgLq9QIS9KAMsNh', '2', 'NF-edit', '2', 'btn_edit()', '/SystemManage/Area/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_ukpNW2582FG5UAnLREzBfV8Ff1M7g0jO', '2018-08-07 15:13:05', '删除区域', 'module_HiblFf7DAjsvRdg2SBgLq9QIS9KAMsNh', '3', 'NF-delete', '2', 'btn_delete()', '/SystemManage/Area/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_B63J4m3QmjA88oUKnLMF2skEsrmKf046', '2018-08-07 15:36:32', '添加系统配置', 'module_9QSLD8uDj3CVEPB5Y3i8Rp6G3QbWEtkG', '1', 'NF-add', '1', 'btn_add()', '/SystemManage/SystemConfig/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_y5fZhBTxQvTe46cOclJRwcKJ8y5hlNjO', '2018-08-07 15:36:32', '修改系统配置', 'module_9QSLD8uDj3CVEPB5Y3i8Rp6G3QbWEtkG', '2', 'NF-edit', '2', 'btn_edit()', '/SystemManage/SystemConfig/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_FFW3JL0Hta9CH00wHChg0fDzl0Txju0z', '2018-08-07 15:36:32', '删除配置', 'module_9QSLD8uDj3CVEPB5Y3i8Rp6G3QbWEtkG', '3', 'NF-delete', '2', 'btn_delete()', '/SystemManage/SystemConfig/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_Ib1lDM947QM8qhCoiHjwaAX6CtM3T8QC', '2018-08-07 15:40:08', '添加分类', 'module_AtJ3CWPNVMrlAXe4YryjT8nqBiqjK2q8', '1', 'NF-add', '1', 'btn_add()', '/PublicBusines/ComClass/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_FadCR1ZLB25emYVt7hgJDknbiAuBZU5k', '2018-08-07 15:40:08', '修改分类', 'module_AtJ3CWPNVMrlAXe4YryjT8nqBiqjK2q8', '2', 'NF-edit', '2', 'btn_edit()', '/PublicBusines/ComClass/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_MKUGia6VeHkCZSIbDyO78og1w2jQXCN5', '2018-08-07 15:40:08', '删除分类', 'module_AtJ3CWPNVMrlAXe4YryjT8nqBiqjK2q8', '3', 'NF-delete', '2', 'btn_delete()', '/PublicBusines/ComClass/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_y4KMQLeNN7HiAUxWBI2ZuINKe6ANzDE0', '2018-08-07 15:43:05', '分类管理', 'module_AtJ3CWPNVMrlAXe4YryjT8nqBiqjK2q8', '4', 'NF-itemstype', '1', 'btn_itemstype()', '/PublicBusines/ComClass/TabType', '0', '0', '0', '0', '1', null);
INSERT INTO `modulebutton` VALUES ('modulebutton_x9vIXLtUlkF0j8XmMCp7vP5LNuXkrhgP', '2018-08-08 09:25:11', '添加会员', 'module_WnnqQT09MPLmzLJcSi5tkAYTajlySHBL', '1', 'NF-add', '1', 'btn_add()', '/PublicBusines/Client//Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_7rvzX29zQCbBfw3rRgV8REOfUiVW8bBk', '2018-08-08 09:25:11', '编辑会员', 'module_WnnqQT09MPLmzLJcSi5tkAYTajlySHBL', '2', 'NF-edit', '2', 'btn_edit()', '/PublicBusines/Client/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_AIo2CaqLsbeuRK386tUItDoGH3u6vLdi', '2018-08-08 09:25:11', '删除会员', 'module_WnnqQT09MPLmzLJcSi5tkAYTajlySHBL', '3', 'NF-delete', '2', 'btn_delete()', '/PublicBusines/Client/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_rKcMMQUilwswfrjSrf83nGFwgjhRFUM2', '2018-08-08 10:48:55', '添加版本', 'module_bY6QvKBFjfL0HsXOaIor8EV1AJuqaqEJ', '1', 'NF-add', '1', 'btn_add()', '/PublicBusines/DeviceVersion/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_ykUQdZ1sYbIUSl7zXxFsRKymtM66CBuO', '2018-08-08 10:48:55', '编辑版本', 'module_bY6QvKBFjfL0HsXOaIor8EV1AJuqaqEJ', '2', 'NF-edit', '2', 'btn_edit()', '/PublicBusines/DeviceVersion/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_1BNjT7jEzKKMuz6hcJE2uJ8NfwFg0c6M', '2018-08-08 10:48:55', '删除版本', 'module_bY6QvKBFjfL0HsXOaIor8EV1AJuqaqEJ', '3', 'NF-delete', '2', 'btn_delete()', '/PublicBusines/DeviceVersion/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_OLjJ9VudqyJWf4Jen274tR4cQrfVDRtF', '2018-08-08 17:22:54', '添加Banner', 'module_HI4HfCGyLPtJIEY20CkjHdD4A34XH7dG', '1', 'NF-add', '1', 'btn_add()', '/PublicBusines/Banner/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_LKv0mbkTUK22bM2jcC4gXBuhxyXtKEIn', '2018-08-08 17:22:54', '编辑Banner', 'module_HI4HfCGyLPtJIEY20CkjHdD4A34XH7dG', '2', 'NF-edit', '2', 'btn_edit()', '/PublicBusines/Banner/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_Skd4Oks3xphqNGP0IUCFrFn7K0MIHmp8', '2018-08-08 17:22:54', '删除Banner', 'module_HI4HfCGyLPtJIEY20CkjHdD4A34XH7dG', '3', 'NF-delete', '2', 'btn_delete()', '/PublicBusines/Banner/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_nEk7EaYo4ztHCI08m0bmNJCDHpQVG8Bk', '2018-08-08 17:23:55', '添加资讯', 'module_Ll1IgETV87zPuR4rdaooHoKYCSEGiYWY', '1', 'NF-add', '1', 'btn_add()', '/PublicBusines/News/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_jDwnSqO4yLMNyqjdbA8zht3InvysNVQ2', '2018-08-08 17:23:56', '编辑资讯', 'module_Ll1IgETV87zPuR4rdaooHoKYCSEGiYWY', '2', 'NF-edit', '2', 'btn_edit()', '/PublicBusines/News/Form', '0', '0', '0', '0', '1', '&nbsp;');
INSERT INTO `modulebutton` VALUES ('modulebutton_qderjzVebq1bbk6UHRGYLxWyBYnHKDyO', '2018-08-08 17:23:56', '删除资讯', 'module_Ll1IgETV87zPuR4rdaooHoKYCSEGiYWY', '3', 'NF-delete', '2', 'btn_delete()', '/PublicBusines/News/DeleteForm', '0', '0', '0', '0', '1', '&nbsp;');

-- ----------------------------
-- Table structure for news
-- ----------------------------
DROP TABLE IF EXISTS `news`;
CREATE TABLE `news` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
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
  `FullName` varchar(50) DEFAULT NULL,
  `ParentId` varchar(50) DEFAULT NULL,
  `EnCode` varchar(30) DEFAULT NULL,
  `Category` varchar(30) DEFAULT NULL,
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
INSERT INTO `organize` VALUES ('organize_tIqwSsIjT8UqHTbnseLXQEhRjC1rVpQQ', '2018-08-07 10:50:46', 'Company', '0', '100001', '1', 'Lead', '&nbsp;', '&nbsp;', '&nbsp;', '1', '&nbsp;');
INSERT INTO `organize` VALUES ('organize_lhuolvhqaIRJIEQM6lTYCkHQGH1dkqjY', '2018-08-07 10:51:30', 'Product_Depar', 'organize_tIqwSsIjT8UqHTbnseLXQEhRjC1rVpQQ', '10000002', '2', null, null, null, null, '1', null);
INSERT INTO `organize` VALUES ('organize_uFN4Ohhar9dHeYIFsBL8PvK54c5wjZS9', '2018-08-07 10:52:03', 'Ios_Team', 'organize_lhuolvhqaIRJIEQM6lTYCkHQGH1dkqjY', '1029019183', '3', '&nbsp;', '&nbsp;', '&nbsp;', '&nbsp;', '1', '&nbsp;');

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `FullName` varchar(50) DEFAULT NULL,
  `EnCode` varchar(50) DEFAULT NULL,
  `OrganizeName` varchar(50) DEFAULT NULL,
  `OrganizeId` varchar(50) DEFAULT NULL,
  `Category` int(2) DEFAULT NULL,
  `AllowEdit` tinyint(1) DEFAULT NULL,
  `AllowDelete` tinyint(1) DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `IsEnable` tinyint(1) DEFAULT NULL,
  `Description` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '2018-08-07 11:21:32', '管理员一号', '001', 'Company', 'organize_tIqwSsIjT8UqHTbnseLXQEhRjC1rVpQQ', '1', '0', '0', '1', '1', '&nbsp;');

-- ----------------------------
-- Table structure for roleauthorize
-- ----------------------------
DROP TABLE IF EXISTS `roleauthorize`;
CREATE TABLE `roleauthorize` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `Sort` int(11) DEFAULT NULL,
  `ModulType` int(2) DEFAULT NULL,
  `ModuleId` varchar(50) DEFAULT NULL,
  `RoleId` varchar(50) DEFAULT NULL,
  `RoleType` int(2) DEFAULT NULL,
  PRIMARY KEY (`Sid`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of roleauthorize
-- ----------------------------
INSERT INTO `roleauthorize` VALUES ('roleauthorize_omU8H1WKQR4IYv62BQDmleC9rygqmRtY', '2018-08-08 17:58:03', '25', '1', 'module_AtJ3CWPNVMrlAXe4YryjT8nqBiqjK2q8', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_soIRuL64mFLC3NOXMgG9Ruc4KsyTf5ef', '2018-08-08 17:58:03', '24', '1', 'module_9QSLD8uDj3CVEPB5Y3i8Rp6G3QbWEtkG', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_lN1N3CZUJ0veqT0fgZ8LmqjexZJDhnxu', '2018-08-08 17:58:03', '23', '1', 'module_fz8Lal6WEYilxm0ELCSA1re0k3wBw8a6', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_edjJCtSK6lgQOZdyKHBmSmqokxUojGPJ', '2018-08-08 17:58:03', '22', '1', 'module_HiblFf7DAjsvRdg2SBgLq9QIS9KAMsNh', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_ie7tpd24C9XKShVtV7EaoC0jEqcRdTA1', '2018-08-08 17:58:03', '21', '1', 'module_pE65nBtQmfzvcJJXmksZQ18IciQCo9dv', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_bEqpX4UUZuHmfn7MpQ6LUy7trYnCfbTg', '2018-08-08 17:58:02', '20', '2', 'modulebutton_A3bcY5pjTPVZ7C9KPpV5Bzwaym8RnZu7', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_eGe9KO4eviogkFPHBg9yqPHoKRF58pEy', '2018-08-08 17:58:02', '19', '2', 'modulebutton_8kPirUEiuouSpjbVT9lKSJuibA8ZeRDy', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_85w5jFX4SD9SHL1Z5ZBaVLOyxpQQaHWN', '2018-08-08 17:58:02', '18', '2', 'modulebutton_XgnLnhytDRl0niznXXwy1lijqjAYpdyn', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_b7kO6q7oorQML3JVgpEXr1otRi8i4UH5', '2018-08-08 17:58:02', '17', '2', 'modulebutton_CBbqgC03qSt9g3BXqYtOAQBeCSDEgSYV', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_5xDKFg0eLMAo99VdK77yXXvDEPj36d0j', '2018-08-08 17:58:02', '16', '2', 'modulebutton_GCZa3manWGa3lljTCowB66a9VMV795Kd', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_CfKhZ8I29dywxVWwvV8XlYUdR5KUICol', '2018-08-08 17:58:02', '15', '2', 'modulebutton_z2h6Cd3dj1VFIrvb66YdC2ijIj6Sco2s', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_8JMUZbUZIypJ2JtnFC7l2hSXoFccgv5h', '2018-08-08 17:58:00', '0', '1', 'module_wfFIhrw7PyIKDIW87iAan3y55EFr3Fed', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_5IXacrKFdKHPYrMruc4yw1i24LUJmhkZ', '2018-08-08 17:58:01', '1', '1', 'module_Nh0c3mAOhOARSD4uqZf9osm46JN6iiSC', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_biFeEARPQpXdBlz90uCX15bSheJYkZ2K', '2018-08-08 17:58:01', '2', '2', 'modulebutton_AkAKOP5suRP5AOHsUFkmzpHjvncU2GD8', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_8gRvRQHwkBgjw3SdO4z9vPBXXkrvrMht', '2018-08-08 17:58:01', '3', '2', 'modulebutton_Hpj9k1ESk6U2S3n8mchMev6QkaHOdWp5', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_fRzziZPFXgvH9XFVkl7yZTuNbNgLotYe', '2018-08-08 17:58:01', '4', '2', 'modulebutton_OOhoZJOPZVnsAQFT6sHoFFRX2GufwuAw', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_bPKPvfFmrtON5FX09V4LtDURRUYivgdW', '2018-08-08 17:58:01', '5', '2', 'modulebutton_toVbp9DDTiI0hxhOYqsQYaQUP2NK77b1', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_ipsTXoMw484bHzLHFcB9XHNH4mNxtYVH', '2018-08-08 17:58:01', '6', '1', 'module_T85uQCX9cFe6LX23nF2KTk7TQxmNdlvQ', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_p0aXoxTFHNkzjtypbu9ysKGxhPCMrFCs', '2018-08-08 17:58:01', '7', '2', 'modulebutton_6kAvkd8GL2K80keN8XEmaiVw1P5W9JGa', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_lYmdBNJmbZCFfbRt046LWu6CYVkjxsRa', '2018-08-08 17:58:01', '8', '2', 'modulebutton_dUhzMmfPoHZwCe1vDebLFmOmehUb7qoV', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_sz3h2WQwOES4S5EbvlE9qyZsbo9yv9zV', '2018-08-08 17:58:01', '9', '2', 'modulebutton_9TtQZC5wTTiCyWjzsO8Y96erUoCIddDD', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_oxfyfcGciQbaONXgkVBmUipxRuR6CWOD', '2018-08-08 17:58:01', '10', '1', 'module_mCXGRbYl4dxtUPORWGxdH2Gqf86Du7pv', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_v7XCHlOmVvryqHKXQc9Lomin4XGlzEvp', '2018-08-08 17:58:02', '11', '2', 'modulebutton_ISgJUR0EpczYtiWddN4PG5u0wANedm2x', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_YpQ5mt5xx4tq2VKF5p7l0lTORHfuXe7n', '2018-08-08 17:58:02', '12', '2', 'modulebutton_FQs077QlToS4o0fh2n12aPU5cGvLk9hg', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_yGQWlKLc2mZ2YjQKb4DmnaBiYwd7E8sS', '2018-08-08 17:58:02', '13', '2', 'modulebutton_Mra4ygXvw48s1U2ZyEzqETNVp9k0iRY1', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');
INSERT INTO `roleauthorize` VALUES ('roleauthorize_1YJq0S3oEV2UBxQrqgCXZ9cJKgMh2J3Q', '2018-08-08 17:58:02', '14', '1', 'module_nH2HVdPKDL8hYzkeeiLu12WCbZQcauZE', 'role_3Gp8kJk96kPB2FmBxRqYCFAWgdJC8mBs', '1');

-- ----------------------------
-- Table structure for systemconfig
-- ----------------------------
DROP TABLE IF EXISTS `systemconfig`;
CREATE TABLE `systemconfig` (
  `Sid` varchar(50) NOT NULL,
  `CreateDate` datetime DEFAULT NULL,
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
INSERT INTO `systemconfig` VALUES ('sysConfig_nauzahmdALTQAYhPNdByD46YxViQmGpB', '2018-08-07 15:38:12', '短信配置', '1', '0', '&nbsp;', '0.00000', '&nbsp;', '&nbsp;');
INSERT INTO `systemconfig` VALUES ('sysConfig_yzPCq0wae6Z6OtVjGJjiTLtRRgEb2fn2', '2018-08-07 15:39:21', '发送间隔时间', '1', 'sysConfig_nauzahmdALTQAYhPNdByD46YxViQmGpB', 'SMS_Second', '60.00000', '&nbsp;', '&nbsp;');

-- ----------------------------
-- Function structure for getChildList
-- ----------------------------
DROP FUNCTION IF EXISTS `getChildList`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` FUNCTION `getChildList`(Pid varchar(100)) RETURNS varchar(20000) CHARSET utf8
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
