using MedicalResearch.BillingData.Model;
using MedicalResearch.BillingData.Persistence.EF;
using System;
using System.Data.Fuse;
using System.Data.Fuse.Convenience;
using System.Data.Fuse.Ef;
using System.Data.Fuse.Ef.InstanceManagement;

namespace MedicalResearch.BillingData.StoreAccess {

  /// <summary> Provides CRUD access to stored BillableVisits (based on schema version '1.5.0') </summary>
  public class BillableVisitStore : ModelVsEntityRepository<BillableVisit, MedicalResearch.BillingData.Persistence.BillableVisitEntity, Guid>, IBillableVisitStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.BillableVisitEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextProvider = new ShortLivingDbContextInstanceProvider(
        () => new BillingDataDbContext()
      );
      return new EfRepository<MedicalResearch.BillingData.Persistence.BillableVisitEntity, Guid>(dbContextProvider);
    }

    public BillableVisitStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<BillableVisit, MedicalResearch.BillingData.Persistence.BillableVisitEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
  public class StudyExecutionScopeStore : ModelVsEntityRepository<StudyExecutionScope, MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity, Guid>, IStudyExecutionScopeStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextProvider = new ShortLivingDbContextInstanceProvider(
        () => new BillingDataDbContext()
      );
      return new EfRepository<MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity, Guid>(dbContextProvider);
    }

    public StudyExecutionScopeStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<StudyExecutionScope, MedicalResearch.BillingData.Persistence.StudyExecutionScopeEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored VisitBillingRecords (based on schema version '1.5.0') </summary>
  public class VisitBillingRecordStore : ModelVsEntityRepository<VisitBillingRecord, MedicalResearch.BillingData.Persistence.VisitBillingRecordEntity, Int64>, IVisitBillingRecordStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.VisitBillingRecordEntity, Int64> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextProvider = new ShortLivingDbContextInstanceProvider(
        () => new BillingDataDbContext()
      );
      return new EfRepository<MedicalResearch.BillingData.Persistence.VisitBillingRecordEntity, Int64>(dbContextProvider);
    }

    public VisitBillingRecordStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<VisitBillingRecord, MedicalResearch.BillingData.Persistence.VisitBillingRecordEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored BillingDemands (based on schema version '1.5.0') </summary>
  public class BillingDemandStore : ModelVsEntityRepository<BillingDemand, MedicalResearch.BillingData.Persistence.BillingDemandEntity, Guid>, IBillingDemandStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.BillingDemandEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextProvider = new ShortLivingDbContextInstanceProvider(
        () => new BillingDataDbContext()
      );
      return new EfRepository<MedicalResearch.BillingData.Persistence.BillingDemandEntity, Guid>(dbContextProvider);
    }

    public BillingDemandStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<BillingDemand, MedicalResearch.BillingData.Persistence.BillingDemandEntity>()
    ) {
    }

  }

  /// <summary> Provides CRUD access to stored Invoices (based on schema version '1.5.0') </summary>
  public class InvoiceStore : ModelVsEntityRepository<Invoice, MedicalResearch.BillingData.Persistence.InvoiceEntity, Guid>, IInvoiceStore {

    private static EfRepository<MedicalResearch.BillingData.Persistence.InvoiceEntity, Guid> CreateInnerEfRepo() {
      IDbContextInstanceProvider dbContextProvider = new ShortLivingDbContextInstanceProvider(
        () => new BillingDataDbContext()
      );
      return new EfRepository<MedicalResearch.BillingData.Persistence.InvoiceEntity, Guid>(dbContextProvider);
    }

    public InvoiceStore() : base(
      CreateInnerEfRepo(), new ModelVsEntityParams<Invoice, MedicalResearch.BillingData.Persistence.InvoiceEntity>()
    ) {
    }

  }

}
