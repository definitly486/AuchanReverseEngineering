package crc64f03248cb510113f2;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ContainerFragment extends BaseFragment implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.ContainerFragment, Auchan.Android.Net", ContainerFragment.class, "");
    }

    public ContainerFragment() {
        if (getClass() == ContainerFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.ContainerFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public ContainerFragment(int i) {
        super(i);
        if (getClass() == ContainerFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.ContainerFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
