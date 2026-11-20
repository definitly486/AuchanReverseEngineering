package com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.svd;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.bidiagonal.BidiagonalDecompositionRow_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.bidiagonal.BidiagonalDecompositionTall_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.svd.implicitqr.SvdImplicitQrAlgorithm_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.BidiagonalDecomposition_F64;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public class SvdImplicitQrDecompose_DDRM implements SingularValueDecomposition_F64 {
    private DMatrixRMaj Ut;
    private DMatrixRMaj Vt;
    protected BidiagonalDecomposition_F64 bidiag;
    protected boolean canUseTallBidiagonal;
    protected boolean compact;
    protected boolean computeU;
    protected boolean computeV;
    double[] diag;
    protected int numCols;
    protected int numColsT;
    protected int numRows;
    protected int numRowsT;
    private int numSingular;
    double[] off;
    protected boolean prefComputeU;
    protected boolean prefComputeV;
    private double[] singularValues;
    protected boolean transposed;
    protected SvdImplicitQrAlgorithm_DDRM qralg = new SvdImplicitQrAlgorithm_DDRM();
    private DMatrixRMaj A_mod = new DMatrixRMaj(1, 1);

    public SvdImplicitQrDecompose_DDRM(boolean z, boolean z2, boolean z3, boolean z4) {
        this.compact = z;
        this.prefComputeU = z2;
        this.prefComputeV = z3;
        this.canUseTallBidiagonal = z4;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64
    public double[] getSingularValues() {
        return this.singularValues;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition
    public int numberOfSingularValues() {
        return this.numSingular;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition
    public DMatrixRMaj getV(DMatrixRMaj dMatrixRMaj, boolean z) {
        if (!this.prefComputeV) {
            throw new IllegalArgumentException("As requested V was not computed.");
        }
        if (z) {
            if (dMatrixRMaj == null) {
                return this.Vt;
            }
            dMatrixRMaj.setTo(this.Vt);
            return dMatrixRMaj;
        }
        DMatrixRMaj dMatrixRMaj2 = this.Vt;
        DMatrixRMaj dMatrixRMajReshapeOrDeclare = UtilEjml.reshapeOrDeclare(dMatrixRMaj, dMatrixRMaj2.numCols, dMatrixRMaj2.numRows);
        transpose(dMatrixRMajReshapeOrDeclare, this.Vt);
        return dMatrixRMajReshapeOrDeclare;
    }

    protected void transpose(DMatrixRMaj dMatrixRMaj, DMatrixRMaj dMatrixRMaj2) {
        CommonOps_DDRM.transpose(dMatrixRMaj2, dMatrixRMaj);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean decompose(DMatrixRMaj dMatrixRMaj) {
        if (!setup(dMatrixRMaj) || bidiagonalization(dMatrixRMaj) || computeUWV()) {
            return false;
        }
        makeSingularPositive();
        undoTranspose();
        return true;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.DecompositionInterface
    public boolean inputModified() {
        return false;
    }

    private boolean bidiagonalization(DMatrixRMaj dMatrixRMaj) {
        if (this.transposed) {
            this.A_mod.reshape(dMatrixRMaj.numCols, dMatrixRMaj.numRows, false);
            transpose(this.A_mod, dMatrixRMaj);
        } else {
            this.A_mod.reshape(dMatrixRMaj.numRows, dMatrixRMaj.numCols, false);
            this.A_mod.setTo(dMatrixRMaj);
        }
        return !this.bidiag.decompose(this.A_mod);
    }

    private void undoTranspose() {
        if (this.transposed) {
            DMatrixRMaj dMatrixRMaj = this.Vt;
            this.Vt = this.Ut;
            this.Ut = dMatrixRMaj;
        }
    }

    private boolean computeUWV() {
        this.bidiag.getDiagonal(this.diag, this.off);
        this.qralg.setMatrix(this.numRowsT, this.numColsT, this.diag, this.off);
        if (this.computeU) {
            this.Ut = (DMatrixRMaj) this.bidiag.getU(this.Ut, true, this.compact);
        }
        if (this.computeV) {
            this.Vt = (DMatrixRMaj) this.bidiag.getV(this.Vt, true, this.compact);
        }
        this.qralg.setFastValues(false);
        if (this.computeU) {
            this.qralg.setUt(this.Ut);
        } else {
            this.qralg.setUt(null);
        }
        if (this.computeV) {
            this.qralg.setVt(this.Vt);
        } else {
            this.qralg.setVt(null);
        }
        return !this.qralg.process();
    }

    private boolean setup(DMatrixRMaj dMatrixRMaj) {
        int i = dMatrixRMaj.numCols;
        int i2 = dMatrixRMaj.numRows;
        boolean z = i > i2;
        this.transposed = z;
        if (z) {
            this.computeU = this.prefComputeV;
            this.computeV = this.prefComputeU;
            this.numRowsT = i;
            this.numColsT = i2;
        } else {
            this.computeU = this.prefComputeU;
            this.computeV = this.prefComputeV;
            this.numRowsT = i2;
            this.numColsT = i;
        }
        this.numRows = i2;
        this.numCols = i;
        double[] dArr = this.diag;
        if (dArr == null || dArr.length < this.numColsT) {
            int i3 = this.numColsT;
            this.diag = new double[i3];
            this.off = new double[Math.max(0, i3 - 1)];
        }
        declareBidiagonalDecomposition();
        return true;
    }

    protected void declareBidiagonalDecomposition() {
        if (this.canUseTallBidiagonal && this.numRows > this.numCols * 2 && !this.computeU) {
            BidiagonalDecomposition_F64 bidiagonalDecomposition_F64 = this.bidiag;
            if (bidiagonalDecomposition_F64 == null || !(bidiagonalDecomposition_F64 instanceof BidiagonalDecompositionTall_DDRM)) {
                this.bidiag = new BidiagonalDecompositionTall_DDRM();
                return;
            }
            return;
        }
        BidiagonalDecomposition_F64 bidiagonalDecomposition_F65 = this.bidiag;
        if (bidiagonalDecomposition_F65 == null || !(bidiagonalDecomposition_F65 instanceof BidiagonalDecompositionRow_DDRM)) {
            this.bidiag = new BidiagonalDecompositionRow_DDRM();
        }
    }

    private void makeSingularPositive() {
        this.numSingular = this.qralg.getNumberOfSingularValues();
        this.singularValues = this.qralg.getSingularValues();
        for (int i = 0; i < this.numSingular; i++) {
            double singularValue = this.qralg.getSingularValue(i);
            if (singularValue < 0.0d) {
                this.singularValues[i] = 0.0d - singularValue;
                if (this.computeU) {
                    int i2 = this.Ut.numCols;
                    int i3 = i * i2;
                    int i4 = i2 + i3;
                    while (i3 < i4) {
                        DMatrixRMaj dMatrixRMaj = this.Ut;
                        dMatrixRMaj.set(i3, 0.0d - dMatrixRMaj.get(i3));
                        i3++;
                    }
                }
            } else {
                this.singularValues[i] = singularValue;
            }
        }
    }
}
