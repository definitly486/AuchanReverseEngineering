package com.scanflow.datacapture.barinternal.georegression.struct;

import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import java.text.DecimalFormat;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
public abstract class GeoTuple3D_F64 extends GeoTuple_F64 {
    public double x;
    public double y;
    public double z;

    protected GeoTuple3D_F64() {
    }

    protected void _setTo(GeoTuple3D_F64 geoTuple3D_F64) {
        this.x = geoTuple3D_F64.x;
        this.y = geoTuple3D_F64.y;
        this.z = geoTuple3D_F64.z;
    }

    public GeoTuple3D_F64 setTo(double d, double d2, double d3) {
        this.x = d;
        this.y = d2;
        this.z = d3;
        return this;
    }

    public void divideIP(double d) {
        this.x /= d;
        this.y /= d;
        this.z /= d;
    }

    public double norm() {
        double d = this.x;
        double d2 = this.y;
        double d3 = (d * d) + (d2 * d2);
        double d4 = this.z;
        return Math.sqrt(d3 + (d4 * d4));
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        GeoTuple3D_F64 geoTuple3D_F64 = (GeoTuple3D_F64) obj;
        return Double.compare(this.x, geoTuple3D_F64.x) == 0 && Double.compare(this.y, geoTuple3D_F64.y) == 0 && Double.compare(this.z, geoTuple3D_F64.z) == 0;
    }

    public String toString(String str) {
        DecimalFormat decimalFormat = new DecimalFormat("#");
        return str + "( " + UtilEjml.fancyString(this.x, decimalFormat, 11, 4) + " , " + UtilEjml.fancyString(this.y, decimalFormat, 11, 4) + " , " + UtilEjml.fancyString(this.z, decimalFormat, 11, 4) + " )";
    }

    public int hashCode() {
        return Objects.hash(Double.valueOf(this.x), Double.valueOf(this.y), Double.valueOf(this.z));
    }
}
