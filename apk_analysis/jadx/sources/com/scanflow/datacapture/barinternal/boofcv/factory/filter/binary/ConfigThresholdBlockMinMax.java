package com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;

/* JADX INFO: loaded from: classes.dex */
public class ConfigThresholdBlockMinMax extends ConfigThreshold {
    public double minimumSpread;

    public ConfigThresholdBlockMinMax(ConfigLength configLength, double d, boolean z) {
        this.minimumSpread = 10.0d;
        this.scale = 0.85d;
        this.type = ThresholdType.BLOCK_MIN_MAX;
        this.width = configLength;
        this.minimumSpread = d;
        this.down = z;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary.ConfigThreshold
    public void checkValidity() {
        super.checkValidity();
    }
}
