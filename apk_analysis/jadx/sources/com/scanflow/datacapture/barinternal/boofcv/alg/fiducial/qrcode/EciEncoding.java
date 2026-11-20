package com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode;

import com.google.common.primitives.UnsignedBytes;
import com.google.zxing.common.StringUtils;

/* JADX INFO: loaded from: classes.dex */
public abstract class EciEncoding {
    public static boolean isValidUTF8(byte[] bArr) {
        int i;
        int i2 = 0;
        while (i2 < bArr.length) {
            int i3 = bArr[i2] & UnsignedBytes.MAX_VALUE;
            if ((i3 >> 3) == 30) {
                i = 4;
            } else if ((i3 >> 4) == 14) {
                i = 3;
            } else if ((i3 >> 5) != 6) {
                if ((i3 >> 7) != 0) {
                    break;
                }
                i = 1;
            } else {
                i = 2;
            }
            for (int i4 = 1; i4 < i; i4++) {
                if (((bArr[i2 + i4] & UnsignedBytes.MAX_VALUE) >> 6) != 2) {
                    return false;
                }
            }
            i2 += i;
            if (i2 == bArr.length) {
                return true;
            }
        }
        return false;
    }

    public static String getEciCharacterSet(int i) {
        if (i != 170) {
            switch (i) {
                case 0:
                case 2:
                    return "Cp437";
                case 1:
                case 3:
                    return "ISO8859_1";
                case 4:
                    return "ISO8859_2";
                case 5:
                    return "ISO8859_3";
                case 6:
                    return "ISO8859_4";
                case 7:
                    return "ISO8859_5";
                case 8:
                    return "ISO8859_6";
                case 9:
                    return "ISO8859_7";
                case 10:
                    return "ISO8859_8";
                case 11:
                    return "ISO8859_9";
                case 12:
                    return "ISO8859_10";
                case 13:
                    return "ISO8859_11";
                case 14:
                    return "ISO8859_12";
                case 15:
                    return "ISO8859_13";
                case 16:
                    return "ISO8859_14";
                case 17:
                    return "ISO8859_15";
                case 18:
                    return "ISO8859_16";
                default:
                    switch (i) {
                        case 20:
                            return StringUtils.SHIFT_JIS;
                        case 21:
                            return "Cp1250";
                        case 22:
                            return "Cp1251";
                        case 23:
                            return "Cp1252";
                        case 24:
                            return "Cp1256";
                        case 25:
                            return "UnicodeBigUnmarked";
                        case 26:
                            return "UTF8";
                        case 27:
                            return "ASCII";
                        case 28:
                            return "Big5";
                        case 29:
                            return "GB18030";
                        case 30:
                            return "EUC_KR";
                        default:
                            throw new IllegalArgumentException("Unknown ECI designator " + i);
                    }
            }
        }
        return "ASCII";
    }
}
