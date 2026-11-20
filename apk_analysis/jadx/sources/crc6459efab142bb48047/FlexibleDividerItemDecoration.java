package crc6459efab142bb48047;

import android.graphics.Canvas;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class FlexibleDividerItemDecoration extends VerticalSpaceItemDecoration implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onDraw(Canvas canvas, RecyclerView recyclerView, RecyclerView.State state);

    public FlexibleDividerItemDecoration() {
        if (getClass() == FlexibleDividerItemDecoration.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.FlexibleDividerItemDecoration, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public FlexibleDividerItemDecoration(int i, boolean z) {
        if (getClass() == FlexibleDividerItemDecoration.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.FlexibleDividerItemDecoration, Auchan.Android.Net", "System.Int32, System.Private.CoreLib:System.Boolean, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i), Boolean.valueOf(z)});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.ItemDecoration
    public void onDraw(Canvas canvas, RecyclerView recyclerView, RecyclerView.State state) {
        n_onDraw(canvas, recyclerView, state);
    }

    @Override // crc6459efab142bb48047.VerticalSpaceItemDecoration, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc6459efab142bb48047.VerticalSpaceItemDecoration, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
