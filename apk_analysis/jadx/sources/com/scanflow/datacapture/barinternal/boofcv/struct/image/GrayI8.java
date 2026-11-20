package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public abstract class GrayI8 extends GrayI {
    public byte[] data;

    protected GrayI8(int i, int i2) {
        super(i, i2);
    }

    protected GrayI8() {
        this.data = new byte[0];
    }

    public void set(int i, int i2, int i3) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds: " + i + " " + i2);
        }
        this.data[getIndex(i, i2)] = (byte) i3;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public void _setData(Object obj) {
        this.data = (byte[]) obj;
    }
}
