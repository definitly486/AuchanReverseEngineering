package com.scanflow.datacapture.barinternal.org.ejml;

import com.scanflow.datacapture.barinternal.org.ejml.data.DGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.data.FGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.ReshapeMatrix;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import java.text.DecimalFormat;
import java.util.Arrays;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilEjml {
    public static double EPS = Math.pow(2.0d, -52.0d);
    public static float F_EPS = (float) Math.pow(2.0d, -21.0d);
    public static double PI = 3.141592653589793d;
    public static double PI2 = 6.283185307179586d;
    public static double PId2 = 1.5707963267948966d;
    public static float F_PI = 3.1415927f;
    public static float F_PI2 = 6.2831855f;
    public static float F_PId2 = 1.5707964f;
    public static float TEST_F32 = 5.0E-4f;
    public static double TEST_F64 = 1.0E-8d;
    public static float TESTP_F32 = 1.0E-6f;
    public static double TESTP_F64 = 1.0E-12d;
    public static float TEST_F32_SQ = (float) Math.sqrt(5.0E-4f);
    public static double TEST_F64_SQ = Math.sqrt(TEST_F64);
    public static int maxInverseSize = 5;
    public static final int[] ZERO_LENGTH_I32 = new int[0];
    public static final float[] ZERO_LENGTH_F32 = new float[0];
    public static final double[] ZERO_LENGTH_F64 = new double[0];

    public static void checkSameInstance(Object obj, Object obj2) {
        if (obj == obj2) {
            throw new IllegalArgumentException("Can't pass in the same instance");
        }
    }

    public static DMatrixRMaj reshapeOrDeclare(DMatrixRMaj dMatrixRMaj, int i, int i2) {
        if (dMatrixRMaj == null) {
            return new DMatrixRMaj(i, i2);
        }
        if (dMatrixRMaj.numRows == i && dMatrixRMaj.numCols == i2) {
            return dMatrixRMaj;
        }
        dMatrixRMaj.reshape(i, i2);
        return dMatrixRMaj;
    }

    public static ReshapeMatrix reshapeOrDeclare(ReshapeMatrix reshapeMatrix, ReshapeMatrix reshapeMatrix2, int i, int i2) {
        if (reshapeMatrix == null) {
            return (ReshapeMatrix) reshapeMatrix2.create(i, i2);
        }
        if (reshapeMatrix.getNumRows() == i && reshapeMatrix.getNumCols() == i2) {
            return reshapeMatrix;
        }
        reshapeMatrix.reshape(i, i2);
        return reshapeMatrix;
    }

    public static void checkValidMatrixShape(int i, int i2) {
        if (i < 0) {
            throw new IllegalArgumentException("Rows are negative: value=" + i);
        }
        if (i2 < 0) {
            throw new IllegalArgumentException("Cols are negative: value=" + i2);
        }
        checkTooLarge(i, i2);
    }

    public static void checkValidMatrixShapeComplex(int i, int i2) {
        if (i < 0) {
            throw new IllegalArgumentException("Rows are negative: value=" + i);
        }
        if (i2 < 0) {
            throw new IllegalArgumentException("Cols are negative: value=" + i2);
        }
        checkTooLargeComplex(i, i2);
    }

    public static void checkTooLarge(int i, int i2) {
        if (i * i2 != ((long) i) * ((long) i2)) {
            throw new IllegalArgumentException("Matrix size exceeds the size of an integer");
        }
    }

    public static void checkTooLargeComplex(int i, int i2) {
        if (i * 2 * i2 != ((long) i) * ((long) i2) * 2) {
            throw new IllegalArgumentException("Matrix size exceeds the size of an integer");
        }
    }

    public static String stringShapes(Matrix matrix, Matrix matrix2) {
        return "( " + matrix.getNumRows() + "x" + matrix.getNumCols() + " ) ( " + matrix2.getNumRows() + "x" + matrix2.getNumCols() + " )";
    }

    public static String fancyString(double d, DecimalFormat decimalFormat, int i, int i2) {
        return fancyString(d, decimalFormat, true, i, i2);
    }

    public static String fancyString(double d, DecimalFormat decimalFormat, boolean z, int i, int i2) {
        boolean z2 = Double.doubleToRawLongBits(d) < 0;
        if (d == 0.0d) {
            if (z2) {
                return "-0";
            }
            return z ? " 0" : CommonUrlParts.Values.FALSE_INTEGER;
        }
        int i3 = i - 1;
        String str = "";
        if (!z2 && z) {
            str = " ";
        }
        int iFloor = (int) Math.floor(Math.log10(Math.abs(d)));
        if (iFloor >= 0 && iFloor < i3) {
            decimalFormat.setMaximumFractionDigits((i - 3) - iFloor);
            return str + decimalFormat.format(d);
        }
        if (iFloor < 0 && i3 + iFloor > i2) {
            decimalFormat.setMaximumFractionDigits(i - 2);
            return str + decimalFormat.format(d);
        }
        int iMin = Math.min(i2, (i3 - i2) - (((int) Math.log10(Math.abs(iFloor))) + 1));
        if (iMin > 0) {
            return str + String.format("%." + iMin + "E", Double.valueOf(d));
        }
        return str + String.format("%.0E", Double.valueOf(d));
    }

    public static int[] adjust(IGrowArray iGrowArray, int i) {
        if (iGrowArray == null) {
            iGrowArray = new IGrowArray();
        }
        iGrowArray.reshape(i);
        return iGrowArray.data;
    }

    public static int[] adjust(IGrowArray iGrowArray, int i, int i2) {
        int[] iArrAdjust = adjust(iGrowArray, i);
        Arrays.fill(iArrAdjust, 0, i2, 0);
        return iArrAdjust;
    }

    public static double[] adjust(DGrowArray dGrowArray, int i) {
        if (dGrowArray == null) {
            dGrowArray = new DGrowArray();
        }
        dGrowArray.reshape(i);
        return dGrowArray.data;
    }

    public static float[] adjust(FGrowArray fGrowArray, int i) {
        if (fGrowArray == null) {
            fGrowArray = new FGrowArray();
        }
        fGrowArray.reshape(i);
        return fGrowArray.data;
    }

    public static void assertEq(int i, int i2) {
        assertEq(i, i2, "");
    }

    public static void assertEq(int i, int i2, String str) {
        if (i == i2) {
            return;
        }
        throw new IllegalArgumentException(i + " != " + i2 + " " + str);
    }

    public static void assertTrue(boolean z, String str) {
        if (!z) {
            throw new IllegalArgumentException(str);
        }
    }

    public static void assertShape(int i, int i2, String str) {
        if (i == i2) {
            return;
        }
        throw new MatrixDimensionException(i + " != " + i2 + " " + str);
    }
}
