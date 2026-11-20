package p000auchan;

import android.content.Context;
import android.util.AttributeSet;
import androidx.core.widget.NestedScrollView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class FadingEdgeNestedScrollView extends NestedScrollView implements IGCUserPeer {
    private ArrayList refList;

    private native float n_getBottomFadingEdgeStrength();

    private native float n_getTopFadingEdgeStrength();

    public FadingEdgeNestedScrollView(Context context) {
        super(context);
        if (getClass() == FadingEdgeNestedScrollView.class) {
            TypeManager.Activate("Auchan.Android.Controls.FadingEdgeNestedScrollView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public FadingEdgeNestedScrollView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == FadingEdgeNestedScrollView.class) {
            TypeManager.Activate("Auchan.Android.Controls.FadingEdgeNestedScrollView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public FadingEdgeNestedScrollView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == FadingEdgeNestedScrollView.class) {
            TypeManager.Activate("Auchan.Android.Controls.FadingEdgeNestedScrollView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    @Override // androidx.core.widget.NestedScrollView, android.view.View
    public float getTopFadingEdgeStrength() {
        return n_getTopFadingEdgeStrength();
    }

    @Override // androidx.core.widget.NestedScrollView, android.view.View
    public float getBottomFadingEdgeStrength() {
        return n_getBottomFadingEdgeStrength();
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
