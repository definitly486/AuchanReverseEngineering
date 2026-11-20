package com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary;

/* JADX INFO: loaded from: classes.dex */
public class ConfigThresholdLocalOtsu extends ConfigThreshold {
    public double tuning = 0.0d;
    public boolean useOtsu2 = true;

    public ConfigThresholdLocalOtsu() {
        this.type = ThresholdType.BLOCK_OTSU;
    }
}
