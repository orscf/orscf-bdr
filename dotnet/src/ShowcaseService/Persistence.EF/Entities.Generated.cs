using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using MedicalResearch.BillingData.Model;

namespace MedicalResearch.BillingData.Persistence {

public class BillableItemEntity {

  /// <summary> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid BillableItemUid { get; set; } = Guid.NewGuid();

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid StudyExecutionIdentifier { get; set; }

  /// <summary> identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String VisitProcedureName { get; set; }

  /// <summary> title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
  [Required]
  public String UniqueExecutionName { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> ExecutionEndDateUtc { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Description { get; set; }

  /// <summary> One of the following values: 'General' / 'Site' / 'Paticipant' (Requires a ParticipantIdentifier) / 'Visit' (Requires a ParticipantIdentifier and UniqueExecutionName) </summary>
  [Required]
  public String RelatedTo { get; set; }

  [Principal]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

#region Mapping

  internal static Expression<Func<BillableItem, BillableItemEntity>> BillableItemEntitySelector = ((BillableItem src) => new BillableItemEntity {
    BillableItemUid = src.BillableItemUid,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ParticipantIdentifier = src.ParticipantIdentifier,
    VisitProcedureName = src.VisitProcedureName,
    UniqueExecutionName = src.UniqueExecutionName,
    ExecutionEndDateUtc = src.ExecutionEndDateUtc,
    Description = src.Description,
    RelatedTo = src.RelatedTo,
  });

  internal static Expression<Func<BillableItemEntity, BillableItem>> BillableItemSelector = ((BillableItemEntity src) => new BillableItem {
    BillableItemUid = src.BillableItemUid,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ParticipantIdentifier = src.ParticipantIdentifier,
    VisitProcedureName = src.VisitProcedureName,
    UniqueExecutionName = src.UniqueExecutionName,
    ExecutionEndDateUtc = src.ExecutionEndDateUtc,
    Description = src.Description,
    RelatedTo = src.RelatedTo,
  });

  internal void CopyContentFrom(BillableItem source, Func<String,bool> onFixedValueChangingCallback = null){
    this.BillableItemUid = source.BillableItemUid;
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.ParticipantIdentifier = source.ParticipantIdentifier;
    this.VisitProcedureName = source.VisitProcedureName;
    this.UniqueExecutionName = source.UniqueExecutionName;
    this.ExecutionEndDateUtc = source.ExecutionEndDateUtc;
    this.Description = source.Description;
    this.RelatedTo = source.RelatedTo;
  }

  internal void CopyContentTo(BillableItem target, Func<String,bool> onFixedValueChangingCallback = null){
    target.BillableItemUid = this.BillableItemUid;
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.ParticipantIdentifier = this.ParticipantIdentifier;
    target.VisitProcedureName = this.VisitProcedureName;
    target.UniqueExecutionName = this.UniqueExecutionName;
    target.ExecutionEndDateUtc = this.ExecutionEndDateUtc;
    target.Description = this.Description;
    target.RelatedTo = this.RelatedTo;
  }

#endregion

}

public class StudyExecutionScopeEntity {

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [FixedAfterCreation, Required]
  public Guid StudyExecutionIdentifier { get; set; } = Guid.NewGuid();

  /// <summary> the institute which is executing the study (this should be an invariant technical representation of the company name or a guid) </summary>
  [FixedAfterCreation, Required]
  public String ExecutingInstituteIdentifier { get; set; }

  /// <summary> the official invariant name of the study as given by the sponsor *this field has a max length of 100 </summary>
  [FixedAfterCreation, MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> version of the workflow *this field has a max length of 20 </summary>
  [FixedAfterCreation, MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  /// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value) </summary>
  public String ExtendedMetaData { get; set; }

  [Required]
  public Decimal SiteRelatedTaxPercentage { get; set; }

  /// <summary> ISO 3-Letter Code (USD, EUR, ...) </summary>
  [Required]
  public String SiteRelatedCurrency { get; set; }

  [Dependent]
  public virtual ObservableCollection<BillingDemandEntity> BillingDemands { get; set; } = new ObservableCollection<BillingDemandEntity>();

  [Dependent]
  public virtual ObservableCollection<InvoiceEntity> Invoices { get; set; } = new ObservableCollection<InvoiceEntity>();

#region Mapping

  internal static Expression<Func<StudyExecutionScope, StudyExecutionScopeEntity>> StudyExecutionScopeEntitySelector = ((StudyExecutionScope src) => new StudyExecutionScopeEntity {
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ExecutingInstituteIdentifier = src.ExecutingInstituteIdentifier,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    ExtendedMetaData = src.ExtendedMetaData,
    SiteRelatedTaxPercentage = src.SiteRelatedTaxPercentage,
    SiteRelatedCurrency = src.SiteRelatedCurrency,
  });

  internal static Expression<Func<StudyExecutionScopeEntity, StudyExecutionScope>> StudyExecutionScopeSelector = ((StudyExecutionScopeEntity src) => new StudyExecutionScope {
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    ExecutingInstituteIdentifier = src.ExecutingInstituteIdentifier,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
    ExtendedMetaData = src.ExtendedMetaData,
    SiteRelatedTaxPercentage = src.SiteRelatedTaxPercentage,
    SiteRelatedCurrency = src.SiteRelatedCurrency,
  });

  internal void CopyContentFrom(StudyExecutionScope source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
      }
    }
    if(!Equals(source.ExecutingInstituteIdentifier, this.ExecutingInstituteIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ExecutingInstituteIdentifier))){
        this.ExecutingInstituteIdentifier = source.ExecutingInstituteIdentifier;
      }
    }
    if(!Equals(source.StudyWorkflowName, this.StudyWorkflowName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowName))){
        this.StudyWorkflowName = source.StudyWorkflowName;
      }
    }
    if(!Equals(source.StudyWorkflowVersion, this.StudyWorkflowVersion)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowVersion))){
        this.StudyWorkflowVersion = source.StudyWorkflowVersion;
      }
    }
    this.ExtendedMetaData = source.ExtendedMetaData;
    this.SiteRelatedTaxPercentage = source.SiteRelatedTaxPercentage;
    this.SiteRelatedCurrency = source.SiteRelatedCurrency;
  }

  internal void CopyContentTo(StudyExecutionScope target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
      }
    }
    if(!Equals(target.ExecutingInstituteIdentifier, this.ExecutingInstituteIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ExecutingInstituteIdentifier))){
        target.ExecutingInstituteIdentifier = this.ExecutingInstituteIdentifier;
      }
    }
    if(!Equals(target.StudyWorkflowName, this.StudyWorkflowName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowName))){
        target.StudyWorkflowName = this.StudyWorkflowName;
      }
    }
    if(!Equals(target.StudyWorkflowVersion, this.StudyWorkflowVersion)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyWorkflowVersion))){
        target.StudyWorkflowVersion = this.StudyWorkflowVersion;
      }
    }
    target.ExtendedMetaData = this.ExtendedMetaData;
    target.SiteRelatedTaxPercentage = this.SiteRelatedTaxPercentage;
    target.SiteRelatedCurrency = this.SiteRelatedCurrency;
  }

