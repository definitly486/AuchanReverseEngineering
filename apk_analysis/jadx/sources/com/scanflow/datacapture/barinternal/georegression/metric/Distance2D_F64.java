package com.scanflow.datacapture.barinternal.georegression.metric;

import com.scanflow.datacapture.barinternal.georegression.geometry.UtilPoint2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Distance2D_F64 {
    public static double distanceSq(LineParametric2D_F64 lineParametric2D_F64, Point2D_F64 point2D_F64) {
        double dMax = Math.max(Math.abs(lineParametric2D_F64.slope.x), Math.abs(lineParametric2D_F64.slope.y));
        double dClosestPointT = ClosestPoint2D_F64.closestPointT(lineParametric2D_F64, point2D_F64, dMax);
        Vector2D_F64 vector2D_F64 = lineParametric2D_F64.slope;
        double d = (vector2D_F64.x / dMax) * dClosestPointT;
        Point2D_F64 point2D_F65 = lineParametric2D_F64.p;
        double d2 = d + point2D_F65.x;
        double d3 = ((vector2D_F64.y / dMax) * dClosestPointT) + point2D_F65.y;
        double d4 = point2D_F64.x - d2;
        double d5 = point2D_F64.y - d3;
        return (d4 * d4) + (d5 * d5);
    }

    public static double distanceSq(LineParametric2D_F64 lineParametric2D_F64, double d, double d2) {
        double dMax = Math.max(Math.abs(lineParametric2D_F64.slope.x), Math.abs(lineParametric2D_F64.slope.y));
        double dClosestPointT = ClosestPoint2D_F64.closestPointT(lineParametric2D_F64, d, d2, dMax);
        Vector2D_F64 vector2D_F64 = lineParametric2D_F64.slope;
        double d3 = (vector2D_F64.x / dMax) * dClosestPointT;
        Point2D_F64 point2D_F64 = lineParametric2D_F64.p;
        double d4 = d - (d3 + point2D_F64.x);
        double d5 = d2 - (((vector2D_F64.y / dMax) * dClosestPointT) + point2D_F64.y);
        return (d4 * d4) + (d5 * d5);
    }

    public static double distanceSq(LineSegment2D_F64 lineSegment2D_F64, double d, double d2) {
        Point2D_F64 point2D_F64 = lineSegment2D_F64.b;
        double d3 = point2D_F64.x;
        Point2D_F64 point2D_F65 = lineSegment2D_F64.a;
        double d4 = point2D_F65.x;
        double d5 = d3 - d4;
        double d6 = point2D_F64.y;
        double d7 = point2D_F65.y;
        double d8 = d6 - d7;
        double d9 = (((d - d4) * d5) + ((d2 - d7) * d8)) / ((d5 * d5) + (d8 * d8));
        if (d9 < 0.0d) {
            return UtilPoint2D_F64.distanceSq(d4, d7, d, d2);
        }
        if (d9 > 1.0d) {
            return UtilPoint2D_F64.distanceSq(d3, d6, d, d2);
        }
        return UtilPoint2D_F64.distanceSq(d4 + (d5 * d9), d7 + (d9 * d8), d, d2);
    }
}
