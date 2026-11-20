package com.scanflow.datacapture.barinternal.boofcv.struct.border;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageBorder {
    protected ImageBase image;

    protected ImageBorder() {
    }

    public void setImage(ImageBase imageBase) {
        this.image = imageBase;
    }
}
