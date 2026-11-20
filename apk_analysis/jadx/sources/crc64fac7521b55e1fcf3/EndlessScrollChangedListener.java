package crc64fac7521b55e1fcf3;

import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class EndlessScrollChangedListener extends RecyclerView.OnScrollListener implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onScrolled(RecyclerView recyclerView, int i, int i2);

    public EndlessScrollChangedListener() {
        if (getClass() == EndlessScrollChangedListener.class) {
            TypeManager.Activate("Auchan.Android.Controls.EndlessScrollChangedListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnScrollListener
    public void onScrolled(RecyclerView recyclerView, int i, int i2) {
        n_onScrolled(recyclerView, i, i2);
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
