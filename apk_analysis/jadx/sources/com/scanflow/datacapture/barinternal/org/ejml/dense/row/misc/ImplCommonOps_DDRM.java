package com.scanflow.datacapture.barinternal.org.ejml.dense.row.misc;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.ElementLocation;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ImplCommonOps_DDRM {
    public static void extract(DMatrixRMaj dMatrixRMaj, int i, int i2, DMatrixRMaj dMatrixRMaj2, int i3, int i4, int i5, int i6) {
        for (int i7 = 0; i7 < i5; i7++) {
            System.arraycopy(dMatrixRMaj.data, dMatrixRMaj.getIndex(i7 + i, i2), dMatrixRMaj2.data, dMatrixRMaj2.getIndex(i7 + i3, i4), i6);
        }
    }

    public static double elementMaxAbs(DMatrixD1 dMatrixD1, ElementLocation elementLocation) {
        int numElements = dMatrixD1.getNumElements();
        double d = 0.0d;
        for (int i = 0; i < numElements; i++) {
            double dAbs = Math.abs(dMatrixD1.get(i));
            if (dAbs > d) {
                d = dAbs;
            }
        }
        return d;
    }
}
