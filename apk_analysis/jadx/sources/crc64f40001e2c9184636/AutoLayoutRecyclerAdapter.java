package crc64f40001e2c9184636;

import android.view.ViewGroup;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AutoLayoutRecyclerAdapter extends RecyclerView.Adapter implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getItemCount();

    private native int n_getItemViewType(int i);

    private native void n_onAttachedToRecyclerView(RecyclerView recyclerView);

    private native void n_onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i);

    private native RecyclerView.ViewHolder n_onCreateViewHolder(ViewGroup viewGroup, int i);

    private native void n_onDetachedFromRecyclerView(RecyclerView recyclerView);

    private native void n_onViewRecycled(RecyclerView.ViewHolder viewHolder);

    public AutoLayoutRecyclerAdapter() {
        if (getClass() == AutoLayoutRecyclerAdapter.class) {
            TypeManager.Activate("Auchan.Android.Controls.AutoLayout.AutoLayoutRecyclerAdapter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public int getItemCount() {
        return n_getItemCount();
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i) {
        n_onBindViewHolder(viewHolder, i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public int getItemViewType(int i) {
        return n_getItemViewType(i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup viewGroup, int i) {
        return n_onCreateViewHolder(viewGroup, i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onAttachedToRecyclerView(RecyclerView recyclerView) {
        n_onAttachedToRecyclerView(recyclerView);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onDetachedFromRecyclerView(RecyclerView recyclerView) {
        n_onDetachedFromRecyclerView(recyclerView);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public void onViewRecycled(RecyclerView.ViewHolder viewHolder) {
        n_onViewRecycled(viewHolder);
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
