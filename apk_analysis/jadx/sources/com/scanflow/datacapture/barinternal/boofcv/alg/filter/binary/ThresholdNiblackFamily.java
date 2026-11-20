package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary;
import com.scanflow.datacapture.barinternal.boofcv.alg.filter.blur.BlurImageOps;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.ImageStatistics;
import com.scanflow.datacapture.barinternal.boofcv.alg.misc.PixelMath;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdNiblackFamily implements InputToBinary {
    boolean down;
    float k;
    float maxStdev;
    float minItensity;
    Threshold op;
    Variant variant;
    ConfigLength width;
    GrayF32 inputPow2 = new GrayF32(1, 1);
    GrayF32 inputMean = new GrayF32(1, 1);
    GrayF32 inputMeanPow2 = new GrayF32(1, 1);
    GrayF32 inputPow2Mean = new GrayF32(1, 1);
    GrayF32 stdev = new GrayF32(1, 1);
    GrayF32 tmp = new GrayF32(1, 1);
    GrowArray work = new GrowArray(new ThresholdNiblackFamily$$ExternalSyntheticLambda0());

    interface Threshold {
        float compute(float f, float f2);
    }

    public enum Variant {
        NIBLACK,
        SAUVOLA,
        WOLF_JOLION
    }

    public ThresholdNiblackFamily(ConfigLength configLength, float f, boolean z, Variant variant) {
        Threshold sauvola;
        this.k = f;
        this.width = configLength;
        this.down = z;
        this.variant = variant;
        int i = AnonymousClass1.$SwitchMap$boofcv$alg$filter$binary$ThresholdNiblackFamily$Variant[variant.ordinal()];
        if (i == 1) {
            sauvola = new Sauvola();
        } else if (i == 2) {
            sauvola = new Niblack();
        } else {
            if (i != 3) {
                throw new IncompatibleClassChangeError();
            }
            sauvola = new WolfJolion();
        }
        this.op = sauvola;
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$boofcv$alg$filter$binary$ThresholdNiblackFamily$Variant;

        static {
            int[] iArr = new int[Variant.values().length];
            $SwitchMap$boofcv$alg$filter$binary$ThresholdNiblackFamily$Variant = iArr;
            try {
                iArr[Variant.SAUVOLA.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$boofcv$alg$filter$binary$ThresholdNiblackFamily$Variant[Variant.NIBLACK.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$boofcv$alg$filter$binary$ThresholdNiblackFamily$Variant[Variant.WOLF_JOLION.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(GrayF32 grayF32, GrayU8 grayU8) {
        grayU8.reshape(grayF32);
        this.inputPow2.reshape(grayF32);
        this.inputMean.reshape(grayF32);
        this.inputMeanPow2.reshape(grayF32);
        this.inputPow2Mean.reshape(grayF32);
        this.stdev.reshape(grayF32);
        this.tmp.reshape(grayF32);
        this.inputPow2.reshape(grayF32);
        int iComputeI = this.width.computeI(Math.min(grayF32.width, grayF32.height)) / 2;
        BlurImageOps.mean(grayF32, this.inputMean, iComputeI, this.tmp, this.work);
        PixelMath.pow2(grayF32, this.inputPow2);
        BlurImageOps.mean(this.inputPow2, this.inputPow2Mean, iComputeI, this.tmp, this.work);
        PixelMath.pow2(this.inputMean, this.inputMeanPow2);
        PixelMath.subtract(this.inputPow2Mean, this.inputMeanPow2, this.stdev);
        GrayF32 grayF33 = this.stdev;
        PixelMath.sqrt(grayF33, grayF33);
        Variant variant = this.variant;
        if (variant == Variant.SAUVOLA || variant == Variant.WOLF_JOLION) {
            this.maxStdev = ImageStatistics.max(this.stdev);
        }
        if (this.variant == Variant.WOLF_JOLION) {
            this.minItensity = ImageStatistics.min(grayF32);
        }
        applyThresholding(grayF32, grayU8);
    }

    protected void applyThresholding(GrayF32 grayF32, GrayU8 grayU8) {
        if (this.down) {
            for (int i = 0; i < grayF32.height; i++) {
                int i2 = this.stdev.width * i;
                int i3 = grayF32.startIndex + (grayF32.stride * i);
                int i4 = grayU8.startIndex + (grayU8.stride * i);
                int i5 = 0;
                while (i5 < grayF32.width) {
                    int i6 = i4 + 1;
                    int i7 = i3 + 1;
                    grayU8.data[i4] = (byte) (grayF32.data[i3] <= this.op.compute(this.inputMean.data[i2], this.stdev.data[i2]) ? 1 : 0);
                    i5++;
                    i2++;
                    i4 = i6;
                    i3 = i7;
                }
            }
            return;
        }
        for (int i8 = 0; i8 < grayF32.height; i8++) {
            int i9 = this.stdev.width * i8;
            int i10 = grayF32.startIndex + (grayF32.stride * i8);
            int i11 = grayU8.startIndex + (grayU8.stride * i8);
            int i12 = 0;
            while (i12 < grayF32.width) {
                int i13 = i11 + 1;
                int i14 = i10 + 1;
                grayU8.data[i11] = (byte) (grayF32.data[i10] >= this.op.compute(this.inputMean.data[i9], this.stdev.data[i9]) ? 1 : 0);
                i12++;
                i9++;
                i11 = i13;
                i10 = i14;
            }
        }
    }

    class Niblack implements Threshold {
        Niblack() {
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily.Threshold
        public final float compute(float f, float f2) {
            return f + (ThresholdNiblackFamily.this.k * f2);
        }
    }

    class Sauvola implements Threshold {
        Sauvola() {
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily.Threshold
        public final float compute(float f, float f2) {
            ThresholdNiblackFamily thresholdNiblackFamily = ThresholdNiblackFamily.this;
            return f * ((thresholdNiblackFamily.k * ((f2 / thresholdNiblackFamily.maxStdev) - 1.0f)) + 1.0f);
        }
    }

    class WolfJolion implements Threshold {
        WolfJolion() {
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily.Threshold
        public final float compute(float f, float f2) {
            ThresholdNiblackFamily thresholdNiblackFamily = ThresholdNiblackFamily.this;
            return f + (thresholdNiblackFamily.k * ((f2 / thresholdNiblackFamily.maxStdev) - 1.0f) * (f - thresholdNiblackFamily.minItensity));
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return ImageType.SB_F32;
    }
}
