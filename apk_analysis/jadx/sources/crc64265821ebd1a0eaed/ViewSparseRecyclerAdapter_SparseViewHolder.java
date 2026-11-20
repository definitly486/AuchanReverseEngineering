package crc64265821ebd1a0eaed;

import android.view.View;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewSparseRecyclerAdapter_SparseViewHolder extends RecyclerView.ViewHolder implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("ViewSparsedRecycler.ViewSparseRecyclerAdapter+SparseViewHolder, Auchan.Android.Net", ViewSparseRecyclerAdapter_SparseViewHolder.class, "");
    }

    public ViewSparseRecyclerAdapter_SparseViewHolder(View view) {
        super(view);
        if (getClass() == ViewSparseRecyclerAdapter_SparseViewHolder.class) {
            TypeManager.Activate("ViewSparsedRecycler.ViewSparseRecyclerAdapter+SparseViewHolder, Auchan.Android.Net", "Android.Views.View, Mono.Android", this, new Object[]{view});
        }
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
