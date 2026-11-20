package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class InterleavedF32 extends ImageInterleaved {
    public float[] data;

    public InterleavedF32(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    public InterleavedF32() {
        this.data = new float[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    public String toString_element(int i) {
        return String.format("%5f", Float.valueOf(this.data[i]));
    }

    public float getBand(int i, int i2, int i3) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds.");
        }
        if (i3 < 0 || i3 >= this.numBands) {
            throw new ImageAccessException("Invalid band requested.");
        }
        return this.data[getIndex(i, i2, i3)];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Class getPrimitiveDataType() {
        return Float.TYPE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected void _setData(Object obj) {
        this.data = (float[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public InterleavedF32 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new InterleavedF32();
        }
        return new InterleavedF32(i, i2, this.numBands);
    }
}
