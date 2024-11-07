using MedicalResearch.BillingData.Model;
using System;
using System.Data.Fuse;
using System.Data.Fuse.Convenience;
using System.Data.Fuse.Ef;
using System.Data.Fuse.Ef.InstanceManagement;

namespace MedicalResearch.BillingData.StoreAccess {

  /// <summary> Provides CRUD access to stored BillableItems (based on schema version '2.0.0') </summary>
  public class BillableItemStore : ModelVsEntityRepository<BillableItem, MedicalResearch.BillingData.Persistence.BillableItemEntity, Guid>, IBillableItemStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.BillableItemEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextInstanceProvider = new ShortLivingDbContextInstanceProvider<
        MedicalResearch.BillingData.Persistence.EF.BillingDataDbContext
      >();
      return new EfRepository<MedicalResearch.BillingData.Persistence.BillableItemEntity, Guid>(dbContextInstanceProvider);
    }

    public BillableItemStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<BillableItem, MedicalResearch.BillingData.Persistence.BillableItemEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '2.0.0') </summary>
  public class StudyExecutionScopeStore : ModelVsEntityRepository<StudyExecutionScope, MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity, Guid>, IStudyExecutionScopeStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextInstanceProvider = new ShortLivingDbContextInstanceProvider<
        MedicalResearch.BillingData.Persistence.EF.BillingDataDbContext
      >();
      return new EfRepository<MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity, Guid>(dbContextInstanceProvider);
    }

    public StudyExecutionScopeStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<StudyExecutionScope, MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored BillingDemands (based on schema version '2.0.0') </summary>
  public class BillingDemandStore : ModelVsEntityRepository<BillingDemand, MedicalResearch.BillingData.Persistence.BillingDemandEntity, Guid>, IBillingDemandStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.BillingDemandEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextInstanceProvider = new ShortLivingDbContextInstanceProvider<
        MedicalResearch.BillingData.Persistence.EF.BillingDataDbContext
      >();
      return new EfRepository<MedicalResearch.BillingData.Persistence.BillingDemandEntity, Guid>(dbContextInstanceProvider);
    }

    public BillingDemandStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<BillingDemand, MedicalResearch.BillingData.Persistence.BillingDemandEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored BillingItems (based on schema version '2.0.0') </summary>
  public class BillingItemStore : ModelVsEntityRepository<BillingItem, MedicalResearch.BillingData.Persistence.BillingItemEntity, Int64>, IBillingItemStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.BillingItemEntity, Int64> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextInstanceProvider = new ShortLivingDbContextInstanceProvider<
        MedicalResearch.BillingData.Persistence.EF.BillingDataDbContext
      >();
      return new EfRepository<MedicalResearch.BillingData.Persistence.BillingItemEntity, Int64>(dbContextInstanceProvider);
    }

    public BillingItemStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<BillingItem, MedicalResearch.BillingData.Persistence.BillingItemEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored Invoices (based on schema version '2.0.0') </summary>
  public class InvoiceStore : ModelVsEntityRepository<Invoice, MedicalResearch.BillingData.Persistence.InvoiceEntity, Guid>, IInvoiceStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.InvoiceEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextInstanceProvider = new ShortLivingDbContextInstanceProvider<
        MedicalResearch.BillingData.Persistence.EF.BillingDataDbContext
      >();
      return new EfRepository<MedicalResearch.BillingData.Persistence.InvoiceEntity, Guid>(dbContextInstanceProvider);
    }

    public InvoiceStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<Invoice, MedicalResearch.BillingData.Persistence.InvoiceEntity>()
    ) {
    }

  }

}
