package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I32;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I8;

/* JADX INFO: loaded from: classes.dex */
public class ReedSolomonCodes_U8 {
    int generatorBase;
    GaliosFieldTableOps_U8 math;
    DogArray_I8 generator = new DogArray_I8();
    DogArray_I8 tmp0 = new DogArray_I8();
    DogArray_I8 tmp1 = new DogArray_I8();
    DogArray_I32 errorLocations = new DogArray_I32();
    DogArray_I8 errorLocatorPoly = new DogArray_I8();
    DogArray_I8 syndromes = new DogArray_I8();
    DogArray_I8 err_eval = new DogArray_I8();
    DogArray_I8 errorX = new DogArray_I8();
    DogArray_I8 err_loc_prime_tmp = new DogArray_I8();

    public ReedSolomonCodes_U8(int i, int i2, int i3) {
        if (i3 < 0 || i3 > 1) {
            throw new IllegalArgumentException("generatorBase must be 0 or 1");
        }
        this.math = new GaliosFieldTableOps_U8(i, i2);
        this.generatorBase = i3;
    }

    public boolean correct(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9) {
        computeSyndromes(dogArray_I8, dogArray_I9, this.syndromes);
        findErrorLocatorPolynomialBM(this.syndromes, this.errorLocatorPoly);
        if (!findErrorLocations_BruteForce(this.errorLocatorPoly, dogArray_I8.size + dogArray_I9.size, this.errorLocations)) {
            return false;
        }
        correctErrors(dogArray_I8, dogArray_I8.size + dogArray_I9.size, this.syndromes, this.errorLocatorPoly, this.errorLocations);
        return true;
    }

    void computeSyndromes(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9, DogArray_I8 dogArray_I10) {
        if (dogArray_I8.size + dogArray_I9.size > this.math.num_values) {
            throw new IllegalArgumentException("Combined size of input and ecc is larger than " + this.math.num_values);
        }
        dogArray_I10.resize(syndromeLength());
        for (int i = 0; i < dogArray_I10.size; i++) {
            int iGeneratorPower = generatorPower(i);
            dogArray_I10.data[i] = (byte) this.math.polyEvalContinue(this.math.polyEval(dogArray_I8, iGeneratorPower), dogArray_I9, iGeneratorPower);
        }
    }

    void findErrorLocatorPolynomialBM(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9) {
        DogArray_I8 dogArray_I10 = this.err_eval;
        initToOne(dogArray_I9, dogArray_I8.size + 1);
        initToOne(dogArray_I10, dogArray_I8.size + 1);
        DogArray_I8 dogArray_I11 = this.errorX;
        dogArray_I11.resize(dogArray_I8.size);
        int i = 1;
        for (int i2 = 0; i2 < dogArray_I8.size; i2++) {
            int iMultiply = dogArray_I8.data[i2] & UnsignedBytes.MAX_VALUE;
            int i3 = 1;
            while (true) {
                int i4 = dogArray_I9.size;
                if (i3 >= i4) {
                    break;
                }
                iMultiply ^= this.math.multiply(dogArray_I9.data[(i4 - i3) - 1] & UnsignedBytes.MAX_VALUE, dogArray_I8.data[i2 - i3] & UnsignedBytes.MAX_VALUE);
                i3++;
            }
            byte[] bArr = dogArray_I10.data;
            int i5 = dogArray_I10.size;
            dogArray_I10.size = i5 + 1;
            bArr[i5] = 0;
            if (iMultiply != 0) {
                GaliosFieldTableOps_U8 galiosFieldTableOps_U8 = this.math;
                this.math.polyAddScaleB(dogArray_I9, dogArray_I10, galiosFieldTableOps_U8.multiply(iMultiply, galiosFieldTableOps_U8.inverse(i)), dogArray_I11);
                if (dogArray_I10.size > dogArray_I9.size) {
                    dogArray_I10.setTo(dogArray_I9);
                    i = iMultiply;
                }
                dogArray_I9.setTo(dogArray_I11);
            }
        }
        removeLeadingZeros(dogArray_I9);
    }

    private void removeLeadingZeros(DogArray_I8 dogArray_I8) {
        int i = 0;
        while (i < dogArray_I8.size && dogArray_I8.data[i] == 0) {
            i++;
        }
        int i2 = i;
        while (true) {
            int i3 = dogArray_I8.size;
            if (i2 < i3) {
                byte[] bArr = dogArray_I8.data;
                bArr[i2 - i] = bArr[i2];
                i2++;
            } else {
                dogArray_I8.size = i3 - i;
                return;
            }
        }
    }

    public boolean findErrorLocations_BruteForce(DogArray_I8 dogArray_I8, int i, DogArray_I32 dogArray_I32) {
        dogArray_I32.resize(0);
        for (int i2 = 0; i2 < i; i2++) {
            GaliosFieldTableOps_U8 galiosFieldTableOps_U8 = this.math;
            if (galiosFieldTableOps_U8.polyEval_S(dogArray_I8, galiosFieldTableOps_U8.power(2, i2)) == 0) {
                dogArray_I32.add((i - i2) - 1);
            }
        }
        return dogArray_I32.size == dogArray_I8.size - 1;
    }

