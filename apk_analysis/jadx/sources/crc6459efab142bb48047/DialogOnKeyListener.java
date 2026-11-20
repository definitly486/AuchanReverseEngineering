package crc6459efab142bb48047;

import android.content.DialogInterface;
import android.view.KeyEvent;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DialogOnKeyListener implements IGCUserPeer, DialogInterface.OnKeyListener {
    private ArrayList refList;

    private native boolean n_onKey(DialogInterface dialogInterface, int i, KeyEvent keyEvent);

    public DialogOnKeyListener() {
        if (getClass() == DialogOnKeyListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.DialogOnKeyListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.content.DialogInterface.OnKeyListener
    public boolean onKey(DialogInterface dialogInterface, int i, KeyEvent keyEvent) {
        return n_onKey(dialogInterface, i, keyEvent);
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
