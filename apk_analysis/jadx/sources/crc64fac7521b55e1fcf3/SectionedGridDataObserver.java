package crc64fac7521b55e1fcf3;

import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SectionedGridDataObserver extends RecyclerView.AdapterDataObserver implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onChanged();

    private native void n_onItemRangeChanged(int i, int i2);

    private native void n_onItemRangeChanged(int i, int i2, Object obj);

    private native void n_onItemRangeInserted(int i, int i2);

    private native void n_onItemRangeMoved(int i, int i2, int i3);

    private native void n_onItemRangeRemoved(int i, int i2);

    public SectionedGridDataObserver() {
        if (getClass() == SectionedGridDataObserver.class) {
            TypeManager.Activate("Auchan.Android.Controls.SectionedGridDataObserver, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.AdapterDataObserver
    public void onChanged() {
        n_onChanged();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.AdapterDataObserver
    public void onItemRangeChanged(int i, int i2) {
        n_onItemRangeChanged(i, i2);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.AdapterDataObserver
    public void onItemRangeChanged(int i, int i2, Object obj) {
        n_onItemRangeChanged(i, i2, obj);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.AdapterDataObserver
    public void onItemRangeInserted(int i, int i2) {
        n_onItemRangeInserted(i, i2);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.AdapterDataObserver
    public void onItemRangeMoved(int i, int i2, int i3) {
        n_onItemRangeMoved(i, i2, i3);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.AdapterDataObserver
    public void onItemRangeRemoved(int i, int i2) {
        n_onItemRangeRemoved(i, i2);
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
