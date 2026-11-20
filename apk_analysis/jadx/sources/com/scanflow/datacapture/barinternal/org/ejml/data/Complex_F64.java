package com.scanflow.datacapture.barinternal.org.ejml.data;

/* JADX INFO: loaded from: classes3.dex */
public class Complex_F64 {
    public double imaginary;
    public double real;

    protected boolean canEqual(Object obj) {
        return obj instanceof Complex_F64;
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (!(obj instanceof Complex_F64)) {
            return false;
        }
        Complex_F64 complex_F64 = (Complex_F64) obj;
        return complex_F64.canEqual(this) && Double.compare(getReal(), complex_F64.getReal()) == 0 && Double.compare(getImaginary(), complex_F64.getImaginary()) == 0;
    }

    public int hashCode() {
        long jDoubleToLongBits = Double.doubleToLongBits(getReal());
        int i = ((int) (jDoubleToLongBits ^ (jDoubleToLongBits >>> 32))) + 59;
        long jDoubleToLongBits2 = Double.doubleToLongBits(getImaginary());
        return (i * 59) + ((int) ((jDoubleToLongBits2 >>> 32) ^ jDoubleToLongBits2));
    }

    public double getReal() {
        return this.real;
    }

    public double getImaginary() {
        return this.imaginary;
    }

    public String toString() {
        double d = this.imaginary;
        if (d == 0.0d) {
            double d2 = this.real;
            StringBuilder sb = new StringBuilder();
            sb.append(d2);
            return sb.toString();
        }
        return this.real + " " + d + "i";
    }
}
