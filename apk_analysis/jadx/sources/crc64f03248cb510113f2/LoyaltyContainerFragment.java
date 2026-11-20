package crc64f03248cb510113f2;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyContainerFragment extends ContainerFragment_1 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.LoyaltyContainerFragment, Auchan.Android.Net", LoyaltyContainerFragment.class, "");
    }

    public LoyaltyContainerFragment() {
        if (getClass() == LoyaltyContainerFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.LoyaltyContainerFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoyaltyContainerFragment(int i) {
        super(i);
        if (getClass() == LoyaltyContainerFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.LoyaltyContainerFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
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
