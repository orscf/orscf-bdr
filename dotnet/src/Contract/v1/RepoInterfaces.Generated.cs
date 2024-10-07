using MedicalResearch.BillingData.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MedicalResearch.BillingData.StoreAccess {

  /// <summary> Provides CRUD access to stored BillableTasks (based on schema version '1.5.0') </summary>
  public partial interface IBillableTaskStore : System.Data.Fuse.IRepository<BillableTask, Guid> {
  }

  /// <summary> Provides CRUD access to stored BillableVisits (based on schema version '1.5.0') </summary>
  public partial interface IBillableVisitStore : System.Data.Fuse.IRepository<BillableVisit, Guid> {
  }

  /// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
  public partial interface IStudyExecutionScopeStore : System.Data.Fuse.IRepository<StudyExecutionScope, Guid> {
  }

  /// <summary> Provides CRUD access to stored BillingDemands (based on schema version '1.5.0') </summary>
  public partial interface IBillingDemandStore : System.Data.Fuse.IRepository<BillingDemand, Guid> {
  }

  /// <summary> Provides CRUD access to stored Invoices (based on schema version '1.5.0') </summary>
  public partial interface IInvoiceStore : System.Data.Fuse.IRepository<Invoice, Guid> {
  }

}
