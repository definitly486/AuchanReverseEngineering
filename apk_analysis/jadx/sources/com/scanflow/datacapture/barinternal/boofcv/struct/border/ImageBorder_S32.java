package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageBorder_S32 extends ImageBorder {
    public abstract int getOutside(int i, int i2);

    protected ImageBorder_S32() {
    }

    public int get(int i, int i2) {
        if (((GrayI) this.image).isInBounds(i, i2)) {
            return ((GrayI) this.image).get(i, i2);
        }
        return getOutside(i, i2);
    }
}
