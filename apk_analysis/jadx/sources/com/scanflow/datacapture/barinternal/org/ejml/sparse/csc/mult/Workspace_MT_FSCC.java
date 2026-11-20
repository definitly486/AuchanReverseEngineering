package com.scanflow.datacapture.barinternal.org.ejml.sparse.csc.mult;

import com.scanflow.datacapture.barinternal.org.ejml.data.FGrowArray;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrixSparseCSC;
import com.scanflow.datacapture.barinternal.org.ejml.data.IGrowArray;

/* JADX INFO: loaded from: classes3.dex */
public class Workspace_MT_FSCC {
    public final IGrowArray gw = new IGrowArray();
    public final FGrowArray gx = new FGrowArray();
    public final FMatrixSparseCSC mat = new FMatrixSparseCSC(1, 1);
}
