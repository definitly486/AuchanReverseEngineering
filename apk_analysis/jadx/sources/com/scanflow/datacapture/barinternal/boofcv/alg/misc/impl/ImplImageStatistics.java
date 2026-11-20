package com.scanflow.datacapture.barinternal.boofcv.alg.misc.impl;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import java.util.Arrays;

/* JADX INFO: loaded from: classes.dex */
public abstract class ImplImageStatistics {
    public static void histogram(GrayU8 grayU8, int i, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i2 = 0; i2 < grayU8.height; i2++) {
            int i3 = grayU8.startIndex + (grayU8.stride * i2);
            int i4 = grayU8.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = (grayU8.data[i3] & UnsignedBytes.MAX_VALUE) - i;
                iArr[i6] = iArr[i6] + 1;
                i3 = i5;
            }
        }
    }

    public static void histogram(GrayS8 grayS8, int i, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i2 = 0; i2 < grayS8.height; i2++) {
            int i3 = grayS8.startIndex + (grayS8.stride * i2);
            int i4 = grayS8.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = grayS8.data[i3] - i;
                iArr[i6] = iArr[i6] + 1;
                i3 = i5;
            }
        }
    }

    public static void histogram(GrayU16 grayU16, int i, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i2 = 0; i2 < grayU16.height; i2++) {
            int i3 = grayU16.startIndex + (grayU16.stride * i2);
            int i4 = grayU16.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = (grayU16.data[i3] & 65535) - i;
                iArr[i6] = iArr[i6] + 1;
                i3 = i5;
            }
        }
    }

    public static void histogram(GrayS16 grayS16, int i, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i2 = 0; i2 < grayS16.height; i2++) {
            int i3 = grayS16.startIndex + (grayS16.stride * i2);
            int i4 = grayS16.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = grayS16.data[i3] - i;
                iArr[i6] = iArr[i6] + 1;
                i3 = i5;
            }
        }
    }

    public static void histogram(GrayS32 grayS32, int i, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i2 = 0; i2 < grayS32.height; i2++) {
            int i3 = grayS32.startIndex + (grayS32.stride * i2);
            int i4 = grayS32.width + i3;
            while (i3 < i4) {
                int i5 = i3 + 1;
                int i6 = grayS32.data[i3] - i;
                iArr[i6] = iArr[i6] + 1;
                i3 = i5;
            }
        }
    }

    public static void histogram(GrayS64 grayS64, long j, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i = 0; i < grayS64.height; i++) {
            int i2 = grayS64.startIndex + (grayS64.stride * i);
            int i3 = grayS64.width + i2;
            while (i2 < i3) {
                int i4 = i2 + 1;
                int i5 = (int) (grayS64.data[i2] - j);
                iArr[i5] = iArr[i5] + 1;
                i2 = i4;
            }
        }
    }

    public static float min(float[] fArr, int i, int i2, int i3, int i4) {
        float f = fArr[i];
        for (int i5 = 0; i5 < i2; i5++) {
            int i6 = (i5 * i4) + i;
            int i7 = i6 + i3;
            while (i6 < i7) {
                float f2 = fArr[i6];
                if (f2 < f) {
                    f = f2;
                }
                i6++;
            }
        }
        return f;
    }

    public static float max(float[] fArr, int i, int i2, int i3, int i4) {
        float f = fArr[i];
        for (int i5 = 0; i5 < i2; i5++) {
            int i6 = (i5 * i4) + i;
            int i7 = i6 + i3;
            while (i6 < i7) {
                float f2 = fArr[i6];
                if (f2 > f) {
                    f = f2;
                }
                i6++;
            }
        }
        return f;
    }

    public static void histogram(GrayF32 grayF32, float f, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i = 0; i < grayF32.height; i++) {
            int i2 = grayF32.startIndex + (grayF32.stride * i);
            int i3 = grayF32.width + i2;
            while (i2 < i3) {
                int i4 = i2 + 1;
                int i5 = (int) (grayF32.data[i2] - f);
                iArr[i5] = iArr[i5] + 1;
                i2 = i4;
            }
        }
    }

    public static void histogram(GrayF64 grayF64, double d, int[] iArr) {
        Arrays.fill(iArr, 0);
        for (int i = 0; i < grayF64.height; i++) {
            int i2 = grayF64.startIndex + (grayF64.stride * i);
            int i3 = grayF64.width + i2;
            while (i2 < i3) {
                int i4 = i2 + 1;
                int i5 = (int) (grayF64.data[i2] - d);
                iArr[i5] = iArr[i5] + 1;
                i2 = i4;
            }
        }
    }
}
