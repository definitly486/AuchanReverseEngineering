package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class Complex_F32 {
    public float imaginary;
    public float real;

    protected boolean canEqual(Object obj) {
        return obj instanceof Complex_F32;
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (!(obj instanceof Complex_F32)) {
            return false;
        }
        Complex_F32 complex_F32 = (Complex_F32) obj;
        return complex_F32.canEqual(this) && Float.compare(getReal(), complex_F32.getReal()) == 0 && Float.compare(getImaginary(), complex_F32.getImaginary()) == 0;
    }

    public int hashCode() {
        return ((Float.floatToIntBits(getReal()) + 59) * 59) + Float.floatToIntBits(getImaginary());
    }

    public float getReal() {
        return this.real;
    }

    public float getImaginary() {
        return this.imaginary;
    }

    public String toString() {
        float f = this.imaginary;
        if (f == 0.0f) {
            float f2 = this.real;
            StringBuilder sb = new StringBuilder();
            sb.append(f2);
            return sb.toString();
        }
        return this.real + " " + f + "i";
    }
}
