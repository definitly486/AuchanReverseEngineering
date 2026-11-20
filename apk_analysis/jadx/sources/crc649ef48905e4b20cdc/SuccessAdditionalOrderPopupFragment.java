package crc649ef48905e4b20cdc;

import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SuccessAdditionalOrderPopupFragment extends BaseBottomSheetDialogFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getTheme();

    private native void n_onViewCreated(View view, Bundle bundle);

    public SuccessAdditionalOrderPopupFragment() {
        if (getClass() == SuccessAdditionalOrderPopupFragment.class) {
            TypeManager.Activate("Auchan.Android.Profile.Orders.SuccessAdditionalOrderPopupFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public SuccessAdditionalOrderPopupFragment(int i) {
        super(i);
        if (getClass() == SuccessAdditionalOrderPopupFragment.class) {
            TypeManager.Activate("Auchan.Android.Profile.Orders.SuccessAdditionalOrderPopupFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.DialogFragment
    public int getTheme() {
        return n_getTheme();
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, crc64f03248cb510113f2.BaseBottomSheetDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
