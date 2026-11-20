package com.scanflow.datacapture.barinternal.georegression.struct.point;

import com.scanflow.datacapture.barinternal.georegression.struct.GeoTuple2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public class Point2D_F64 extends GeoTuple2D_F64 {
    public Point2D_F64 setTo(Point2D_F64 point2D_F64) {
        _setTo(point2D_F64);
        return this;
    }

    public String toString() {
        return toString("P");
    }
}
