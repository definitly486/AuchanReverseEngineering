using System;
using Android.Database;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Widget;

[Register("android/widget/FilterQueryProvider", "", "Android.Widget.IFilterQueryProviderInvoker")]
public interface IFilterQueryProvider : IJavaObject, IDisposable, IJavaPeerable
{
	ICursor? RunQuery(ICharSequence? constraint);
}
