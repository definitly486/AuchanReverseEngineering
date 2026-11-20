package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.alg.InputSanityCheck;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.impl.ImplThresholdImageOps_MT;
import com.scanflow.datacapture.barinternal.boofcv.concurrency.BoofConcurrency;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF64;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayS32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU16;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class ThresholdImageOps {
    public static GrayU8 threshold(GrayF32 grayF32, GrayU8 grayU8, float f, boolean z) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayF32, grayU8, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.threshold(grayF32, grayU9, f, z);
            return grayU9;
        }
        ImplThresholdImageOps.threshold(grayF32, grayU9, f, z);
        return grayU9;
    }

    public static GrayU8 threshold(GrayF64 grayF64, GrayU8 grayU8, double d, boolean z) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayF64, grayU8, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.threshold(grayF64, grayU9, d, z);
            return grayU9;
        }
        ImplThresholdImageOps.threshold(grayF64, grayU9, d, z);
        return grayU9;
    }

    public static GrayU8 threshold(GrayU8 grayU8, GrayU8 grayU9, int i, boolean z) {
        GrayU8 grayU10 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU9, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.threshold(grayU8, grayU10, i, z);
            return grayU10;
        }
        ImplThresholdImageOps.threshold(grayU8, grayU10, i, z);
        return grayU10;
    }

    public static GrayU8 threshold(GrayS16 grayS16, GrayU8 grayU8, int i, boolean z) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayS16, grayU8, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.threshold(grayS16, grayU9, i, z);
            return grayU9;
        }
        ImplThresholdImageOps.threshold(grayS16, grayU9, i, z);
        return grayU9;
    }

    public static GrayU8 threshold(GrayU16 grayU16, GrayU8 grayU8, int i, boolean z) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayU16, grayU8, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.threshold(grayU16, grayU9, i, z);
            return grayU9;
        }
        ImplThresholdImageOps.threshold(grayU16, grayU9, i, z);
        return grayU9;
    }

    public static GrayU8 threshold(GrayS32 grayS32, GrayU8 grayU8, int i, boolean z) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayS32, grayU8, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.threshold(grayS32, grayU9, i, z);
            return grayU9;
        }
        ImplThresholdImageOps.threshold(grayS32, grayU9, i, z);
        return grayU9;
    }

    public static GrayU8 localMean(GrayU8 grayU8, GrayU8 grayU9, ConfigLength configLength, float f, boolean z, GrayU8 grayU10, GrayU8 grayU11, GrowArray growArray) {
        GrayU8 grayU12 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU9, GrayU8.class);
        GrayU8 grayU13 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU10, GrayU8.class);
        GrayU8 grayU14 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU11, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.localMean(grayU8, grayU12, configLength, f, z, grayU13, grayU14, growArray);
            return grayU12;
        }
        ImplThresholdImageOps.localMean(grayU8, grayU12, configLength, f, z, grayU13, grayU14, growArray);
        return grayU12;
    }

    public static GrayU8 localGaussian(GrayU8 grayU8, GrayU8 grayU9, ConfigLength configLength, float f, boolean z, GrayU8 grayU10, GrayU8 grayU11) {
        GrayU8 grayU12 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU9, GrayU8.class);
        GrayU8 grayU13 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU10, GrayU8.class);
        GrayU8 grayU14 = (GrayU8) InputSanityCheck.declareOrReshape(grayU8, grayU11, GrayU8.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.localGaussian(grayU8, grayU12, configLength, f, z, grayU13, grayU14);
            return grayU12;
        }
        ImplThresholdImageOps.localGaussian(grayU8, grayU12, configLength, f, z, grayU13, grayU14);
        return grayU12;
    }

    public static GrayU8 localMean(GrayU16 grayU16, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayU16 grayU17, GrayU16 grayU18, GrowArray growArray) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayU16, grayU8, GrayU8.class);
        GrayU16 grayU19 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU17, GrayU16.class);
        GrayU16 grayU110 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU18, GrayU16.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.localMean(grayU16, grayU9, configLength, f, z, grayU19, grayU110, growArray);
            return grayU9;
        }
        ImplThresholdImageOps.localMean(grayU16, grayU9, configLength, f, z, grayU19, grayU110, growArray);
        return grayU9;
    }

    public static GrayU8 localGaussian(GrayU16 grayU16, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayU16 grayU17, GrayU16 grayU18) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayU16, grayU8, GrayU8.class);
        GrayU16 grayU19 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU17, GrayU16.class);
        GrayU16 grayU110 = (GrayU16) InputSanityCheck.declareOrReshape(grayU16, grayU18, GrayU16.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.localGaussian(grayU16, grayU9, configLength, f, z, grayU19, grayU110);
            return grayU9;
        }
        ImplThresholdImageOps.localGaussian(grayU16, grayU9, configLength, f, z, grayU19, grayU110);
        return grayU9;
    }

    public static GrayU8 localMean(GrayF32 grayF32, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayF32 grayF33, GrayF32 grayF34, GrowArray growArray) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayF32, grayU8, GrayU8.class);
        GrayF32 grayF35 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF33, GrayF32.class);
        GrayF32 grayF36 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF34, GrayF32.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.localMean(grayF32, grayU9, configLength, f, z, grayF35, grayF36, growArray);
            return grayU9;
        }
        ImplThresholdImageOps.localMean(grayF32, grayU9, configLength, f, z, grayF35, grayF36, growArray);
        return grayU9;
    }

    public static GrayU8 localGaussian(GrayF32 grayF32, GrayU8 grayU8, ConfigLength configLength, float f, boolean z, GrayF32 grayF33, GrayF32 grayF34) {
        GrayU8 grayU9 = (GrayU8) InputSanityCheck.declareOrReshape(grayF32, grayU8, GrayU8.class);
        GrayF32 grayF35 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF33, GrayF32.class);
        GrayF32 grayF36 = (GrayF32) InputSanityCheck.declareOrReshape(grayF32, grayF34, GrayF32.class);
        if (BoofConcurrency.USE_CONCURRENT) {
            ImplThresholdImageOps_MT.localGaussian(grayF32, grayU9, configLength, f, z, grayF35, grayF36);
            return grayU9;
        }
        ImplThresholdImageOps.localGaussian(grayF32, grayU9, configLength, f, z, grayF35, grayF36);
        return grayU9;
    }
}
