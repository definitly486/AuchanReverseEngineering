package com.scanflow.datacapture.barinternal.georegression.struct;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import java.text.DecimalFormat;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
public abstract class GeoTuple2D_F32 extends GeoTuple_F32 {
    public float x;
    public float y;

    protected GeoTuple2D_F32() {
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        GeoTuple2D_F32 geoTuple2D_F32 = (GeoTuple2D_F32) obj;
        return Float.compare(this.x, geoTuple2D_F32.x) == 0 && Float.compare(this.y, geoTuple2D_F32.y) == 0;
    }

    protected String toString(String str) {
        DecimalFormat decimalFormat = new DecimalFormat("#");
        return str + "( " + UtilEjml.fancyString(this.x, decimalFormat, 11, 4) + " " + UtilEjml.fancyString(this.y, decimalFormat, 11, 4) + " )";
    }

    public int hashCode() {
        return Objects.hash(Float.valueOf(this.x), Float.valueOf(this.y));
    }
}
