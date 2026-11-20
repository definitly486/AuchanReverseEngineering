package crc64f03248cb510113f2;

import androidx.lifecycle.ViewModel;
import java.io.Closeable;
import java.util.ArrayList;
import kotlinx.coroutines.CoroutineScope;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RetainerViewModel extends ViewModel implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCleared();

    public RetainerViewModel() {
        if (getClass() == RetainerViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.RetainerViewModel, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public RetainerViewModel(Closeable[] closeableArr) {
        super((AutoCloseable[]) closeableArr);
        if (getClass() == RetainerViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.RetainerViewModel, Auchan.Android.Net", "Java.IO.ICloseable[], Mono.Android", this, new Object[]{closeableArr});
        }
    }

    public RetainerViewModel(AutoCloseable[] autoCloseableArr) {
        super(autoCloseableArr);
        if (getClass() == RetainerViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.RetainerViewModel, Auchan.Android.Net", "Java.Lang.IAutoCloseable[], Mono.Android", this, new Object[]{autoCloseableArr});
        }
    }

    public RetainerViewModel(CoroutineScope coroutineScope) {
        super(coroutineScope);
        if (getClass() == RetainerViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.RetainerViewModel, Auchan.Android.Net", "Xamarin.KotlinX.Coroutines.ICoroutineScope, Xamarin.KotlinX.Coroutines.Core.Jvm", this, new Object[]{coroutineScope});
        }
    }

    public RetainerViewModel(CoroutineScope coroutineScope, AutoCloseable[] autoCloseableArr) {
        super(coroutineScope, autoCloseableArr);
        if (getClass() == RetainerViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.RetainerViewModel, Auchan.Android.Net", "Xamarin.KotlinX.Coroutines.ICoroutineScope, Xamarin.KotlinX.Coroutines.Core.Jvm:Java.Lang.IAutoCloseable[], Mono.Android", this, new Object[]{coroutineScope, autoCloseableArr});
        }
    }

    @Override // androidx.lifecycle.ViewModel
    public void onCleared() {
        n_onCleared();
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
