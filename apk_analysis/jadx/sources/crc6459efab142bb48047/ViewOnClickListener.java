package crc6459efab142bb48047;

import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewOnClickListener implements IGCUserPeer, View.OnClickListener {
    private ArrayList refList;

    private native void n_onClick(View view);

    public ViewOnClickListener() {
        if (getClass() == ViewOnClickListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.ViewOnClickListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.view.View.OnClickListener
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
