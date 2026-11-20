package com.scanflow.datacapture.barinternal.boofcv.misc;

import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_F32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;

/* JADX INFO: loaded from: classes.dex */
public abstract class BoofMiscOps {
    public static boolean isInside(int i, int i2, double d, double d2) {
        return d >= 0.0d && d < ((double) i) && d2 >= 0.0d && d2 < ((double) i2);
    }

    public static int[] checkDeclare(DogArray_I32 dogArray_I32, int i, boolean z) {
        if (dogArray_I32 == null) {
            dogArray_I32 = new DogArray_I32(i);
        }
        dogArray_I32.resize(i);
        if (z) {
            dogArray_I32.fill(0);
        }
        return dogArray_I32.data;
    }

    public static float[] checkDeclare(DogArray_F32 dogArray_F32, int i, boolean z) {
        if (dogArray_F32 == null) {
            dogArray_F32 = new DogArray_F32(i);
        }
        dogArray_F32.resize(i);
        if (z) {
            dogArray_F32.fill(0.0f);
        }
        return dogArray_F32.data;
    }

    public static GrowArray checkDeclare(GrowArray growArray, ConcurrencyOps.NewInstance newInstance) {
        if (growArray == null) {
            growArray = new GrowArray(newInstance);
        }
        growArray.reset();
        return growArray;
    }
}
