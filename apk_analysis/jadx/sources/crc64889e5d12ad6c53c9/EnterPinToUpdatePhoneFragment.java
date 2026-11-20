package crc64889e5d12ad6c53c9;

import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class EnterPinToUpdatePhoneFragment extends BaseBottomSheetDialogFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onDismiss(DialogInterface dialogInterface);

    private native void n_onViewCreated(View view, Bundle bundle);

    public EnterPinToUpdatePhoneFragment() {
        if (getClass() == EnterPinToUpdatePhoneFragment.class) {
            TypeManager.Activate("Auchan.Android.Profile.EnterPinToUpdatePhoneFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public EnterPinToUpdatePhoneFragment(int i) {
        super(i);
        if (getClass() == EnterPinToUpdatePhoneFragment.class) {
            TypeManager.Activate("Auchan.Android.Profile.EnterPinToUpdatePhoneFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment_1, androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.fragment.app.DialogFragment, android.content.DialogInterface.OnDismissListener
    public void onDismiss(DialogInterface dialogInterface) {
        n_onDismiss(dialogInterface);
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
