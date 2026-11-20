package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageBorder_F32 extends ImageBorder {
    public abstract float getOutside(int i, int i2);

    protected ImageBorder_F32() {
    }

    public float get(int i, int i2) {
        if (((GrayF32) this.image).isInBounds(i, i2)) {
            return ((GrayF32) this.image).get(i, i2);
        }
        return getOutside(i, i2);
    }
}
