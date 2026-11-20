package com.scanflow.datacapture.barinternal.boofcv.struct.geo;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point3D_F64;

/* JADX INFO: loaded from: classes.dex */
public class AssociatedPair3D {
    public Point3D_F64 p1 = new Point3D_F64();
    public Point3D_F64 p2 = new Point3D_F64();

    public AssociatedPair3D setTo(double d, double d2, double d3, double d4, double d5, double d6) {
        this.p1.setTo(d, d2, d3);
        this.p2.setTo(d4, d5, d6);
        return this;
    }

    public String toString() {
        return "AssociatedPair3D{p1=" + this.p1 + ", p2=" + this.p2 + "}";
    }
}
