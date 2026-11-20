package com.scanflow.datacapture.barinternal.georegression.metric;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Area2D_F64 {
    public static double polygonSimple(Polygon2D_F64 polygon2D_F64) {
        double d = 0.0d;
        int i = 2;
        Point2D_F64 point2D_F64 = polygon2D_F64.get(0);
        Point2D_F64 point2D_F65 = polygon2D_F64.get(1);
        while (i < polygon2D_F64.size()) {
            Point2D_F64 point2D_F66 = polygon2D_F64.get(i);
            d += point2D_F65.x * (point2D_F66.y - point2D_F64.y);
            i++;
            point2D_F64 = point2D_F65;
            point2D_F65 = point2D_F66;
        }
        Point2D_F64 point2D_F67 = polygon2D_F64.get(0);
        return Math.abs(((d + (point2D_F65.x * (point2D_F67.y - point2D_F64.y))) + (point2D_F67.x * (polygon2D_F64.get(1).y - point2D_F65.y))) / 2.0d);
    }
}
