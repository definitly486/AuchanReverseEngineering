package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult;

import com.scanflow.datacapture.barinternal.org.ejml.data.DGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;

/* JADX INFO: loaded from: classes3.dex */
public class Workspace_MT_DSCC {
    public final IGrowArray gw = new IGrowArray();
    public final DGrowArray gx = new DGrowArray();
    public final DMatrixSparseCSC mat = new DMatrixSparseCSC(1, 1);
}
