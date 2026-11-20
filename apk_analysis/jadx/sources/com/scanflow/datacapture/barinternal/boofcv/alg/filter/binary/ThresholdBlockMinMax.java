package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

/* JADX INFO: loaded from: classes.dex */
public abstract class ThresholdBlockMinMax implements ThresholdBlock.BlockProcessor {
    protected int blockHeight;
    protected int blockWidth;
    protected boolean down;
    protected double minimumSpread;
    protected boolean thresholdFromLocalBlocks;

    protected ThresholdBlockMinMax(double d, boolean z) {
        this.minimumSpread = d;
        this.down = z;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void init(int i, int i2, boolean z) {
        this.blockWidth = i;
        this.blockHeight = i2;
        this.thresholdFromLocalBlocks = z;
    }
}
