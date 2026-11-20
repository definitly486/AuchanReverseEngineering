package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.google.common.primitives.UnsignedBytes;
import com.scanflow.datacapture.barinternal.org.ddogleg.struct.DogArray_I8;
import io.appmetrica.analytics.BuildConfig;
import java.io.PrintStream;
import java.io.UnsupportedEncodingException;
import java.nio.charset.Charset;
import java.nio.charset.CharsetEncoder;

/* JADX INFO: loaded from: classes.dex */
public class QrCodeCodecBitsUtils {
    static final CharsetEncoder asciiEncoder = Charset.forName("ISO-8859-1").newEncoder();
    public String defaultEncoding;
    String encodingEci;
    String forceEncoding;
    public QrCode.Failure failureCause = QrCode.Failure.NONE;
    public final StringBuilder workString = new StringBuilder();
    public String selectedByteEncoding = "";
    PrintStream verbose = null;

    public QrCodeCodecBitsUtils(String str, String str2) {
        this.forceEncoding = str;
        this.defaultEncoding = str2;
    }

    public int decodeNumeric(PackedBits8 packedBits8, int i, int i2) {
        int i3 = packedBits8.read(i, i2, true);
        int i4 = i + i2;
        while (i3 >= 3) {
            int i5 = packedBits8.size;
            int i6 = i4 + 10;
            if (i5 < i6) {
                PrintStream printStream = this.verbose;
                if (printStream != null) {
                    printStream.printf("overflow: numeric data.size=%d\n", Integer.valueOf(i5));
                }
                this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
                return -1;
            }
            int i7 = packedBits8.read(i4, 10, true);
            int i8 = i7 / 100;
            int i9 = i7 - (i8 * 100);
            int i10 = i9 / 10;
            this.workString.append((char) (i8 + 48));
            this.workString.append((char) (i10 + 48));
            this.workString.append((char) ((i9 - (i10 * 10)) + 48));
            i3 -= 3;
            i4 = i6;
        }
        if (i3 != 2) {
            if (i3 != 1) {
                return i4;
            }
            int i11 = i4 + 4;
            if (packedBits8.size < i11) {
                this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
                return -1;
            }
            this.workString.append((char) (packedBits8.read(i4, 4, true) + 48));
            return i11;
        }
        int i12 = i4 + 7;
        if (packedBits8.size < i12) {
            this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
            return -1;
        }
        int i13 = packedBits8.read(i4, 7, true);
        int i14 = i13 / 10;
        this.workString.append((char) (i14 + 48));
        this.workString.append((char) ((i13 - (i14 * 10)) + 48));
        return i12;
    }

    public int decodeAlphanumeric(PackedBits8 packedBits8, int i, int i2) {
        int i3 = packedBits8.read(i, i2, true);
        int i4 = i + i2;
        while (i3 >= 2) {
            int i5 = packedBits8.size;
            int i6 = i4 + 11;
            if (i5 < i6) {
                PrintStream printStream = this.verbose;
                if (printStream != null) {
                    printStream.printf("overflow: alphanumeric data.size=%d\n", Integer.valueOf(i5));
                }
                this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
                return -1;
            }
            int i7 = packedBits8.read(i4, 11, true);
            int i8 = i7 / 45;
            this.workString.append(valueToAlphanumeric(i8));
            this.workString.append(valueToAlphanumeric(i7 - (i8 * 45)));
            i3 -= 2;
            i4 = i6;
        }
        if (i3 != 1) {
            return i4;
        }
        int i9 = i4 + 6;
        if (packedBits8.size < i9) {
            this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
            return -1;
        }
        this.workString.append(valueToAlphanumeric(packedBits8.read(i4, 6, true)));
        return i9;
    }

