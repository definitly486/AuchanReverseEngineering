package com.scanflow.datacapture.barinternal.georegression.geometry;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilPolygons2D_F64 {
    public static boolean isConvex(Polygon2D_F64 polygon2D_F64) {
        int size = polygon2D_F64.size();
        int i = 0;
        int i2 = 0;
        while (i < size) {
            int i3 = i + 1;
            int i4 = (i + 2) % size;
            Object[] objArr = polygon2D_F64.vertexes.data;
            Point2D_F64 point2D_F64 = ((Point2D_F64[]) objArr)[i];
            Point2D_F64 point2D_F65 = ((Point2D_F64[]) objArr)[i3 % size];
            Point2D_F64 point2D_F66 = ((Point2D_F64[]) objArr)[i4];
            double d = point2D_F64.x;
            double d2 = point2D_F65.x;
            double d3 = point2D_F64.y;
            double d4 = point2D_F65.y;
            if (((d - d2) * (point2D_F66.y - d4)) - ((d3 - d4) * (point2D_F66.x - d2)) > 0.0d) {
                i2++;
            }
            i = i3;
        }
        return i2 == 0 || i2 == size;
    }

    public static void shiftDown(Polygon2D_F64 polygon2D_F64) {
        int size = polygon2D_F64.size() - 1;
        Point2D_F64 point2D_F64 = polygon2D_F64.get(size);
        while (size > 0) {
            Object[] objArr = polygon2D_F64.vertexes.data;
            ((Point2D_F64[]) objArr)[size] = ((Point2D_F64[]) objArr)[size - 1];
            size--;
        }
        ((Point2D_F64[]) polygon2D_F64.vertexes.data)[0] = point2D_F64;
    }

    public static void removeAdjacentDuplicates(Polygon2D_F64 polygon2D_F64, double d) {
        int i = 0;
        for (int size = polygon2D_F64.vertexes.size() - 1; size >= 0 && polygon2D_F64.size() > 1; size--) {
            if (polygon2D_F64.get(size).isIdentical(polygon2D_F64.get(i), d)) {
                polygon2D_F64.vertexes.remove(size);
            }
            i = size;
        }
    }
}
