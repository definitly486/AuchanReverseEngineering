package com.scanflow.datacapture.barinternal.org.ejml.simple;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import org.ejml.data.CMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleMatrix extends SimpleBase {

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleMatrix$1, reason: invalid class name */
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

    public SimpleMatrix(int i, int i2, MatrixType matrixType) {
        switch (AnonymousClass1.$SwitchMap$org$ejml$data$MatrixType[matrixType.ordinal()]) {
            case 1:
                setMatrix(new DMatrixRMaj(i, i2));
                return;
            case 2:
                setMatrix(new FMatrixRMaj(i, i2));
                return;
            case 3:
                setMatrix(new ZMatrixRMaj(i, i2));
                return;
            case 4:
                setMatrix(new CMatrixRMaj(i, i2));
                return;
            case 5:
                setMatrix(new DMatrixSparseCSC(i, i2));
                return;
            case 6:
                setMatrix(new FMatrixSparseCSC(i, i2));
                return;
            default:
                throw new RuntimeException("Unknown matrix type");
        }
    }

    public SimpleMatrix(Matrix matrix) {
        setMatrix(matrix.copy());
    }

    protected SimpleMatrix() {
    }

    public static SimpleMatrix wrap(Matrix matrix) {
        SimpleMatrix simpleMatrix = new SimpleMatrix();
        simpleMatrix.setMatrix(matrix);
        return simpleMatrix;
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleBase
    public SimpleMatrix createMatrix(int i, int i2, MatrixType matrixType) {
        return new SimpleMatrix(i, i2, matrixType);
    }

    /* JADX INFO: Access modifiers changed from: protected */
    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleBase
    public SimpleMatrix wrapMatrix(Matrix matrix) {
        return new SimpleMatrix(matrix);
    }
}
