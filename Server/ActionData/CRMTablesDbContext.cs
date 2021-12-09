using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskToOctopus.Server.ActionTablesModels;

#nullable disable

namespace TaskToOctopus.Server.ActionTablesData
{
    public partial class CRMTablesDbContext : DbContext
    {
        public CRMTablesDbContext()
        {
        }

        public CRMTablesDbContext(DbContextOptions<CRMTablesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<T_ActionType> T_ActionTypes { get; set; }
        public virtual DbSet<T_ActionType_Department> T_ActionType_Departments { get; set; }
        public virtual DbSet<T_ActivityTypeDef> T_ActivityTypeDefs { get; set; }
        public virtual DbSet<T_ActivityType_ResultLink> T_ActivityType_ResultLinks { get; set; }
        public virtual DbSet<T_ActivtyResultDef> T_ActivtyResultDefs { get; set; }
        public virtual DbSet<T_Brand> T_Brands { get; set; }
        public virtual DbSet<T_Brand_BusinessUnit> T_Brand_BusinessUnits { get; set; }
        public virtual DbSet<T_Brand_BusinessUnitLink> T_Brand_BusinessUnitLinks { get; set; }
        public virtual DbSet<T_Brand_Model> T_Brand_Models { get; set; }
        public virtual DbSet<T_BusinessUnit> T_BusinessUnits { get; set; }
        public virtual DbSet<T_CampaignContactTypeDef> T_CampaignContactTypeDefs { get; set; }
        public virtual DbSet<T_CampaignType> T_CampaignTypes { get; set; }
        public virtual DbSet<T_Channel> T_Channels { get; set; }
        public virtual DbSet<T_ClosureReasonDef> T_ClosureReasonDefs { get; set; }
        public virtual DbSet<T_ColorDef> T_ColorDefs { get; set; }
        public virtual DbSet<T_Contact_Source> T_Contact_Sources { get; set; }
        public virtual DbSet<T_ContractTypeDef> T_ContractTypeDefs { get; set; }
        public virtual DbSet<T_Conversion_Table> T_Conversion_Tables { get; set; }
        public virtual DbSet<T_Country> T_Countries { get; set; }
        public virtual DbSet<T_Country_HolidayDate> T_Country_HolidayDates { get; set; }
        public virtual DbSet<T_Country_HolidayDay> T_Country_HolidayDays { get; set; }
        public virtual DbSet<T_Customer_BusinessTypeDef> T_Customer_BusinessTypeDefs { get; set; }
        public virtual DbSet<T_Customer_CustomerTypeDef> T_Customer_CustomerTypeDefs { get; set; }
        public virtual DbSet<T_Customer_Gender> T_Customer_Genders { get; set; }
        public virtual DbSet<T_Customer_MaritalStatusDef> T_Customer_MaritalStatusDefs { get; set; }
        public virtual DbSet<T_DataCapture> T_DataCaptures { get; set; }
        public virtual DbSet<T_Data_Provider> T_Data_Providers { get; set; }
        public virtual DbSet<T_DealerTypeDef> T_DealerTypeDefs { get; set; }
        public virtual DbSet<T_EstimateTypeDef> T_EstimateTypeDefs { get; set; }
        public virtual DbSet<T_Estimate_RowType> T_Estimate_RowTypes { get; set; }
        public virtual DbSet<T_EventTypeDef> T_EventTypeDefs { get; set; }
        public virtual DbSet<T_FinancialOptionDef> T_FinancialOptionDefs { get; set; }
        public virtual DbSet<T_FuelTypeDef> T_FuelTypeDefs { get; set; }
        public virtual DbSet<T_ImportInterface> T_ImportInterfaces { get; set; }
        public virtual DbSet<T_ImportInterface_Conversion> T_ImportInterface_Conversions { get; set; }
        public virtual DbSet<T_Interview> T_Interviews { get; set; }
        public virtual DbSet<T_InterviewTypeDef> T_InterviewTypeDefs { get; set; }
        public virtual DbSet<T_Interview_Question> T_Interview_Questions { get; set; }
        public virtual DbSet<T_LOV> T_LOVs { get; set; }
        public virtual DbSet<T_Message_Provider> T_Message_Providers { get; set; }
        public virtual DbSet<T_Model> T_Models { get; set; }
        public virtual DbSet<T_ModelVersion> T_ModelVersions { get; set; }
        public virtual DbSet<T_NotificationDef> T_NotificationDefs { get; set; }
        public virtual DbSet<T_NotificationTypeDef> T_NotificationTypeDefs { get; set; }
        public virtual DbSet<T_Process> T_Processes { get; set; }
        public virtual DbSet<T_Process_ActionDef> T_Process_ActionDefs { get; set; }
        public virtual DbSet<T_Process_ActionStructure> T_Process_ActionStructures { get; set; }
        public virtual DbSet<T_Profile> T_Profiles { get; set; }
        public virtual DbSet<T_Profile_Task> T_Profile_Tasks { get; set; }
        public virtual DbSet<T_ReferenceChannelCodeDef> T_ReferenceChannelCodeDefs { get; set; }
        public virtual DbSet<T_ReferenceChannelCode_ScriptType> T_ReferenceChannelCode_ScriptTypes { get; set; }
        public virtual DbSet<T_ReferenceTypeDef> T_ReferenceTypeDefs { get; set; }
        public virtual DbSet<T_ReportTypeDef> T_ReportTypeDefs { get; set; }
        public virtual DbSet<T_RequestTypeDef> T_RequestTypeDefs { get; set; }
        public virtual DbSet<T_Sales_Department> T_Sales_Departments { get; set; }
        public virtual DbSet<T_ScriptDef> T_ScriptDefs { get; set; }
        public virtual DbSet<T_ScriptOptionTypeDef> T_ScriptOptionTypeDefs { get; set; }
        public virtual DbSet<T_ScriptParameter> T_ScriptParameters { get; set; }
        public virtual DbSet<T_ScriptTypeDef> T_ScriptTypeDefs { get; set; }
        public virtual DbSet<T_Sequence> T_Sequences { get; set; }
        public virtual DbSet<T_Sequence_Action> T_Sequence_Actions { get; set; }
        public virtual DbSet<T_Sequence_Action_BUP> T_Sequence_Action_BUPs { get; set; }
        public virtual DbSet<T_Sequence_BUP> T_Sequence_BUPs { get; set; }
        public virtual DbSet<T_ServiceTypeDef> T_ServiceTypeDefs { get; set; }
        public virtual DbSet<T_Setting> T_Settings { get; set; }
        public virtual DbSet<T_Setting_Group> T_Setting_Groups { get; set; }
        public virtual DbSet<T_Setting_Type> T_Setting_Types { get; set; }
        public virtual DbSet<T_Setting_Value> T_Setting_Values { get; set; }
        public virtual DbSet<T_SmtpClient> T_SmtpClients { get; set; }
        public virtual DbSet<T_StatCode> T_StatCodes { get; set; }
        public virtual DbSet<T_StatCodeLink> T_StatCodeLinks { get; set; }
        public virtual DbSet<T_StatusDef> T_StatusDefs { get; set; }
        public virtual DbSet<T_SubchannelType> T_SubchannelTypes { get; set; }
        public virtual DbSet<T_TagType> T_TagTypes { get; set; }
        public virtual DbSet<T_Task> T_Tasks { get; set; }
        public virtual DbSet<T_User_NotificationDef> T_User_NotificationDefs { get; set; }
        public virtual DbSet<T_VATCodeDef> T_VATCodeDefs { get; set; }
        public virtual DbSet<T_VehicleChannelDef> T_VehicleChannelDefs { get; set; }
        public virtual DbSet<T_Web_Button> T_Web_Buttons { get; set; }
        public virtual DbSet<V_BrandBusinessUnit> V_BrandBusinessUnits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=192.168.204.100;initial catalog=CRMTables;persist security info=True;user id=rsappuser;password=pupi@Trerot01!;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<T_ActionType>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.T_ActionTypes)
                    .HasForeignKey(d => d.TaskID)
                    .HasConstraintName("FK_T_ActionType_T_Task");
            });

            modelBuilder.Entity<T_ActionType_Department>(entity =>
            {
                entity.Property(e => e.ActionTypeDepartmentID).ValueGeneratedNever();

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.T_ActionType_Departments)
                    .HasForeignKey(d => d.ActionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ActionType_Department_T_ActionType");

                entity.HasOne(d => d.SalesDepartment)
                    .WithMany(p => p.T_ActionType_Departments)
                    .HasForeignKey(d => d.SalesDepartmentID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ActionType_Department_T_Sales_Department");
            });

            modelBuilder.Entity<T_ActivityTypeDef>(entity =>
            {
                entity.HasOne(d => d.PreviousActivity)
                    .WithMany(p => p.InversePreviousActivity)
                    .HasForeignKey(d => d.PreviousActivityID)
                    .HasConstraintName("FK_T_ActivityTypeDef_T_ActivityTypeDef");
            });

            modelBuilder.Entity<T_ActivityType_ResultLink>(entity =>
            {
                entity.HasKey(e => new { e.PlanActivityTypeID, e.FirstActivityResultID, e.NextActivityResultID });

                entity.HasOne(d => d.PlanActivityType)
                    .WithMany(p => p.T_ActivityType_ResultLinks)
                    .HasForeignKey(d => d.PlanActivityTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ActivityType_ResultLink_T_ActivityTypeDef");
            });

            modelBuilder.Entity<T_Brand_BusinessUnit>(entity =>
            {
                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.T_Brand_BusinessUnits)
                    .HasForeignKey(d => d.BrandID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Brand_BusinessUnit_T_Brand");

                entity.HasOne(d => d.BusinessUnit)
                    .WithMany(p => p.T_Brand_BusinessUnits)
                    .HasForeignKey(d => d.BusinessUnitID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Brand_BusinessUnit_T_BusinessUnit");
            });

            modelBuilder.Entity<T_Brand_BusinessUnitLink>(entity =>
            {
                entity.HasOne(d => d.BrandBusinessUnit)
                    .WithMany(p => p.T_Brand_BusinessUnitLinks)
                    .HasForeignKey(d => d.BrandBusinessUnitID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Brand_BusinessUnitLink_T_Brand_BusinessUnit");
            });

            modelBuilder.Entity<T_Brand_Model>(entity =>
            {
                entity.Property(e => e.ModelID).ValueGeneratedNever();

                entity.HasOne(d => d.BrandBusinessUnit)
                    .WithMany(p => p.T_Brand_Models)
                    .HasForeignKey(d => d.BrandBusinessUnitID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Brand_Model_T_Brand_BusinessUnit");
            });

            modelBuilder.Entity<T_BusinessUnit>(entity =>
            {
                entity.Property(e => e.BusinessUnitID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_CampaignType>(entity =>
            {
                entity.Property(e => e.CampaignTypeID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_ClosureReasonDef>(entity =>
            {
                entity.Property(e => e.ClosureReasonID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_ColorDef>(entity =>
            {
                entity.HasKey(e => new { e.TableKey, e.ID });
            });

            modelBuilder.Entity<T_ContractTypeDef>(entity =>
            {
                entity.Property(e => e.ContractTypeID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_Conversion_Table>(entity =>
            {
                entity.HasKey(e => new { e.TableKey, e.FieldKey, e.ActionValue, e.SourceID, e.SourceValue });
            });

            modelBuilder.Entity<T_Country_HolidayDate>(entity =>
            {
                entity.HasKey(e => new { e.CountryID, e.RefDate });

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.T_Country_HolidayDates)
                    .HasForeignKey(d => d.CountryID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Country_HolidayDate_T_Country");
            });

            modelBuilder.Entity<T_Country_HolidayDay>(entity =>
            {
                entity.HasKey(e => new { e.CountryID, e.RefMonth, e.RefDay });
            });

            modelBuilder.Entity<T_Customer_BusinessTypeDef>(entity =>
            {
                entity.Property(e => e.BusinessTypeID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_EstimateTypeDef>(entity =>
            {
                entity.Property(e => e.EstimateTypeID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_Estimate_RowType>(entity =>
            {
                entity.Property(e => e.EstimateRowTypeID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_ImportInterface_Conversion>(entity =>
            {
                entity.HasKey(e => new { e.InterfaceID, e.DataKey, e.SourceData });

                entity.HasOne(d => d.Interface)
                    .WithMany(p => p.T_ImportInterface_Conversions)
                    .HasForeignKey(d => d.InterfaceID)
                    .HasConstraintName("FK_T_ImportInterface_Conversion_T_ImportInterface");
            });

            modelBuilder.Entity<T_Interview>(entity =>
            {
                entity.HasOne(d => d.InterviewType)
                    .WithMany(p => p.T_Interviews)
                    .HasForeignKey(d => d.InterviewTypeID)
                    .HasConstraintName("FK_T_Interview_T_InterviewTypeDef");
            });

            modelBuilder.Entity<T_Interview_Question>(entity =>
            {
                entity.HasOne(d => d.Interview)
                    .WithMany(p => p.T_Interview_Questions)
                    .HasForeignKey(d => d.InterviewID)
                    .HasConstraintName("FK_T_Interview_Question_T_Interview");
            });

            modelBuilder.Entity<T_LOV>(entity =>
            {
                entity.HasKey(e => new { e.LOVKey, e.LOVCode });
            });

            modelBuilder.Entity<T_Model>(entity =>
            {
                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.T_Models)
                    .HasForeignKey(d => d.BrandID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Model_T_Brand");
            });

            modelBuilder.Entity<T_ModelVersion>(entity =>
            {
                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.T_ModelVersions)
                    .HasForeignKey(d => d.FuelTypeID)
                    .HasConstraintName("FK_T_ModelVersion_T_FuelTypeDef");

                entity.HasOne(d => d.ModelCodeNavigation)
                    .WithMany(p => p.T_ModelVersions)
                    .HasForeignKey(d => d.ModelCode)
                    .HasConstraintName("FK_T_ModelVersion_T_ModelVersion");
            });

            modelBuilder.Entity<T_Process_ActionDef>(entity =>
            {
                entity.HasOne(d => d.Process)
                    .WithMany(p => p.T_Process_ActionDefs)
                    .HasForeignKey(d => d.ProcessID)
                    .HasConstraintName("FK_T_Process_ActionDef_T_Process");
            });

            modelBuilder.Entity<T_Process_ActionStructure>(entity =>
            {
                entity.HasKey(e => new { e.ProcessActionID, e.SequenceNumber });

                entity.HasOne(d => d.ProcessAction)
                    .WithMany(p => p.T_Process_ActionStructures)
                    .HasForeignKey(d => d.ProcessActionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Process_ActionStructure_T_Process_ActionDef");
            });

            modelBuilder.Entity<T_Profile>(entity =>
            {
                entity.Property(e => e.ProfileID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_Profile_Task>(entity =>
            {
                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.T_Profile_Tasks)
                    .HasForeignKey(d => d.ProfileID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Profile_Task_T_Profile");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.T_Profile_Tasks)
                    .HasForeignKey(d => d.TaskID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Profile_Task_T_Task");
            });

            modelBuilder.Entity<T_ReferenceChannelCodeDef>(entity =>
            {
                entity.HasOne(d => d.ReferenceType)
                    .WithMany(p => p.T_ReferenceChannelCodeDefs)
                    .HasForeignKey(d => d.ReferenceTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ReferenceChannelCodeDef_T_ReferenceTypeDef");
            });

            modelBuilder.Entity<T_ReferenceChannelCode_ScriptType>(entity =>
            {
                entity.HasOne(d => d.ChannelCode)
                    .WithMany(p => p.T_ReferenceChannelCode_ScriptTypes)
                    .HasForeignKey(d => d.ChannelCodeID)
                    .HasConstraintName("FK_T_ReferenceChannelCode_ScriptType_T_ReferenceChannelCodeDef");

                entity.HasOne(d => d.ScriptType)
                    .WithMany(p => p.T_ReferenceChannelCode_ScriptTypes)
                    .HasForeignKey(d => d.ScriptTypeID)
                    .HasConstraintName("FK_T_ReferenceChannelCode_ScriptType_T_ScriptTypeDef");
            });

            modelBuilder.Entity<T_ReportTypeDef>(entity =>
            {
                entity.HasOne(d => d.Task)
                    .WithMany(p => p.T_ReportTypeDefs)
                    .HasForeignKey(d => d.TaskID)
                    .HasConstraintName("FK_T_ReportTypeDef_T_Task");
            });

            modelBuilder.Entity<T_RequestTypeDef>(entity =>
            {
                entity.HasOne(d => d.SalesDepartment)
                    .WithMany(p => p.T_RequestTypeDefs)
                    .HasForeignKey(d => d.SalesDepartmentID)
                    .HasConstraintName("FK_T_RequestTypeDef_T_Sales_Department");
            });

            modelBuilder.Entity<T_Sales_Department>(entity =>
            {
                entity.Property(e => e.SortOrder).IsFixedLength(true);
            });

            modelBuilder.Entity<T_ScriptDef>(entity =>
            {
                entity.HasOne(d => d.ScriptType)
                    .WithMany(p => p.T_ScriptDefs)
                    .HasForeignKey(d => d.ScriptTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ScriptDef_T_ScriptTypeDef");
            });

            modelBuilder.Entity<T_ScriptOptionTypeDef>(entity =>
            {
                entity.Property(e => e.ScriptOptionTypeID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_ScriptTypeDef>(entity =>
            {
                entity.HasOne(d => d.ScriptOptionType)
                    .WithMany(p => p.T_ScriptTypeDefs)
                    .HasForeignKey(d => d.ScriptOptionTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_ScriptTypeDef_T_ScriptOptionTypeDef");
            });

            modelBuilder.Entity<T_Sequence_Action>(entity =>
            {
                entity.HasKey(e => new { e.SequenceID, e.SeqActionID, e.ActionOrder });

                entity.HasOne(d => d.Sequence)
                    .WithMany(p => p.T_Sequence_Actions)
                    .HasForeignKey(d => d.SequenceID)
                    .HasConstraintName("FK_T_Sequence_Action_T_Sequence");
            });

            modelBuilder.Entity<T_Setting>(entity =>
            {
                entity.HasOne(d => d.SettingGroup)
                    .WithMany(p => p.T_Settings)
                    .HasForeignKey(d => d.SettingGroupID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Setting_T_Setting_Group");

                entity.HasOne(d => d.SettingType)
                    .WithMany(p => p.T_Settings)
                    .HasForeignKey(d => d.SettingTypeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Setting_T_Setting_Type");
            });

            modelBuilder.Entity<T_Setting_Group>(entity =>
            {
                entity.Property(e => e.SettingGroupID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_Setting_Value>(entity =>
            {
                entity.HasKey(e => new { e.SettingID, e.OptionValue });

                entity.HasOne(d => d.Setting)
                    .WithMany(p => p.T_Setting_Values)
                    .HasForeignKey(d => d.SettingID)
                    .HasConstraintName("FK_T_Setting_Values_T_Setting");
            });

            modelBuilder.Entity<T_StatCode>(entity =>
            {
                entity.HasOne(d => d.BrandBusinessUnit)
                    .WithMany(p => p.T_StatCodes)
                    .HasForeignKey(d => d.BrandBusinessUnitID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_T_StatCode_T_Brand_BusinessUnit");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.T_StatCodes)
                    .HasForeignKey(d => d.BrandID)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_T_StatCode_T_Brand");
            });

            modelBuilder.Entity<T_StatCodeLink>(entity =>
            {
                entity.HasOne(d => d.StatCode)
                    .WithMany(p => p.T_StatCodeLinks)
                    .HasForeignKey(d => d.StatCodeID)
                    .HasConstraintName("FK_T_StatCodeLink_T_StatCode");
            });

            modelBuilder.Entity<T_StatusDef>(entity =>
            {
                entity.Property(e => e.StatusID).ValueGeneratedNever();
            });

            modelBuilder.Entity<T_SubchannelType>(entity =>
            {
                entity.Property(e => e.SubchannelTypeID).ValueGeneratedNever();

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.T_SubchannelTypes)
                    .HasForeignKey(d => d.ChannelID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_SubchannelType_T_Channel");
            });

            modelBuilder.Entity<T_Task>(entity =>
            {
                entity.HasOne(d => d.ParentTask)
                    .WithMany(p => p.InverseParentTask)
                    .HasForeignKey(d => d.ParentTaskID)
                    .HasConstraintName("FK_T_Task_T_Task");
            });

            modelBuilder.Entity<T_VATCodeDef>(entity =>
            {
                entity.HasKey(e => e.VATID)
                    .HasName("PK_T_VATCodeDef_1");
            });

            modelBuilder.Entity<T_Web_Button>(entity =>
            {
                entity.Property(e => e.ButtonID).ValueGeneratedNever();
            });

            modelBuilder.Entity<V_BrandBusinessUnit>(entity =>
            {
                entity.ToView("V_BrandBusinessUnit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
