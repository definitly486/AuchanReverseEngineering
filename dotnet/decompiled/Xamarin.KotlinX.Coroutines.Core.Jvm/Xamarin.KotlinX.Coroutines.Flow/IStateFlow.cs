using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Xamarin.KotlinX.Coroutines.Flow;

[Register("kotlinx/coroutines/flow/StateFlow", "", "Xamarin.KotlinX.Coroutines.Flow.IStateFlowInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IStateFlow : ISharedFlow, IFlow, IJavaObject, IDisposable, IJavaPeerable
{
	Java.Lang.Object? Value
	{
		[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler:Xamarin.KotlinX.Coroutines.Flow.IStateFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		get;
	}
}
