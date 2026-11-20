package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public abstract class SingularOps_DDRM {
    public static void descendingOrder(DMatrixRMaj dMatrixRMaj, boolean z, double[] dArr, int i, DMatrixRMaj dMatrixRMaj2, boolean z2) {
        for (int i2 = 0; i2 < i; i2++) {
            double d = -1.0d;
            int i3 = -1;
            for (int i4 = i2; i4 < i; i4++) {
                double d2 = dArr[i4];
                if (d2 > d) {
                    i3 = i4;
                    d = d2;
                }
            }
            if (i3 != i2) {
                if (i3 == -1) {
                    return;
                }
                double d3 = dArr[i2];
                dArr[i2] = d;
                dArr[i3] = d3;
                if (dMatrixRMaj2 != null) {
                    swapRowOrCol(dMatrixRMaj2, z2, i2, i3);
                }
                if (dMatrixRMaj != null) {
                    swapRowOrCol(dMatrixRMaj, z, i2, i3);
                }
            }
        }
    }

    private static void swapRowOrCol(DMatrixRMaj dMatrixRMaj, boolean z, int i, int i2) {
        int i3 = 0;
        if (z) {
            while (i3 < dMatrixRMaj.numCols) {
                double d = dMatrixRMaj.get(i, i3);
                dMatrixRMaj.set(i, i3, dMatrixRMaj.get(i2, i3));
                dMatrixRMaj.set(i2, i3, d);
                i3++;
            }
            return;
        }
        while (i3 < dMatrixRMaj.numRows) {
            double d2 = dMatrixRMaj.get(i3, i);
            dMatrixRMaj.set(i3, i, dMatrixRMaj.get(i3, i2));
            dMatrixRMaj.set(i3, i2, d2);
            i3++;
        }
    }
}
