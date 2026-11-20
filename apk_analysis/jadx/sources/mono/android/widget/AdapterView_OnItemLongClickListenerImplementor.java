package mono.android.widget;

import android.view.View;
import android.widget.AdapterView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AdapterView_OnItemLongClickListenerImplementor implements IGCUserPeer, AdapterView.OnItemLongClickListener {
    private ArrayList refList;

    private native boolean n_onItemLongClick(AdapterView adapterView, View view, int i, long j);

    public AdapterView_OnItemLongClickListenerImplementor() {
        if (getClass() == AdapterView_OnItemLongClickListenerImplementor.class) {
            TypeManager.Activate("Android.Widget.AdapterView+IOnItemLongClickListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.widget.AdapterView.OnItemLongClickListener
    public boolean onItemLongClick(AdapterView adapterView, View view, int i, long j) {
        return n_onItemLongClick(adapterView, view, i, j);
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
