package crc64f03248cb510113f2;

import android.view.View;
import com.google.android.material.bottomsheet.BottomSheetBehavior;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class BottomSheetBehaviorCallback extends BottomSheetBehavior.BottomSheetCallback implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onSlide(View view, float f);

    private native void n_onStateChanged(View view, int i);

    public BottomSheetBehaviorCallback() {
        if (getClass() == BottomSheetBehaviorCallback.class) {
            TypeManager.Activate("Auchan.Android.Base.BottomSheetBehaviorCallback, Auchan.Android.Net", "", this, new Object[0]);
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
