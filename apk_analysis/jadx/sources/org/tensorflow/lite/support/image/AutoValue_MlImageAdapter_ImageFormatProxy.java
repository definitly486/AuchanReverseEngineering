package org.tensorflow.lite.support.image;

/* JADX INFO: loaded from: classes4.dex */
final class AutoValue_MlImageAdapter_ImageFormatProxy extends MlImageAdapter.ImageFormatProxy {
    private final ColorSpaceType colorSpaceType;
    private final int imageFormat;

    AutoValue_MlImageAdapter_ImageFormatProxy(ColorSpaceType colorSpaceType, int i) {
        if (colorSpaceType == null) {
            throw new NullPointerException("Null colorSpaceType");
        }
        this.colorSpaceType = colorSpaceType;
        this.imageFormat = i;
    }

    @Override // org.tensorflow.lite.support.image.MlImageAdapter.ImageFormatProxy
    ColorSpaceType getColorSpaceType() {
        return this.colorSpaceType;
    }

    @Override // org.tensorflow.lite.support.image.MlImageAdapter.ImageFormatProxy
    int getImageFormat() {
        return this.imageFormat;
    }

    public String toString() {
        return "ImageFormatProxy{colorSpaceType=" + this.colorSpaceType + ", imageFormat=" + this.imageFormat + "}";
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof MlImageAdapter.ImageFormatProxy) {
            MlImageAdapter.ImageFormatProxy imageFormatProxy = (MlImageAdapter.ImageFormatProxy) obj;
            if (this.colorSpaceType.equals(imageFormatProxy.getColorSpaceType()) && this.imageFormat == imageFormatProxy.getImageFormat()) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return ((this.colorSpaceType.hashCode() ^ 1000003) * 1000003) ^ this.imageFormat;
    }
}
