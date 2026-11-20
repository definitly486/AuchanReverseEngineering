package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageBorder_F64 extends ImageBorder {
    public abstract double getOutside(int i, int i2);

    protected ImageBorder_F64() {
    }

    public double get(int i, int i2) {
        if (((GrayF64) this.image).isInBounds(i, i2)) {
            return ((GrayF64) this.image).get(i, i2);
        }
        return getOutside(i, i2);
    }
}
