package crc64da0865216948f4da;

import android.content.Context;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SupportChatLayoutManager extends RecyclerView.LayoutManager implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_canScrollHorizontally();

    private native boolean n_canScrollVertically();

    private native RecyclerView.LayoutParams n_generateDefaultLayoutParams();

    private native boolean n_isAutoMeasureEnabled();

    private native void n_onLayoutChildren(RecyclerView.Recycler recycler, RecyclerView.State state);

    private native int n_scrollVerticallyBy(int i, RecyclerView.Recycler recycler, RecyclerView.State state);

    private native void n_setAutoMeasureEnabled(boolean z);

    private native void n_smoothScrollToPosition(RecyclerView recyclerView, RecyclerView.State state, int i);

    public SupportChatLayoutManager() {
        if (getClass() == SupportChatLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.SupportChatLayoutManager, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public SupportChatLayoutManager(Context context) {
        if (getClass() == SupportChatLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.SupportChatLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public RecyclerView.LayoutParams generateDefaultLayoutParams() {
        return n_generateDefaultLayoutParams();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean isAutoMeasureEnabled() {
        return n_isAutoMeasureEnabled();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public void setAutoMeasureEnabled(boolean z) {
        n_setAutoMeasureEnabled(z);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public void onLayoutChildren(RecyclerView.Recycler recycler, RecyclerView.State state) {
        n_onLayoutChildren(recycler, state);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public void smoothScrollToPosition(RecyclerView recyclerView, RecyclerView.State state, int i) {
        n_smoothScrollToPosition(recyclerView, state, i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean canScrollVertically() {
        return n_canScrollVertically();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean canScrollHorizontally() {
        return n_canScrollHorizontally();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public int scrollVerticallyBy(int i, RecyclerView.Recycler recycler, RecyclerView.State state) {
        return n_scrollVerticallyBy(i, recycler, state);
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
