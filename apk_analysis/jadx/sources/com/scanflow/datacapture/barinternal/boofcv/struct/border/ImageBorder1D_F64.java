package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public class ImageBorder1D_F64 extends ImageBorder_F64 {
    BorderIndex1D colWrap;
    BorderIndex1D rowWrap;

    public ImageBorder1D_F64(FactoryBorderIndex1D factoryBorderIndex1D) {
        this.rowWrap = factoryBorderIndex1D.newInstance();
        this.colWrap = factoryBorderIndex1D.newInstance();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder
    public void setImage(GrayF64 grayF64) {
        super.setImage((ImageBase) grayF64);
        this.colWrap.setLength(grayF64.width);
        this.rowWrap.setLength(grayF64.height);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_F64
    public double getOutside(int i, int i2) {
        return ((GrayF64) this.image).get(this.colWrap.getIndex(i), this.rowWrap.getIndex(i2));
    }
}