#endregion

}

/// <summary> created by the sponsor </summary>
public class BillingDemandEntity {

  [Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  [Required]
  public String OfficialNumber { get; set; }

  [Required]
  public Guid StudyExecutionIdentifier { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TransmissionDateUtc { get; set; }

  [Required]
  public DateTime CreationDateUtc { get; set; }

  [Required]
  public String CreatedByPerson { get; set; }

  [Principal]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

  [Referrer]
  public virtual ObservableCollection<BillingItemEntity> BillingItems { get; set; } = new ObservableCollection<BillingItemEntity>();

#region Mapping

  internal static Expression<Func<BillingDemand, BillingDemandEntity>> BillingDemandEntitySelector = ((BillingDemand src) => new BillingDemandEntity {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
  });

  internal static Expression<Func<BillingDemandEntity, BillingDemand>> BillingDemandSelector = ((BillingDemandEntity src) => new BillingDemand {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
  });

  internal void CopyContentFrom(BillingDemand source, Func<String,bool> onFixedValueChangingCallback = null){
    this.Id = source.Id;
    this.OfficialNumber = source.OfficialNumber;
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.TransmissionDateUtc = source.TransmissionDateUtc;
    this.CreationDateUtc = source.CreationDateUtc;
    this.CreatedByPerson = source.CreatedByPerson;
  }

  internal void CopyContentTo(BillingDemand target, Func<String,bool> onFixedValueChangingCallback = null){
    target.Id = this.Id;
    target.OfficialNumber = this.OfficialNumber;
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.TransmissionDateUtc = this.TransmissionDateUtc;
    target.CreationDateUtc = this.CreationDateUtc;
    target.CreatedByPerson = this.CreatedByPerson;
  }

#endregion

}

/// <summary> Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand </summary>
public class BillingItemEntity {

  [Required]
  public Int64 BillingItemId { get; set; }

  [Required]
  public DateTime CreationDateUtc { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> SponsorValidationDateUtc { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> ExecutorValidationDateUtc { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> BillingDemandId { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> InvoiceId { get; set; }

  [Required]
  public Int32 FixedExecutionState { get; set; }

  /// <summary> Including 'FixedPriceOfTasks' but excluding Taxes </summary>
  [Required]
  public Decimal FixedPriceOfItem { get; set; }

  /// <summary> An additional info which is only relevant when declaing Subtasks </summary>
  [Required]
  public Decimal FixedPriceOfTasks { get; set; }

  [Required]
  public Decimal FixedTaxPercentage { get; set; }

  [Required]
  public String TasksRelatedInfo { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> BillableItemUid { get; set; }

  [Required]
  public String Description { get; set; }

  [Lookup]
  public virtual BillingDemandEntity AssignedDemand { get; set; }

  [Lookup]
  public virtual InvoiceEntity AssignedInvoice { get; set; }

  [Lookup]
  public virtual BillableItemEntity BillableItem { get; set; }

#region Mapping

  internal static Expression<Func<BillingItem, BillingItemEntity>> BillingItemEntitySelector = ((BillingItem src) => new BillingItemEntity {
    BillingItemId = src.BillingItemId,
    CreationDateUtc = src.CreationDateUtc,
    SponsorValidationDateUtc = src.SponsorValidationDateUtc,
    ExecutorValidationDateUtc = src.ExecutorValidationDateUtc,
    BillingDemandId = src.BillingDemandId,
    InvoiceId = src.InvoiceId,
    FixedExecutionState = src.FixedExecutionState,
    FixedPriceOfItem = src.FixedPriceOfItem,
    FixedPriceOfTasks = src.FixedPriceOfTasks,
    FixedTaxPercentage = src.FixedTaxPercentage,
    TasksRelatedInfo = src.TasksRelatedInfo,
    BillableItemUid = src.BillableItemUid,
    Description = src.Description,
  });

  internal static Expression<Func<BillingItemEntity, BillingItem>> BillingItemSelector = ((BillingItemEntity src) => new BillingItem {
    BillingItemId = src.BillingItemId,
    CreationDateUtc = src.CreationDateUtc,
    SponsorValidationDateUtc = src.SponsorValidationDateUtc,
    ExecutorValidationDateUtc = src.ExecutorValidationDateUtc,
    BillingDemandId = src.BillingDemandId,
    InvoiceId = src.InvoiceId,
    FixedExecutionState = src.FixedExecutionState,
    FixedPriceOfItem = src.FixedPriceOfItem,
    FixedPriceOfTasks = src.FixedPriceOfTasks,
    FixedTaxPercentage = src.FixedTaxPercentage,
    TasksRelatedInfo = src.TasksRelatedInfo,
    BillableItemUid = src.BillableItemUid,
    Description = src.Description,
  });

  internal void CopyContentFrom(BillingItem source, Func<String,bool> onFixedValueChangingCallback = null){
    this.BillingItemId = source.BillingItemId;
    this.CreationDateUtc = source.CreationDateUtc;
    this.SponsorValidationDateUtc = source.SponsorValidationDateUtc;
    this.ExecutorValidationDateUtc = source.ExecutorValidationDateUtc;
    this.BillingDemandId = source.BillingDemandId;
    this.InvoiceId = source.InvoiceId;
    this.FixedExecutionState = source.FixedExecutionState;
    this.FixedPriceOfItem = source.FixedPriceOfItem;
    this.FixedPriceOfTasks = source.FixedPriceOfTasks;
    this.FixedTaxPercentage = source.FixedTaxPercentage;
    this.TasksRelatedInfo = source.TasksRelatedInfo;
    this.BillableItemUid = source.BillableItemUid;
    this.Description = source.Description;
  }

  internal void CopyContentTo(BillingItem target, Func<String,bool> onFixedValueChangingCallback = null){
    target.BillingItemId = this.BillingItemId;
    target.CreationDateUtc = this.CreationDateUtc;
    target.SponsorValidationDateUtc = this.SponsorValidationDateUtc;
    target.ExecutorValidationDateUtc = this.ExecutorValidationDateUtc;
    target.BillingDemandId = this.BillingDemandId;
    target.InvoiceId = this.InvoiceId;
    target.FixedExecutionState = this.FixedExecutionState;
    target.FixedPriceOfItem = this.FixedPriceOfItem;
    target.FixedPriceOfTasks = this.FixedPriceOfTasks;
    target.FixedTaxPercentage = this.FixedTaxPercentage;
    target.TasksRelatedInfo = this.TasksRelatedInfo;
    target.BillableItemUid = this.BillableItemUid;
    target.Description = this.Description;
  }

#endregion

}

/// <summary> created by the executor-company </summary>
public class InvoiceEntity {

  [FixedAfterCreation, Required]
  public Guid Id { get; set; } = Guid.NewGuid();

  /// <summary> the invoice number </summary>
  [FixedAfterCreation, Required]
  public String OfficialNumber { get; set; }

  [FixedAfterCreation, Required]
  public Guid StudyExecutionIdentifier { get; set; }

  [FixedAfterCreation, Required]
  public DateTime OffcialInvoiceDate { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> TransmissionDateUtc { get; set; }

  [Required]
  public DateTime CreationDateUtc { get; set; }

  [Required]
  public String CreatedByPerson { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> PaymentSubmittedDateUtc { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> PaymentReceivedDateUtc { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> CorrectionOfInvoiceId { get; set; }

  [Referrer]
  public virtual ObservableCollection<BillingItemEntity> BillingItems { get; set; } = new ObservableCollection<BillingItemEntity>();

  [Principal]
  public virtual StudyExecutionScopeEntity StudyExecution { get; set; }

  [Referrer]
  public virtual ObservableCollection<InvoiceEntity> Corrections { get; set; } = new ObservableCollection<InvoiceEntity>();

  [Lookup]
  public virtual InvoiceEntity CorrectionOf { get; set; }

#region Mapping

  internal static Expression<Func<Invoice, InvoiceEntity>> InvoiceEntitySelector = ((Invoice src) => new InvoiceEntity {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    OffcialInvoiceDate = src.OffcialInvoiceDate,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
    PaymentSubmittedDateUtc = src.PaymentSubmittedDateUtc,
    PaymentReceivedDateUtc = src.PaymentReceivedDateUtc,
    CorrectionOfInvoiceId = src.CorrectionOfInvoiceId,
  });

  internal static Expression<Func<InvoiceEntity, Invoice>> InvoiceSelector = ((InvoiceEntity src) => new Invoice {
    Id = src.Id,
    OfficialNumber = src.OfficialNumber,
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    OffcialInvoiceDate = src.OffcialInvoiceDate,
    TransmissionDateUtc = src.TransmissionDateUtc,
    CreationDateUtc = src.CreationDateUtc,
    CreatedByPerson = src.CreatedByPerson,
    PaymentSubmittedDateUtc = src.PaymentSubmittedDateUtc,
    PaymentReceivedDateUtc = src.PaymentReceivedDateUtc,
    CorrectionOfInvoiceId = src.CorrectionOfInvoiceId,
  });

  internal void CopyContentFrom(Invoice source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.Id, this.Id)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(Id))){
        this.Id = source.Id;
      }
    }
    if(!Equals(source.OfficialNumber, this.OfficialNumber)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OfficialNumber))){
        this.OfficialNumber = source.OfficialNumber;
      }
    }
    if(!Equals(source.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
      }
    }
    if(!Equals(source.OffcialInvoiceDate, this.OffcialInvoiceDate)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OffcialInvoiceDate))){
        this.OffcialInvoiceDate = source.OffcialInvoiceDate;
      }
    }
    this.TransmissionDateUtc = source.TransmissionDateUtc;
    this.CreationDateUtc = source.CreationDateUtc;
    this.CreatedByPerson = source.CreatedByPerson;
    this.PaymentSubmittedDateUtc = source.PaymentSubmittedDateUtc;
    this.PaymentReceivedDateUtc = source.PaymentReceivedDateUtc;
    this.CorrectionOfInvoiceId = source.CorrectionOfInvoiceId;
  }

  internal void CopyContentTo(Invoice target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.Id, this.Id)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(Id))){
        target.Id = this.Id;
      }
    }
    if(!Equals(target.OfficialNumber, this.OfficialNumber)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OfficialNumber))){
        target.OfficialNumber = this.OfficialNumber;
      }
    }
    if(!Equals(target.StudyExecutionIdentifier, this.StudyExecutionIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(StudyExecutionIdentifier))){
        target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
      }
    }
    if(!Equals(target.OffcialInvoiceDate, this.OffcialInvoiceDate)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(OffcialInvoiceDate))){
        target.OffcialInvoiceDate = this.OffcialInvoiceDate;
      }
    }
    target.TransmissionDateUtc = this.TransmissionDateUtc;
    target.CreationDateUtc = this.CreationDateUtc;
    target.CreatedByPerson = this.CreatedByPerson;
    target.PaymentSubmittedDateUtc = this.PaymentSubmittedDateUtc;
    target.PaymentReceivedDateUtc = this.PaymentReceivedDateUtc;
    target.CorrectionOfInvoiceId = this.CorrectionOfInvoiceId;
  }

#endregion

}

}
