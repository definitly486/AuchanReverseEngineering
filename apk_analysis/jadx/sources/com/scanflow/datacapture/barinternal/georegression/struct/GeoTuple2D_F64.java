package com.scanflow.datacapture.barinternal.georegression.struct;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import java.text.DecimalFormat;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
public abstract class GeoTuple2D_F64 extends GeoTuple_F64 {
    public double x;
    public double y;

    protected GeoTuple2D_F64() {
    }

    protected void _setTo(GeoTuple2D_F64 geoTuple2D_F64) {
        this.x = geoTuple2D_F64.x;
        this.y = geoTuple2D_F64.y;
    }

    public GeoTuple2D_F64 setTo(double d, double d2) {
        this.x = d;
        this.y = d2;
        return this;
    }

    public boolean isIdentical(GeoTuple2D_F64 geoTuple2D_F64, double d) {
        return Math.abs(this.x - geoTuple2D_F64.x) <= d && Math.abs(this.y - geoTuple2D_F64.y) <= d;
    }

    public double distance2(double d, double d2) {
        double d3 = d - this.x;
        double d4 = d2 - this.y;
        return (d3 * d3) + (d4 * d4);
    }

    public double distance(GeoTuple2D_F64 geoTuple2D_F64) {
        double d = geoTuple2D_F64.x - this.x;
        double d2 = geoTuple2D_F64.y - this.y;
        return Math.sqrt((d * d) + (d2 * d2));
    }

    public double distance2(GeoTuple2D_F64 geoTuple2D_F64) {
        double d = geoTuple2D_F64.x - this.x;
        double d2 = geoTuple2D_F64.y - this.y;
        return (d * d) + (d2 * d2);
    }

    public double norm() {
        double d = this.x;
        double d2 = this.y;
        return Math.sqrt((d * d) + (d2 * d2));
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        GeoTuple2D_F64 geoTuple2D_F64 = (GeoTuple2D_F64) obj;
        return Double.compare(this.x, geoTuple2D_F64.x) == 0 && Double.compare(this.y, geoTuple2D_F64.y) == 0;
    }

    protected String toString(String str) {
        DecimalFormat decimalFormat = new DecimalFormat("#");
        return str + "( " + UtilEjml.fancyString(this.x, decimalFormat, 11, 4) + " " + UtilEjml.fancyString(this.y, decimalFormat, 11, 4) + " )";
    }

    public int hashCode() {
        return Objects.hash(Double.valueOf(this.x), Double.valueOf(this.y));
    }
}
