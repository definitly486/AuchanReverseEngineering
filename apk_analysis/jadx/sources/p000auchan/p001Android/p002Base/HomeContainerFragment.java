package p000auchan.p001Android.p002Base;

import crc64f03248cb510113f2.ContainerFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class HomeContainerFragment extends ContainerFragment_1 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.HomeContainerFragment, Auchan.Android.Net", HomeContainerFragment.class, "");
    }

    public HomeContainerFragment() {
        if (getClass() == HomeContainerFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.HomeContainerFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public HomeContainerFragment(int i) {
        super(i);
        if (getClass() == HomeContainerFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.HomeContainerFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.ContainerFragment_1, crc64f03248cb510113f2.ContainerFragment, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.ContainerFragment_1, crc64f03248cb510113f2.ContainerFragment, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
