package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class GrayS8 extends GrayI8 {
    public GrayS8(int i, int i2) {
        super(i, i2);
    }

    public GrayS8() {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI
    public int unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.S8;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayS8 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayS8();
        }
        return new GrayS8(i, i2);
    }
}
