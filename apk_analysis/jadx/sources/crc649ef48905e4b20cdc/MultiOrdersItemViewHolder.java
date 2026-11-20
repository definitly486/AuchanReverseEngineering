package crc649ef48905e4b20cdc;

import android.view.View;
import crc64f03248cb510113f2.CachingViewHolder;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class MultiOrdersItemViewHolder extends CachingViewHolder implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Profile.Orders.MultiOrdersItemViewHolder, Auchan.Android.Net", MultiOrdersItemViewHolder.class, "");
    }

    public MultiOrdersItemViewHolder(View view) {
        super(view);
        if (getClass() == MultiOrdersItemViewHolder.class) {
            TypeManager.Activate("Auchan.Android.Profile.Orders.MultiOrdersItemViewHolder, Auchan.Android.Net", "Android.Views.View, Mono.Android", this, new Object[]{view});
        }
    }

    @Override // crc64f03248cb510113f2.CachingViewHolder, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.CachingViewHolder, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
