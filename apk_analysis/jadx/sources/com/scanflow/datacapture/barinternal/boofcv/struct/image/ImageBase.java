package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageBase implements Serializable, Cloneable {
    public int height;
    public ImageType imageType;
    public int startIndex;
    public int stride;
    public boolean subImage = false;
    public int width;

    public abstract ImageBase createNew(int i, int i2);

    public abstract void reshape(int i, int i2);

    public abstract ImageBase setTo(ImageBase imageBase);

    public int getStartIndex() {
        return this.startIndex;
    }

    public int getStride() {
        return this.stride;
    }

    public int getWidth() {
        return this.width;
    }

    public int getHeight() {
        return this.height;
    }

    public void reshapeTo(ImageBase imageBase) {
        reshape(imageBase.width, imageBase.height);
    }

    public boolean isSubimage() {
        return this.subImage;
    }

    public final boolean isInBounds(int i, int i2) {
        return i >= 0 && i < this.width && i2 >= 0 && i2 < this.height;
    }

    public int getIndex(int i, int i2) {
        return this.startIndex + (i2 * this.stride) + i;
    }

    public ImageType getImageType() {
        return this.imageType;
    }

    public ImageBase createSameShape() {
        return createNew(this.width, this.height);
    }

    /* JADX INFO: renamed from: clone, reason: merged with bridge method [inline-methods] */
    public ImageBase m679clone() {
        ImageBase imageBaseCreateSameShape = createSameShape();
        imageBaseCreateSameShape.setTo(this);
        return imageBaseCreateSameShape;
    }
}
