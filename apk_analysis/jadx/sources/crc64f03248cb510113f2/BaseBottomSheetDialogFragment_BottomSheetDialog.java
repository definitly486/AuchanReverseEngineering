package crc64f03248cb510113f2;

import android.content.Context;
import android.content.DialogInterface;
import com.google.android.material.bottomsheet.BottomSheetDialog;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class BaseBottomSheetDialogFragment_BottomSheetDialog extends BottomSheetDialog implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onAttachedToWindow();

    public BaseBottomSheetDialogFragment_BottomSheetDialog(Context context) {
        super(context);
        if (getClass() == BaseBottomSheetDialogFragment_BottomSheetDialog.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseBottomSheetDialogFragment+BottomSheetDialog, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public BaseBottomSheetDialogFragment_BottomSheetDialog(Context context, boolean z, DialogInterface.OnCancelListener onCancelListener) {
        super(context, z, onCancelListener);
        if (getClass() == BaseBottomSheetDialogFragment_BottomSheetDialog.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseBottomSheetDialogFragment+BottomSheetDialog, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Boolean, System.Private.CoreLib:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android", this, new Object[]{context, Boolean.valueOf(z), onCancelListener});
        }
    }

    public BaseBottomSheetDialogFragment_BottomSheetDialog(Context context, int i) {
        super(context, i);
        if (getClass() == BaseBottomSheetDialogFragment_BottomSheetDialog.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseBottomSheetDialogFragment+BottomSheetDialog, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, Integer.valueOf(i)});
        }
    }

    @Override // com.google.android.material.bottomsheet.BottomSheetDialog, android.app.Dialog, android.view.Window.Callback
    public void onAttachedToWindow() {
        n_onAttachedToWindow();
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
