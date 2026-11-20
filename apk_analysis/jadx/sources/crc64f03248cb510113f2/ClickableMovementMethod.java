package crc64f03248cb510113f2;

import android.text.Spannable;
import android.text.method.BaseMovementMethod;
import android.view.MotionEvent;
import android.widget.TextView;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class ClickableMovementMethod extends BaseMovementMethod implements IGCUserPeer {
    private ArrayList refList;

    private native boolean n_canSelectArbitrarily();

    private native void n_initialize(TextView textView, Spannable spannable);

    private native boolean n_onTouchEvent(TextView textView, Spannable spannable, MotionEvent motionEvent);

    public ClickableMovementMethod() {
        if (getClass() == ClickableMovementMethod.class) {
            TypeManager.Activate("Auchan.Android.Base.ClickableMovementMethod, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.text.method.BaseMovementMethod, android.text.method.MovementMethod
    public boolean onTouchEvent(TextView textView, Spannable spannable, MotionEvent motionEvent) {
        return n_onTouchEvent(textView, spannable, motionEvent);
    }

    @Override // android.text.method.BaseMovementMethod, android.text.method.MovementMethod
    public boolean canSelectArbitrarily() {
        return n_canSelectArbitrarily();
    }

    @Override // android.text.method.BaseMovementMethod, android.text.method.MovementMethod
    public void initialize(TextView textView, Spannable spannable) {
        n_initialize(textView, spannable);
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
