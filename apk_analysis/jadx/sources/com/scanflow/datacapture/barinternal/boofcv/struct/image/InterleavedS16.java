package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedS16 extends InterleavedI16 {
    public InterleavedS16(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedS16() {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedS16 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedS16();
        }
        return new InterleavedS16(i, i2, this.numBands);
    }
}
