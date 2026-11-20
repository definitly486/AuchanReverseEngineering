package crc64f03248cb510113f2;

import android.os.Bundle;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class BlockedAccountFragment extends BaseDialogFragment_1 implements IGCUserPeer, View.OnClickListener {
    private ArrayList refList;

    private native void n_onClick(View view);

    private native void n_onViewCreated(View view, Bundle bundle);

    public BlockedAccountFragment() {
        if (getClass() == BlockedAccountFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.BlockedAccountFragment, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BlockedAccountFragment(int i) {
        super(i);
        if (getClass() == BlockedAccountFragment.class) {
            TypeManager.Activate("Auchan.Android.Base.BlockedAccountFragment, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseDialogFragment, androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // android.view.View.OnClickListener
    public void onClick(View view) {
        n_onClick(view);
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
