package com.scanflow.datacapture.barinternal.georegression.geometry;

import com.scanflow.datacapture.barinternal.georegression.struct.GeoTuple2D_F64;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public abstract class GeometryMath_F64 {
    public static double innerProd(GeoTuple2D_F64 geoTuple2D_F64, DMatrixRMaj dMatrixRMaj, GeoTuple2D_F64 geoTuple2D_F65) {
        if (dMatrixRMaj.numRows != 3 || dMatrixRMaj.numCols != 3) {
            throw new IllegalArgumentException("M must be 3 by 3.");
        }
        double d = geoTuple2D_F64.x;
        double[] dArr = dMatrixRMaj.data;
        double d2 = dArr[0] * d;
        double d3 = geoTuple2D_F64.y;
        double d4 = d2 + (dArr[3] * d3) + dArr[6];
        double d5 = (dArr[1] * d) + (dArr[4] * d3) + dArr[7];
        return (d4 * geoTuple2D_F65.x) + (d5 * geoTuple2D_F65.y) + (d * dArr[2]) + (d3 * dArr[5]) + dArr[8];
    }
}
