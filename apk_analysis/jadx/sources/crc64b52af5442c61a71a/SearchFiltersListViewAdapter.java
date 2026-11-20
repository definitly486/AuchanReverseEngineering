package crc64b52af5442c61a71a;

import crc646064278e9258e0c4.VariableItemsListViewAdapter_2;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SearchFiltersListViewAdapter extends VariableItemsListViewAdapter_2 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Catalog.Search.SearchFiltersListViewAdapter, Auchan.Android.Net", SearchFiltersListViewAdapter.class, "");
    }

    public SearchFiltersListViewAdapter() {
        if (getClass() == SearchFiltersListViewAdapter.class) {
            TypeManager.Activate("Auchan.Android.Catalog.Search.SearchFiltersListViewAdapter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // crc646064278e9258e0c4.VariableItemsListViewAdapter_2, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc646064278e9258e0c4.VariableItemsListViewAdapter_2, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
