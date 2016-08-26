# CentralBusinessValidation
How to build central business validation on DSL / Orchestration level

This spike project shows you how to combine:
* Field Attributes
* Ninject Method Interception


This combination allows you to decorate your request object with [Validate] which in return will match it by request type to a grouping of validation rules. The list of violations is then added to custom Validation Exception and thrown updward before th emethod is even excecuted.
