package crc641d13f74a87b777a4;

import crc64fac7521b55e1fcf3.OptionDialogFragment_2;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ReviewSortFragment extends OptionDialogFragment_2 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Reviews.ReviewSortFragment, Auchan.Android.Net", ReviewSortFragment.class, "");
    }

    public ReviewSortFragment() {
        if (getClass() == ReviewSortFragment.class) {
            TypeManager.Activate("Auchan.Android.Reviews.ReviewSortFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public ReviewSortFragment(int i) {
        super(i);
        if (getClass() == ReviewSortFragment.class) {
            TypeManager.Activate("Auchan.Android.Reviews.ReviewSortFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64fac7521b55e1fcf3.OptionDialogFragment_2, crc64fac7521b55e1fcf3.OptionDialogFragment_3, crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64fac7521b55e1fcf3.OptionDialogFragment_2, crc64fac7521b55e1fcf3.OptionDialogFragment_3, crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
