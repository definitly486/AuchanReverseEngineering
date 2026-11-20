package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.boofcv.struct.lists.RecycleStack;
import java.util.Arrays;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdLocalOtsu implements InputToBinary {
    private final boolean down;
    int numPixels;
    int regionWidth;
    ConfigLength regionWidthLength;
    private final double scale;
    private final double tuning;
    private final boolean useOtsu2;
    ImageType imageType = ImageType.single(GrayU8.class);
    RecycleStack helpers = new RecycleStack(new RecycleStack.Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdLocalOtsu$$ExternalSyntheticLambda0
        @Override // com.scanflow.datacapture.barinternal.boofcv.struct.lists.RecycleStack.Factory
        public final Object newInstance() {
            return ThresholdLocalOtsu.m632$r8$lambda$XG_ZRSFmmuDVB2y8CiM5vm4n3U(this.f$0);
        }
    });

    /* JADX INFO: renamed from: $r8$lambda$XG_-ZRSFmmuDVB2y8CiM5vm4n3U, reason: not valid java name */
    public static /* synthetic */ ApplyHelper m632$r8$lambda$XG_ZRSFmmuDVB2y8CiM5vm4n3U(ThresholdLocalOtsu thresholdLocalOtsu) {
        thresholdLocalOtsu.getClass();
        return thresholdLocalOtsu.new ApplyHelper();
    }

    public ThresholdLocalOtsu(boolean z, ConfigLength configLength, double d, double d2, boolean z2) {
        this.regionWidthLength = configLength;
        this.useOtsu2 = z;
        this.tuning = d;
        this.scale = d2;
        this.down = z2;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(GrayU8 grayU8, GrayU8 grayU9) {
        grayU9.reshape(grayU8.width, grayU8.height);
        int iComputeI = this.regionWidthLength.computeI(Math.min(grayU8.width, grayU8.height));
        this.regionWidth = iComputeI;
        int i = grayU8.width;
        if (i < iComputeI || grayU8.height < iComputeI) {
            this.regionWidth = Math.min(i, grayU8.height);
        }
        int i2 = this.regionWidth;
        this.numPixels = i2 * i2;
        int i3 = i2 / 2;
        int i4 = grayU8.height - (i2 - i3);
        int i5 = i2 / 2;
        int i6 = grayU8.width - (i2 - i5);
        boolean z = this.down;
        process(grayU8, grayU9, i5, i3, i6, i4, z ? (byte) 1 : (byte) 0, !z ? (byte) 1 : (byte) 0);
    }

    protected void process(GrayU8 grayU8, GrayU8 grayU9, int i, int i2, int i3, int i4, byte b, byte b2) {
        ThresholdLocalOtsu thresholdLocalOtsu = this;
        ApplyHelper applyHelper = (ApplyHelper) thresholdLocalOtsu.helpers.pop();
        int i5 = i2;
        while (i5 < i4) {
            int i6 = grayU8.startIndex + (grayU8.stride * i5) + i;
            int i7 = grayU9.startIndex + (grayU9.stride * i5) + i;
            int i8 = i5 - i2;
            applyHelper.computeHistogram(0, i8, grayU8);
            int i9 = i7 + 1;
            int i10 = i6 + 1;
            int i11 = i5;
            grayU9.data[i7] = ((double) (grayU8.data[i6] & UnsignedBytes.MAX_VALUE)) <= applyHelper.otsu.threshold ? b : b2;
            int i12 = i + 1;
            while (i12 < i3) {
                applyHelper.updateHistogramX(i12 - i, i8, grayU8);
                int i13 = i9 + 1;
                int i14 = i10 + 1;
                grayU9.data[i9] = ((double) (grayU8.data[i10] & UnsignedBytes.MAX_VALUE)) <= applyHelper.otsu.threshold ? b : b2;
                i12++;
                grayU8 = grayU8;
                i9 = i13;
                i10 = i14;
            }
            i5 = i11 + 1;
            thresholdLocalOtsu = this;
        }
        thresholdLocalOtsu.applyToBorder(grayU8, grayU9, i2, i4, i, i3, applyHelper);
        thresholdLocalOtsu.helpers.recycle(applyHelper);
    }

    void applyToBorder(GrayU8 grayU8, GrayU8 grayU9, int i, int i2, int i3, int i4, ApplyHelper applyHelper) {
        ApplyHelper applyHelper2 = applyHelper;
        applyHelper2.computeHistogram(0, 0, grayU8);
        int i5 = i3 + 1;
        int i6 = i + 1;
        applyHelper2.applyToBlock(0, 0, i5, i6, grayU8, grayU9);
        int i7 = i5;
        while (i7 < i4) {
            applyHelper2.updateHistogramX(i7 - i3, 0, grayU8);
            int i8 = i7 + 1;
            applyHelper2.applyToBlock(i7, 0, i8, i, grayU8, grayU9);
            i7 = i8;
        }
        int i9 = i4 - i3;
        applyHelper2.updateHistogramX(i9, 0, grayU8);
        applyHelper2.applyToBlock(i4, 0, grayU8.width, i6, grayU8, grayU9);
        int i10 = i6;
        while (i10 < i2) {
            applyHelper2.updateHistogramY(i9, i10 - i, grayU8);
            int i11 = i10 + 1;
            applyHelper2.applyToBlock(i4, i10, grayU8.width, i11, grayU8, grayU9);
            i10 = i11;
        }
        int i12 = i2 - i;
        applyHelper2.updateHistogramY(i9, i12, grayU8);
        applyHelper2.applyToBlock(i4, i2, grayU8.width, grayU8.height, grayU8, grayU9);
        applyHelper2.computeHistogram(0, 0, grayU8);
        int i13 = i6;
        while (i13 < i2) {
            applyHelper2.updateHistogramY(0, i13 - i, grayU8);
            int i14 = i13 + 1;
            applyHelper2.applyToBlock(0, i13, i3, i14, grayU8, grayU9);
            i13 = i14;
        }
        applyHelper2.updateHistogramY(0, i12, grayU8);
        int i15 = i5;
        applyHelper2.applyToBlock(0, i2, i15, grayU8.height, grayU8, grayU9);
        while (true) {
            int i16 = i15;
            if (i16 >= i4) {
                return;
            }
            applyHelper2.updateHistogramX(i16 - i3, i12, grayU8);
            i15 = i16 + 1;
            applyHelper2.applyToBlock(i16, i2, i15, grayU8.height, grayU8, grayU9);
            applyHelper2 = applyHelper;
        }
    }

    class ApplyHelper {
        int[] histogram = new int[256];
        ComputeOtsu otsu;

        ApplyHelper() {
            this.otsu = new ComputeOtsu(ThresholdLocalOtsu.this.useOtsu2, ThresholdLocalOtsu.this.tuning, ThresholdLocalOtsu.this.down, ThresholdLocalOtsu.this.scale);
        }

        /* JADX INFO: Access modifiers changed from: private */
        /* JADX WARN: Multi-variable type inference failed */
        public void applyToBlock(int i, int i2, int i3, int i4, GrayU8 grayU8, GrayU8 grayU9) {
            ApplyHelper applyHelper = this;
            boolean z = applyHelper.otsu.down;
            boolean z2 = !z;
            int i5 = i2;
            while (i5 < i4) {
                int i6 = grayU8.startIndex + (grayU8.stride * i5) + i;
                int i7 = grayU9.startIndex + (grayU9.stride * i5) + i;
                int i8 = (i3 - i) + i7;
                while (i7 < i8) {
                    int i9 = i7 + 1;
                    int i10 = i6 + 1;
                    grayU9.data[i7] = ((double) (grayU8.data[i6] & UnsignedBytes.MAX_VALUE)) <= applyHelper.otsu.threshold ? z : z2;
                    applyHelper = this;
                    grayU8 = grayU8;
                    i7 = i9;
                    i6 = i10;
                }
                i5++;
                applyHelper = this;
            }
        }

        void computeHistogram(int i, int i2, GrayU8 grayU8) {
            Arrays.fill(this.histogram, 0);
            int i3 = 0;
            while (true) {
                ThresholdLocalOtsu thresholdLocalOtsu = ThresholdLocalOtsu.this;
                if (i3 < thresholdLocalOtsu.regionWidth) {
                    int i4 = grayU8.startIndex + ((i2 + i3) * grayU8.stride) + i;
                    int i5 = 0;
                    while (i5 < ThresholdLocalOtsu.this.regionWidth) {
                        int[] iArr = this.histogram;
                        int i6 = i4 + 1;
                        int i7 = grayU8.data[i4] & UnsignedBytes.MAX_VALUE;
                        iArr[i7] = iArr[i7] + 1;
                        i5++;
                        i4 = i6;
                    }
                    i3++;
                } else {
                    ComputeOtsu computeOtsu = this.otsu;
                    int[] iArr2 = this.histogram;
                    computeOtsu.compute(iArr2, iArr2.length, thresholdLocalOtsu.numPixels);
                    return;
                }
            }
        }

        void updateHistogramX(int i, int i2, GrayU8 grayU8) {
            if (i <= 0) {
                return;
            }
            int i3 = ((grayU8.startIndex + (i2 * grayU8.stride)) + i) - 1;
            int i4 = 0;
            while (true) {
                ThresholdLocalOtsu thresholdLocalOtsu = ThresholdLocalOtsu.this;
                int i5 = thresholdLocalOtsu.regionWidth;
                if (i4 < i5) {
                    int[] iArr = this.histogram;
                    byte[] bArr = grayU8.data;
                    int i6 = bArr[i3] & UnsignedBytes.MAX_VALUE;
                    iArr[i6] = iArr[i6] - 1;
                    int i7 = bArr[i5 + i3] & UnsignedBytes.MAX_VALUE;
                    iArr[i7] = iArr[i7] + 1;
                    i3 += grayU8.stride;
                    i4++;
                } else {
                    ComputeOtsu computeOtsu = this.otsu;
                    int[] iArr2 = this.histogram;
                    computeOtsu.compute(iArr2, iArr2.length, thresholdLocalOtsu.numPixels);
                    return;
                }
            }
        }

        void updateHistogramY(int i, int i2, GrayU8 grayU8) {
            if (i2 <= 0) {
                return;
            }
            int i3 = ThresholdLocalOtsu.this.regionWidth * grayU8.stride;
            int i4 = 0;
            while (true) {
                ThresholdLocalOtsu thresholdLocalOtsu = ThresholdLocalOtsu.this;
                if (i4 < thresholdLocalOtsu.regionWidth) {
                    int i5 = grayU8.startIndex + ((i2 - 1) * grayU8.stride) + i + i4;
                    int[] iArr = this.histogram;
                    byte[] bArr = grayU8.data;
                    int i6 = bArr[i5] & UnsignedBytes.MAX_VALUE;
                    iArr[i6] = iArr[i6] - 1;
                    int i7 = bArr[i5 + i3] & UnsignedBytes.MAX_VALUE;
                    iArr[i7] = iArr[i7] + 1;
                    i4++;
                } else {
                    ComputeOtsu computeOtsu = this.otsu;
                    int[] iArr2 = this.histogram;
                    computeOtsu.compute(iArr2, iArr2.length, thresholdLocalOtsu.numPixels);
                    return;
                }
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return this.imageType;
    }
}
