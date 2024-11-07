using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MedicalResearch.BillingData.Model {

  [PrimaryIdentity(nameof(BillableItemUid))]
  [PropertyGroup(nameof(BillableItemUid), nameof(BillableItemUid))]
  public partial class BillableItem {

  }

  [PrimaryIdentity(nameof(StudyExecutionIdentifier))]
  [PropertyGroup(nameof(StudyExecutionIdentifier), nameof(StudyExecutionIdentifier))]
  public partial class StudyExecutionScope {

  }

  /// <summary> Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand </summary>
  [PrimaryIdentity(nameof(BillingItemId))]
  [PropertyGroup(nameof(BillingItemId), nameof(BillingItemId))]
  [PropertyGroup(nameof(BillableItemUid), nameof(BillableItemUid))]
  [HasPrincipal("", nameof(BillableItemUid), "", null, nameof(BillableItem))]
  [PropertyGroup(nameof(BillingDemandId), nameof(BillingDemandId))]
  [HasLookup("", nameof(BillingDemandId), "", null, nameof(BillingDemand))]
  [PropertyGroup(nameof(InvoiceId), nameof(InvoiceId))]
  [HasLookup("", nameof(InvoiceId), "", null, nameof(Invoice))]
  public partial class BillingItem {

  }

  /// <summary> created by the sponsor </summary>
  [PrimaryIdentity(nameof(Id))]
  [PropertyGroup(nameof(Id), nameof(Id))]
  public partial class BillingDemand {

  }

  /// <summary> created by the executor-company </summary>
  [PrimaryIdentity(nameof(Id))]
  [PropertyGroup(nameof(Id), nameof(Id))]
  public partial class Invoice {

  }

}
