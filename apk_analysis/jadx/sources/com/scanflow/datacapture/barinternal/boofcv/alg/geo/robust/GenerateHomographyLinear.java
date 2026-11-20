package com.scanflow.datacapture.barinternal.boofcv.alg.geo.robust;

import com.scanflow.datacapture.barinternal.boofcv.abst.geo.Estimate1ofEpipolar;
import com.scanflow.datacapture.barinternal.boofcv.factory.geo.FactoryMultiView;
import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.homography.UtilHomography_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.fitting.modelset.ModelGenerator;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;
import java.util.List;

/* JADX INFO: loaded from: classes.dex */
public class GenerateHomographyLinear implements ModelGenerator {
    DMatrixRMaj H = new DMatrixRMaj(3, 3);
    Estimate1ofEpipolar alg;

    public GenerateHomographyLinear(boolean z) {
        this.alg = FactoryMultiView.homographyDLT(z);
    }

    @Override // com.scanflow.datacapture.barinternal.org.ddogleg.fitting.modelset.ModelGenerator
    public boolean generate(List list, Homography2D_F64 homography2D_F64) {
        if (!this.alg.process(list, this.H)) {
            return false;
        }
        UtilHomography_F64.convert(this.H, homography2D_F64);
        return true;
    }
}
