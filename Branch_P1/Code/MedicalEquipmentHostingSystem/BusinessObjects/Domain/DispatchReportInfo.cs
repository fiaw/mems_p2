﻿using BusinessObjects.Manager;
using BusinessObjects.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Domain
{
    /// <summary>
    /// 作业报告信息
    /// </summary>
    public class DispatchReportInfo:EntityInfo
    {
        /// <summary>
        /// 派工单信息
        /// </summary>
        /// <value>
        /// The dispatch.
        /// </value>
        public DispatchBaseInfo Dispatch { get; set; }
        /// <summary>
        /// 作业报告类型	
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public KeyValueInfo Type  { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        /// <value>
        /// The fault code.
        /// </value>
        public string FaultCode  { get; set; }
        /// <summary>
        /// 详细故障描述 / 强检要求
        /// </summary>
        /// <value>
        /// The fault desc.
        /// </value>
        public string FaultDesc  { get; set; }
        /// <summary>
        /// 分析原因 / 报告明细
        /// </summary>
        /// <value>
        /// The solution cause analysis.
        /// </value>
        public string SolutionCauseAnalysis  { get; set; }
        /// <summary>
        /// 处理方式
        /// </summary>
        /// <value>
        /// The solution way.
        /// </value>
        public string SolutionWay  { get; set; }
        /// <summary>
        /// 是否专用报告
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is private; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// 服务提供方
        /// </summary>
        /// <value>
        /// The service provider.
        /// </value>
        public KeyValueInfo ServiceProvider { get; set; }
        /// <summary>
        /// 作业报告结果状态
        /// </summary>
        /// <value>
        /// The solution result status.
        /// </value>
        public KeyValueInfo SolutionResultStatus  { get; set; }
        /// <summary>
        /// 问题升级
        /// </summary>
        /// <value>
        /// The solution unsolved comments.
        /// </value>
        public string SolutionUnsolvedComments { get; set; }
        /// <summary>
        /// 误工说明
        /// </summary>
        /// <value>
        /// The delay reason.
        /// </value>
        public string DelayReason  { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string Comments { get; set; }
        /// <summary>
        /// 审批备注
        /// </summary>
        /// <value>
        /// The fuji comments.
        /// </value>
        public string FujiComments  { get; set; }
        /// <summary>
        /// 作业报告状态
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public KeyValueInfo Status { get; set; }

        /// <summary>
        /// 设备状态（离场）
        /// </summary>
        /// <value>
        /// The equipment status.
        /// </value>
        public KeyValueInfo EquipmentStatus { get; set; }
        /// <summary>
        /// 资产金额
        /// </summary>
        /// <value>
        /// The purchase amount.
        /// </value>
        public double PurchaseAmount { get; set; }
        /// <summary>
        /// 整包范围
        /// </summary>
        /// <value>
        ///   <c>true</c> if [service scope]; otherwise, <c>false</c>.
        /// </value>
        public bool ServiceScope { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public string Result { get; set; }
        /// <summary>
        /// 是否召回
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is recall; otherwise, <c>false</c>.
        /// </value>
        public bool IsRecall { get; set; }
        /// <summary>
        /// 验收日期
        /// </summary>
        /// <value>
        /// The acceptance date.
        /// </value>
        public DateTime AcceptanceDate { get; set; }

        /// <summary>
        /// 请求编号
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public int RequestID { get { return this.Dispatch == null ? 0 : this.Dispatch.RequestID; } }
        /// <summary>
        /// 历史信息
        /// </summary>
        /// <value>
        /// The histories.
        /// </value>
        public List<HistoryInfo> Histories { get; set; }

        /// <summary>
        /// 零配件信息
        /// </summary>
        /// <value>
        /// The report accessories.
        /// </value>
        public List<ReportAccessoryInfo> ReportAccessories { get; set; }
        /// <summary>
        /// 附件信息
        /// </summary>
        /// <value>
        /// The file information.
        /// </value>
        public UploadFileInfo FileInfo { get; set; }
        /// <summary>
        /// 作业报告编号
        /// </summary>
        /// <value>
        /// The oid.
        /// </value>
        public string OID { get { return EntityInfo.GenerateOID(ObjectTypes.DispatchReport, this.ID); } }

        //Display-Only
        /// <summary>
        /// 超期sql
        /// </summary>
        /// <returns>超期sql</returns>
        public static string GetOverDueSQL()
        {
            return string.Format(" (Case When r.RequestType = {0} AND DATEDIFF(MINUTE, r.DistributeDate, r.ResponseDate) > e.ResponseTimeLength AND r.LastStatusID = {1} Then 1 Else 0 End) ",
                                     RequestInfo.RequestTypes.Repair, RequestInfo.Statuses.New
                                 );
        }
        /// <summary>
        /// 作业报告信息
        /// </summary>
        public DispatchReportInfo()
        {
            this.Dispatch = new DispatchBaseInfo();
            this.Type = new KeyValueInfo();
            this.SolutionResultStatus = new KeyValueInfo();
            this.ServiceProvider = new KeyValueInfo();
            this.Status = new KeyValueInfo();
            this.EquipmentStatus = new KeyValueInfo();
        }
        /// <summary>
        /// 获取作业报告信息
        /// </summary>
        /// <param name="dr">The dr.</param>
        public DispatchReportInfo(DataRow dr)
            :this()
        {
            this.ID = SQLUtil.ConvertInt(dr["ID"]);
            this.Dispatch.ID = SQLUtil.ConvertInt(dr["DispatchID"]);
            this.Type.ID=SQLUtil.ConvertInt(dr["TypeID"]);
            this.Type = LookupManager.GetDispatchReportType(this.Type.ID);
            this.FaultCode = SQLUtil.TrimNull(dr["FaultCode"]);
            this.FaultDesc = SQLUtil.TrimNull(dr["FaultDesc"]);
            this.SolutionCauseAnalysis = SQLUtil.TrimNull(dr["SolutionCauseAnalysis"]);
            this.SolutionWay = SQLUtil.TrimNull(dr["SolutionWay"]);
            this.IsPrivate = SQLUtil.ConvertBoolean(dr["IsPrivate"]);
            this.ServiceProvider.ID = SQLUtil.ConvertInt(dr["ServiceProvider"]);
            this.ServiceProvider.Name = ServiceProviders.GetDescByID(this.ServiceProvider.ID);
            this.SolutionResultStatus.ID=SQLUtil.ConvertInt(dr["SolutionResultStatusID"]);
            this.SolutionResultStatus.Name = LookupManager.GetSolutionResultStatusDesc(this.SolutionResultStatus.ID);
            this.SolutionUnsolvedComments = SQLUtil.TrimNull(dr["SolutionUnsolvedComments"]);
            this.DelayReason = SQLUtil.TrimNull(dr["DelayReason"]);
            this.Comments = SQLUtil.TrimNull(dr["Comments"]);
            this.FujiComments = SQLUtil.TrimNull(dr["FujiComments"]);
            this.Status.ID = SQLUtil.ConvertInt(dr["StatusID"]);
            this.Status.Name = LookupManager.GetDispatchDocStatusDesc(this.Status.ID);

            this.PurchaseAmount = SQLUtil.ConvertDouble(dr["PurchaseAmount"]);this.ServiceScope = SQLUtil.ConvertBoolean(dr["ServiceScope"]);
            this.ServiceScope = SQLUtil.ConvertBoolean(dr["ServiceScope"]);
            this.Result = SQLUtil.TrimNull(dr["Result"]);
            this.IsRecall = SQLUtil.ConvertBoolean(dr["IsRecall"]);
            this.AcceptanceDate = SQLUtil.ConvertDateTime(dr["AcceptanceDate"]);
            this.EquipmentStatus.ID = SQLUtil.ConvertInt(dr["EquipmentStatus"]);
            this.EquipmentStatus.Name = MachineStatuses.GetMachineStatusesDesc(this.EquipmentStatus.ID);
        }
        /// <summary>
        /// Copy4s the application.
        /// </summary>
        /// <returns>DispatchReportInfo</returns>
        public DispatchReportInfo Copy4App()
        {
            this.Dispatch.Request = null;
            this.Dispatch.Engineer = null;
            return this;
        }
        /// <summary>
        /// 流程信息
        /// </summary>
        /// <value>
        /// The format history.
        /// </value>
        public string FormatHistory { get; set; }
        /// <summary>
        /// 设置流程历史信息
        /// </summary>
        public void SetHis4Comments()
        {
            StringBuilder sb = new StringBuilder();
            foreach (HistoryInfo history in this.Histories)
            {
                sb.AppendLine(history.VerifyHistory);
            }
            this.FormatHistory = sb.ToString();
        }

        /// <summary>
        /// 作业报告结果
        /// </summary>
        public static class SolutionResultStatuses
        {
            /// <summary>
            /// 待分配
            /// </summary>
            public const int Allocating = 1;
            /// <summary>
            /// 问题升级
            /// </summary>
            public const int Problem_Escalation = 2;
            /// <summary>
            /// 待第三方支持
            /// </summary>
            public const int Waitting_Thirdparty = 3;
            /// <summary>
            /// 已解决
            /// </summary>
            public const int Resolved = 4;
            /// <summary>
            /// 根据作业报告结果获取请求状态
            /// </summary>
            /// <param name="reportSolution">作业报告结果编号</param>
            /// <returns>请求状态编号</returns>
            public static int GetRequestStatusBySolutionResult(int reportSolution)
            {
                switch (reportSolution)
                {
                    case Allocating:
                        return RequestInfo.Statuses.Allocating;
                    case Problem_Escalation:
                        return RequestInfo.Statuses.ProblemEscalation;
                    case Waitting_Thirdparty:
                        return RequestInfo.Statuses.WaittingThirdParty;
                    case Resolved:
                        return RequestInfo.Statuses.Close;
                    default:
                        return 0;
                }
            }
        }

        /// <summary>
        /// 服务提供方
        /// </summary>
        public static class ServiceProviders
        {
            /// <summary>
            /// 管理方
            /// </summary>
            public const int Management_Party = 1;
            /// <summary>
            /// 第三方
            /// </summary>
            public const int Third_Party = 2;
            /// <summary>
            /// 厂家
            /// </summary>
            public const int Manufacture = 3;
            /// <summary>
            /// 获取服务提供方列表
            /// </summary>
            /// <returns>服务提供方列表</returns>
            public static List<KeyValueInfo> GetServiceProviders()
            {
                List<KeyValueInfo> serviceProviders = new List<KeyValueInfo>();
                serviceProviders.Add(new KeyValueInfo() { ID = ServiceProviders.Management_Party, Name = GetDescByID(ServiceProviders.Management_Party) });
                serviceProviders.Add(new KeyValueInfo() { ID = ServiceProviders.Third_Party, Name = GetDescByID(ServiceProviders.Third_Party) });
                serviceProviders.Add(new KeyValueInfo() { ID = ServiceProviders.Manufacture, Name = GetDescByID(ServiceProviders.Manufacture) });
                return serviceProviders;
            }
            /// <summary>
            /// 根据服务提供方编号获取服务提供方描述信息
            /// </summary>
            /// <param name="id">服务提供方编号</param>
            /// <returns>服务提供方描述</returns>
            public static string GetDescByID(int id)
            {
                switch (id)
                {
                    case Management_Party:
                        return "管理方";
                    case Third_Party:
                        return "第三方";
                    case Manufacture:
                        return "厂家";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 作业报告状态
        /// </summary>
        public static class DispatchReportStatus
        {
            /// <summary>
            /// 新建
            /// </summary>
            public const int New = 1;
            /// <summary>
            /// 待审批
            /// </summary>
            public const int Pending = 2;
            /// <summary>
            /// 已审批
            /// </summary>
            public const int Approved = 3;
            /// <summary>
            /// 已终止
            /// </summary>
            public const int Cancelled = 99;
        }

        /// <summary>
        /// 作业报告类型
        /// </summary>
        public static class DispatchReportTypes
        {
            /// <summary>
            /// 通用作业报告
            /// </summary>
            public const int Common = 1;
            /// <summary>
            /// 维修作业报告
            /// </summary>
            public const int Repair = 101;
            /// <summary>
            /// 保养作业报告
            /// </summary>
            public const int Maintenance = 201;
            /// <summary>
            /// 强检作业报告
            /// </summary>
            public const int MandatoryInspection = 301;
            /// <summary>
            /// 巡检作业报告
            /// </summary>
            public const int RegularParol = 401;
            /// <summary>
            /// 校准作业报告
            /// </summary>
            public const int Correcting = 501;
            /// <summary>
            /// 设备新增作业报告
            /// </summary>
            public const int AddEquipment = 601;
            /// <summary>
            /// 不良事件作业报告
            /// </summary>
            public const int AdverseEvent = 701;
            /// <summary>
            /// 验收安装作业报告
            /// </summary>
            public const int Accetance = 901;
            /// <summary>
            /// 根据派工类型获取作业报告类型信息
            /// </summary>
            /// <param name="requestTypeId">派工类型编号</param>
            /// <returns>作业报告类型信息</returns>
            public static KeyValueInfo GetDispatchReportType(int requestTypeId)
            {
                int reportTypeId;
                switch (requestTypeId)
                {
                    case RequestInfo.RequestTypes.Repair:
                        reportTypeId = DispatchReportTypes.Repair;
                        break;
                    case RequestInfo.RequestTypes.Maintain:
                        reportTypeId = DispatchReportTypes.Maintenance;
                        break;
                    case RequestInfo.RequestTypes.Inspection:
                        reportTypeId = DispatchReportTypes.MandatoryInspection;
                        break;
                    case RequestInfo.RequestTypes.OnSiteInspection:
                        reportTypeId = DispatchReportTypes.RegularParol;
                        break;
                    case RequestInfo.RequestTypes.Correcting: 
                        reportTypeId = DispatchReportTypes.Correcting; 
                        break;
                    case RequestInfo.RequestTypes.AddEquipment: 
                        reportTypeId = DispatchReportTypes.AddEquipment; 
                        break;
                    case RequestInfo.RequestTypes.AdverseEvent: 
                        reportTypeId = DispatchReportTypes.AdverseEvent; 
                        break;
                    case RequestInfo.RequestTypes.Accetance: 
                        reportTypeId = DispatchReportTypes.Accetance; 
                        break;
                    default:
                        reportTypeId = DispatchReportTypes.Common;
                        break;
                }

                return LookupManager.GetDispatchReportType(reportTypeId);
            }
            /// <summary>
            /// 根据派工类型编号获取作业报告类型编号
            /// </summary>
            /// <param name="requestTypeId">派工类型编号</param>
            /// <returns>作业报告类型编号</returns>
            public static int GetDispatchReportTypeID(int requestTypeId)
            {
                switch (requestTypeId)
                {
                    case RequestInfo.RequestTypes.Repair:
                        return DispatchReportTypes.Repair;
                    case RequestInfo.RequestTypes.Maintain:
                        return DispatchReportTypes.Maintenance;
                    case RequestInfo.RequestTypes.Inspection:
                        return DispatchReportTypes.MandatoryInspection;
                    case RequestInfo.RequestTypes.OnSiteInspection:
                        return DispatchReportTypes.RegularParol;
                    case RequestInfo.RequestTypes.Correcting:
                        return DispatchReportTypes.Correcting;
                    case RequestInfo.RequestTypes.AddEquipment:
                        return DispatchReportTypes.AddEquipment;
                    case RequestInfo.RequestTypes.AdverseEvent:
                        return DispatchReportTypes.AdverseEvent;
                    case RequestInfo.RequestTypes.Accetance:
                        return DispatchReportTypes.Accetance;
                    default:
                        return DispatchReportTypes.Common;
                }
            }
            /// <summary>
            /// 根据派工类型编号获取可选作业报告类型信息
            /// </summary>
            /// <param name="requestTypeId">派工类型编号</param>
            /// <returns>可选作业报告类型信息</returns>
            public static List<KeyValueInfo> GetDispatchReportTypes(int requestTypeId)
            {
                List<KeyValueInfo> reportTypes = new List<KeyValueInfo>();

                reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.Common));
                switch (requestTypeId)
                {
                    case RequestInfo.RequestTypes.Repair:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.Repair));
                        break;
                    case RequestInfo.RequestTypes.Maintain:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.Maintenance));
                        break;
                    case RequestInfo.RequestTypes.Inspection:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.MandatoryInspection));
                        break;
                    case RequestInfo.RequestTypes.OnSiteInspection:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.RegularParol));
                        break;
                    case RequestInfo.RequestTypes.Correcting:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.Correcting));
                        break;
                    case RequestInfo.RequestTypes.AddEquipment:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.AddEquipment));
                        break;
                    case RequestInfo.RequestTypes.AdverseEvent:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.AdverseEvent));
                        break;
                    case RequestInfo.RequestTypes.Accetance:
                        reportTypes.Add(LookupManager.GetDispatchReportType(DispatchReportTypes.Accetance));
                        break;
                }

                return reportTypes;
            }
        }

        /// <summary>
        /// 作业报告流程操作
        /// </summary>
        public static class Actions
        {
            /// <summary>
            /// 提交
            /// </summary>
            public const int Submit = 1;
            /// <summary>
            /// 通过
            /// </summary>
            public const int Pass = 2;
            /// <summary>
            /// 退回
            /// </summary>
            public const int Reject = 3;
            /// <summary>
            /// 根据作业报告流程操作编号获取作业报告流程操作描述信息
            /// </summary>
            /// <param name="actionID">作业报告流程操作编号</param>
            /// <returns>作业报告流程操作描述</returns>
            public static string GetDesc(int actionID)
            {
                switch (actionID)
                {
                    case Submit:
                        return "提交";
                    case Pass:
                        return "通过";
                    case Reject:
                        return "退回";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 作业报告附件类型
        /// </summary>
        public static class FileTypes
        {
            /// <summary>
            /// 作业报告附件
            /// </summary>
            public const int DispatchReportFile = 1;

            /// <summary>
            /// 获取附件类型描述信息
            /// </summary>
            /// <param name="id">附件类型id</param>
            /// <returns>附件类型描述信息</returns>
            public static string GetFileName(int id)
            {
                switch (id)
                {
                    case DispatchReportFile:
                        return "附件";
                    default:
                        return "";
                }
            }
        }
    }
    /// <summary>
    /// 零配件信息
    /// </summary>
    public class ReportAccessoryInfo : EntityInfo
    {
        /// <summary>
        /// 作业报告编号
        /// </summary>
        /// <value>
        /// The dispatch report identifier.
        /// </value>
        public int DispatchReportID { get; set; }
        /// <summary>
        /// 零配件名称
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public KeyValueInfo Source { get; set; }
        /// <summary>
        /// 外部供应商
        /// </summary>
        /// <value>
        /// The supplier.
        /// </value>
        public SupplierInfo Supplier { get; set; }
        /// <summary>
        /// 新装零配件序列号
        /// </summary>
        /// <value>
        /// The new serial code.
        /// </value>
        public string NewSerialCode { get; set; }
        /// <summary>
        /// 拆下零配件序列号
        /// </summary>
        /// <value>
        /// The old serial code.
        /// </value>
        public string OldSerialCode { get; set; }
        /// <summary>
        /// 零配件数量
        /// </summary>
        /// <value>
        /// The qty.
        /// </value>
        public int Qty { get; set; }
        /// <summary>
        /// 零配件金额
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public double Amount { get; set; }

        /// <summary>
        /// 附件信息
        /// </summary>
        /// <value>
        /// The file infos.
        /// </value>
        public List<UploadFileInfo> FileInfos { get; set; }

        /// <summary>
        /// 零配件系统编号
        /// </summary>
        public string OID { get { return EntityInfo.GenerateOID(ObjectTypes.ReportAccessory, this.ID); } }

        /// <summary>
        /// 零配件信息
        /// </summary>
        public ReportAccessoryInfo()
        {
            this.Source = new KeyValueInfo();
            this.Supplier = new SupplierInfo();
            this.FileInfos = new List<UploadFileInfo>();
        }
        /// <summary>
        /// 获取零配件信息
        /// </summary>
        /// <param name="dr">The dr.</param>
        public ReportAccessoryInfo(DataRow dr)
            : this()
        {
            this.ID = SQLUtil.ConvertInt(dr["ID"]);
            this.DispatchReportID = SQLUtil.ConvertInt(dr["DispatchReportID"]);
            this.Name = SQLUtil.TrimNull(dr["Name"]);
            this.Source.ID = SQLUtil.ConvertInt(dr["SourceID"]);
            this.Source.Name = LookupManager.GetAccessorySourceTypeDesc(this.Source.ID);
            if (dr.Table.Columns.Contains("SupplierID"))
            {
                this.Supplier.ID = SQLUtil.ConvertInt(dr["SupplierID"]);
                this.Supplier.Name = SQLUtil.TrimNull(dr["SupplierName"]);
            }
            this.NewSerialCode = SQLUtil.TrimNull(dr["NewSerialCode"]);
            this.OldSerialCode = SQLUtil.TrimNull(dr["OldSerialCode"]);
            this.Qty = SQLUtil.ConvertInt(dr["Qty"]);
            this.Amount = SQLUtil.ConvertDouble(dr["Amount"]);
        }

        /// <summary>
        /// 零配件附件类型
        /// </summary>
        public static class FileTypes
        {
            /// <summary>
            /// 新装
            /// </summary>
            public const int New = 1;
            /// <summary>
            /// 拆下
            /// </summary>
            public const int Old = 2;

            /// <summary>
            /// 获取零配件附件类型
            /// </summary>
            /// <returns>零配件附件类型</returns>
            public static List<KeyValueInfo> GetFileName()
            {
                List<KeyValueInfo> filetypes = new List<KeyValueInfo>();
                filetypes.Add(new KeyValueInfo() { ID = FileTypes.New, Name = GetFileName(FileTypes.New) });
                filetypes.Add(new KeyValueInfo() { ID = FileTypes.Old, Name = GetFileName(FileTypes.Old) });
                return filetypes;
            }
            /// <summary>
            /// 根据零配件附件类型编号获取零配件附件类型描述
            /// </summary>
            /// <param name="filetypeId">零配件附件类型编号</param>
            /// <returns>零配件附件类型描述</returns>
            public static string GetFileName(int filetypeId)
            {
                switch (filetypeId)
                {
                    case FileTypes.New:
                        return "新装";
                    case FileTypes.Old:
                        return "拆下";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 零配件来源
        /// </summary>
        public static class SourceType
        {
            /// <summary>
            /// 外部供应商
            /// </summary>
            public const int External_Suppliers = 1;
            /// <summary>
            /// 备件库
            /// </summary>
            public const int Stock = 2;
        }
    }
}