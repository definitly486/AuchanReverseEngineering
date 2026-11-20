package crc64f03248cb510113f2;

import android.content.Context;
import android.util.AttributeSet;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class CustomSizeLinearLayoutManager extends LinearLayoutManager implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_canScrollHorizontally();

    private native boolean n_canScrollVertically();

    private native boolean n_checkLayoutParams(RecyclerView.LayoutParams layoutParams);

    public CustomSizeLinearLayoutManager(Context context) {
        super(context);
        if (getClass() == CustomSizeLinearLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomSizeLinearLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public CustomSizeLinearLayoutManager(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == CustomSizeLinearLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomSizeLinearLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public CustomSizeLinearLayoutManager(Context context, int i, boolean z) {
        super(context, i, z);
        if (getClass() == CustomSizeLinearLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomSizeLinearLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib:System.Boolean, System.Private.CoreLib", this, new Object[]{context, Integer.valueOf(i), Boolean.valueOf(z)});
        }
    }

    @Override // androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean checkLayoutParams(RecyclerView.LayoutParams layoutParams) {
        return n_checkLayoutParams(layoutParams);
    }

    @Override // androidx.recyclerview.widget.LinearLayoutManager, androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean canScrollHorizontally() {
        return n_canScrollHorizontally();
    }

    @Override // androidx.recyclerview.widget.LinearLayoutManager, androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean canScrollVertically() {
        return n_canScrollVertically();
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
