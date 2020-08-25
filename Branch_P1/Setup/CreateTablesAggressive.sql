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

-- kevin 2020-07-24
ALTER TABLE tblUser
ADD SessionID varchar(50) NULL,
	 WebSessionID varchar(50) NULL
GO

-- kevin 2020-07-28
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
