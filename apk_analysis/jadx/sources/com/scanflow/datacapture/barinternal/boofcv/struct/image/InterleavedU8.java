package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import com.google.common.primitives.UnsignedBytes;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedU8 extends InterleavedI8 {
    public InterleavedU8(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedU8() {
    }

    public int getBand(int i, int i2, int i3) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds.");
        }
        if (i3 < 0 || i3 >= this.numBands) {
            throw new ImageAccessException("Invalid band requested.");
        }
        return this.data[getIndex(i, i2, i3)] & UnsignedBytes.MAX_VALUE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedU8 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedU8();
        }
        return new InterleavedU8(i, i2, this.numBands);
    }
}
