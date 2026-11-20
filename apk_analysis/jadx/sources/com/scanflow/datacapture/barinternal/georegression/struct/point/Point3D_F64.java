package com.scanflow.datacapture.barinternal.georegression.struct.point;

import com.scanflow.datacapture.barinternal.georegression.struct.GeoTuple3D_F64;

/* JADX INFO: loaded from: classes3.dex */
public class Point3D_F64 extends GeoTuple3D_F64 {
    public Point3D_F64 setTo(Point3D_F64 point3D_F64) {
        _setTo(point3D_F64);
        return this;
    }

    public String toString() {
        return toString("P");
    }
}
