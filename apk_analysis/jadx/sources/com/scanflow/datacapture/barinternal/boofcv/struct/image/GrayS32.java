package com.scanflow.datacapture.barinternal.boofcv.struct.image;

/* JADX INFO: loaded from: classes.dex */
public class GrayS32 extends GrayI {
    public int[] data;

    public GrayS32(int i, int i2) {
        super(i, i2);
    }

    public GrayS32() {
        this.data = new int[0];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI
    public int unsafe_get(int i, int i2) {
        return this.data[getIndex(i, i2)];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public ImageDataType getDataType() {
        return ImageDataType.S32;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    protected Object _getData() {
        return this.data;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray
    public void _setData(Object obj) {
        this.data = (int[]) obj;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public GrayS32 createNew(int i, int i2) {
        if (i == -1 || i2 == -1) {
            return new GrayS32();
        }
        return new GrayS32(i, i2);
    }
}
