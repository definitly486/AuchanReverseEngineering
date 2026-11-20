package crc6459152f4311e0a0b4;

import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RefundOrderMessageView_ScrollListener extends RecyclerView.OnScrollListener implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onScrolled(RecyclerView recyclerView, int i, int i2);

    public RefundOrderMessageView_ScrollListener() {
        if (getClass() == RefundOrderMessageView_ScrollListener.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.Views.RefundOrderMessageView+ScrollListener, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public RefundOrderMessageView_ScrollListener(RefundOrderMessageView refundOrderMessageView) {
        if (getClass() == RefundOrderMessageView_ScrollListener.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.Views.RefundOrderMessageView+ScrollListener, Auchan.Android.Net", "Auchan.Android.SupportChat.Views.RefundOrderMessageView, Auchan.Android.Net", this, new Object[]{refundOrderMessageView});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.OnScrollListener
    public void onScrolled(RecyclerView recyclerView, int i, int i2) {
        n_onScrolled(recyclerView, i, i2);
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
