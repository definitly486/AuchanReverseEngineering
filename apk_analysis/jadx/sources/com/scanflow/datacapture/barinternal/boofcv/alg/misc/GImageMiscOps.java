package com.scanflow.datacapture.barinternal.boofcv.alg.misc;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageInterleaved;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageMultiBand;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.Planar;

/* JADX INFO: loaded from: classes.dex */
public abstract class GImageMiscOps {
    public static void insertBand(ImageGray imageGray, int i, ImageMultiBand imageMultiBand) {
        if (imageMultiBand instanceof ImageInterleaved) {
            if (InterleavedI8.class.isAssignableFrom(imageMultiBand.getClass())) {
                ImageMiscOps.insertBand((GrayI8) imageGray, i, (InterleavedI8) imageMultiBand);
                return;
            }
            if (InterleavedI16.class.isAssignableFrom(imageMultiBand.getClass())) {
                ImageMiscOps.insertBand((GrayI16) imageGray, i, (InterleavedI16) imageMultiBand);
                return;
            }
            if (InterleavedS32.class == imageMultiBand.getClass()) {
                ImageMiscOps.insertBand((GrayS32) imageGray, i, (InterleavedS32) imageMultiBand);
                return;
            }
            if (InterleavedS64.class == imageMultiBand.getClass()) {
                ImageMiscOps.insertBand((GrayS64) imageGray, i, (InterleavedS64) imageMultiBand);
                return;
            }
            if (InterleavedF32.class == imageMultiBand.getClass()) {
                ImageMiscOps.insertBand((GrayF32) imageGray, i, (InterleavedF32) imageMultiBand);
                return;
            }
            if (InterleavedF64.class == imageMultiBand.getClass()) {
                ImageMiscOps.insertBand((GrayF64) imageGray, i, (InterleavedF64) imageMultiBand);
                return;
            }
            throw new IllegalArgumentException("Unknown image Type: " + imageGray.getClass().getSimpleName());
        }
        if (imageMultiBand instanceof Planar) {
            ((Planar) imageMultiBand).getBand(i).setTo(imageGray);
            return;
        }
        throw new IllegalArgumentException("Unknown image type: " + imageGray.getClass().getSimpleName());
    }
}
