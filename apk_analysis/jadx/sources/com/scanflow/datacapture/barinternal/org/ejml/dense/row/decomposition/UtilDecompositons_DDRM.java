package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilDecompositons_DDRM {
    public static DMatrixRMaj ensureIdentity(DMatrixRMaj dMatrixRMaj, int i, int i2) {
        if (dMatrixRMaj == null) {
            return CommonOps_DDRM.identity(i, i2);
        }
        dMatrixRMaj.reshape(i, i2);
        CommonOps_DDRM.setIdentity(dMatrixRMaj);
        return dMatrixRMaj;
    }

    public static DMatrixRMaj checkZerosLT(DMatrixRMaj dMatrixRMaj, int i, int i2) {
        if (dMatrixRMaj == null) {
            return new DMatrixRMaj(i, i2);
        }
        if (i != dMatrixRMaj.numRows || i2 != dMatrixRMaj.numCols) {
            dMatrixRMaj.reshape(i, i2);
            dMatrixRMaj.zero();
            return dMatrixRMaj;
        }
        for (int i3 = 0; i3 < dMatrixRMaj.numRows; i3++) {
            int i4 = dMatrixRMaj.numCols;
            int i5 = i3 * i4;
            int iMin = Math.min(i3, i4) + i5;
            while (i5 < iMin) {
                dMatrixRMaj.data[i5] = 0.0d;
                i5++;
            }
        }
        return dMatrixRMaj;
    }
}
