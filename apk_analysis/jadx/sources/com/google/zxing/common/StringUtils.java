package com.google.zxing.common;

import com.google.common.primitives.UnsignedBytes;
import com.google.zxing.DecodeHintType;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.nio.charset.UnsupportedCharsetException;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class StringUtils {
    private static final boolean ASSUME_SHIFT_JIS;
    private static final Charset EUC_JP;
    public static final String GB2312 = "GB2312";
    public static final Charset GB2312_CHARSET;
    private static final Charset PLATFORM_DEFAULT_ENCODING = Charset.defaultCharset();
    public static final String SHIFT_JIS = "SJIS";
    public static final Charset SHIFT_JIS_CHARSET = Charset.forName(SHIFT_JIS);

    static {
        Charset charsetForName;
        try {
            charsetForName = Charset.forName(GB2312);
        } catch (UnsupportedCharsetException unused) {
            charsetForName = null;
        }
        GB2312_CHARSET = charsetForName;
        Charset charsetForName2 = Charset.forName("EUC_JP");
        EUC_JP = charsetForName2;
        Charset charset = SHIFT_JIS_CHARSET;
        Charset charset2 = PLATFORM_DEFAULT_ENCODING;
        ASSUME_SHIFT_JIS = charset.equals(charset2) || charsetForName2.equals(charset2);
    }

    private StringUtils() {
    }

    public static String guessEncoding(byte[] bArr, Map<DecodeHintType, ?> map) {
        Charset charsetGuessCharset = guessCharset(bArr, map);
        if (charsetGuessCharset.equals(SHIFT_JIS_CHARSET)) {
            return SHIFT_JIS;
        }
        if (charsetGuessCharset.equals(StandardCharsets.UTF_8)) {
            return "UTF8";
        }
        if (charsetGuessCharset.equals(StandardCharsets.ISO_8859_1)) {
            return "ISO8859_1";
        }
        return charsetGuessCharset.name();
    }

    /* JADX WARN: Code duplicated, block: B:84:0x00da A[PHI: r19
      0x00da: PHI (r19v6 boolean) = (r19v5 boolean), (r19v5 boolean), (r19v5 boolean), (r19v7 boolean), (r19v7 boolean), (r19v7 boolean) binds: [B:86:0x00e0, B:88:0x00e4, B:90:0x00e8, B:78:0x00ce, B:79:0x00d0, B:81:0x00d4] A[DONT_GENERATE, DONT_INLINE]] */
    public static Charset guessCharset(byte[] bArr, Map<DecodeHintType, ?> map) {
        boolean z;
        boolean z2;
        boolean z3;
        byte b;
        byte[] bArr2 = bArr;
        if (map != null) {
            DecodeHintType decodeHintType = DecodeHintType.CHARACTER_SET;
            if (map.containsKey(decodeHintType)) {
                return Charset.forName(map.get(decodeHintType).toString());
            }
        }
        boolean z4 = true;
        int i = 0;
        if (bArr2.length > 2 && (((b = bArr2[0]) == -2 && bArr2[1] == -1) || (b == -1 && bArr2[1] == -2))) {
            return StandardCharsets.UTF_16;
        }
        int length = bArr2.length;
        boolean z5 = bArr2.length > 3 && bArr2[0] == -17 && bArr2[1] == -69 && bArr2[2] == -65;
        boolean z6 = true;
        boolean z7 = true;
        int i2 = 0;
        int i3 = 0;
        int i4 = 0;
        int i5 = 0;
        int i6 = 0;
        int i7 = 0;
        int i8 = 0;
        int i9 = 0;
        int i10 = 0;
        int i11 = 0;
        int i12 = 0;
        while (i3 < length && (z4 || z6 || z7)) {
            byte b2 = bArr2[i3];
            int i13 = b2 & UnsignedBytes.MAX_VALUE;
            if (z7) {
                if (i4 <= 0) {
                    z = z4;
                    if ((b2 & UnsignedBytes.MAX_POWER_OF_TWO) != 0) {
                        if ((b2 & 64) != 0) {
                            int i14 = i4 + 1;
                            if ((b2 & 32) == 0) {
                                i6++;
                            } else {
                                i14 = i4 + 2;
                                if ((b2 & 16) == 0) {
                                    i7++;
                                } else {
                                    i4 += 3;
                                    if ((b2 & 8) == 0) {
                                        i8++;
                                    }
                                }
                            }
                            i4 = i14;
                        }
                    }
                } else if ((b2 & UnsignedBytes.MAX_POWER_OF_TWO) == 0) {
                    z = z4;
                } else {
                    i4--;
                    z = z4;
                }
                z7 = false;
            } else {
                z = z4;
            }
            if (!z) {
                z2 = z;
            } else if (i13 <= 127 || i13 >= 160) {
                if (i13 > 159 && (i13 < 192 || i13 == 215 || i13 == 247)) {
                    i10++;
                }
                z2 = z;
            } else {
                z2 = false;
            }
            if (!z6) {
                z3 = z2;
            } else if (i5 > 0) {
                z3 = z2;
                if (i13 < 64 || i13 == 127 || i13 > 252) {
                    z6 = false;
                } else {
                    i5--;
                }
            } else {
                z3 = z2;
                if (i13 == 128 || i13 == 160 || i13 > 239) {
                    z6 = false;
                } else if (i13 <= 160 || i13 >= 224) {
                    if (i13 > 127) {
                        i5++;
                        int i15 = i11 + 1;
                        if (i15 > i) {
                            i = i15;
                            i11 = i;
                        } else {
                            i11 = i15;
                        }
                    } else {
                        i11 = 0;
                    }
                    i12 = 0;
                } else {
                    i2++;
                    int i16 = i12 + 1;
                    if (i16 > i9) {
                        i9 = i16;
                        i12 = i9;
                    } else {
                        i12 = i16;
                    }
                    i11 = 0;
                }
            }
            i3++;
            bArr2 = bArr;
            z4 = z3;
        }
        boolean z8 = z4;
        if (z7 && i4 > 0) {
            z7 = false;
        }
        if (z6 && i5 > 0) {
            z6 = false;
        }
        if (z7 && (z5 || i6 + i7 + i8 > 0)) {
            return StandardCharsets.UTF_8;
        }
        if (z6 && (ASSUME_SHIFT_JIS || i9 >= 3 || i >= 3)) {
            return SHIFT_JIS_CHARSET;
        }
        if (z8 && z6) {
            return (!(i9 == 2 && i2 == 2) && i10 * 10 < length) ? StandardCharsets.ISO_8859_1 : SHIFT_JIS_CHARSET;
        }
        if (z8) {
            return StandardCharsets.ISO_8859_1;
        }
        if (z6) {
            return SHIFT_JIS_CHARSET;
        }
        if (z7) {
            return StandardCharsets.UTF_8;
        }
        return PLATFORM_DEFAULT_ENCODING;
    }
}
