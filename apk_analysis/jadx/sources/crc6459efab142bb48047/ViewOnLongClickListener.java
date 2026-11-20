package crc6459efab142bb48047;

import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewOnLongClickListener implements IGCUserPeer, View.OnLongClickListener {
    private ArrayList refList;

    private native boolean n_onLongClick(View view);

    private native boolean n_onLongClickUseDefaultHapticFeedback(View view);

    public ViewOnLongClickListener() {
        if (getClass() == ViewOnLongClickListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.ViewOnLongClickListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.view.View.OnLongClickListener
    public boolean onLongClick(View view) {
        return n_onLongClick(view);
    }

    @Override // android.view.View.OnLongClickListener
    public boolean onLongClickUseDefaultHapticFeedback(View view) {
        return n_onLongClickUseDefaultHapticFeedback(view);
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
