package crc64f03248cb510113f2;

import android.app.Dialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import com.google.android.material.bottomsheet.BottomSheetDialogFragment;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseBottomSheetDialogFragment extends BottomSheetDialogFragment implements IGCUserPeer, DialogInterface.OnShowListener {
    private ArrayList refList;

    private native Dialog n_onCreateDialog(Bundle bundle);

    private native View n_onCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle);

    private native void n_onShow(DialogInterface dialogInterface);

    public BaseBottomSheetDialogFragment() {
        if (getClass() == BaseBottomSheetDialogFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseBottomSheetDialogFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseBottomSheetDialogFragment(int i) {
        super(i);
        if (getClass() == BaseBottomSheetDialogFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseBottomSheetDialogFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.Fragment
    public View onCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle) {
        return n_onCreateView(layoutInflater, viewGroup, bundle);
    }

    @Override // com.google.android.material.bottomsheet.BottomSheetDialogFragment, androidx.appcompat.app.AppCompatDialogFragment, androidx.fragment.app.DialogFragment
    public Dialog onCreateDialog(Bundle bundle) {
        return n_onCreateDialog(bundle);
    }

    @Override // android.content.DialogInterface.OnShowListener
    public void onShow(DialogInterface dialogInterface) {
        n_onShow(dialogInterface);
    }

    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
