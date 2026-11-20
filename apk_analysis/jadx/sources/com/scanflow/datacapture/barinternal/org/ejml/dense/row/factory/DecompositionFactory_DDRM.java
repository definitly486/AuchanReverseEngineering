package com.scanflow.datacapture.barinternal.org.ejml.dense.row.factory;

import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.qr.QRColPivDecompositionHouseholderColumn_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.svd.SvdImplicitQrDecompose_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.QRPDecomposition_F64;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class DecompositionFactory_DDRM {
    public static SingularValueDecomposition_F64 svd(int i, int i2, boolean z, boolean z2, boolean z3) {
        return new SvdImplicitQrDecompose_DDRM(z3, z, z2, false);
    }

    public static QRPDecomposition_F64 qrp(int i, int i2) {
        return new QRColPivDecompositionHouseholderColumn_DDRM();
    }
}
