package crc64f3dd990328beca9c;

import android.os.Bundle;
import android.view.View;
import androidx.core.widget.NestedScrollView;
import crc64f03248cb510113f2.BaseToolbarFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyCardPointsExpirationFragment extends BaseToolbarFragment_1 implements IGCUserPeer, NestedScrollView.OnScrollChangeListener {
    private ArrayList refList;

    private native void n_onScrollChange(NestedScrollView nestedScrollView, int i, int i2, int i3, int i4);

    private native void n_onViewCreated(View view, Bundle bundle);

    public LoyaltyCardPointsExpirationFragment() {
        if (getClass() == LoyaltyCardPointsExpirationFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyCardPointsExpirationFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public LoyaltyCardPointsExpirationFragment(int i) {
        super(i);
        if (getClass() == LoyaltyCardPointsExpirationFragment.class) {
            TypeManager.Activate("Auchan.Android.LoyaltyProgram.LoyaltyCardPointsExpirationFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.core.widget.NestedScrollView.OnScrollChangeListener
    public void onScrollChange(NestedScrollView nestedScrollView, int i, int i2, int i3, int i4) {
        n_onScrollChange(nestedScrollView, i, i2, i3, i4);
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
