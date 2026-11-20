package mono.androidx.core.os;

import androidx.core.os.CancellationSignal;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class CancellationSignal_OnCancelListenerImplementor implements IGCUserPeer, CancellationSignal.OnCancelListener {
    private ArrayList refList;

    private native void n_onCancel();

    public CancellationSignal_OnCancelListenerImplementor() {
        if (getClass() == CancellationSignal_OnCancelListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Core.OS.CancellationSignal+IOnCancelListenerImplementor, Xamarin.AndroidX.Core", "", this, new Object[0]);
        }
    }

    @Override // androidx.core.os.CancellationSignal.OnCancelListener
    public void onCancel() {
        n_onCancel();
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
