package com.scanflow.datacapture.barinternal.boofcv.alg.filter.kernel;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel2D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel2D_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel2D_S32;

/* JADX INFO: loaded from: classes.dex */
public abstract class KernelMath {
    public static Kernel2D_F32 convolve2D(Kernel1D_F32 kernel1D_F32, Kernel1D_F32 kernel1D_F33) {
        int i = kernel1D_F32.width;
        int i2 = kernel1D_F33.width;
        if (i != i2) {
            throw new IllegalArgumentException("Only kernels with the same width supported");
        }
        if (kernel1D_F32.offset != i2 / 2) {
            throw new IllegalArgumentException("Only kernels with the offset in the middle supported");
        }
        Kernel2D_F32 kernel2D_F32 = new Kernel2D_F32(i);
        int i3 = 0;
        for (int i4 = 0; i4 < i; i4++) {
            int i5 = 0;
            while (i5 < i) {
                kernel2D_F32.data[i3] = kernel1D_F32.data[i4] * kernel1D_F33.data[i5];
                i5++;
                i3++;
            }
        }
        return kernel2D_F32;
    }

    public static Kernel2D_F64 convolve2D(Kernel1D_F64 kernel1D_F64, Kernel1D_F64 kernel1D_F65) {
        int i = kernel1D_F64.width;
        int i2 = kernel1D_F65.width;
        if (i != i2) {
            throw new IllegalArgumentException("Only kernels with the same width supported");
        }
        if (kernel1D_F64.offset != i2 / 2) {
            throw new IllegalArgumentException("Only kernels with the offset in the middle supported");
        }
        Kernel2D_F64 kernel2D_F64 = new Kernel2D_F64(i);
        int i3 = 0;
        for (int i4 = 0; i4 < i; i4++) {
            int i5 = 0;
            while (i5 < i) {
                kernel2D_F64.data[i3] = kernel1D_F64.data[i4] * kernel1D_F65.data[i5];
                i5++;
                i3++;
            }
        }
        return kernel2D_F64;
    }

    public static void normalizeSumToOne(Kernel1D_F32 kernel1D_F32) {
        float[] fArr = kernel1D_F32.data;
        float f = 0.0f;
        for (float f2 : fArr) {
            f += f2;
        }
        for (int i = 0; i < fArr.length; i++) {
            fArr[i] = fArr[i] / f;
        }
    }

    public static void normalizeSumToOne(Kernel1D_F64 kernel1D_F64) {
        double[] dArr = kernel1D_F64.data;
        double d = 0.0d;
        for (double d2 : dArr) {
            d += d2;
        }
        for (int i = 0; i < dArr.length; i++) {
            dArr[i] = dArr[i] / d;
        }
    }

    public static void normalizeSumToOne(Kernel2D_F32 kernel2D_F32) {
        float[] fArr = kernel2D_F32.data;
        float f = 0.0f;
        for (float f2 : fArr) {
            f += f2;
        }
        for (int i = 0; i < fArr.length; i++) {
            fArr[i] = fArr[i] / f;
        }
    }

    public static void normalizeSumToOne(Kernel2D_F64 kernel2D_F64) {
        double[] dArr = kernel2D_F64.data;
        double d = 0.0d;
        for (double d2 : dArr) {
            d += d2;
        }
        for (int i = 0; i < dArr.length; i++) {
            dArr[i] = dArr[i] / d;
        }
    }

    public static Kernel2D_S32 convert(Kernel2D_F32 kernel2D_F32, float f) {
        Kernel2D_S32 kernel2D_S32 = new Kernel2D_S32(kernel2D_F32.width);
        float[] fArr = kernel2D_F32.data;
        int[] iArr = kernel2D_S32.data;
        int i = kernel2D_F32.width;
        convert(fArr, iArr, i * i, f);
        return kernel2D_S32;
    }

    public static Kernel1D_S32 convert(Kernel1D_F32 kernel1D_F32, float f) {
        Kernel1D_S32 kernel1D_S32 = new Kernel1D_S32(kernel1D_F32.width, kernel1D_F32.offset);
        convert(kernel1D_F32.data, kernel1D_S32.data, kernel1D_F32.width, f);
        return kernel1D_S32;
    }

    public static Kernel1D_S32 convert(Kernel1D_F64 kernel1D_F64, double d) {
        Kernel1D_S32 kernel1D_S32 = new Kernel1D_S32(kernel1D_F64.width, kernel1D_F64.offset);
        convert(kernel1D_F64.data, kernel1D_S32.data, kernel1D_F64.width, d);
        return kernel1D_S32;
    }

    public static void convert(float[] fArr, int[] iArr, int i, float f) {
        float fMinAbs = minAbs(fArr, i, maxAbs(fArr, i) * f);
        for (int i2 = 0; i2 < i; i2++) {
            iArr[i2] = (int) (fArr[i2] / fMinAbs);
        }
    }

    public static void convert(double[] dArr, int[] iArr, int i, double d) {
        double dMinAbs = minAbs(dArr, i, maxAbs(dArr, i) * d);
        for (int i2 = 0; i2 < i; i2++) {
            iArr[i2] = (int) (dArr[i2] / dMinAbs);
        }
    }

    public static float maxAbs(float[] fArr, int i) {
        float f = 0.0f;
        for (int i2 = 0; i2 < i; i2++) {
            float fAbs = Math.abs(fArr[i2]);
            if (fAbs > f) {
                f = fAbs;
            }
        }
        return f;
    }

    public static double maxAbs(double[] dArr, int i) {
        double d = 0.0d;
        for (int i2 = 0; i2 < i; i2++) {
            double dAbs = Math.abs(dArr[i2]);
            if (dAbs > d) {
                d = dAbs;
            }
        }
        return d;
    }

    public static float minAbs(float[] fArr, int i, float f) {
        float f2 = Float.MAX_VALUE;
        for (int i2 = 0; i2 < i; i2++) {
            float fAbs = Math.abs(fArr[i2]);
            if (fAbs < f2 && fAbs >= f) {
                f2 = fAbs;
            }
        }
        return f2;
    }

    public static double minAbs(double[] dArr, int i, double d) {
        double d2 = 3.4028234663852886E38d;
        for (int i2 = 0; i2 < i; i2++) {
            double dAbs = Math.abs(dArr[i2]);
            if (dAbs < d2 && dAbs >= d) {
                d2 = dAbs;
            }
        }
        return d2;
    }
}
