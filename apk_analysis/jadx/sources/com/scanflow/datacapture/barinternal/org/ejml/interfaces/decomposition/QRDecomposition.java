package com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition;

import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;

/* JADX INFO: loaded from: classes3.dex */
public interface QRDecomposition extends DecompositionInterface {
    Matrix getQ(Matrix matrix, boolean z);

    Matrix getR(Matrix matrix, boolean z);
}
