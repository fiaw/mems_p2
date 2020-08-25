﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataImport.Util;
using DataImport.Domain;

namespace DataImport.DataAccess
{
    class ImportDao : BaseDao
    {
        public void CleanData()
        {
            sqlStr = "delete from tblContract; " +
                    "delete from jctContractEqpt; " +             
                    "delete from tblContractFile; " +
                    "delete from tblSupplier; " +
                    "delete from tblSupplierFile; " +
                    "delete from tblEquipment; " +
                    "delete from tblEquipmentFile; " +
                    "delete from tblAuditHdr; " +
                    "delete from tblAuditDetail; " +
                    "delete from jctRequestEqpt; " +
                    "delete from tblDispatch; " +
                    "delete from tblDispatchHistory; " +
                    "delete from tblDispatchJournal; " +
                    "delete from tblDispatchJournalHistory; " +
                    "delete from tblDispatchReport; " +
                    "delete from tblDispatchReportFile; " +
                    "delete from tblDispatchReportHistory; " +
                    "delete from tblReportAccessory; " +
                    "delete from tblReportAccessoryFile; " +
                    "delete from tblRequest; " +
                    "delete from tblRequestFile; " +
                    "delete from tblRequestHistory; " +
                    "delete from tblServiceHis; " +
                    "delete from tblFujiClass1 where ID > 0; " +                  	                      
                    "delete from jctFujiClass1EqpType; " +	                      
                    "delete from tblFujiClass2 where ID > 0; " +	        	                      
                    "delete from jctFujiClass2EqpType; " +	              
                    "delete from tblFaultRate; " +	                       
                    "delete from tblComponent; " +              
                    "delete from tblConsumable; " +	       
                    "dbcc checkident ('tblFujiClass1',reseed,0) ; " +  
                    "dbcc checkident ('tblFujiClass2',reseed,0); " +  
                    "dbcc checkident ('tblComponent',reseed,0) ; " +  
                    "dbcc checkident ('tblConsumable',reseed,0); " +   
                    "dbcc checkident ('tblContract',reseed,0) ; " +
                    "dbcc checkident ('tblSupplier',reseed,0) ; " +
                    "dbcc checkident ('tblEquipment',reseed,0) ; " +
                    "dbcc checkident ('tblDispatch',reseed,0) ; " +
                    "dbcc checkident ('tblDispatchJournal',reseed,0) ; " +
                    "dbcc checkident ('tblDispatchReport',reseed,0) ; " +
                    "dbcc checkident ('tblReportAccessory',reseed,0) ; " +
                    "dbcc checkident ('tblRequest',reseed,0) ; " +
                    "dbcc checkident ('tblServiceHis',reseed,0) ; ";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.ExecuteNonQuery();
            }
        }

        public void ImportSupplier(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblSupplier(TypeID,Name,Province,Mobile, Address,Contact,ContactMobile,AddDate,IsActive) " +
                     " VALUES(@TypeID,@Name,@Province,@Mobile, @Address,@Contact,@ContactMobile,@AddDate,@IsActive);";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@TypeID", SqlDbType.Int);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Province", SqlDbType.NVarChar);
                command.Parameters.Add("@Mobile", SqlDbType.VarChar);
                command.Parameters.Add("@Address", SqlDbType.NVarChar);
                command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                command.Parameters.Add("@ContactMobile", SqlDbType.VarChar);
                command.Parameters.Add("@AddDate", SqlDbType.DateTime);   
                command.Parameters.Add("@IsActive", SqlDbType.Bit);          

