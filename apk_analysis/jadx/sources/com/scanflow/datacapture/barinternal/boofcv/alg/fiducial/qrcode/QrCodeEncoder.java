package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

/* JADX INFO: loaded from: classes.dex */
public abstract class QrCodeEncoder {
    public static int getLengthBitsNumeric(int i) {
        return getLengthBits(i, 10, 12, 14);
    }

    public static int getLengthBitsAlphanumeric(int i) {
        return getLengthBits(i, 9, 11, 13);
    }

    public static int getLengthBitsBytes(int i) {
        return getLengthBits(i, 8, 16, 16);
    }

    public static int getLengthBitsKanji(int i) {
        return getLengthBits(i, 8, 10, 12);
    }

    private static int getLengthBits(int i, int i2, int i3, int i4) {
        if (i < 10) {
            return i2;
        }
        return i < 27 ? i3 : i4;
    }
}
