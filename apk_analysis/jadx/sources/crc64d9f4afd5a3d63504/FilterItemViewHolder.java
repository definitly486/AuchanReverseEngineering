package crc64d9f4afd5a3d63504;

import android.view.View;
import crc64f03248cb510113f2.CachingViewHolder;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class FilterItemViewHolder extends CachingViewHolder implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.LoyaltyProgram.ViewHolders.FilterItemViewHolder, Auchan.Android.Net", FilterItemViewHolder.class, "");
    }

    public FilterItemViewHolder(View view) {
        super(view);
        if (getClass() == FilterItemViewHolder.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.ViewHolders.FilterItemViewHolder, Auchan.Android.Net", "Android.Views.View, Mono.Android", this, new Object[]{view});
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
