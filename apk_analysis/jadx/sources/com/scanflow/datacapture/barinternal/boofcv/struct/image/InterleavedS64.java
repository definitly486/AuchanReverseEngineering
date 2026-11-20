package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedS64 extends ImageInterleaved {
    public long[] data;

    public InterleavedS64(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedS64() {
        this.data = new long[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    public String toString_element(int i) {
        return String.format("%016x", Long.valueOf(this.data[i]));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Class getPrimitiveDataType() {
        return Long.TYPE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected void _setData(Object obj) {
        this.data = (long[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedS64 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedS64();
        }
        return new InterleavedS64(i, i2, this.numBands);
    }
}
