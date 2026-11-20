package com.scanflow.datacapture.barinternal.boofcv.alg.shapes.polygon;

import com.scanflow.datacapture.barinternal.georegression.metric.Intersection2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;

/* JADX INFO: loaded from: classes.dex */
public abstract class UtilShapePolygon {
    public static boolean convert(LineGeneral2D_F64[] lineGeneral2D_F64Arr, Polygon2D_F64 polygon2D_F64) {
        int i = 0;
        while (i < polygon2D_F64.size()) {
            int i2 = i + 1;
            int size = i2 % polygon2D_F64.size();
            if (Intersection2D_F64.intersection(lineGeneral2D_F64Arr[i], lineGeneral2D_F64Arr[size], polygon2D_F64.get(size)) == null) {
                return false;
            }
            i = i2;
        }
        return true;
    }
}