                foreach (SupplierInfo info in infos)
                {
                    if (info.SupplierType.ID == 0) return;

                    command.Parameters["@TypeID"].Value = SQLUtil.ConvertInt(info.SupplierType.ID);
                    command.Parameters["@Name"].Value = SQLUtil.TrimNull(info.Name);
                    command.Parameters["@Province"].Value = SQLUtil.TrimNull(info.Province);
                    command.Parameters["@Mobile"].Value = SQLUtil.EmptyStringToNull(info.Mobile);
                    command.Parameters["@Address"].Value = SQLUtil.EmptyStringToNull(info.Address);
                    command.Parameters["@Contact"].Value = SQLUtil.TrimNull(info.Contact);
                    command.Parameters["@ContactMobile"].Value = SQLUtil.EmptyStringToNull(info.ContactMobile);
                    command.Parameters["@AddDate"].Value = info.AddDate == DateTime.MinValue ? DateTime.Now : info.AddDate;
                    command.Parameters["@IsActive"].Value = info.IsActive;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportEquipment(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblEquipment(EquipmentLevel,Name,EquipmentCode,SerialCode,ManufacturerID,EquipmentClass1,EquipmentClass2,EquipmentClass3, " +
                     " FixedAsset,AssetCode,AssetLevel,DepreciationYears,ValidityStartDate,ValidityEndDate, " +
                     " SaleContractName,SupplierID,PurchaseWay,PurchaseAmount,PurchaseDate,IsImport, " +
                     " DepartmentID,InstalSite,InstalDate,Accepted,AcceptanceDate,UsageStatusID,EquipmentStatusID,ScrapDate,MaintenancePeriod, " +
                     " MaintenanceTypeID,PatrolPeriod,PatrolTypeID,CorrectionPeriod,CorrectionTypeID,MandatoryTestStatus,MandatoryTestDate,RecallFlag, " +
                     " RecallDate,CreateDate,CreateUserID,UpdateDate,ResponseTimeLength,ServiceScope,Brand,Comments,ManufacturingDate,UseageDate,FujiClass2ID,CTSerialCode,CTUsedSeconds ) " +
                     " VALUES(@EquipmentLevel,@Name,@EquipmentCode,@SerialCode,@ManufacturerID,@EquipmentClass1,@EquipmentClass2,@EquipmentClass3, " +
                     " @FixedAsset,@AssetCode,@AssetLevel,@DepreciationYears,@ValidityStartDate,@ValidityEndDate, " +
                     " @SaleContractName,@SupplierID,@PurchaseWay,@PurchaseAmount,@PurchaseDate,@IsImport, " +
                     " @DepartmentID,@InstalSite,@InstalDate,@Accepted,@AcceptanceDate,@UsageStatusID,@EquipmentStatusID,@ScrapDate,@MaintenancePeriod, " +
                     " @MaintenanceTypeID,@PatrolPeriod,@PatrolTypeID,@CorrectionPeriod,@CorrectionTypeID,@MandatoryTestStatus,@MandatoryTestDate,@RecallFlag, " +
                     " @RecallDate,@CreateDate,@CreateUserID,@CreateDate,@ResponseTimeLength,1,@Brand,@Comments,@ManufacturingDate,@UseageDate,@FujiClass2ID,@CTSerialCode,@CTUsedSeconds);";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@EquipmentLevel", SqlDbType.Int);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@EquipmentCode", SqlDbType.NVarChar);
                command.Parameters.Add("@SerialCode", SqlDbType.VarChar);
                command.Parameters.Add("@ManufacturerID", SqlDbType.Int);
                command.Parameters.Add("@EquipmentClass1", SqlDbType.VarChar);
                command.Parameters.Add("@EquipmentClass2", SqlDbType.VarChar);
                command.Parameters.Add("@EquipmentClass3", SqlDbType.VarChar);
                command.Parameters.Add("@FixedAsset", SqlDbType.Bit);
                command.Parameters.Add("@AssetCode", SqlDbType.VarChar);
                command.Parameters.Add("@AssetLevel", SqlDbType.Int);
                command.Parameters.Add("@DepreciationYears", SqlDbType.Int);
                command.Parameters.Add("@ValidityStartDate", SqlDbType.DateTime);
                command.Parameters.Add("@ValidityEndDate", SqlDbType.DateTime);
                command.Parameters.Add("@SaleContractName", SqlDbType.NVarChar);
                command.Parameters.Add("@SupplierID", SqlDbType.Int);
                command.Parameters.Add("@PurchaseWay", SqlDbType.NVarChar);
                command.Parameters.Add("@PurchaseAmount", SqlDbType.Decimal);
                command.Parameters.Add("@PurchaseDate", SqlDbType.DateTime);
                command.Parameters.Add("@IsImport", SqlDbType.Bit);
                command.Parameters.Add("@DepartmentID", SqlDbType.Int);
                command.Parameters.Add("@InstalSite", SqlDbType.NVarChar);
                command.Parameters.Add("@InstalDate", SqlDbType.DateTime);
                command.Parameters.Add("@Accepted", SqlDbType.Bit);
                command.Parameters.Add("@AcceptanceDate", SqlDbType.DateTime);
                command.Parameters.Add("@UsageStatusID", SqlDbType.Int);
                command.Parameters.Add("@EquipmentStatusID", SqlDbType.Int);
                command.Parameters.Add("@ScrapDate", SqlDbType.DateTime);
                command.Parameters.Add("@MaintenancePeriod", SqlDbType.Int);
                command.Parameters.Add("@MaintenanceTypeID", SqlDbType.Int);
                command.Parameters.Add("@PatrolPeriod", SqlDbType.Int);
                command.Parameters.Add("@PatrolTypeID", SqlDbType.Int);
                command.Parameters.Add("@CorrectionPeriod", SqlDbType.Int);
                command.Parameters.Add("@CorrectionTypeID", SqlDbType.Int);
                command.Parameters.Add("@MandatoryTestStatus", SqlDbType.Int);
                command.Parameters.Add("@MandatoryTestDate", SqlDbType.DateTime);
                command.Parameters.Add("@RecallFlag", SqlDbType.Bit);
                command.Parameters.Add("@RecallDate", SqlDbType.DateTime);
                command.Parameters.Add("@CreateUserID", SqlDbType.Int);
                command.Parameters.Add("@CreateDate", SqlDbType.DateTime);
                command.Parameters.Add("@ResponseTimeLength", SqlDbType.Int);
                command.Parameters.Add("@Brand", SqlDbType.NVarChar);
                command.Parameters.Add("@Comments", SqlDbType.NVarChar);
                command.Parameters.Add("@ManufacturingDate", SqlDbType.DateTime);
                command.Parameters.Add("@UseageDate", SqlDbType.DateTime);
                command.Parameters.Add("@FujiClass2ID", SqlDbType.Int);
                command.Parameters.Add("@CTSerialCode", SqlDbType.NVarChar);
                command.Parameters.Add("@CTUsedSeconds", SqlDbType.Decimal);   

                foreach (EquipmentInfo info in infos)
                {
                    if (info.Name.Length == 0) return;

                    command.Parameters["@EquipmentLevel"].Value = info.EquipmentLevel.ID;
                    command.Parameters["@Name"].Value = SQLUtil.TrimNull(info.Name);
                    command.Parameters["@EquipmentCode"].Value = SQLUtil.TrimNull(info.EquipmentCode);
                    command.Parameters["@SerialCode"].Value = SQLUtil.TrimNull(info.SerialCode);
                    command.Parameters["@ManufacturerID"].Value = info.ManufacturerID;
                    command.Parameters["@EquipmentClass1"].Value = SQLUtil.TrimNull(info.EquipmentClass1.ToString("D2"));
                    command.Parameters["@EquipmentClass2"].Value = SQLUtil.TrimNull(info.EquipmentClass2.ToString("D2"));
                    command.Parameters["@EquipmentClass3"].Value = SQLUtil.TrimNull(info.EquipmentClass3.ToString("D2"));
                    command.Parameters["@FixedAsset"].Value = info.FixedAsset;
                    command.Parameters["@AssetCode"].Value = SQLUtil.TrimNull(info.AssetCode);
                    command.Parameters["@AssetLevel"].Value = info.AssetLevel.ID;
                    command.Parameters["@DepreciationYears"].Value = info.DepreciationYears;
                    command.Parameters["@ValidityStartDate"].Value = SQLUtil.MinDateToNull(info.ValidityStartDate);
                    command.Parameters["@ValidityEndDate"].Value = SQLUtil.MinDateToNull(info.ValidityEndDate);
                    command.Parameters["@SaleContractName"].Value = SQLUtil.TrimNull(info.SaleContractName);
                    command.Parameters["@SupplierID"].Value = info.SupplierID;
                    command.Parameters["@PurchaseWay"].Value = SQLUtil.TrimNull(info.PurchaseWay);
                    command.Parameters["@PurchaseAmount"].Value = info.PurchaseAmount;
                    command.Parameters["@PurchaseDate"].Value = SQLUtil.MinDateToNull(info.PurchaseDate);
                    command.Parameters["@IsImport"].Value = info.IsImport;
                    command.Parameters["@DepartmentID"].Value = info.Department.ID;
                    command.Parameters["@InstalSite"].Value = SQLUtil.TrimNull(info.InstalSite);
                    command.Parameters["@InstalDate"].Value = SQLUtil.MinDateToNull(info.InstalDate);
                    command.Parameters["@Accepted"].Value = info.Accepted;
                    command.Parameters["@AcceptanceDate"].Value = SQLUtil.MinDateToNull(info.AcceptanceDate);
                    command.Parameters["@UsageStatusID"].Value = info.UsageStatus.ID;
                    command.Parameters["@EquipmentStatusID"].Value = info.EquipmentStatus.ID;
                    command.Parameters["@ScrapDate"].Value = SQLUtil.MinDateToNull(info.ScrapDate);
                    command.Parameters["@MaintenancePeriod"].Value = info.MaintenancePeriod;
                    command.Parameters["@MaintenanceTypeID"].Value = info.MaintenanceType.ID;
                    command.Parameters["@PatrolPeriod"].Value = info.PatrolPeriod;
                    command.Parameters["@PatrolTypeID"].Value = info.PatrolType.ID;
                    command.Parameters["@CorrectionPeriod"].Value = info.CorrectionPeriod;
                    command.Parameters["@CorrectionTypeID"].Value = info.CorrectionType.ID;
                    command.Parameters["@MandatoryTestStatus"].Value = info.MandatoryTestStatus.ID;
                    command.Parameters["@MandatoryTestDate"].Value = SQLUtil.MinDateToNull(info.MandatoryTestDate);
                    command.Parameters["@RecallFlag"].Value = info.RecallFlag;
                    command.Parameters["@RecallDate"].Value = SQLUtil.MinDateToNull(info.RecallDate);
                    command.Parameters["@CreateUserID"].Value = info.CreateUserID;
                    command.Parameters["@CreateDate"].Value = info.CreateDate == DateTime.MinValue ? DateTime.Now : info.CreateDate;
                    command.Parameters["@ResponseTimeLength"].Value = info.ResponseTimeLength;
                    command.Parameters["@Brand"].Value = SQLUtil.TrimNull(info.Brand);
                    command.Parameters["@Comments"].Value = SQLUtil.TrimNull(info.Comments);
                    command.Parameters["@ManufacturingDate"].Value = SQLUtil.MinDateToNull(info.ManufacturingDate);
                    command.Parameters["@UseageDate"].Value = SQLUtil.MinDateToNull(info.UseageDate);
                    command.Parameters["@FujiClass2ID"].Value = info.FujiClass2ID == 0 ? -1 : info.FujiClass2ID;
                    command.Parameters["@CTSerialCode"].Value = SQLUtil.TrimNull(info.CTSerialCode);
                    command.Parameters["@CTUsedSeconds"].Value = info.CTUsedSeconds;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportContract(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblContract(SupplierID,ContractNum,"+
                            "Name,TypeID,ScopeID,ScopeComments,Amount,ProjectNum,StartDate,EndDate,Comments)" +
                     "VALUES(@SupplierID,@ContractNum,@Name,@TypeID,@ScopeID,@ScopeComments,@Amount," +
                            "@ProjectNum,@StartDate,@EndDate,@Comments)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@SupplierID", SqlDbType.Int);
                command.Parameters.Add("@ContractNum", SqlDbType.VarChar);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@TypeID", SqlDbType.Int);
                command.Parameters.Add("@ScopeID", SqlDbType.Int);
                command.Parameters.Add("@ScopeComments", SqlDbType.NVarChar);
                command.Parameters.Add("@Amount", SqlDbType.Decimal);
                command.Parameters.Add("@ProjectNum", SqlDbType.NVarChar);
                command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                command.Parameters.Add("@EndDate", SqlDbType.DateTime);
                command.Parameters.Add("@Comments", SqlDbType.NVarChar);     

                foreach (ContractInfo info in infos)
                {
                    if (string.IsNullOrEmpty(info.Name)) return;

                    command.Parameters["@SupplierID"].Value = info.SupplierID;
                    command.Parameters["@ContractNum"].Value = SQLUtil.TrimNull(info.ContractNum);
                    command.Parameters["@Name"].Value = SQLUtil.TrimNull(info.Name);
                    command.Parameters["@TypeID"].Value = SQLUtil.ConvertInt(info.Type.ID);
                    command.Parameters["@ScopeID"].Value = SQLUtil.ConvertInt(info.Scope.ID);
                    command.Parameters["@ScopeComments"].Value = SQLUtil.TrimNull(info.ScopeComments);
                    command.Parameters["@Amount"].Value = SQLUtil.ConvertDouble(info.Amount);
                    command.Parameters["@ProjectNum"].Value = SQLUtil.TrimNull(info.ProjectNum);
                    command.Parameters["@StartDate"].Value = SQLUtil.ConvertDateTime(info.StartDate);
                    command.Parameters["@EndDate"].Value = SQLUtil.ConvertDateTime(info.EndDate);
                    command.Parameters["@Comments"].Value = SQLUtil.TrimNull(info.Comments);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportContractEqpt(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO jctContractEqpt (ContractID,EquipmentID)" +
                        "VALUES(@ContractID,@EquipmentID)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@ContractID", SqlDbType.Int);
                command.Parameters.Add("@EquipmentID", SqlDbType.Int);

                foreach (ContractEqptInfo info in infos)
                {
                    if (info.ContractID == 0) return;

                    command.Parameters["@ContractID"].Value = info.ContractID;
                    command.Parameters["@EquipmentID"].Value = info.EquipmentID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportRequest(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblRequest(Source,RequestType,IsRecall,RequestUserID,RequestUserName,RequestUserMobile," +
                     " Subject,EquipmentStatus,FaultTypeID,FaultDesc,StatusID,DealTypeID,PriorityID,RequestDate,DistributeDate,ResponseDate,CloseDate,SelectiveDate,LastStatusID) " +
                     " VALUES(@Source,@RequestType,@IsRecall,@RequestUserID,@RequestUserName,@RequestUserMobile," +
                     " @Subject,@EquipmentStatus,@FaultTypeID,@FaultDesc,@StatusID,@DealTypeID,@PriorityID,@RequestDate,@DistributeDate,@ResponseDate,@CloseDate, @SelectiveDate,1)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@Source", SqlDbType.Int);
                command.Parameters.Add("@RequestType", SqlDbType.Int);
                command.Parameters.Add("@IsRecall", SqlDbType.Bit);
                command.Parameters.Add("@RequestUserID", SqlDbType.Int);
                command.Parameters.Add("@RequestUserName", SqlDbType.NVarChar);
                command.Parameters.Add("@RequestUserMobile", SqlDbType.VarChar);
                command.Parameters.Add("@Subject", SqlDbType.NVarChar);
                command.Parameters.Add("@EquipmentStatus", SqlDbType.Int);
                command.Parameters.Add("@FaultTypeID", SqlDbType.Int);
                command.Parameters.Add("@FaultDesc", SqlDbType.NVarChar);
                command.Parameters.Add("@StatusID", SqlDbType.Int);
                command.Parameters.Add("@DealTypeID", SqlDbType.Int);
                command.Parameters.Add("@PriorityID", SqlDbType.Int);
                command.Parameters.Add("@RequestDate", SqlDbType.DateTime);
                command.Parameters.Add("@DistributeDate", SqlDbType.DateTime);
                command.Parameters.Add("@ResponseDate", SqlDbType.DateTime);
                command.Parameters.Add("@CloseDate", SqlDbType.DateTime);
                command.Parameters.Add("@SelectiveDate", SqlDbType.DateTime);

                foreach (RequestInfo info in infos)
                {
                    if (info.Source.ID == 0) return;

                    command.Parameters["@Source"].Value = info.Source.ID;
                    command.Parameters["@RequestType"].Value = info.RequestType.ID;
                    command.Parameters["@IsRecall"].Value = info.IsRecall;
                    command.Parameters["@RequestUserID"].Value = SQLUtil.ZeroToNull(info.RequestUser.ID);
                    command.Parameters["@RequestUserName"].Value = SQLUtil.EmptyStringToNull(info.RequestUser.Name);
                    command.Parameters["@RequestUserMobile"].Value = SQLUtil.EmptyStringToNull(info.RequestUser.Mobile);
                    command.Parameters["@Subject"].Value = SQLUtil.TrimNull(info.Subject);
                    command.Parameters["@EquipmentStatus"].Value = info.MachineStatus.ID;
                    command.Parameters["@FaultTypeID"].Value = SQLUtil.ZeroToNull(info.FaultType.ID);
                    command.Parameters["@FaultDesc"].Value = SQLUtil.TrimNull(info.FaultDesc);
                    command.Parameters["@StatusID"].Value = info.Status.ID;
                    command.Parameters["@DealTypeID"].Value = info.DealType.ID;
                    command.Parameters["@PriorityID"].Value = info.Priority.ID;
                    command.Parameters["@RequestDate"].Value = info.RequestDate == DateTime.MinValue ? DateTime.Now : info.RequestDate;
                    command.Parameters["@DistributeDate"].Value = SQLUtil.MinDateToNull(info.DistributeDate);
                    command.Parameters["@ResponseDate"].Value = SQLUtil.MinDateToNull(info.ResponseDate);
                    command.Parameters["@CloseDate"].Value = SQLUtil.MinDateToNull(info.CloseDate);
                    command.Parameters["@SelectiveDate"].Value = SQLUtil.MinDateToNull(info.SelectiveDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportRequestEqpt(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO jctRequestEqpt(RequestID,EquipmentID)" +
                        "VALUES(@RequestID,@EquipmentID)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@RequestID", SqlDbType.Int);
                command.Parameters.Add("@EquipmentID", SqlDbType.Int);

                foreach (RequestEqptInfo info in infos)
                {
                    if (info.RequestID == 0) return;

                    command.Parameters["@RequestID"].Value = info.RequestID;
                    command.Parameters["@EquipmentID"].Value = info.EquipmentID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportDispatch(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblDispatch(RequestID,RequestType,UrgencyID,EquipmentStatus,EngineerID," +
                     " ScheduleDate,LeaderComments,StatusID,CreateDate,StartDate,EndDate) " +
                     " VALUES(@RequestID,@RequestType,@UrgencyID,@EquipmentStatus,@EngineerID," +
                     " @ScheduleDate,@LeaderComments,@StatusID,@CreateDate,@StartDate,@EndDate)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@RequestID", SqlDbType.Int);
                command.Parameters.Add("@RequestType", SqlDbType.Int);
                command.Parameters.Add("@UrgencyID", SqlDbType.Int);
                command.Parameters.Add("@EquipmentStatus", SqlDbType.Int);
                command.Parameters.Add("@EngineerID", SqlDbType.Int);
                command.Parameters.Add("@ScheduleDate", SqlDbType.DateTime);
                command.Parameters.Add("@LeaderComments", SqlDbType.NVarChar);
                command.Parameters.Add("@StatusID", SqlDbType.Int);
                command.Parameters.Add("@CreateDate", SqlDbType.DateTime);
                command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                command.Parameters.Add("@EndDate", SqlDbType.DateTime);

                foreach (DispatchInfo info in infos)
                {
                    if (info.Request.ID == 0) return;

                    command.Parameters["@RequestID"].Value = info.Request.ID;
                    command.Parameters["@RequestType"].Value = info.RequestType.ID;
                    command.Parameters["@UrgencyID"].Value = SQLUtil.ZeroToNull(info.Urgency.ID);
                    command.Parameters["@EquipmentStatus"].Value = info.MachineStatus.ID;
                    command.Parameters["@EngineerID"].Value = info.Engineer.ID;
                    command.Parameters["@ScheduleDate"].Value = info.ScheduleDate;
                    command.Parameters["@LeaderComments"].Value = SQLUtil.TrimNull(info.LeaderComments);
                    command.Parameters["@StatusID"].Value = info.Status.ID;
                    command.Parameters["@CreateDate"].Value = info.CreateDate == DateTime.MinValue ? DateTime.Now : info.CreateDate;
                    command.Parameters["@StartDate"].Value = SQLUtil.MinDateToNull(info.StartDate);
                    command.Parameters["@EndDate"].Value = SQLUtil.MinDateToNull(info.EndDate);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportDispatchJournal(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblDispatchJournal(DispatchID,FaultCode,JobContent,ResultStatusID, " +
                            " FollowProblem,Advice,UserName,UserMobile,Signed,StatusID) " +
                     " VALUES(@DispatchID,@FaultCode,@JobContent,@ResultStatusID, " +
                            " @FollowProblem,@Advice,@UserName,@UserMobile,1,@StatusID)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@DispatchID", SqlDbType.Int);
                command.Parameters.Add("@FaultCode", SqlDbType.NVarChar);
                command.Parameters.Add("@JobContent", SqlDbType.NVarChar);
                command.Parameters.Add("@ResultStatusID", SqlDbType.Int);
                command.Parameters.Add("@FollowProblem", SqlDbType.NVarChar);
                command.Parameters.Add("@Advice", SqlDbType.NVarChar);
                command.Parameters.Add("@UserName", SqlDbType.NVarChar);
                command.Parameters.Add("@UserMobile", SqlDbType.VarChar);
                command.Parameters.Add("@StatusID", SqlDbType.Int);

                foreach (DispatchJournalInfo info in infos)
                {
                    if (info.DispatchID == 0) return;

                    command.Parameters["@DispatchID"].Value = info.DispatchID;
                    command.Parameters["@FaultCode"].Value = SQLUtil.TrimNull(info.FaultCode);
                    command.Parameters["@JobContent"].Value = SQLUtil.TrimNull(info.JobContent);
                    command.Parameters["@ResultStatusID"].Value = info.ResultStatus.ID;
                    command.Parameters["@FollowProblem"].Value = SQLUtil.TrimNull(info.FollowProblem);
                    command.Parameters["@Advice"].Value = SQLUtil.TrimNull(info.Advice);
                    command.Parameters["@UserName"].Value = SQLUtil.EmptyStringToNull(info.UserName);
                    command.Parameters["@UserMobile"].Value = SQLUtil.EmptyStringToNull(info.UserMobile);
                    command.Parameters["@StatusID"].Value = info.Status.ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportDispatchReport(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblDispatchReport(DispatchID ,TypeID ,FaultCode ," +
                " FaultDesc ,SolutionCauseAnalysis ,SolutionWay, IsPrivate, ServiceProvider, SolutionResultStatusID ," +
                " SolutionUnsolvedComments ,DelayReason,Comments,FujiComments ,StatusID ) " +
                     " VALUES(@DispatchID ,@TypeID ,@FaultCode ," +
                " @FaultDesc ,@SolutionCauseAnalysis , @SolutionWay,@IsPrivate,@ServiceProvider, @SolutionResultStatusID ," +
                " @SolutionUnsolvedComments ,@DelayReason,@Comments,@FujiComments ,@StatusID)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@DispatchID", SqlDbType.Int);
                command.Parameters.Add("@TypeID", SqlDbType.Int);
                command.Parameters.Add("@FaultCode", SqlDbType.NVarChar);
                command.Parameters.Add("@FaultDesc", SqlDbType.NVarChar);
                command.Parameters.Add("@SolutionCauseAnalysis", SqlDbType.NVarChar);
                command.Parameters.Add("@SolutionWay", SqlDbType.NVarChar);
                command.Parameters.Add("@IsPrivate", SqlDbType.Bit);
                command.Parameters.Add("@ServiceProvider", SqlDbType.Int);
                command.Parameters.Add("@SolutionResultStatusID", SqlDbType.Int);
                command.Parameters.Add("@SolutionUnsolvedComments", SqlDbType.NVarChar);
                command.Parameters.Add("@DelayReason", SqlDbType.NVarChar);
                command.Parameters.Add("@Comments", SqlDbType.NVarChar);
                command.Parameters.Add("@FujiComments", SqlDbType.NVarChar);
                command.Parameters.Add("@StatusID", SqlDbType.Int);                     

                foreach (DispatchReportInfo info in infos)
                {
                    if (info.DispatchID == 0) return;

                    command.Parameters["@DispatchID"].Value = info.DispatchID;
                    command.Parameters["@TypeID"].Value = info.Type.ID;
                    command.Parameters["@FaultCode"].Value = SQLUtil.TrimNull(info.FaultCode);
                    command.Parameters["@FaultDesc"].Value = SQLUtil.TrimNull(info.FaultDesc);
                    command.Parameters["@SolutionCauseAnalysis"].Value = SQLUtil.TrimNull(info.SolutionCauseAnalysis);
                    command.Parameters["@SolutionWay"].Value = SQLUtil.TrimNull(info.SolutionWay);
                    command.Parameters["@IsPrivate"].Value = info.IsPrivate;
                    command.Parameters["@ServiceProvider"].Value = SQLUtil.ZeroToNull(info.ServiceProvider.ID);
                    command.Parameters["@SolutionResultStatusID"].Value = info.SolutionResultStatus.ID;
                    command.Parameters["@SolutionUnsolvedComments"].Value = SQLUtil.TrimNull(info.SolutionUnsolvedComments);
                    command.Parameters["@DelayReason"].Value = SQLUtil.TrimNull(info.DelayReason);
                    command.Parameters["@Comments"].Value = SQLUtil.TrimNull(info.Comments);
                    command.Parameters["@FujiComments"].Value = SQLUtil.TrimNull(info.FujiComments);
                    command.Parameters["@StatusID"].Value = info.Status.ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportReportAccessory(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblReportAccessory(DispatchReportID, Name, SourceID, SupplierID, NewSerialCode, OldSerialCode, Qty, Amount) " +
                     " VALUES(@DispatchReportID, @Name, @SourceID, @SupplierID, @NewSerialCode, @OldSerialCode, @Qty, @Amount)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@DispatchReportID", SqlDbType.Int);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@SourceID", SqlDbType.Int);
                command.Parameters.Add("@SupplierID", SqlDbType.Int);
                command.Parameters.Add("@NewSerialCode", SqlDbType.VarChar);
                command.Parameters.Add("@OldSerialCode", SqlDbType.VarChar);
                command.Parameters.Add("@Qty", SqlDbType.Int);
                command.Parameters.Add("@Amount", SqlDbType.Decimal);       

                foreach (ReportAccessoryInfo info in infos)
                {
                    if (info.DispatchReportID == 0) return;

                    command.Parameters["@DispatchReportID"].Value = info.DispatchReportID;
                    command.Parameters["@Name"].Value = SQLUtil.TrimNull(info.Name);
                    command.Parameters["@SourceID"].Value = info.Source.ID;
                    command.Parameters["@SupplierID"].Value = SQLUtil.ZeroToNull(info.SupplierID);
                    command.Parameters["@NewSerialCode"].Value = SQLUtil.TrimNull(info.NewSerialCode);
                    command.Parameters["@OldSerialCode"].Value = SQLUtil.TrimNull(info.OldSerialCode);
                    command.Parameters["@Qty"].Value = info.Qty;
                    command.Parameters["@Amount"].Value = info.Amount;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportServiceHis(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblServiceHis(EquipmentID,TransDate,Income)" +
                        "VALUES(@EquipmentID,@TransDate,@Income)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@EquipmentID", SqlDbType.Int);
                command.Parameters.Add("@TransDate", SqlDbType.DateTime);
                command.Parameters.Add("@Income", SqlDbType.Decimal);

                foreach (ServiceHisInfo info in infos)
                {
                    if (info.EquipmentID == 0) return;

                    command.Parameters["@EquipmentID"].Value = info.EquipmentID;
                    command.Parameters["@TransDate"].Value = info.TransDate;
                    command.Parameters["@Income"].Value = info.Income;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportFujiClass1(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblFujiClass1(Name,Description,AddDate)" +
                        "VALUES(@Name,@Description,@AddDate)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Description", SqlDbType.NVarChar);
                command.Parameters.Add("@AddDate", SqlDbType.DateTime);

                foreach (FujiClass1Info info in infos)
                {
                    command.Parameters["@Name"].Value = info.Name;
                    command.Parameters["@Description"].Value = info.Description;
                    command.Parameters["@AddDate"].Value = info.AddDate;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportFujiClass1EqpType(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO jctFujiClass1EqpType(EquipmentType1ID,EquipmentType2ID,FujiClass1ID)" +
                        "VALUES(@EquipmentType1ID,@EquipmentType2ID,@FujiClass1ID)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@EquipmentType1ID", SqlDbType.VarChar);
                command.Parameters.Add("@EquipmentType2ID", SqlDbType.VarChar);
                command.Parameters.Add("@FujiClass1ID", SqlDbType.Int);

                foreach (FujiClass1EqpType info in infos)
                {
                    command.Parameters["@EquipmentType1ID"].Value = SQLUtil.TrimNull(info.EquipmentType1ID.ToString("D2"));
                    command.Parameters["@EquipmentType2ID"].Value = SQLUtil.TrimNull(info.EquipmentType2ID.ToString("D2"));
                    command.Parameters["@FujiClass1ID"].Value = info.FujiClass1ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportFujiClass2(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblFujiClass2(FujiClass1ID,Name,Description,AddDate,IncludeLabour,PatrolTimes,PatrolHours,MaintenanceTimes,MaintenanceHours,RepairHours,IncludeContract, " +
                    " FullCoveragePtg,TechCoveragePtg,IncludeSpare,SparePrice,SpareRentPtg,IncludeRepair,Usage,EquipmentType,RepairComponentCost,Repair3partyRatio,Repair3partyCost,RepairCostRatio,MethodID)" +
                    " VALUES(@FujiClass1ID,@Name,@Description,@AddDate,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1)" +
                   @" DECLARE @i INT
                      DECLARE @id INT  
                      DECLARE @j INT  
                      SELECT @id = @@IDENTITY
                      SET @i=0 
                      WHILE @i<10
                      BEGIN 
	                      SET @j=0
	                      WHILE @j<12
	                      BEGIN
		                      INSERT INTO [tblFaultRate] VALUES(1,@id,CONVERT(VARCHAR(2),@i+1),CONVERT(VARCHAR(2),@j+1),0)
		                      SET @j=@j+1
	                      END
	                      SET @i = @i+1
                      END";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@FujiClass1ID", SqlDbType.Int);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Description", SqlDbType.NVarChar);
                command.Parameters.Add("@AddDate", SqlDbType.DateTime);

                foreach (FujiClass2Info info in infos)
                {
                    command.Parameters["@FujiClass1ID"].Value = info.FujiClass1ID;
                    command.Parameters["@Name"].Value = info.Name;
                    command.Parameters["@Description"].Value = info.Description;
                    command.Parameters["@AddDate"].Value = info.AddDate;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportFujiClass2EqpType(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO jctFujiClass2EqpType(EquipmentType1ID,EquipmentType2ID,FujiClass2ID)" +
                        "VALUES(@EquipmentType1ID,@EquipmentType2ID,@FujiClass2ID)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@EquipmentType1ID", SqlDbType.VarChar);
                command.Parameters.Add("@EquipmentType2ID", SqlDbType.VarChar);
                command.Parameters.Add("@FujiClass2ID", SqlDbType.Int);

                foreach (FujiClass2EqpType info in infos)
                {
                    command.Parameters["@EquipmentType1ID"].Value = SQLUtil.TrimNull(info.EquipmentType1ID.ToString("D2"));
                    command.Parameters["@EquipmentType2ID"].Value = SQLUtil.TrimNull(info.EquipmentType2ID.ToString("D2"));
                    command.Parameters["@FujiClass2ID"].Value = info.FujiClass2ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportComponent(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblComponent(FujiClass2ID,Name,Description,TypeID,StdPrice,Usage,TotalSeconds,SecondsPer,IsIncluded,IncludeContract,IsActive,AddDate)" +
                    " VALUES(@FujiClass2ID,@Name,@Description,@TypeID,@StdPrice,@Usage,@TotalSeconds,@SecondsPer,1,0,1,@AddDate)" +
                   @" DECLARE @i INT
                      DECLARE @id INT  
                      DECLARE @j INT  
                      SELECT @id = @@IDENTITY
                      SET @i=0 
                      WHILE @i<10
                      BEGIN 
	                      SET @j=0
	                      WHILE @j<12
	                      BEGIN
		                      INSERT INTO [tblFaultRate] VALUES(2,@id,CONVERT(VARCHAR(2),@i+1),CONVERT(VARCHAR(2),@j+1),0)
		                      SET @j=@j+1
	                      END
	                      SET @i = @i+1
                      END";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@FujiClass2ID", SqlDbType.Int);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Description", SqlDbType.NVarChar);
                command.Parameters.Add("@TypeID", SqlDbType.Int);
                command.Parameters.Add("@StdPrice", SqlDbType.Decimal);
                command.Parameters.Add("@Usage", SqlDbType.Int);
                command.Parameters.Add("@TotalSeconds", SqlDbType.Int);
                command.Parameters.Add("@SecondsPer", SqlDbType.Decimal);
                command.Parameters.Add("@AddDate", SqlDbType.DateTime);

                foreach (ComponentInfo info in infos)
                {
                    command.Parameters["@FujiClass2ID"].Value = info.FujiClass2ID;
                    command.Parameters["@Name"].Value = info.Name;
                    command.Parameters["@Description"].Value = info.Description;
                    command.Parameters["@TypeID"].Value = info.TypeID;
                    command.Parameters["@StdPrice"].Value = info.StdPrice;
                    command.Parameters["@Usage"].Value = info.Usage;
                    command.Parameters["@TotalSeconds"].Value = info.TotalSeconds;
                    command.Parameters["@SecondsPer"].Value = info.SecondsPer;
                    command.Parameters["@AddDate"].Value = info.AddDate;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ImportConsumable(List<EntityInfo> infos)
        {
            sqlStr = "INSERT INTO tblConsumable(FujiClass2ID,Name,Description,TypeID,StdPrice,ReplaceTimes,CostPer,IsIncluded,IncludeContract,IsActive,AddDate)" +
                        "VALUES(@FujiClass2ID,@Name,@Description,@TypeID,@StdPrice,@ReplaceTimes,@CostPer,1,0,1,@AddDate)";

            using (SqlCommand command = DatabaseConnection.GetCommand(sqlStr))
            {
                command.Parameters.Add("@FujiClass2ID", SqlDbType.Int);
                command.Parameters.Add("@Name", SqlDbType.NVarChar);
                command.Parameters.Add("@Description", SqlDbType.NVarChar);
                command.Parameters.Add("@TypeID", SqlDbType.Int);
                command.Parameters.Add("@StdPrice", SqlDbType.Decimal);
                command.Parameters.Add("@ReplaceTimes", SqlDbType.Decimal);
                command.Parameters.Add("@CostPer", SqlDbType.Decimal);
                command.Parameters.Add("@AddDate", SqlDbType.DateTime);

                foreach (ConsumableInfo info in infos)
                {
                    command.Parameters["@FujiClass2ID"].Value = info.FujiClass2ID;
                    command.Parameters["@Name"].Value = info.Name;
                    command.Parameters["@Description"].Value = info.Description;
                    command.Parameters["@TypeID"].Value = info.TypeID;
                    command.Parameters["@StdPrice"].Value = info.StdPrice;
                    command.Parameters["@ReplaceTimes"].Value = info.ReplaceTimes;
                    command.Parameters["@CostPer"].Value = info.CostPer;
                    command.Parameters["@AddDate"].Value = info.AddDate;

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}