using System.Linq;
using System.Reflection;
using System.Threading;

namespace DryIoc;

public static class Error
{
	private static int _errorIndex;

	public static readonly string[] Messages;

	public static readonly int UnableToResolveUnknownService;

	public static readonly int UnableToResolveFromRegisteredServices;

	public static readonly int ExpectedSingleDefaultFactory;

	public static readonly int RegisteringImplementationNotAssignableToServiceType;

	public static readonly int RegisteredFactoryMethodResultTypesIsNotAssignableToImplementationType;

	public static readonly int ImpossibleToRegisterOpenGenericWithRegisterDelegate;

	public static readonly int RegisteringOpenGenericImplWithNonGenericService;

	public static readonly int RegisteringOpenGenericServiceWithMissingTypeArgs;

	public static readonly int RegisteringNotAGenericTypedefImplType;

	public static readonly int RegisteringNotAGenericTypedefServiceType;

	public static readonly int RegisteringNullImplementationTypeAndNoFactoryMethod;

	public static readonly int RegisteringObjectTypeAsImplementationIsNotSupported;

	public static readonly int RegisteringAbstractImplementationTypeAndNoFactoryMethod;

	public static readonly int UnableToSelectSinglePublicConstructorFromMultiple;

	public static readonly int UnableToSelectSinglePublicConstructorFromNone;

	public static readonly int NoMatchedImplementedTypesWithServiceType;

	public static readonly int NoMatchedFactoryMethodDeclaringTypeWithServiceTypeArgs;

	public static readonly int NoMatchedFactoryMethodWithServiceTypeArgs;

	public static readonly int OpenGenericFactoryMethodDeclaringTypeIsNotSupportedOnThisPlatform;

	public static readonly int ResolvingOpenGenericServiceTypeIsNotPossible;

	public static readonly int RecursiveDependencyDetected;

	public static readonly int ScopeIsDisposed;

	public static readonly int NotFoundOpenGenericImplTypeArgInService;

	public static readonly int UnableToSelectCtor;

	public static readonly int UnableToFindCtorWithAllResolvableArgs;

	public static readonly int RegisteredDelegateResultIsNotOfServiceType;

	public static readonly int NotFoundSpecifiedWritablePropertyOrField;

	public static readonly int PushingToRequestWithoutFactory;

	public static readonly int NoMatchedGenericParamConstraints;

	public static readonly int GenericWrapperWithMultipleTypeArgsShouldSpecifyArgIndex;

	public static readonly int GenericWrapperTypeArgIndexOutOfBounds;

	public static readonly int DependencyHasShorterReuseLifespan;

	public static readonly int WeakRefReuseWrapperGCed;

	public static readonly int ServiceIsNotAssignableFromFactoryMethod;

	public static readonly int GotNullConstructorFromFactoryMethod;

	public static readonly int UnableToRegisterDuplicateDefault;

	public static readonly int UnableToRegisterDuplicateKey;

	public static readonly int NoCurrentScope;

	public static readonly int ContainerIsDisposed;

	public static readonly int NoMatchedScopeFound;

	public static readonly int NotSupportedMadeOfExpression;

	public static readonly int UnexpectedFactoryMemberExpressionInMadeOf;

	public static readonly int UnexpectedExpressionInsteadOfArgMethodInMadeOf;

	public static readonly int UnexpectedExpressionInsteadOfConstantInMadeOf;

	public static readonly int InjectedCustomValueIsOfDifferentType;

	public static readonly int NoConversionOperatorFoundWhenInterpretingTheConvertExpression;

	public static readonly int StateIsRequiredToUseItem;

	public static readonly int ArgValueIndexIsProvidedButNoArgValues;

	public static readonly int ArgValueIndexIsOutOfProvidedArgValues;

	public static readonly int ResolutionNeedsRequiredServiceType;

	public static readonly int RegisterMappingNotFoundRegisteredService;

	public static readonly int RegisterMappingUnableToSelectFromMultipleFactories;

	public static readonly int RegisteringInstanceNotAssignableToServiceType;

	public static readonly int NoMoreRegistrationsAllowed;

	public static readonly int NoMoreUnregistrationsAllowed;

	public static readonly int GotNullFactoryWhenResolvingService;

	public static readonly int RegisteredDisposableTransientWontBeDisposedByContainer;

