# ORSCF-BillingData Schema Specification

|          | Info                                    |
|----------|-----------------------------------------|
|author:   |[ORSCF](https://www.orscf.org) ("Open Research Study Communication Formats") / T.Korn|
|license:  |[Apache-2](https://choosealicense.com/licenses/apache-2.0/)|
|version:  |1.5.0|
|timestamp:|2024-10-13 00:00|

### Contents

  * .  [StudyExecutionScope](#StudyExecutionScope)
  * ........\  [BillableVisit](#BillableVisit)
  * ........\  [BillingDemand](#BillingDemand)
  * ........\  [Invoice](#Invoice)
  * .  [VisitBillingRecord](#VisitBillingRecord)

# Model:

![chart](./chart.png)



## StudyExecutionScope


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [StudyExecutionIdentifier](#StudyExecutionScopeStudyExecutionIdentifier-Field) **(PK)** | *guid* | YES | YES |
| [ExecutingInstituteIdentifier](#StudyExecutionScopeExecutingInstituteIdentifier-Field) | *string* | YES | YES |
| [StudyWorkflowName](#StudyExecutionScopeStudyWorkflowName-Field) | *string* (100) | YES | YES |
| [StudyWorkflowVersion](#StudyExecutionScopeStudyWorkflowVersion-Field) | *string* (20) | YES | YES |
| [ExtendedMetaData](#StudyExecutionScopeExtendedMetaData-Field) | *string* | no | no |
| SiteRelatedTaxPercentage | *decimal* | YES | no |
| [SiteRelatedCurrency](#StudyExecutionScopeSiteRelatedCurrency-Field) | *string* | YES | no |
#### Unique Keys
* StudyExecutionIdentifier **(primary)**

#### StudyExecutionScope.**StudyExecutionIdentifier** (Field)

a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')

* this field represents the identity (PK) of the record
* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**ExecutingInstituteIdentifier** (Field)

the institute which is executing the study (this should be an invariant technical representation of the company name or a guid)

* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**StudyWorkflowName** (Field)

the official invariant name of the study as given by the sponsor

* the maximum length of the content within this field is 100 characters.
* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**StudyWorkflowVersion** (Field)

version of the workflow

* the maximum length of the content within this field is 20 characters.
* after the record has been created, the value of this field must not be changed any more!

#### StudyExecutionScope.**ExtendedMetaData** (Field)

optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema

* this field is optional, so that '*null*' values are supported

#### StudyExecutionScope.**SiteRelatedCurrency** (Field)

ISO 3-Letter Code (USD, EUR, ...)



### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [BillableVisits](#BillableVisits-childs-of-this-StudyExecutionScope) | Childs | [BillableVisit](#BillableVisit) | * (multiple) |
| [BillingDemands](#BillingDemands-childs-of-this-StudyExecutionScope) | Childs | [BillingDemand](#BillingDemand) | * (multiple) |
| [Invoices](#Invoices-childs-of-this-StudyExecutionScope) | Childs | [Invoice](#Invoice) | * (multiple) |

##### **BillableVisits** (childs of this StudyExecutionScope)
Target: [BillableVisit](#BillableVisit)
##### **BillingDemands** (childs of this StudyExecutionScope)
Target: [BillingDemand](#BillingDemand)
##### **Invoices** (childs of this StudyExecutionScope)
Target: [Invoice](#Invoice)




## BillableVisit


### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [VisitGuid](#BillableVisitVisitGuid-Field) **(PK)** | *guid* | YES | no |
| [StudyExecutionIdentifier](#BillableVisitStudyExecutionIdentifier-Field) (FK) | *guid* | YES | no |
| [ParticipantIdentifier](#BillableVisitParticipantIdentifier-Field) | *string* (50) | YES | no |
| [VisitProcedureName](#BillableVisitVisitProcedureName-Field) | *string* | YES | no |
| [UniqueExecutionName](#BillableVisitUniqueExecutionName-Field) | *string* | YES | no |
| [ExecutionEndDateUtc](#BillableVisitExecutionEndDateUtc-Field) | *datetime* | no | no |
#### Unique Keys
* VisitGuid **(primary)**

#### BillableVisit.**VisitGuid** (Field)

a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')

* this field represents the identity (PK) of the record

#### BillableVisit.**StudyExecutionIdentifier** (Field)

a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')

* this field is used as foreign key to address the related 'StudyExecution'

#### BillableVisit.**ParticipantIdentifier** (Field)

identity of the patient which can be a randomization or screening number (the exact semantic is defined per study)

* the maximum length of the content within this field is 50 characters.

#### BillableVisit.**VisitProcedureName** (Field)

unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)


#### BillableVisit.**UniqueExecutionName** (Field)

title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)


#### BillableVisit.**ExecutionEndDateUtc** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [StudyExecution](#StudyExecution-parent-of-this-BillableVisit) | Parent | [StudyExecutionScope](#StudyExecutionScope) | 0/1 (optional) |
| [BillingRecord](#BillingRecord-refering-to-this-BillableVisit) | Referers | [VisitBillingRecord](#VisitBillingRecord) | * (multiple) |

##### **StudyExecution** (parent of this BillableVisit)
Target Type: [StudyExecutionScope](#StudyExecutionScope)
Addressed by: [StudyExecutionIdentifier](#BillableVisitStudyExecutionIdentifier-Field).
##### **BillingRecord** (refering to this BillableVisit)
Target: [VisitBillingRecord](#VisitBillingRecord)




## BillingDemand

created by the sponsor
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#BillingDemandId-Field) **(PK)** | *guid* | YES | no |
| OfficialNumber | *string* | YES | no |
| [StudyExecutionIdentifier](#BillingDemandStudyExecutionIdentifier-Field) (FK) | *guid* | YES | no |
| [TransmissionDateUtc](#BillingDemandTransmissionDateUtc-Field) | *datetime* | no | no |
| CreationDateUtc | *datetime* | YES | no |
| CreatedByPerson | *string* | YES | no |
#### Unique Keys
* Id **(primary)**

#### BillingDemand.**Id** (Field)
* this field represents the identity (PK) of the record

#### BillingDemand.**StudyExecutionIdentifier** (Field)
* this field is used as foreign key to address the related 'StudyExecution'

#### BillingDemand.**TransmissionDateUtc** (Field)
* this field is optional, so that '*null*' values are supported


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [StudyExecution](#StudyExecution-parent-of-this-BillingDemand) | Parent | [StudyExecutionScope](#StudyExecutionScope) | 0/1 (optional) |
| [BillingRecords](#BillingRecords-refering-to-this-BillingDemand) | Referers | [VisitBillingRecord](#VisitBillingRecord) | * (multiple) |

##### **StudyExecution** (parent of this BillingDemand)
Target Type: [StudyExecutionScope](#StudyExecutionScope)
Addressed by: [StudyExecutionIdentifier](#BillingDemandStudyExecutionIdentifier-Field).
##### **BillingRecords** (refering to this BillingDemand)
Target: [VisitBillingRecord](#VisitBillingRecord)




## Invoice

created by the executor-company
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [Id](#InvoiceId-Field) **(PK)** | *guid* | YES | YES |
| [OfficialNumber](#InvoiceOfficialNumber-Field) | *string* | YES | YES |
| [StudyExecutionIdentifier](#InvoiceStudyExecutionIdentifier-Field) (FK) | *guid* | YES | YES |
| [OffcialInvoiceDate](#InvoiceOffcialInvoiceDate-Field) | *datetime* | YES | YES |
| [TransmissionDateUtc](#InvoiceTransmissionDateUtc-Field) | *datetime* | no | no |
| CreationDateUtc | *datetime* | YES | no |
| CreatedByPerson | *string* | YES | no |
| [PaymentSubmittedDateUtc](#InvoicePaymentSubmittedDateUtc-Field) | *datetime* | no | no |
| [PaymentReceivedDateUtc](#InvoicePaymentReceivedDateUtc-Field) | *datetime* | no | no |
| [CorrectionOfInvoiceId](#InvoiceCorrectionOfInvoiceId-Field) (FK) | *guid* | no | no |
#### Unique Keys
* Id **(primary)**

#### Invoice.**Id** (Field)
* this field represents the identity (PK) of the record
* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**OfficialNumber** (Field)

the invoice number

* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**StudyExecutionIdentifier** (Field)
* this field is used as foreign key to address the related 'StudyExecution'
* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**OffcialInvoiceDate** (Field)
* after the record has been created, the value of this field must not be changed any more!

#### Invoice.**TransmissionDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### Invoice.**PaymentSubmittedDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### Invoice.**PaymentReceivedDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### Invoice.**CorrectionOfInvoiceId** (Field)
* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'CorrectionOf'


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [StudyExecution](#StudyExecution-parent-of-this-Invoice) | Parent | [StudyExecutionScope](#StudyExecutionScope) | 0/1 (optional) |
| [BillingRecord](#BillingRecord-refering-to-this-Invoice) | Referers | [VisitBillingRecord](#VisitBillingRecord) | * (multiple) |
| [Corrections](#Corrections-refering-to-this-Invoice) | Referers | [Invoice](#Invoice) | * (multiple) |
| [CorrectionOf](#CorrectionOf-lookup-from-this-Invoice) | Lookup | [Invoice](#Invoice) | 1 (required) |

##### **StudyExecution** (parent of this Invoice)
Target Type: [StudyExecutionScope](#StudyExecutionScope)
Addressed by: [StudyExecutionIdentifier](#InvoiceStudyExecutionIdentifier-Field).
##### **BillingRecord** (refering to this Invoice)
Target: [VisitBillingRecord](#VisitBillingRecord)
##### **Corrections** (refering to this Invoice)
Target: [Invoice](#Invoice)
##### **CorrectionOf** (lookup from this Invoice)
Target Type: [Invoice](#Invoice)
Addressed by: [CorrectionOfInvoiceId](#InvoiceCorrectionOfInvoiceId-Field).




## VisitBillingRecord

Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand
### Fields

| Name | Type | Required | Fix |
| ---- | ---- | -------- | --- |
| [BillingRecordId](#VisitBillingRecordBillingRecordId-Field) **(PK)** | *int64* | YES | no |
| [VisitGuid](#VisitBillingRecordVisitGuid-Field) (FK) | *guid* | YES | no |
| CreationDateUtc | *datetime* | YES | no |
| [SponsorValidationDateUtc](#VisitBillingRecordSponsorValidationDateUtc-Field) | *datetime* | no | no |
| [ExecutorValidationDateUtc](#VisitBillingRecordExecutorValidationDateUtc-Field) | *datetime* | no | no |
| [BillingDemandId](#VisitBillingRecordBillingDemandId-Field) (FK) | *guid* | no | no |
| [InvoiceId](#VisitBillingRecordInvoiceId-Field) (FK) | *guid* | no | no |
| FixedExecutionState | *int32* | YES | no |
| FixedPriceOfVisit | *decimal* | YES | no |
| FixedPriceOfTasks | *decimal* | YES | no |
| FixedTaxPercentage | *decimal* | YES | no |
| TasksRelatedInfo | *string* | YES | no |
#### Unique Keys
* BillingRecordId **(primary)**

#### VisitBillingRecord.**BillingRecordId** (Field)
* this field represents the identity (PK) of the record
* this identity is a internal record id, so that it must not be exposed to other systems or displayed to end-users!

#### VisitBillingRecord.**VisitGuid** (Field)
* this field is used as foreign key to address the related 'BillableVisit'

#### VisitBillingRecord.**SponsorValidationDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### VisitBillingRecord.**ExecutorValidationDateUtc** (Field)
* this field is optional, so that '*null*' values are supported

#### VisitBillingRecord.**BillingDemandId** (Field)
* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'AssignedDemand'

#### VisitBillingRecord.**InvoiceId** (Field)
* this field is optional, so that '*null*' values are supported
* this field is used as foreign key to address the related 'AssignedInvoice'


### Relations

| Navigation-Name | Role | Target-Type | Target-Multiplicity |
| --------------- | -----| ----------- | ------------------- |
| [BillableVisit](#BillableVisit-lookup-from-this-VisitBillingRecord) | Lookup | [BillableVisit](#BillableVisit) | 0/1 (optional) |
| [AssignedDemand](#AssignedDemand-lookup-from-this-VisitBillingRecord) | Lookup | [BillingDemand](#BillingDemand) | 1 (required) |
| [AssignedInvoice](#AssignedInvoice-lookup-from-this-VisitBillingRecord) | Lookup | [Invoice](#Invoice) | 1 (required) |

##### **BillableVisit** (lookup from this VisitBillingRecord)
Target Type: [BillableVisit](#BillableVisit)
Addressed by: [VisitGuid](#VisitBillingRecordVisitGuid-Field).
##### **AssignedDemand** (lookup from this VisitBillingRecord)
Target Type: [BillingDemand](#BillingDemand)
Addressed by: [BillingDemandId](#VisitBillingRecordBillingDemandId-Field).
##### **AssignedInvoice** (lookup from this VisitBillingRecord)
Target Type: [Invoice](#Invoice)
Addressed by: [InvoiceId](#VisitBillingRecordInvoiceId-Field).


