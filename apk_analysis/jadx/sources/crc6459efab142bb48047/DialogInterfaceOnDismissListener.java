package crc6459efab142bb48047;

import android.content.DialogInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DialogInterfaceOnDismissListener implements IGCUserPeer, DialogInterface.OnDismissListener, DialogInterface.OnCancelListener {
    private ArrayList refList;

    private native void n_onCancel(DialogInterface dialogInterface);

    private native void n_onDismiss(DialogInterface dialogInterface);

    public DialogInterfaceOnDismissListener() {
        if (getClass() == DialogInterfaceOnDismissListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.DialogInterfaceOnDismissListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.content.DialogInterface.OnDismissListener
    public void onDismiss(DialogInterface dialogInterface) {
        n_onDismiss(dialogInterface);
    }

    @Override // android.content.DialogInterface.OnCancelListener
    public void onCancel(DialogInterface dialogInterface) {
        n_onCancel(dialogInterface);
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
