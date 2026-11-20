package androidx.appcompat.app;

import android.content.DialogInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class AlertDialog_IDialogInterfaceOnMultiChoiceClickListenerImplementor implements IGCUserPeer, DialogInterface.OnMultiChoiceClickListener {
    private ArrayList refList;

    private native void n_onClick(DialogInterface dialogInterface, int i, boolean z);

    public AlertDialog_IDialogInterfaceOnMultiChoiceClickListenerImplementor() {
        if (getClass() == AlertDialog_IDialogInterfaceOnMultiChoiceClickListenerImplementor.class) {
            TypeManager.Activate("AndroidX.AppCompat.App.AlertDialog+IDialogInterfaceOnMultiChoiceClickListenerImplementor, Xamarin.AndroidX.AppCompat", "", this, new Object[0]);
        }
    }

    @Override // android.content.DialogInterface.OnMultiChoiceClickListener
    public void onClick(DialogInterface dialogInterface, int i, boolean z) {
        n_onClick(dialogInterface, i, z);
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
