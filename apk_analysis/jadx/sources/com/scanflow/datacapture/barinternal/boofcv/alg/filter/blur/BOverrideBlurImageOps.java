package com.scanflow.datacapture.barinternal.boofcv.alg.filter.blur;

import com.scanflow.datacapture.barinternal.boofcv.override.BOverrideClass;
import com.scanflow.datacapture.barinternal.boofcv.override.BOverrideManager;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public abstract class BOverrideBlurImageOps extends BOverrideClass {
    static {
        BOverrideManager.register(BOverrideBlurImageOps.class);
    }

    public static boolean invokeNativeMeanWeighted(ImageBase imageBase, ImageBase imageBase2, int i, int i2, ImageBase imageBase3) {
        return false;
    }

    public static boolean invokeNativeGaussian(ImageBase imageBase, ImageBase imageBase2, double d, int i, double d2, int i2, ImageBase imageBase3) {
        return false;
    }
}
