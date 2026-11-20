package crc64c3822007c8e12760;

import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class EditCarPopupFragment extends CarFormPopupFragment_1 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Drive.EditCarPopupFragment, Auchan.Android.Net", EditCarPopupFragment.class, "");
    }

    public EditCarPopupFragment() {
        if (getClass() == EditCarPopupFragment.class) {
            TypeManager.Activate("Auchan.Android.Drive.EditCarPopupFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public EditCarPopupFragment(int i) {
        super(i);
        if (getClass() == EditCarPopupFragment.class) {
            TypeManager.Activate("Auchan.Android.Drive.EditCarPopupFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64c3822007c8e12760.CarFormPopupFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64c3822007c8e12760.CarFormPopupFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
