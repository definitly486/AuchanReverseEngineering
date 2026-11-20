package com.scanflow.datacapture.barinternal.org.ejml.concurrency;

import com.scanflow.datacapture.barinternal.org.ejml.data.Matrix;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixSparse;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;

/* JADX INFO: loaded from: classes3.dex */
public abstract class EjmlConcurrency extends ConcurrencyOps {
    public static int ELEMENT_THRESHOLD = 50000;
    public static boolean USE_CONCURRENT = true;

    public static boolean useConcurrent(MatrixSparse matrixSparse) {
        return USE_CONCURRENT && matrixSparse.getNonZeroLength() > ELEMENT_THRESHOLD;
    }

    public static boolean useConcurrent(Matrix matrix) {
        return USE_CONCURRENT && matrix.getNumRows() * matrix.getNumCols() > ELEMENT_THRESHOLD;
    }
}
