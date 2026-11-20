package com.scanflow.datacapture.barinternal.boofcv.core.image;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public interface GImageGray {
    int getHeight();

    int getWidth();

    double unsafe_getD(int i, int i2);

    void wrap(ImageGray imageGray);
}
