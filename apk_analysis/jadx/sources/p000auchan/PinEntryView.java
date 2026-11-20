package p000auchan;

import android.content.Context;
import android.graphics.Rect;
import android.util.AttributeSet;
import android.view.KeyEvent;
import android.view.MotionEvent;
import android.widget.FrameLayout;
import android.widget.TextView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class PinEntryView extends FrameLayout implements IGCUserPeer, TextView.OnEditorActionListener {
    private ArrayList refList;

    private native void n_onDetachedFromWindow();

    private native boolean n_onEditorAction(TextView textView, int i, KeyEvent keyEvent);

    private native boolean n_onInterceptTouchEvent(MotionEvent motionEvent);

    private native boolean n_requestFocus(int i, Rect rect);

    public PinEntryView(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        if (getClass() == PinEntryView.class) {
            TypeManager.Activate("Auchan.Android.Controls.PinEntryView.PinEntryView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i), Integer.valueOf(i2)});
        }
    }

    public PinEntryView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == PinEntryView.class) {
            TypeManager.Activate("Auchan.Android.Controls.PinEntryView.PinEntryView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    public PinEntryView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == PinEntryView.class) {
            TypeManager.Activate("Auchan.Android.Controls.PinEntryView.PinEntryView, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public PinEntryView(Context context) {
        super(context);
        if (getClass() == PinEntryView.class) {
            TypeManager.Activate("Auchan.Android.Controls.PinEntryView.PinEntryView, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    @Override // android.view.ViewGroup, android.view.View
    public void onDetachedFromWindow() {
        n_onDetachedFromWindow();
    }

    @Override // android.view.ViewGroup
    public boolean onInterceptTouchEvent(MotionEvent motionEvent) {
        return n_onInterceptTouchEvent(motionEvent);
    }

    @Override // android.view.ViewGroup, android.view.View
    public boolean requestFocus(int i, Rect rect) {
        return n_requestFocus(i, rect);
    }

    @Override // android.widget.TextView.OnEditorActionListener
    public boolean onEditorAction(TextView textView, int i, KeyEvent keyEvent) {
        return n_onEditorAction(textView, i, keyEvent);
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
