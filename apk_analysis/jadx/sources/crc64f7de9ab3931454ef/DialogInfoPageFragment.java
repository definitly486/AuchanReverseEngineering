package crc64f7de9ab3931454ef;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class DialogInfoPageFragment extends InfoPageFragment implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.InfoPages.DialogInfoPageFragment, Auchan.Android.Net", DialogInfoPageFragment.class, "");
    }

    public DialogInfoPageFragment() {
        if (getClass() == DialogInfoPageFragment.class) {
            TypeManager.Activate("Auchan.Android.InfoPages.DialogInfoPageFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public DialogInfoPageFragment(int i) {
        super(i);
        if (getClass() == DialogInfoPageFragment.class) {
            TypeManager.Activate("Auchan.Android.InfoPages.DialogInfoPageFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f7de9ab3931454ef.InfoPageFragment, crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f7de9ab3931454ef.InfoPageFragment, crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
