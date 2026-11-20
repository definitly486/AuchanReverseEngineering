package com.scanflow.datacapture.barinternal.androidx.camera.video.internal.encoder;

import android.util.Range;

/* JADX INFO: loaded from: classes.dex */
public interface VideoEncoderInfo extends EncoderInfo {
    boolean canSwapWidthHeight();

    int getHeightAlignment();

    Range getSupportedBitrateRange();

    Range getSupportedHeights();

    Range getSupportedHeightsFor(int i);

    Range getSupportedWidths();

    Range getSupportedWidthsFor(int i);

    int getWidthAlignment();

    boolean isSizeSupported(int i, int i2);

    default boolean isSizeSupportedAllowSwapping(int i, int i2) {
        if (isSizeSupported(i, i2)) {
            return true;
        }
        return canSwapWidthHeight() && isSizeSupported(i2, i);
    }
}
