package crc6459efab142bb48047;

import com.google.android.material.snackbar.ContentViewCallback;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AuchanSnackbar_ContentViewCallback implements IGCUserPeer, ContentViewCallback {
    private ArrayList refList;

    private native void n_animateContentIn(int i, int i2);

    private native void n_animateContentOut(int i, int i2);

    public AuchanSnackbar_ContentViewCallback() {
        if (getClass() == AuchanSnackbar_ContentViewCallback.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.AuchanSnackbar+ContentViewCallback, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // com.google.android.material.snackbar.ContentViewCallback
    public void animateContentIn(int i, int i2) {
        n_animateContentIn(i, i2);
    }

    @Override // com.google.android.material.snackbar.ContentViewCallback
    public void animateContentOut(int i, int i2) {
        n_animateContentOut(i, i2);
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
