package crc642b256e382eaa7efb;

import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseToolbarFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class StaticProductListFragment extends BaseToolbarFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onViewCreated(View view, Bundle bundle);

    public StaticProductListFragment() {
        if (getClass() == StaticProductListFragment.class) {
            TypeManager.Activate("Auchan.Android.Catalog.StaticProductListFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public StaticProductListFragment(int i) {
        super(i);
        if (getClass() == StaticProductListFragment.class) {
            TypeManager.Activate("Auchan.Android.Catalog.StaticProductListFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
