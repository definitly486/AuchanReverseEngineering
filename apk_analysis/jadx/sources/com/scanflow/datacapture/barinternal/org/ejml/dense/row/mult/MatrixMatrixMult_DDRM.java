package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixMatrixMult_DDRM {
    public static void mult_reorder(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3) {
        UtilEjml.assertTrue((dMatrix1Row == dMatrix1Row3 || dMatrix1Row2 == dMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(dMatrix1Row.numCols, dMatrix1Row2.numRows, "The 'A' and 'B' matrices do not have compatible dimensions");
        dMatrix1Row3.reshape(dMatrix1Row.numRows, dMatrix1Row2.numCols);
        if (dMatrix1Row.numCols == 0 || dMatrix1Row.numRows == 0) {
            CommonOps_DDRM.fill(dMatrix1Row3, 0.0d);
            return;
        }
        int i = dMatrix1Row2.numRows * dMatrix1Row2.numCols;
        for (int i2 = 0; i2 < dMatrix1Row.numRows; i2++) {
            int i3 = dMatrix1Row3.numCols * i2;
            int i4 = dMatrix1Row.numCols * i2;
            int i5 = dMatrix1Row2.numCols;
            int i6 = i4 + 1;
            double d = dMatrix1Row.data[i4];
            int i7 = i3;
            int i8 = 0;
            while (i8 < i5) {
                dMatrix1Row3.set(i7, d * dMatrix1Row2.data[i8]);
                i7++;
                i8++;
                i = i;
            }
            while (i8 != i) {
                int i9 = dMatrix1Row2.numCols + i8;
                int i10 = i6 + 1;
                double d2 = dMatrix1Row.data[i6];
                int i11 = i3;
                while (i8 < i9) {
                    double[] dArr = dMatrix1Row3.data;
                    dArr[i11] = dArr[i11] + (dMatrix1Row2.data[i8] * d2);
                    i11++;
                    i8++;
                }
                i6 = i10;
            }
        }
    }

    public static void mult_small(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3) {
        UtilEjml.assertTrue((dMatrix1Row == dMatrix1Row3 || dMatrix1Row2 == dMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(dMatrix1Row.numCols, dMatrix1Row2.numRows, "The 'A' and 'B' matrices do not have compatible dimensions");
        dMatrix1Row3.reshape(dMatrix1Row.numRows, dMatrix1Row2.numCols);
        for (int i = 0; i < dMatrix1Row.numRows; i++) {
            int i2 = dMatrix1Row2.numCols * i;
            int i3 = dMatrix1Row.numCols * i;
            int i4 = 0;
            while (i4 < dMatrix1Row2.numCols) {
                int i5 = dMatrix1Row2.numRows + i3;
                double d = 0.0d;
                int i6 = i4;
                for (int i7 = i3; i7 < i5; i7++) {
                    d += dMatrix1Row.data[i7] * dMatrix1Row2.data[i6];
                    i6 += dMatrix1Row2.numCols;
                }
                dMatrix1Row3.set(i2, d);
                i4++;
                i2++;
            }
        }
    }

    public static void multTransB(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3) {
        UtilEjml.assertTrue((dMatrix1Row == dMatrix1Row3 || dMatrix1Row2 == dMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(dMatrix1Row.numCols, dMatrix1Row2.numCols, "The 'A' and 'B' matrices do not have compatible dimensions");
        dMatrix1Row3.reshape(dMatrix1Row.numRows, dMatrix1Row2.numRows);
        for (int i = 0; i < dMatrix1Row.numRows; i++) {
            int i2 = dMatrix1Row2.numRows * i;
            int i3 = dMatrix1Row2.numCols;
            int i4 = i * i3;
            int i5 = i3 + i4;
            int i6 = 0;
            int i7 = 0;
            while (i6 < dMatrix1Row2.numRows) {
                double d = 0.0d;
                int i8 = i4;
                while (i8 < i5) {
                    d += dMatrix1Row.data[i8] * dMatrix1Row2.data[i7];
                    i8++;
                    i7++;
                }
                dMatrix1Row3.set(i2, d);
                i6++;
                i2++;
            }
        }
    }
}
