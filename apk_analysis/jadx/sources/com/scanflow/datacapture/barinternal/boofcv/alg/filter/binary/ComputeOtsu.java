package com.scanflow.datacapture.barinternal.boofcv.alg.filter.binary;

/* JADX INFO: loaded from: classes.dex */
public class ComputeOtsu {
    public boolean down;
    private double scale;
    public double threshold;
    private double tuning;
    private boolean useOtsu2;
    public double variance;

    public boolean isUseOtsu2() {
        return this.useOtsu2;
    }

    public double getTuning() {
        return this.tuning;
    }

    public double getScale() {
        return this.scale;
    }

    public ComputeOtsu(boolean z, double d, boolean z2, double d2) {
        this.useOtsu2 = z;
        this.tuning = d;
        this.down = z2;
        this.scale = d2;
    }

    public void compute(int[] iArr, int i, int i2) {
        if (this.useOtsu2) {
            computeOtsu2(iArr, i, i2);
        } else {
            computeOtsu(iArr, i, i2);
        }
        double d = this.variance + 0.001d;
        this.variance = d;
        double d2 = this.tuning;
        double d3 = this.threshold;
        int i3 = (int) (((((d2 * d3) * d2) * d3) / d) + 0.5d);
        if (this.down) {
            i3 = -i3;
        }
        double d4 = d3 + ((double) i3);
        this.threshold = d4;
        this.threshold = (int) ((this.scale * Math.max(d4, 0.0d)) + 0.5d);
    }

    protected void computeOtsu(int[] iArr, int i, int i2) {
        double d;
        int i3 = i;
        double d2 = i3;
        double d3 = 0.0d;
        int i4 = 0;
        double d4 = 0.0d;
        for (int i5 = 0; i5 < i3; i5++) {
            d4 += (((double) i5) / d2) * ((double) iArr[i5]);
        }
        this.variance = 0.0d;
        this.threshold = 0.0d;
        int i6 = 0;
        while (i4 < i3) {
            int i7 = iArr[i4];
            i6 += i7;
            if (i6 == 0) {
                d = d2;
            } else {
                int i8 = i2 - i6;
                if (i8 == 0) {
                    return;
                }
                double d5 = i4;
                d = d2;
                d3 += (d5 / d2) * ((double) i7);
                double d6 = i6;
                double d7 = i8;
                double d8 = (d3 / d6) - ((d4 - d3) / d7);
                double d9 = d6 * d7 * d8 * d8;
                if (d9 > this.variance) {
                    this.variance = d9;
                    this.threshold = d5;
                }
            }
            i4++;
            i3 = i;
            d2 = d;
        }
    }

    protected void computeOtsu2(int[] iArr, int i, int i2) {
        double d;
        int i3 = i;
        double d2 = i3;
        double d3 = 0.0d;
        double d4 = 0.0d;
        for (int i4 = 0; i4 < i3; i4++) {
            d4 += (((double) i4) / d2) * ((double) iArr[i4]);
        }
        this.variance = 0.0d;
        this.threshold = 0.0d;
        double d5 = 0.0d;
        int i5 = 0;
        int i6 = 0;
        double d6 = 0.0d;
        while (i5 < i3) {
            int i7 = iArr[i5];
            i6 += i7;
            if (i6 == 0) {
                d = d2;
            } else {
                int i8 = i2 - i6;
                if (i8 == 0) {
                    break;
                }
                d = d2;
                d3 += ((double) i7) * (((double) i5) / d);
                double d7 = i6;
                double d8 = d3 / d7;
                double d9 = i8;
                double d10 = (d4 - d3) / d9;
                double d11 = d7 * d9;
                double d12 = d8 - d10;
                double d13 = d11 * d12 * d12;
                if (d13 > this.variance) {
                    this.variance = d13;
                    d6 = d8;
                    d5 = d10;
                }
            }
            i5++;
            i3 = i;
            d2 = d;
        }
        this.threshold = (d2 * (d6 + d5)) / 2.0d;
    }
}
