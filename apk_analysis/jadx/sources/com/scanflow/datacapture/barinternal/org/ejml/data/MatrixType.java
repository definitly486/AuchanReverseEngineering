package com.scanflow.datacapture.barinternal.org.ejml.data;

import org.ejml.data.CMatrixRMaj;

/* JADX INFO: loaded from: classes3.dex */
public enum MatrixType {
    DDRM(true, true, 64, DMatrixRMaj.class),
    FDRM(true, true, 32, FMatrixRMaj.class),
    ZDRM(false, true, 64, ZMatrixRMaj.class),
    CDRM(false, true, 32, CMatrixRMaj.class),
    DSCC(true, false, 64, DMatrixSparseCSC.class),
    FSCC(true, false, 32, FMatrixSparseCSC.class),
    ZSCC(false, false, 64, Object.class),
    CSCC(false, false, 32, Object.class),
    DTRIPLET(false, false, 64, DMatrixSparseTriplet.class),
    FTRIPLET(false, false, 64, FMatrixSparseTriplet.class),
    UNSPECIFIED(false, false, 0, Object.class);

    final int bits;
    final Class classType;
    final boolean dense;
    final boolean fixed;
    final boolean real;

    MatrixType(boolean z, boolean z2, int i, Class cls) {
        this(false, z, z2, i, cls);
    }

    MatrixType(boolean z, boolean z2, boolean z3, int i, Class cls) {
        this.real = z2;
        this.fixed = z;
        this.dense = z3;
        this.bits = i;
        this.classType = cls;
    }

    public static MatrixType lookup(boolean z, boolean z2, int i) {
        if (!z) {
            if (!z2) {
                throw new IllegalArgumentException("Complex sparse not yet supported");
            }
            if (i == 64) {
                return DSCC;
            }
            return FSCC;
        }
        if (z2) {
            if (i == 64) {
                return DDRM;
            }
            return FDRM;
        }
        if (i == 64) {
            return ZDRM;
        }
        return CDRM;
    }

    public boolean isReal() {
        return this.real;
    }

    public boolean isDense() {
        return this.dense;
    }

    public int getBits() {
        return this.bits;
    }

    public Class getClassType() {
        return this.classType;
    }

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.org.ejml.data.MatrixType$1, reason: invalid class name */
    static /* synthetic */ class AnonymousClass1 {
        static final /* synthetic */ int[] $SwitchMap$org$ejml$data$MatrixType;

        static {
            int[] iArr = new int[MatrixType.values().length];
            $SwitchMap$org$ejml$data$MatrixType = iArr;
            try {
                iArr[MatrixType.DDRM.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FDRM.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.ZDRM.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.CDRM.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.DSCC.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                $SwitchMap$org$ejml$data$MatrixType[MatrixType.FSCC.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
        }
    }

    public Matrix create(int i, int i2) {
        switch (AnonymousClass1.$SwitchMap$org$ejml$data$MatrixType[ordinal()]) {
            case 1:
                return new DMatrixRMaj(i, i2);
            case 2:
                return new FMatrixRMaj(i, i2);
            case 3:
                return new ZMatrixRMaj(i, i2);
            case 4:
                return new CMatrixRMaj(i, i2);
            case 5:
                return new DMatrixSparseCSC(i, i2);
            case 6:
                return new FMatrixSparseCSC(i, i2);
            default:
                throw new RuntimeException("Unknown Matrix Type " + this);
        }
    }
}
