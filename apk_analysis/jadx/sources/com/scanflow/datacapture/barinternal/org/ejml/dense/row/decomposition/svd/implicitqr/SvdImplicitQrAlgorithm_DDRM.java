package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.svd.implicitqr;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.eig.EigenvalueSmall_F64;
import java.util.Random;

/* JADX INFO: loaded from: classes3.dex */
public class SvdImplicitQrAlgorithm_DDRM {
    protected int N;
    protected DMatrixRMaj Ut;
    protected DMatrixRMaj Vt;
    double bulge;
    double c;
    protected double[] diag;
    private boolean findingZeros;
    boolean followScript;
    protected double maxValue;
    protected int nextExceptional;
    protected int numExceptional;
    protected int numSplits;
    protected double[] off;
    double s;
    protected int[] splits;
    int steps;
    protected int totalSteps;
    private double[] values;
    protected int x1;
    protected int x2;
    protected Random rand = new Random(3434270);
    protected EigenvalueSmall_F64 eigenSmall = new EigenvalueSmall_F64();
    private int exceptionalThresh = 15;
    private int maxIterations = 15 * 100;
    private boolean fastValues = false;

    public void setUt(DMatrixRMaj dMatrixRMaj) {
        this.Ut = dMatrixRMaj;
    }

    public void setVt(DMatrixRMaj dMatrixRMaj) {
        this.Vt = dMatrixRMaj;
    }

    public void setMatrix(int i, int i2, double[] dArr, double[] dArr2) {
        initParam(i, i2);
        this.diag = dArr;
        this.off = dArr2;
        if (dArr.length <= 0) {
            this.maxValue = 0.0d;
            return;
        }
        this.maxValue = Math.abs(dArr[0]);
        for (int i3 = 1; i3 < this.N; i3++) {
            double dAbs = Math.abs(dArr[i3]);
            double dAbs2 = Math.abs(dArr2[i3 - 1]);
            if (dAbs > this.maxValue) {
                this.maxValue = Math.abs(dAbs);
            }
            if (dAbs2 > this.maxValue) {
                this.maxValue = Math.abs(dAbs2);
            }
        }
    }

    public void initParam(int i, int i2) {
        if (i2 > i) {
            throw new RuntimeException("Must be a square or tall matrix");
        }
        this.N = i2;
        int[] iArr = this.splits;
        if (iArr == null || iArr.length < i2) {
            this.splits = new int[i2];
        }
        this.x1 = 0;
        this.x2 = i2 - 1;
        this.steps = 0;
        this.totalSteps = 0;
        this.numSplits = 0;
        this.numExceptional = 0;
        this.nextExceptional = this.exceptionalThresh;
    }

    public boolean process() {
        this.followScript = false;
        this.findingZeros = true;
        return _process();
    }

    public boolean _process() {
        if (this.maxValue == 0.0d) {
            return true;
        }
        while (true) {
            int i = this.x2;
            if (i < 0) {
                break;
            }
            int i2 = this.steps;
            if (i2 > this.maxIterations) {
                return false;
            }
            int i3 = this.x1;
            if (i3 == i) {
                resetSteps();
                if (!nextSplit()) {
                    break;
                }
            } else if (this.fastValues && i - i3 == 1) {
                resetSteps();
                eigenBB_2x2(this.x1);
                int i4 = this.x2;
                setSubmatrix(i4, i4);
            } else if (i2 >= this.nextExceptional) {
                exceptionShift();
            } else if (!checkForAndHandleZeros()) {
                if (this.followScript) {
                    performScriptedStep();
                } else {
                    performDynamicStep();
                }
            }
        }
        return true;
    }

    private void performDynamicStep() {
        if (this.findingZeros) {
            if (this.steps > 6) {
                this.findingZeros = false;
                return;
            } else {
                performImplicitSingleStep(computeBulgeScale(), 0.0d, false);
                return;
            }
        }
        double dComputeBulgeScale = computeBulgeScale();
        performImplicitSingleStep(dComputeBulgeScale, selectWilkinsonShift(dComputeBulgeScale), false);
    }

