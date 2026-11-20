package p000auchan.p001Android.Ecom;

import android.os.Bundle;
import android.view.View;
import crc6477abdb5b4de0290f.BaseScannerFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class PriceCheckerFragment extends BaseScannerFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onViewCreated(View view, Bundle bundle);

    public PriceCheckerFragment() {
        if (getClass() == PriceCheckerFragment.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.PriceCheckerFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public PriceCheckerFragment(int i) {
        super(i);
        if (getClass() == PriceCheckerFragment.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.PriceCheckerFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc6477abdb5b4de0290f.BaseScannerFragment_1, androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc6477abdb5b4de0290f.BaseScannerFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc6477abdb5b4de0290f.BaseScannerFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
