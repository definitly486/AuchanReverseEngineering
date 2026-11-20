package com.scanflow.datacapture.barinternal.boofcv.alg.misc;

import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;

/* JADX INFO: loaded from: classes.dex */
public abstract class GImageStatistics {
    public static void histogram(ImageGray imageGray, double d, int[] iArr) {
        if (GrayU8.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayU8) imageGray, (int) d, iArr);
            return;
        }
        if (GrayS8.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayS8) imageGray, (int) d, iArr);
            return;
        }
        if (GrayU16.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayU16) imageGray, (int) d, iArr);
            return;
        }
        if (GrayS16.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayS16) imageGray, (int) d, iArr);
            return;
        }
        if (GrayS32.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayS32) imageGray, (int) d, iArr);
            return;
        }
        if (GrayS64.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayS64) imageGray, (long) d, iArr);
        } else if (GrayF32.class == imageGray.getClass()) {
            ImageStatistics.histogram((GrayF32) imageGray, (float) d, iArr);
        } else {
            if (GrayF64.class == imageGray.getClass()) {
                ImageStatistics.histogram((GrayF64) imageGray, d, iArr);
                return;
            }
            throw new IllegalArgumentException("Unknown image Type");
        }
    }
}
