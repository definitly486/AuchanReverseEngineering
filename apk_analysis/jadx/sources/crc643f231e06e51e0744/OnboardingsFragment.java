package crc643f231e06e51e0744;

import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseDialogFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OnboardingsFragment extends BaseDialogFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onCreate(Bundle bundle);

    private native void n_onPause();

    private native void n_onResume();

    private native void n_onViewCreated(View view, Bundle bundle);

    public OnboardingsFragment() {
        if (getClass() == OnboardingsFragment.class) {
            TypeManager.Activate("Auchan.Android.Onboardings.OnboardingsFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public OnboardingsFragment(int i) {
        super(i);
        if (getClass() == OnboardingsFragment.class) {
            TypeManager.Activate("Auchan.Android.Onboardings.OnboardingsFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment_1, androidx.fragment.app.DialogFragment, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onResume() {
        n_onResume();
    }

    @Override // androidx.fragment.app.Fragment
    public void onPause() {
        n_onPause();
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
