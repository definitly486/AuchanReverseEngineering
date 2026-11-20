package com.scanflow.datacapture.barinternal.georegression.struct.point;

import com.scanflow.datacapture.barinternal.georegression.geometry.UtilVector2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.GeoTuple2D_F64;

/* JADX INFO: loaded from: classes3.dex */
public class Vector2D_F64 extends GeoTuple2D_F64 {
    public String toString() {
        return toString("V");
    }

    public double dot(Vector2D_F64 vector2D_F64) {
        return (this.x * vector2D_F64.x) + (this.y * vector2D_F64.y);
    }

    public double acute(Vector2D_F64 vector2D_F64) {
        return UtilVector2D_F64.acute(this, vector2D_F64);
    }
}
