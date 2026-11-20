package p000auchan;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Rect;
import android.util.AttributeSet;
import android.view.View;
import android.view.ViewParent;
import android.widget.FrameLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class DynamicShadowLayout extends FrameLayout implements IGCUserPeer {
    private ArrayList refList;

    private native ViewParent n_invalidateChildInParent(int[] iArr, Rect rect);

    private native void n_onDescendantInvalidated(View view, View view2);

    private native void n_onDraw(Canvas canvas);

    private native void n_onSizeChanged(int i, int i2, int i3, int i4);

    public DynamicShadowLayout(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == DynamicShadowLayout.class) {
            TypeManager.Activate("Auchan.Android.Controls.DynamicShadows.DynamicShadowLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public DynamicShadowLayout(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == DynamicShadowLayout.class) {
            TypeManager.Activate("Auchan.Android.Controls.DynamicShadows.DynamicShadowLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public DynamicShadowLayout(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == DynamicShadowLayout.class) {
            TypeManager.Activate("Auchan.Android.Controls.DynamicShadows.DynamicShadowLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public DynamicShadowLayout(Context context) {
        super(context);
        if (getClass() == DynamicShadowLayout.class) {
            TypeManager.Activate("Auchan.Android.Controls.DynamicShadows.DynamicShadowLayout, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.View
    public void onSizeChanged(int i, int i2, int i3, int i4) {
        n_onSizeChanged(i, i2, i3, i4);
    }

    @Override // android.view.View
    public void onDraw(Canvas canvas) {
        n_onDraw(canvas);
    }

    @Override // android.view.ViewGroup, android.view.ViewParent
    public void onDescendantInvalidated(View view, View view2) {
        n_onDescendantInvalidated(view, view2);
    }

    @Override // android.view.ViewGroup, android.view.ViewParent
    public ViewParent invalidateChildInParent(int[] iArr, Rect rect) {
        return n_invalidateChildInParent(iArr, rect);
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
