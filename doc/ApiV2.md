# BillableItemStore
Provides CRUD access to stored BillableItems (based on schema version '2.0.0')

### Methods:



## .GetOriginIdentity
Returns an string, representing the "Identity" of the current origin.
This can be used to discriminate multiple source repos.
(usually it should be related to a SCOPE like {DbServer}+{DbName/Schema}+{EntityName})
NOTE: This is an technical disciminator and it is not required, that it is an human-readable
"frieldly-name". It can just be an Hash or Uid, so its NOT RECOMMENDED to use it as display label!
no parameters
**return value:** String



## .GetCapabilities
Returns an property bag which holds information about the implemented/supported capabilities of this IRepository.
no parameters
**return value:** [RepositoryCapabilities](#RepositoryCapabilities)



## .GetEntityRefs
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [BillableItem](#BillableItem)[] *(array)*



## .GetEntitiesBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [BillableItem](#BillableItem)[] *(array)*



## .GetEntitiesByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [BillableItem](#BillableItem)[] *(array)*



## .GetEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required)|
**return value:** Dictionary_String_Object[] *(array)*



## .CountAll
no parameters
**return value:** Int32



## .Count
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
**return value:** Int32



## .CountBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
**return value:** Int32



## .ContainsKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|key|Guid|**IN**-Param (required)|
**return value:** Boolean



## .AddOrUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .AddOrUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillableItem](#BillableItem)|**IN**-Param (required)|
**return value:** [BillableItem](#BillableItem)



## .TryUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .TryUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillableItem](#BillableItem)|**IN**-Param (required)|
**return value:** [BillableItem](#BillableItem)



## .TryAddEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillableItem](#BillableItem)|**IN**-Param (required)|
**return value:** Guid



## .MassupdateByKeys
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToUpdate|Guid[] *(array)*|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .Massupdate
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .MassupdateBySearchExpression
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryDeleteEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToDelete|Guid[] *(array)*|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryUpdateKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|currentKey|Guid|**IN**-Param (required)|
|newKey|Guid|**IN**-Param (required)|
**return value:** Boolean
# StudyExecutionScopeStore
Provides CRUD access to stored StudyExecutionScopes (based on schema version '2.0.0')

### Methods:



## .GetOriginIdentity
Returns an string, representing the "Identity" of the current origin.
This can be used to discriminate multiple source repos.
(usually it should be related to a SCOPE like {DbServer}+{DbName/Schema}+{EntityName})
NOTE: This is an technical disciminator and it is not required, that it is an human-readable
"frieldly-name". It can just be an Hash or Uid, so its NOT RECOMMENDED to use it as display label!
no parameters
**return value:** String



## .GetCapabilities
Returns an property bag which holds information about the implemented/supported capabilities of this IRepository.
no parameters
**return value:** [RepositoryCapabilities](#RepositoryCapabilities)



## .GetEntityRefs
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [StudyExecutionScope](#StudyExecutionScope)[] *(array)*



## .GetEntitiesBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [StudyExecutionScope](#StudyExecutionScope)[] *(array)*



## .GetEntitiesByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [StudyExecutionScope](#StudyExecutionScope)[] *(array)*



## .GetEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required)|
**return value:** Dictionary_String_Object[] *(array)*



## .CountAll
no parameters
**return value:** Int32



## .Count
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
**return value:** Int32



## .CountBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
**return value:** Int32



## .ContainsKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|key|Guid|**IN**-Param (required)|
**return value:** Boolean



## .AddOrUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .AddOrUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[StudyExecutionScope](#StudyExecutionScope)|**IN**-Param (required)|
**return value:** [StudyExecutionScope](#StudyExecutionScope)



## .TryUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .TryUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[StudyExecutionScope](#StudyExecutionScope)|**IN**-Param (required)|
**return value:** [StudyExecutionScope](#StudyExecutionScope)



## .TryAddEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[StudyExecutionScope](#StudyExecutionScope)|**IN**-Param (required)|
**return value:** Guid



## .MassupdateByKeys
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToUpdate|Guid[] *(array)*|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .Massupdate
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .MassupdateBySearchExpression
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryDeleteEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToDelete|Guid[] *(array)*|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryUpdateKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|currentKey|Guid|**IN**-Param (required)|
|newKey|Guid|**IN**-Param (required)|
**return value:** Boolean
# BillingDemandStore
Provides CRUD access to stored BillingDemands (based on schema version '2.0.0')

### Methods:



## .GetOriginIdentity
Returns an string, representing the "Identity" of the current origin.
This can be used to discriminate multiple source repos.
(usually it should be related to a SCOPE like {DbServer}+{DbName/Schema}+{EntityName})
NOTE: This is an technical disciminator and it is not required, that it is an human-readable
"frieldly-name". It can just be an Hash or Uid, so its NOT RECOMMENDED to use it as display label!
no parameters
**return value:** String



## .GetCapabilities
Returns an property bag which holds information about the implemented/supported capabilities of this IRepository.
no parameters
**return value:** [RepositoryCapabilities](#RepositoryCapabilities)



## .GetEntityRefs
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [BillingDemand](#BillingDemand)[] *(array)*



## .GetEntitiesBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [BillingDemand](#BillingDemand)[] *(array)*



## .GetEntitiesByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [BillingDemand](#BillingDemand)[] *(array)*



## .GetEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required)|
**return value:** Dictionary_String_Object[] *(array)*



## .CountAll
no parameters
**return value:** Int32



## .Count
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
**return value:** Int32



## .CountBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
**return value:** Int32



## .ContainsKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|key|Guid|**IN**-Param (required)|
**return value:** Boolean



## .AddOrUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .AddOrUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillingDemand](#BillingDemand)|**IN**-Param (required): created by the sponsor|
**return value:** [BillingDemand](#BillingDemand)



## .TryUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .TryUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillingDemand](#BillingDemand)|**IN**-Param (required): created by the sponsor|
**return value:** [BillingDemand](#BillingDemand)



## .TryAddEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillingDemand](#BillingDemand)|**IN**-Param (required): created by the sponsor|
**return value:** Guid



## .MassupdateByKeys
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToUpdate|Guid[] *(array)*|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .Massupdate
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .MassupdateBySearchExpression
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryDeleteEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToDelete|Guid[] *(array)*|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryUpdateKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|currentKey|Guid|**IN**-Param (required)|
|newKey|Guid|**IN**-Param (required)|
**return value:** Boolean
# BillingItemStore
Provides CRUD access to stored BillingItems (based on schema version '2.0.0')

### Methods:



## .GetOriginIdentity
Returns an string, representing the "Identity" of the current origin.
This can be used to discriminate multiple source repos.
(usually it should be related to a SCOPE like {DbServer}+{DbName/Schema}+{EntityName})
NOTE: This is an technical disciminator and it is not required, that it is an human-readable
"frieldly-name". It can just be an Hash or Uid, so its NOT RECOMMENDED to use it as display label!
no parameters
**return value:** String



## .GetCapabilities
Returns an property bag which holds information about the implemented/supported capabilities of this IRepository.
no parameters
**return value:** [RepositoryCapabilities](#RepositoryCapabilities)



## .GetEntityRefs
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Int64](#EntityRef_Int64)[] *(array)*



## .GetEntityRefsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Int64](#EntityRef_Int64)[] *(array)*



## .GetEntityRefsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Int64[] *(array)*|**IN**-Param (required)|
**return value:** [EntityRef_Int64](#EntityRef_Int64)[] *(array)*



## .GetEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [BillingItem](#BillingItem)[] *(array)*



## .GetEntitiesBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [BillingItem](#BillingItem)[] *(array)*



## .GetEntitiesByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Int64[] *(array)*|**IN**-Param (required)|
**return value:** [BillingItem](#BillingItem)[] *(array)*



## .GetEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Int64[] *(array)*|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required)|
**return value:** Dictionary_String_Object[] *(array)*



## .CountAll
no parameters
**return value:** Int32



## .Count
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
**return value:** Int32



## .CountBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
**return value:** Int32



## .ContainsKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|key|Int64|**IN**-Param (required)|
**return value:** Boolean



## .AddOrUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .AddOrUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillingItem](#BillingItem)|**IN**-Param (required): Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand|
**return value:** [BillingItem](#BillingItem)



## .TryUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .TryUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillingItem](#BillingItem)|**IN**-Param (required): Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand|
**return value:** [BillingItem](#BillingItem)



## .TryAddEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[BillingItem](#BillingItem)|**IN**-Param (required): Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand|
**return value:** Int64



## .MassupdateByKeys
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToUpdate|Int64[] *(array)*|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Int64[] *(array)*



## .Massupdate
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Int64[] *(array)*



## .MassupdateBySearchExpression
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Int64[] *(array)*



## .TryDeleteEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToDelete|Int64[] *(array)*|**IN**-Param (required)|
**return value:** Int64[] *(array)*



## .TryUpdateKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|currentKey|Int64|**IN**-Param (required)|
|newKey|Int64|**IN**-Param (required)|
**return value:** Boolean
# InvoiceStore
Provides CRUD access to stored Invoices (based on schema version '2.0.0')

### Methods:



## .GetOriginIdentity
Returns an string, representing the "Identity" of the current origin.
This can be used to discriminate multiple source repos.
(usually it should be related to a SCOPE like {DbServer}+{DbName/Schema}+{EntityName})
NOTE: This is an technical disciminator and it is not required, that it is an human-readable
"frieldly-name". It can just be an Hash or Uid, so its NOT RECOMMENDED to use it as display label!
no parameters
**return value:** String



## .GetCapabilities
Returns an property bag which holds information about the implemented/supported capabilities of this IRepository.
no parameters
**return value:** [RepositoryCapabilities](#RepositoryCapabilities)



## .GetEntityRefs
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntityRefsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [EntityRef_Guid](#EntityRef_Guid)[] *(array)*



## .GetEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [Invoice](#Invoice)[] *(array)*



## .GetEntitiesBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** [Invoice](#Invoice)[] *(array)*



## .GetEntitiesByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
**return value:** [Invoice](#Invoice)[] *(array)*



## .GetEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required): An array of field names to be loaded|
|sortedBy|String[] *(array)*|**IN**-Param (required): An array of field names to be used for sorting the results (before 'limit' and 'skip' is processed). Use the character "^" as prefix for DESC sorting. Sample: ['^Age','Lastname']|
|limit|Int32? *(nullable)*|**IN**-Param (optional)|
|skip|Int32? *(nullable)*|**IN**-Param (optional)|
**return value:** Dictionary_String_Object[] *(array)*



## .GetEntityFieldsByKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToLoad|Guid[] *(array)*|**IN**-Param (required)|
|includedFieldNames|String[] *(array)*|**IN**-Param (required)|
**return value:** Dictionary_String_Object[] *(array)*



## .CountAll
no parameters
**return value:** Int32



## .Count
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
**return value:** Int32



## .CountBySearchExpression
NOTE: this method can only be used, if the 'SupportsStringBaseSearchExpressions'-Capability is given for this repository!
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
**return value:** Int32



## .ContainsKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|key|Guid|**IN**-Param (required)|
**return value:** Boolean



## .AddOrUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .AddOrUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[Invoice](#Invoice)|**IN**-Param (required): created by the executor-company|
**return value:** [Invoice](#Invoice)



## .TryUpdateEntityFields
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Dictionary_String_Object



## .TryUpdateEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[Invoice](#Invoice)|**IN**-Param (required): created by the executor-company|
**return value:** [Invoice](#Invoice)



## .TryAddEntity
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|entity|[Invoice](#Invoice)|**IN**-Param (required): created by the executor-company|
**return value:** Guid



## .MassupdateByKeys
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToUpdate|Guid[] *(array)*|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .Massupdate
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|filter|[ExpressionTree](#ExpressionTree)|**IN**-Param (required): (from 'FUSE-fx.RepositoryContract')|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .MassupdateBySearchExpression
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|searchExpression|String|**IN**-Param (required)|
|fields|Dictionary_String_Object|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryDeleteEntities
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|keysToDelete|Guid[] *(array)*|**IN**-Param (required)|
**return value:** Guid[] *(array)*



## .TryUpdateKey
#### Parameters:
|Name|Type|Description|
|----|----|-----------|
|currentKey|Guid|**IN**-Param (required)|
|newKey|Guid|**IN**-Param (required)|
**return value:** Boolean



# Models:



## BillableItem
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|BillableItemUid|Guid|(required): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS')|
|StudyExecutionIdentifier|Guid|(required): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')|
|ParticipantIdentifier|String|(required): identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50|
|VisitProcedureName|String|(required): unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)|
|UniqueExecutionName|String|(required): title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor)|
|ExecutionEndDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|Description|String|(optional): *this field is optional (use null as value)|
|RelatedTo|String|(required): One of the following values: 'General' / 'Site' / 'Paticipant' (Requires a ParticipantIdentifier) / 'Visit' (Requires a ParticipantIdentifier and UniqueExecutionName)|



## BillingDemand
created by the sponsor
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|Id|Guid|(required)|
|OfficialNumber|String|(required)|
|StudyExecutionIdentifier|Guid|(required)|
|TransmissionDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|CreationDateUtc|DateTime|(required)|
|CreatedByPerson|String|(required)|



## BillingItem
Respresents a Snapshot, containig al the values, which are required to be fixed in relation to a concrete invoice or demand
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|BillingItemId|Int64|(required)|
|CreationDateUtc|DateTime|(required)|
|SponsorValidationDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|ExecutorValidationDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|BillingDemandId|Guid? *(nullable)*|(optional): *this field is optional|
|InvoiceId|Guid? *(nullable)*|(optional): *this field is optional|
|FixedExecutionState|Int32|(required)|
|FixedPriceOfItem|Decimal|(required): Including 'FixedPriceOfTasks' but excluding Taxes|
|FixedPriceOfTasks|Decimal|(required): An additional info which is only relevant when declaing Subtasks|
|FixedTaxPercentage|Decimal|(required)|
|TasksRelatedInfo|String|(required)|
|BillableItemUid|Guid? *(nullable)*|(optional): *this field is optional|
|Description|String|(required)|



## Invoice
created by the executor-company
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|Id|Guid|(required)|
|OfficialNumber|String|(required): the invoice number|
|StudyExecutionIdentifier|Guid|(required)|
|OffcialInvoiceDate|DateTime|(required)|
|TransmissionDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|CreationDateUtc|DateTime|(required)|
|CreatedByPerson|String|(required)|
|PaymentSubmittedDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|PaymentReceivedDateUtc|DateTime? *(nullable)*|(optional): *this field is optional|
|CorrectionOfInvoiceId|Guid? *(nullable)*|(optional): *this field is optional|



## StudyExecutionScope
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|StudyExecutionIdentifier|Guid|(required): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS')|
|ExecutingInstituteIdentifier|String|(required): the institute which is executing the study (this should be an invariant technical representation of the company name or a guid)|
|StudyWorkflowName|String|(required): the official invariant name of the study as given by the sponsor *this field has a max length of 100|
|StudyWorkflowVersion|String|(required): version of the workflow *this field has a max length of 20|
|ExtendedMetaData|String|(optional): optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value)|
|SiteRelatedTaxPercentage|Decimal|(required)|
|SiteRelatedCurrency|String|(required): ISO 3-Letter Code (USD, EUR, ...)|



## EntityRef
(from 'FUSE-fx.RepositoryContract')
EntityRef (UNTYPED)
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|Key|Object|(optional)|
|Label|String|(optional)|



## EntityRef_Guid
(from 'FUSE-fx.RepositoryContract')
EntityRef with Typed Key (generic)
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|Key|Guid? *(nullable)*|(optional)|
|Key|Object|(optional)|
|Label|String|(optional)|



## EntityRef_Int64
(from 'FUSE-fx.RepositoryContract')
EntityRef with Typed Key (generic)
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|Key|Int64? *(nullable)*|(optional)|
|Key|Object|(optional)|
|Label|String|(optional)|



## ExpressionTree
(from 'FUSE-fx.RepositoryContract')
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|MatchAll|Boolean? *(nullable)*|(optional): true: AND-Relation | false: OR-Relation|
|Negate|Boolean? *(nullable)*|(optional): Negates the result|
|Predicates|List_FieldPredicate|(optional): Can contain ATOMIC predicates (FieldName~Value). NOTE: If there is more than one predicate with the same FieldName in combination with MatchAll=true, then this will lead to an subordinated OR-Expression dedicated to this field.|
|SubTree|List_ExpressionTree|(optional)|



## RepositoryCapabilities
(from 'FUSE-fx.RepositoryContract')
An property bag which holds information about the implemented/supported
capabilities of an IRepository.
#### Fields:
|Name|Type|Description|
|----|----|-----------|
|CanReadContent|Boolean? *(nullable)*|(optional): Indicates, that this repository offers access to load entities(classes) or some their entity fields (if this is false, then only EntityRefs are accessable)|
|CanUpdateContent|Boolean? *(nullable)*|(optional)|
|CanAddNewEntities|Boolean? *(nullable)*|(optional)|
|CanDeleteEntities|Boolean? *(nullable)*|(optional)|
|SupportsMassupdate|Boolean? *(nullable)*|(optional)|
|SupportsKeyUpdate|Boolean? *(nullable)*|(optional)|
|SupportsStringBasedSearchExpressions|Boolean? *(nullable)*|(optional)|
|RequiresExternalKeys|Boolean? *(nullable)*|(optional): Indicates, that entities can only be added to this repository, if ther key fields are pre-initialized by the caller. If false, then the persistence-technology behind the repository implementation will auto-generate a new key by its own.|
