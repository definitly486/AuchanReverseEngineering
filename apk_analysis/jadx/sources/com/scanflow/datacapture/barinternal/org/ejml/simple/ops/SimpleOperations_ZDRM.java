package com.scanflow.datacapture.barinternal.org.ejml.simple.ops;

import com.scanflow.datacapture.barinternal.org.ejml.concurrency.EjmlConcurrency;
import com.scanflow.datacapture.barinternal.org.ejml.data.ZMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_MT_ZDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_ZDRM;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleOperations_ZDRM implements SimpleOperations {
    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations
    public void mult(ZMatrixRMaj zMatrixRMaj, ZMatrixRMaj zMatrixRMaj2, ZMatrixRMaj zMatrixRMaj3) {
        if (EjmlConcurrency.useConcurrent(zMatrixRMaj) || EjmlConcurrency.useConcurrent(zMatrixRMaj2)) {
            CommonOps_MT_ZDRM.mult(zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3);
        } else {
            CommonOps_ZDRM.mult(zMatrixRMaj, zMatrixRMaj2, zMatrixRMaj3);
        }
    }
}
