package com.scanflow.datacapture.barinternal.boofcv.struct.geo;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;

/* JADX INFO: loaded from: classes.dex */
public class AssociatedPair {
    public Point2D_F64 p1 = new Point2D_F64();
    public Point2D_F64 p2 = new Point2D_F64();

    public AssociatedPair setTo(double d, double d2, double d3, double d4) {
        this.p1.setTo(d, d2);
        this.p2.setTo(d3, d4);
        return this;
    }

    public String toString() {
        Point2D_F64 point2D_F64 = this.p1;
        double d = point2D_F64.x;
        double d2 = point2D_F64.y;
        Point2D_F64 point2D_F65 = this.p2;
        return "AssociatedPair{p1=(" + d + ", " + d2 + "), p2=(" + point2D_F65.x + ", " + point2D_F65.y + ")}";
    }
}
