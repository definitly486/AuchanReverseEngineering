package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ImplMultiplication_MT_FSCC {
    public static void mult(final FMatrixSparseCSC fMatrixSparseCSC, final FMatrixSparseCSC fMatrixSparseCSC2, FMatrixSparseCSC fMatrixSparseCSC3, GrowArray growArray) {
        ConcurrencyOps.loopBlocks(0, fMatrixSparseCSC2.numCols, growArray, new IntRangeObjectConsumer() { // from class: com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult.ImplMultiplication_MT_FSCC$$ExternalSyntheticLambda0
            @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.IntRangeObjectConsumer
            public final void accept(Object obj, int i, int i2) {
                ImplMultiplication_MT_FSCC.$r8$lambda$7c66ZP4n2dqp4sSNt5qn_2M53ps(fMatrixSparseCSC, fMatrixSparseCSC2, (Workspace_MT_FSCC) obj, i, i2);
            }
        });
        stitchMatrix(fMatrixSparseCSC3, fMatrixSparseCSC.numRows, fMatrixSparseCSC2.numCols, growArray);
    }

    public static /* synthetic */ void $r8$lambda$7c66ZP4n2dqp4sSNt5qn_2M53ps(FMatrixSparseCSC fMatrixSparseCSC, FMatrixSparseCSC fMatrixSparseCSC2, Workspace_MT_FSCC workspace_MT_FSCC, int i, int i2) {
        FMatrixSparseCSC fMatrixSparseCSC3 = workspace_MT_FSCC.mat;
        int i3 = i2 - i;
        fMatrixSparseCSC3.reshape(fMatrixSparseCSC.numRows, i3, i3);
        fMatrixSparseCSC3.col_idx[0] = 0;
        float[] fArrAdjust = UtilEjml.adjust(workspace_MT_FSCC.gx, fMatrixSparseCSC.numRows);
        IGrowArray iGrowArray = workspace_MT_FSCC.gw;
        int i4 = fMatrixSparseCSC.numRows;
        int[] iArrAdjust = UtilEjml.adjust(iGrowArray, i4, i4);
        int i5 = i;
        while (i5 < i2) {
            int i6 = i5 - i;
            int[] iArr = fMatrixSparseCSC2.col_idx;
            int i7 = iArr[i5];
            i5++;
            int i8 = iArr[i5];
            int i9 = i6 + 1;
            fMatrixSparseCSC3.col_idx[i9] = fMatrixSparseCSC3.nz_length;
            if (i7 != i8) {
                for (int i10 = i7; i10 < i8; i10++) {
                    ImplMultiplication_FSCC.multAddColA(fMatrixSparseCSC, fMatrixSparseCSC2.nz_rows[i10], fMatrixSparseCSC2.nz_values[i10], fMatrixSparseCSC3, i9, fArrAdjust, iArrAdjust);
                }
                int[] iArr2 = fMatrixSparseCSC3.col_idx;
                int i11 = iArr2[i9];
                for (int i12 = iArr2[i6]; i12 < i11; i12++) {
                    fMatrixSparseCSC3.nz_values[i12] = fArrAdjust[fMatrixSparseCSC3.nz_rows[i12]];
                }
            }
            fMatrixSparseCSC = fMatrixSparseCSC;
        }
    }

    public static void stitchMatrix(FMatrixSparseCSC fMatrixSparseCSC, int i, int i2, GrowArray growArray) {
        FMatrixSparseCSC fMatrixSparseCSC2;
        fMatrixSparseCSC.reshape(i, i2);
        fMatrixSparseCSC.indicesSorted = false;
        fMatrixSparseCSC.nz_length = 0;
        for (int i3 = 0; i3 < growArray.size(); i3++) {
            fMatrixSparseCSC.nz_length += ((Workspace_MT_FSCC) growArray.get(i3)).mat.nz_length;
        }
        fMatrixSparseCSC.growMaxLength(fMatrixSparseCSC.nz_length, false);
        fMatrixSparseCSC.nz_length = 0;
        fMatrixSparseCSC.numCols = 0;
        fMatrixSparseCSC.col_idx[0] = 0;
        for (int i4 = 0; i4 < growArray.size(); i4++) {
            Workspace_MT_FSCC workspace_MT_FSCC = (Workspace_MT_FSCC) growArray.get(i4);
            FMatrixSparseCSC fMatrixSparseCSC3 = workspace_MT_FSCC.mat;
            System.arraycopy(fMatrixSparseCSC3.nz_rows, 0, fMatrixSparseCSC.nz_rows, fMatrixSparseCSC.nz_length, fMatrixSparseCSC3.nz_length);
            FMatrixSparseCSC fMatrixSparseCSC4 = workspace_MT_FSCC.mat;
            System.arraycopy(fMatrixSparseCSC4.nz_values, 0, fMatrixSparseCSC.nz_values, fMatrixSparseCSC.nz_length, fMatrixSparseCSC4.nz_length);
            int i5 = 1;
            while (true) {
                fMatrixSparseCSC2 = workspace_MT_FSCC.mat;
                if (i5 <= fMatrixSparseCSC2.numCols) {
                    int[] iArr = fMatrixSparseCSC.col_idx;
                    int i6 = fMatrixSparseCSC.numCols + 1;
                    fMatrixSparseCSC.numCols = i6;
                    iArr[i6] = fMatrixSparseCSC.nz_length + fMatrixSparseCSC2.col_idx[i5];
                    i5++;
                }
            }
            fMatrixSparseCSC.nz_length += fMatrixSparseCSC2.nz_length;
        }
        UtilEjml.assertEq(fMatrixSparseCSC.numCols, i2);
        UtilEjml.assertEq(fMatrixSparseCSC.col_idx[i2], fMatrixSparseCSC.nz_length);
    }
}
