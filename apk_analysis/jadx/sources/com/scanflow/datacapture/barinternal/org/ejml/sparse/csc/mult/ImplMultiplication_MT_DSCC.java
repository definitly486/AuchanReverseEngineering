package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ImplMultiplication_MT_DSCC {
    public static void mult(final DMatrixSparseCSC dMatrixSparseCSC, final DMatrixSparseCSC dMatrixSparseCSC2, DMatrixSparseCSC dMatrixSparseCSC3, GrowArray growArray) {
        ConcurrencyOps.loopBlocks(0, dMatrixSparseCSC2.numCols, growArray, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult.ImplMultiplication_MT_DSCC$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i, int i2) {
                ImplMultiplication_MT_DSCC.m910$r8$lambda$Xc9PSBNyxiepKsGHeJXRMEMlpY(dMatrixSparseCSC, dMatrixSparseCSC2, (Workspace_MT_DSCC) obj, i, i2);
            }
        });
        stitchMatrix(dMatrixSparseCSC3, dMatrixSparseCSC.numRows, dMatrixSparseCSC2.numCols, growArray);
    }

    /* JADX INFO: renamed from: $r8$lambda$Xc9PSBNyxiepKsGHeJXRME-MlpY, reason: not valid java name */
    public static /* synthetic */ void m910$r8$lambda$Xc9PSBNyxiepKsGHeJXRMEMlpY(DMatrixSparseCSC dMatrixSparseCSC, DMatrixSparseCSC dMatrixSparseCSC2, Workspace_MT_DSCC workspace_MT_DSCC, int i, int i2) {
        DMatrixSparseCSC dMatrixSparseCSC3 = workspace_MT_DSCC.mat;
        int i3 = i2 - i;
        dMatrixSparseCSC3.reshape(dMatrixSparseCSC.numRows, i3, i3);
        dMatrixSparseCSC3.col_idx[0] = 0;
        double[] dArrAdjust = UtilEjml.adjust(workspace_MT_DSCC.gx, dMatrixSparseCSC.numRows);
        IGrowArray iGrowArray = workspace_MT_DSCC.gw;
        int i4 = dMatrixSparseCSC.numRows;
        int[] iArrAdjust = UtilEjml.adjust(iGrowArray, i4, i4);
        int i5 = i;
        while (i5 < i2) {
            int i6 = i5 - i;
            int[] iArr = dMatrixSparseCSC2.col_idx;
            int i7 = iArr[i5];
            i5++;
            int i8 = iArr[i5];
            int i9 = i6 + 1;
            dMatrixSparseCSC3.col_idx[i9] = dMatrixSparseCSC3.nz_length;
            if (i7 != i8) {
                for (int i10 = i7; i10 < i8; i10++) {
                    ImplMultiplication_DSCC.multAddColA(dMatrixSparseCSC, dMatrixSparseCSC2.nz_rows[i10], dMatrixSparseCSC2.nz_values[i10], dMatrixSparseCSC3, i9, dArrAdjust, iArrAdjust);
                }
                int[] iArr2 = dMatrixSparseCSC3.col_idx;
                int i11 = iArr2[i9];
                for (int i12 = iArr2[i6]; i12 < i11; i12++) {
                    dMatrixSparseCSC3.nz_values[i12] = dArrAdjust[dMatrixSparseCSC3.nz_rows[i12]];
                }
            }
            dMatrixSparseCSC = dMatrixSparseCSC;
        }
    }

    public static void stitchMatrix(DMatrixSparseCSC dMatrixSparseCSC, int i, int i2, GrowArray growArray) {
        DMatrixSparseCSC dMatrixSparseCSC2;
        dMatrixSparseCSC.reshape(i, i2);
        dMatrixSparseCSC.indicesSorted = false;
        dMatrixSparseCSC.nz_length = 0;
        for (int i3 = 0; i3 < growArray.size(); i3++) {
            dMatrixSparseCSC.nz_length += ((Workspace_MT_DSCC) growArray.get(i3)).mat.nz_length;
        }
        dMatrixSparseCSC.growMaxLength(dMatrixSparseCSC.nz_length, false);
        dMatrixSparseCSC.nz_length = 0;
        dMatrixSparseCSC.numCols = 0;
        dMatrixSparseCSC.col_idx[0] = 0;
        for (int i4 = 0; i4 < growArray.size(); i4++) {
            Workspace_MT_DSCC workspace_MT_DSCC = (Workspace_MT_DSCC) growArray.get(i4);
            DMatrixSparseCSC dMatrixSparseCSC3 = workspace_MT_DSCC.mat;
            System.arraycopy(dMatrixSparseCSC3.nz_rows, 0, dMatrixSparseCSC.nz_rows, dMatrixSparseCSC.nz_length, dMatrixSparseCSC3.nz_length);
            DMatrixSparseCSC dMatrixSparseCSC4 = workspace_MT_DSCC.mat;
            System.arraycopy(dMatrixSparseCSC4.nz_values, 0, dMatrixSparseCSC.nz_values, dMatrixSparseCSC.nz_length, dMatrixSparseCSC4.nz_length);
            int i5 = 1;
            while (true) {
                dMatrixSparseCSC2 = workspace_MT_DSCC.mat;
                if (i5 <= dMatrixSparseCSC2.numCols) {
                    int[] iArr = dMatrixSparseCSC.col_idx;
                    int i6 = dMatrixSparseCSC.numCols + 1;
                    dMatrixSparseCSC.numCols = i6;
                    iArr[i6] = dMatrixSparseCSC.nz_length + dMatrixSparseCSC2.col_idx[i5];
                    i5++;
                }
            }
            dMatrixSparseCSC.nz_length += dMatrixSparseCSC2.nz_length;
        }
        UtilEjml.assertEq(dMatrixSparseCSC.numCols, i2);
        UtilEjml.assertEq(dMatrixSparseCSC.col_idx[i2], dMatrixSparseCSC.nz_length);
    }
}