    void correctErrors(DogArray_I8 dogArray_I8, int i, DogArray_I8 dogArray_I9, DogArray_I8 dogArray_I10, DogArray_I32 dogArray_I32) {
        findErrorEvaluator(dogArray_I9, dogArray_I10, this.err_eval);
        this.errorX.reset().resize(dogArray_I32.size, (byte) 0);
        for (int i2 = 0; i2 < dogArray_I32.size; i2++) {
            this.errorX.data[i2] = (byte) this.math.power(2, (i - dogArray_I32.data[i2]) - 1);
        }
        this.err_loc_prime_tmp.resize(this.errorX.size);
        int i3 = 0;
        while (true) {
            DogArray_I8 dogArray_I11 = this.errorX;
            if (i3 >= dogArray_I11.size) {
                return;
            }
            int i4 = dogArray_I11.data[i3] & UnsignedBytes.MAX_VALUE;
            int iInverse = this.math.inverse(i4);
            this.err_loc_prime_tmp.size = 0;
            int i5 = 0;
            while (true) {
                DogArray_I8 dogArray_I12 = this.errorX;
                if (i5 >= dogArray_I12.size) {
                    break;
                }
                if (i3 != i5) {
                    DogArray_I8 dogArray_I13 = this.err_loc_prime_tmp;
                    byte[] bArr = dogArray_I13.data;
                    int i6 = dogArray_I13.size;
                    dogArray_I13.size = i6 + 1;
                    bArr[i6] = (byte) GaliosFieldOps.subtract(1, this.math.multiply(iInverse, dogArray_I12.data[i5] & UnsignedBytes.MAX_VALUE));
                }
                i5++;
            }
            int i7 = 0;
            int iMultiply = 1;
            while (true) {
                DogArray_I8 dogArray_I14 = this.err_loc_prime_tmp;
                if (i7 >= dogArray_I14.size) {
                    break;
                }
                iMultiply = this.math.multiply(iMultiply, dogArray_I14.data[i7] & UnsignedBytes.MAX_VALUE);
                i7++;
            }
            int iPolyEval_S = this.math.polyEval_S(this.err_eval, iInverse);
            GaliosFieldTableOps_U8 galiosFieldTableOps_U8 = this.math;
            int iDivide = this.math.divide(galiosFieldTableOps_U8.multiply(galiosFieldTableOps_U8.power(i4, 1), iPolyEval_S), iMultiply);
            if (this.generatorBase != 0) {
                iDivide = this.math.multiply(iDivide, iInverse);
            }
            int i8 = dogArray_I32.get(i3);
            if (i8 < dogArray_I8.size) {
                byte[] bArr2 = dogArray_I8.data;
                bArr2[i8] = (byte) (iDivide ^ (bArr2[i8] & UnsignedBytes.MAX_VALUE));
            }
            i3++;
        }
    }

    void findErrorEvaluator(DogArray_I8 dogArray_I8, DogArray_I8 dogArray_I9, DogArray_I8 dogArray_I10) {
        this.math.polyMult_flipA(dogArray_I8, dogArray_I9, dogArray_I10);
        int i = dogArray_I9.size - 1;
        int i2 = dogArray_I10.size - i;
        int i3 = 0;
        for (int i4 = 0; i4 < i; i4++) {
            byte[] bArr = dogArray_I10.data;
            bArr[i4] = bArr[i4 + i2];
        }
        dogArray_I10.data[i] = 0;
        dogArray_I10.size = dogArray_I9.size;
        while (true) {
            int i5 = dogArray_I10.size;
            if (i3 >= i5 / 2) {
                return;
            }
            int i6 = (i5 - i3) - 1;
            byte[] bArr2 = dogArray_I10.data;
            byte b = bArr2[i3];
            bArr2[i3] = bArr2[i6];
            bArr2[i6] = b;
            i3++;
        }
    }

    public void generator(int i) {
        initToOne(this.generator, i + 1);
        this.tmp1.resize(2);
        this.tmp1.data[0] = 1;
        for (int i2 = 0; i2 < i; i2++) {
            this.tmp1.data[1] = (byte) generatorPower(i2);
            this.math.polyMult(this.generator, this.tmp1, this.tmp0);
            this.generator.setTo(this.tmp0);
        }
    }

    void initToOne(DogArray_I8 dogArray_I8, int i) {
        dogArray_I8.reset();
        dogArray_I8.reserve(i);
        dogArray_I8.size = 1;
        dogArray_I8.data[0] = 1;
    }

    int generatorPower(int i) {
        return this.math.power(2, i + this.generatorBase);
    }

    private int syndromeLength() {
        return this.generator.size - 1;
    }

    public int getTotalErrors() {
        return this.errorLocations.size;
    }
}