	public static readonly int NotFoundMetaCtorWithTwoArgs;

	public static readonly int UnableToSelectFromManyRegistrationsWithMatchingMetadata;

	public static readonly int ImplTypeIsNotSpecifiedForAutoCtorSelection;

	public static readonly int NoImplementationForPlaceholder;

	public static readonly int InjectedIntoFactoryDummy;

	public static readonly int DecoratorShouldNotBeRegisteredWithServiceKey;

	public static readonly int PassedCtorOrMemberIsNull;

	public static readonly int PassedMemberIsNotStaticButInstanceFactoryIsNull;

	public static readonly int PassedMemberIsStaticButInstanceFactoryIsNotNull;

	public static readonly int MadeOfCallExpressionParameterDoesNotCorrespondToTheFactoryInfo;

	public static readonly int UndefinedMethodWhenGettingTheSingleMethod;

	public static readonly int UndefinedMethodWhenGettingMethodWithSpecifiedParameters;

	public static readonly int UndefinedPropertyWhenGettingProperty;

	public static readonly int UndefinedFieldWhenGettingField;

	public static readonly int UnableToFindConstructorWithArgs;

	public static readonly int UnableToFindSingleConstructor;

	public static readonly int DisposerTrackForDisposeError;

	public static readonly int NoServicesWereRegisteredByRegisterMany;

	public static readonly int FoundNoRootsToValidate;

	public static readonly int NoServiceTypesToValidate;

	public static readonly int ValidateFoundErrors;

	public static readonly int UnableToInterpretTheNestedLambda;

	public static readonly int WaitForScopedServiceIsCreatedTimeoutExpired;

	public static readonly int ServiceTypeIsNull;

	private static int Of(string message)
	{
		int num = Interlocked.Increment(ref _errorIndex);
		Messages[num] = message;
		return num;
	}

	public static string NameOf(int error)
	{
		if (error != -1)
		{
			return typeof(Error).GetTypeInfo().DeclaredFields.Where((FieldInfo f) => f.FieldType == typeof(int)).Where((FieldInfo _, int i) => i == error + 1).FirstOrDefault()?.Name;
		}
		return "ErrorCheck";
	}

