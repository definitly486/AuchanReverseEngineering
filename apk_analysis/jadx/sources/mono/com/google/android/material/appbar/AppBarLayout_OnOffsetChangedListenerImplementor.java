package mono.com.google.android.material.appbar;

import com.google.android.material.appbar.AppBarLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AppBarLayout_OnOffsetChangedListenerImplementor implements IGCUserPeer, AppBarLayout.OnOffsetChangedListener {
    private ArrayList refList;

    private native void n_onOffsetChanged(AppBarLayout appBarLayout, int i);

    public AppBarLayout_OnOffsetChangedListenerImplementor() {
        if (getClass() == AppBarLayout_OnOffsetChangedListenerImplementor.class) {
            TypeManager.Activate("Google.Android.Material.AppBar.AppBarLayout+IOnOffsetChangedListenerImplementor, Xamarin.Google.Android.Material", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.appbar.AppBarLayout.OnOffsetChangedListener, com.google.android.material.appbar.AppBarLayout.BaseOnOffsetChangedListener
    public void onOffsetChanged(AppBarLayout appBarLayout, int i) {
        n_onOffsetChanged(appBarLayout, i);
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
