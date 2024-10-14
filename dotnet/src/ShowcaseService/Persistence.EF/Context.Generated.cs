using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.BillingData.Persistence;

namespace MedicalResearch.BillingData.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '1.5.0') </summary>
  public partial class BillingDataDbContext : DbContext{

    public const String SchemaVersion = "1.5.0";

    public DbSet<BillableVisitEntity> BillableVisits { get; set; }

    public DbSet<StudyExecutionScopeEntity> StudyExecutionScopes { get; set; }

    /// <summary> VisitBillingRecord: Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand </summary>
    public DbSet<VisitBillingRecordEntity> VisitBillingRecords { get; set; }

    /// <summary> BillingDemand: created by the sponsor </summary>
    public DbSet<BillingDemandEntity> BillingDemands { get; set; }

    /// <summary> Invoice: created by the executor-company </summary>
    public DbSet<InvoiceEntity> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // BillableVisit
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillableVisit = modelBuilder.Entity<BillableVisitEntity>();
      cfgBillableVisit.ToTable("BdrBillableVisits");
      cfgBillableVisit.HasKey((e) => e.VisitGuid);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgBillableVisit
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.BillableVisits )
        .HasForeignKey(nameof(BillableVisitEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyExecutionScope
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyExecutionScope = modelBuilder.Entity<StudyExecutionScopeEntity>();
      cfgStudyExecutionScope.ToTable("BdrStudyExecutionScopes");
      cfgStudyExecutionScope.HasKey((e) => e.StudyExecutionIdentifier);

      //////////////////////////////////////////////////////////////////////////////////////
      // VisitBillingRecord
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgVisitBillingRecord = modelBuilder.Entity<VisitBillingRecordEntity>();
      cfgVisitBillingRecord.ToTable("BdrVisitBillingRecords");
      cfgVisitBillingRecord.HasKey((e) => e.BillingRecordId);
      cfgVisitBillingRecord.Property((e) => e.BillingRecordId).UseIdentityColumn();

      // LOOKUP: >>> BillableVisit
      cfgVisitBillingRecord
        .HasOne((lcl) => lcl.BillableVisit )
        .WithMany((rem) => rem.BillingRecord )
        .HasForeignKey(nameof(VisitBillingRecordEntity.VisitGuid))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> BillingDemand
      cfgVisitBillingRecord
        .HasOne((lcl) => lcl.AssignedDemand )
        .WithMany((rem) => rem.BillingRecords )
        .HasForeignKey(nameof(VisitBillingRecordEntity.BillingDemandId))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> Invoice
      cfgVisitBillingRecord
        .HasOne((lcl) => lcl.AssignedInvoice )
        .WithMany((rem) => rem.BillingRecord )
        .HasForeignKey(nameof(VisitBillingRecordEntity.InvoiceId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // BillingDemand
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillingDemand = modelBuilder.Entity<BillingDemandEntity>();
      cfgBillingDemand.ToTable("BdrBillingDemands");
      cfgBillingDemand.HasKey((e) => e.Id);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgBillingDemand
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.BillingDemands )
        .HasForeignKey(nameof(BillingDemandEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // Invoice
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInvoice = modelBuilder.Entity<InvoiceEntity>();
      cfgInvoice.ToTable("BdrInvoices");
      cfgInvoice.HasKey((e) => e.Id);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgInvoice
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.Invoices )
        .HasForeignKey(nameof(InvoiceEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> Invoice
      cfgInvoice
        .HasOne((lcl) => lcl.CorrectionOf )
        .WithMany((rem) => rem.Corrections )
        .HasForeignKey(nameof(InvoiceEntity.CorrectionOfInvoiceId))
        .OnDelete(DeleteBehavior.Restrict);

#endregion

      this.OnModelCreatingCustom(modelBuilder);
    }

    partial void OnModelCreatingCustom(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder options) {

      //reqires separate nuget-package Microsoft.EntityFrameworkCore.SqlServer
      options.UseSqlServer(_ConnectionString);

      //reqires separate nuget-package Microsoft.EntityFrameworkCore.Proxies
      options.UseLazyLoadingProxies();

      this.OnConfiguringCustom(options);
    }

    partial void OnConfiguringCustom(DbContextOptionsBuilder options);

    public static void Migrate() {
      if (!_Migrated) {
        BillingDataDbContext c = new BillingDataDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=BillingDataDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
