package crc64f03248cb510113f2;

import android.os.Bundle;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ContainerFragment_1 extends ContainerFragment implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onHiddenChanged(boolean z);

    public ContainerFragment_1() {
        if (getClass() == ContainerFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Base.ContainerFragment`1, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public ContainerFragment_1(int i) {
        super(i);
        if (getClass() == ContainerFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Base.ContainerFragment`1, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onHiddenChanged(boolean z) {
        n_onHiddenChanged(z);
    }

    @Override // crc64f03248cb510113f2.ContainerFragment, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.ContainerFragment, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
