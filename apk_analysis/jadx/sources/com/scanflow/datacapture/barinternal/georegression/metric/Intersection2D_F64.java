package com.scanflow.datacapture.barinternal.georegression.metric;

import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Intersection2D_F64 {
    public static Point2D_F64 intersection(LineSegment2D_F64 lineSegment2D_F64, LineSegment2D_F64 lineSegment2D_F65, Point2D_F64 point2D_F64) {
        Point2D_F64 point2D_F65 = lineSegment2D_F64.b;
        double d = point2D_F65.x;
        Point2D_F64 point2D_F66 = lineSegment2D_F64.a;
        double d2 = point2D_F66.x;
        double d3 = d - d2;
        double d4 = point2D_F65.y;
        double d5 = point2D_F66.y;
        double d6 = d4 - d5;
        Point2D_F64 point2D_F67 = lineSegment2D_F65.b;
        double d7 = point2D_F67.x;
        Point2D_F64 point2D_F68 = lineSegment2D_F65.a;
        double d8 = point2D_F68.x;
        double d9 = d7 - d8;
        double d10 = point2D_F67.y;
        double d11 = point2D_F68.y;
        double d12 = d10 - d11;
        double d13 = ((d8 - d2) * d6) + ((d5 - d11) * d3);
        double d14 = d3 * d12;
        double d15 = d6 * d9;
        double d16 = d14 - d15;
        if (d16 == 0.0d) {
            return null;
        }
        double d17 = d13 / d16;
        if (d17 >= 0.0d && d17 <= 1.0d) {
            double d18 = (((d2 - d8) * d12) + ((d11 - d5) * d9)) / (d15 - d14);
            if (d18 >= 0.0d && d18 <= 1.0d) {
                Point2D_F64 point2D_F69 = point2D_F64 == null ? new Point2D_F64() : point2D_F64;
                Point2D_F64 point2D_F610 = lineSegment2D_F65.a;
                point2D_F69.setTo(point2D_F610.x + (d9 * d17), point2D_F610.y + (d12 * d17));
                return point2D_F69;
            }
        }
        return null;
    }

    public static Point2D_F64 intersection(LineGeneral2D_F64 lineGeneral2D_F64, LineGeneral2D_F64 lineGeneral2D_F65, Point2D_F64 point2D_F64) {
        if (point2D_F64 == null) {
            point2D_F64 = new Point2D_F64();
        }
        double d = lineGeneral2D_F64.B;
        double d2 = lineGeneral2D_F65.C;
        double d3 = lineGeneral2D_F64.C;
        double d4 = lineGeneral2D_F65.B;
        double d5 = (d * d2) - (d3 * d4);
        point2D_F64.x = d5;
        double d6 = lineGeneral2D_F65.A;
        double d7 = lineGeneral2D_F64.A;
        double d8 = (d3 * d6) - (d2 * d7);
        point2D_F64.y = d8;
        double d9 = (d7 * d4) - (d * d6);
        if (d9 == 0.0d) {
            return null;
        }
        point2D_F64.x = d5 / d9;
        point2D_F64.y = d8 / d9;
        return point2D_F64;
    }

    public static Point2D_F64 intersection(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65, Point2D_F64 point2D_F66, Point2D_F64 point2D_F67, Point2D_F64 point2D_F68) {
        Point2D_F64 point2D_F69 = point2D_F68 == null ? new Point2D_F64() : point2D_F68;
        double d = point2D_F65.x;
        double d2 = point2D_F64.x;
        double d3 = d - d2;
        double d4 = point2D_F65.y;
        double d5 = point2D_F64.y;
        double d6 = d4 - d5;
        double d7 = point2D_F67.x;
        double d8 = point2D_F66.x;
        double d9 = d7 - d8;
        double d10 = point2D_F67.y;
        double d11 = point2D_F66.y;
        double d12 = d10 - d11;
        double d13 = ((d8 - d2) * d6) + ((d5 - d11) * d3);
        double d14 = (d3 * d12) - (d6 * d9);
        if (d14 == 0.0d) {
            return null;
        }
        double d15 = d13 / d14;
        point2D_F69.x = d8 + (d9 * d15);
        point2D_F69.y = d11 + (d15 * d12);
        return point2D_F69;
    }
}
