package com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition;

import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;

/* JADX INFO: loaded from: classes3.dex */
public interface SingularValueDecomposition extends DecompositionInterface {
    Matrix getV(Matrix matrix, boolean z);

    int numberOfSingularValues();
}
