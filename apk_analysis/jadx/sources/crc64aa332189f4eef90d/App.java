package crc64aa332189f4eef90d;

import android.support.multidex.MultiDexApplication;
import java.util.ArrayList;
import mono.MonoPackageManager;
import mono.android.IGCUserPeer;

/* JADX INFO: loaded from: classes3.dex */
public class App extends MultiDexApplication implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate();

    private native void n_onTrimMemory(int i);

    public App() {
        MonoPackageManager.setContext(this);
    }

    @Override // android.app.Application
    public void onCreate() {
        n_onCreate();
    }

    @Override // android.app.Application, android.content.ComponentCallbacks2
    public void onTrimMemory(int i) {
        n_onTrimMemory(i);
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
