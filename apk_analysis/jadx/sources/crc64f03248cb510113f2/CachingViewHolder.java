package crc64f03248cb510113f2;

import android.view.View;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class CachingViewHolder extends RecyclerView.ViewHolder implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.CachingViewHolder, Auchan.Android.Net", CachingViewHolder.class, "");
    }

    public CachingViewHolder(View view) {
        super(view);
        if (getClass() == CachingViewHolder.class) {
            TypeManager.Activate("Auchan.Android.Base.CachingViewHolder, Auchan.Android.Net", "Android.Views.View, Mono.Android", this, new Object[]{view});
        }
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
