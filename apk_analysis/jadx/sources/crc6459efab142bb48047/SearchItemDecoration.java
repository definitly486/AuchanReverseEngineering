package crc6459efab142bb48047;

import android.graphics.Rect;
import android.view.View;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SearchItemDecoration extends RecyclerView.ItemDecoration implements IGCUserPeer {
    private ArrayList refList;

    private native void n_getItemOffsets(Rect rect, View view, RecyclerView recyclerView, RecyclerView.State state);

    public SearchItemDecoration() {
        if (getClass() == SearchItemDecoration.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.SearchItemDecoration, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.ItemDecoration
    public void getItemOffsets(Rect rect, View view, RecyclerView recyclerView, RecyclerView.State state) {
        n_getItemOffsets(rect, view, recyclerView, state);
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
