package com.scanflow.datacapture.barinternal.georegression.metric;

import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class ClosestPoint2D_F64 {
    public static double closestPointT(LineParametric2D_F64 lineParametric2D_F64, Point2D_F64 point2D_F64, double d) {
        Vector2D_F64 vector2D_F64 = lineParametric2D_F64.slope;
        double d2 = vector2D_F64.x / d;
        double d3 = vector2D_F64.y / d;
        double d4 = point2D_F64.x;
        Point2D_F64 point2D_F65 = lineParametric2D_F64.p;
        return (((d4 - point2D_F65.x) * d2) + ((point2D_F64.y - point2D_F65.y) * d3)) / ((d2 * d2) + (d3 * d3));
    }

    public static double closestPointT(LineParametric2D_F64 lineParametric2D_F64, double d, double d2, double d3) {
        Vector2D_F64 vector2D_F64 = lineParametric2D_F64.slope;
        double d4 = vector2D_F64.x / d3;
        double d5 = vector2D_F64.y / d3;
        Point2D_F64 point2D_F64 = lineParametric2D_F64.p;
        return (((d - point2D_F64.x) * d4) + ((d2 - point2D_F64.y) * d5)) / ((d4 * d4) + (d5 * d5));
    }
}
