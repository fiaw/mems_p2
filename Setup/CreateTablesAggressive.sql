--frank 2019-10-7
INSERT INTO [lkpPeriodType] VALUES(1,'天/次');

alter table tblDispatchJournal alter column [FaultCode] [nvarchar](500) NOT NULL;
alter table tblDispatchJournal alter column [JobContent] [nvarchar](500) NOT NULL;
alter table tblDispatchJournal alter column [FollowProblem] [nvarchar](500) NOT NULL;
alter table tblDispatchJournal alter column [UnconfirmedProblem] [nvarchar](500) NOT NULL;

alter table tblDispatchReport alter column [FaultDesc] [nvarchar](500) NOT NULL;
alter table tblDispatchReport alter column [SolutionCauseAnalysis] [nvarchar](500) NOT NULL;
alter table tblDispatchReport alter column [SolutionWay] [nvarchar](500) NOT NULL;
GO

--recreate tblContract/jctContractEqpt/tblContractFile/v_ActiveContract


--frank 2019-10-8
alter table tblUser alter column [Mobile] [nvarchar](20) NULL;

alter table tblEquipment alter column [AssetCode] [nvarchar](20) NOT NULL;

alter table tblContract alter column [ContractNum] [nvarchar](20) NOT NULL;

alter table tblSupplier alter column [Mobile] [nvarchar](20) NULL;
alter table tblSupplier alter column [ContactMobile] [nvarchar](20) NULL;


-- rebecca 2019-10-9 recreate lkpCustomReportType/lkpCustRptTemplateTable/lkpCustRptTemplateField

