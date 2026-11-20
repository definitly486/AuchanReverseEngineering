package crc6441692d3bc71bd2a2;

import android.content.Context;
import android.util.AttributeSet;
import android.view.View;
import crc64fac7521b55e1fcf3.HintPopupBase;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class WaitListButtonPopup extends HintPopupBase implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Ecom.Product.WaitListButtonPopup, Auchan.Android.Net", WaitListButtonPopup.class, "");
    }

    public WaitListButtonPopup(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == WaitListButtonPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonPopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public WaitListButtonPopup(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == WaitListButtonPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonPopup, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public WaitListButtonPopup(View view, int i, int i2) {
        super(view, i, i2);
        if (getClass() == WaitListButtonPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonPopup, Auchan.Android.Net", "Android.Views.View, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{view, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public WaitListButtonPopup(int i, int i2) {
        super(i, i2);
        if (getClass() == WaitListButtonPopup.class) {
            TypeManager.Activate("Auchan.Android.Ecom.Product.WaitListButtonPopup, Auchan.Android.Net", "System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // crc64fac7521b55e1fcf3.HintPopupBase, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64fac7521b55e1fcf3.HintPopupBase, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
