package com.scanflow.datacapture.barinternal.georegression.struct.homography;

import com.scanflow.datacapture.barinternal.georegression.struct.Matrix3x3_F32;
import java.io.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public class Homography2D_F32 extends Matrix3x3_F32 implements Serializable {
    public Homography2D_F32(Homography2D_F32 homography2D_F32) {
        setTo(homography2D_F32);
    }

    public Homography2D_F32() {
        reset();
    }

    public Homography2D_F32 setTo(Homography2D_F32 homography2D_F32) {
        super.setTo((Matrix3x3_F32) homography2D_F32);
        return this;
    }

    public void reset() {
        this.a33 = 1.0f;
        this.a22 = 1.0f;
        this.a11 = 1.0f;
        this.a32 = 0.0f;
        this.a31 = 0.0f;
        this.a23 = 0.0f;
        this.a21 = 0.0f;
        this.a13 = 0.0f;
        this.a12 = 0.0f;
    }

    @Override // com.scanflow.datacapture.barinternal.org.ejml.data.Matrix
    public Homography2D_F32 copy() {
        return new Homography2D_F32(this);
    }

    public String toString() {
        return getClass().getSimpleName() + String.format("[ %5.2fe %5.2fe %5.2fe ; %5.2fe %5.2fe %5.2fe ; %5.2fe %5.2fe %5.2fe ]", Float.valueOf(this.a11), Float.valueOf(this.a12), Float.valueOf(this.a13), Float.valueOf(this.a21), Float.valueOf(this.a22), Float.valueOf(this.a23), Float.valueOf(this.a31), Float.valueOf(this.a32), Float.valueOf(this.a33));
    }
}
