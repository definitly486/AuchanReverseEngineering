package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public class ImageBorder1D_S32 extends ImageBorder_S32 {
    BorderIndex1D colWrap;
    BorderIndex1D rowWrap;

    public ImageBorder1D_S32(FactoryBorderIndex1D factoryBorderIndex1D) {
        this.rowWrap = factoryBorderIndex1D.newInstance();
        this.colWrap = factoryBorderIndex1D.newInstance();
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder
    public void setImage(GrayI grayI) {
        super.setImage((ImageBase) grayI);
        this.colWrap.setLength(grayI.width);
        this.rowWrap.setLength(grayI.height);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder_S32
    public int getOutside(int i, int i2) {
        return ((GrayI) this.image).get(this.colWrap.getIndex(i), this.rowWrap.getIndex(i2));
    }
}
