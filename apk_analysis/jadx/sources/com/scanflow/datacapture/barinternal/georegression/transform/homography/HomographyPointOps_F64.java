package com.scanflow.datacapture.barinternal.georegression.transform.homography;

import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class HomographyPointOps_F64 {
    public static Point2D_F64 transform(Homography2D_F64 homography2D_F64, double d, double d2, Point2D_F64 point2D_F64) {
        if (point2D_F64 == null) {
            point2D_F64 = new Point2D_F64();
        }
        double d3 = (homography2D_F64.a31 * d) + (homography2D_F64.a32 * d2) + homography2D_F64.a33;
        point2D_F64.x = (((homography2D_F64.a11 * d) + (homography2D_F64.a12 * d2)) + homography2D_F64.a13) / d3;
        point2D_F64.y = (((homography2D_F64.a21 * d) + (homography2D_F64.a22 * d2)) + homography2D_F64.a23) / d3;
        return point2D_F64;
    }
}
