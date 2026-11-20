package com.scanflow.datacapture.barinternal.org.ejml.simple;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType;
import com.scanflow.datacapture.barinternal.org.ejml.ops.ConvertMatrixType;
import com.scanflow.datacapture.barinternal.org.ejml.ops.MatrixIO;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_CDRM;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_DSCC;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_FDRM;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_FSCC;
import com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_ZDRM;
import java.io.ByteArrayOutputStream;
import java.io.PrintStream;
import java.io.Serializable;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.nio.charset.StandardCharsets;

/* JADX INFO: loaded from: classes3.dex */
public abstract class SimpleBase implements ConstMatrix, Serializable {
    protected transient AutomaticSimpleMatrixConvert convertType = new AutomaticSimpleMatrixConvert();
    protected Matrix mat;
    protected SimpleOperations ops;

    protected abstract SimpleBase createMatrix(int i, int i2, MatrixType matrixType);

    protected abstract SimpleBase wrapMatrix(Matrix matrix);

    protected SimpleBase() {
    }

    public Matrix getMatrix() {
        return this.mat;
    }

    public DMatrixRMaj getDDRM() {
        MatrixType type = this.mat.getType();
        MatrixType matrixType = MatrixType.DDRM;
        return (DMatrixRMaj) (type == matrixType ? this.mat : ConvertMatrixType.convert(this.mat, matrixType));
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleBase$1, reason: invalid class name */
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

    protected static SimpleOperations lookupOps(MatrixType matrixType) {
        switch (AnonymousClass1.$SwitchMap$org$ejml$data$MatrixType[matrixType.ordinal()]) {
            case 1:
                return new SimpleOperations_DDRM();
            case 2:
                return new SimpleOperations_FDRM();
            case 3:
                return new SimpleOperations_ZDRM();
            case 4:
                return new SimpleOperations_CDRM();
            case 5:
                return new SimpleOperations_DSCC();
            case 6:
                return new SimpleOperations_FSCC();
            default:
                throw new RuntimeException("Unknown Matrix Type. " + matrixType);
        }
    }

    public SimpleBase mult(ConstMatrix constMatrix) {
        Method methodFindAlternative;
        SimpleBase simpleBase = (SimpleBase) constMatrix;
        this.convertType.specify(this, simpleBase);
        if (this.mat.getType() != simpleBase.getType() && (methodFindAlternative = findAlternative("mult", this.mat, simpleBase.mat, this.convertType.commonType.getClassType())) != null) {
            SimpleBase simpleBaseWrapMatrix = wrapMatrix(this.convertType.commonType.create(1, 1));
            invoke(methodFindAlternative, this.mat, simpleBase.mat, simpleBaseWrapMatrix.mat);
            return simpleBaseWrapMatrix;
        }
        SimpleBase simpleBaseConvert = this.convertType.convert(this);
        SimpleBase simpleBaseConvert2 = this.convertType.convert(simpleBase);
        SimpleBase simpleBaseCreateMatrix = simpleBaseConvert.createMatrix(this.mat.getNumRows(), simpleBaseConvert2.getMatrix().getNumCols(), simpleBaseConvert.getType());
        simpleBaseConvert.ops.mult(simpleBaseConvert.mat, simpleBaseConvert2.mat, simpleBaseCreateMatrix.mat);
        return simpleBaseCreateMatrix;
    }

    public String toString() {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        MatrixIO.print(new PrintStream(byteArrayOutputStream), this.mat);
        return byteArrayOutputStream.toString(StandardCharsets.UTF_8);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.ConstMatrix
    public MatrixType getType() {
        return this.mat.getType();
    }

    protected void setMatrix(Matrix matrix) {
        this.mat = matrix;
        this.ops = lookupOps(matrix.getType());
    }

    Method findAlternative(String str, Object... objArr) {
        Method[] methods = this.ops.getClass().getMethods();
        for (int i = 0; i < methods.length; i++) {
            if (methods[i].getName().equals(str)) {
                Class<?>[] parameterTypes = methods[i].getParameterTypes();
                if (parameterTypes.length == objArr.length) {
                    for (int i2 = 0; i2 < parameterTypes.length; i2++) {
                        Class<?> cls = objArr[i2];
                        if (cls instanceof Class) {
                            if (parameterTypes[i2] == cls) {
                            }
                        } else if (parameterTypes[i2] == cls.getClass()) {
                        }
                    }
                    return methods[i];
                }
                continue;
            }
        }
        return null;
    }

    public void invoke(Method method, Object... objArr) {
        try {
            method.invoke(this.ops, objArr);
        } catch (IllegalAccessException | InvocationTargetException e) {
            throw new RuntimeException(e);
        }
    }
}
