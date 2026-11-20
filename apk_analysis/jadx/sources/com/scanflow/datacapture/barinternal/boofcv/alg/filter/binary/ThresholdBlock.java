package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary;
import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageGray;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageType;
import com.scanflow.datacapture.barinternal.boofcv.struct.lists.RecycleStack;

/* JADX INFO: loaded from: classes.dex */
public class ThresholdBlock implements InputToBinary {
    protected int blockHeight;
    protected int blockWidth;
    ImageType imageType;
    protected BlockProcessor original;
    protected RecycleStack processors;
    protected ConfigLength requestedBlockWidth;
    protected ImageBase stats;
    protected boolean thresholdFromLocalBlocks;

    public interface BlockProcessor {
        void computeBlockStatistics(int i, int i2, int i3, int i4, int i5, ImageGray imageGray, ImageBase imageBase);

        BlockProcessor copy();

        ImageBase createStats();

        void init(int i, int i2, boolean z);

        void thresholdBlock(int i, int i2, ImageGray imageGray, ImageBase imageBase, GrayU8 grayU8);
    }

    public ThresholdBlock(final BlockProcessor blockProcessor, ConfigLength configLength, boolean z, Class cls) {
        this.requestedBlockWidth = configLength;
        this.imageType = ImageType.single(cls);
        this.thresholdFromLocalBlocks = z;
        this.stats = blockProcessor.createStats();
        this.original = blockProcessor;
        this.processors = new RecycleStack(new RecycleStack.Factory() { // from class: com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.boofcv.struct.lists.RecycleStack.Factory
            public final Object newInstance() {
                return blockProcessor.copy();
            }
        });
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public void process(ImageGray imageGray, GrayU8 grayU8) {
        grayU8.reshape(imageGray.width, imageGray.height);
        selectBlockSize(imageGray.width, imageGray.height, this.requestedBlockWidth.computeI(Math.min(imageGray.width, imageGray.height)));
        this.stats.reshape(imageGray.width / this.blockWidth, imageGray.height / this.blockHeight);
        int i = imageGray.width;
        int i2 = this.blockWidth;
        if (i % i2 != 0) {
            i = (i - i2) - (i % i2);
        }
        int i3 = imageGray.height;
        int i4 = this.blockHeight;
        if (i3 % i4 != 0) {
            i3 = (i3 - i4) - (i3 % i4);
        }
        computeStatistics(imageGray, i, i3);
        applyThreshold(imageGray, grayU8);
    }

    void selectBlockSize(int i, int i2, int i3) {
        if (i2 < i3) {
            this.blockHeight = i2;
        } else {
            this.blockHeight = i2 / (i2 / i3);
        }
        if (i < i3) {
            this.blockWidth = i;
        } else {
            this.blockWidth = i / (i / i3);
        }
    }

    protected void applyThreshold(ImageGray imageGray, GrayU8 grayU8) {
        for (int i = 0; i < this.stats.height; i++) {
            int i2 = 0;
            while (true) {
                ImageBase imageBase = this.stats;
                if (i2 < imageBase.width) {
                    this.original.thresholdBlock(i2, i, imageGray, imageBase, grayU8);
                    i2++;
                }
            }
        }
    }

    protected void computeStatistics(ImageGray imageGray, int i, int i2) {
        int i3 = i2;
        this.original.init(this.blockWidth, this.blockHeight, this.thresholdFromLocalBlocks);
        int numBands = this.stats.getImageType().getNumBands();
        int i4 = 0;
        int i5 = 0;
        while (i5 < i3) {
            int i6 = i4;
            int i7 = 0;
            while (i7 < i) {
                this.original.computeBlockStatistics(i7, i5, this.blockWidth, this.blockHeight, i6, imageGray, this.stats);
                i7 += this.blockWidth;
                i6 += numBands;
            }
            int i8 = imageGray.width;
            if (i != i8) {
                this.original.computeBlockStatistics(i, i5, i8 - i, this.blockHeight, i6, imageGray, this.stats);
                i6 += numBands;
            }
            i4 = i6;
            i5 += this.blockHeight;
        }
        int i9 = imageGray.height;
        if (i3 != i9) {
            int i10 = i9 - i3;
            int i11 = i4;
            int i12 = 0;
            while (i12 < i) {
                this.original.computeBlockStatistics(i12, i3, this.blockWidth, i10, i11, imageGray, this.stats);
                i12 += this.blockWidth;
                i11 += numBands;
                i3 = i2;
            }
            int i13 = imageGray.width;
            if (i != i13) {
                this.original.computeBlockStatistics(i, i2, i13 - i, i10, i11, imageGray, this.stats);
            }
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.abst.filter.binary.InputToBinary
    public ImageType getInputType() {
        return this.imageType;
    }
}
