using System;

namespace MedicalResearch.BillingData {

  /// <summary>
  /// Provides convenience for bulk-registering factories for all endpoints, for example when hosting them via asp.net core webapi
  /// </summary>
  public static class BdrShowcaseEndpointFactory {

    public delegate void GetFactoryMethodsPerEndpointCallback(Type contractType, Func<object> endpointFactory);

    public static void GetFactoryMethodsPerEndpoint(GetFactoryMethodsPerEndpointCallback callback) {

      callback.Invoke(typeof(StoreAccess.IBillableItemStore), () => new StoreAccess.BillableItemStore());
      callback.Invoke(typeof(StoreAccess.IInvoiceStore), () => new StoreAccess.InvoiceStore());
      callback.Invoke(typeof(StoreAccess.IBillingItemStore), () => new StoreAccess.BillingItemStore());
      callback.Invoke(typeof(StoreAccess.IBillingDemandStore), () => new StoreAccess.BillingDemandStore());
      callback.Invoke(typeof(StoreAccess.IStudyExecutionScopeStore), () => new StoreAccess.StudyExecutionScopeStore());

    }

  }

}
