package com.scanflow.datacapture.barinternal.boofcv.struct.convolve;

/* JADX INFO: loaded from: classes.dex */
public abstract class KernelBase {
    public int offset;
    public int width;

    public int getWidth() {
        return this.width;
    }

    public int getOffset() {
        return this.offset;
    }

    protected KernelBase(int i) {
        if (i < 0) {
            throw new IllegalArgumentException("Kernel width must be greater than zero not " + i);
        }
        this.width = i;
        this.offset = i / 2;
    }

    protected KernelBase(int i, int i2) {
        if (i <= 0) {
            throw new IllegalArgumentException("Kernel width must be greater than zero not " + i);
        }
        if (i2 < 0 || i2 >= i) {
            throw new IllegalArgumentException("The offset must be inside the kernel's bounds. o=" + i2 + " w=" + i);
        }
        this.width = i;
        this.offset = i2;
    }

    public int getRadius() {
        return this.width / 2;
    }
}
