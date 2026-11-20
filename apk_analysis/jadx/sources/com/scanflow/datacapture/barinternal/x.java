package com.scanflow.datacapture.barinternal;

import android.graphics.RectF;
import android.util.Size;
import com.scanflow.ui.ar.ArObject;
import com.scanflow.ui.ar.ArObjectTracker;

/* JADX INFO: loaded from: classes3.dex */
public final class x extends ArObjectTracker {
    public final int a;
    public final int b;
    public final boolean c = false;

    public x(int i, int i2) {
        this.a = i;
        this.b = i2;
    }

    /* JADX WARN: Code duplicated, block: B:15:0x0033  */
    @Override // com.scanflow.ui.ar.ArObjectTracker
    public final void processObject(ArObject arObject) {
        if (arObject == null) {
            super.processObject((ArObject) null);
            return;
        }
        int sourceRotationDegrees = arObject.getSourceRotationDegrees();
        if (sourceRotationDegrees == 0) {
            arObject.getSourceSize();
        } else {
            if (sourceRotationDegrees != 90) {
                if (sourceRotationDegrees == 180) {
                    arObject.getSourceSize();
                } else if (sourceRotationDegrees != 270) {
                    throw new IllegalArgumentException("Unsupported rotation. Must be 0, 90, 180 or 270");
                }
            }
            new Size(arObject.getSourceSize().getHeight(), arObject.getSourceSize().getWidth());
        }
        RectF boundingBox = arObject.getBoundingBox();
        if (this.c) {
            float f = this.a / 2;
            boundingBox.left = (f - boundingBox.left) + f;
            boundingBox.right = f - (boundingBox.right - f);
        }
        super.processObject(new ArObject(arObject.component1(), boundingBox, new Size(this.a, this.b), arObject.component4(), arObject.component5(), arObject.component6(), true));
    }
}
