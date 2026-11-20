package crc64fac7521b55e1fcf3;

import android.app.Dialog;
import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseDialogFragment;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class BusyPopup extends BaseDialogFragment implements IGCUserPeer {
    private ArrayList refList;

    private native Dialog n_onCreateDialog(Bundle bundle);

    private native void n_onViewCreated(View view, Bundle bundle);

    public BusyPopup() {
        if (getClass() == BusyPopup.class) {
            TypeManager.Activate("Auchan.Android.Controls.BusyPopup, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BusyPopup(int i) {
        super(i);
        if (getClass() == BusyPopup.class) {
            TypeManager.Activate("Auchan.Android.Controls.BusyPopup, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.fragment.app.DialogFragment
    public Dialog onCreateDialog(Bundle bundle) {
        return n_onCreateDialog(bundle);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
