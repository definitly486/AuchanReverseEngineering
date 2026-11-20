package crc646064278e9258e0c4;

import android.view.View;
import com.google.android.material.bottomsheet.BottomSheetBehavior;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LockableBottomSheetCallback extends BottomSheetBehavior.BottomSheetCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onSlide(View view, float f);

    private native void n_onStateChanged(View view, int i);

    public LockableBottomSheetCallback() {
        if (getClass() == LockableBottomSheetCallback.class) {
            TypeManager.Activate("Auchan.Android.Common.LockableBottomSheetCallback, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LockableBottomSheetCallback(BottomSheetBehavior bottomSheetBehavior) {
        if (getClass() == LockableBottomSheetCallback.class) {
            TypeManager.Activate("Auchan.Android.Common.LockableBottomSheetCallback, Auchan.Android.Net", "Google.Android.Material.BottomSheet.BottomSheetBehavior, Xamarin.Google.Android.Material", this, new Object[]{bottomSheetBehavior});
        }
    }

    @Override // com.google.android.material.bottomsheet.BottomSheetBehavior.BottomSheetCallback
    public void onSlide(View view, float f) {
        n_onSlide(view, f);
    }

    @Override // com.google.android.material.bottomsheet.BottomSheetBehavior.BottomSheetCallback
    public void onStateChanged(View view, int i) {
        n_onStateChanged(view, i);
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
