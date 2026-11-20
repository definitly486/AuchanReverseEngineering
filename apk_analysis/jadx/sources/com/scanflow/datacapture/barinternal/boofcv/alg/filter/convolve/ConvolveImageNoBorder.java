package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve;

import com.scanflow.datacapture.barinternal.boofcv.alg.InputSanityCheck;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageStandard_SB_MT;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_F32_F32;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_F32_F32;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U16_I16_Div;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_MT_U8_I8_Div;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_U16_I16_Div;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve.noborder.ConvolveImageUnrolled_SB_U8_I8_Div;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayI8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ConvolveImageNoBorder {
    public static void horizontal(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        InputSanityCheck.checkSameShape(grayF32, grayF33);
        if (BoofConcurrency.USE_CONCURRENT) {
            if (ConvolveImageUnrolled_SB_MT_F32_F32.horizontal(kernel1D_F32, grayF32, grayF33)) {
                return;
            }
            ConvolveImageStandard_SB_MT.horizontal(kernel1D_F32, grayF32, grayF33);
        } else {
            if (ConvolveImageUnrolled_SB_F32_F32.horizontal(kernel1D_F32, grayF32, grayF33)) {
                return;
            }
            ConvolveImageStandard_SB.horizontal(kernel1D_F32, grayF32, grayF33);
        }
    }

    public static void vertical(Kernel1D_F32 kernel1D_F32, GrayF32 grayF32, GrayF32 grayF33) {
        InputSanityCheck.checkSameShape(grayF32, grayF33);
        if (BoofConcurrency.USE_CONCURRENT) {
            if (ConvolveImageUnrolled_SB_MT_F32_F32.vertical(kernel1D_F32, grayF32, grayF33)) {
                return;
            }
            ConvolveImageStandard_SB_MT.vertical(kernel1D_F32, grayF32, grayF33);
        } else {
            if (ConvolveImageUnrolled_SB_F32_F32.vertical(kernel1D_F32, grayF32, grayF33)) {
                return;
            }
            ConvolveImageStandard_SB.vertical(kernel1D_F32, grayF32, grayF33);
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i) {
        InputSanityCheck.checkSameShape(grayU8, grayI8);
        if (BoofConcurrency.USE_CONCURRENT) {
            if (ConvolveImageUnrolled_SB_MT_U8_I8_Div.horizontal(kernel1D_S32, grayU8, grayI8, i)) {
                return;
            }
            ConvolveImageStandard_SB_MT.horizontal(kernel1D_S32, grayU8, grayI8, i);
        } else {
            if (ConvolveImageUnrolled_SB_U8_I8_Div.horizontal(kernel1D_S32, grayU8, grayI8, i)) {
                return;
            }
            ConvolveImageStandard_SB.horizontal(kernel1D_S32, grayU8, grayI8, i);
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU8 grayU8, GrayI8 grayI8, int i, GrowArray growArray) {
        InputSanityCheck.checkSameShape(grayU8, grayI8);
        if (BoofConcurrency.USE_CONCURRENT) {
            if (ConvolveImageUnrolled_SB_MT_U8_I8_Div.vertical(kernel1D_S32, grayU8, grayI8, i, growArray)) {
                return;
            }
            ConvolveImageStandard_SB_MT.vertical(kernel1D_S32, grayU8, grayI8, i, growArray);
        } else {
            if (ConvolveImageUnrolled_SB_U8_I8_Div.vertical(kernel1D_S32, grayU8, grayI8, i, growArray)) {
                return;
            }
            ConvolveImageStandard_SB.vertical(kernel1D_S32, grayU8, grayI8, i, growArray);
        }
    }

    public static void horizontal(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i) {
        InputSanityCheck.checkSameShape(grayU16, grayI16);
        if (BoofConcurrency.USE_CONCURRENT) {
            if (ConvolveImageUnrolled_SB_MT_U16_I16_Div.horizontal(kernel1D_S32, grayU16, grayI16, i)) {
                return;
            }
            ConvolveImageStandard_SB_MT.horizontal(kernel1D_S32, grayU16, grayI16, i);
        } else {
            if (ConvolveImageUnrolled_SB_U16_I16_Div.horizontal(kernel1D_S32, grayU16, grayI16, i)) {
                return;
            }
            ConvolveImageStandard_SB.horizontal(kernel1D_S32, grayU16, grayI16, i);
        }
    }

    public static void vertical(Kernel1D_S32 kernel1D_S32, GrayU16 grayU16, GrayI16 grayI16, int i, GrowArray growArray) {
        InputSanityCheck.checkSameShape(grayU16, grayI16);
        if (BoofConcurrency.USE_CONCURRENT) {
            if (ConvolveImageUnrolled_SB_MT_U16_I16_Div.vertical(kernel1D_S32, grayU16, grayI16, i, growArray)) {
                return;
            }
            ConvolveImageStandard_SB_MT.vertical(kernel1D_S32, grayU16, grayI16, i, growArray);
        } else {
            if (ConvolveImageUnrolled_SB_U16_I16_Div.vertical(kernel1D_S32, grayU16, grayI16, i, growArray)) {
                return;
            }
            ConvolveImageStandard_SB.vertical(kernel1D_S32, grayU16, grayI16, i, growArray);
        }
    }
}
