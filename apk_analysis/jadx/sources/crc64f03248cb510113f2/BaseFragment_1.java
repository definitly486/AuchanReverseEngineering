package crc64f03248cb510113f2;

import android.os.Bundle;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseFragment_1 extends BaseFragmentWithViewModel implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onHiddenChanged(boolean z);

    private native void n_onPause();

    private native void n_onResume();

    private native void n_onStart();

    private native void n_onStop();

    public BaseFragment_1() {
        if (getClass() == BaseFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseFragment`1, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseFragment_1(int i) {
        super(i);
        if (getClass() == BaseFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseFragment`1, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onStart() {
        n_onStart();
    }

    @Override // androidx.fragment.app.Fragment
    public void onStop() {
        n_onStop();
    }

    @Override // androidx.fragment.app.Fragment
    public void onHiddenChanged(boolean z) {
        n_onHiddenChanged(z);
    }

    @Override // androidx.fragment.app.Fragment
    public void onResume() {
        n_onResume();
    }

    @Override // androidx.fragment.app.Fragment
    public void onPause() {
        n_onPause();
    }

    @Override // crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
