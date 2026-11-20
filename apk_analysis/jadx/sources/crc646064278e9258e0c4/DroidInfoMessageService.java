package crc646064278e9258e0c4;

import android.content.DialogInterface;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DroidInfoMessageService implements IGCUserPeer, DialogInterface.OnShowListener {
    private ArrayList refList;

    private native void n_onShow(DialogInterface dialogInterface);

    public DroidInfoMessageService() {
        if (getClass() == DroidInfoMessageService.class) {
            TypeManager.Activate("Auchan.Android.Common.DroidInfoMessageService, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.content.DialogInterface.OnShowListener
    public void onShow(DialogInterface dialogInterface) {
        n_onShow(dialogInterface);
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