    private void performScriptedStep() {
        double dComputeBulgeScale = computeBulgeScale();
        if (this.steps > 10) {
            this.followScript = false;
        } else {
            double d = this.values[this.x2] / dComputeBulgeScale;
            performImplicitSingleStep(dComputeBulgeScale, d * d, false);
        }
    }

    public void incrementSteps() {
        this.steps++;
        this.totalSteps++;
    }

    public boolean isOffZero(int i) {
        return Math.abs(this.off[i]) <= (Math.abs(this.diag[i]) + Math.abs(this.diag[i + 1])) * UtilEjml.EPS;
    }

    public boolean isDiagonalZero(int i) {
        return Math.abs(this.diag[i]) <= (Math.abs(this.diag[i + 1]) + Math.abs(this.off[i])) * UtilEjml.EPS;
    }

    public void resetSteps() {
        this.steps = 0;
        this.nextExceptional = this.exceptionalThresh;
        this.numExceptional = 0;
    }

    public boolean nextSplit() {
        int i = this.numSplits;
        if (i == 0) {
            return false;
        }
        int[] iArr = this.splits;
        int i2 = i - 1;
        this.numSplits = i2;
        this.x2 = iArr[i2];
        if (i2 > 0) {
            this.x1 = iArr[i - 2] + 1;
        } else {
            this.x1 = 0;
        }
        return true;
    }

    public void performImplicitSingleStep(double d, double d2, boolean z) {
        createBulge(this.x1, d2, d, z);
        for (int i = this.x1; i < this.x2 - 1 && this.bulge != 0.0d; i++) {
            removeBulgeLeft(i, true);
            if (this.bulge == 0.0d) {
                break;
            }
            removeBulgeRight(i);
        }
        if (this.bulge != 0.0d) {
            removeBulgeLeft(this.x2 - 1, false);
        }
        incrementSteps();
    }

    protected void updateRotator(DMatrixRMaj dMatrixRMaj, int i, int i2, double d, double d2) {
        int i3 = dMatrixRMaj.numCols;
        int i4 = i * i3;
        int i5 = i2 * i3;
        int i6 = i3 + i4;
        while (i4 != i6) {
            double d3 = dMatrixRMaj.get(i4);
            double d4 = dMatrixRMaj.get(i5);
            dMatrixRMaj.set(i4, (d * d3) + (d2 * d4));
            dMatrixRMaj.set(i5, ((-d2) * d3) + (d4 * d));
            i4++;
            i5++;
        }
    }

    private double computeBulgeScale() {
        double[] dArr = this.diag;
        int i = this.x1;
        return Math.max(Math.abs(dArr[i]), Math.abs(this.off[i]));
    }

    protected void createBulge(int i, double d, double d2, boolean z) {
        double[] dArr = this.diag;
        double d3 = dArr[i];
        double d4 = this.off[i];
        int i2 = i + 1;
        double d5 = dArr[i2];
        if (z) {
            this.c = Math.cos(d);
            this.s = Math.sin(d);
        } else {
            double d6 = d3 / d2;
            double d7 = (d6 * d6) - d;
            double d8 = (d4 / d2) * d6;
            double dSqrt = Math.sqrt((d7 * d7) + (d8 * d8));
            this.c = d7 / dSqrt;
            this.s = d8 / dSqrt;
        }
        double[] dArr2 = this.diag;
        double d9 = this.c;
        double d10 = this.s;
        dArr2[i] = (d3 * d9) + (d4 * d10);
        this.off[i] = (d4 * d9) - (d3 * d10);
        dArr2[i2] = d5 * d9;
        this.bulge = d5 * d10;
        DMatrixRMaj dMatrixRMaj = this.Vt;
        if (dMatrixRMaj != null) {
            updateRotator(dMatrixRMaj, i, i2, d9, d10);
        }
    }

