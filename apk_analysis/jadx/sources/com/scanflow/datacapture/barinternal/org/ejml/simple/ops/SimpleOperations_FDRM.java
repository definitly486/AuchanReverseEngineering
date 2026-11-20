package com.scanflow.datacapture.barinternal.org.ejml.simple.ops;

import com.scanflow.datacapture.barinternal.org.ejml.concurrency.EjmlConcurrency;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_FDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_MT_FDRM;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleOperations_FDRM implements SimpleOperations {
    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations
    public void mult(FMatrixRMaj fMatrixRMaj, FMatrixRMaj fMatrixRMaj2, FMatrixRMaj fMatrixRMaj3) {
        if (EjmlConcurrency.useConcurrent(fMatrixRMaj) || EjmlConcurrency.useConcurrent(fMatrixRMaj2)) {
            CommonOps_MT_FDRM.mult(fMatrixRMaj, fMatrixRMaj2, fMatrixRMaj3);
        } else {
            CommonOps_FDRM.mult(fMatrixRMaj, fMatrixRMaj2, fMatrixRMaj3);
        }
    }
}
