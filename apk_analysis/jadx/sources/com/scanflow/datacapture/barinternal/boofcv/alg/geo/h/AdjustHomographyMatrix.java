package com.scanflow.datacapture.barinternal.boofcv.alg.geo.h;

import com.scanflow.datacapture.barinternal.boofcv.struct.geo.AssociatedPair;
import com.scanflow.datacapture.barinternal.georegression.geometry.GeometryMath_F64;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.CommonOps_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.decomposition.svd.SafeSvd_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.dense.row.factory.DecompositionFactory_DDRM;
import com.scanflow.datacapture.barinternal.org.ejml.interfaces.decomposition.SingularValueDecomposition_F64;
import java.util.Arrays;

/* JADX INFO: loaded from: classes.dex */
public class AdjustHomographyMatrix {
    protected SingularValueDecomposition_F64 svd = new SafeSvd_DDRM(DecompositionFactory_DDRM.svd(0, 0, true, true, false));
    DMatrixRMaj H_t = new DMatrixRMaj(3, 3);

    public boolean adjust(DMatrixRMaj dMatrixRMaj, AssociatedPair associatedPair) {
        if (!findScaleH(dMatrixRMaj)) {
            return false;
        }
        adjustHomographSign(associatedPair, dMatrixRMaj);
        return true;
    }

    protected boolean findScaleH(DMatrixRMaj dMatrixRMaj) {
        if (!this.svd.decompose(dMatrixRMaj)) {
            return false;
        }
        Arrays.sort(this.svd.getSingularValues(), 0, 3);
        CommonOps_DDRM.divide(dMatrixRMaj, this.svd.getSingularValues()[1]);
        return true;
    }

    protected void adjustHomographSign(AssociatedPair associatedPair, DMatrixRMaj dMatrixRMaj) {
        if (GeometryMath_F64.innerProd(associatedPair.p2, dMatrixRMaj, associatedPair.p1) < 0.0d) {
            CommonOps_DDRM.scale(-1.0d, dMatrixRMaj);
        }
    }
}