    protected void computeRotator(double d, double d2) {
        if (Math.abs(d) < Math.abs(d2)) {
            double d3 = d / d2;
            double dSqrt = Math.sqrt((d3 * d3) + 1.0d);
            this.s = 1.0d / dSqrt;
            this.c = d3 / dSqrt;
            return;
        }
        double d4 = d2 / d;
        double dSqrt2 = Math.sqrt((d4 * d4) + 1.0d);
        this.c = 1.0d / dSqrt2;
        this.s = d4 / dSqrt2;
    }

    protected void removeBulgeLeft(int i, boolean z) {
        double[] dArr = this.diag;
        double d = dArr[i];
        double d2 = this.off[i];
        int i2 = i + 1;
        double d3 = dArr[i2];
        computeRotator(d, this.bulge);
        double[] dArr2 = this.diag;
        double d4 = this.c;
        double d5 = this.s;
        dArr2[i] = (d * d4) + (this.bulge * d5);
        double[] dArr3 = this.off;
        dArr3[i] = (d4 * d2) + (d5 * d3);
        dArr2[i2] = (d4 * d3) - (d2 * d5);
        if (z) {
            double d6 = dArr3[i2];
            this.bulge = d5 * d6;
            dArr3[i2] = d6 * d4;
        }
        DMatrixRMaj dMatrixRMaj = this.Ut;
        if (dMatrixRMaj != null) {
            updateRotator(dMatrixRMaj, i, i2, d4, d5);
        }
    }

    protected void removeBulgeRight(int i) {
        double[] dArr = this.off;
        double d = dArr[i];
        int i2 = i + 1;
        double d2 = this.diag[i2];
        double d3 = dArr[i2];
        computeRotator(d, this.bulge);
        double[] dArr2 = this.off;
        double d4 = this.c;
        double d5 = this.bulge;
        double d6 = this.s;
        dArr2[i] = (d * d4) + (d5 * d6);
        double[] dArr3 = this.diag;
        dArr3[i2] = (d2 * d4) + (d3 * d6);
        dArr2[i2] = ((-d2) * d6) + (d3 * d4);
        int i3 = i + 2;
        double d7 = dArr3[i3];
        dArr3[i3] = d7 * d4;
        this.bulge = d7 * d6;
        DMatrixRMaj dMatrixRMaj = this.Vt;
        if (dMatrixRMaj != null) {
            updateRotator(dMatrixRMaj, i2, i3, d4, d6);
        }
    }

    public void setSubmatrix(int i, int i2) {
        this.x1 = i;
        this.x2 = i2;
    }

    public double selectWilkinsonShift(double d) {
        double d2;
        int i = this.x2;
        if (i - this.x1 > 1) {
            double[] dArr = this.diag;
            double d3 = dArr[i - 1] / d;
            double[] dArr2 = this.off;
            double d4 = dArr2[i - 2] / d;
            double d5 = dArr[i] / d;
            double d6 = dArr2[i - 1] / d;
            d2 = (d6 * d6) + (d5 * d5);
            this.eigenSmall.symm2x2_fast((d4 * d4) + (d3 * d3), d6 * d3, d2);
        } else {
            double[] dArr3 = this.diag;
            double d7 = dArr3[i - 1] / d;
            double d8 = this.off[i - 1] / d;
            double d9 = dArr3[i] / d;
            double d10 = (d8 * d8) + (d9 * d9);
            this.eigenSmall.symm2x2_fast(d7 * d7, d7 * d8, d10);
            d2 = d10;
        }
        return (Math.abs(this.eigenSmall.value0.real - d2) < Math.abs(this.eigenSmall.value1.real - d2) ? this.eigenSmall.value0 : this.eigenSmall.value1).real;
    }

