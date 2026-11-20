package com.scanflow.datacapture.barinternal.georegression.struct.homography;

import com.scanflow.datacapture.barinternal.georegression.struct.Matrix3x3_F64;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class Homography2D_F64 extends Matrix3x3_F64 implements Serializable {
    public Homography2D_F64(Homography2D_F64 homography2D_F64) {
        setTo(homography2D_F64);
    }

    public Homography2D_F64() {
        reset();
    }

    public Homography2D_F64 setTo(Homography2D_F64 homography2D_F64) {
        super.setTo((Matrix3x3_F64) homography2D_F64);
        return this;
    }

    public Homography2D_F64 invert(Homography2D_F64 homography2D_F64) {
        Homography2D_F64 homography2D_F65 = homography2D_F64 == null ? new Homography2D_F64() : homography2D_F64;
        double d = this.a22;
        double d2 = this.a33;
        double d3 = this.a23;
        double d4 = this.a32;
        double d5 = (d * d2) - (d3 * d4);
        double d6 = this.a21;
        double d7 = this.a31;
        double d8 = -((d6 * d2) - (d3 * d7));
        double d9 = (d6 * d4) - (d * d7);
        double d10 = this.a12;
        double d11 = d10 * d2;
        double d12 = this.a13;
        double d13 = -(d11 - (d12 * d4));
        double d14 = this.a11;
        double d15 = (d2 * d14) - (d12 * d7);
        double d16 = -((d4 * d14) - (d7 * d10));
        double d17 = (d10 * d3) - (d12 * d);
        double d18 = -((d3 * d14) - (d12 * d6));
        double d19 = (d * d14) - (d6 * d10);
        double d20 = (d14 * d5) + (d10 * d8) + (d12 * d9);
        homography2D_F65.a11 = d5 / d20;
        homography2D_F65.a12 = d13 / d20;
        homography2D_F65.a13 = d17 / d20;
        homography2D_F65.a21 = d8 / d20;
        homography2D_F65.a22 = d15 / d20;
        homography2D_F65.a23 = d18 / d20;
        homography2D_F65.a31 = d9 / d20;
        homography2D_F65.a32 = d16 / d20;
        homography2D_F65.a33 = d19 / d20;
        return homography2D_F65;
    }

    public void reset() {
        this.a33 = 1.0d;
        this.a22 = 1.0d;
        this.a11 = 1.0d;
        this.a32 = 0.0d;
        this.a31 = 0.0d;
        this.a23 = 0.0d;
        this.a21 = 0.0d;
        this.a13 = 0.0d;
        this.a12 = 0.0d;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.DMatrix3x3, com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public Homography2D_F64 copy() {
        return new Homography2D_F64(this);
    }

    public String toString() {
        return getClass().getSimpleName() + String.format("[ %5.2e %5.2e %5.2e ; %5.2e %5.2e %5.2e ; %5.2e %5.2e %5.2e ]", Double.valueOf(this.a11), Double.valueOf(this.a12), Double.valueOf(this.a13), Double.valueOf(this.a21), Double.valueOf(this.a22), Double.valueOf(this.a23), Double.valueOf(this.a31), Double.valueOf(this.a32), Double.valueOf(this.a33));
    }
}
