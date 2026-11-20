package crc64f03248cb510113f2;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseFragmentWithViewModel extends BaseFragment implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Base.BaseFragmentWithViewModel, Auchan.Android.Net", BaseFragmentWithViewModel.class, "");
    }

    public BaseFragmentWithViewModel() {
        if (getClass() == BaseFragmentWithViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseFragmentWithViewModel, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseFragmentWithViewModel(int i) {
        super(i);
        if (getClass() == BaseFragmentWithViewModel.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseFragmentWithViewModel, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
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
