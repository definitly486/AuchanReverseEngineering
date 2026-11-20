package com.scanflow.datacapture.barinternal;

import android.graphics.Bitmap;
import android.graphics.RectF;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class B {
    public final RectF a;
    public final Bitmap b;

    public B(Bitmap croppedBitmap, RectF boundBox) {
        Intrinsics.checkNotNullParameter(boundBox, "boundBox");
        Intrinsics.checkNotNullParameter(croppedBitmap, "croppedBitmap");
        this.a = boundBox;
        this.b = croppedBitmap;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof B)) {
            return false;
        }
        B b = (B) obj;
        return Intrinsics.areEqual(this.a, b.a) && Intrinsics.areEqual(this.b, b.b);
    }

    public final int hashCode() {
        return this.b.hashCode() + (this.a.hashCode() * 31);
    }

    public final String toString() {
        return "BatchScanningModel(boundBox=" + this.a + ", croppedBitmap=" + this.b + ')';
    }
}
