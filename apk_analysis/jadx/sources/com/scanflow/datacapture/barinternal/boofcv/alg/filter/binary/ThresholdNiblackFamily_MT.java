package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayF32;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdNiblackFamily_MT extends ThresholdNiblackFamily {
    public ThresholdNiblackFamily_MT(ConfigLength configLength, float f, boolean z, ThresholdNiblackFamily.Variant variant) {
        super(configLength, f, z, variant);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily
    protected void applyThresholding(final GrayF32 grayF32, final GrayU8 grayU8) {
        if (this.down) {
            ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily_MT$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ThresholdNiblackFamily_MT.$r8$lambda$Qi3Rg0LWXfegsxJoFfZU0LqKSm0(this.f$0, grayF32, grayU8, i);
                }
            });
        } else {
            ConcurrencyOps.loopFor(0, grayF32.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdNiblackFamily_MT$$ExternalSyntheticLambda1
                @Override // java.util.function.IntConsumer
                public final void accept(int i) {
                    ThresholdNiblackFamily_MT.$r8$lambda$nal9l7lLBP8HhWO0aQbO6XFW8n0(this.f$0, grayF32, grayU8, i);
                }
            });
        }
    }

    public static /* synthetic */ void $r8$lambda$Qi3Rg0LWXfegsxJoFfZU0LqKSm0(ThresholdNiblackFamily_MT thresholdNiblackFamily_MT, GrayF32 grayF32, GrayU8 grayU8, int i) {
        int i2 = thresholdNiblackFamily_MT.stdev.width * i;
        int i3 = grayF32.startIndex + (grayF32.stride * i);
        int i4 = grayU8.startIndex + (i * grayU8.stride);
        int i5 = 0;
        while (i5 < grayF32.width) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) (grayF32.data[i3] <= thresholdNiblackFamily_MT.op.compute(thresholdNiblackFamily_MT.inputMean.data[i2], thresholdNiblackFamily_MT.stdev.data[i2]) ? 1 : 0);
            i5++;
            i2++;
            i4 = i6;
            i3 = i7;
        }
    }

    public static /* synthetic */ void $r8$lambda$nal9l7lLBP8HhWO0aQbO6XFW8n0(ThresholdNiblackFamily_MT thresholdNiblackFamily_MT, GrayF32 grayF32, GrayU8 grayU8, int i) {
        int i2 = thresholdNiblackFamily_MT.stdev.width * i;
        int i3 = grayF32.startIndex + (grayF32.stride * i);
        int i4 = grayU8.startIndex + (i * grayU8.stride);
        int i5 = 0;
        while (i5 < grayF32.width) {
            int i6 = i4 + 1;
            int i7 = i3 + 1;
            grayU8.data[i4] = (byte) (grayF32.data[i3] >= thresholdNiblackFamily_MT.op.compute(thresholdNiblackFamily_MT.inputMean.data[i2], thresholdNiblackFamily_MT.stdev.data[i2]) ? 1 : 0);
            i5++;
            i2++;
            i4 = i6;
            i3 = i7;
        }
    }
}
