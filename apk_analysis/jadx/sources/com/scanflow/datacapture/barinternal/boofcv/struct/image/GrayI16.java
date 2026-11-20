package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public abstract class GrayI16 extends GrayI {
    public short[] data;

    protected GrayI16(int i, int i2) {
        super(i, i2);
    }

    protected GrayI16() {
        this.data = new short[0];
    }

    public void set(int i, int i2, int i3) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds: " + i + " " + i2);
        }
        this.data[getIndex(i, i2)] = (short) i3;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public void _setData(Object obj) {
        this.data = (short[]) obj;
    }
}
