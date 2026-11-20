package p000auchan.p001Android.SelfScan;

import android.content.Context;
import android.graphics.Canvas;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.widget.FrameLayout;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class AuchanBarcodeView extends FrameLayout implements IGCUserPeer {
    private ArrayList refList;

    private native void n_dispatchDraw(Canvas canvas);

    private native void n_onSizeChanged(int i, int i2, int i3, int i4);

    private native boolean n_onTouchEvent(MotionEvent motionEvent);

    public AuchanBarcodeView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == AuchanBarcodeView.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.AuchanBarcodeView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public AuchanBarcodeView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == AuchanBarcodeView.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.AuchanBarcodeView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public AuchanBarcodeView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == AuchanBarcodeView.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.AuchanBarcodeView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public AuchanBarcodeView(Context context) {
        super(context);
        if (getClass() == AuchanBarcodeView.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.AuchanBarcodeView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.View
    public void onSizeChanged(int i, int i2, int i3, int i4) {
        n_onSizeChanged(i, i2, i3, i4);
    }

    @Override // android.view.ViewGroup, android.view.View
    public void dispatchDraw(Canvas canvas) {
        n_dispatchDraw(canvas);
    }

    @Override // android.view.View
    public boolean onTouchEvent(MotionEvent motionEvent) {
        return n_onTouchEvent(motionEvent);
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
