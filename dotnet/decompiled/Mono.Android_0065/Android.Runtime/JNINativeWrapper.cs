using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Java.Interop;

namespace Android.Runtime;

public static class JNINativeWrapper
{
	private static MethodInfo? exception_handler_method;

	private static MethodInfo? wait_for_bridge_processing_method;

	private static void get_runtime_types()
	{
		if (!(exception_handler_method != null))
		{
			exception_handler_method = typeof(AndroidEnvironment).GetMethod("UnhandledException", BindingFlags.Static | BindingFlags.NonPublic);
			if (exception_handler_method == null)
			{
				AndroidEnvironment.FailFast("Cannot find AndroidEnvironment.UnhandledException");
			}
			wait_for_bridge_processing_method = typeof(AndroidRuntimeInternal).GetMethod("WaitForBridgeProcessing", BindingFlags.Static | BindingFlags.Public);
			if (wait_for_bridge_processing_method == null)
			{
				AndroidEnvironment.FailFast("Cannot find AndroidRuntimeInternal.WaitForBridgeProcessing");
			}
		}
	}

	public static Delegate CreateDelegate(Delegate dlg)
	{
		if ((object)dlg == null)
		{
			throw new ArgumentNullException();
		}
		if (dlg.Target != null)
		{
			throw new ArgumentException();
		}
		if (dlg.Method == null)
		{
			throw new ArgumentException();
		}
		Type type = dlg.GetType();
		Delegate obj = CreateBuiltInDelegate(dlg, type);
		if ((object)obj != null)
		{
			return obj;
		}
		if (Logger.LogAssembly)
		{
			RuntimeNativeMethods.monodroid_log(LogLevel.Debug, LogCategories.Assembly, $"Falling back to System.Reflection.Emit for delegate type '{type}': {dlg.Method}");
		}
		get_runtime_types();
		Type returnType = dlg.Method.ReturnType;
		ParameterInfo[] parameters = dlg.Method.GetParameters();
		Type[] array = new Type[parameters.Length];
		for (int i = 0; i < parameters.Length; i++)
		{
			array[i] = parameters[i].ParameterType;
		}
		DynamicMethod dynamicMethod = new DynamicMethod(DynamicMethodNameCounter.GetUniqueName(), returnType, array, typeof(DynamicMethodNameCounter), skipVisibility: true);
		ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
		LocalBuilder localBuilder = null;
		if (returnType != typeof(void))
		{
			localBuilder = iLGenerator.DeclareLocal(returnType);
		}
		iLGenerator.Emit(OpCodes.Call, wait_for_bridge_processing_method);
		Label label = iLGenerator.BeginExceptionBlock();
		for (int j = 0; j < array.Length; j++)
		{
			iLGenerator.Emit(OpCodes.Ldarg, j);
		}
		iLGenerator.Emit(OpCodes.Call, dlg.Method);
		if (localBuilder != null)
		{
			iLGenerator.Emit(OpCodes.Stloc, localBuilder);
		}
		iLGenerator.Emit(OpCodes.Leave, label);
		int num;
		if (!Debugger.IsAttached)
		{
			num = ((!JNIEnvInit.PropagateExceptions) ? 1 : 0);
			if (num == 0)
			{
				iLGenerator.BeginCatchBlock(typeof(Exception));
				goto IL_01da;
			}
		}
		else
		{
			num = 1;
		}
		iLGenerator.BeginExceptFilterBlock();
		iLGenerator.Emit(OpCodes.Call, AndroidRuntimeInternal.mono_unhandled_exception.Method);
		iLGenerator.Emit(OpCodes.Ldc_I4_1);
		iLGenerator.BeginCatchBlock(null);
		goto IL_01da;
		IL_01da:
		iLGenerator.Emit(OpCodes.Dup);
		iLGenerator.Emit(OpCodes.Call, exception_handler_method);
		if (num != 0)
		{
			iLGenerator.Emit(OpCodes.Throw);
		}
		iLGenerator.EndExceptionBlock();
		if (localBuilder != null)
		{
			iLGenerator.Emit(OpCodes.Ldloc, localBuilder);
		}
		iLGenerator.Emit(OpCodes.Ret);
		return dynamicMethod.CreateDelegate(dlg.GetType());
	}

