package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedF64 extends ImageInterleaved {
    public double[] data;

    public InterleavedF64(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedF64() {
        this.data = new double[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    public String toString_element(int i) {
        return String.format("%5f", Double.valueOf(this.data[i]));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Class getPrimitiveDataType() {
        return Double.TYPE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected void _setData(Object obj) {
        this.data = (double[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedF64 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedF64();
        }
        return new InterleavedF64(i, i2, this.numBands);
    }
}
