package com.scanflow.datacapture.barinternal.boofcv.abst.geo.h;

import com.scanflow.datacapture.barinternal.boofcv.abst.geo.Estimate1ofEpipolar;
import com.scanflow.datacapture.barinternal.boofcv.alg.geo.h.HomographyDirectLinearTransform;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class HomographyDLT_to_Epipolar implements Estimate1ofEpipolar {
    HomographyDirectLinearTransform alg;

    public HomographyDLT_to_Epipolar(HomographyDirectLinearTransform homographyDirectLinearTransform) {
        this.alg = homographyDirectLinearTransform;
    }

    @Override // com.scanflow.datacapture.barinternal.boofcv.struct.geo.GeoModelEstimator1
    public boolean process(List list, DMatrixRMaj dMatrixRMaj) {
        return this.alg.process(list, dMatrixRMaj);
    }
}
