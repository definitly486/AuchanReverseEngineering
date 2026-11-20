package crc64da0865216948f4da;

import android.content.Context;
import android.graphics.PointF;
import androidx.recyclerview.widget.LinearSmoothScroller;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SupportChatLayoutManager_CustomLinearSmoothScroller extends LinearSmoothScroller implements IGCUserPeer {
    private ArrayList refList;

    private native PointF n_computeScrollVectorForPosition(int i);

    private native int n_getVerticalSnapPreference();

    public SupportChatLayoutManager_CustomLinearSmoothScroller(Context context) {
        super(context);
        if (getClass() == SupportChatLayoutManager_CustomLinearSmoothScroller.class) {
            TypeManager.Activate("Auchan.Android.SupportChat.SupportChatLayoutManager+CustomLinearSmoothScroller, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.SmoothScroller
    public PointF computeScrollVectorForPosition(int i) {
        return n_computeScrollVectorForPosition(i);
    }

    @Override // androidx.recyclerview.widget.LinearSmoothScroller
    public int getVerticalSnapPreference() {
        return n_getVerticalSnapPreference();
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
