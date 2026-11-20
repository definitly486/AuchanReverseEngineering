package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.qr;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public abstract class QrHelperFunctions_DDRM {
    public static double findMax(double[] dArr, int i, int i2) {
        int i3 = i2 + i;
        double d = -1.0d;
        while (i < i3) {
            double d2 = dArr[i];
            if (d2 < 0.0d) {
                d2 = -d2;
            }
            if (d2 > d) {
                d = d2;
            }
            i++;
        }
        return d;
    }

    public static void divideElements(int i, int i2, double[] dArr, double d) {
        while (i < i2) {
            dArr[i] = dArr[i] / d;
            i++;
        }
    }

    public static void divideElements_Brow(int i, int i2, double[] dArr, double[] dArr2, int i3, double d) {
        while (i < i2) {
            int i4 = i + i3;
            double d2 = dArr2[i4] / d;
            dArr2[i4] = d2;
            dArr[i] = d2;
            i++;
        }
    }

    public static void divideElements_Bcol(int i, int i2, int i3, double[] dArr, double[] dArr2, int i4, double d) {
        int i5 = (i * i3) + i4;
        while (i < i2) {
            double d2 = dArr[i] / d;
            dArr[i] = d2;
            dArr2[i5] = d2;
            i++;
            i5 += i3;
        }
    }

    public static double computeTauAndDivide(int i, int i2, double[] dArr, int i3, double d) {
        double d2 = 0.0d;
        for (int i4 = i; i4 < i2; i4++) {
            int i5 = i3 + i4;
            double d3 = dArr[i5] / d;
            dArr[i5] = d3;
            d2 += d3 * d3;
        }
        double dSqrt = Math.sqrt(d2);
        return dArr[i3 + i] < 0.0d ? -dSqrt : dSqrt;
    }

    public static double computeTauAndDivide(int i, int i2, double[] dArr, double d) {
        double d2 = 0.0d;
        for (int i3 = i; i3 < i2; i3++) {
            double d3 = dArr[i3] / d;
            dArr[i3] = d3;
            d2 += d3 * d3;
        }
        double dSqrt = Math.sqrt(d2);
        return dArr[i] < 0.0d ? -dSqrt : dSqrt;
    }

    public static void rank1UpdateMultR(DMatrixRMaj dMatrixRMaj, double[] dArr, double d, int i, int i2, int i3, double[] dArr2) {
        int i4 = i;
        while (true) {
            int i5 = dMatrixRMaj.numCols;
            if (i4 >= i5) {
                break;
            }
            dArr2[i4] = dArr[i2] * dMatrixRMaj.data[(i5 * i2) + i4];
            i4++;
        }
        for (int i6 = i2 + 1; i6 < i3; i6++) {
            int i7 = (dMatrixRMaj.numCols * i6) + i;
            double d2 = dArr[i6];
            int i8 = i;
            while (i8 < dMatrixRMaj.numCols) {
                dArr2[i8] = dArr2[i8] + (dMatrixRMaj.data[i7] * d2);
                i8++;
                i7++;
            }
        }
        for (int i9 = i; i9 < dMatrixRMaj.numCols; i9++) {
            dArr2[i9] = dArr2[i9] * d;
        }
        for (int i10 = i2; i10 < i3; i10++) {
            double d3 = dArr[i10];
            int i11 = (dMatrixRMaj.numCols * i10) + i;
            int i12 = i;
            while (i12 < dMatrixRMaj.numCols) {
                double[] dArr3 = dMatrixRMaj.data;
                dArr3[i11] = dArr3[i11] - (dArr2[i12] * d3);
                i12++;
                i11++;
            }
        }
    }

    public static void rank1UpdateMultL(DMatrixRMaj dMatrixRMaj, double[] dArr, double d, int i, int i2, int i3) {
        for (int i4 = i; i4 < dMatrixRMaj.numRows; i4++) {
            int i5 = (dMatrixRMaj.numCols * i4) + i2;
            double d2 = 0.0d;
            int i6 = i2;
            int i7 = i5;
            while (i6 < i3) {
                d2 += dMatrixRMaj.data[i7] * dArr[i6];
                i6++;
                i7++;
            }
            double d3 = (-d) * d2;
            int i8 = i2;
            while (i8 < i3) {
                double[] dArr2 = dMatrixRMaj.data;
                dArr2[i5] = dArr2[i5] + (dArr[i8] * d3);
                i8++;
                i5++;
            }
        }
    }
}
