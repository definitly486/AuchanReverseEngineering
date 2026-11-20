package crc6477abdb5b4de0290f;

import android.view.View;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class PriceCheckerAddressFragment_StickyTitleScrollListener extends RecyclerView.OnScrollListener implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onScrolled(RecyclerView recyclerView, int i, int i2);

    public PriceCheckerAddressFragment_StickyTitleScrollListener() {
        if (getClass() == PriceCheckerAddressFragment_StickyTitleScrollListener.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.PriceCheckerAddressFragment+StickyTitleScrollListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public PriceCheckerAddressFragment_StickyTitleScrollListener(LinearLayoutManager linearLayoutManager, View view, int i) {
        if (getClass() == PriceCheckerAddressFragment_StickyTitleScrollListener.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.PriceCheckerAddressFragment+StickyTitleScrollListener, Auchan.Android.Net", "AndroidX.RecyclerView.Widget.LinearLayoutManager, Xamarin.AndroidX.RecyclerView:Android.Views.View, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{linearLayoutManager, view, Integer.valueOf(i)});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnScrollListener
    public void onScrolled(RecyclerView recyclerView, int i, int i2) {
        n_onScrolled(recyclerView, i, i2);
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
