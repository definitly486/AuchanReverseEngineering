package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import java.lang.reflect.Array;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageInterleaved extends ImageMultiBand {
    public int numBands;

    protected abstract Object _getData();

    protected abstract void _setData(Object obj);

    protected abstract Class getPrimitiveDataType();

    public abstract String toString_element(int i);

    protected ImageInterleaved(int i, int i2, int i3) {
        this.imageType = ImageType.il(0, getClass());
        _setData(Array.newInstance((Class<?>) getPrimitiveDataType(), i * i2 * i3));
        this.startIndex = 0;
        this.stride = i * i3;
        this.numBands = i3;
        this.width = i;
        this.height = i2;
        this.imageType.numBands = i3;
    }

    protected ImageInterleaved() {
        this.imageType = ImageType.il(0, getClass());
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public void reshape(int i, int i2) {
        if (this.width == i && this.height == i2) {
            return;
        }
        if (isSubimage()) {
            throw new IllegalArgumentException("Can't reshape sub-images");
        }
        if (Array.getLength(_getData()) < i * i2 * this.numBands) {
            _setData(((ImageInterleaved) createNew(i, i2))._getData());
        }
        this.width = i;
        this.height = i2;
        this.stride = i * this.numBands;
    }

    public void reshape(int i, int i2, int i3) {
        if (this.numBands != i3) {
            if (isSubimage()) {
                throw new IllegalArgumentException("Can't reshape sub-images");
            }
            this.numBands = -1;
            this.width = i;
            this.height = i2;
            setNumberOfBands(i3);
            return;
        }
        reshape(i, i2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public int getIndex(int i, int i2) {
        return this.startIndex + (i2 * this.stride) + (i * this.numBands);
    }

    public int getIndex(int i, int i2, int i3) {
        return this.startIndex + (i2 * this.stride) + (i * this.numBands) + i3;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public ImageInterleaved setTo(ImageInterleaved imageInterleaved) {
        int i = imageInterleaved.width;
        if (i != this.width || imageInterleaved.height != this.height || imageInterleaved.numBands != this.numBands) {
            reshape(i, imageInterleaved.height, imageInterleaved.numBands);
        }
        if (!imageInterleaved.isSubimage() && !isSubimage()) {
            System.arraycopy(imageInterleaved._getData(), imageInterleaved.startIndex, _getData(), this.startIndex, this.stride * this.height);
            return this;
        }
        int i2 = imageInterleaved.startIndex;
        int i3 = this.startIndex;
        for (int i4 = 0; i4 < this.height; i4++) {
            System.arraycopy(imageInterleaved._getData(), i2, _getData(), i3, this.width * this.numBands);
            i2 += imageInterleaved.stride;
            i3 += this.stride;
        }
        return this;
    }

    public int getNumBands() {
        return this.imageType.getNumBands();
    }

    public final void setNumberOfBands(int i) {
        if (this.numBands == i) {
            return;
        }
        if (isSubimage()) {
            throw new IllegalArgumentException("Can't reshape sub-images");
        }
        this.imageType.numBands = i;
        this.numBands = i;
        this.stride = this.width * i;
        Object obj_getData = _getData();
        if (obj_getData == null || Array.getLength(obj_getData) < this.width * this.height * i) {
            _setData(((ImageInterleaved) createNew(this.width, this.height))._getData());
        }
    }

    public static ImageInterleaved create(Class cls, int i, int i2, int i3) {
        if (cls == InterleavedU8.class) {
            return new InterleavedU8(i, i2, i3);
        }
        if (cls == InterleavedS8.class) {
            return new InterleavedS8(i, i2, i3);
        }
        if (cls == InterleavedU16.class) {
            return new InterleavedU16(i, i2, i3);
        }
        if (cls == InterleavedS16.class) {
            return new InterleavedS16(i, i2, i3);
        }
        if (cls == InterleavedS32.class) {
            return new InterleavedS32(i, i2, i3);
        }
        if (cls == InterleavedS64.class) {
            return new InterleavedS64(i, i2, i3);
        }
        if (cls == InterleavedF32.class) {
            return new InterleavedF32(i, i2, i3);
        }
        if (cls == InterleavedF64.class) {
            return new InterleavedF64(i, i2, i3);
        }
        throw new IllegalArgumentException("Unknown type " + cls);
    }

    public String toString() {
        String str = getClass().getSimpleName() + " : w=" + this.width + ", h=" + this.height + ", c=" + this.numBands + "\n";
        for (int i = 0; i < this.height; i++) {
            int i2 = this.startIndex + (this.stride * i);
            for (int i3 = 0; i3 < this.width; i3++) {
                int i4 = 0;
                while (i4 < this.numBands) {
                    int i5 = i2 + 1;
                    str = str + toString_element(i2) + " ";
                    i4++;
                    i2 = i5;
                }
                if (i3 < this.width - 1) {
                    str = str + ", ";
                }
            }
            str = str + "\n";
        }
        return str;
    }
}
