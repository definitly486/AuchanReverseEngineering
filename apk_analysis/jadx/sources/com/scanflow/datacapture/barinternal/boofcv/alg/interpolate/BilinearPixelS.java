package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate;

import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public abstract class BilinearPixelS implements InterpolatePixelS {
    protected ImageBorder border;
    protected int height;
    protected ImageGray orig;
    protected int stride;
    protected int width;

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixel
    public void setBorder(ImageBorder imageBorder) {
        this.border = imageBorder;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.interpolate.InterpolatePixel
    public void setImage(ImageGray imageGray) {
        ImageBorder imageBorder = this.border;
        if (imageBorder != null) {
            imageBorder.setImage(imageGray);
        }
        this.orig = imageGray;
        this.stride = imageGray.getStride();
        this.width = this.orig.getWidth();
        this.height = this.orig.getHeight();
    }
}
