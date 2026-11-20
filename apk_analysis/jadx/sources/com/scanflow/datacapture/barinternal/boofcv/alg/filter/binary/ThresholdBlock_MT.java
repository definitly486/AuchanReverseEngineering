package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlock_MT extends ThresholdBlock {
    public ThresholdBlock_MT(ThresholdBlock.BlockProcessor blockProcessor, ConfigLength configLength, boolean z, Class cls) {
        super(blockProcessor, configLength, z, cls);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock
    protected void computeStatistics(final ImageGray imageGray, final int i, int i2) {
        final int numBands = this.stats.getImageType().getNumBands();
        final int i3 = this.stats.stride;
        int i4 = this.blockHeight;
        int i5 = i2 / i4;
        if (i4 * i5 < i2) {
            i5++;
        }
        int i6 = 0;
        ConcurrencyOps.loopFor(0, i5, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock_MT$$ExternalSyntheticLambda0
            @Override // java.util.function.IntConsumer
            public final void accept(int i7) {
                ThresholdBlock_MT.$r8$lambda$A_SfUZzdujV7dIxQsb6nOmjL2zo(this.f$0, i3, i, numBands, imageGray, i7);
            }
        });
        if (i2 != imageGray.height) {
            ThresholdBlock.BlockProcessor blockProcessor = (ThresholdBlock.BlockProcessor) this.processors.pop();
            blockProcessor.init(this.blockWidth, this.blockHeight, this.thresholdFromLocalBlocks);
            int i7 = (i2 / this.blockHeight) * i3;
            int i8 = imageGray.height - i2;
            int i9 = i7;
            while (i6 < i) {
                int i10 = i2;
                blockProcessor.computeBlockStatistics(i6, i10, this.blockWidth, i8, i9, imageGray, this.stats);
                i6 += this.blockWidth;
                i9 += numBands;
                i2 = i10;
            }
            int i11 = i2;
            int i12 = imageGray.width;
            if (i != i12) {
                blockProcessor.computeBlockStatistics(i, i11, i12 - i, i8, i9, imageGray, this.stats);
            }
        }
    }

    public static /* synthetic */ void $r8$lambda$A_SfUZzdujV7dIxQsb6nOmjL2zo(ThresholdBlock_MT thresholdBlock_MT, int i, int i2, int i3, ImageGray imageGray, int i4) {
        ThresholdBlock.BlockProcessor blockProcessor = (ThresholdBlock.BlockProcessor) thresholdBlock_MT.processors.pop();
        blockProcessor.init(thresholdBlock_MT.blockWidth, thresholdBlock_MT.blockHeight, thresholdBlock_MT.thresholdFromLocalBlocks);
        int i5 = thresholdBlock_MT.blockHeight;
        int i6 = i4 * i5;
        int i7 = 0;
        int i8 = (i6 / i5) * i;
        while (i7 < i2) {
            blockProcessor.computeBlockStatistics(i7, i6, thresholdBlock_MT.blockWidth, thresholdBlock_MT.blockHeight, i8, imageGray, thresholdBlock_MT.stats);
            i7 += thresholdBlock_MT.blockWidth;
            i8 += i3;
        }
        int i9 = imageGray.width;
        if (i2 != i9) {
            blockProcessor.computeBlockStatistics(i2, i6, i9 - i2, thresholdBlock_MT.blockHeight, i8, imageGray, thresholdBlock_MT.stats);
        }
        thresholdBlock_MT.processors.recycle(blockProcessor);
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock
    protected void applyThreshold(final ImageGray imageGray, final GrayU8 grayU8) {
        ConcurrencyOps.loopFor(0, this.stats.height, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock_MT$$ExternalSyntheticLambda1
            @Override // java.util.function.IntConsumer
            public final void accept(int i) {
                ThresholdBlock_MT.$r8$lambda$Pt3EE6LR3shwLSRXYi9R_MduhWY(this.f$0, imageGray, grayU8, i);
            }
        });
    }

    public static /* synthetic */ void $r8$lambda$Pt3EE6LR3shwLSRXYi9R_MduhWY(ThresholdBlock_MT thresholdBlock_MT, ImageGray imageGray, GrayU8 grayU8, int i) {
        ThresholdBlock.BlockProcessor blockProcessor = (ThresholdBlock.BlockProcessor) thresholdBlock_MT.processors.pop();
        blockProcessor.init(thresholdBlock_MT.blockWidth, thresholdBlock_MT.blockHeight, thresholdBlock_MT.thresholdFromLocalBlocks);
        int i2 = 0;
        while (true) {
            ImageBase imageBase = thresholdBlock_MT.stats;
            if (i2 >= imageBase.width) {
                return;
            }
            blockProcessor.thresholdBlock(i2, i, imageGray, imageBase, grayU8);
            i2++;
        }
    }
}
