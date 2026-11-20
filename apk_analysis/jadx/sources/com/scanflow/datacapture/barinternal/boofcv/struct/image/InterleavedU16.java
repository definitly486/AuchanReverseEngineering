package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedU16 extends InterleavedI16 {
    public InterleavedU16(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedU16() {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedU16 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedU16();
        }
        return new InterleavedU16(i, i2, this.numBands);
    }
}
