package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedS32 extends InterleavedInteger {
    public int[] data;

    public InterleavedS32(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedS32() {
        this.data = new int[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    public String toString_element(int i) {
        return String.format("%08x", Integer.valueOf(this.data[i]));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Class getPrimitiveDataType() {
        return Integer.TYPE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected void _setData(Object obj) {
        this.data = (int[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedS32 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedS32();
        }
        return new InterleavedS32(i, i2, this.numBands);
    }
}
