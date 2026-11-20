package androidx.appcompat.app;

import android.content.DialogInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class AlertDialog_IDialogInterfaceOnCancelListenerImplementor implements IGCUserPeer, DialogInterface.OnCancelListener {
    private ArrayList refList;

    private native void n_onCancel(DialogInterface dialogInterface);

    public AlertDialog_IDialogInterfaceOnCancelListenerImplementor() {
        if (getClass() == AlertDialog_IDialogInterfaceOnCancelListenerImplementor.class) {
            TypeManager.Activate("AndroidX.AppCompat.App.AlertDialog+IDialogInterfaceOnCancelListenerImplementor, Xamarin.AndroidX.AppCompat", "", this, new Object[0]);
        }
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
