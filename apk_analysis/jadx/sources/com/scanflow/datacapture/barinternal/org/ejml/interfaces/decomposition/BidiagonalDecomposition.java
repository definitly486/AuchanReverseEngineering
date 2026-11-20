package com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition;

import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;

/* JADX INFO: loaded from: classes3.dex */
public interface BidiagonalDecomposition extends DecompositionInterface {
    Matrix getU(Matrix matrix, boolean z, boolean z2);

    Matrix getV(Matrix matrix, boolean z, boolean z2);
}
