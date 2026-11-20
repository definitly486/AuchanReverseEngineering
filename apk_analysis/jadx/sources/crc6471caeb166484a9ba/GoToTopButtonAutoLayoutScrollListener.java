package crc6471caeb166484a9ba;

import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class GoToTopButtonAutoLayoutScrollListener extends GoToTopButtonScrollListener implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onScrolled(RecyclerView recyclerView, int i, int i2);

    public GoToTopButtonAutoLayoutScrollListener() {
        if (getClass() == GoToTopButtonAutoLayoutScrollListener.class) {
            TypeManager.Activate("Auchan.Android.Common.ScrollListeners.GoToTopButtonAutoLayoutScrollListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // crc6471caeb166484a9ba.GoToTopButtonScrollListener, androidx.recyclerview.widget.RecyclerView.OnScrollListener
    public void onScrolled(RecyclerView recyclerView, int i, int i2) {
        n_onScrolled(recyclerView, i, i2);
    }

    @Override // crc6471caeb166484a9ba.GoToTopButtonScrollListener, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc6471caeb166484a9ba.GoToTopButtonScrollListener, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
