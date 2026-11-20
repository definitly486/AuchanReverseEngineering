package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public class ImageBorder1D_F32 extends ImageBorder_F32 {
    BorderIndex1D colWrap;
    BorderIndex1D rowWrap;

    public ImageBorder1D_F32(FactoryBorderIndex1D factoryBorderIndex1D) {
        this.rowWrap = factoryBorderIndex1D.newInstance();
        this.colWrap = factoryBorderIndex1D.newInstance();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder
    public void setImage(GrayF32 grayF32) {
        super.setImage((ImageBase) grayF32);
        this.colWrap.setLength(grayF32.width);
        this.rowWrap.setLength(grayF32.height);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F32
    public float getOutside(int i, int i2) {
        return ((GrayF32) this.image).get(this.colWrap.getIndex(i), this.rowWrap.getIndex(i2));
    }
}
