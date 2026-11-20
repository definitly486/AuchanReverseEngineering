package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve;

import com.scanflow.datacapture.barinternal.boofcv.override.BOverrideClass;
import com.scanflow.datacapture.barinternal.boofcv.override.BOverrideManager;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public abstract class BOverrideConvolveImageMean extends BOverrideClass {
    static {
        BOverrideManager.register(BOverrideConvolveImageMean.class);
    }

    public static boolean invokeNativeHorizontal(ImageBase imageBase, ImageBase imageBase2, int i, int i2) {
        return false;
    }

    public static boolean invokeNativeVertical(ImageBase imageBase, ImageBase imageBase2, int i, int i2) {
        return false;
    }
}
