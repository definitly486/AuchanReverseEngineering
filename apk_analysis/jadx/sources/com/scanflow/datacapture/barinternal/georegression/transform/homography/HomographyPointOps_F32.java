package com.scanflow.datacapture.barinternal.georegression.transform.homography;

import com.scanflow.datacapture.barinternal.georegression.struct.homography.Homography2D_F32;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F32;

/* JADX INFO: loaded from: classes3.dex */
public abstract class HomographyPointOps_F32 {
    public static Point2D_F32 transform(Homography2D_F32 homography2D_F32, float f, float f2, Point2D_F32 point2D_F32) {
        if (point2D_F32 == null) {
            point2D_F32 = new Point2D_F32();
        }
        float f3 = (homography2D_F32.a31 * f) + (homography2D_F32.a32 * f2) + homography2D_F32.a33;
        point2D_F32.x = (((homography2D_F32.a11 * f) + (homography2D_F32.a12 * f2)) + homography2D_F32.a13) / f3;
        point2D_F32.y = (((homography2D_F32.a21 * f) + (homography2D_F32.a22 * f2)) + homography2D_F32.a23) / f3;
        return point2D_F32;
    }
}
