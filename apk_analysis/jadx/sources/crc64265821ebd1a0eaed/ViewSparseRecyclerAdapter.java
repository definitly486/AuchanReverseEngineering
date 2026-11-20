package crc64265821ebd1a0eaed;

import android.view.ViewGroup;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import java.util.List;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewSparseRecyclerAdapter extends RecyclerView.Adapter implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getItemCount();

    private native long n_getItemId(int i);

    private native int n_getItemViewType(int i);

    private native void n_onAttachedToRecyclerView(RecyclerView recyclerView);

    private native void n_onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i);

    private native void n_onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i, List list);

    private native RecyclerView.ViewHolder n_onCreateViewHolder(ViewGroup viewGroup, int i);

    private native void n_onDetachedFromRecyclerView(RecyclerView recyclerView);

    private native boolean n_onFailedToRecycleView(RecyclerView.ViewHolder viewHolder);

    private native void n_onViewAttachedToWindow(RecyclerView.ViewHolder viewHolder);

    private native void n_onViewDetachedFromWindow(RecyclerView.ViewHolder viewHolder);

    private native void n_onViewRecycled(RecyclerView.ViewHolder viewHolder);

    private native void n_registerAdapterDataObserver(RecyclerView.AdapterDataObserver adapterDataObserver);

    private native void n_unregisterAdapterDataObserver(RecyclerView.AdapterDataObserver adapterDataObserver);

    public ViewSparseRecyclerAdapter() {
        if (getClass() == ViewSparseRecyclerAdapter.class) {
            TypeManager.Activate("ViewSparsedRecycler.ViewSparseRecyclerAdapter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public ViewSparseRecyclerAdapter(RecyclerView.Adapter adapter) {
        if (getClass() == ViewSparseRecyclerAdapter.class) {
            TypeManager.Activate("ViewSparsedRecycler.ViewSparseRecyclerAdapter, Auchan.Android.Net", "AndroidX.RecyclerView.Widget.RecyclerView+Adapter, Xamarin.AndroidX.RecyclerView", this, new Object[]{adapter});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public int getItemCount() {
        return n_getItemCount();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public long getItemId(int i) {
        return n_getItemId(i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public int getItemViewType(int i) {
        return n_getItemViewType(i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onAttachedToRecyclerView(RecyclerView recyclerView) {
        n_onAttachedToRecyclerView(recyclerView);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i) {
        n_onBindViewHolder(viewHolder, i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i, List list) {
        n_onBindViewHolder(viewHolder, i, list);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup viewGroup, int i) {
        return n_onCreateViewHolder(viewGroup, i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onDetachedFromRecyclerView(RecyclerView recyclerView) {
        n_onDetachedFromRecyclerView(recyclerView);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public boolean onFailedToRecycleView(RecyclerView.ViewHolder viewHolder) {
        return n_onFailedToRecycleView(viewHolder);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onViewAttachedToWindow(RecyclerView.ViewHolder viewHolder) {
        n_onViewAttachedToWindow(viewHolder);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onViewDetachedFromWindow(RecyclerView.ViewHolder viewHolder) {
        n_onViewDetachedFromWindow(viewHolder);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onViewRecycled(RecyclerView.ViewHolder viewHolder) {
        n_onViewRecycled(viewHolder);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void registerAdapterDataObserver(RecyclerView.AdapterDataObserver adapterDataObserver) {
        n_registerAdapterDataObserver(adapterDataObserver);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void unregisterAdapterDataObserver(RecyclerView.AdapterDataObserver adapterDataObserver) {
        n_unregisterAdapterDataObserver(adapterDataObserver);
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
