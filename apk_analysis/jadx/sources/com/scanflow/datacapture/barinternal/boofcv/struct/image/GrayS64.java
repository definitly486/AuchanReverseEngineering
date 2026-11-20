package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class GrayS64 extends ImageGray {
    public long[] data;

    public GrayS64(int i, int i2) {
        super(i, i2);
    }

    public GrayS64() {
        this.data = new long[0];
    }

    public long unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.S64;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public void _setData(Object obj) {
        this.data = (long[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayS64 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayS64();
        }
        return new GrayS64(i, i2);
    }
}
