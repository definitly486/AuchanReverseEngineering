package com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary;

import com.scanflow.datacapture.barinternal.boofcv.struct.ConfigLength;
import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ConfigThreshold implements Serializable {
    public double fixedThreshold;
    public ThresholdType type;
    public double scale = 1.0d;
    public boolean down = true;
    public ConfigLength width = ConfigLength.fixed(11.0d);
    public float niblackK = 0.3f;
    public float nickK = -0.2f;
    public int minPixelValue = 0;
    public int maxPixelValue = 255;
    public boolean thresholdFromLocalBlocks = true;

    public static ConfigThreshold local(ThresholdType thresholdType, int i) {
        return local(thresholdType, ConfigLength.fixed(i));
    }

    public static ConfigThreshold local(ThresholdType thresholdType, ConfigLength configLength) {
        ConfigThreshold configThreshold;
        if (!thresholdType.isAdaptive()) {
            throw new IllegalArgumentException("Type must be adaptive");
        }
        if (thresholdType.isGlobal()) {
            throw new IllegalArgumentException("Type must be local");
        }
        if (thresholdType == ThresholdType.BLOCK_MIN_MAX) {
            configThreshold = new ConfigThresholdBlockMinMax(configLength, 10.0d, true);
        } else if (thresholdType == ThresholdType.BLOCK_OTSU) {
            configThreshold = new ConfigThresholdLocalOtsu();
        } else {
            configThreshold = new ConfigThreshold();
        }
        configThreshold.scale = 0.95d;
        configThreshold.type = thresholdType;
        configThreshold.width = configLength;
        return configThreshold;
    }

    public void checkValidity() {
    }

    public String toString() {
        return "ConfigThreshold{type=" + this.type + ", fixedThreshold=" + this.fixedThreshold + ", scale=" + this.scale + ", down=" + this.down + ", width=" + this.width + ", savolaK=" + this.niblackK + ", minPixelValue=" + this.minPixelValue + ", maxPixelValue=" + this.maxPixelValue + "}";
    }
}
