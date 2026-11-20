package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.util.AttributeSet;
import android.view.View;
import android.widget.FrameLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class SkottieAnimationView extends FrameLayout implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onAttachedToWindow();

    private native void n_onDetachedFromWindow();

    private native void n_onSizeChanged(int i, int i2, int i3, int i4);

    private native void n_onVisibilityChanged(View view, int i);

    public SkottieAnimationView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == SkottieAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public SkottieAnimationView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == SkottieAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public SkottieAnimationView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == SkottieAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public SkottieAnimationView(Context context) {
        super(context);
        if (getClass() == SkottieAnimationView.class) {
            TypeManager.Activate("Auchan.Android.Controls.SkottieAnimationView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.View
    public void onSizeChanged(int i, int i2, int i3, int i4) {
        n_onSizeChanged(i, i2, i3, i4);
    }

    @Override // android.view.View
    public void onVisibilityChanged(View view, int i) {
        n_onVisibilityChanged(view, i);
    }

    @Override // android.view.ViewGroup, android.view.View
    public void onAttachedToWindow() {
        n_onAttachedToWindow();
    }

    @Override // android.view.ViewGroup, android.view.View
    public void onDetachedFromWindow() {
        n_onDetachedFromWindow();
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
