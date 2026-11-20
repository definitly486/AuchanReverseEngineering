package crc64f03248cb510113f2;

import androidx.lifecycle.Lifecycle;
import androidx.lifecycle.LifecycleObserver;
import androidx.lifecycle.LifecycleOwner;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LifecycleEventObserver implements IGCUserPeer, androidx.lifecycle.LifecycleEventObserver, LifecycleObserver {
    private ArrayList refList;

    private native void n_onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event);

    public LifecycleEventObserver() {
        if (getClass() == LifecycleEventObserver.class) {
            TypeManager.Activate("Auchan.Android.Base.LifecycleEventObserver, Auchan.Android.Net", "", this, new Object[0]);
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
