package com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_FDRM;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import java.util.function.IntConsumer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class MatrixMatrixMult_MT_FDRM {
    public static void mult_reorder(final FMatrix1Row fMatrix1Row, final FMatrix1Row fMatrix1Row2, final FMatrix1Row fMatrix1Row3) {
        int i;
        UtilEjml.assertTrue((fMatrix1Row == fMatrix1Row3 || fMatrix1Row2 == fMatrix1Row3) ? false : true, "Neither 'A' or 'B' can be the same matrix as 'C'");
        UtilEjml.assertShape(fMatrix1Row.numCols, fMatrix1Row2.numRows, "The 'A' and 'B' matrices do not have compatible dimensions");
        fMatrix1Row3.reshape(fMatrix1Row.numRows, fMatrix1Row2.numCols);
        if (fMatrix1Row.numCols == 0 || (i = fMatrix1Row.numRows) == 0) {
            CommonOps_FDRM.fill(fMatrix1Row3, 0.0f);
        } else {
            final int i2 = fMatrix1Row2.numRows * fMatrix1Row2.numCols;
            ConcurrencyOps.loopFor(0, i, new IntConsumer() { // from class: com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_MT_FDRM$$ExternalSyntheticLambda0
                @Override // java.util.function.IntConsumer
                public final void accept(int i3) {
                    MatrixMatrixMult_MT_FDRM.m909$r8$lambda$rwB1Fa91jozVpSQroAAVLQaMHw(fMatrix1Row3, fMatrix1Row, fMatrix1Row2, i2, i3);
                }
            });
        }
    }

    /* JADX INFO: renamed from: $r8$lambda$rwB1Fa91jozVpSQroAA-VLQaMHw, reason: not valid java name */
    public static /* synthetic */ void m909$r8$lambda$rwB1Fa91jozVpSQroAAVLQaMHw(FMatrix1Row fMatrix1Row, FMatrix1Row fMatrix1Row2, FMatrix1Row fMatrix1Row3, int i, int i2) {
        int i3 = fMatrix1Row.numCols * i2;
        int i4 = i2 * fMatrix1Row2.numCols;
        int i5 = fMatrix1Row3.numCols;
        int i6 = i4 + 1;
        float f = fMatrix1Row2.data[i4];
        int i7 = 0;
        int i8 = i3;
        while (i7 < i5) {
            fMatrix1Row.set(i8, fMatrix1Row3.data[i7] * f);
            i8++;
            i7++;
        }
        while (i7 != i) {
            int i9 = fMatrix1Row3.numCols + i7;
            int i10 = i6 + 1;
            float f2 = fMatrix1Row2.data[i6];
            int i11 = i3;
            while (i7 < i9) {
                float[] fArr = fMatrix1Row.data;
                fArr[i11] = fArr[i11] + (fMatrix1Row3.data[i7] * f2);
                i11++;
                i7++;
            }
            i6 = i10;
        }
    }
}
