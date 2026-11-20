package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import com.google.common.primitives.UnsignedBytes;

/* JADX INFO: loaded from: classes.dex */
public class GrayU8 extends GrayI8 {
    public GrayU8(int i, int i2) {
        super(i, i2);
    }

    public GrayU8() {
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI
    public int unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)] & UnsignedBytes.MAX_VALUE;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.U8;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayU8 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayU8();
        }
        return new GrayU8(i, i2);
    }
}