    public int decodeByte(PackedBits8 packedBits8, int i, int i2) {
        int i3 = packedBits8.read(i, i2, true);
        int i4 = i + i2;
        int i5 = i3 * 8;
        int i6 = packedBits8.size;
        if (i5 > i6 - i4) {
            PrintStream printStream = this.verbose;
            if (printStream != null) {
                printStream.printf("overflow: byte data.size=%d\n", Integer.valueOf(i6));
            }
            this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
            return -1;
        }
        byte[] bArr = new byte[i3];
        for (int i7 = 0; i7 < i3; i7++) {
            bArr[i7] = (byte) packedBits8.read(i4, 8, true);
            i4 += 8;
        }
        String strSelectByteEncoding = selectByteEncoding(bArr);
        this.selectedByteEncoding = strSelectByteEncoding;
        try {
            if (strSelectByteEncoding.equalsIgnoreCase(BuildConfig.SDK_DEPENDENCY)) {
                StringBuilder sb = this.workString;
                sb.ensureCapacity(sb.length() + i3);
                for (int i8 = 0; i8 < i3; i8++) {
                    this.workString.append((char) (bArr[i8] & UnsignedBytes.MAX_VALUE));
                }
                return i4;
            }
            this.workString.append(new String(bArr, this.selectedByteEncoding));
            return i4;
        } catch (UnsupportedEncodingException unused) {
            this.failureCause = QrCode.Failure.STRING_ENCODING_UNAVAILABLE;
            return -1;
        }
    }

    private String selectByteEncoding(byte[] bArr) {
        String str = this.encodingEci;
        if (str != null) {
            return str;
        }
        String str2 = this.forceEncoding;
        if (str2 != null) {
            return str2;
        }
        if (EciEncoding.isValidUTF8(bArr)) {
            return "UTF8";
        }
        return this.defaultEncoding;
    }

    public int decodeKanji(PackedBits8 packedBits8, int i, int i2) {
        int i3 = packedBits8.read(i, i2, true);
        int i4 = i + i2;
        byte[] bArr = new byte[i3 * 2];
        int i5 = 0;
        while (i5 < i3) {
            int i6 = packedBits8.size;
            int i7 = i4 + 13;
            if (i6 < i7) {
                PrintStream printStream = this.verbose;
                if (printStream != null) {
                    printStream.printf("overflow: kanji data.size=%d\n", Integer.valueOf(i6));
                }
                this.failureCause = QrCode.Failure.MESSAGE_OVERFLOW;
                return -1;
            }
            int i8 = packedBits8.read(i4, 13, true);
            int i9 = (i8 % 192) | ((i8 / 192) << 8);
            int i10 = i9 + (i9 < 7936 ? 33088 : 49472);
            int i11 = i5 * 2;
            bArr[i11] = (byte) (i10 >> 8);
            bArr[i11 + 1] = (byte) i10;
            i5++;
            i4 = i7;
        }
        try {
            this.workString.append(new String(bArr, "Shift_JIS"));
            return i4;
        } catch (UnsupportedEncodingException unused) {
            this.failureCause = QrCode.Failure.KANJI_UNAVAILABLE;
            return -1;
        }
    }

    public static void flipBits8(byte[] bArr, int i) {
        for (int i2 = 0; i2 < i; i2++) {
            bArr[i2] = flipBits8(bArr[i2] & UnsignedBytes.MAX_VALUE);
        }
    }

    public static void flipBits8(DogArray_I8 dogArray_I8) {
        flipBits8(dogArray_I8.data, dogArray_I8.size);
    }

    public static byte flipBits8(int i) {
        int i2 = 0;
        for (int i3 = 0; i3 < 8; i3++) {
            i2 = (i2 << 1) | (i & 1);
            i >>= 1;
        }
        return (byte) i2;
    }

    public static char valueToAlphanumeric(int i) {
        if (i < 0 || i >= 45) {
            throw new RuntimeException("Alphanumeric: Value out of range. value=" + i);
        }
        return "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ $%*+-./:".charAt(i);
    }
}
