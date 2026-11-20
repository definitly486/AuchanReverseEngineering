package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedS8 extends InterleavedI8 {
    public InterleavedS8(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedS8() {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedS8 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedS8();
        }
        return new InterleavedS8(i, i2, this.numBands);
    }
}
