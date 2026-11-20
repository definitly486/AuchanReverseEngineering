package crc6459efab142bb48047;

import com.google.android.material.appbar.AppBarLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AppBarStateChangeListener implements IGCUserPeer, AppBarLayout.OnOffsetChangedListener {
    private ArrayList refList;

    private native void n_onOffsetChanged(AppBarLayout appBarLayout, int i);

    public AppBarStateChangeListener() {
        if (getClass() == AppBarStateChangeListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.AppBarStateChangeListener, Auchan.Android.Net", "", this, new Object[0]);
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
