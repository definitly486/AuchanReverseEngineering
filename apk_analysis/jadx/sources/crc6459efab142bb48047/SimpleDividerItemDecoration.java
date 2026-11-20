package crc6459efab142bb48047;

import android.content.Context;
import android.graphics.Canvas;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleDividerItemDecoration extends RecyclerView.ItemDecoration implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onDrawOver(Canvas canvas, RecyclerView recyclerView, RecyclerView.State state);

    public SimpleDividerItemDecoration() {
        if (getClass() == SimpleDividerItemDecoration.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.SimpleDividerItemDecoration, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public SimpleDividerItemDecoration(Context context) {
        if (getClass() == SimpleDividerItemDecoration.class) {
            TypeManager.Activate("Auchan.Android.Common.UiUtils.SimpleDividerItemDecoration, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.ItemDecoration
    public void onDrawOver(Canvas canvas, RecyclerView recyclerView, RecyclerView.State state) {
        n_onDrawOver(canvas, recyclerView, state);
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
