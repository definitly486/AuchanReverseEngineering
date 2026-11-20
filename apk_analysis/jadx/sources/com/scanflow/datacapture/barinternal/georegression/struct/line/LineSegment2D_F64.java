package com.scanflow.datacapture.barinternal.georegression.struct.line;

import com.scanflow.datacapture.barinternal.georegression.struct.point.Point2D_F64;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class LineSegment2D_F64 implements Serializable {
    public Point2D_F64 a = new Point2D_F64();
    public Point2D_F64 b = new Point2D_F64();

    public double slopeX() {
        return this.b.x - this.a.x;
    }

    public double slopeY() {
        return this.b.y - this.a.y;
    }

    public double getLength() {
        return this.a.distance(this.b);
    }

    public String toString() {
        return getClass().getSimpleName() + "{a=" + this.a + ", b=" + this.b + "}";
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof LineSegment2D_F64)) {
            return false;
        }
        LineSegment2D_F64 lineSegment2D_F64 = (LineSegment2D_F64) obj;
        return this.a.equals(lineSegment2D_F64.a) && this.b.equals(lineSegment2D_F64.b);
    }

    public int hashCode() {
        return this.a.hashCode() + this.b.hashCode();
    }
}
