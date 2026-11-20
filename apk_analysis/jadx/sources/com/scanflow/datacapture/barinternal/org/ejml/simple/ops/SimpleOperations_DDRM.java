package com.scanflow.datacapture.barinternal.org.ejml.simple.ops;

import com.scanflow.datacapture.barinternal.org.ejml.concurrency.EjmlConcurrency;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_MT_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleOperations_DDRM implements SimpleOperations {
    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations
    public void mult(DMatrixRMaj dMatrixRMaj, DMatrixRMaj dMatrixRMaj2, DMatrixRMaj dMatrixRMaj3) {
        if (EjmlConcurrency.useConcurrent(dMatrixRMaj) || EjmlConcurrency.useConcurrent(dMatrixRMaj2)) {
            CommonOps_MT_DDRM.mult(dMatrixRMaj, dMatrixRMaj2, dMatrixRMaj3);
        } else {
            CommonOps_DDRM.mult(dMatrixRMaj, dMatrixRMaj2, dMatrixRMaj3);
        }
    }
}
