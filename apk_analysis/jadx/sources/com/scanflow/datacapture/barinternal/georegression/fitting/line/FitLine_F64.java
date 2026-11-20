package com.scanflow.datacapture.barinternal.georegression.fitting.line;

import com.scanflow.datacapture.barinternal.georegression.struct.line.LinePolar2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FitLine_F64 {
    public static LinePolar2D_F64 polar(List list, LinePolar2D_F64 linePolar2D_F64) {
        LinePolar2D_F64 linePolar2D_F65 = linePolar2D_F64 == null ? new LinePolar2D_F64() : linePolar2D_F64;
        int size = list.size();
        int i = 0;
        double d = 0.0d;
        double d2 = 0.0d;
        double d3 = 0.0d;
        for (int i2 = 0; i2 < size; i2++) {
            Point2D_F64 point2D_F64 = (Point2D_F64) list.get(i2);
            d2 += point2D_F64.x;
            d3 += point2D_F64.y;
        }
        double d4 = size;
        double d5 = d2 / d4;
        double d6 = d3 / d4;
        double d7 = 0.0d;
        while (i < size) {
            Point2D_F64 point2D_F65 = (Point2D_F64) list.get(i);
            double d8 = d5 - point2D_F65.x;
            int i3 = size;
            double d9 = d6 - point2D_F65.y;
            d += d8 * d9;
            d7 += (d9 * d9) - (d8 * d8);
            i++;
            size = i3;
        }
        double dAtan2 = Math.atan2(d * (-2.0d), d7) / 2.0d;
        linePolar2D_F65.angle = dAtan2;
        linePolar2D_F65.distance = (d5 * Math.cos(dAtan2)) + (d6 * Math.sin(linePolar2D_F65.angle));
        return linePolar2D_F65;
    }

    public static LinePolar2D_F64 polar(List list, double[] dArr, LinePolar2D_F64 linePolar2D_F64) {
        List list2 = list;
        int size = list2.size();
        int i = 0;
        double d = 0.0d;
        for (int i2 = 0; i2 < size; i2++) {
            d += dArr[i2];
        }
        if (d == 0.0d) {
            return null;
        }
        LinePolar2D_F64 linePolar2D_F65 = linePolar2D_F64 == null ? new LinePolar2D_F64() : linePolar2D_F64;
        double d2 = 0.0d;
        double d3 = 0.0d;
        for (int i3 = 0; i3 < size; i3++) {
            Point2D_F64 point2D_F64 = (Point2D_F64) list2.get(i3);
            double d4 = dArr[i3];
            d2 += point2D_F64.x * d4;
            d3 += d4 * point2D_F64.y;
        }
        double d5 = d2 / d;
        double d6 = d3 / d;
        double d7 = 0.0d;
        double d8 = 0.0d;
        while (i < size) {
            Point2D_F64 point2D_F65 = (Point2D_F64) list2.get(i);
            double d9 = dArr[i];
            double d10 = d5 - point2D_F65.x;
            double d11 = d6 - point2D_F65.y;
            d7 += d9 * d10 * d11;
            d8 += d9 * ((d11 * d11) - (d10 * d10));
            i++;
            list2 = list;
            size = size;
        }
        double dAtan2 = Math.atan2((d7 / d) * (-2.0d), d8 / d) / 2.0d;
        linePolar2D_F65.angle = dAtan2;
        linePolar2D_F65.distance = (d5 * Math.cos(dAtan2)) + (d6 * Math.sin(linePolar2D_F65.angle));
        return linePolar2D_F65;
    }
}
