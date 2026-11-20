package com.scanflow.datacapture.barinternal.org.opencv.core;

/* JADX INFO: loaded from: classes3.dex */
public class Size {
    public double height;
    public double width;

    public Size(double d, double d2) {
        this.width = d;
        this.height = d2;
    }

    public Size(double[] dArr) {
        set(dArr);
    }

    public void set(double[] dArr) {
        if (dArr != null) {
            this.width = dArr.length > 0 ? dArr[0] : 0.0d;
            this.height = dArr.length > 1 ? dArr[1] : 0.0d;
        } else {
            this.width = 0.0d;
            this.height = 0.0d;
        }
    }

    /* JADX INFO: renamed from: clone, reason: merged with bridge method [inline-methods] */
    public Size m914clone() {
        return new Size(this.width, this.height);
    }

    public int hashCode() {
        long jDoubleToLongBits = Double.doubleToLongBits(this.height);
        int i = ((int) (jDoubleToLongBits ^ (jDoubleToLongBits >>> 32))) + 31;
        long jDoubleToLongBits2 = Double.doubleToLongBits(this.width);
        return (i * 31) + ((int) ((jDoubleToLongBits2 >>> 32) ^ jDoubleToLongBits2));
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Size)) {
            return false;
        }
        Size size = (Size) obj;
        return this.width == size.width && this.height == size.height;
    }

    public String toString() {
        return ((int) this.width) + "x" + ((int) this.height);
    }
}
