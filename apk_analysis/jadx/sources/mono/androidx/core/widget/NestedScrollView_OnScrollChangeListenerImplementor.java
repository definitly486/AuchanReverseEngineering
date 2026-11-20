package mono.androidx.core.widget;

import androidx.core.widget.NestedScrollView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class NestedScrollView_OnScrollChangeListenerImplementor implements IGCUserPeer, NestedScrollView.OnScrollChangeListener {
    private ArrayList refList;

    private native void n_onScrollChange(NestedScrollView nestedScrollView, int i, int i2, int i3, int i4);

    public NestedScrollView_OnScrollChangeListenerImplementor() {
        if (getClass() == NestedScrollView_OnScrollChangeListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Core.Widget.NestedScrollView+IOnScrollChangeListenerImplementor, Xamarin.AndroidX.Core", "", this, new Object[0]);
        }
    }

    @Override // androidx.core.widget.NestedScrollView.OnScrollChangeListener
    public void onScrollChange(NestedScrollView nestedScrollView, int i, int i2, int i3, int i4) {
        n_onScrollChange(nestedScrollView, i, i2, i3, i4);
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
