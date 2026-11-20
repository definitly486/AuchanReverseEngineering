package com.scanflow.datacapture.barinternal.georegression.struct.point;

import com.scanflow.datacapture.barinternal.georegression.struct.GeoTuple_I32;
import java.util.Objects;

/* JADX INFO: loaded from: classes3.dex */
public class Point2D_I32 extends GeoTuple_I32 {
    public int x;
    public int y;

    public Point2D_I32(int i, int i2) {
        this.x = i;
        this.y = i2;
    }

    public Point2D_I32() {
    }

    public void setTo(int i, int i2) {
        this.x = i;
        this.y = i2;
    }

    public double distance(Point2D_I32 point2D_I32) {
        int i = this.x - point2D_I32.x;
        int i2 = this.y - point2D_I32.y;
        return Math.sqrt((i * i) + (i2 * i2));
    }

    public int distance2(Point2D_I32 point2D_I32) {
        int i = this.x - point2D_I32.x;
        int i2 = this.y - point2D_I32.y;
        return (i * i) + (i2 * i2);
    }

    public String toString() {
        return "Point2D_I32{x=" + this.x + ", y=" + this.y + "}";
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Point2D_I32)) {
            return false;
        }
        Point2D_I32 point2D_I32 = (Point2D_I32) obj;
        return this.x == point2D_I32.x && this.y == point2D_I32.y;
    }

    public int hashCode() {
        return Objects.hash(Integer.valueOf(this.x), Integer.valueOf(this.y));
    }
}
