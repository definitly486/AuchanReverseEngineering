package com.scanflow.datacapture.barinternal.org.ejml.simple.ops;

import com.scanflow.datacapture.barinternal.org.ejml.concurrency.EjmlConcurrency;
import com.scanflow.datacapture.barinternal.org.ejml.data.DGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.MatrixSparse;
import com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.CommonOps_DSCC;
import com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.CommonOps_MT_DSCC;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps;
import com.scanflow.datacapture.barinternal.pabeles.concurrency.GrowArray;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class SimpleOperations_DSCC implements SimpleOperations, Serializable {
    public transient IGrowArray gw = new IGrowArray();
    public transient DGrowArray gx = new DGrowArray();
    public transient GrowArray workspaceMT = new GrowArray(new SimpleOperations_DSCC$$ExternalSyntheticLambda0());
    public transient GrowArray workspaceA = new GrowArray(new ConcurrencyOps.NewInstance() { // from class: com.scanflow.datacapture.barinternal.org.ejml.simple.ops.SimpleOperations_DSCC$$ExternalSyntheticLambda1
        @Override // com.scanflow.datacapture.barinternal.pabeles.concurrency.ConcurrencyOps.NewInstance
        public final Object newInstance() {
            return new DGrowArray();
        }
    });

    @Override // com.scanflow.datacapture.barinternal.org.ejml.simple.SimpleOperations
    public void mult(DMatrixSparseCSC dMatrixSparseCSC, DMatrixSparseCSC dMatrixSparseCSC2, DMatrixSparseCSC dMatrixSparseCSC3) {
        if (EjmlConcurrency.useConcurrent((MatrixSparse) dMatrixSparseCSC) || EjmlConcurrency.useConcurrent((MatrixSparse) dMatrixSparseCSC2)) {
            CommonOps_MT_DSCC.mult(dMatrixSparseCSC, dMatrixSparseCSC2, dMatrixSparseCSC3, this.workspaceMT);
        } else {
            CommonOps_DSCC.mult(dMatrixSparseCSC, dMatrixSparseCSC2, dMatrixSparseCSC3);
        }
    }
}
