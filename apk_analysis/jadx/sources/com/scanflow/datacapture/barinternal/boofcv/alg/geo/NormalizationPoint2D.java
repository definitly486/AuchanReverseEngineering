package com.scanflow.datacapture.barinternal.boofcv.alg.geo;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point3D_F64;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix3x3;
import com.scanflow.datacapture.barinternal.org.ejml.data.DMatrixRMaj;

/* JADX INFO: loaded from: classes.dex */
public class NormalizationPoint2D {
    public double meanX = 0.0d;
    public double stdX = 1.0d;
    public double meanY = 0.0d;
    public double stdY = 1.0d;
    private DMatrix3x3 work = new DMatrix3x3();

    public void apply(Point2D_F64 point2D_F64, Point2D_F64 point2D_F65) {
        point2D_F65.x = (point2D_F64.x - this.meanX) / this.stdX;
        point2D_F65.y = (point2D_F64.y - this.meanY) / this.stdY;
    }

    public void apply(Point3D_F64 point3D_F64, Point3D_F64 point3D_F65) {
        double d = point3D_F64.x;
        double d2 = point3D_F64.z;
        point3D_F65.x = (d - (this.meanX * d2)) / this.stdX;
        point3D_F65.y = (point3D_F64.y - (d2 * this.meanY)) / this.stdY;
    }

    public DMatrixRMaj matrix(DMatrixRMaj dMatrixRMaj) {
        if (dMatrixRMaj == null) {
            dMatrixRMaj = new DMatrixRMaj(3, 3);
        } else {
            dMatrixRMaj.reshape(3, 3);
        }
        dMatrixRMaj.set(0, 0, 1.0d / this.stdX);
        dMatrixRMaj.set(1, 1, 1.0d / this.stdY);
        dMatrixRMaj.set(0, 2, (-this.meanX) / this.stdX);
        dMatrixRMaj.set(1, 2, (-this.meanY) / this.stdY);
        dMatrixRMaj.set(2, 2, 1.0d);
        return dMatrixRMaj;
    }

    public DMatrixRMaj matrixInv(DMatrixRMaj dMatrixRMaj) {
        if (dMatrixRMaj == null) {
            dMatrixRMaj = new DMatrixRMaj(3, 3);
        } else {
            dMatrixRMaj.reshape(3, 3);
        }
        dMatrixRMaj.set(0, 0, this.stdX);
        dMatrixRMaj.set(1, 1, this.stdY);
        dMatrixRMaj.set(0, 2, this.meanX);
        dMatrixRMaj.set(1, 2, this.meanY);
        dMatrixRMaj.set(2, 2, 1.0d);
        return dMatrixRMaj;
    }
}
