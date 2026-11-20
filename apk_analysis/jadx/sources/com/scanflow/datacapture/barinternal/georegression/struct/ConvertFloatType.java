package com.scanflow.datacapture.barinternal.georegression.struct;

import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F32;
import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F64;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix3x3;
import com.scanflow.datacapture.barinternal.org.ejml.data.FMatrix3x3;
import com.scanflow.datacapture.barinternal.org.ejml.ops.ConvertMatrixData;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ConvertFloatType {
    public static Homography2D_F32 convert(Homography2D_F64 homography2D_F64, Homography2D_F32 homography2D_F32) {
        if (homography2D_F32 == null) {
            homography2D_F32 = new Homography2D_F32();
        }
        ConvertMatrixData.convert((DMatrix3x3) homography2D_F64, (FMatrix3x3) homography2D_F32);
        return homography2D_F32;
    }
}
