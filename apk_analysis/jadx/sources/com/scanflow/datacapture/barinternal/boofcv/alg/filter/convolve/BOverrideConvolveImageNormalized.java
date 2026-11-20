package com.scanflow.datacapture.barinternal.boofcv.alg.filter.convolve;

import com.scanflow.datacapture.barinternal.boofcv.override.BOverrideClass;
import com.scanflow.datacapture.barinternal.boofcv.override.BOverrideManager;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.ImageBase;

/* JADX INFO: loaded from: classes.dex */
public abstract class BOverrideConvolveImageNormalized extends BOverrideClass {
    static {
        BOverrideManager.register(BOverrideConvolveImageNormalized.class);
    }

    public static boolean invokeNativeHorizontal(Kernel1D kernel1D, ImageBase imageBase, ImageBase imageBase2) {
        return false;
    }

    public static boolean invokeNativeVertical(Kernel1D kernel1D, ImageBase imageBase, ImageBase imageBase2) {
        return false;
    }
}
