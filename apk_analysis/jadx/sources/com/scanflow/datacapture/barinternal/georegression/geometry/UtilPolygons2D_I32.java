package com.scanflow.datacapture.barinternal.georegression.geometry;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilPolygons2D_I32 {
    public static boolean isCCW(List list) {
        int size = list.size();
        int i = 0;
        int i2 = 0;
        while (i < size) {
            int i3 = i + 1;
            i2 = isPositiveZ((Point2D_I32) list.get(i), (Point2D_I32) list.get(i3 % size), (Point2D_I32) list.get((i + 2) % size)) ? i2 + 1 : i2 - 1;
            i = i3;
        }
        return i2 < 0;
    }

    public static boolean isPositiveZ(Point2D_I32 point2D_I32, Point2D_I32 point2D_I33, Point2D_I32 point2D_I34) {
        int i = point2D_I32.x;
        int i2 = point2D_I33.x;
        int i3 = point2D_I32.y;
        int i4 = point2D_I33.y;
        return ((i - i2) * (point2D_I34.y - i4)) - ((i3 - i4) * (point2D_I34.x - i2)) > 0;
    }
}
