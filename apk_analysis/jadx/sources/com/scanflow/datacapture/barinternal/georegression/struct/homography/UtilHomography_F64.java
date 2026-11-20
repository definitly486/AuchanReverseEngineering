package com.scanflow.datacapture.barinternal.georegression.struct.homography;

import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilHomography_F64 {
    public static Homography2D_F64 convert(DMatrixRMaj dMatrixRMaj, Homography2D_F64 homography2D_F64) {
        if (dMatrixRMaj.numCols != 3 || dMatrixRMaj.numRows != 3) {
            throw new IllegalArgumentException("Expected a 3 by 3 matrix.");
        }
        if (homography2D_F64 == null) {
            homography2D_F64 = new Homography2D_F64();
        }
        homography2D_F64.a11 = dMatrixRMaj.unsafe_get(0, 0);
        homography2D_F64.a12 = dMatrixRMaj.unsafe_get(0, 1);
        homography2D_F64.a13 = dMatrixRMaj.unsafe_get(0, 2);
        homography2D_F64.a21 = dMatrixRMaj.unsafe_get(1, 0);
        homography2D_F64.a22 = dMatrixRMaj.unsafe_get(1, 1);
        homography2D_F64.a23 = dMatrixRMaj.unsafe_get(1, 2);
        homography2D_F64.a31 = dMatrixRMaj.unsafe_get(2, 0);
        homography2D_F64.a32 = dMatrixRMaj.unsafe_get(2, 1);
        homography2D_F64.a33 = dMatrixRMaj.unsafe_get(2, 2);
        return homography2D_F64;
    }
}
