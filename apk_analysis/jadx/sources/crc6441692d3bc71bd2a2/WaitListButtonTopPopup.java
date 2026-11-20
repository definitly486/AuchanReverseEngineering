package crc6441692d3bc71bd2a2;

import android.content.Context;
import android.util.AttributeSet;
import android.view.View;
import android.widget.PopupWindow;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class WaitListButtonTopPopup extends PopupWindow implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Ecom.Product.WaitListButtonTopPopup, Auchan.Android.Net", WaitListButtonTopPopup.class, "");
    }

    public WaitListButtonTopPopup(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == WaitListButtonTopPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonTopPopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public WaitListButtonTopPopup(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == WaitListButtonTopPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonTopPopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public WaitListButtonTopPopup(View view, int i, int i2) {
        super(view, i, i2);
        if (getClass() == WaitListButtonTopPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonTopPopup, Auchan.Android.Net", "Android.Views.View, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{view, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public WaitListButtonTopPopup(int i, int i2) {
        super(i, i2);
        if (getClass() == WaitListButtonTopPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonTopPopup, Auchan.Android.Net", "System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i), Integer.valueOf(i2)});
        }
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
