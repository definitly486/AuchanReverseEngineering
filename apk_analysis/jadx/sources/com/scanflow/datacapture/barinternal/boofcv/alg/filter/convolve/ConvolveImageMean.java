package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve;

import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ImplConvolveMean_MT;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.normalized.ConvolveNormalized_JustBorder_SB;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.factory.filter.kernel.FactoryKernel;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageMean {
    public static void horizontal(GrayU8 grayU8, GrayI8 grayI8, int i, int i2) {
        grayI8.reshape(grayU8);
        if (BOverrideConvolveImageMean.invokeNativeHorizontal(grayU8, grayI8, i, i2)) {
            return;
        }
        Kernel1D_S32 kernel1D_S32Table1D_S32 = FactoryKernel.table1D_S32(i, i2);
        if (i2 > grayU8.width) {
            ConvolveImageNormalized.horizontal(kernel1D_S32Table1D_S32, grayU8, grayI8);
            return;
        }
        ConvolveNormalized_JustBorder_SB.horizontal(kernel1D_S32Table1D_S32, grayU8, grayI8);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvolveMean_MT.horizontal(grayU8, grayI8, i, i2);
        } else {
            ImplConvolveMean.horizontal(grayU8, grayI8, i, i2);
        }
    }

    public static void vertical(GrayU8 grayU8, GrayI8 grayI8, int i, int i2, GrowArray growArray) {
        grayI8.reshape(grayU8);
        if (BOverrideConvolveImageMean.invokeNativeVertical(grayU8, grayI8, i, i2)) {
            return;
        }
        Kernel1D_S32 kernel1D_S32Table1D_S32 = FactoryKernel.table1D_S32(i, i2);
        if (i2 > grayU8.height) {
            ConvolveImageNormalized.vertical(kernel1D_S32Table1D_S32, grayU8, grayI8);
            return;
        }
        ConvolveNormalized_JustBorder_SB.vertical(kernel1D_S32Table1D_S32, grayU8, grayI8);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvolveMean_MT.vertical(grayU8, grayI8, i, i2, growArray);
        } else {
            ImplConvolveMean.vertical(grayU8, grayI8, i, i2, growArray);
        }
    }

    public static void horizontal(GrayU16 grayU16, GrayI16 grayI16, int i, int i2) {
        grayI16.reshape(grayU16);
        if (BOverrideConvolveImageMean.invokeNativeHorizontal(grayU16, grayI16, i, i2)) {
            return;
        }
        Kernel1D_S32 kernel1D_S32Table1D_S32 = FactoryKernel.table1D_S32(i, i2);
        if (i2 > grayU16.width) {
            ConvolveImageNormalized.horizontal(kernel1D_S32Table1D_S32, grayU16, grayI16);
            return;
        }
        ConvolveNormalized_JustBorder_SB.horizontal(kernel1D_S32Table1D_S32, grayU16, grayI16);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvolveMean_MT.horizontal(grayU16, grayI16, i, i2);
        } else {
            ImplConvolveMean.horizontal(grayU16, grayI16, i, i2);
        }
    }

    public static void vertical(GrayU16 grayU16, GrayI16 grayI16, int i, int i2, GrowArray growArray) {
        grayI16.reshape(grayU16);
        if (BOverrideConvolveImageMean.invokeNativeVertical(grayU16, grayI16, i, i2)) {
            return;
        }
        Kernel1D_S32 kernel1D_S32Table1D_S32 = FactoryKernel.table1D_S32(i, i2);
        if (i2 > grayU16.height) {
            ConvolveImageNormalized.vertical(kernel1D_S32Table1D_S32, grayU16, grayI16);
            return;
        }
        ConvolveNormalized_JustBorder_SB.vertical(kernel1D_S32Table1D_S32, grayU16, grayI16);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvolveMean_MT.vertical(grayU16, grayI16, i, i2, growArray);
        } else {
            ImplConvolveMean.vertical(grayU16, grayI16, i, i2, growArray);
        }
    }

    public static void horizontal(GrayF32 grayF32, GrayF32 grayF33, int i, int i2) {
        grayF33.reshape(grayF32);
        if (BOverrideConvolveImageMean.invokeNativeHorizontal(grayF32, grayF33, i, i2)) {
            return;
        }
        Kernel1D_F32 kernel1D_F32Table1D_F32 = FactoryKernel.table1D_F32(i, i2, true);
        if (i2 > grayF32.width) {
            ConvolveImageNormalized.horizontal(kernel1D_F32Table1D_F32, grayF32, grayF33);
            return;
        }
        ConvolveNormalized_JustBorder_SB.horizontal(kernel1D_F32Table1D_F32, grayF32, grayF33);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvolveMean_MT.horizontal(grayF32, grayF33, i, i2);
        } else {
            ImplConvolveMean.horizontal(grayF32, grayF33, i, i2);
        }
    }

    public static void vertical(GrayF32 grayF32, GrayF32 grayF33, int i, int i2, GrowArray growArray) {
        grayF33.reshape(grayF32);
        if (BOverrideConvolveImageMean.invokeNativeVertical(grayF32, grayF33, i, i2)) {
            return;
        }
        Kernel1D_F32 kernel1D_F32Table1D_F32 = FactoryKernel.table1D_F32(i, i2, true);
        if (i2 > grayF32.height) {
            ConvolveImageNormalized.vertical(kernel1D_F32Table1D_F32, grayF32, grayF33);
            return;
        }
        ConvolveNormalized_JustBorder_SB.vertical(kernel1D_F32Table1D_F32, grayF32, grayF33);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplConvolveMean_MT.vertical(grayF32, grayF33, i, i2, growArray);
        } else {
            ImplConvolveMean.vertical(grayF32, grayF33, i, i2, growArray);
        }
    }
}
