package crc64f03248cb510113f2;

import androidx.activity.OnBackPressedCallback;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DelegateOnBackPressedCallback extends OnBackPressedCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_handleOnBackPressed();

    public DelegateOnBackPressedCallback(boolean z) {
        super(z);
        if (getClass() == DelegateOnBackPressedCallback.class) {
            TypeManager.Activate("Auchan.Android.Base.DelegateOnBackPressedCallback, Auchan.Android.Net", "System.Boolean, System.Private.CoreLib", this, new Object[]{Boolean.valueOf(z)});
        }
    }

    @Override // androidx.activity.OnBackPressedCallback
    public void handleOnBackPressed() {
        n_handleOnBackPressed();
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
