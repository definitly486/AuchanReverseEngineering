package com.scanflow.datacapture.barinternal;

import android.graphics.Paint;
import androidx.core.view.ViewCompat;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.f, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0088f {
    public C0088f(float f) {
        Paint paint = new Paint();
        paint.setTextSize(f);
        paint.setColor(-1);
        paint.setStyle(Paint.Style.FILL);
        paint.setAntiAlias(false);
        paint.setAlpha(255);
        Paint paint2 = new Paint();
        paint2.setTextSize(f);
        paint2.setColor(ViewCompat.MEASURED_STATE_MASK);
        paint2.setStyle(Paint.Style.FILL_AND_STROKE);
        paint2.setStrokeWidth(f / 8);
        paint2.setAntiAlias(false);
        paint2.setAlpha(255);
    }
}
