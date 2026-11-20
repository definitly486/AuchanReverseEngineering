package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public class ImageBorder1D_S64 extends ImageBorder_S64 {
    BorderIndex1D colWrap;
    BorderIndex1D rowWrap;

    public ImageBorder1D_S64(FactoryBorderIndex1D factoryBorderIndex1D) {
        this.rowWrap = factoryBorderIndex1D.newInstance();
        this.colWrap = factoryBorderIndex1D.newInstance();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder
    public void setImage(GrayS64 grayS64) {
        super.setImage((ImageBase) grayS64);
        this.colWrap.setLength(grayS64.width);
        this.rowWrap.setLength(grayS64.height);
    }
}
