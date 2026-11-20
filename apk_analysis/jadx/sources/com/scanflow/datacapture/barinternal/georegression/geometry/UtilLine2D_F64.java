package com.scanflow.datacapture.barinternal.georegression.geometry;

import com.scanflow.datacapture.barinternal.georegression.struct.line.LineGeneral2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineParametric2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LinePolar2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.line.LineSegment2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public abstract class UtilLine2D_F64 {
    public static LineGeneral2D_F64 convert(LinePolar2D_F64 linePolar2D_F64, LineGeneral2D_F64 lineGeneral2D_F64) {
        if (lineGeneral2D_F64 == null) {
            lineGeneral2D_F64 = new LineGeneral2D_F64();
        }
        double dCos = Math.cos(linePolar2D_F64.angle);
        double dSin = Math.sin(linePolar2D_F64.angle);
        lineGeneral2D_F64.A = dCos;
        lineGeneral2D_F64.B = dSin;
        lineGeneral2D_F64.C = -linePolar2D_F64.distance;
        return lineGeneral2D_F64;
    }

    public static LineParametric2D_F64 convert(LineSegment2D_F64 lineSegment2D_F64, LineParametric2D_F64 lineParametric2D_F64) {
        if (lineParametric2D_F64 == null) {
            lineParametric2D_F64 = new LineParametric2D_F64();
        }
        lineParametric2D_F64.p.setTo(lineSegment2D_F64.a);
        lineParametric2D_F64.slope.setTo(lineSegment2D_F64.slopeX(), lineSegment2D_F64.slopeY());
        return lineParametric2D_F64;
    }

    public static LineGeneral2D_F64 convert(LineSegment2D_F64 lineSegment2D_F64, LineGeneral2D_F64 lineGeneral2D_F64) {
        return convert(lineSegment2D_F64.a, lineSegment2D_F64.b, lineGeneral2D_F64);
    }

    public static LineGeneral2D_F64 convert(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65, LineGeneral2D_F64 lineGeneral2D_F64) {
        if (lineGeneral2D_F64 == null) {
            lineGeneral2D_F64 = new LineGeneral2D_F64();
        }
        double d = point2D_F64.y;
        double d2 = d - point2D_F65.y;
        lineGeneral2D_F64.A = d2;
        double d3 = point2D_F65.x;
        double d4 = point2D_F64.x;
        double d5 = d3 - d4;
        lineGeneral2D_F64.B = d5;
        lineGeneral2D_F64.C = -((d2 * d4) + (d5 * d));
        return lineGeneral2D_F64;
    }
}
