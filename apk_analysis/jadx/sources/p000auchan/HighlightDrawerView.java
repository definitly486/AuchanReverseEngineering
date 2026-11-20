package p000auchan;

import android.content.Context;
import android.graphics.Canvas;
import android.util.AttributeSet;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class HighlightDrawerView extends View implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onDraw(Canvas canvas);

    public HighlightDrawerView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == HighlightDrawerView.class) {
            TypeManager.Activate("Auchan.Android.Common.HighlightScreen.HighlightDrawerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public HighlightDrawerView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == HighlightDrawerView.class) {
            TypeManager.Activate("Auchan.Android.Common.HighlightScreen.HighlightDrawerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public HighlightDrawerView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == HighlightDrawerView.class) {
            TypeManager.Activate("Auchan.Android.Common.HighlightScreen.HighlightDrawerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public HighlightDrawerView(Context context) {
        super(context);
        if (getClass() == HighlightDrawerView.class) {
            TypeManager.Activate("Auchan.Android.Common.HighlightScreen.HighlightDrawerView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.View
    public void onDraw(Canvas canvas) {
        n_onDraw(canvas);
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
