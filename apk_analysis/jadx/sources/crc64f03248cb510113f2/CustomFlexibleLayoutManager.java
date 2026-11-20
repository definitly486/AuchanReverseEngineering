package crc64f03248cb510113f2;

import android.content.Context;
import android.util.AttributeSet;
import com.google.android.flexbox.FlexboxLayoutManager;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class CustomFlexibleLayoutManager extends FlexboxLayoutManager implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_canScrollHorizontally();

    private native boolean n_canScrollVertically();

    public CustomFlexibleLayoutManager(Context context) {
        super(context);
        if (getClass() == CustomFlexibleLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomFlexibleLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public CustomFlexibleLayoutManager(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == CustomFlexibleLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomFlexibleLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public CustomFlexibleLayoutManager(Context context, int i) {
        super(context, i);
        if (getClass() == CustomFlexibleLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomFlexibleLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, Integer.valueOf(i)});
        }
    }

    public CustomFlexibleLayoutManager(Context context, int i, int i2) {
        super(context, i, i2);
        if (getClass() == CustomFlexibleLayoutManager.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomFlexibleLayoutManager, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // com.google.android.flexbox.FlexboxLayoutManager, androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean canScrollVertically() {
        return n_canScrollVertically();
    }

    @Override // com.google.android.flexbox.FlexboxLayoutManager, androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean canScrollHorizontally() {
        return n_canScrollHorizontally();
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
