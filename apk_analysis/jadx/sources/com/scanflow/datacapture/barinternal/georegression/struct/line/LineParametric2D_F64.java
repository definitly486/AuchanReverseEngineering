package com.scanflow.datacapture.barinternal.georegression.struct.line;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import com.scanflow.datacapture.barinternal.georegression.struct.point.Vector2D_F64;
import com.scanflow.datacapture.barinternal.org.ejml.FancyPrint;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class LineParametric2D_F64 implements Serializable {
    public Point2D_F64 p = new Point2D_F64();
    public Vector2D_F64 slope = new Vector2D_F64();

    public String toString() {
        FancyPrint fancyPrint = new FancyPrint();
        return getClass().getSimpleName() + " P( " + fancyPrint.s(this.p.x) + " " + fancyPrint.s(this.p.y) + " ) Slope( " + fancyPrint.s(this.slope.x) + " " + fancyPrint.s(this.slope.y) + " )";
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof LineParametric2D_F64)) {
            return false;
        }
        LineParametric2D_F64 lineParametric2D_F64 = (LineParametric2D_F64) obj;
        return this.p.equals(lineParametric2D_F64.p) && this.slope.equals(lineParametric2D_F64.slope);
    }

    public int hashCode() {
        return this.p.hashCode() + this.slope.hashCode();
    }
}
