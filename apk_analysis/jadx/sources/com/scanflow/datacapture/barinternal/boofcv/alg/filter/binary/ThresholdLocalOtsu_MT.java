package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdLocalOtsu_MT extends ThresholdLocalOtsu {
    public ThresholdLocalOtsu_MT(boolean z, ConfigLength configLength, double d, double d2, boolean z2) {
        super(z, configLength, d, d2, z2);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdLocalOtsu
    protected void process(final GrayU8 grayU8, final GrayU8 grayU9, final int i, final int i2, final int i3, int i4, final byte b, final byte b2) {
        ConcurrencyOps.loopBlocks(i2, i4, new IntRangeConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdLocalOtsu_MT$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeConsumer
            public final void accept(int i5, int i6) {
                ThresholdLocalOtsu_MT.$r8$lambda$dUCKF_QMbnfjPIhcrBpWUGX8CfQ(this.f$0, grayU8, i, grayU9, i2, b, b2, i3, i5, i6);
            }
        });
        ThresholdLocalOtsu.ApplyHelper applyHelper = (ThresholdLocalOtsu.ApplyHelper) this.helpers.pop();
        applyToBorder(grayU8, grayU9, i2, i4, i, i3, applyHelper);
        this.helpers.recycle(applyHelper);
    }

    public static /* synthetic */ void $r8$lambda$dUCKF_QMbnfjPIhcrBpWUGX8CfQ(ThresholdLocalOtsu_MT thresholdLocalOtsu_MT, GrayU8 grayU8, int i, GrayU8 grayU9, int i2, byte b, byte b2, int i3, int i4, int i5) {
        ThresholdLocalOtsu.ApplyHelper applyHelper = (ThresholdLocalOtsu.ApplyHelper) thresholdLocalOtsu_MT.helpers.pop();
        int i6 = i4;
        while (i6 < i5) {
            int i7 = grayU8.startIndex + (grayU8.stride * i6) + i;
            int i8 = grayU9.startIndex + (grayU9.stride * i6) + i;
            int i9 = i6 - i2;
            applyHelper.computeHistogram(0, i9, grayU8);
            int i10 = i8 + 1;
            int i11 = i7 + 1;
            int i12 = i6;
            grayU9.data[i8] = ((double) (grayU8.data[i7] & UnsignedBytes.MAX_VALUE)) <= applyHelper.otsu.threshold ? b : b2;
            int i13 = i + 1;
            while (i13 < i3) {
                applyHelper.updateHistogramX(i13 - i, i9, grayU8);
                int i14 = i10 + 1;
                int i15 = i11 + 1;
                grayU9.data[i10] = ((double) (grayU8.data[i11] & UnsignedBytes.MAX_VALUE)) <= applyHelper.otsu.threshold ? b : b2;
                i13++;
                grayU8 = grayU8;
                grayU9 = grayU9;
                i10 = i14;
                i11 = i15;
            }
            i6 = i12 + 1;
        }
        thresholdLocalOtsu_MT.helpers.recycle(applyHelper);
    }
}
