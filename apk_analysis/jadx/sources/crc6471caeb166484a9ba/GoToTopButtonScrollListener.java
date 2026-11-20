package crc6471caeb166484a9ba;

import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class GoToTopButtonScrollListener extends RecyclerView.OnScrollListener implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onScrolled(RecyclerView recyclerView, int i, int i2);

    public GoToTopButtonScrollListener() {
        if (getClass() == GoToTopButtonScrollListener.class) {
            TypeManager.Activate("Auchan.Android.Common.ScrollListeners.GoToTopButtonScrollListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnScrollListener
    public void onScrolled(RecyclerView recyclerView, int i, int i2) {
        n_onScrolled(recyclerView, i, i2);
    }

    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
