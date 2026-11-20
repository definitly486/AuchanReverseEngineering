package com.scanflow.datacapture.barinternal.boofcv.misc;

/* JADX INFO: loaded from: classes.dex */
public class MovingAverage {
    double average;
    double decay;
    boolean first;

    public MovingAverage(double d) {
        setDecay(d);
        this.decay = d;
        reset();
    }

    public void reset() {
        this.first = true;
        this.average = 0.0d;
    }

    public double update(double d) {
        if (this.first) {
            this.first = false;
            this.average = d;
        } else {
            double d2 = this.average;
            double d3 = this.decay;
            this.average = (d2 * d3) + ((1.0d - d3) * d);
        }
        return this.average;
    }

    public double getAverage() {
        return this.average;
    }

    public void setDecay(double d) {
        if (d < 0.0d || d > 1.0d) {
            throw new IllegalArgumentException("Decay must be from 0 to 1, inclusive");
        }
        this.decay = d;
    }
}
