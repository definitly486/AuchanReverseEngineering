package com.scanflow.datacapture.barinternal.georegression.struct.line;

import com.scanflow.datacapture.barinternal.org.ejml.FancyPrint;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class LineGeneral2D_F64 implements Serializable {
    public double A;
    public double B;
    public double C;

    public LineGeneral2D_F64 setTo(LineGeneral2D_F64 lineGeneral2D_F64) {
        this.A = lineGeneral2D_F64.A;
        this.B = lineGeneral2D_F64.B;
        this.C = lineGeneral2D_F64.C;
        return this;
    }

    public void normalize() {
        double d = this.A;
        double d2 = this.B;
        double dSqrt = Math.sqrt((d * d) + (d2 * d2));
        this.A /= dSqrt;
        this.B /= dSqrt;
        this.C /= dSqrt;
    }

    public String toString() {
        FancyPrint fancyPrint = new FancyPrint();
        return getClass().getSimpleName() + "{ A=" + fancyPrint.s(this.A) + " B=" + fancyPrint.s(this.B) + " C=" + fancyPrint.s(this.C) + " }";
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof LineGeneral2D_F64)) {
            return false;
        }
        LineGeneral2D_F64 lineGeneral2D_F64 = (LineGeneral2D_F64) obj;
        return this.A == lineGeneral2D_F64.A && this.B == lineGeneral2D_F64.B && this.C == lineGeneral2D_F64.C;
    }

    public int hashCode() {
        return Double.hashCode(this.A + this.B + this.C);
    }
}
