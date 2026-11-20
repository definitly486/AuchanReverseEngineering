package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class GrayF32 extends GrayF {
    public float[] data;

    public GrayF32(int i, int i2) {
        super(i, i2);
    }

    public GrayF32() {
        this.data = new float[0];
    }

    public float get(int i, int i2) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds: " + i + " " + i2);
        }
        return unsafe_get(i, i2);
    }

    public float unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)];
    }

    public void set(int i, int i2, float f) {
        if (!isInBounds(i, i2)) {
            throw new ImageAccessException("Requested pixel is out of bounds: " + i + " " + i2);
        }
        unsafe_set(i, i2, f);
    }

    public void unsafe_set(int i, int i2, float f) {
        this.data[getIndex(i, i2)] = f;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public void _setData(Object obj) {
        this.data = (float[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayF32 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayF32();
        }
        return new GrayF32(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.F32;
    }
}
