package com.scanflow.datacapture.barinternal;

import android.graphics.RectF;
import com.google.mlkit.vision.barcode.common.Barcode;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class C {
    public final RectF a;
    public final Barcode b;
    public final String c;

    public C(RectF rectF, Barcode barcode, String str) {
        this.a = rectF;
        this.b = barcode;
        this.c = str;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof C)) {
            return false;
        }
        C c = (C) obj;
        return Intrinsics.areEqual(this.a, c.a) && Intrinsics.areEqual(this.b, c.b) && Intrinsics.areEqual(this.c, c.c);
    }

    public final int hashCode() {
        RectF rectF = this.a;
        int iHashCode = (rectF == null ? 0 : rectF.hashCode()) * 31;
        Barcode barcode = this.b;
        int iHashCode2 = (iHashCode + (barcode == null ? 0 : barcode.hashCode())) * 31;
        String str = this.c;
        return iHashCode2 + (str != null ? str.hashCode() : 0);
    }

    public final String toString() {
        return "BatchScanningResult(boundBox=" + this.a + ", value=" + this.b + ", zxingOutput=" + this.c + ')';
    }
}
