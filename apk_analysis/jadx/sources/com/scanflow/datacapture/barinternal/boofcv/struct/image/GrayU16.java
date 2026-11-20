package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class GrayU16 extends GrayI16 {
    public GrayU16(int i, int i2) {
        super(i, i2);
    }

    public GrayU16() {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI
    public int unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)] & 65535;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.U16;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayU16 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayU16();
        }
        return new GrayU16(i, i2);
    }
}
