package crc646f9e2e79d266beb3;

import android.app.Service;
import android.content.Intent;
import android.os.IBinder;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class PleaseGenerateCorrectAndroidManifest extends Service implements IGCUserPeer {
    private ArrayList refList;

    private native IBinder n_onBind(Intent intent);

    public PleaseGenerateCorrectAndroidManifest() {
        if (getClass() == PleaseGenerateCorrectAndroidManifest.class) {
            TypeManager.Activate("Appmetrica.Android.PleaseGenerateCorrectAndroidManifest, Appmetrica.Android", "", this, new Object[0]);
        }
    }

    @Override // android.app.Service
    public IBinder onBind(Intent intent) {
        return n_onBind(intent);
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
