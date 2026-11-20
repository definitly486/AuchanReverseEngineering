package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public abstract class InterleavedI16 extends InterleavedInteger {
    public short[] data;

    protected InterleavedI16(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    protected InterleavedI16() {
        this.data = new short[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    public String toString_element(int i) {
        return String.format("%04x", Integer.valueOf(this.data[i] & 65535));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Class getPrimitiveDataType() {
        return Short.TYPE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected void _setData(Object obj) {
        this.data = (short[]) obj;
    }
}
