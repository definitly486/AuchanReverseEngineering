package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

/* JADX INFO: loaded from: classes.dex */
public abstract class ThresholdBlockMean implements ThresholdBlock.BlockProcessor {
    protected byte a;
    protected byte b;
    protected int blockHeight;
    protected int blockWidth;
    protected boolean thresholdFromLocalBlocks;

    protected ThresholdBlockMean(boolean z) {
        if (z) {
            this.a = (byte) 1;
            this.b = (byte) 0;
        } else {
            this.a = (byte) 0;
            this.b = (byte) 1;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary.ThresholdBlock.BlockProcessor
    public void init(int i, int i2, boolean z) {
        this.blockWidth = i;
        this.blockHeight = i2;
        this.thresholdFromLocalBlocks = z;
    }

    public boolean isDown() {
        return this.a == 1;
    }
}
