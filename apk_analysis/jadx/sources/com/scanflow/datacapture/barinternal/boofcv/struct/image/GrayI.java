package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public abstract class GrayI extends ImageGray {
    public abstract int unsafe_get(int i, int i2);

    protected GrayI(int i, int i2) {
        super(i, i2);
    }

    protected GrayI() {
    }

    public int get(int i, int i2) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds: " + i + " " + i2);
        }
        return unsafe_get(i, i2);
    }
}
