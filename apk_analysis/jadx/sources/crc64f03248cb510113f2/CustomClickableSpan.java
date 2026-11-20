package crc64f03248cb510113f2;

import android.text.TextPaint;
import android.text.style.ClickableSpan;
import android.view.View;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public class CustomClickableSpan extends ClickableSpan implements IGCUserPeer {
    private ArrayList refList;

    private native void n_onClick(View view);

    private native void n_updateDrawState(TextPaint textPaint);

    public CustomClickableSpan() {
        if (getClass() == CustomClickableSpan.class) {
            TypeManager.Activate("Auchan.Android.Base.CustomClickableSpan, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    @Override // android.text.style.ClickableSpan
    public void onClick(View view) {
        n_onClick(view);
    }

    @Override // android.text.style.ClickableSpan, android.text.style.CharacterStyle
    public void updateDrawState(TextPaint textPaint) {
        n_updateDrawState(textPaint);
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
