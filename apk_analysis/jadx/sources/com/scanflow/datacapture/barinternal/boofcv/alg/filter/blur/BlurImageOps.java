package com.scanflow.datacapture.barinternal.boofcv.alg.filter.blur;

import com.scanflow.datacapture.barinternal.boofcv.alg.InputSanityCheck;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.ConvolveImageMean;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.ConvolveImageNormalized;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.kernel.FactoryKernelGaussian;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class BlurImageOps {
    public static GrayU8 mean(GrayU8 grayU8, GrayU8 grayU9, int i, GrayU8 grayU10, GrowArray growArray) {
        return mean(grayU8, grayU9, i, i, grayU10, growArray);
    }

    public static GrayU8 mean(GrayU8 grayU8, GrayU8 grayU9, int i, int i2, GrayU8 grayU10, GrowArray growArray) {
        if (i <= 0 || i2 <= 0) {
            throw new IllegalArgumentException("Radius must be > 0");
        }
        GrayU8 grayU11 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU9);
        GrayU8 grayU12 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU10);
        if (BOverrideBlurImageOps.invokeNativeMeanWeighted(grayU8, grayU11, i, i2, grayU12)) {
            return grayU11;
        }
        ConvolveImageMean.horizontal(grayU8, grayU12, i, (i * 2) + 1);
        ConvolveImageMean.vertical(grayU12, grayU11, i2, (i2 * 2) + 1, growArray);
        return grayU11;
    }

    public static GrayU8 gaussian(GrayU8 grayU8, GrayU8 grayU9, double d, int i, GrayU8 grayU10) {
        return gaussian(grayU8, grayU9, d, i, d, i, grayU10);
    }

    public static GrayU8 gaussian(GrayU8 grayU8, GrayU8 grayU9, double d, int i, double d2, int i2, GrayU8 grayU10) {
        GrayU8 grayU11 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU9);
        GrayU8 grayU12 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU10);
        if (!BOverrideBlurImageOps.invokeNativeGaussian(grayU8, grayU11, d, i, d2, i2, grayU12)) {
            Kernel1D_S32 kernel1D_S32 = (Kernel1D_S32) FactoryKernelGaussian.gaussian(Kernel1D_S32.class, d, i);
            Kernel1D_S32 kernel1D_S33 = (d == d2 && i == i2) ? kernel1D_S32 : (Kernel1D_S32) FactoryKernelGaussian.gaussian(Kernel1D_S32.class, d2, i2);
            ConvolveImageNormalized.horizontal(kernel1D_S32, grayU8, grayU12);
            ConvolveImageNormalized.vertical(kernel1D_S33, grayU12, grayU11);
        }
        return grayU11;
    }

    public static GrayU16 mean(GrayU16 grayU16, GrayU16 grayU17, int i, GrayU16 grayU18, GrowArray growArray) {
        return mean(grayU16, grayU17, i, i, grayU18, growArray);
    }

    public static GrayU16 mean(GrayU16 grayU16, GrayU16 grayU17, int i, int i2, GrayU16 grayU18, GrowArray growArray) {
        if (i <= 0 || i2 <= 0) {
            throw new IllegalArgumentException("Radius must be > 0");
        }
        GrayU16 grayU19 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU17);
        GrayU16 grayU110 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU18);
        if (BOverrideBlurImageOps.invokeNativeMeanWeighted(grayU16, grayU19, i, i2, grayU110)) {
            return grayU19;
        }
        ConvolveImageMean.horizontal(grayU16, grayU110, i, (i * 2) + 1);
        ConvolveImageMean.vertical(grayU110, grayU19, i2, (i2 * 2) + 1, growArray);
        return grayU19;
    }

    public static GrayU16 gaussian(GrayU16 grayU16, GrayU16 grayU17, double d, int i, GrayU16 grayU18) {
        return gaussian(grayU16, grayU17, d, i, d, i, grayU18);
    }

    public static GrayU16 gaussian(GrayU16 grayU16, GrayU16 grayU17, double d, int i, double d2, int i2, GrayU16 grayU18) {
        GrayU16 grayU19 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU17);
        GrayU16 grayU110 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU18);
        if (!BOverrideBlurImageOps.invokeNativeGaussian(grayU16, grayU19, d, i, d2, i2, grayU110)) {
            Kernel1D_S32 kernel1D_S32 = (Kernel1D_S32) FactoryKernelGaussian.gaussian(Kernel1D_S32.class, d, i);
            Kernel1D_S32 kernel1D_S33 = (d == d2 && i == i2) ? kernel1D_S32 : (Kernel1D_S32) FactoryKernelGaussian.gaussian(Kernel1D_S32.class, d2, i2);
            ConvolveImageNormalized.horizontal(kernel1D_S32, grayU16, grayU110);
            ConvolveImageNormalized.vertical(kernel1D_S33, grayU110, grayU19);
        }
        return grayU19;
    }

    public static GrayF32 mean(GrayF32 grayF32, GrayF32 grayF33, int i, GrayF32 grayF34, GrowArray growArray) {
        return mean(grayF32, grayF33, i, i, grayF34, growArray);
    }

    public static GrayF32 mean(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, GrayF32 grayF34, GrowArray growArray) {
        if (i <= 0 || i2 <= 0) {
            throw new IllegalArgumentException("Radius must be > 0");
        }
        GrayF32 grayF35 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF33);
        GrayF32 grayF36 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF34);
        if (BOverrideBlurImageOps.invokeNativeMeanWeighted(grayF32, grayF35, i, i2, grayF36)) {
            return grayF35;
        }
        ConvolveImageMean.horizontal(grayF32, grayF36, i, (i * 2) + 1);
        ConvolveImageMean.vertical(grayF36, grayF35, i2, (i2 * 2) + 1, growArray);
        return grayF35;
    }

    public static GrayF32 gaussian(GrayF32 grayF32, GrayF32 grayF33, double d, int i, GrayF32 grayF34) {
        return gaussian(grayF32, grayF33, d, i, d, i, grayF34);
    }

    public static GrayF32 gaussian(GrayF32 grayF32, GrayF32 grayF33, double d, int i, double d2, int i2, GrayF32 grayF34) {
        GrayF32 grayF35 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF33);
        GrayF32 grayF36 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF34);
        if (!BOverrideBlurImageOps.invokeNativeGaussian(grayF32, grayF35, d, i, d2, i2, grayF36)) {
            Kernel1D_F32 kernel1D_F32 = (Kernel1D_F32) FactoryKernelGaussian.gaussian(Kernel1D_F32.class, d, i);
            Kernel1D_F32 kernel1D_F33 = (d == d2 && i == i2) ? kernel1D_F32 : (Kernel1D_F32) FactoryKernelGaussian.gaussian(Kernel1D_F32.class, d2, i2);
            ConvolveImageNormalized.horizontal(kernel1D_F32, grayF32, grayF36);
            ConvolveImageNormalized.vertical(kernel1D_F33, grayF36, grayF35);
        }
        return grayF35;
    }
}
