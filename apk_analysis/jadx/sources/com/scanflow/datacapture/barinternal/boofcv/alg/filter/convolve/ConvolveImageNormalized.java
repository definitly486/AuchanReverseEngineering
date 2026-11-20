package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.normalized.ConvolveNormalizedNaive_SB;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.normalized.ConvolveNormalized_JustBorder_SB;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.kernel.KernelMath;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageNormalized {
    public static void horizontal(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        grayF33.reshape(grayF32.width, grayF32.height);
        if (BOverrideConvolveImageNormalized.invokeNativeHorizontal(kernel1D_F32, grayF32, grayF33)) {
            return;
        }
        if (kernel1D_F32.width >= grayF32.width) {
            ConvolveNormalizedNaive_SB.horizontal(kernel1D_F32, grayF32, grayF33);
            return;
        }
        if (Math.abs(kernel1D_F32.computeSum() - 1.0f) > 1.0E-4f) {
            kernel1D_F32 = kernel1D_F32.copy();
            KernelMath.normalizeSumToOne(kernel1D_F32);
        }
        ConvolveImageNoBorder.horizontal(kernel1D_F32, grayF32, grayF33);
        ConvolveNormalized_JustBorder_SB.horizontal(kernel1D_F32, grayF32, grayF33);
    }

    public static void vertical(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        grayF33.reshape(grayF32.width, grayF32.height);
        if (BOverrideConvolveImageNormalized.invokeNativeVertical(kernel1D_F32, grayF32, grayF33)) {
            return;
        }
        if (kernel1D_F32.width >= grayF32.height) {
            ConvolveNormalizedNaive_SB.vertical(kernel1D_F32, grayF32, grayF33);
            return;
        }
        if (Math.abs(kernel1D_F32.computeSum() - 1.0f) > 1.0E-4f) {
            kernel1D_F32 = kernel1D_F32.copy();
            KernelMath.normalizeSumToOne(kernel1D_F32);
        }
        ConvolveImageNoBorder.vertical(kernel1D_F32, grayF32, grayF33);
        ConvolveNormalized_JustBorder_SB.vertical(kernel1D_F32, grayF32, grayF33);
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8) {
        grayI8.reshape(grayU8.width, grayU8.height);
        if (BOverrideConvolveImageNormalized.invokeNativeHorizontal(kernel1D_S32, grayU8, grayI8)) {
            return;
        }
        if (kernel1D_S32.width >= grayU8.width) {
            ConvolveNormalizedNaive_SB.horizontal(kernel1D_S32, grayU8, grayI8);
        } else {
            ConvolveImageNoBorder.horizontal(kernel1D_S32, grayU8, grayI8, kernel1D_S32.computeSum());
            ConvolveNormalized_JustBorder_SB.horizontal(kernel1D_S32, grayU8, grayI8);
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8) {
        grayI8.reshape(grayU8.width, grayU8.height);
        if (BOverrideConvolveImageNormalized.invokeNativeVertical(kernel1D_S32, grayU8, grayI8)) {
            return;
        }
        if (kernel1D_S32.width >= grayU8.height) {
            ConvolveNormalizedNaive_SB.vertical(kernel1D_S32, grayU8, grayI8);
        } else {
            ConvolveImageNoBorder.vertical(kernel1D_S32, grayU8, grayI8, kernel1D_S32.computeSum(), (GrowArray) null);
            ConvolveNormalized_JustBorder_SB.vertical(kernel1D_S32, grayU8, grayI8);
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16) {
        grayI16.reshape(grayU16.width, grayU16.height);
        if (BOverrideConvolveImageNormalized.invokeNativeHorizontal(kernel1D_S32, grayU16, grayI16)) {
            return;
        }
        if (kernel1D_S32.width >= grayU16.width) {
            ConvolveNormalizedNaive_SB.horizontal(kernel1D_S32, grayU16, grayI16);
        } else {
            ConvolveImageNoBorder.horizontal(kernel1D_S32, grayU16, grayI16, kernel1D_S32.computeSum());
            ConvolveNormalized_JustBorder_SB.horizontal(kernel1D_S32, grayU16, grayI16);
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16) {
        grayI16.reshape(grayU16.width, grayU16.height);
        if (BOverrideConvolveImageNormalized.invokeNativeVertical(kernel1D_S32, grayU16, grayI16)) {
            return;
        }
        if (kernel1D_S32.width >= grayU16.height) {
            ConvolveNormalizedNaive_SB.vertical(kernel1D_S32, grayU16, grayI16);
        } else {
            ConvolveImageNoBorder.vertical(kernel1D_S32, grayU16, grayI16, kernel1D_S32.computeSum(), (GrowArray) null);
            ConvolveNormalized_JustBorder_SB.vertical(kernel1D_S32, grayU16, grayI16);
        }
    }
}
