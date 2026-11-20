package com.scanflow.datacapture.barinternal.org.opencv.core;

/* JADX INFO: loaded from: classes3.dex */
public class Point {
    public double x;
    public double y;

    public Point(double d, double d2) {
        this.x = d;
        this.y = d2;
    }

    /* JADX INFO: renamed from: clone, reason: merged with bridge method [inline-methods] */
    public Point m911clone() {
        return new Point(this.x, this.y);
    }

    public int hashCode() {
        long jDoubleToLongBits = Double.doubleToLongBits(this.x);
        int i = ((int) (jDoubleToLongBits ^ (jDoubleToLongBits >>> 32))) + 31;
        long jDoubleToLongBits2 = Double.doubleToLongBits(this.y);
        return (i * 31) + ((int) ((jDoubleToLongBits2 >>> 32) ^ jDoubleToLongBits2));
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Point)) {
            return false;
        }
        Point point = (Point) obj;
        return this.x == point.x && this.y == point.y;
    }

    public String toString() {
        return "{" + this.x + ", " + this.y + "}";
    }
}
