package com.scanflow.datacapture.barinternal.org.ejml.simple.ops;

import com.scanflow.datacapture.barinternal.org.ejml.concurrency.EjmlConcurrency;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations;
import org.ejml.data.CMatrixRMaj;
import org.ejml.dense.row.CommonOps_CDRM;
import org.ejml.dense.row.CommonOps_MT_CDRM;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleOperations_CDRM implements SimpleOperations {
    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations
    public void mult(CMatrixRMaj cMatrixRMaj, CMatrixRMaj cMatrixRMaj2, CMatrixRMaj cMatrixRMaj3) {
        if (EjmlConcurrency.useConcurrent(cMatrixRMaj) || EjmlConcurrency.useConcurrent(cMatrixRMaj2)) {
            CommonOps_MT_CDRM.mult(cMatrixRMaj, cMatrixRMaj2, cMatrixRMaj3);
        } else {
            CommonOps_CDRM.mult(cMatrixRMaj, cMatrixRMaj2, cMatrixRMaj3);
        }
    }
}
