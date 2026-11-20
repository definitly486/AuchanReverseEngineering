package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class GrayF64 extends GrayF {
    public double[] data;

    public GrayF64(int i, int i2) {
        super(i, i2);
    }

    public GrayF64() {
        this.data = new double[0];
    }

    public double get(int i, int i2) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds: " + i + " " + i2);
        }
        return unsafe_get(i, i2);
    }

    public double unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public void _setData(Object obj) {
        this.data = (double[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayF64 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayF64();
        }
        return new GrayF64(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.F64;
    }
}
