package com.scanflow.datacapture.barinternal.georegression.geometry;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilPoint2D_F64 {
    public static double distanceSq(double d, double d2, double d3, double d4) {
        double d5 = d3 - d;
        double d6 = d4 - d2;
        return (d5 * d5) + (d6 * d6);
    }

    public static Point2D_F64 mean(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65, Point2D_F64 point2D_F66) {
        if (point2D_F66 == null) {
            point2D_F66 = new Point2D_F64();
        }
        point2D_F66.x = (point2D_F64.x + point2D_F65.x) / 2.0d;
        point2D_F66.y = (point2D_F64.y + point2D_F65.y) / 2.0d;
        return point2D_F66;
    }
}
