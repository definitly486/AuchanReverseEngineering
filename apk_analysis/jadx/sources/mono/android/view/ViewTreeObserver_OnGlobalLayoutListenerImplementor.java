package mono.android.view;

import android.view.ViewTreeObserver;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ViewTreeObserver_OnGlobalLayoutListenerImplementor implements IGCUserPeer, ViewTreeObserver.OnGlobalLayoutListener {
    private ArrayList refList;

    private native void n_onGlobalLayout();

    public ViewTreeObserver_OnGlobalLayoutListenerImplementor() {
        if (getClass() == ViewTreeObserver_OnGlobalLayoutListenerImplementor.class) {
            TypeManager.Activate("Android.Views.ViewTreeObserver+IOnGlobalLayoutListenerImplementor, Mono.Android", "", this, new Object[0]);
        }
    }

    @Override // android.view.ViewTreeObserver.OnGlobalLayoutListener
    public void onGlobalLayout() {
        n_onGlobalLayout();
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
