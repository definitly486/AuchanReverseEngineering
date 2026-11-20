package mono.android.content;

import android.content.DialogInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DialogInterface_OnClickListenerImplementor implements IGCUserPeer, DialogInterface.OnClickListener {
    private ArrayList refList;

    private native void n_onClick(DialogInterface dialogInterface, int i);

    public DialogInterface_OnClickListenerImplementor() {
        if (getClass() == DialogInterface_OnClickListenerImplementor.class) {
            TypeManager.Activate("Android.Content.IDialogInterfaceOnClickListenerImplementor, Mono.Android", "", this, new Object[0]);
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
