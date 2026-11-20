package com.scanflow.datacapture.barinternal.org.opencv.core;

/* JADX INFO: loaded from: classes3.dex */
public class Range {
    public int end;
    public int start;

    public Range(int i, int i2) {
        this.start = i;
        this.end = i2;
    }

    public static Range all() {
        return new Range(Integer.MIN_VALUE, Integer.MAX_VALUE);
    }

    /* JADX INFO: renamed from: clone, reason: merged with bridge method [inline-methods] */
    public Range m912clone() {
        return new Range(this.start, this.end);
    }

    public int hashCode() {
        long jDoubleToLongBits = Double.doubleToLongBits(this.start);
        int i = ((int) (jDoubleToLongBits ^ (jDoubleToLongBits >>> 32))) + 31;
        long jDoubleToLongBits2 = Double.doubleToLongBits(this.end);
        return (i * 31) + ((int) ((jDoubleToLongBits2 >>> 32) ^ jDoubleToLongBits2));
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Range)) {
            return false;
        }
        Range range = (Range) obj;
        return this.start == range.start && this.end == range.end;
    }

    public String toString() {
        return "[" + this.start + ", " + this.end + ")";
    }
}
