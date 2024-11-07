using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.BillingData.Persistence;

namespace MedicalResearch.BillingData.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '2.0.0') </summary>
  public partial class BillingDataDbContext : DbContext{

    public const String SchemaVersion = "2.0.0";

    public DbSet<BillableItemEntity> BillableItems { get; set; }

    public DbSet<StudyExecutionScopeEntity> StudyExecutionScopes { get; set; }

    /// <summary> BillingDemand: created by the sponsor </summary>
    public DbSet<BillingDemandEntity> BillingDemands { get; set; }

    /// <summary> BillingItem: Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand </summary>
    public DbSet<BillingItemEntity> BillingItems { get; set; }

    /// <summary> Invoice: created by the executor-company </summary>
    public DbSet<InvoiceEntity> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // BillableItem
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillableItem = modelBuilder.Entity<BillableItemEntity>();
      cfgBillableItem.ToTable("BdrBillableItems");
      cfgBillableItem.HasKey((e) => e.BillableItemUid);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgBillableItem
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany()
        .HasForeignKey(nameof(BillableItemEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyExecutionScope
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyExecutionScope = modelBuilder.Entity<StudyExecutionScopeEntity>();
      cfgStudyExecutionScope.ToTable("BdrStudyExecutionScopes");
      cfgStudyExecutionScope.HasKey((e) => e.StudyExecutionIdentifier);

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
      // BillingItem
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillingItem = modelBuilder.Entity<BillingItemEntity>();
      cfgBillingItem.ToTable("BdrBillingItems");
      cfgBillingItem.HasKey((e) => e.BillingItemId);
      cfgBillingItem.Property((e) => e.BillingItemId).UseIdentityColumn();

      // LOOKUP: >>> BillingDemand
      cfgBillingItem
        .HasOne((lcl) => lcl.AssignedDemand )
        .WithMany((rem) => rem.BillingItems )
        .HasForeignKey(nameof(BillingItemEntity.BillingDemandId))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> Invoice
      cfgBillingItem
        .HasOne((lcl) => lcl.AssignedInvoice )
        .WithMany((rem) => rem.BillingItems )
        .HasForeignKey(nameof(BillingItemEntity.InvoiceId))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> BillableItem
      cfgBillingItem
        .HasOne((lcl) => lcl.BillableItem )
        .WithMany()
        .HasForeignKey(nameof(BillingItemEntity.BillableItemUid))
        .OnDelete(DeleteBehavior.Restrict);

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