    protected void eigenBB_2x2(int i) {
        double[] dArr = this.diag;
        double d = dArr[i];
        double d2 = this.off[i];
        int i2 = i + 1;
        double d3 = dArr[i2];
        double dAbs = Math.abs(d);
        double dAbs2 = Math.abs(d2);
        double dAbs3 = Math.abs(d3);
        if (dAbs <= dAbs2) {
            dAbs = dAbs2;
        }
        if (dAbs3 <= dAbs) {
            dAbs3 = dAbs;
        }
        if (dAbs3 == 0.0d) {
            return;
        }
        double d4 = d / dAbs3;
        double d5 = d2 / dAbs3;
        double d6 = d3 / dAbs3;
        this.eigenSmall.symm2x2_fast(d4 * d4, d4 * d5, (d5 * d5) + (d6 * d6));
        this.off[i] = 0.0d;
        this.diag[i] = Math.sqrt(this.eigenSmall.value0.real) * dAbs3;
        this.diag[i2] = Math.signum(this.eigenSmall.value1.real) * dAbs3 * Math.sqrt(Math.abs(this.eigenSmall.value1.real));
    }

    protected boolean checkForAndHandleZeros() {
        for (int i = this.x2 - 1; i >= this.x1; i--) {
            if (isOffZero(i)) {
                resetSteps();
                int[] iArr = this.splits;
                int i2 = this.numSplits;
                this.numSplits = i2 + 1;
                iArr[i2] = i;
                this.x1 = i + 1;
                return true;
            }
        }
        for (int i3 = this.x2 - 1; i3 >= this.x1; i3--) {
            if (isDiagonalZero(i3)) {
                pushRight(i3);
                resetSteps();
                int[] iArr2 = this.splits;
                int i4 = this.numSplits;
                this.numSplits = i4 + 1;
                iArr2[i4] = i3;
                this.x1 = i3 + 1;
                return true;
            }
        }
        return false;
    }

    private void pushRight(int i) {
        if (isOffZero(i)) {
            return;
        }
        rotatorPushRight(i);
        int i2 = (this.N - 2) - i;
        for (int i3 = 0; i3 < i2 && this.bulge != 0.0d; i3++) {
            rotatorPushRight2(i, i3 + 2);
        }
    }

    private void rotatorPushRight(int i) {
        double d = this.off[i];
        int i2 = i + 1;
        double d2 = this.diag[i2];
        computeRotator(d2, -d);
        double[] dArr = this.off;
        dArr[i] = 0.0d;
        double[] dArr2 = this.diag;
        double d3 = this.c;
        double d4 = this.s;
        dArr2[i2] = (d2 * d3) - (d * d4);
        if (i + 2 < this.N) {
            double d5 = dArr[i2];
            dArr[i2] = d5 * d3;
            this.bulge = d5 * d4;
        } else {
            this.bulge = 0.0d;
        }
        DMatrixRMaj dMatrixRMaj = this.Ut;
        if (dMatrixRMaj != null) {
            updateRotator(dMatrixRMaj, i, i2, d3, d4);
        }
    }

    private void rotatorPushRight2(int i, int i2) {
        double d = this.bulge;
        int i3 = i + i2;
        double d2 = this.diag[i3];
        computeRotator(d2, -d);
        double[] dArr = this.diag;
        double d3 = this.c;
        double d4 = this.s;
        dArr[i3] = (d2 * d3) - (d * d4);
        if (i3 < this.N - 1) {
            double[] dArr2 = this.off;
            double d5 = dArr2[i3];
            dArr2[i3] = d5 * d3;
            this.bulge = d5 * d4;
        }
        DMatrixRMaj dMatrixRMaj = this.Ut;
        if (dMatrixRMaj != null) {
            updateRotator(dMatrixRMaj, i, i3, d3, d4);
        }
    }

    public void exceptionShift() {
        int i = this.numExceptional + 1;
        this.numExceptional = i;
        double d = ((double) i) * 0.05d;
        if (d > 1.0d) {
            d = 1.0d;
        }
        performImplicitSingleStep(0.0d, UtilEjml.PI * 2.0d * (this.rand.nextDouble() - 0.5d) * d, true);
        this.nextExceptional = this.steps + this.exceptionalThresh;
    }

    public int getNumberOfSingularValues() {
        return this.N;
    }

    public double getSingularValue(int i) {
        return this.diag[i];
    }

    public void setFastValues(boolean z) {
        this.fastValues = z;
    }

    public double[] getSingularValues() {
        return this.diag;
    }
}
