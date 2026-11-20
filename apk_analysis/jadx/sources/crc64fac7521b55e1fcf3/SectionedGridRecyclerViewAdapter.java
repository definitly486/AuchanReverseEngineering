package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.view.ViewGroup;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SectionedGridRecyclerViewAdapter extends RecyclerView.Adapter implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getItemCount();

    private native long n_getItemId(int i);

    private native int n_getItemViewType(int i);

    private native void n_onBindViewHolder(RecyclerView.ViewHolder viewHolder, int i);

    private native RecyclerView.ViewHolder n_onCreateViewHolder(ViewGroup viewGroup, int i);

    public SectionedGridRecyclerViewAdapter() {
        if (getClass() == SectionedGridRecyclerViewAdapter.class) {
            TypeManager.Activate("Auchan.Android.Controls.SectionedGridRecyclerViewAdapter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public SectionedGridRecyclerViewAdapter(Context context, int i, int i2, RecyclerView recyclerView, RecyclerView.Adapter adapter) {
        if (getClass() == SectionedGridRecyclerViewAdapter.class) {
            TypeManager.Activate("Auchan.Android.Controls.SectionedGridRecyclerViewAdapter, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib:AndroidX.RecyclerView.Widget.RecyclerView, Xamarin.AndroidX.RecyclerView:AndroidX.RecyclerView.Widget.RecyclerView+Adapter, Xamarin.AndroidX.RecyclerView", this, new Object[]{context, Integer.valueOf(i), Integer.valueOf(i2), recyclerView, adapter});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup viewGroup, int i) {
        return n_onCreateViewHolder(viewGroup, i);
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
    public long getItemId(int i) {
        return n_getItemId(i);
    }

    @Override // androidx.recyclerview.widget.RecyclerView.Adapter
    public int getItemCount() {
        return n_getItemCount();
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
