package com.scanflow.datacapture.barinternal.boofcv.factory.filter.kernel;

import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_F32;
import com.scanflow.datacapture.barinternal.boofcv.struct.convolve.Kernel1D_S32;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryKernel {
    public static Kernel1D_S32 table1D_S32(int i, int i2) {
        Kernel1D_S32 kernel1D_S32 = new Kernel1D_S32(i2, i);
        for (int i3 = 0; i3 < i2; i3++) {
            kernel1D_S32.data[i3] = 1;
        }
        return kernel1D_S32;
    }

    public static Kernel1D_F32 table1D_F32(int i, int i2, boolean z) {
        Kernel1D_F32 kernel1D_F32 = new Kernel1D_F32(i2, i);
        float f = z ? 1.0f / kernel1D_F32.width : 1.0f;
        for (int i3 = 0; i3 < i2; i3++) {
            kernel1D_F32.data[i3] = f;
        }
        return kernel1D_F32;
    }
}
