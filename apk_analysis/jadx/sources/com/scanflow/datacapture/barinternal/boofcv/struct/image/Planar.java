package com.scanflow.datacapture.barinternal.boofcv.struct.image;

import java.lang.reflect.Array;

/* JADX INFO: loaded from: classes.dex */
public class Planar extends ImageMultiBand {
    public ImageGray[] bands;
    public Class type;

    public Planar(Class cls, int i, int i2, int i3) {
        this.type = cls;
        this.stride = i;
        this.width = i;
        this.height = i2;
        this.bands = (ImageGray[]) Array.newInstance((Class<?>) cls, i3);
        for (int i4 = 0; i4 < i3; i4++) {
            this.bands[i4] = ImageGray.create(cls, i, i2);
        }
        this.imageType = ImageType.pl(i3, cls);
    }

    public Class getBandType() {
        return this.type;
    }

    public int getNumBands() {
        return this.bands.length;
    }

    public ImageGray getBand(int i) {
        ImageGray[] imageGrayArr = this.bands;
        if (i >= imageGrayArr.length || i < 0) {
            throw new IllegalArgumentException("The specified band is out of range. " + i + " / " + this.bands.length);
        }
        return imageGrayArr[i];
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public Planar setTo(Planar planar) {
        int i = planar.width;
        if (i != this.width || planar.height != this.height) {
            reshape(i, planar.height);
        }
        if (planar.getBandType() != getBandType()) {
            throw new IllegalArgumentException("The band type must be the same");
        }
        int numBands = planar.getNumBands();
        if (numBands != getNumBands()) {
            setNumberOfBands(planar.getNumBands());
        }
        for (int i2 = 0; i2 < numBands; i2++) {
            this.bands[i2].setTo(planar.getBand(i2));
        }
        return this;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public void reshape(int i, int i2) {
        if (this.width == i && this.height == i2) {
            return;
        }
        if (isSubimage()) {
            throw new IllegalArgumentException("Can't reshape subimage");
        }
        int i3 = 0;
        while (true) {
            ImageGray[] imageGrayArr = this.bands;
            if (i3 < imageGrayArr.length) {
                imageGrayArr[i3].reshape(i, i2);
                i3++;
            } else {
                this.startIndex = 0;
                this.stride = i;
                this.width = i;
                this.height = i2;
                return;
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase
    public Planar createNew(int i, int i2) {
        return new Planar(this.type, i, i2, this.bands.length);
    }

    public void setNumberOfBands(int i) {
        if (i == this.bands.length) {
            return;
        }
        ImageGray[] imageGrayArr = (ImageGray[]) Array.newInstance((Class<?>) this.type, i);
        int iMin = Math.min(i, this.bands.length);
        for (int i2 = 0; i2 < iMin; i2++) {
            imageGrayArr[i2] = this.bands[i2];
        }
        while (iMin < imageGrayArr.length) {
            imageGrayArr[iMin] = ImageGray.create(this.type, this.width, this.height);
            iMin++;
        }
        this.bands = imageGrayArr;
        this.imageType.numBands = imageGrayArr.length;
    }
}
