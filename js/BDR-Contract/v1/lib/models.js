"use strict";
/* based on ORSCF BillingData Contract v1.8.0.0 */
Object.defineProperty(exports, "__esModule", { value: true });
exports.Invoice = exports.BillingDemand = exports.StudyExecutionScope = exports.BillableVisit = exports.BillableTask = void 0;
var BillableTask = /** @class */ (function () {
    function BillableTask() {
        /**
         * a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS')
         */
        this.taskGuid = '';
        /**
         * a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')
         */
        this.visitGuid = '';
        /**
         * unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
         */
        this.taskName = '';
        /**
         * title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
         */
        this.taskExecutionTitle = '';
    }
    return BillableTask;
}());
exports.BillableTask = BillableTask;
var BillableVisit = /** @class */ (function () {
    function BillableVisit() {
        /**
         * a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')
         */
        this.visitGuid = '';
        /**
         * a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')
         */
        this.studyExecutionIdentifier = '';
        /**
         * identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50
         */
        this.participantIdentifier = '';
        /**
         * unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
         */
        this.visitProcedureName = '';
        /**
         * title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)
         */
        this.visitExecutionTitle = '';
    }
    return BillableVisit;
}());
exports.BillableVisit = BillableVisit;
var StudyExecutionScope = /** @class */ (function () {
    function StudyExecutionScope() {
        /**
         * a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')
         */
        this.studyExecutionIdentifier = '';
        /**
         * the institute which is executing the study (this should be an invariant technical representation of the company name or a guid)
         */
        this.executingInstituteIdentifier = '';
        /**
         * the official invariant name of the study as given by the sponsor *this field has a max length of 100
         */
        this.studyWorkflowName = '';
        /**
         * version of the workflow *this field has a max length of 20
         */
        this.studyWorkflowVersion = '';
    }
    return StudyExecutionScope;
}());
exports.StudyExecutionScope = StudyExecutionScope;
/**
 * created by the sponsor
 */
var BillingDemand = /** @class */ (function () {
    function BillingDemand() {
        this.id = '';
        this.officialNumber = '';
        this.studyExecutionIdentifier = '';
        this.creationDateUtc = new Date();
        this.createdByPerson = '';
    }
    return BillingDemand;
}());
exports.BillingDemand = BillingDemand;
/**
 * created by the executor-company
 */
var Invoice = /** @class */ (function () {
    function Invoice() {
        this.id = '';
        /**
         * the invoice number
         */
        this.officialNumber = '';
        this.studyExecutionIdentifier = '';
        this.offcialInvoiceDate = new Date();
        this.creationDateUtc = new Date();
        this.createdByPerson = '';
    }
    return Invoice;
}());
exports.Invoice = Invoice;
//# sourceMappingURL=models.js.map