	static Error()
	{
		_errorIndex = -1;
		Messages = new string[100];
		UnableToResolveUnknownService = Of("Unable to resolve {0}" + "\n" + "Where no service registrations found" + "\n" + "  and no dynamic registrations found in {1} of Rules.DynamicServiceProviders" + "\n" + "  and nothing found in {2} of Rules.UnknownServiceResolvers");
		UnableToResolveFromRegisteredServices = Of("Unable to resolve {0}" + "\n" + "  with normal and dynamic registrations:" + "\n" + "{1}");
		ExpectedSingleDefaultFactory = Of("Expecting a single default registration but found many:" + "\n" + "{0}" + "\n" + "when resolving {1}." + "\n" + "Please identify service with key, or metadata, or use Rules.WithFactorySelector to specify single registered factory.");
		RegisteringImplementationNotAssignableToServiceType = Of("Registering implementation type {0} is not assignable to service type {1}.");
		RegisteredFactoryMethodResultTypesIsNotAssignableToImplementationType = Of("Registered factory method return type {1} should be assignable Or castable to implementation type {0} but it is not.");
		ImpossibleToRegisterOpenGenericWithRegisterDelegate = Of("Unable to register delegate factory for open-generic service {0}." + "\n" + "You need to specify concrete (closed) service type returned by delegate.");
		RegisteringOpenGenericImplWithNonGenericService = Of("Unable to register open-generic implementation {0} with non-generic service {1}.");
		RegisteringOpenGenericServiceWithMissingTypeArgs = Of("Unable to register open-generic implementation {0} because service {1} should specify all type arguments, but specifies only {2}.");
		RegisteringNotAGenericTypedefImplType = Of("Unsupported registration of implementation {0} which is not a generic type definition but contains generic parameters." + "\n" + "Consider to register generic type definition {1} instead.");
		RegisteringNotAGenericTypedefServiceType = Of("Unsupported registration of service {0} which is not a generic type definition but contains generic parameters." + "\n" + "Consider to register generic type definition {1} instead.");
		RegisteringNullImplementationTypeAndNoFactoryMethod = Of("Registering without implementation type and without FactoryMethod to use instead.");
		RegisteringObjectTypeAsImplementationIsNotSupported = Of("Registering `System.Object` type as implementation without a factory method is not supported.");
		RegisteringAbstractImplementationTypeAndNoFactoryMethod = Of("Registering abstract implementation type {0} when it is should be concrete. Also there is not FactoryMethod to use instead.");
		UnableToSelectSinglePublicConstructorFromMultiple = Of("Unable to select single public constructor from implementation type {0}:" + "\n" + "{1}");
		UnableToSelectSinglePublicConstructorFromNone = Of("Unable to select a single public constructor from the implementation type '{0}' because the type does not have public constructors.");
		NoMatchedImplementedTypesWithServiceType = Of("Unable to match service with open-generic {0} implementing {1} when resolving {2}.");
		NoMatchedFactoryMethodDeclaringTypeWithServiceTypeArgs = Of("Unable to match open-generic factory method Declaring type {0} with requested service type arguments <{1}> when resolving {2}.");
		NoMatchedFactoryMethodWithServiceTypeArgs = Of("Unable to match open-generic factory method {0} with requested service type arguments <{1}> when resolving {2}.");
		OpenGenericFactoryMethodDeclaringTypeIsNotSupportedOnThisPlatform = Of("[Specific to this .NET version] Unable to match method or constructor {0} from open-generic declaring type {1} to closed-generic type {2}, " + "\n" + "Please give the method an unique name to distinguish it from other overloads.");
		ResolvingOpenGenericServiceTypeIsNotPossible = Of("Resolving open-generic service type is not possible for type: {0}.");
		RecursiveDependencyDetected = Of("Recursive dependency is detected when resolving " + "\n" + "{0}.");
		ScopeIsDisposed = Of("Scope {0} is disposed and scoped instances are disposed and no longer available." + "\n" + "Dispose stack-trace: " + "\n" + "{1}");
		NotFoundOpenGenericImplTypeArgInService = Of("Unable to find for open-generic implementation {0} the type argument {1} when resolving {2}.");
		UnableToSelectCtor = Of("Unable to get constructor of {0} using provided constructor selector when resolving {1}.");
		UnableToFindCtorWithAllResolvableArgs = Of("Unable to find most resolvable constructor also including passed input arguments `{0}` " + "\n" + " when resolving: {1}.");
		RegisteredDelegateResultIsNotOfServiceType = Of("Registered factory delegate returns service {0} is not assignable to desired service {1}.");
		NotFoundSpecifiedWritablePropertyOrField = Of("Unable to find writable property or field {0} when resolving: {1}.");
		PushingToRequestWithoutFactory = Of("Pushing the next request `{0}` into parent request not yet resolved to factory: {1}");
		NoMatchedGenericParamConstraints = Of("Open-generic service does not match with registered open-generic implementation constraints {0} when resolving: {1}.");
		GenericWrapperWithMultipleTypeArgsShouldSpecifyArgIndex = Of("Generic wrapper type {0} should specify what type argument is wrapped, but it does not.");
		GenericWrapperTypeArgIndexOutOfBounds = Of("Registered generic wrapper {0} specified type argument index {1} is out of type argument list.");
		DependencyHasShorterReuseLifespan = Of("Dependency {0} with reuse {1} has a shorter lifespan than its parent's {2}" + "\n" + "If you know what you're doing you may disable this error with the rule `new Container(rules => rules.WithoutThrowIfDependencyHasShorterReuseLifespan())`.");
		WeakRefReuseWrapperGCed = Of("Reused service wrapped in WeakReference is Garbage Collected and no longer available.");
		ServiceIsNotAssignableFromFactoryMethod = Of("Service of {0} is not assignable from factory method {1} when resolving: {2}.");
		GotNullConstructorFromFactoryMethod = Of("Got null constructor when resolving {0}");
		UnableToRegisterDuplicateDefault = Of("The default service {0} without key {1} is already registered as {2}.");
		UnableToRegisterDuplicateKey = Of("Unable to register service with duplicate key '{0}': {1}" + "\n" + " There is already registered service with the same key {2}.");
		NoCurrentScope = Of("No current scope is available - probably you are registering to or resolving from outside of the scope. " + "\n" + "It also may be because of the scoped dependency has singletons in its parent chain so the dependency is resolved from the root container resolver." + "\n" + "Current resolver context is: {0}.");
		ContainerIsDisposed = Of("Container is disposed and should not be used: {0}");
		NoMatchedScopeFound = Of("Unable to find matching scope with name {0} starting from the current scope {1}.");
		NotSupportedMadeOfExpression = Of("Expected expression of method call, property getter, or new statement (with optional property initializer), but found this Made.Of expression: {0}");
		UnexpectedFactoryMemberExpressionInMadeOf = Of("Expected property getter, but found not supported `{0}` " + "\n" + "in Made.Of expression: `{1}`");
		UnexpectedExpressionInsteadOfArgMethodInMadeOf = Of("Expected `Arg.Of` method call to specify parameter, property or field, but found `{0}` " + "\n" + "in Made.Of expression: `{1}`");
		UnexpectedExpressionInsteadOfConstantInMadeOf = Of("Expected `ConstantExpression` for value of parameter, property, or field, but found `{0}` " + "\n" + "in Made.Of expression: `{1}`");
		InjectedCustomValueIsOfDifferentType = Of("Injected value {0} is not assignable to {1} when resolving: {2}");
		NoConversionOperatorFoundWhenInterpretingTheConvertExpression = Of("There is no explicit or implicit conversion operator found when interpreting {0} to {1} in expression: {2}");
		StateIsRequiredToUseItem = Of("Runtime state is required to inject (or use) the object of type `{0}` and value: `{1}`. " + "\n" + "The reason is using RegisterDelegate, Use, RegisterInitializer/Disposer, or registering with non-primitive service key, or metadata." + "\n" + "You can convert run-time value to expression via container.With(rules => rules.WithItemToExpressionConverter(YOUR_ITEM_TO_EXPRESSION_CONVERTER)).");
		ArgValueIndexIsProvidedButNoArgValues = Of("`Arg.Index` is provided but no values are passed in Made.Of expression: " + "\n" + "{0}");
		ArgValueIndexIsOutOfProvidedArgValues = Of("`Arg.Index` {0} is outside of provided values [{1}] in Made.Of expression: " + "\n" + "{2}");
		ResolutionNeedsRequiredServiceType = Of("Expecting required service type but it is not specified when resolving: {0}");
		RegisterMappingNotFoundRegisteredService = Of("When registering mapping, Container is unable to find factory of registered service type {0} and key {1}.");
		RegisterMappingUnableToSelectFromMultipleFactories = Of("RegisterMapping selected more than 1 factory with provided type {0} and key {1}: {2}");
		RegisteringInstanceNotAssignableToServiceType = Of("Registered instance of type {0} is not assignable to serviceType {1}.");
		NoMoreRegistrationsAllowed = Of("Container does not allow further registrations." + "\n" + "Attempting to register {0}{1} with implementation factory {2}.");
		NoMoreUnregistrationsAllowed = Of("Container does not allow further registry modification." + "\n" + "Attempting to Unregister {0}{1} with factory type {2}.");
		GotNullFactoryWhenResolvingService = Of("Got null factory method when resolving {0}");
		RegisteredDisposableTransientWontBeDisposedByContainer = Of("Registered Disposable Transient service {0} with key {1} registered as {2} won't be disposed by container. DryIoc does not hold reference to resolved transients, and therefore does not control their dispose. To silence this exception Register<YourService>(setup: Setup.With(allowDisposableTransient: true))  or set the rule Container(rules => rules.WithoutThrowOnRegisteringDisposableTransient()). To enable tracking use Register<YourService>(setup: Setup.With(trackDisposableTransient: true))  or set the rule Container(rules => rules.WithTrackingDisposableTransients())");
		NotFoundMetaCtorWithTwoArgs = Of("Expecting Meta wrapper public constructor with two arguments {0} but not found when resolving: {1}");
		UnableToSelectFromManyRegistrationsWithMatchingMetadata = Of("Unable to select from multiple registrations matching the Metadata type {0}:" + "\n" + "{1}" + "\n" + "When resolving: {2}");
		ImplTypeIsNotSpecifiedForAutoCtorSelection = Of("Implementation type is not specified when using automatic constructor selection: {0}");
		NoImplementationForPlaceholder = Of("There is no real implementation, only a placeholder for the service {0}." + "\n" + "Please Register the implementation with the ifAlreadyRegistered.Replace parameter to fill the placeholder.");
		InjectedIntoFactoryDummy = Of("This is not a real factory but a dummy for the instance where properties and fields are injected into");
		DecoratorShouldNotBeRegisteredWithServiceKey = Of("Registering Decorator {0} with service key {1} is not supported," + "\n" + "because instead of decorator with the key you actually want a decorator for service registered with the key." + "\n" + "To apply decorator for service with the key, please use `Setup.DecoratorOf(decorateeServiceKey: \"a service key\")`");
		PassedCtorOrMemberIsNull = Of("The constructor of member info passed to `Made.Of` or `FactoryMethod.Of` is null");
		PassedMemberIsNotStaticButInstanceFactoryIsNull = Of("The member info {0} passed to `Made.Of` or `FactoryMethod.Of` is NOT static, but instance factory is not provided or null");
		PassedMemberIsStaticButInstanceFactoryIsNotNull = Of("You are passing constructor or STATIC member info {0} to `Made.Of` or `FactoryMethod.Of`, but then why are you passing factory INSTANCE: {1}");
		MadeOfCallExpressionParameterDoesNotCorrespondToTheFactoryInfo = Of("Made.Of factory method uses parameter expression `{0}` which is not corresponding to the factory info for that parameter: {1}");
		UndefinedMethodWhenGettingTheSingleMethod = Of("Undefined Method '{0}' in Type {1} (including non-public={2})");
		UndefinedMethodWhenGettingMethodWithSpecifiedParameters = Of("Undefined Method '{0}' in Type {1} with parameters {2}.");
		UndefinedPropertyWhenGettingProperty = Of("Undefined property {0} in type {1}");
		UndefinedFieldWhenGettingField = Of("Undefined field {0} in type {1}");
		UnableToFindConstructorWithArgs = Of("Unable to find a constructor in Type {0} with args: {1}");
		UnableToFindSingleConstructor = Of("Unable to find a single constructor in Type {0} (including non-public={1})");
		DisposerTrackForDisposeError = Of("Something is {0} already.");
		NoServicesWereRegisteredByRegisterMany = Of("No service types were discovered in `RegisterMany` (or in `RegisterInstanceMany`) for the specified implementation types: " + "\n" + "[{0}]" + "\n" + "Maybe you missed the implementation or service type(s), e.g. provided only abstract or compiler-generated implementation types, or specified a wrong `serviceTypeCondition`,or did not specify to use `nonPublicServiceTypes`, etc.");
		FoundNoRootsToValidate = Of("No roots to Validate found. Check the `condition` passed to Validate method for container: {0}" + "\n" + "You may also examine all container registrations via `container.container.GetServiceRegistrations()` method.");
		NoServiceTypesToValidate = Of("The `serviceTypes` passed to Validate method is null or empty. Please pass the type(s) you want to Validate.");
		ValidateFoundErrors = Of("Validate method found the errors, please check the ContainerException.CollectedExceptions for the details." + "\n" + "If you see too many (unexpected) errors, try narrowing the resolution roots by passing the selected service types or the condition to the Validate(AndThrow) method." + "\n" + "Or alternatively, mark the service registrations with `setup: Setup.With(asResolutionRoot: true)`.");
		UnableToInterpretTheNestedLambda = Of("Unable to interpret the nested lambda with Body:" + "\n" + "{0}");
		WaitForScopedServiceIsCreatedTimeoutExpired = Of("DryIoc has waited for the creation of the scoped or singleton service by the \"other party\" for the {0} time ticks without the completion. " + "\n" + "You may call `exception.TryGetDetails(container)` to get the details of the problematic service registration." + "\n" + "The error means that either the \"other party\" is the parallel thread which has started but is unable to finish the creation of the service in the provided amount of time. " + "\n" + "Or more likely the \"other party\"  is the same thread and there is an undetected recursive dependency or " + "\n" + "the scoped service creation is failed with the exception and the exception was catched but you are trying to resolve the failed service again. " + "\n" + "For all those reasons DryIoc has a timeout to prevent the infinite waiting. " + "\n" + "You may change the default timeout via `Scope.WaitForScopedServiceIsCreatedTimeoutTicks=NewNumberOfTicks`");
		ServiceTypeIsNull = Of("Registered service type is null");
		Throw.GetMatchedException = ContainerException.Of;
	}
}
