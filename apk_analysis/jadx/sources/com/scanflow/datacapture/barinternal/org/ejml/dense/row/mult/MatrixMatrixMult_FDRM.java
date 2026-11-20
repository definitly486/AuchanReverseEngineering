package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_FDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixMatrixMult_FDRM {
    public static void mult_reorder(FMatrix1Row fMatrix1Row, FMatrix1Row fMatrix1Row2, FMatrix1Row fMatrix1Row3) {
        UtilEjml.assertTrue((fMatrix1Row == fMatrix1Row3 || fMatrix1Row2 == fMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(fMatrix1Row.numCols, fMatrix1Row2.numRows, "The 'A' and 'B' matrices do not have compatible dimensions");
        fMatrix1Row3.reshape(fMatrix1Row.numRows, fMatrix1Row2.numCols);
        if (fMatrix1Row.numCols == 0 || fMatrix1Row.numRows == 0) {
            CommonOps_FDRM.fill(fMatrix1Row3, 0.0f);
            return;
        }
        int i = fMatrix1Row2.numRows * fMatrix1Row2.numCols;
        for (int i2 = 0; i2 < fMatrix1Row.numRows; i2++) {
            int i3 = fMatrix1Row3.numCols * i2;
            int i4 = fMatrix1Row.numCols * i2;
            int i5 = fMatrix1Row2.numCols;
            int i6 = i4 + 1;
            float f = fMatrix1Row.data[i4];
            int i7 = 0;
            int i8 = i3;
            while (i7 < i5) {
                fMatrix1Row3.set(i8, fMatrix1Row2.data[i7] * f);
                i8++;
                i7++;
            }
            while (i7 != i) {
                int i9 = fMatrix1Row2.numCols + i7;
                int i10 = i6 + 1;
                float f2 = fMatrix1Row.data[i6];
                int i11 = i3;
                while (i7 < i9) {
                    float[] fArr = fMatrix1Row3.data;
                    fArr[i11] = fArr[i11] + (fMatrix1Row2.data[i7] * f2);
                    i11++;
                    i7++;
                }
                i6 = i10;
            }
        }
    }

    public static void mult_small(FMatrix1Row fMatrix1Row, FMatrix1Row fMatrix1Row2, FMatrix1Row fMatrix1Row3) {
        UtilEjml.assertTrue((fMatrix1Row == fMatrix1Row3 || fMatrix1Row2 == fMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(fMatrix1Row.numCols, fMatrix1Row2.numRows, "The 'A' and 'B' matrices do not have compatible dimensions");
        fMatrix1Row3.reshape(fMatrix1Row.numRows, fMatrix1Row2.numCols);
        for (int i = 0; i < fMatrix1Row.numRows; i++) {
            int i2 = fMatrix1Row2.numCols * i;
            int i3 = fMatrix1Row.numCols * i;
            int i4 = 0;
            while (i4 < fMatrix1Row2.numCols) {
                int i5 = fMatrix1Row2.numRows + i3;
                float f = 0.0f;
                int i6 = i4;
                for (int i7 = i3; i7 < i5; i7++) {
                    f += fMatrix1Row.data[i7] * fMatrix1Row2.data[i6];
                    i6 += fMatrix1Row2.numCols;
                }
                fMatrix1Row3.set(i2, f);
                i4++;
                i2++;
            }
        }
    }
}
