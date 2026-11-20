package crc646064278e9258e0c4;

import android.view.ViewTreeObserver;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnGlobalLayoutListener implements IGCUserPeer, ViewTreeObserver.OnGlobalLayoutListener {
    private ArrayList refList;

    private native void n_onGlobalLayout();

    public OnGlobalLayoutListener() {
        if (getClass() == OnGlobalLayoutListener.class) {
            TypeManager.Activate("Auchan.Android.Common.OnGlobalLayoutListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.view.ViewTreeObserver.OnGlobalLayoutListener
    public void onGlobalLayout() {
        n_onGlobalLayout();
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
