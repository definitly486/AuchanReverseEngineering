package crc646064278e9258e0c4;

import androidx.lifecycle.Lifecycle;
import androidx.lifecycle.LifecycleEventObserver;
import androidx.lifecycle.LifecycleObserver;
import androidx.lifecycle.LifecycleOwner;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LifecycleCallback implements IGCUserPeer, LifecycleEventObserver, LifecycleObserver {
    private ArrayList refList;

    private native void n_onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event);

    public LifecycleCallback() {
        if (getClass() == LifecycleCallback.class) {
            TypeManager.Activate("Auchan.Android.Common.LifecycleCallback, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.lifecycle.LifecycleEventObserver
    public void onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event) {
        n_onStateChanged(lifecycleOwner, event);
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
