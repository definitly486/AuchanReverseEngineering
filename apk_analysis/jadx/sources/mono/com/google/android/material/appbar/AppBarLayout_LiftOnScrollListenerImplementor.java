package mono.com.google.android.material.appbar;

import com.google.android.material.appbar.AppBarLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AppBarLayout_LiftOnScrollListenerImplementor implements IGCUserPeer, AppBarLayout.LiftOnScrollListener {
    private ArrayList refList;

    private native void n_onUpdate(float f, int i);

    public AppBarLayout_LiftOnScrollListenerImplementor() {
        if (getClass() == AppBarLayout_LiftOnScrollListenerImplementor.class) {
            TypeManager.Activate("Google.Android.Material.AppBar.AppBarLayout+ILiftOnScrollListenerImplementor, Xamarin.Google.Android.Material", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.appbar.AppBarLayout.LiftOnScrollListener
    public void onUpdate(float f, int i) {
        n_onUpdate(f, i);
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
