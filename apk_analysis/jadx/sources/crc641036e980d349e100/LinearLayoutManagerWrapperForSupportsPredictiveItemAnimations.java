package crc641036e980d349e100;

import android.content.Context;
import android.util.AttributeSet;
import androidx.recyclerview.widget.LinearLayoutManager;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations extends LinearLayoutManager implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_supportsPredictiveItemAnimations();

    public LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context context) {
        super(context);
        if (getClass() == LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations(Context context, int i, boolean z) {
        super(context, i, z);
        if (getClass() == LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.LinearLayoutManagerWrapperForSupportsPredictiveItemAnimations, Auchan.Android.Net", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib:System.Boolean, System.Private.CoreLib", this, new Object[]{context, Integer.valueOf(i), Boolean.valueOf(z)});
        }
    }

    @Override // androidx.recyclerview.widget.LinearLayoutManager, androidx.recyclerview.widget.RecyclerView.LayoutManager
    public boolean supportsPredictiveItemAnimations() {
        return n_supportsPredictiveItemAnimations();
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
