package crc646064278e9258e0c4;

import android.text.style.ClickableSpan;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ClickableActionSpan extends ClickableSpan implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onClick(View view);

    public ClickableActionSpan() {
        if (getClass() == ClickableActionSpan.class) {
            TypeManager.Activate("Auchan.Android.Common.ClickableActionSpan, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.text.style.ClickableSpan
    public void onClick(View view) {
        n_onClick(view);
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
