package crc641036e980d349e100;

import android.content.Context;
import android.util.AttributeSet;
import android.view.View;
import android.widget.PopupWindow;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ExpressDeliveryAvailablePopup extends PopupWindow implements IGCUserPeer {
    private ArrayList refList;

    private native void n_dismiss();

    public ExpressDeliveryAvailablePopup(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == ExpressDeliveryAvailablePopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.ExpressDeliveryAvailablePopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public ExpressDeliveryAvailablePopup(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == ExpressDeliveryAvailablePopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.ExpressDeliveryAvailablePopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public ExpressDeliveryAvailablePopup(View view, int i, int i2) {
        super(view, i, i2);
        if (getClass() == ExpressDeliveryAvailablePopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.ExpressDeliveryAvailablePopup, Auchan.Android.Net", "Android.Views.View, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{view, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public ExpressDeliveryAvailablePopup(int i, int i2) {
        super(i, i2);
        if (getClass() == ExpressDeliveryAvailablePopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.AddressStoreSelection.ExpressDeliveryAvailablePopup, Auchan.Android.Net", "System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // android.widget.PopupWindow
    public void dismiss() {
        n_dismiss();
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
