package crc6459efab142bb48047;

import android.view.KeyEvent;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewOnKeyListener implements IGCUserPeer, View.OnKeyListener {
    private ArrayList refList;

    private native boolean n_onKey(View view, int i, KeyEvent keyEvent);

    public ViewOnKeyListener() {
        if (getClass() == ViewOnKeyListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.ViewOnKeyListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.view.View.OnKeyListener
    public boolean onKey(View view, int i, KeyEvent keyEvent) {
        return n_onKey(view, i, keyEvent);
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
