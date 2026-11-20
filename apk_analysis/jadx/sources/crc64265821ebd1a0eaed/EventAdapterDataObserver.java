package crc64265821ebd1a0eaed;

import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class EventAdapterDataObserver extends RecyclerView.AdapterDataObserver implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onChanged();

    private native void n_onItemRangeChanged(int i, int i2);

    private native void n_onItemRangeChanged(int i, int i2, Object obj);

    private native void n_onItemRangeInserted(int i, int i2);

    private native void n_onItemRangeMoved(int i, int i2, int i3);

    private native void n_onItemRangeRemoved(int i, int i2);

    public EventAdapterDataObserver() {
        if (getClass() == EventAdapterDataObserver.class) {
            TypeManager.Activate("ViewSparsedRecycler.EventAdapterDataObserver, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public EventAdapterDataObserver(RecyclerView.Adapter adapter) {
        if (getClass() == EventAdapterDataObserver.class) {
            TypeManager.Activate("ViewSparsedRecycler.EventAdapterDataObserver, Auchan.Android.Net", "AndroidX.RecyclerView.Widget.RecyclerView+Adapter, Xamarin.AndroidX.RecyclerView", this, new Object[]{adapter});
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
