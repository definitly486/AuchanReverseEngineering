package com.scanflow.datacapture.barinternal.org.ejml.dense.row;

import com.scanflow.datacapture.barinternal.org.ejml.EjmlParameters;
import com.scanflow.datacapture.barinternal.org.ejml.MatrixDimensionException;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix1Row;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixD1;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.misc.ImplCommonOps_DDMA;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.misc.ImplCommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.misc.TransposeAlgs_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixMatrixMult_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.mult.MatrixVectorMult_DDRM;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public abstract class CommonOps_DDRM {
    public static DMatrix1Row mult(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3) {
        DMatrix1Row dMatrix1Row4 = (DMatrix1Row) UtilEjml.reshapeOrDeclare(dMatrix1Row3, dMatrix1Row, dMatrix1Row.numRows, dMatrix1Row2.numCols);
        UtilEjml.checkSameInstance(dMatrix1Row, dMatrix1Row4);
        UtilEjml.checkSameInstance(dMatrix1Row2, dMatrix1Row4);
        int i = dMatrix1Row2.numCols;
        if (i == 1) {
            MatrixVectorMult_DDRM.mult(dMatrix1Row, dMatrix1Row2, dMatrix1Row4);
            return dMatrix1Row4;
        }
        if (i >= EjmlParameters.MULT_COLUMN_SWITCH) {
            MatrixMatrixMult_DDRM.mult_reorder(dMatrix1Row, dMatrix1Row2, dMatrix1Row4);
            return dMatrix1Row4;
        }
        MatrixMatrixMult_DDRM.mult_small(dMatrix1Row, dMatrix1Row2, dMatrix1Row4);
        return dMatrix1Row4;
    }

    public static DMatrix1Row multTransB(DMatrix1Row dMatrix1Row, DMatrix1Row dMatrix1Row2, DMatrix1Row dMatrix1Row3) {
        DMatrix1Row dMatrix1Row4 = (DMatrix1Row) UtilEjml.reshapeOrDeclare(dMatrix1Row3, dMatrix1Row, dMatrix1Row.numRows, dMatrix1Row2.numRows);
        UtilEjml.checkSameInstance(dMatrix1Row, dMatrix1Row4);
        UtilEjml.checkSameInstance(dMatrix1Row2, dMatrix1Row4);
        if (dMatrix1Row2.numRows == 1) {
            MatrixVectorMult_DDRM.mult(dMatrix1Row, dMatrix1Row2, dMatrix1Row4);
            return dMatrix1Row4;
        }
        MatrixMatrixMult_DDRM.multTransB(dMatrix1Row, dMatrix1Row2, dMatrix1Row4);
        return dMatrix1Row4;
    }

    public static void transpose(DMatrixRMaj dMatrixRMaj) {
        int i = dMatrixRMaj.numCols;
        int i2 = dMatrixRMaj.numRows;
        if (i == i2) {
            TransposeAlgs_DDRM.square(dMatrixRMaj);
            return;
        }
        DMatrixRMaj dMatrixRMaj2 = new DMatrixRMaj(i, i2);
        transpose(dMatrixRMaj, dMatrixRMaj2);
        dMatrixRMaj.setTo(dMatrixRMaj2);
    }

    public static DMatrixRMaj transpose(DMatrixRMaj dMatrixRMaj, DMatrixRMaj dMatrixRMaj2) {
        DMatrixRMaj dMatrixRMajReshapeOrDeclare = UtilEjml.reshapeOrDeclare(dMatrixRMaj2, dMatrixRMaj.numCols, dMatrixRMaj.numRows);
        int i = dMatrixRMaj.numRows;
        int i2 = EjmlParameters.TRANSPOSE_SWITCH;
        if (i > i2 && dMatrixRMaj.numCols > i2) {
            TransposeAlgs_DDRM.block(dMatrixRMaj, dMatrixRMajReshapeOrDeclare, EjmlParameters.BLOCK_WIDTH);
            return dMatrixRMajReshapeOrDeclare;
        }
        TransposeAlgs_DDRM.standard(dMatrixRMaj, dMatrixRMajReshapeOrDeclare);
        return dMatrixRMajReshapeOrDeclare;
    }

    public static void setIdentity(DMatrix1Row dMatrix1Row) {
        int i = dMatrix1Row.numRows;
        int i2 = dMatrix1Row.numCols;
        if (i >= i2) {
            i = i2;
        }
        int i3 = 0;
        Arrays.fill(dMatrix1Row.data, 0, dMatrix1Row.getNumElements(), 0.0d);
        int i4 = 0;
        while (i3 < i) {
            dMatrix1Row.data[i4] = 1.0d;
            i3++;
            i4 += dMatrix1Row.numCols + 1;
        }
    }

    public static DMatrixRMaj identity(int i, int i2) {
        DMatrixRMaj dMatrixRMaj = new DMatrixRMaj(i, i2);
        if (i >= i2) {
            i = i2;
        }
        for (int i3 = 0; i3 < i; i3++) {
            dMatrixRMaj.set(i3, i3, 1.0d);
        }
        return dMatrixRMaj;
    }

    public static void extract(DMatrix dMatrix, int i, int i2, int i3, int i4, DMatrix dMatrix2, int i5, int i6) {
        if (i2 < i || i < 0 || i2 > dMatrix.getNumRows()) {
            throw new MatrixDimensionException("srcY1 < srcY0 || srcY0 < 0 || srcY1 > src.numRows. " + UtilEjml.stringShapes(dMatrix, dMatrix2));
        }
        if (i4 < i3 || i3 < 0 || i4 > dMatrix.getNumCols()) {
            throw new MatrixDimensionException("srcX1 < srcX0 || srcX0 < 0 || srcX1 > src.numCols. " + UtilEjml.stringShapes(dMatrix, dMatrix2));
        }
        int i7 = i4 - i3;
        int i8 = i2 - i;
        int i9 = i5 + i8;
        if (i9 > dMatrix2.getNumRows()) {
            throw new MatrixDimensionException("dst is too small in rows. " + dMatrix2.getNumRows() + " < " + i9);
        }
        int i10 = i6 + i7;
        if (i10 > dMatrix2.getNumCols()) {
            throw new MatrixDimensionException("dst is too small in columns. " + dMatrix2.getNumCols() + " < " + i10);
        }
        if ((dMatrix instanceof DMatrixRMaj) && (dMatrix2 instanceof DMatrixRMaj)) {
            ImplCommonOps_DDRM.extract((DMatrixRMaj) dMatrix, i, i3, (DMatrixRMaj) dMatrix2, i5, i6, i8, i7);
        } else {
            ImplCommonOps_DDMA.extract(dMatrix, i, i3, dMatrix2, i5, i6, i8, i7);
        }
    }

    public static DMatrixRMaj extract(DMatrixRMaj dMatrixRMaj, int i, int i2, int i3, int i4) {
        if (i2 <= i || i < 0 || i2 > dMatrixRMaj.numRows) {
            throw new MatrixDimensionException("srcY1 <= srcY0 || srcY0 < 0 || srcY1 > src.numRows");
        }
        if (i4 <= i3 || i3 < 0 || i4 > dMatrixRMaj.numCols) {
            throw new MatrixDimensionException("srcX1 <= srcX0 || srcX0 < 0 || srcX1 > src.numCols");
        }
        int i5 = i4 - i3;
        int i6 = i2 - i;
        DMatrixRMaj dMatrixRMaj2 = new DMatrixRMaj(i6, i5);
        ImplCommonOps_DDRM.extract(dMatrixRMaj, i, i3, dMatrixRMaj2, 0, 0, i6, i5);
        return dMatrixRMaj2;
    }

    public static void insert(DMatrix dMatrix, DMatrix dMatrix2, int i, int i2) {
        extract(dMatrix, 0, dMatrix.getNumRows(), 0, dMatrix.getNumCols(), dMatrix2, i, i2);
    }

    public static double elementMaxAbs(DMatrixD1 dMatrixD1) {
        return ImplCommonOps_DDRM.elementMaxAbs(dMatrixD1, null);
    }

    public static void scale(double d, DMatrixD1 dMatrixD1) {
        int numElements = dMatrixD1.getNumElements();
        for (int i = 0; i < numElements; i++) {
            double[] dArr = dMatrixD1.data;
            dArr[i] = dArr[i] * d;
        }
    }

    public static void divide(DMatrixD1 dMatrixD1, double d) {
        int numElements = dMatrixD1.getNumElements();
        for (int i = 0; i < numElements; i++) {
            double[] dArr = dMatrixD1.data;
            dArr[i] = dArr[i] / d;
        }
    }

    public static void fill(DMatrixD1 dMatrixD1, double d) {
        Arrays.fill(dMatrixD1.data, 0, dMatrixD1.getNumElements(), d);
    }
}
