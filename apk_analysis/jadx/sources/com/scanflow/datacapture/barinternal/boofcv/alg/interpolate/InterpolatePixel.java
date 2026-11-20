package com.scanflow.datacapture.barinternal.boofcv.alg.interpolate;

import com.scanflow.datacapture.barinternal.boofcv.struct.border.ImageBorder;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public interface InterpolatePixel {
    void setBorder(ImageBorder imageBorder);

    void setImage(ImageBase imageBase);
}
