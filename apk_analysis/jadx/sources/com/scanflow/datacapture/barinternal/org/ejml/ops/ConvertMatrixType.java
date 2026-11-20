package com.scanflow.datacapture.barinternal.org.ejml.ops;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import org.ejml.data.CMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ConvertMatrixType {
    public static Matrix convert(Matrix matrix, MatrixType matrixType) {
        Matrix matrixCopy;
        CMatrixRMaj cMatrixRMaj;
        ZMatrixRMaj zMatrixRMaj;
        Matrix matrixCopy2;
        int[] iArr = AnonymousClass1.$SwitchMap$org$ejml$data$MatrixType;
        Matrix matrixCopy3 = null;
        matrixCopy3 = null;
        matrixCopy3 = null;
        matrixCopy3 = null;
        matrixCopy3 = null;
        matrixCopy3 = null;
        matrixCopy3 = null;
        switch (iArr[matrix.getType().ordinal()]) {
            case 1:
                switch (iArr[matrixType.ordinal()]) {
                    case 1:
                        matrixCopy3 = matrix.copy();
                        break;
                    case 2:
                        FMatrixRMaj fMatrixRMaj = new FMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixRMaj) matrix, fMatrixRMaj);
                        matrixCopy3 = fMatrixRMaj;
                        break;
                    case 3:
                        ZMatrixRMaj zMatrixRMaj2 = new ZMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixRMaj) matrix, zMatrixRMaj2);
                        matrixCopy3 = zMatrixRMaj2;
                        break;
                    case 4:
                        CMatrixRMaj cMatrixRMaj2 = new CMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixRMaj) matrix, cMatrixRMaj2);
                        matrixCopy3 = cMatrixRMaj2;
                        break;
                    case 5:
                        DMatrixSparseCSC dMatrixSparseCSC = new DMatrixSparseCSC(matrix.getNumRows(), matrix.getNumCols());
                        DConvertMatrixStruct.convert((DMatrixRMaj) matrix, dMatrixSparseCSC);
                        matrixCopy3 = dMatrixSparseCSC;
                        break;
                    case 6:
                        FMatrixSparseCSC fMatrixSparseCSC = new FMatrixSparseCSC(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixRMaj) matrix, fMatrixSparseCSC);
                        matrixCopy3 = fMatrixSparseCSC;
                        break;
                }
                break;
            case 2:
                switch (iArr[matrixType.ordinal()]) {
                    case 1:
                        DMatrixRMaj dMatrixRMaj = new DMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixRMaj) matrix, dMatrixRMaj);
                        matrixCopy3 = dMatrixRMaj;
                        break;
                    case 2:
                        matrixCopy3 = matrix.copy();
                        break;
                    case 3:
                        ZMatrixRMaj zMatrixRMaj3 = new ZMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixRMaj) matrix, zMatrixRMaj3);
                        matrixCopy3 = zMatrixRMaj3;
                        break;
                    case 4:
                        CMatrixRMaj cMatrixRMaj3 = new CMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixRMaj) matrix, cMatrixRMaj3);
                        matrixCopy3 = cMatrixRMaj3;
                        break;
                    case 5:
                        DMatrixSparseCSC dMatrixSparseCSC2 = new DMatrixSparseCSC(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixRMaj) matrix, dMatrixSparseCSC2);
                        matrixCopy3 = dMatrixSparseCSC2;
                        break;
                    case 6:
                        FMatrixSparseCSC fMatrixSparseCSC2 = new FMatrixSparseCSC(matrix.getNumRows(), matrix.getNumCols());
                        FConvertMatrixStruct.convert((FMatrixRMaj) matrix, fMatrixSparseCSC2);
                        matrixCopy3 = fMatrixSparseCSC2;
                        break;
                }
                break;
            case 3:
                int i = iArr[matrixType.ordinal()];
                if (i == 3) {
                    matrixCopy = matrix.copy();
                } else if (i == 4) {
                    cMatrixRMaj = new CMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                    ConvertMatrixData.convert((ZMatrixRMaj) matrix, cMatrixRMaj);
                }
                break;
            case 4:
                int i2 = iArr[matrixType.ordinal()];
                if (i2 == 3) {
                    zMatrixRMaj = new ZMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                    ConvertMatrixData.convert((CMatrixRMaj) matrix, zMatrixRMaj);
                } else if (i2 == 4) {
                    matrixCopy2 = matrix.copy();
                }
                break;
            case 5:
                switch (iArr[matrixType.ordinal()]) {
                    case 1:
                        DMatrixRMaj dMatrixRMaj2 = new DMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        DConvertMatrixStruct.convert((DMatrixSparseCSC) matrix, dMatrixRMaj2);
                        matrixCopy3 = dMatrixRMaj2;
                        break;
                    case 2:
                        FMatrixRMaj fMatrixRMaj2 = new FMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixSparseCSC) matrix, fMatrixRMaj2);
                        matrixCopy3 = fMatrixRMaj2;
                        break;
                    case 3:
                        ZMatrixRMaj zMatrixRMaj4 = new ZMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixSparseCSC) matrix, zMatrixRMaj4);
                        matrixCopy3 = zMatrixRMaj4;
                        break;
                    case 4:
                        CMatrixRMaj cMatrixRMaj4 = new CMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixSparseCSC) matrix, cMatrixRMaj4);
                        matrixCopy3 = cMatrixRMaj4;
                        break;
                    case 5:
                        matrixCopy3 = matrix.copy();
                        break;
                    case 6:
                        FMatrixSparseCSC fMatrixSparseCSC3 = new FMatrixSparseCSC(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((DMatrixSparseCSC) matrix, fMatrixSparseCSC3);
                        matrixCopy3 = fMatrixSparseCSC3;
                        break;
                }
                break;
            case 6:
                switch (iArr[matrixType.ordinal()]) {
                    case 1:
                        DMatrixRMaj dMatrixRMaj3 = new DMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixSparseCSC) matrix, dMatrixRMaj3);
                        matrixCopy3 = dMatrixRMaj3;
                        break;
                    case 2:
                        FMatrixRMaj fMatrixRMaj3 = new FMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        FConvertMatrixStruct.convert((FMatrixSparseCSC) matrix, fMatrixRMaj3);
                        matrixCopy3 = fMatrixRMaj3;
                        break;
                    case 3:
                        ZMatrixRMaj zMatrixRMaj5 = new ZMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixSparseCSC) matrix, zMatrixRMaj5);
                        matrixCopy3 = zMatrixRMaj5;
                        break;
                    case 4:
                        CMatrixRMaj cMatrixRMaj5 = new CMatrixRMaj(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixSparseCSC) matrix, cMatrixRMaj5);
                        matrixCopy3 = cMatrixRMaj5;
                        break;
                    case 5:
                        DMatrixSparseCSC dMatrixSparseCSC3 = new DMatrixSparseCSC(matrix.getNumRows(), matrix.getNumCols());
                        ConvertMatrixData.convert((FMatrixSparseCSC) matrix, dMatrixSparseCSC3);
                        matrixCopy3 = dMatrixSparseCSC3;
                        break;
                    case 6:
                        matrixCopy3 = matrix.copy();
                        break;
                }
                break;
        }
        if (matrixCopy3 != null) {
            matrixCopy3 = matrixCopy;
            matrixCopy3 = cMatrixRMaj;
            matrixCopy3 = zMatrixRMaj;
            matrixCopy3 = matrixCopy2;
            return matrixCopy3;
        }
        matrixCopy3 = matrixCopy;
        matrixCopy3 = cMatrixRMaj;
        matrixCopy3 = zMatrixRMaj;
        matrixCopy3 = matrixCopy2;
        throw new IllegalArgumentException("Unknown " + matrix.getType() + " " + matrixType);
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.org.ejml.ops.ConvertMatrixType$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$org$ejml$data$MatrixType;

        static {
            int[] iArr = new int[MatrixType.values().length];
            $SwitchMap$org$ejml$data$MatrixType = iArr;
            try {
                iArr[MatrixType.DDRM.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FDRM.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.ZDRM.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.CDRM.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.DSCC.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FSCC.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
        }
    }
}
