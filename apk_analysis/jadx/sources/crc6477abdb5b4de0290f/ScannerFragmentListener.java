package crc6477abdb5b4de0290f;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ScannerFragmentListener extends FragmentManager.FragmentLifecycleCallbacks implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onFragmentStarted(FragmentManager fragmentManager, Fragment fragment);

    public ScannerFragmentListener() {
        if (getClass() == ScannerFragmentListener.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.ScannerFragmentListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // androidx.fragment.app.FragmentManager.FragmentLifecycleCallbacks
    public void onFragmentStarted(FragmentManager fragmentManager, Fragment fragment) {
        n_onFragmentStarted(fragmentManager, fragment);
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
