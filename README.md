# Central Business Validation
How to build central business validation on DSL / Orchestration level. Ensure your contracted business layer enforces the same validation that your presentation layers are.

This spike project shows you how to combine:
* Field Attributes
* Ninject Method Interception


This combination allows you to decorate your request object with [Validate] which in return will match it by request type to a grouping of validation rules. The list of violations is then added to custom Validation Exception and thrown updward before th emethod is even excecuted.

Some good references on this topic:
* Ninject Attributes with Interception - https://buildplease.com/pages/Ninject-Interception-Serilog-Part3-072215/
* DI with Ninject - https://github.com/ninject/Ninject/wiki/Dependency-Injection-With-Ninject
* Validation with Ninject Interceptor - http://tpodolak.com/blog/2012/10/21/argument-validation-with-attributes-and-ninject-interceptor/
* https://github.com/tpodolak/Blog/tree/master/NInjectInterceptors
* http://codepyre.com/2010/03/using-ninject-extensions-interception-part-1-the-basics/
