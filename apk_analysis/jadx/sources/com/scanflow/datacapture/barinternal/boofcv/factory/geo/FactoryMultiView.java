package com.scanflow.datacapture.barinternal.boofcv.factory.geo;

import com.scanflow.datacapture.barinternal.boofcv.abst.geo.h.HomographyDLT_to_Epipolar;
import com.scanflow.datacapture.barinternal.boofcv.alg.geo.h.HomographyDirectLinearTransform;

/* JADX INFO: loaded from: classes.dex */
public abstract class FactoryMultiView {
    public static HomographyDLT_to_Epipolar homographyDLT(boolean z) {
        return new HomographyDLT_to_Epipolar(new HomographyDirectLinearTransform(z));
    }
}
