package crc64f3dd990328beca9c;

import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseDialogFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyCardPdf417LandscapeFragment extends BaseDialogFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getTheme();

    private native void n_onAttach(Context context);

    private native void n_onDismiss(DialogInterface dialogInterface);

    private native void n_onViewCreated(View view, Bundle bundle);

    public LoyaltyCardPdf417LandscapeFragment() {
        if (getClass() == LoyaltyCardPdf417LandscapeFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyCardPdf417LandscapeFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoyaltyCardPdf417LandscapeFragment(int i) {
        super(i);
        if (getClass() == LoyaltyCardPdf417LandscapeFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyCardPdf417LandscapeFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.DialogFragment
    public int getTheme() {
        return n_getTheme();
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onAttach(Context context) {
        n_onAttach(context);
    }

    @Override // androidx.fragment.app.DialogFragment, android.content.DialogInterface.OnDismissListener
    public void onDismiss(DialogInterface dialogInterface) {
        n_onDismiss(dialogInterface);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment_1, crc64f03248cb510113f2.BaseDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment_1, crc64f03248cb510113f2.BaseDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
