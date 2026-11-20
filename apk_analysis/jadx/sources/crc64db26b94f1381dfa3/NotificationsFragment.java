package crc64db26b94f1381dfa3;

import android.os.Bundle;
import android.view.View;
import androidx.swiperefreshlayout.widget.SwipeRefreshLayout;
import crc64f03248cb510113f2.BaseToolbarFragment_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class NotificationsFragment extends BaseToolbarFragment_1 implements IGCUserPeer, SwipeRefreshLayout.OnRefreshListener {
    private ArrayList refList;

    private native void n_onRefresh();

    private native void n_onViewCreated(View view, Bundle bundle);

    public NotificationsFragment() {
        if (getClass() == NotificationsFragment.class) {
            TypeManager.Activate("Auchan.Android.Notifications.NotificationsFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public NotificationsFragment(int i) {
        super(i);
        if (getClass() == NotificationsFragment.class) {
            TypeManager.Activate("Auchan.Android.Notifications.NotificationsFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // androidx.swiperefreshlayout.widget.SwipeRefreshLayout.OnRefreshListener
    public void onRefresh() {
        n_onRefresh();
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