	private static bool _unhandled_exception(Exception e)
	{
		if (Debugger.IsAttached || !JNIEnvInit.PropagateExceptions)
		{
			AndroidRuntimeInternal.mono_unhandled_exception?.Invoke(e);
			return false;
		}
		return true;
	}

	internal static void Wrap_JniMarshal_PP_V(this _JniMarshal_PP_V callback, nint jnienv, nint klazz)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static int Wrap_JniMarshal_PP_I(this _JniMarshal_PP_I callback, nint jnienv, nint klazz)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static bool Wrap_JniMarshal_PP_Z(this _JniMarshal_PP_Z callback, nint jnienv, nint klazz)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPI_V(this _JniMarshal_PPI_V callback, nint jnienv, nint klazz, int p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static nint Wrap_JniMarshal_PPI_L(this _JniMarshal_PPI_L callback, nint jnienv, nint klazz, int p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static int Wrap_JniMarshal_PPI_I(this _JniMarshal_PPI_I callback, nint jnienv, nint klazz, int p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static long Wrap_JniMarshal_PPI_J(this _JniMarshal_PPI_J callback, nint jnienv, nint klazz, int p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0L;
		}
	}

	internal static int Wrap_JniMarshal_PPL_I(this _JniMarshal_PPL_I callback, nint jnienv, nint klazz, nint p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static nint Wrap_JniMarshal_PPL_L(this _JniMarshal_PPL_L callback, nint jnienv, nint klazz, nint p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static void Wrap_JniMarshal_PPL_V(this _JniMarshal_PPL_V callback, nint jnienv, nint klazz, nint p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static bool Wrap_JniMarshal_PPL_Z(this _JniMarshal_PPL_Z callback, nint jnienv, nint klazz, nint p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static bool Wrap_JniMarshal_PPJ_Z(this _JniMarshal_PPJ_Z callback, nint jnienv, nint klazz, long p0)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPII_V(this _JniMarshal_PPII_V callback, nint jnienv, nint klazz, int p0, int p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static nint Wrap_JniMarshal_PPII_L(this _JniMarshal_PPII_L callback, nint jnienv, nint klazz, int p0, int p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static void Wrap_JniMarshal_PPLI_V(this _JniMarshal_PPLI_V callback, nint jnienv, nint klazz, nint p0, int p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPLZ_V(this _JniMarshal_PPLZ_V callback, nint jnienv, nint klazz, nint p0, bool p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPLL_V(this _JniMarshal_PPLL_V callback, nint jnienv, nint klazz, nint p0, nint p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPLF_V(this _JniMarshal_PPLF_V callback, nint jnienv, nint klazz, nint p0, float p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static nint Wrap_JniMarshal_PPLI_L(this _JniMarshal_PPLI_L callback, nint jnienv, nint klazz, nint p0, int p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static nint Wrap_JniMarshal_PPLL_L(this _JniMarshal_PPLL_L callback, nint jnienv, nint klazz, nint p0, nint p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static bool Wrap_JniMarshal_PPLL_Z(this _JniMarshal_PPLL_Z callback, nint jnienv, nint klazz, nint p0, nint p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static bool Wrap_JniMarshal_PPIL_Z(this _JniMarshal_PPIL_Z callback, nint jnienv, nint klazz, int p0, nint p1)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPIIL_V(this _JniMarshal_PPIIL_V callback, nint jnienv, nint klazz, int p0, int p1, nint p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static int Wrap_JniMarshal_PPLII_I(this _JniMarshal_PPLII_I callback, nint jnienv, nint klazz, nint p0, int p1, int p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static bool Wrap_JniMarshal_PPLII_Z(this _JniMarshal_PPLII_Z callback, nint jnienv, nint klazz, nint p0, int p1, int p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPLII_V(this _JniMarshal_PPLII_V callback, nint jnienv, nint klazz, nint p0, int p1, int p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPIII_V(this _JniMarshal_PPIII_V callback, nint jnienv, nint klazz, int p0, int p1, int p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static bool Wrap_JniMarshal_PPLLJ_Z(this _JniMarshal_PPLLJ_Z callback, nint jnienv, nint klazz, nint p0, nint p1, long p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPILL_V(this _JniMarshal_PPILL_V callback, nint jnienv, nint klazz, int p0, nint p1, nint p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static bool Wrap_JniMarshal_PPLIL_Z(this _JniMarshal_PPLIL_Z callback, nint jnienv, nint klazz, nint p0, int p1, nint p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPLLL_V(this _JniMarshal_PPLLL_V callback, nint jnienv, nint klazz, nint p0, nint p1, nint p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static nint Wrap_JniMarshal_PPLLL_L(this _JniMarshal_PPLLL_L callback, nint jnienv, nint klazz, nint p0, nint p1, nint p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static bool Wrap_JniMarshal_PPLLL_Z(this _JniMarshal_PPLLL_Z callback, nint jnienv, nint klazz, nint p0, nint p1, nint p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static nint Wrap_JniMarshal_PPIZI_L(this _JniMarshal_PPIZI_L callback, nint jnienv, nint klazz, int p0, bool p1, int p2)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return 0;
		}
	}

	internal static void Wrap_JniMarshal_PPIIII_V(this _JniMarshal_PPIIII_V callback, nint jnienv, nint klazz, int p0, int p1, int p2, int p3)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2, p3);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPLLLL_V(this _JniMarshal_PPLLLL_V callback, nint jnienv, nint klazz, nint p0, nint p1, nint p2, nint p3)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2, p3);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static bool Wrap_JniMarshal_PPLZZL_Z(this _JniMarshal_PPLZZL_Z callback, nint jnienv, nint klazz, nint p0, bool p1, bool p2, nint p3)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			return callback(jnienv, klazz, p0, p1, p2, p3);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
			return false;
		}
	}

	internal static void Wrap_JniMarshal_PPLIIII_V(this _JniMarshal_PPLIIII_V callback, nint jnienv, nint klazz, nint p0, int p1, int p2, int p3, int p4)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2, p3, p4);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPZIIII_V(this _JniMarshal_PPZIIII_V callback, nint jnienv, nint klazz, bool p0, int p1, int p2, int p3, int p4)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2, p3, p4);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	internal static void Wrap_JniMarshal_PPLIIIIIIII_V(this _JniMarshal_PPLIIIIIIII_V callback, nint jnienv, nint klazz, nint p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8)
	{
		JniEnvironment.Runtime.ValueManager.WaitForGCBridgeProcessing();
		try
		{
			callback(jnienv, klazz, p0, p1, p2, p3, p4, p5, p6, p7, p8);
		}
		catch (Exception e) when (_unhandled_exception(e))
		{
			AndroidEnvironment.UnhandledException(e);
		}
	}

	private static Delegate CreateBuiltInDelegate(Delegate dlg, Type delegateType)
	{
		return delegateType.Name switch
		{
			"_JniMarshal_PP_V" => new _JniMarshal_PP_V(Unsafe.As<_JniMarshal_PP_V>(dlg).Wrap_JniMarshal_PP_V), 
			"_JniMarshal_PP_I" => new _JniMarshal_PP_I(Unsafe.As<_JniMarshal_PP_I>(dlg).Wrap_JniMarshal_PP_I), 
			"_JniMarshal_PP_Z" => new _JniMarshal_PP_Z(Unsafe.As<_JniMarshal_PP_Z>(dlg).Wrap_JniMarshal_PP_Z), 
			"_JniMarshal_PPI_V" => new _JniMarshal_PPI_V(Unsafe.As<_JniMarshal_PPI_V>(dlg).Wrap_JniMarshal_PPI_V), 
			"_JniMarshal_PPI_L" => new _JniMarshal_PPI_L(Unsafe.As<_JniMarshal_PPI_L>(dlg).Wrap_JniMarshal_PPI_L), 
			"_JniMarshal_PPI_I" => new _JniMarshal_PPI_I(Unsafe.As<_JniMarshal_PPI_I>(dlg).Wrap_JniMarshal_PPI_I), 
			"_JniMarshal_PPI_J" => new _JniMarshal_PPI_J(Unsafe.As<_JniMarshal_PPI_J>(dlg).Wrap_JniMarshal_PPI_J), 
			"_JniMarshal_PPL_I" => new _JniMarshal_PPL_I(Unsafe.As<_JniMarshal_PPL_I>(dlg).Wrap_JniMarshal_PPL_I), 
			"_JniMarshal_PPL_L" => new _JniMarshal_PPL_L(Unsafe.As<_JniMarshal_PPL_L>(dlg).Wrap_JniMarshal_PPL_L), 
			"_JniMarshal_PPL_V" => new _JniMarshal_PPL_V(Unsafe.As<_JniMarshal_PPL_V>(dlg).Wrap_JniMarshal_PPL_V), 
			"_JniMarshal_PPL_Z" => new _JniMarshal_PPL_Z(Unsafe.As<_JniMarshal_PPL_Z>(dlg).Wrap_JniMarshal_PPL_Z), 
			"_JniMarshal_PPJ_Z" => new _JniMarshal_PPJ_Z(Unsafe.As<_JniMarshal_PPJ_Z>(dlg).Wrap_JniMarshal_PPJ_Z), 
			"_JniMarshal_PPII_V" => new _JniMarshal_PPII_V(Unsafe.As<_JniMarshal_PPII_V>(dlg).Wrap_JniMarshal_PPII_V), 
			"_JniMarshal_PPII_L" => new _JniMarshal_PPII_L(Unsafe.As<_JniMarshal_PPII_L>(dlg).Wrap_JniMarshal_PPII_L), 
			"_JniMarshal_PPLI_V" => new _JniMarshal_PPLI_V(Unsafe.As<_JniMarshal_PPLI_V>(dlg).Wrap_JniMarshal_PPLI_V), 
			"_JniMarshal_PPLZ_V" => new _JniMarshal_PPLZ_V(Unsafe.As<_JniMarshal_PPLZ_V>(dlg).Wrap_JniMarshal_PPLZ_V), 
			"_JniMarshal_PPLL_V" => new _JniMarshal_PPLL_V(Unsafe.As<_JniMarshal_PPLL_V>(dlg).Wrap_JniMarshal_PPLL_V), 
			"_JniMarshal_PPLF_V" => new _JniMarshal_PPLF_V(Unsafe.As<_JniMarshal_PPLF_V>(dlg).Wrap_JniMarshal_PPLF_V), 
			"_JniMarshal_PPLI_L" => new _JniMarshal_PPLI_L(Unsafe.As<_JniMarshal_PPLI_L>(dlg).Wrap_JniMarshal_PPLI_L), 
			"_JniMarshal_PPLL_L" => new _JniMarshal_PPLL_L(Unsafe.As<_JniMarshal_PPLL_L>(dlg).Wrap_JniMarshal_PPLL_L), 
			"_JniMarshal_PPLL_Z" => new _JniMarshal_PPLL_Z(Unsafe.As<_JniMarshal_PPLL_Z>(dlg).Wrap_JniMarshal_PPLL_Z), 
			"_JniMarshal_PPIL_Z" => new _JniMarshal_PPIL_Z(Unsafe.As<_JniMarshal_PPIL_Z>(dlg).Wrap_JniMarshal_PPIL_Z), 
			"_JniMarshal_PPIIL_V" => new _JniMarshal_PPIIL_V(Unsafe.As<_JniMarshal_PPIIL_V>(dlg).Wrap_JniMarshal_PPIIL_V), 
			"_JniMarshal_PPLII_I" => new _JniMarshal_PPLII_I(Unsafe.As<_JniMarshal_PPLII_I>(dlg).Wrap_JniMarshal_PPLII_I), 
			"_JniMarshal_PPLII_Z" => new _JniMarshal_PPLII_Z(Unsafe.As<_JniMarshal_PPLII_Z>(dlg).Wrap_JniMarshal_PPLII_Z), 
			"_JniMarshal_PPLII_V" => new _JniMarshal_PPLII_V(Unsafe.As<_JniMarshal_PPLII_V>(dlg).Wrap_JniMarshal_PPLII_V), 
			"_JniMarshal_PPIII_V" => new _JniMarshal_PPIII_V(Unsafe.As<_JniMarshal_PPIII_V>(dlg).Wrap_JniMarshal_PPIII_V), 
			"_JniMarshal_PPLLJ_Z" => new _JniMarshal_PPLLJ_Z(Unsafe.As<_JniMarshal_PPLLJ_Z>(dlg).Wrap_JniMarshal_PPLLJ_Z), 
			"_JniMarshal_PPILL_V" => new _JniMarshal_PPILL_V(Unsafe.As<_JniMarshal_PPILL_V>(dlg).Wrap_JniMarshal_PPILL_V), 
			"_JniMarshal_PPLIL_Z" => new _JniMarshal_PPLIL_Z(Unsafe.As<_JniMarshal_PPLIL_Z>(dlg).Wrap_JniMarshal_PPLIL_Z), 
			"_JniMarshal_PPLLL_V" => new _JniMarshal_PPLLL_V(Unsafe.As<_JniMarshal_PPLLL_V>(dlg).Wrap_JniMarshal_PPLLL_V), 
			"_JniMarshal_PPLLL_L" => new _JniMarshal_PPLLL_L(Unsafe.As<_JniMarshal_PPLLL_L>(dlg).Wrap_JniMarshal_PPLLL_L), 
			"_JniMarshal_PPLLL_Z" => new _JniMarshal_PPLLL_Z(Unsafe.As<_JniMarshal_PPLLL_Z>(dlg).Wrap_JniMarshal_PPLLL_Z), 
			"_JniMarshal_PPIZI_L" => new _JniMarshal_PPIZI_L(Unsafe.As<_JniMarshal_PPIZI_L>(dlg).Wrap_JniMarshal_PPIZI_L), 
			"_JniMarshal_PPIIII_V" => new _JniMarshal_PPIIII_V(Unsafe.As<_JniMarshal_PPIIII_V>(dlg).Wrap_JniMarshal_PPIIII_V), 
			"_JniMarshal_PPLLLL_V" => new _JniMarshal_PPLLLL_V(Unsafe.As<_JniMarshal_PPLLLL_V>(dlg).Wrap_JniMarshal_PPLLLL_V), 
			"_JniMarshal_PPLZZL_Z" => new _JniMarshal_PPLZZL_Z(Unsafe.As<_JniMarshal_PPLZZL_Z>(dlg).Wrap_JniMarshal_PPLZZL_Z), 
			"_JniMarshal_PPLIIII_V" => new _JniMarshal_PPLIIII_V(Unsafe.As<_JniMarshal_PPLIIII_V>(dlg).Wrap_JniMarshal_PPLIIII_V), 
			"_JniMarshal_PPZIIII_V" => new _JniMarshal_PPZIIII_V(Unsafe.As<_JniMarshal_PPZIIII_V>(dlg).Wrap_JniMarshal_PPZIIII_V), 
			"_JniMarshal_PPLIIIIIIII_V" => new _JniMarshal_PPLIIIIIIII_V(Unsafe.As<_JniMarshal_PPLIIIIIIII_V>(dlg).Wrap_JniMarshal_PPLIIIIIIII_V), 
			_ => null, 
		};
	}
}
