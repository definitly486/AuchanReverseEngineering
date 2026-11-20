package crc64f03248cb510113f2;

import android.os.Bundle;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class BottomSheetInfoPageFragmentContainer extends BaseBottomSheetDialogFragment implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getTheme();

    private native void n_onCreate(Bundle bundle);

    public BottomSheetInfoPageFragmentContainer() {
        if (getClass() == BottomSheetInfoPageFragmentContainer.class) {
            TypeManager.Activate("Auchan.Android.Base.BottomSheetInfoPageFragmentContainer, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BottomSheetInfoPageFragmentContainer(int i) {
        super(i);
        if (getClass() == BottomSheetInfoPageFragmentContainer.class) {
            TypeManager.Activate("Auchan.Android.Base.BottomSheetInfoPageFragmentContainer, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.DialogFragment
    public int getTheme() {
        return n_getTheme();
    }

    @Override // androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
