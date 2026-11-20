package mono.android.widget;

import android.view.View;
import android.widget.AdapterView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AdapterView_OnItemSelectedListenerImplementor implements IGCUserPeer, AdapterView.OnItemSelectedListener {
    private ArrayList refList;

    private native void n_onItemSelected(AdapterView adapterView, View view, int i, long j);

    private native void n_onNothingSelected(AdapterView adapterView);

    public AdapterView_OnItemSelectedListenerImplementor() {
        if (getClass() == AdapterView_OnItemSelectedListenerImplementor.class) {
            TypeManager.Activate("Android.Widget.AdapterView+IOnItemSelectedListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.widget.AdapterView.OnItemSelectedListener
    public void onItemSelected(AdapterView adapterView, View view, int i, long j) {
        n_onItemSelected(adapterView, view, i, j);
    }

    @Override // android.widget.AdapterView.OnItemSelectedListener
    public void onNothingSelected(AdapterView adapterView) {
        n_onNothingSelected(adapterView);
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
