package com.scanflow.datacapture.barinternal.boofcv.alg.misc;

import com.scanflow.datacapture.barinternal.boofcv.alg.InputSanityCheck;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplPixelMath;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl.ImplPixelMath_MT;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;

/* JADX INFO: loaded from: classes.dex */
public abstract class PixelMath {
    public static int SMALL_IMAGE = 10000;

    public static void subtract(GrayF32 grayF32, GrayF32 grayF33, GrayF32 grayF34) {
        InputSanityCheck.checkSameShape(grayF32, grayF33);
        grayF34.reshape(grayF32.width, grayF32.height);
        int i = grayF32.width * grayF32.height;
        if (BoofConcurrency.USE_CONCURRENT && i > SMALL_IMAGE) {
            ImplPixelMath_MT.subtract(grayF32, grayF33, grayF34);
        } else {
            ImplPixelMath.subtract(grayF32, grayF33, grayF34);
        }
    }

    public static void sqrt(GrayF32 grayF32, GrayF32 grayF33) {
        grayF33.reshape(grayF32.width, grayF32.height);
        int i = grayF32.width;
        int i2 = grayF32.height;
        int i3 = i * i2;
        if (BoofConcurrency.USE_CONCURRENT && i3 > SMALL_IMAGE) {
            ImplPixelMath_MT.sqrt(grayF32.data, grayF32.startIndex, grayF32.stride, grayF33.data, grayF33.startIndex, grayF33.stride, i2, i);
        } else {
            ImplPixelMath.sqrt(grayF32.data, grayF32.startIndex, grayF32.stride, grayF33.data, grayF33.startIndex, grayF33.stride, i2, i);
        }
    }

    public static void pow2(GrayF32 grayF32, GrayF32 grayF33) {
        grayF33.reshape(grayF32.width, grayF32.height);
        int i = grayF32.width;
        int i2 = grayF32.height;
        int i3 = i * i2;
        if (BoofConcurrency.USE_CONCURRENT && i3 > SMALL_IMAGE) {
            ImplPixelMath_MT.pow2(grayF32.data, grayF32.startIndex, grayF32.stride, grayF33.data, grayF33.startIndex, grayF33.stride, i2, i);
        } else {
            ImplPixelMath.pow2(grayF32.data, grayF32.startIndex, grayF32.stride, grayF33.data, grayF33.startIndex, grayF33.stride, i2, i);
        }
    }
}
