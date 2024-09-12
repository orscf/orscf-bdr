export declare class BillableTask {
    /**
     * a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS')
     */
    taskGuid: string;
    /**
     * a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')
     */
    visitGuid: string;
    /**
     * unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
     */
    taskName: string;
    /**
     * title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
     */
    taskExecutionTitle: string;
}
export declare class BillableVisit {
    /**
     * a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')
     */
    visitGuid: string;
    /**
     * a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')
     */
    studyExecutionIdentifier: string;
    /**
     * identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50
     */
    participantIdentifier: string;
    /**
     * unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
     */
    visitProcedureName: string;
    /**
     * title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
     */
    visitExecutionTitle: string;
    /**
     * *this field is optional
     */
    billingDemandId?: string;
    /**
     * *this field is optional
     */
    invoiceId?: string;
    /**
     * *this field is optional
     */
    executionEndDateUtc?: Date;
    /**
     * indicates, that the visit is ready to get assigned to a 'BillingDemand' (usually this state is managed by the sponsor) This can only be set after there is a valid 'ExecutionEndDateUtc' *this field is optional
     */
    sponsorValidationDateUtc?: Date;
    /**
     * indicates, that the visit is ready to get assigned to a 'Invoice' (usually this state is managed by the executor) This can only be set after either the 'SponsorValidationDateUtc' is set (and there is a Demand) nor the states are only managed by the executor, so that the demand-part is completely skipped. *this field is optional
     */
    executorValidationDateUtc?: Date;
}
export declare class StudyExecutionScope {
    /**
     * a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')
     */
    studyExecutionIdentifier: string;
    /**
     * the institute which is executing the study (this should be an invariant technical representation of the company name or a guid)
     */
    executingInstituteIdentifier: string;
    /**
     * the official invariant name of the study as given by the sponsor *this field has a max length of 100
     */
    studyWorkflowName: string;
    /**
     * version of the workflow *this field has a max length of 20
     */
    studyWorkflowVersion: string;
    /**
     * optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value)
     */
    extendedMetaData?: string;
}
/**
 * created by the sponsor
 */
export declare class BillingDemand {
    id: string;
    officialNumber: string;
    studyExecutionIdentifier: string;
    /**
     * *this field is optional
     */
    transmissionDateUtc?: Date;
    creationDateUtc: Date;
    createdByPerson: string;
}
/**
 * created by the executor-company
 */
export declare class Invoice {
    id: string;
    /**
     * the invoice number
     */
    officialNumber: string;
    studyExecutionIdentifier: string;
    offcialInvoiceDate: Date;
    /**
     * *this field is optional
     */
    transmissionDateUtc?: Date;
    creationDateUtc: Date;
    createdByPerson: string;
    /**
     * *this field is optional
     */
    paymentSubmittedDateUtc?: Date;
    /**
     * *this field is optional
     */
    paymentReceivedDateUtc?: Date;
}
//# sourceMappingURL=models.d.ts.map