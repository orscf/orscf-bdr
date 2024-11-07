using System;

namespace MedicalResearch.BillingData {

  /// <summary>
  /// Provides convenience for bulk-registering controllers for all endpoints, for example when hosting them via asp.net core webapi
  /// </summary>
  public static class BdrEndpointRegister {

    /// <summary></summary>
    /// <param name="contractType"></param>
    /// <param name="preferredRoute"> WITHOUT the version-prefix and WITHOUT leading or trailing slash!</param>
    public delegate void GetContractsPerEndpointCallback(Type contractType, string preferredRoute);

    public static void GetContractsPerEndpoint(GetContractsPerEndpointCallback callback) {

      callback.Invoke(typeof(StoreAccess.IBillableItemStore), "store/BillableItem");
      callback.Invoke(typeof(StoreAccess.IInvoiceStore), "store/Invoice");
      callback.Invoke(typeof(StoreAccess.IBillingItemStore), "store/BillingItem");
      callback.Invoke(typeof(StoreAccess.IBillingDemandStore), "store/BillingDemand");
      callback.Invoke(typeof(StoreAccess.IStudyExecutionScopeStore), "store/StudyExecutionScope");

    }

  }

}
