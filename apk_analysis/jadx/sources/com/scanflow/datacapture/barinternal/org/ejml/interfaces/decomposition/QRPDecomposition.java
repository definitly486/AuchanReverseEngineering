package com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition;

import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;

/* JADX INFO: loaded from: classes3.dex */
public interface QRPDecomposition extends QRDecomposition {
    Matrix getColPivotMatrix(Matrix matrix);
}
