package com.scanflow.datacapture.barinternal.boofcv.alg.misc;

import com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplImageStatistics_MT;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImageStatistics {
    public static void histogram(GrayU8 grayU8, int i, int[] iArr) {
        int i2 = grayU8.width * grayU8.height;
        if (BoofConcurrency.USE_CONCURRENT && i2 >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayU8, i, iArr);
        } else {
            ImplImageStatistics.histogram(grayU8, i, iArr);
        }
    }

    public static void histogram(GrayS8 grayS8, int i, int[] iArr) {
        int i2 = grayS8.width * grayS8.height;
        if (BoofConcurrency.USE_CONCURRENT && i2 >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayS8, i, iArr);
        } else {
            ImplImageStatistics.histogram(grayS8, i, iArr);
        }
    }

    public static void histogram(GrayU16 grayU16, int i, int[] iArr) {
        int i2 = grayU16.width * grayU16.height;
        if (BoofConcurrency.USE_CONCURRENT && i2 >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayU16, i, iArr);
        } else {
            ImplImageStatistics.histogram(grayU16, i, iArr);
        }
    }

    public static void histogram(GrayS16 grayS16, int i, int[] iArr) {
        int i2 = grayS16.width * grayS16.height;
        if (BoofConcurrency.USE_CONCURRENT && i2 >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayS16, i, iArr);
        } else {
            ImplImageStatistics.histogram(grayS16, i, iArr);
        }
    }

    public static void histogram(GrayS32 grayS32, int i, int[] iArr) {
        int i2 = grayS32.width * grayS32.height;
        if (BoofConcurrency.USE_CONCURRENT && i2 >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayS32, i, iArr);
        } else {
            ImplImageStatistics.histogram(grayS32, i, iArr);
        }
    }

    public static void histogram(GrayS64 grayS64, long j, int[] iArr) {
        int i = grayS64.width * grayS64.height;
        if (BoofConcurrency.USE_CONCURRENT && i >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayS64, j, iArr);
        } else {
            ImplImageStatistics.histogram(grayS64, j, iArr);
        }
    }

    public static float min(GrayF32 grayF32) {
        int i = grayF32.width;
        int i2 = grayF32.height;
        int i3 = i * i2;
        if (BoofConcurrency.USE_CONCURRENT && i3 >= BoofConcurrency.SMALL_IMAGE) {
            return ImplImageStatistics_MT.min(grayF32.data, grayF32.startIndex, i2, i, grayF32.stride);
        }
        return ImplImageStatistics.min(grayF32.data, grayF32.startIndex, i2, i, grayF32.stride);
    }

    public static float max(GrayF32 grayF32) {
        int i = grayF32.width;
        int i2 = grayF32.height;
        int i3 = i * i2;
        if (BoofConcurrency.USE_CONCURRENT && i3 >= BoofConcurrency.SMALL_IMAGE) {
            return ImplImageStatistics_MT.max(grayF32.data, grayF32.startIndex, i2, i, grayF32.stride);
        }
        return ImplImageStatistics.max(grayF32.data, grayF32.startIndex, i2, i, grayF32.stride);
    }

    public static void histogram(GrayF32 grayF32, float f, int[] iArr) {
        int i = grayF32.width * grayF32.height;
        if (BoofConcurrency.USE_CONCURRENT && i >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayF32, f, iArr);
        } else {
            ImplImageStatistics.histogram(grayF32, f, iArr);
        }
    }

    public static void histogram(GrayF64 grayF64, double d, int[] iArr) {
        int i = grayF64.width * grayF64.height;
        if (BoofConcurrency.USE_CONCURRENT && i >= BoofConcurrency.SMALL_IMAGE) {
            ImplImageStatistics_MT.histogram(grayF64, d, iArr);
        } else {
            ImplImageStatistics.histogram(grayF64, d, iArr);
        }
    }
}
