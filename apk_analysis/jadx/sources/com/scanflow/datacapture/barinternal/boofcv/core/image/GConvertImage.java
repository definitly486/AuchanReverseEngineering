package com.scanflow.datacapture.barinternal.boofcv.core.image;

import com.scanflow.datacapture.barinternal.boofcv.alg.misc.GImageMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageDataType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.Planar;

/* JADX INFO: loaded from: classes.dex */
public abstract class GConvertImage {
    public static void convert(ImageBase imageBase, ImageBase imageBase2) {
        ImageType imageType = imageBase.getImageType();
        ImageType imageType2 = imageBase2.getImageType();
        int i = 0;
        String str = "convert";
        if (imageBase instanceof ImageGray) {
            ImageGray imageGray = (ImageGray) imageBase;
            if (imageBase2 instanceof ImageGray) {
                if (imageBase.getClass() == imageBase2.getClass()) {
                    imageBase2.setTo(imageBase);
                    return;
                }
                try {
                    ConvertImage.class.getMethod("convert", imageBase.getClass(), imageBase2.getClass()).invoke(null, imageBase, imageBase2);
                    return;
                } catch (Exception unused) {
                    throw new IllegalArgumentException("Unknown conversion. " + imageBase.getClass().getSimpleName() + " to " + imageBase2.getClass().getSimpleName());
                }
            }
            if (imageBase2 instanceof Planar) {
                Planar planar = (Planar) imageBase2;
                while (i < planar.getNumBands()) {
                    convert(imageBase, planar.getBand(i));
                    i++;
                }
                return;
            }
            if (imageBase2 instanceof ImageInterleaved) {
                ImageInterleaved imageInterleaved = (ImageInterleaved) imageBase2;
                while (i < imageInterleaved.getNumBands()) {
                    GImageMiscOps.insertBand(imageGray, i, imageInterleaved);
                    i++;
                }
                return;
            }
            throw new IllegalArgumentException("Unknown conversion. " + imageBase.getClass().getSimpleName() + " to " + imageBase2.getClass().getSimpleName());
        }
        boolean z = imageBase instanceof ImageInterleaved;
        if (z && (imageBase2 instanceof ImageInterleaved)) {
            if (imageBase.getClass() == imageBase2.getClass()) {
                imageBase2.setTo(imageBase);
                return;
            }
            try {
                ConvertImage.class.getMethod("convert", imageBase.getClass(), imageBase2.getClass()).invoke(null, imageBase, imageBase2);
                return;
            } catch (Exception unused2) {
                throw new IllegalArgumentException("Unknown conversion. " + imageBase.getClass().getSimpleName() + " to " + imageBase2.getClass().getSimpleName());
            }
        }
        boolean z2 = imageBase instanceof Planar;
        if (z2 && (imageBase2 instanceof ImageGray)) {
            Planar planar2 = (Planar) imageBase;
            ImageGray imageGray2 = (ImageGray) imageBase2;
            if (planar2.getImageType().getDataType() != imageGray2.getDataType()) {
                ImageGray imageGrayCreateSingleBand = GeneralizedImageOps.createSingleBand(planar2.getImageType().getDataType(), imageBase2.width, imageBase2.height);
                average(planar2, imageGrayCreateSingleBand);
                convert(imageGrayCreateSingleBand, imageGray2);
                return;
            }
            average(planar2, imageGray2);
            return;
        }
        if (z2 && (imageBase2 instanceof ImageInterleaved)) {
            if (imageType.getDataType() != imageType2.getDataType()) {
                str = "convert" + imageType.getDataType() + imageType2.getDataType();
            }
            try {
                ConvertImage.class.getMethod(str, imageBase.getClass(), imageBase2.getClass()).invoke(null, imageBase, imageBase2);
                return;
            } catch (Exception unused3) {
                throw new IllegalArgumentException("Unknown conversion. " + imageBase.getClass().getSimpleName() + " to " + imageBase2.getClass().getSimpleName());
            }
        }
        if (z2 && (imageBase2 instanceof Planar)) {
            Planar planar3 = (Planar) imageBase;
            Planar planar4 = (Planar) imageBase2;
            if (planar3.getBandType() == planar4.getBandType()) {
                planar4.setTo(planar3);
                return;
            }
            while (i < planar3.getNumBands()) {
                convert(planar3.getBand(i), planar4.getBand(i));
                i++;
            }
            return;
        }
        if (z && (imageBase2 instanceof Planar)) {
            if (imageType.getDataType() != imageType2.getDataType()) {
                str = "convert" + imageType.getDataType() + imageType2.getDataType();
            }
            try {
                ConvertImage.class.getMethod(str, imageBase.getClass(), imageBase2.getClass()).invoke(null, imageBase, imageBase2);
                return;
            } catch (Exception unused4) {
                throw new IllegalArgumentException("Unknown conversion. " + imageBase.getClass().getSimpleName() + " to " + imageBase2.getClass().getSimpleName());
            }
        }
        if (z && (imageBase2 instanceof ImageGray)) {
            ImageInterleaved imageInterleaved2 = (ImageInterleaved) imageBase;
            ImageGray imageGray3 = (ImageGray) imageBase2;
            if (imageInterleaved2.getImageType().getDataType() != imageGray3.getDataType()) {
                ImageGray imageGrayCreateSingleBand2 = GeneralizedImageOps.createSingleBand(imageInterleaved2.getImageType().getDataType(), imageBase2.width, imageBase2.height);
                average(imageInterleaved2, imageGrayCreateSingleBand2);
                convert(imageGrayCreateSingleBand2, imageGray3);
                return;
            }
            average(imageInterleaved2, imageGray3);
            return;
        }
        throw new IllegalArgumentException("Don't know how to convert between input types. " + imageBase.getClass().getSimpleName() + " " + imageBase2.getClass().getSimpleName());
    }

