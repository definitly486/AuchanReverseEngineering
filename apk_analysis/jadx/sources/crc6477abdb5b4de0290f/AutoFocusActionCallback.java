package crc6477abdb5b4de0290f;

import android.hardware.Camera;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AutoFocusActionCallback implements IGCUserPeer, Camera.AutoFocusCallback {
    private ArrayList refList;

    private native void n_onAutoFocus(boolean z, Camera camera);

    public AutoFocusActionCallback() {
        if (getClass() == AutoFocusActionCallback.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.AutoFocusActionCallback, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.hardware.Camera.AutoFocusCallback
    public void onAutoFocus(boolean z, Camera camera) {
        n_onAutoFocus(z, camera);
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
