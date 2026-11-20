package com.scanflow.datacapture.barinternal.boofcv.alg.misc;

import com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageMiscOps_MT;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.InterleavedS64;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageMiscOps {
    public static int MIN_ELEMENTS_CONCURRENT = 160000;

    public static boolean runConcurrent(ImageBase imageBase) {
        return runConcurrent(imageBase.width * imageBase.height);
    }

    public static boolean runConcurrent(int i) {
        return BoofConcurrency.isUseConcurrent() && i >= MIN_ELEMENTS_CONCURRENT;
    }

    public static void copy(int i, int i2, int i3, int i4, int i5, int i6, GrayI8 grayI8, GrayI8 grayI9) {
        ImplImageMiscOps.copy(i, i2, i3, i4, i5, i6, grayI8, grayI9);
    }

    public static void insertBand(GrayI8 grayI8, int i, InterleavedI8 interleavedI8) {
        if (runConcurrent(grayI8)) {
            ImplImageMiscOps_MT.insertBand(grayI8, i, interleavedI8);
        } else {
            ImplImageMiscOps.insertBand(grayI8, i, interleavedI8);
        }
    }

    public static void fillBorder(GrayI8 grayI8, int i, int i2) {
        ImplImageMiscOps.fillBorder(grayI8, i, i2);
    }

    public static void insertBand(GrayI16 grayI16, int i, InterleavedI16 interleavedI16) {
        if (runConcurrent(grayI16)) {
            ImplImageMiscOps_MT.insertBand(grayI16, i, interleavedI16);
        } else {
            ImplImageMiscOps.insertBand(grayI16, i, interleavedI16);
        }
    }

    public static void insertBand(GrayS32 grayS32, int i, InterleavedS32 interleavedS32) {
        if (runConcurrent(grayS32)) {
            ImplImageMiscOps_MT.insertBand(grayS32, i, interleavedS32);
        } else {
            ImplImageMiscOps.insertBand(grayS32, i, interleavedS32);
        }
    }

    public static void insertBand(GrayS64 grayS64, int i, InterleavedS64 interleavedS64) {
        if (runConcurrent(grayS64)) {
            ImplImageMiscOps_MT.insertBand(grayS64, i, interleavedS64);
        } else {
            ImplImageMiscOps.insertBand(grayS64, i, interleavedS64);
        }
    }

    public static void insertBand(GrayF32 grayF32, int i, InterleavedF32 interleavedF32) {
        if (runConcurrent(grayF32)) {
            ImplImageMiscOps_MT.insertBand(grayF32, i, interleavedF32);
        } else {
            ImplImageMiscOps.insertBand(grayF32, i, interleavedF32);
        }
    }

    public static void insertBand(GrayF64 grayF64, int i, InterleavedF64 interleavedF64) {
        if (runConcurrent(grayF64)) {
            ImplImageMiscOps_MT.insertBand(grayF64, i, interleavedF64);
        } else {
            ImplImageMiscOps.insertBand(grayF64, i, interleavedF64);
        }
    }
}
