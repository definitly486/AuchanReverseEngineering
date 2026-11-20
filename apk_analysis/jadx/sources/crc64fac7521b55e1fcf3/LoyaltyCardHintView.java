package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.util.AttributeSet;
import androidx.constraintlayout.widget.ConstraintLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class LoyaltyCardHintView extends ConstraintLayout implements IGCUserPeer {
    private ArrayList refList;

    private native int n_getVisibility();

    private native void n_setVisibility(int i);

    public LoyaltyCardHintView(Context context) {
        super(context);
        if (getClass() == LoyaltyCardHintView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardHintView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public LoyaltyCardHintView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == LoyaltyCardHintView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardHintView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public LoyaltyCardHintView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == LoyaltyCardHintView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardHintView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public LoyaltyCardHintView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == LoyaltyCardHintView.class) {
            TypeManager.Activate("Auchan.Android.Controls.LoyaltyCardHintView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    @Override // android.view.View
    public int getVisibility() {
        return n_getVisibility();
    }

    @Override // android.view.View
    public void setVisibility(int i) {
        n_setVisibility(i);
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
