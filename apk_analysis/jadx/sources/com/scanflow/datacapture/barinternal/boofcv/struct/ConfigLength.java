package com.scanflow.datacapture.barinternal.boofcv.struct;

import java.io.Serializable;

/* JADX INFO: loaded from: classes.dex */
public class ConfigLength implements Serializable {
    public double fraction;
    public double length;

    public ConfigLength(double d, double d2) {
        this.length = d;
        this.fraction = d2;
    }

    public ConfigLength() {
        this.length = -1.0d;
        this.fraction = -1.0d;
    }

    public static ConfigLength fixed(double d) {
        return new ConfigLength(d, -1.0d);
    }

    public static ConfigLength relative(double d, double d2) {
        return new ConfigLength(d2, d);
    }

    public double compute(double d) {
        double d2 = this.fraction;
        if (d2 >= 0.0d) {
            return Math.max(d2 * d, this.length);
        }
        return this.length;
    }

    public boolean isRelative() {
        return this.fraction >= 0.0d;
    }

    public int computeI(double d) {
        double dCompute = compute(d);
        if (dCompute >= 0.0d) {
            return (int) Math.round(dCompute);
        }
        throw new IllegalArgumentException("Threshold was set to a negative value: " + dCompute);
    }

    public int computeNegMaxI(double d) {
        double dCompute = compute(d);
        if (dCompute >= 0.0d) {
            return (int) Math.round(dCompute);
        }
        return Integer.MAX_VALUE;
    }

    public void checkValidity() {
        if (isRelative()) {
            double d = this.fraction;
            if (d < 0.0d || d > 1.0d) {
                throw new IllegalArgumentException("Fractional value must be from 0.0 to 1.0, inclusive");
            }
        }
    }

    public ConfigLength setTo(ConfigLength configLength) {
        this.length = configLength.length;
        this.fraction = configLength.fraction;
        return this;
    }

    public ConfigLength copy() {
        return new ConfigLength().setTo(this);
    }

    public String toString() {
        String str;
        double d = this.fraction;
        if (d >= 0.0d) {
            str = "ConfigLength{fraction=" + d + ", minimum=" + this.length;
        } else {
            str = "ConfigLength{, length=" + this.length;
        }
        return str + "}";
    }
}
