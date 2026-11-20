package p000auchan;

import android.graphics.Typeface;
import android.text.TextPaint;
import android.text.style.MetricAffectingSpan;
import java.util.ArrayList;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes.dex */
public class HighlightedTextView_TypefaceSpan extends MetricAffectingSpan implements IGCUserPeer {
    private ArrayList refList;

    private native void n_updateDrawState(TextPaint textPaint);

    private native void n_updateMeasureState(TextPaint textPaint);

    public HighlightedTextView_TypefaceSpan() {
        if (getClass() == HighlightedTextView_TypefaceSpan.class) {
            TypeManager.Activate("Auchan.Android.Base.HighlightedTextView+TypefaceSpan, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public HighlightedTextView_TypefaceSpan(Typeface typeface) {
        if (getClass() == HighlightedTextView_TypefaceSpan.class) {
            TypeManager.Activate("Auchan.Android.Base.HighlightedTextView+TypefaceSpan, Auchan.Android.Net", "Android.Graphics.Typeface, Mono.Android", this, new Object[]{typeface});
        }
    }

    @Override // android.text.style.CharacterStyle
    public void updateDrawState(TextPaint textPaint) {
        n_updateDrawState(textPaint);
    }

    @Override // android.text.style.MetricAffectingSpan
    public void updateMeasureState(TextPaint textPaint) {
        n_updateMeasureState(textPaint);
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
