package mono.androidx.swiperefreshlayout.widget;

import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SwipeRefreshLayout_OnRefreshListenerImplementor implements IGCUserPeer, SwipeRefreshLayout.OnRefreshListener {
    private ArrayList refList;

    private native void n_onRefresh();

    public SwipeRefreshLayout_OnRefreshListenerImplementor() {
        if (getClass() == SwipeRefreshLayout_OnRefreshListenerImplementor.class) {
            TypeManager.Activate("AndroidX.SwipeRefreshLayout.Widget.SwipeRefreshLayout+IOnRefreshListenerImplementor, Xamarin.AndroidX.SwipeRefreshLayout", "", this, new Object[0]);
        }
    }

    @Override // androidx.swiperefreshlayout.widget.SwipeRefreshLayout.OnRefreshListener
    public void onRefresh() {
        n_onRefresh();
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
