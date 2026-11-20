package crc6459efab142bb48047;

import android.view.View;
import androidx.core.view.WindowInsetsCompat;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnApplyWindowInsetsListener implements IGCUserPeer, androidx.core.view.OnApplyWindowInsetsListener {
    private ArrayList refList;

    private native WindowInsetsCompat n_onApplyWindowInsets(View view, WindowInsetsCompat windowInsetsCompat);

    public OnApplyWindowInsetsListener() {
        if (getClass() == OnApplyWindowInsetsListener.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.OnApplyWindowInsetsListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.core.view.OnApplyWindowInsetsListener
    public WindowInsetsCompat onApplyWindowInsets(View view, WindowInsetsCompat windowInsetsCompat) {
        return n_onApplyWindowInsets(view, windowInsetsCompat);
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
