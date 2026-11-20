package crc64442f438b9d6a8443;

import android.graphics.Outline;
import android.view.View;
import android.view.ViewOutlineProvider;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RoundViewOutlineProvider extends ViewOutlineProvider implements IGCUserPeer {
    private ArrayList refList;

    private native void n_getOutline(View view, Outline outline);

    public RoundViewOutlineProvider() {
        if (getClass() == RoundViewOutlineProvider.class) {
            TypeManager.Activate("Auchan.Android.Providers.RoundViewOutlineProvider, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public RoundViewOutlineProvider(float f) {
        if (getClass() == RoundViewOutlineProvider.class) {
            TypeManager.Activate("Auchan.Android.Providers.RoundViewOutlineProvider, Auchan.Android.Net", "System.Single, System.Private.CoreLib", this, new Object[]{Float.valueOf(f)});
        }
    }

    @Override // android.view.ViewOutlineProvider
    public void getOutline(View view, Outline outline) {
        n_getOutline(view, outline);
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