    public static ImageGray average(Planar planar, ImageGray imageGray) {
        Class bandType = planar.getBandType();
        if (bandType == GrayU8.class) {
            return ConvertImage.average(planar, (GrayU8) imageGray);
        }
        if (bandType == GrayS8.class) {
            return ConvertImage.average(planar, (GrayS8) imageGray);
        }
        if (bandType == GrayU16.class) {
            return ConvertImage.average(planar, (GrayU16) imageGray);
        }
        if (bandType == GrayS16.class) {
            return ConvertImage.average(planar, (GrayS16) imageGray);
        }
        if (bandType == GrayS32.class) {
            return ConvertImage.average(planar, (GrayS32) imageGray);
        }
        if (bandType == GrayS64.class) {
            return ConvertImage.average(planar, (GrayS64) imageGray);
        }
        if (bandType == GrayF32.class) {
            return ConvertImage.average(planar, (GrayF32) imageGray);
        }
        if (bandType == GrayF64.class) {
            return ConvertImage.average(planar, (GrayF64) imageGray);
        }
        throw new IllegalArgumentException("Unknown image type: " + bandType.getSimpleName());
    }

    public static ImageGray average(ImageInterleaved imageInterleaved, ImageGray imageGray) {
        ImageDataType dataType = imageInterleaved.getImageType().getDataType();
        if (dataType == ImageDataType.U8) {
            return ConvertImage.average((InterleavedU8) imageInterleaved, (GrayU8) imageGray);
        }
        if (dataType == ImageDataType.S8) {
            return ConvertImage.average((InterleavedS8) imageInterleaved, (GrayS8) imageGray);
        }
        if (dataType == ImageDataType.U16) {
            return ConvertImage.average((InterleavedU16) imageInterleaved, (GrayU16) imageGray);
        }
        if (dataType == ImageDataType.S16) {
            return ConvertImage.average((InterleavedS16) imageInterleaved, (GrayS16) imageGray);
        }
        if (dataType == ImageDataType.S32) {
            return ConvertImage.average((InterleavedS32) imageInterleaved, (GrayS32) imageGray);
        }
        if (dataType == ImageDataType.S64) {
            return ConvertImage.average((InterleavedS64) imageInterleaved, (GrayS64) imageGray);
        }
        if (dataType == ImageDataType.F32) {
            return ConvertImage.average((InterleavedF32) imageInterleaved, (GrayF32) imageGray);
        }
        if (dataType == ImageDataType.F64) {
            return ConvertImage.average((InterleavedF64) imageInterleaved, (GrayF64) imageGray);
        }
        throw new IllegalArgumentException("Unknown image type: " + dataType);
    }
}
