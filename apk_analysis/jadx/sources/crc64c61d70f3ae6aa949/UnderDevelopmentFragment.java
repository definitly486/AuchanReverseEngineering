package crc64c61d70f3ae6aa949;

import crc64f03248cb510113f2.BaseFragment;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class UnderDevelopmentFragment extends BaseFragment implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.UnderDevelopment.UnderDevelopmentFragment, Auchan.Android.Net", UnderDevelopmentFragment.class, "");
    }

    public UnderDevelopmentFragment() {
        if (getClass() == UnderDevelopmentFragment.class) {
            TypeManager.Activate("Auchan.Android.UnderDevelopment.UnderDevelopmentFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public UnderDevelopmentFragment(int i) {
        super(i);
        if (getClass() == UnderDevelopmentFragment.class) {
            TypeManager.Activate("Auchan.Android.UnderDevelopment.UnderDevelopmentFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
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
