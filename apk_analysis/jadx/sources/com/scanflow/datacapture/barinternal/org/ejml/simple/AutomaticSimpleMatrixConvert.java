package com.scanflow.datacapture.barinternal.org.ejml.simple;

import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType;
import com.scanflow.datacapture.barinternal.org.ejml.ops.ConvertMatrixType;

/* JADX INFO: loaded from: classes3.dex */
public class AutomaticSimpleMatrixConvert {
    MatrixType commonType;

    public void specify(ConstMatrix... constMatrixArr) {
        int i = 32;
        boolean z = false;
        boolean z2 = true;
        for (ConstMatrix constMatrix : constMatrixArr) {
            MatrixType type = constMatrix.getType();
            if (type.isDense()) {
                z = true;
            }
            if (!type.isReal()) {
                z2 = false;
            }
            if (type.getBits() == 64) {
                i = 64;
            }
        }
        this.commonType = MatrixType.lookup(z, z2, i);
    }

    public SimpleBase convert(SimpleBase simpleBase) {
        if (simpleBase.getType() == this.commonType) {
            return simpleBase;
        }
        if (!simpleBase.getType().isDense() && this.commonType.isDense()) {
            System.err.println("\n***** WARNING *****\n");
            System.err.println("Converting a sparse to dense matrix automatically.");
            System.err.println("Current auto convert code isn't that smart and this might have been available");
        }
        Matrix matrixConvert = ConvertMatrixType.convert(simpleBase.mat, this.commonType);
        if (matrixConvert == null) {
            throw new IllegalArgumentException("Conversion from " + simpleBase.getType() + " to " + this.commonType + " not possible");
        }
        return simpleBase.wrapMatrix(matrixConvert);
    }
}
