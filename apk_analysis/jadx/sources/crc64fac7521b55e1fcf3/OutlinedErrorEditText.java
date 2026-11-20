package crc64fac7521b55e1fcf3;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.util.AttributeSet;
import android.view.KeyEvent;
import com.google.android.material.textfield.TextInputEditText;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class OutlinedErrorEditText extends TextInputEditText implements IGCUserPeer {
    private ArrayList refList;

    private native Drawable n_getBackground();

    private native boolean n_onKeyPreIme(int i, KeyEvent keyEvent);

    private native void n_setBackground(Drawable drawable);

    public OutlinedErrorEditText(Context context) {
        super(context);
        if (getClass() == OutlinedErrorEditText.class) {
            TypeManager.Activate("Auchan.Android.Controls.OutlinedErrorEditText, Auchan.Android.Net", "Android.Content.Context, Mono.Android", this, new Object[]{context});
        }
    }

    public OutlinedErrorEditText(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        if (getClass() == OutlinedErrorEditText.class) {
            TypeManager.Activate("Auchan.Android.Controls.OutlinedErrorEditText, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new Object[]{context, attributeSet});
        }
    }

    public OutlinedErrorEditText(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        if (getClass() == OutlinedErrorEditText.class) {
            TypeManager.Activate("Auchan.Android.Controls.OutlinedErrorEditText, Auchan.Android.Net", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, System.Private.CoreLib", this, new Object[]{context, attributeSet, Integer.valueOf(i)});
        }
    }

    @Override // android.widget.TextView, android.view.View
    public boolean onKeyPreIme(int i, KeyEvent keyEvent) {
        return n_onKeyPreIme(i, keyEvent);
    }

    @Override // android.view.View
    public Drawable getBackground() {
        return n_getBackground();
    }

    @Override // android.view.View
    public void setBackground(Drawable drawable) {
        n_setBackground(drawable);
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
