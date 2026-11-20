package crc64f03248cb510113f2;

import android.os.Bundle;
import androidx.fragment.app.DialogFragment;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseSimpleDialogFragment_1 extends DialogFragment implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onHiddenChanged(boolean z);

    private native void n_onStart();

    private native void n_onStop();

    public BaseSimpleDialogFragment_1() {
        if (getClass() == BaseSimpleDialogFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseSimpleDialogFragment`1, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseSimpleDialogFragment_1(int i) {
        super(i);
        if (getClass() == BaseSimpleDialogFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Base.BaseSimpleDialogFragment`1, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onStart() {
        n_onStart();
    }

    @Override // androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onStop() {
        n_onStop();
    }

    @Override // androidx.fragment.app.Fragment
    public void onHiddenChanged(boolean z) {
        n_onHiddenChanged(z);
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
