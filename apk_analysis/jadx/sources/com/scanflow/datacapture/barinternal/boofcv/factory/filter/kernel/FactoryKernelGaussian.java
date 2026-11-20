package com.scanflow.datacapture.barinternal.boofcv.factory.filter.kernel;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.kernel.KernelMath;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel2D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel2D_F64;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel2D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.KernelBase;
import com.scanflow.datacapture.barinternal.org.ddogleg.stats.UtilGaussian;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryKernelGaussian {
    public static float MIN_FRAC = 0.01f;
    public static double MIN_FRACD = 0.01d;

    public static KernelBase gaussian(Class cls, double d, int i) {
        if (Kernel1D_F32.class == cls) {
            return gaussian(1, true, 32, d, i);
        }
        if (Kernel1D_F64.class == cls) {
            return gaussian(1, true, 64, d, i);
        }
        if (Kernel1D_S32.class == cls) {
            return gaussian(1, false, 32, d, i);
        }
        if (Kernel2D_S32.class == cls) {
            return gaussian(2, false, 32, d, i);
        }
        if (Kernel2D_F32.class == cls) {
            return gaussian(2, true, 32, d, i);
        }
        if (Kernel2D_F64.class == cls) {
            return gaussian(2, true, 64, d, i);
        }
        throw new RuntimeException("Unknown kernel type. " + cls.getSimpleName());
    }

    public static KernelBase gaussian(int i, boolean z, int i2, double d, int i3) {
        if (i3 <= 0) {
            i3 = radiusForSigma(d, 0);
        } else if (d <= 0.0d) {
            d = sigmaForRadius(i3, 0);
        }
        if (i == 2) {
            if (i2 == 32) {
                Kernel2D_F32 kernel2D_F32Gaussian2D_F32 = gaussian2D_F32(d, i3, true, z);
                return z ? kernel2D_F32Gaussian2D_F32 : KernelMath.convert(kernel2D_F32Gaussian2D_F32, MIN_FRAC);
            }
            if (i2 == 64) {
                Kernel2D_F64 kernel2D_F64Gaussian2D_F64 = gaussian2D_F64(d, i3, true, z);
                if (z) {
                    return kernel2D_F64Gaussian2D_F64;
                }
                throw new IllegalArgumentException("64bit int kernels supported");
            }
            throw new IllegalArgumentException("Bits must be 32 or 64");
        }
        if (i != 1) {
            throw new IllegalArgumentException("DOF not supported");
        }
        if (i2 == 32) {
            Kernel1D_F32 kernel1D_F32Gaussian1D_F32 = gaussian1D_F32(d, i3, true, z);
            return z ? kernel1D_F32Gaussian1D_F32 : KernelMath.convert(kernel1D_F32Gaussian1D_F32, MIN_FRAC);
        }
        if (i2 == 64) {
            Kernel1D_F64 kernel1D_F64Gaussian1D_F64 = gaussian1D_F64(d, i3, true, z);
            return z ? kernel1D_F64Gaussian1D_F64 : KernelMath.convert(kernel1D_F64Gaussian1D_F64, MIN_FRACD);
        }
        throw new IllegalArgumentException("Bits must be 32 or 64 not " + i2);
    }

    protected static Kernel1D_F32 gaussian1D_F32(double d, int i, boolean z, boolean z2) {
        Kernel1D_F32 kernel1D_F32;
        int i2 = 0;
        if (z) {
            kernel1D_F32 = new Kernel1D_F32((i * 2) + 1);
            int i3 = i;
            while (i3 >= (-i)) {
                double d2 = d;
                kernel1D_F32.data[i2] = (float) UtilGaussian.computePDF(0.0d, d2, i3);
                i3--;
                i2++;
                d = d2;
            }
        } else {
            kernel1D_F32 = new Kernel1D_F32(i * 2);
            int i4 = i;
            while (i4 > (-i)) {
                kernel1D_F32.data[i2] = (float) UtilGaussian.computePDF(0.0d, d, ((double) i4) - 0.5d);
                i4--;
                i2++;
            }
        }
        if (z2) {
            KernelMath.normalizeSumToOne(kernel1D_F32);
        }
        return kernel1D_F32;
    }

    protected static Kernel1D_F64 gaussian1D_F64(double d, int i, boolean z, boolean z2) {
        Kernel1D_F64 kernel1D_F64;
        int i2 = 0;
        if (z) {
            kernel1D_F64 = new Kernel1D_F64((i * 2) + 1);
            int i3 = i;
            while (i3 >= (-i)) {
                double d2 = d;
                kernel1D_F64.data[i2] = UtilGaussian.computePDF(0.0d, d2, i3);
                i3--;
                i2++;
                d = d2;
            }
        } else {
            kernel1D_F64 = new Kernel1D_F64(i * 2);
            int i4 = i;
            while (i4 > (-i)) {
                kernel1D_F64.data[i2] = UtilGaussian.computePDF(0.0d, d, ((double) i4) - 0.5d);
                i4--;
                i2++;
            }
        }
        if (z2) {
            KernelMath.normalizeSumToOne(kernel1D_F64);
        }
        return kernel1D_F64;
    }

    public static Kernel2D_F32 gaussian2D_F32(double d, int i, boolean z, boolean z2) {
        Kernel1D_F32 kernel1D_F32Gaussian1D_F32 = gaussian1D_F32(d, i, z, false);
        Kernel2D_F32 kernel2D_F32Convolve2D = KernelMath.convolve2D(kernel1D_F32Gaussian1D_F32, kernel1D_F32Gaussian1D_F32);
        if (z2) {
            KernelMath.normalizeSumToOne(kernel2D_F32Convolve2D);
        }
        return kernel2D_F32Convolve2D;
    }

    public static Kernel2D_F64 gaussian2D_F64(double d, int i, boolean z, boolean z2) {
        Kernel1D_F64 kernel1D_F64Gaussian1D_F64 = gaussian1D_F64(d, i, z, false);
        Kernel2D_F64 kernel2D_F64Convolve2D = KernelMath.convolve2D(kernel1D_F64Gaussian1D_F64, kernel1D_F64Gaussian1D_F64);
        if (z2) {
            KernelMath.normalizeSumToOne(kernel2D_F64Convolve2D);
        }
        return kernel2D_F64Convolve2D;
    }

    public static double sigmaForRadius(double d, int i) {
        if (d > 0.0d) {
            return ((d * 2.0d) + 1.0d) / ((((double) i) * 0.8d) + 5.0d);
        }
        throw new IllegalArgumentException("Radius must be > 0");
    }

    public static int radiusForSigma(double d, int i) {
        if (d <= 0.0d) {
            throw new IllegalArgumentException("Sigma must be > 0");
        }
        return (int) Math.ceil(((((((double) i) * 0.8d) + 5.0d) * d) - 1.0d) / 2.0d);
    }
}
