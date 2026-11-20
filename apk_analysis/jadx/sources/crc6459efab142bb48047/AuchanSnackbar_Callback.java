package crc6459efab142bb48047;

import android.widget.PopupWindow;
import com.google.android.material.snackbar.BaseTransientBottomBar;
import crc646064278e9258e0c4.DroidInfoMessageService;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class AuchanSnackbar_Callback extends BaseTransientBottomBar.BaseCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onDismissed(Object obj, int i);

    public AuchanSnackbar_Callback() {
        if (getClass() == AuchanSnackbar_Callback.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.AuchanSnackbar+Callback, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public AuchanSnackbar_Callback(PopupWindow popupWindow, String str, int i, DroidInfoMessageService droidInfoMessageService) {
        if (getClass() == AuchanSnackbar_Callback.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.AuchanSnackbar+Callback, Auchan.Android.Net", "Android.Widget.PopupWindow, Mono.Android:System.String, System.Private.CoreLib:Auchan.Common.Common.SnackbarStyle, Auchan.Common.Net:Auchan.Android.Common.DroidInfoMessageService, Auchan.Android.Net", this, new Object[]{popupWindow, str, Integer.valueOf(i), droidInfoMessageService});
        }
    }

    @Override // com.google.android.material.snackbar.BaseTransientBottomBar.BaseCallback
    public void onDismissed(Object obj, int i) {
        n_onDismissed(obj, i);
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
