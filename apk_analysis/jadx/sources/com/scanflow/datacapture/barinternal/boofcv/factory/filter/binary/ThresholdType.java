package com.scanflow.datacapture.barinternal.boofcv.factory.filter.binary;

/* JADX INFO: loaded from: classes.dex */
public enum ThresholdType {
    FIXED(false, true),
    GLOBAL_ENTROPY(true, true),
    GLOBAL_OTSU(true, true),
    GLOBAL_LI(true, true),
    GLOBAL_HUANG(true, true),
    LOCAL_GAUSSIAN(true, false),
    LOCAL_MEAN(true, false),
    LOCAL_OTSU(true, false),
    BLOCK_MIN_MAX(true, false),
    BLOCK_MEAN(true, false),
    BLOCK_OTSU(true, false),
    LOCAL_NIBLACK(true, false),
    LOCAL_SAVOLA(true, false),
    LOCAL_WOLF(true, false),
    LOCAL_NICK(true, false);

    final boolean adaptive;
    final boolean global;

    ThresholdType(boolean z, boolean z2) {
        this.adaptive = z;
        this.global = z2;
    }

    public boolean isAdaptive() {
        return this.adaptive;
    }

    public boolean isGlobal() {
        return this.global;
    }
}
