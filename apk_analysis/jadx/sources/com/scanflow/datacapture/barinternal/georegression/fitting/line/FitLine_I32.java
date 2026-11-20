package com.scanflow.datacapture.barinternal.georegression.fitting.line;

import com.scanflow.datacapture.barinternal.georegression.struct.line.LinePolar2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_I32;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public abstract class FitLine_I32 {
    public static LinePolar2D_F64 polar(List list, int i, int i2, LinePolar2D_F64 linePolar2D_F64) {
        List list2 = list;
        int i3 = i2;
        LinePolar2D_F64 linePolar2D_F65 = linePolar2D_F64 == null ? new LinePolar2D_F64() : linePolar2D_F64;
        int i4 = 0;
        int i5 = 0;
        int i6 = 0;
        for (int i7 = 0; i7 < i3; i7++) {
            Point2D_I32 point2D_I32 = (Point2D_I32) list2.get(i + i7);
            i5 += point2D_I32.x;
            i6 += point2D_I32.y;
        }
        double d = i3;
        double d2 = ((double) i5) / d;
        double d3 = ((double) i6) / d;
        double d4 = 0.0d;
        double d5 = 0.0d;
        while (i4 < i3) {
            Point2D_I32 point2D_I33 = (Point2D_I32) list2.get(i + i4);
            double d6 = d2 - ((double) point2D_I33.x);
            double d7 = d3 - ((double) point2D_I33.y);
            d4 += d6 * d7;
            d5 += (d7 * d7) - (d6 * d6);
            i4++;
            list2 = list;
            i3 = i2;
        }
        double dAtan2 = Math.atan2(d4 * (-2.0d), d5) / 2.0d;
        linePolar2D_F65.angle = dAtan2;
        linePolar2D_F65.distance = (d2 * Math.cos(dAtan2)) + (d3 * Math.sin(linePolar2D_F65.angle));
        return linePolar2D_F65;
    }
}
