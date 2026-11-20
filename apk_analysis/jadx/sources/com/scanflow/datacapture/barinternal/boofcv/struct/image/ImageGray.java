package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import java.lang.reflect.Array;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageGray extends ImageBase {
    protected abstract Object _getData();

    public abstract void _setData(Object obj);

    public abstract ImageDataType getDataType();

    protected ImageGray(int i, int i2) {
        this.imageType = ImageType.single(getClass());
        initialize(i, i2);
    }

    protected ImageGray() {
        this.imageType = ImageType.single(getClass());
    }

    protected void initialize(int i, int i2) {
        _setData(Array.newInstance((Class<?>) getDataType().getDataType(), i * i2));
        this.startIndex = 0;
        this.stride = i;
        this.width = i;
        this.height = i2;
    }

    public ImageGray subimage(int i, int i2, int i3, int i4, ImageGray imageGray) {
        if (i < 0 || i2 < 0) {
            throw new IllegalArgumentException("x0 or y0 is less than zero");
        }
        if (i3 < i || i4 < i2) {
            throw new IllegalArgumentException("x1 or y1 is less than x0 or y0 respectively");
        }
        if (i3 > this.width || i4 > this.height) {
            throw new IllegalArgumentException("x1 or y1 is more than the width or height respectively");
        }
        if (imageGray == null) {
            imageGray = (ImageGray) createNew(-1, -1);
        }
        imageGray._setData(_getData());
        imageGray.stride = Math.max(this.width, this.stride);
        imageGray.width = i3 - i;
        imageGray.height = i4 - i2;
        imageGray.startIndex = this.startIndex + (i2 * this.stride) + i;
        imageGray.subImage = true;
        imageGray.imageType = this.imageType;
        return imageGray;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public void reshape(int i, int i2) {
        if (this.width == i && this.height == i2) {
            return;
        }
        if (isSubimage()) {
            throw new IllegalArgumentException("Can't reshape sub-images");
        }
        if (Array.getLength(_getData()) < i * i2) {
            _setData(((ImageGray) createNew(i, i2))._getData());
        }
        this.stride = i;
        this.width = i;
        this.height = i2;
    }

    public void reshape(ImageBase imageBase) {
        reshape(imageBase.width, imageBase.height);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public ImageGray setTo(ImageGray imageGray) {
        int i = this.width;
        int i2 = imageGray.width;
        if (i != i2 || this.height != imageGray.height) {
            reshape(i2, imageGray.height);
        }
        if (!imageGray.isSubimage() && !isSubimage()) {
            System.arraycopy(imageGray._getData(), imageGray.startIndex, _getData(), this.startIndex, this.stride * this.height);
            return this;
        }
        int i3 = imageGray.startIndex;
        int i4 = this.startIndex;
        for (int i5 = 0; i5 < this.height; i5++) {
            System.arraycopy(imageGray._getData(), i3, _getData(), i4, this.width);
            i3 += imageGray.stride;
            i4 += this.stride;
        }
        return this;
    }

    public static ImageGray create(Class cls, int i, int i2) {
        if (cls == GrayU8.class) {
            return new GrayU8(i, i2);
        }
        if (cls == GrayS8.class) {
            return new GrayS8(i, i2);
        }
        if (cls == GrayS16.class) {
            return new GrayS16(i, i2);
        }
        if (cls == GrayU16.class) {
            return new GrayU16(i, i2);
        }
        if (cls == GrayS32.class) {
            return new GrayS32(i, i2);
        }
        if (cls == GrayS64.class) {
            return new GrayS64(i, i2);
        }
        if (cls == GrayF32.class) {
            return new GrayF32(i, i2);
        }
        if (cls == GrayF64.class) {
            return new GrayF64(i, i2);
        }
        if (cls == GrayI.class) {
            return new GrayS32(i, i2);
        }
        throw new IllegalArgumentException("Unknown type " + cls);
    }
}