--buster 2019-11-04 copy changes from global
alter table tblRequest add [EquipmentStatus] [int] NULL;	 			-- 机器状态
alter table tblDispatchJournal add [UserName] [nvarchar] (20) NULL;		
alter table tblDispatchJournal add [UserMobile] [varchar](20) NULL;
GO
alter table tblDispatchReport add [IsPrivate] [bit] NULL;	-- 专用报告 (强检)
alter table tblDispatchReport add [ServiceProvider] [int] NULL;		--服务提供方 (保养:管理方；第三方；厂家)
GO
alter table lkpDispatchReportType alter column [Description] [nvarchar](30) NOT NULL;
INSERT INTO [lkpDispatchReportType] VALUES(1,'通用作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(101,'维修作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(201,'保养作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(301,'强检作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(401,'巡检作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(501,'校正作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(601,'设备新增作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(701,'不良事件作业报告')
INSERT INTO [lkpDispatchReportType] VALUES(901,'验收安装作业报告')
GO

alter table tblDispatchReport ADD [Comments] [nvarchar](500) NULL;
GO

--frank 2019-11-25
alter table tblDispatchJournal alter column [UserMobile] [nvarchar](20) NULL;
alter table tblReportAccessory alter column [NewSerialCode] [nvarchar](30) NULL;
alter table tblReportAccessory alter column [OldSerialCode] [nvarchar](30) NULL;

--frank 2019-11-28
alter table tblEquipment add [ServiceScope] [bit] NOT NULL default 1;

--rebecca 2019-12-3
update lkpContractType set Description = '第三方供应商服务合同' where ID = 2

--rebecca 2019-12-5
alter table tblDispatchReport drop column FaultFrequency;
alter table tblDispatchReport drop column FaultSystemStatus;
alter table tblDispatchReport add [EquipmentStatus] [int] NULL;						-- 设备状态 (离场)
alter table tblDispatchReport add [PurchaseAmount] [decimal](10, 2) NULL;			-- 资产金额
alter table tblDispatchReport add [ServiceScope] [bit] NULL;							-- 整包范围
alter table tblDispatchReport add [Result] [nvarchar] (500) NULL;					-- 结果
alter table tblDispatchReport add [IsRecall] [bit] NULL;								-- 待召回
alter table tblDispatchReport add [AcceptanceDate] [datetime] NULL;					-- 验收日期

--rebecca 2019-12-13
alter table tblRequest add [DispatchDate] [datetime] NULL;				-- 首次派工时间

-- rebecca 2020-01-13 recreate lkpCustRptTemplateField
alter table tblDispatchJournal drop column UnconfirmedProblem;

--frank 2020-01-13
alter table tblControl drop column MsgHost;
alter table tblControl drop column MsgAppID;
alter table tblControl drop column MsgAppKey;
alter table tblControl drop column MsgMasterSecret;
drop table lkpPriority

-- frank 2020-03-26
alter table tblEquipment add [Brand] [nvarchar] (30) NULL				-- 品牌
alter table tblEquipment add [Comments] [nvarchar](100) NULL			-- 备注
alter table tblEquipment add [ManufacturingDate] [datetime] NULL		-- 出厂日期
alter table tblEquipment add [UseageDate] [datetime] NULL				-- 启用日期
alter table [tblEquipment] drop column InstalStartDate;
EXEC sp_rename 'tblEquipment.InstalEndDate', 'InstalDate', 'column'

--buster 2020-04-13 create lkpDepartmentType and recreate lkpDepartment and then run department list sql
-- for live site, we will need rename the existing lkpDepartment table first, then create the new table and copy data from the renamed table.

-- frank 2020-04-27
alter table tblEquipment alter column [AssetCode] [nvarchar](30) NOT NULL
INSERT INTO tblControl (AdminEmail,WillExpireTime,OverDueTime,ErrorMessage) VALUES (null,30,18,'请联系管理员') -- add default ErrorMessage 

-- frank 2020-04-28 create tblEquipmentCtl

-- rebecca 2020-05-11 recreate lkpCustRptTemplateField
alter table tblEqptAuditHdr drop constraint [PK_tblEqptAuditHdr]
drop index IX_tblEqptAuditHdr on tblEqptAuditHdr

EXEC sp_rename 'tblEqptAuditHdr','tblAuditHdr';
alter table tblAuditHdr add [ObjectTypeID] [int] NOT NULL default 0;
UPDATE tblAuditHdr set ObjectTypeID = 1;
EXEC sp_rename 'tblAuditHdr.EquipmentID', 'ObjectID', 'column'

alter table tblAuditHdr add constraint PK_tblAuditHdr PRIMARY KEY ([ID])
CREATE INDEX IX_tblAuditHdr ON [tblAuditHdr] ([ObjectTypeID],[ObjectID])


alter table tblEqptAuditDetail drop constraint [PK_tblEqptAuditDetail]
EXEC sp_rename tblEqptAuditDetail , tblAuditDetail;
alter table tblAuditDetail alter column FieldName [varchar](50) NOT NULL;
alter table tblAuditDetail alter column OldValue [nvarchar](500) NOT NULL;
alter table tblAuditDetail alter column NewValue [nvarchar](500) NOT NULL;

alter table tblAuditDetail add constraint PK_tblAuditDetail PRIMARY KEY ([AuditID],[FieldName])

-- rebecca 2020-05-14
alter table lkpDepartment add [Pinyin] [varchar](100) NULL;

--frank 2020-05-14
dbcc checkident ("lkpDepartment",reseed,-1)
INSERT INTO [lkpDepartment] VALUES('其他',99999,9,'qt')
dbcc checkident ("lkpDepartment",reseed,maxID) -- maxID need change to real data


-- rebecca 2020-05-19 recreate lkpCustRptTemplateField
INSERT INTO [lkpCustRptTemplateField] VALUES(2,29,'tblSupplier','SupplierStatus','供应商经营状态')

-- rebecca 2020-06-03 create jctContractComponent jctContractConsumable
alter table tblComponent alter column Usage [int] NULL;
alter table tblComponent add MethodID [int] NULL;
alter table tblComponent add LifeTime [int] NULL;

alter table tblEquipment add FujiClass2ID [int] NULL;

-- frank 2020-06-12 recreate tblFujiClass2 create jctFujiClass2EqpType

-- rebecca 2020-06-15 
alter table tblAuditHdr add Operation [int] NOT NULL default 2;

-- frank 2020-06-17
alter table tblEquipment add [CTSerialCode] [nvarchar](30) NULL;
alter table tblEquipment add [CTUsedSeconds] [decimal](12,2) NULL;

-- frank 2020-06-18
dbcc checkident ("tblFujiClass1",reseed,-2)
INSERT INTO [tblFujiClass1] VALUES('其它','其它',GETDATE(),NULL)
dbcc checkident ("tblFujiClass1",reseed,maxID) -- maxID need change to real data

dbcc checkident ("tblFujiClass2",reseed,-2)
INSERT INTO [tblFujiClass2] VALUES(-1,'其它','其它',0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,1,GETDATE(),NULL)  --3为设备等级一般,1为故障率计算方式手动
dbcc checkident ("tblFujiClass2",reseed,maxID) -- maxID need change to real data

-- frank 2020-06-19 recreate lkpCustRptTemplateField

-- rebecca 2020-06-19 recreate tblValParameter  tblValControl

--buster
-- 系统对象列表
CREATE TABLE [dbo].[lkpObjectType](
	[ID] [int] NOT NULL,
	[TableKey] [varchar](20) NOT NULL,
	[Prefix] [varchar](10) NOT NULL,
	[LeadingZeros] [decimal](2,0) NOT NULL,
	[Description] [nvarchar](20) NOT NULL,
	CONSTRAINT PK_lkpObjectType PRIMARY KEY ([ID]),
	CONSTRAINT IX_lkpObjectType UNIQUE NONCLUSTERED ([TableKey]),
)
GO
INSERT INTO [lkpObjectType] VALUES(1,	'Supplier',			'GYS',	8, '供应商')
INSERT INTO [lkpObjectType] VALUES(2,	'Contract',			'HT',	8, '合同')
INSERT INTO [lkpObjectType] VALUES(3,	'Equipment',		'ZC',	8, '设备')
INSERT INTO [lkpObjectType] VALUES(4,	'Request',			'C',	8, '客户请求')
INSERT INTO [lkpObjectType] VALUES(5,	'Dispatch',			'PGD',	8, '派工单')
INSERT INTO [lkpObjectType] VALUES(6,	'DispatchJournal',	'FWPZ',	8, '服务凭证')
INSERT INTO [lkpObjectType] VALUES(7,	'DispatchReport',	'ZYBG',	8, '作业报告')
INSERT INTO [lkpObjectType] VALUES(8,	'ReportAccessory',	'LPJ',	8, '报告零配件')
INSERT INTO [lkpObjectType] VALUES(9,	'CustomReport',		'ZB',	8, '自定义报表')
INSERT INTO [lkpObjectType] VALUES(10,	'Notice',			'GB',	8, '广播')
INSERT INTO [lkpObjectType] VALUES(11,	'Department',		'KS',	8, '科室')
INSERT INTO [lkpObjectType] VALUES(12,	'SysAuditLog',		'XTRZ',	8, '日志')
INSERT INTO [lkpObjectType] VALUES(13,	'Component',		'LJ',	8, '零件')
INSERT INTO [lkpObjectType] VALUES(14,	'Consumable',		'HC',	8, '耗材')
INSERT INTO [lkpObjectType] VALUES(15,	'FujiClass1',		'',		8, '富士I类')
INSERT INTO [lkpObjectType] VALUES(16,	'FujiClass2',		'FJFL',	8, '富士II类')
GO


-- rebecca 2020-06-24
alter table tblValEquipment add [Hours] [decimal](12, 2) NOT NULL

-- frank 2020-06-26 change "其他" to "其它"  add default HospitalLevel in tblValParameter 

-- frank2020-06-29 
alter table tblInvComponent add [Comments] [nvarchar](500) NULL

-- rebecca 2020-06-30 recreate tblValEquipment
alter table tblValComponent add InSystem bit NOT NULL default 1  -- frank recreate tblValComponent 4 PK_tblValComponent

--frank 2020-07-06
alter table jctContractComponent drop constraint [PK_jctContractComponent]
alter table jctContractComponent add constraint PK_jctContractComponent PRIMARY KEY ([ContractID],[EquipmentID],[ComponentID])

alter table jctContractConsumable drop constraint [PK_jctContractConsumable]
alter table jctContractConsumable add constraint PK_jctContractConsumable PRIMARY KEY ([ContractID],[EquipmentID],[ConsumableID])

-- rebecca 2020-07-07 create tblValEqptOutput tblValConsumableOutput tblValComponentOutput

-- rebecca 2020-07-13 recreate tblValEquipment

-- frank 2020-07-13 
INSERT INTO [lkpObjectType] VALUES(17,	'InvComponent',		'LJK',	8, '零件')
INSERT INTO [lkpObjectType] VALUES(18,	'InvConsumable',	'HCK',	8, '耗材')
INSERT INTO [lkpObjectType] VALUES(19,	'InvService',		'WGFW',	8, '服务库')
INSERT INTO [lkpObjectType] VALUES(20,	'InvSpare',			'BYJ',	8, '备用机库')

-- rebecca 2020-07-14 recreate tblValConsumableOutput
alter table tblValComponent drop column TotalSeconds;

-- frank 2020-7-17 create tblInvComponent tblInvConsumable tblInvService tblInvSpare

-- frank 2020-07-21 create lkpPurchaseOrderStatus tblPurchaseOrder tblPurchaseComponent tblPurchaseConsumable tblPurchaseService
INSERT INTO [lkpObjectType] VALUES(21,	'PurchaseOrder',	'CGD',	8, '采购单')

-- frank 2020-07-30 recreate tblPurchaseComponent tblPurchaseConsumable


-- kevin 2020-07-24
ALTER TABLE tblUser
ADD SessionID varchar(50) NULL,WebSessionID varchar(50) NULL
GO
-- kevin 2020-07-27
UPDATE lkpDispatchReportType 
SET Description = '校准作业报告'
WHERE ID = 501

UPDATE lkpRequestType 
SET Description = '校准'
WHERE ID = 5

UPDATE lkpCustRptTemplateField 
SET FieldDesc = '校准周期'
WHERE TypeID = 1 AND Seq = 41

UPDATE lkpCustRptTemplateField 
SET FieldDesc = '校准周期类型'
WHERE TypeID = 1 AND Seq = 42


-- rebecca 2020-07-31
alter table tblValControl drop column HospitalFactor;
alter table tblValControl drop column AutualEngineer;

alter table tblValParameter drop column HospitalFactor
alter table tblValParameter add [HospitalFactor1] [decimal](5, 2) NOT NULL default 0.8
alter table tblValParameter add [HospitalFactor2] [decimal](5, 2) NOT NULL default 1
alter table tblValParameter add [HospitalFactor3] [decimal](5, 2) NOT NULL default 1.5
 
alter table tblValComponent add [UsageRefere] [int] NULL

-- frank 2020-08-04 recreate tblInvService create tblPurchaseOrderHistory
alter table tblPurchaseOrder add [FujiComments] [nvarchar](200) NULL

-- frank 2020-08-05
alter table tblPurchaseComponent add [InboundQty] [int] NOT NULL default 0
alter table tblPurchaseConsumable add [InboundQty] [int] NOT NULL default 0

-- frank 2020-08-07
alter table tblPurchaseConsumable alter column [Qty] [decimal](12,2) NOT NULL
alter table tblPurchaseConsumable alter column [InboundQty] [decimal](12,2) NOT NULL

-- rebecca 2020-08-10 create tblMaterialHistory
alter table tblValControl drop constraint [PK_tblValControl]
alter table tblValControl add constraint PK_tblValControl PRIMARY KEY ([CtlFlag],[UserID])

alter table tblValEquipment add [UserID] [int] NOT NULL default 0
alter table tblValEquipment drop constraint [PK_tblValEquipment]
alter table tblValEquipment add constraint PK_tblValEquipment PRIMARY KEY ([InSystem],[EquipmentID],[UserID])

alter table tblValSpare add [UserID] [int] NOT NULL default 0
alter table tblValSpare drop constraint [PK_tblValSpare]
alter table tblValSpare add constraint PK_tblValSpare PRIMARY KEY ([FujiClass2ID],[UserID])

alter table tblValConsumable add [UserID] [int] NOT NULL default 0
alter table tblValConsumable drop constraint [PK_tblValConsumable]
alter table tblValConsumable add constraint PK_tblValConsumable PRIMARY KEY ([ConsumableID],[UserID])

alter table tblValComponent add [UserID] [int] NOT NULL default 0
alter table tblValComponent drop constraint [PK_tblValComponent]
alter table tblValComponent add constraint PK_tblValComponent PRIMARY KEY ([InSystem],[EquipmentID],[ComponentID],[UserID])

alter table tblValEqptOutput add [UserID] [int] NOT NULL default 0
alter table tblValEqptOutput drop constraint [PK_tblValEqptOutput]
alter table tblValEqptOutput add constraint PK_tblValEqptOutput PRIMARY KEY ([UserID],[InSystem],[EquipmentID],[Year],[Month])

alter table tblValConsumableOutput add [UserID] [int] NOT NULL default 0
alter table tblValConsumableOutput drop constraint [PK_tblValConsumableOutput]
alter table tblValConsumableOutput add constraint PK_tblValConsumableOutput PRIMARY KEY ([UserID],[InSystem],[EquipmentID],[ConsumableID],[Year],[Month])

alter table tblValComponentOutput add [UserID] [int] NOT NULL default 0
alter table tblValComponentOutput drop constraint [PK_tblValComponentOutput]
alter table tblValComponentOutput add constraint PK_tblValComponentOutput PRIMARY KEY ([UserID],[InSystem],[EquipmentID],[ComponentID],[Year],[Month])

















