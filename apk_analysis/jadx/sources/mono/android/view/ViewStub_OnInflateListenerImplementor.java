package mono.android.view;

import android.view.View;
import android.view.ViewStub;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewStub_OnInflateListenerImplementor implements IGCUserPeer, ViewStub.OnInflateListener {
    private ArrayList refList;

    private native void n_onInflate(ViewStub viewStub, View view);

    public ViewStub_OnInflateListenerImplementor() {
        if (getClass() == ViewStub_OnInflateListenerImplementor.class) {
            TypeManager.Activate("Android.Views.ViewStub+IOnInflateListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.view.ViewStub.OnInflateListener
    public void onInflate(ViewStub viewStub, View view) {
        n_onInflate(viewStub, view);
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
