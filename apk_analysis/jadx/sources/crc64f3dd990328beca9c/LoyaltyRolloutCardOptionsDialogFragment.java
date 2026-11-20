package crc64f3dd990328beca9c;

import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.KeyEvent;
import android.view.View;
import crc64f03248cb510113f2.BaseBottomSheetDialogFragment;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyRolloutCardOptionsDialogFragment extends BaseBottomSheetDialogFragment implements IGCUserPeer, DialogInterface.OnKeyListener {
    private ArrayList refList;

    private native int n_getTheme();

    private native void n_onCreate(Bundle bundle);

    private native Dialog n_onCreateDialog(Bundle bundle);

    private native boolean n_onKey(DialogInterface dialogInterface, int i, KeyEvent keyEvent);

    private native void n_onViewCreated(View view, Bundle bundle);

    public LoyaltyRolloutCardOptionsDialogFragment() {
        if (getClass() == LoyaltyRolloutCardOptionsDialogFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyRolloutCardOptionsDialogFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoyaltyRolloutCardOptionsDialogFragment(int i) {
        super(i);
        if (getClass() == LoyaltyRolloutCardOptionsDialogFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyRolloutCardOptionsDialogFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
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

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseBottomSheetDialogFragment, com.google.android.material.bottomsheet.BottomSheetDialogFragment, androidx.appcompat.app.AppCompatDialogFragment, androidx.fragment.app.DialogFragment
    public Dialog onCreateDialog(Bundle bundle) {
        return n_onCreateDialog(bundle);
    }

    @Override // android.content.DialogInterface.OnKeyListener
    public boolean onKey(DialogInterface dialogInterface, int i, KeyEvent keyEvent) {
        return n_onKey(dialogInterface, i, keyEvent);
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
