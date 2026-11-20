package crc646e7dac6304ae8ce3;

import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class StreamsListViewAdapter extends BaseAdapter implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getCount();

    private native Object n_getItem(int i);

    private native long n_getItemId(int i);

    private native View n_getView(int i, View view, ViewGroup viewGroup);

    public StreamsListViewAdapter() {
        if (getClass() == StreamsListViewAdapter.class) {
            TypeManager.Activate("Auchan.Android.Streams.StreamsListViewAdapter, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.widget.Adapter
    public Object getItem(int i) {
        return n_getItem(i);
    }

    @Override // android.widget.Adapter
    public int getCount() {
        return n_getCount();
    }

    @Override // android.widget.Adapter
    public long getItemId(int i) {
        return n_getItemId(i);
    }

    @Override // android.widget.Adapter
    public View getView(int i, View view, ViewGroup viewGroup) {
        return n_getView(i, view, viewGroup);
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
