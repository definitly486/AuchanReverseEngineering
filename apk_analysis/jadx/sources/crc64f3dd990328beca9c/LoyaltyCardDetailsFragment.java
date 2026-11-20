package crc64f3dd990328beca9c;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import crc64f03248cb510113f2.BaseToolbarFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyCardDetailsFragment extends BaseToolbarFragment_1 implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onAttach(Context context);

    private native void n_onViewCreated(View view, Bundle bundle);

    public LoyaltyCardDetailsFragment() {
        if (getClass() == LoyaltyCardDetailsFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyCardDetailsFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoyaltyCardDetailsFragment(int i) {
        super(i);
        if (getClass() == LoyaltyCardDetailsFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyCardDetailsFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.Fragment
    public void onAttach(Context context) {
        n_onAttach(context);
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseToolbarFragment_1, crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
