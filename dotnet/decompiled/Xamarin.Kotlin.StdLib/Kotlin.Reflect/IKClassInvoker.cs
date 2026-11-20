using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;

namespace Kotlin.Reflect;

[Register("kotlin/reflect/KClass", DoNotGenerateAcw = true)]
internal class IKClassInvoker : Java.Lang.Object, IKClass, IKAnnotatedElement, IJavaObject, IDisposable, IJavaPeerable, IKClassifier, IKDeclarationContainer
{
	private static readonly JniPeerMembers _members_kotlin_reflect_KAnnotatedElement = new XAPeerMembers("kotlin/reflect/KAnnotatedElement", typeof(IKClassInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KClass = new XAPeerMembers("kotlin/reflect/KClass", typeof(IKClassInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KClassifier = new XAPeerMembers("kotlin/reflect/KClassifier", typeof(IKClassInvoker));

	private static readonly JniPeerMembers _members_kotlin_reflect_KDeclarationContainer = new XAPeerMembers("kotlin/reflect/KDeclarationContainer", typeof(IKClassInvoker));

	private static Delegate? cb_getConstructors_GetConstructors_Ljava_util_Collection_;

	private static Delegate? cb_isAbstract_IsAbstract_Z;

	private static Delegate? cb_isCompanion_IsCompanion_Z;

	private static Delegate? cb_isData_IsData_Z;

	private static Delegate? cb_isFinal_IsFinal_Z;

	private static Delegate? cb_isFun_IsFun_Z;

	private static Delegate? cb_isInner_IsInner_Z;

	private static Delegate? cb_isOpen_IsOpen_Z;

	private static Delegate? cb_isSealed_IsSealed_Z;

	private static Delegate? cb_isValue_IsValue_Z;

	private static Delegate? cb_getMembers_GetMembers_Ljava_util_Collection_;

	private static Delegate? cb_getNestedClasses_GetNestedClasses_Ljava_util_Collection_;

	private static Delegate? cb_getObjectInstance_GetObjectInstance_Ljava_lang_Object_;

	private static Delegate? cb_getQualifiedName_GetQualifiedName_Ljava_lang_String_;

	private static Delegate? cb_getSealedSubclasses_GetSealedSubclasses_Ljava_util_List_;

	private static Delegate? cb_getSimpleName_GetSimpleName_Ljava_lang_String_;

	private static Delegate? cb_getSupertypes_GetSupertypes_Ljava_util_List_;

	private static Delegate? cb_getTypeParameters_GetTypeParameters_Ljava_util_List_;

	private static Delegate? cb_getVisibility_GetVisibility_Lkotlin_reflect_KVisibility_;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_isInstance_IsInstance_Ljava_lang_Object__Z;

	private static Delegate? cb_getAnnotations_GetAnnotations_Ljava_util_List_;

	private static nint java_class_ref => _members_kotlin_reflect_KClass.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_kotlin_reflect_KClass;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_kotlin_reflect_KClass.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_kotlin_reflect_KClass.ManagedPeerType;

	public unsafe ICollection<IKFunction> Constructors => JavaCollection<IKFunction>.FromJniHandle(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getConstructors.()Ljava/util/Collection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsAbstract => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isAbstract.()Z", this, null);

	public unsafe bool IsCompanion => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isCompanion.()Z", this, null);

	public unsafe bool IsData => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isData.()Z", this, null);

	public unsafe bool IsFinal => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isFinal.()Z", this, null);

	public unsafe bool IsFun => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isFun.()Z", this, null);

	public unsafe bool IsInner => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isInner.()Z", this, null);

	public unsafe bool IsOpen => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isOpen.()Z", this, null);

	public unsafe bool IsSealed => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isSealed.()Z", this, null);

	public unsafe bool IsValue => _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isValue.()Z", this, null);

	public unsafe ICollection<IKCallable> Members => JavaCollection<IKCallable>.FromJniHandle(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getMembers.()Ljava/util/Collection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe ICollection<IKClass> NestedClasses => JavaCollection<IKClass>.FromJniHandle(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getNestedClasses.()Ljava/util/Collection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Java.Lang.Object? ObjectInstance => Java.Lang.Object.GetObject<Java.Lang.Object>(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getObjectInstance.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? QualifiedName => JNIEnv.GetString(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getQualifiedName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IKClass> SealedSubclasses => JavaList<IKClass>.FromJniHandle(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getSealedSubclasses.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? SimpleName => JNIEnv.GetString(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getSimpleName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IKType> Supertypes => JavaList<IKType>.FromJniHandle(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getSupertypes.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IKTypeParameter> TypeParameters => JavaList<IKTypeParameter>.FromJniHandle(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getTypeParameters.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe KVisibility? Visibility => Java.Lang.Object.GetObject<KVisibility>(_members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractObjectMethod("getVisibility.()Lkotlin/reflect/KVisibility;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IList<IAnnotation> Annotations => JavaList<IAnnotation>.FromJniHandle(_members_kotlin_reflect_KAnnotatedElement.InstanceMethods.InvokeAbstractObjectMethod("getAnnotations.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKClassInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetConstructorsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetConstructors);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetConstructors(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaCollection<IKFunction>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Constructors);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsAbstractHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsAbstract);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsAbstract(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAbstract ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsCompanionHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsCompanion);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCompanion(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCompanion ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsDataHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsData);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsData(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsData ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsFinalHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFinal);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFinal(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFinal ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsFunHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsFun);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFun(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFun ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsInnerHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsInner);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInner(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInner ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsOpenHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOpen);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOpen(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsSealedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsSealed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsSealed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSealed ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsValueHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValue ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetMembersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetMembers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMembers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaCollection<IKCallable>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Members);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetNestedClassesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetNestedClasses);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetNestedClasses(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaCollection<IKClass>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NestedClasses);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetObjectInstanceHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetObjectInstance);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetObjectInstance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ObjectInstance);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetQualifiedNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetQualifiedName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetQualifiedName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).QualifiedName);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetSealedSubclassesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSealedSubclasses);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSealedSubclasses(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IKClass>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SealedSubclasses);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetSimpleNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSimpleName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSimpleName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SimpleName);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetSupertypesHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupertypes);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupertypes(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IKType>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Supertypes);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTypeParametersHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTypeParameters);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTypeParameters(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IKTypeParameter>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TypeParameters);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetVisibilityHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetVisibility);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetVisibility(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetEquals_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_Equals_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_other)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKClass? iKClass = Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object other = Java.Lang.Object.GetObject<Java.Lang.Object>(native_other, JniHandleOwnership.DoNotTransfer);
			return iKClass.Equals(other) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public new unsafe bool Equals(Java.Lang.Object? other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			return _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	private static Delegate GetGetHashCodeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHashCode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHashCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public new unsafe int GetHashCode()
	{
		return _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractInt32Method("hashCode.()I", this, null);
	}

	private static Delegate GetIsInstance_Ljava_lang_Object_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_IsInstance_Ljava_lang_Object_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsInstance_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IKClass? iKClass = Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return iKClass.IsInstance(value) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe bool IsInstance(Java.Lang.Object? value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return _members_kotlin_reflect_KClass.InstanceMethods.InvokeAbstractBooleanMethod("isInstance.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetGetAnnotationsHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAnnotations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAnnotations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JavaList<IAnnotation>.ToLocalJniHandle(Java.Lang.Object.GetObject<IKClass>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Annotations);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
