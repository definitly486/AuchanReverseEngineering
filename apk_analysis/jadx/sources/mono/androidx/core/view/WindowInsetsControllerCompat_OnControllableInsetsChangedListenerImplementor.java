package mono.androidx.core.view;

import androidx.core.view.WindowInsetsControllerCompat;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class WindowInsetsControllerCompat_OnControllableInsetsChangedListenerImplementor implements IGCUserPeer, WindowInsetsControllerCompat.OnControllableInsetsChangedListener {
    private ArrayList refList;

    private native void n_onControllableInsetsChanged(WindowInsetsControllerCompat windowInsetsControllerCompat, int i);

    public WindowInsetsControllerCompat_OnControllableInsetsChangedListenerImplementor() {
        if (getClass() == WindowInsetsControllerCompat_OnControllableInsetsChangedListenerImplementor.class) {
            TypeManager.Activate("AndroidX.Core.View.WindowInsetsControllerCompat+IOnControllableInsetsChangedListenerImplementor, Xamarin.AndroidX.Core", "", this, new Object[0]);
        }
    }

    @Override // androidx.core.view.WindowInsetsControllerCompat.OnControllableInsetsChangedListener
    public void onControllableInsetsChanged(WindowInsetsControllerCompat windowInsetsControllerCompat, int i) {
        n_onControllableInsetsChanged(windowInsetsControllerCompat, i);
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
