package crc646064278e9258e0c4;

import androidx.lifecycle.DefaultLifecycleObserver;
import androidx.lifecycle.LifecycleObserver;
import androidx.lifecycle.LifecycleOwner;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ProcessLifecycleObserver implements IGCUserPeer, DefaultLifecycleObserver, LifecycleObserver {
    private ArrayList refList;

    private native void n_onCreate(LifecycleOwner lifecycleOwner);

    private native void n_onDestroy(LifecycleOwner lifecycleOwner);

    private native void n_onPause(LifecycleOwner lifecycleOwner);

    private native void n_onResume(LifecycleOwner lifecycleOwner);

    private native void n_onStart(LifecycleOwner lifecycleOwner);

    private native void n_onStop(LifecycleOwner lifecycleOwner);

    public ProcessLifecycleObserver() {
        if (getClass() == ProcessLifecycleObserver.class) {
            TypeManager.Activate("Auchan.Android.Common.ProcessLifecycleObserver, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.lifecycle.DefaultLifecycleObserver
    public void onCreate(LifecycleOwner lifecycleOwner) {
        n_onCreate(lifecycleOwner);
    }

    @Override // androidx.lifecycle.DefaultLifecycleObserver
    public void onDestroy(LifecycleOwner lifecycleOwner) {
        n_onDestroy(lifecycleOwner);
    }

    @Override // androidx.lifecycle.DefaultLifecycleObserver
    public void onPause(LifecycleOwner lifecycleOwner) {
        n_onPause(lifecycleOwner);
    }

    @Override // androidx.lifecycle.DefaultLifecycleObserver
    public void onResume(LifecycleOwner lifecycleOwner) {
        n_onResume(lifecycleOwner);
    }

    @Override // androidx.lifecycle.DefaultLifecycleObserver
    public void onStart(LifecycleOwner lifecycleOwner) {
        n_onStart(lifecycleOwner);
    }

    @Override // androidx.lifecycle.DefaultLifecycleObserver
    public void onStop(LifecycleOwner lifecycleOwner) {
        n_onStop(lifecycleOwner);
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
