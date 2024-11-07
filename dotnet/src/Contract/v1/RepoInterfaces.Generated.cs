using MedicalResearch.BillingData.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.BillingData.StoreAccess {

  public static class ApiVersion {
    public const string SemanticVersion = "2.0.0";
  }

  /// <summary> Provides CRUD access to stored BillableItems (based on schema version '2.0.0') </summary>
  public partial interface IBillableItemStore : System.Data.Fuse.IRepository<BillableItem, Guid> {
  }

  /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '2.0.0') </summary>
  public partial interface IStudyExecutionScopeStore : System.Data.Fuse.IRepository<StudyExecutionScope, Guid> {
  }

  /// <summary> Provides CRUD access to stored BillingDemands (based on schema version '2.0.0') </summary>
  public partial interface IBillingDemandStore : System.Data.Fuse.IRepository<BillingDemand, Guid> {
  }

  /// <summary> Provides CRUD access to stored BillingItems (based on schema version '2.0.0') </summary>
  public partial interface IBillingItemStore : System.Data.Fuse.IRepository<BillingItem, Int64> {
  }

  /// <summary> Provides CRUD access to stored Invoices (based on schema version '2.0.0') </summary>
  public partial interface IInvoiceStore : System.Data.Fuse.IRepository<Invoice, Guid> {
  }

}
