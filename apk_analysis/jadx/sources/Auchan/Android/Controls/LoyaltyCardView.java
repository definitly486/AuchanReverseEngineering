package Auchan.Android.Controls;

import android.content.Context;
import android.util.AttributeSet;
import crc64f03248cb510113f2.BaseCustomView_1;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.Runtime;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class LoyaltyCardView extends BaseCustomView_1 implements IGCUserPeer {
    public static final String __md_methods = "";
    private ArrayList refList;

    static {
        Runtime.register("Auchan.Android.Controls.LoyaltyCardView, Auchan.Android.Net", LoyaltyCardView.class, "");
    }

    public LoyaltyCardView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == LoyaltyCardView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public LoyaltyCardView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == LoyaltyCardView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public LoyaltyCardView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == LoyaltyCardView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public LoyaltyCardView(Context context) {
        super(context);
        if (getClass() == LoyaltyCardView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // crc64f03248cb510113f2.BaseCustomView_1, crc64f03248cb510113f2.BaseCustomView, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseCustomView_1, crc64f03248cb510113f2.BaseCustomView, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
