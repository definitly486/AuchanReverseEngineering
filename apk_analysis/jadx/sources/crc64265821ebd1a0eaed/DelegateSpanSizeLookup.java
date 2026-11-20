package crc64265821ebd1a0eaed;

import androidx.recyclerview.widget.GridLayoutManager;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DelegateSpanSizeLookup extends GridLayoutManager.SpanSizeLookup implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getSpanSize(int i);

    public DelegateSpanSizeLookup() {
        if (getClass() == DelegateSpanSizeLookup.class) {
            TypeManager.Activate("ViewSparsedRecycler.DelegateSpanSizeLookup, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.recyclerview.widget.GridLayoutManager.SpanSizeLookup
    public int getSpanSize(int i) {
        return n_getSpanSize(i);
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
