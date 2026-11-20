package com.scanflow.datacapture.barinternal.georegression.struct.shapes;

import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray;
import com.scanflow.datacapture.barinternal.org.ejml.UtilEjml;
import java.io.Serializable;
import java.text.DecimalFormat;

/* JADX INFO: loaded from: classes3.dex */
public class Polygon2D_F64 implements Serializable {
    public DogArray vertexes;

    public Polygon2D_F64(int i) {
        DogArray dogArray = new DogArray(i, new QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2());
        this.vertexes = dogArray;
        dogArray.reserve(i);
        this.vertexes.size = i;
    }

    public Polygon2D_F64() {
        this.vertexes = new DogArray(new QrCodeBinaryGridToPixel$$ExternalSyntheticLambda2());
    }

    public Polygon2D_F64 setTo(Polygon2D_F64 polygon2D_F64) {
        this.vertexes.resize(polygon2D_F64.size());
        for (int i = 0; i < polygon2D_F64.size(); i++) {
            ((Point2D_F64[]) this.vertexes.data)[i].setTo(((Point2D_F64[]) polygon2D_F64.vertexes.data)[i]);
        }
        return this;
    }

    public void set(int i, double d, double d2) {
        ((Point2D_F64[]) this.vertexes.data)[i].setTo(d, d2);
    }

    public Point2D_F64 get(int i) {
        return ((Point2D_F64[]) this.vertexes.data)[i];
    }

    public int size() {
        return this.vertexes.size();
    }

    public String toString() {
        DecimalFormat decimalFormat = new DecimalFormat("#");
        String str = getClass().getSimpleName() + "{ order=" + this.vertexes.size + ", [ ";
        int i = 0;
        while (true) {
            DogArray dogArray = this.vertexes;
            if (i < dogArray.size) {
                Point2D_F64 point2D_F64 = (Point2D_F64) dogArray.get(i);
                str = str + "(" + UtilEjml.fancyString(point2D_F64.x, decimalFormat, false, 11, 4) + ", " + UtilEjml.fancyString(point2D_F64.y, decimalFormat, false, 11, 4) + ") ";
                i++;
            } else {
                return str + "] }";
            }
        }
    }
}
