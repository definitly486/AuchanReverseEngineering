package com.scanflow.datacapture.barinternal.org.ejml.simple.ops;

import com.scanflow.datacapture.barinternal.org.ejml.concurrency.EjmlConcurrency;
import com.scanflow.datacapture.barinternal.org.ejml.data.FGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixSparse;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.CommonOps_FSCC;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.CommonOps_MT_FSCC;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleOperations_FSCC implements SimpleOperations, Serializable {
    public transient IGrowArray gw = new IGrowArray();
    public transient FGrowArray gx = new FGrowArray();
    public transient GrowArray workspaceMT = new GrowArray(new SimpleOperations_FSCC$$ExternalSyntheticLambda0());
    public transient GrowArray workspaceA = new GrowArray(new ConcurrencyOps.NewInstance() { // from class: com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_FSCC$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps.NewInstance
        public final Object newInstance() {
            return new FGrowArray();
        }
    });

    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations
    public void mult(FMatrixSparseCSC fMatrixSparseCSC, FMatrixSparseCSC fMatrixSparseCSC2, FMatrixSparseCSC fMatrixSparseCSC3) {
        if (EjmlConcurrency.useConcurrent((MatrixSparse) fMatrixSparseCSC) || EjmlConcurrency.useConcurrent((MatrixSparse) fMatrixSparseCSC2)) {
            CommonOps_MT_FSCC.mult(fMatrixSparseCSC, fMatrixSparseCSC2, fMatrixSparseCSC3, this.workspaceMT);
        } else {
            CommonOps_FSCC.mult(fMatrixSparseCSC, fMatrixSparseCSC2, fMatrixSparseCSC3);
        }
    }
}
