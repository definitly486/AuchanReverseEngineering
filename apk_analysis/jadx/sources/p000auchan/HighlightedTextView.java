package p000auchan;

import android.animation.ValueAnimator;
import android.content.Context;
import android.util.AttributeSet;
import android.widget.TextView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class HighlightedTextView extends TextView implements IGCUserPeer, ValueAnimator.AnimatorUpdateListener {
    private ArrayList refList;

    private native void n_onAnimationUpdate(ValueAnimator valueAnimator);

    public HighlightedTextView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == HighlightedTextView.class) {
            TypeManager.Activate("Auchan.Android.Base.HighlightedTextView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public HighlightedTextView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == HighlightedTextView.class) {
            TypeManager.Activate("Auchan.Android.Base.HighlightedTextView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public HighlightedTextView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == HighlightedTextView.class) {
            TypeManager.Activate("Auchan.Android.Base.HighlightedTextView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public HighlightedTextView(Context context) {
        super(context);
        if (getClass() == HighlightedTextView.class) {
            TypeManager.Activate("Auchan.Android.Base.HighlightedTextView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.animation.ValueAnimator.AnimatorUpdateListener
    public void onAnimationUpdate(ValueAnimator valueAnimator) {
        n_onAnimationUpdate(valueAnimator);
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
