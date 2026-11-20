package androidx.appcompat.app;

import android.content.DialogInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class AlertDialog_IDialogInterfaceOnClickListenerImplementor implements IGCUserPeer, DialogInterface.OnClickListener {
    private ArrayList refList;

    private native void n_onClick(DialogInterface dialogInterface, int i);

    public AlertDialog_IDialogInterfaceOnClickListenerImplementor() {
        if (getClass() == AlertDialog_IDialogInterfaceOnClickListenerImplementor.class) {
            TypeManager.Activate("AndroidX.AppCompat.App.AlertDialog+IDialogInterfaceOnClickListenerImplementor, Xamarin.AndroidX.AppCompat", "", this, new Object[0]);
        }
    }

    @Override // android.content.DialogInterface.OnClickListener
    public void onClick(DialogInterface dialogInterface, int i) {
        n_onClick(dialogInterface, i);
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
