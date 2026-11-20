package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import com.google.common.primitives.UnsignedBytes;

/* JADX INFO: loaded from: classes.dex */
public abstract class InterleavedI8 extends InterleavedInteger {
    public byte[] data;

    protected InterleavedI8(int i, int i2, int i3) {
        super(i, i2, i3);
    }

    protected InterleavedI8() {
        this.data = new byte[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    public String toString_element(int i) {
        return String.format("%02x", Integer.valueOf(this.data[i] & UnsignedBytes.MAX_VALUE));
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected Class getPrimitiveDataType() {
        return Byte.TYPE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved
    protected void _setData(Object obj) {
        this.data = (byte[]) obj;
    }
}
