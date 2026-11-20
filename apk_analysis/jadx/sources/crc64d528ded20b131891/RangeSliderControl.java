package crc64d528ded20b131891;

import android.content.Context;
import android.graphics.Canvas;
import android.os.Parcelable;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.widget.ImageView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class RangeSliderControl extends ImageView implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_isEnabled();

    private native void n_onDraw(Canvas canvas);

    private native void n_onMeasure(int i, int i2);

    private native void n_onRestoreInstanceState(Parcelable parcelable);

    private native Parcelable n_onSaveInstanceState();

    private native boolean n_onTouchEvent(MotionEvent motionEvent);

    private native void n_setEnabled(boolean z);

    public RangeSliderControl(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == RangeSliderControl.class) {
            TypeManager.Activate("Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public RangeSliderControl(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == RangeSliderControl.class) {
            TypeManager.Activate("Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public RangeSliderControl(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == RangeSliderControl.class) {
            TypeManager.Activate("Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public RangeSliderControl(Context context) {
        super(context);
        if (getClass() == RangeSliderControl.class) {
            TypeManager.Activate("Xamarin.RangeSlider.RangeSliderControl, Xamarin.RangeSlider.Droid", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.View
    public boolean isEnabled() {
        return n_isEnabled();
    }

    @Override // android.view.View
    public void setEnabled(boolean z) {
        n_setEnabled(z);
    }

    @Override // android.view.View
    public boolean onTouchEvent(MotionEvent motionEvent) {
        return n_onTouchEvent(motionEvent);
    }

    @Override // android.widget.ImageView, android.view.View
    public void onMeasure(int i, int i2) {
        n_onMeasure(i, i2);
    }

    @Override // android.widget.ImageView, android.view.View
    public void onDraw(Canvas canvas) {
        n_onDraw(canvas);
    }

    @Override // android.view.View
    public Parcelable onSaveInstanceState() {
        return n_onSaveInstanceState();
    }

    @Override // android.view.View
    public void onRestoreInstanceState(Parcelable parcelable) {
        n_onRestoreInstanceState(parcelable);
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
