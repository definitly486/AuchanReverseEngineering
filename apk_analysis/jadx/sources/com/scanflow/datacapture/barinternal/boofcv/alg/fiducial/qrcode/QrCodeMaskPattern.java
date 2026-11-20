package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

/* JADX INFO: loaded from: classes.dex */
public abstract class QrCodeMaskPattern {
    public static final QrCodeMaskPattern M000 = new M000();
    public static final QrCodeMaskPattern M001 = new M001();
    public static final QrCodeMaskPattern M010 = new M010();
    public static final QrCodeMaskPattern M011 = new M011();
    public static final QrCodeMaskPattern M100 = new M100();
    public static final QrCodeMaskPattern M101 = new M101();
    public static final QrCodeMaskPattern M110 = new M110();
    public static final QrCodeMaskPattern M111 = new M111();
    int bits;

    public abstract int apply(int i, int i2, int i3);

    protected QrCodeMaskPattern(int i) {
        this.bits = i;
    }

    public static QrCodeMaskPattern lookupMask(int i) {
        switch (i) {
            case 0:
                return M000;
            case 1:
                return M001;
            case 2:
                return M010;
            case 3:
                return M011;
            case 4:
                return M100;
            case 5:
                return M101;
            case 6:
                return M110;
            case 7:
                return M111;
            default:
                throw new RuntimeException("Unknown mask: " + i);
        }
    }

    static class M000 extends QrCodeMaskPattern {
        public M000() {
            super(0);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            return ((~((i + i2) % 2)) & 1) ^ i3;
        }
    }

    static class M001 extends QrCodeMaskPattern {
        public M001() {
            super(1);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            return ((~(i % 2)) & 1) ^ i3;
        }
    }

    static class M010 extends QrCodeMaskPattern {
        public M010() {
            super(2);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            return (i2 % 3 == 0 ? 1 : 0) ^ i3;
        }
    }

    static class M011 extends QrCodeMaskPattern {
        public M011() {
            super(3);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            return ((i + i2) % 3 == 0 ? 1 : 0) ^ i3;
        }
    }

    static class M100 extends QrCodeMaskPattern {
        public M100() {
            super(4);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            return ((~(((i / 2) + (i2 / 3)) % 2)) & 1) ^ i3;
        }
    }

    static class M101 extends QrCodeMaskPattern {
        public M101() {
            super(5);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            int i4 = i * i2;
            return ((i4 % 2) + (i4 % 3) == 0 ? 1 : 0) ^ i3;
        }
    }

    static class M110 extends QrCodeMaskPattern {
        public M110() {
            super(6);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            int i4 = i * i2;
            return (((i4 % 2) + (i4 % 3)) % 2 == 0 ? 1 : 0) ^ i3;
        }
    }

    static class M111 extends QrCodeMaskPattern {
        public M111() {
            super(7);
        }

        @Override // com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCodeMaskPattern
        public int apply(int i, int i2, int i3) {
            return ((~((((i * i2) % 3) + ((i + i2) % 2)) % 2)) & 1) ^ i3;
        }
    }

    public String toString() {
        return getClass().getSimpleName();
    }
}
