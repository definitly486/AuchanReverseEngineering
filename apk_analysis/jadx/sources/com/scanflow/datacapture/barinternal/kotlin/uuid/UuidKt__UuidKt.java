package com.scanflow.datacapture.barinternal.kotlin.uuid;

import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.text.HexExtensionsKt;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Uuid.kt */
/* JADX INFO: loaded from: classes3.dex */
abstract class UuidKt__UuidKt extends UuidKt__UuidJVMKt {
    public static final void formatBytesIntoCommonImpl(long j, byte[] dst, int i, int i2, int i3) {
        Intrinsics.checkNotNullParameter(dst, "dst");
        int i4 = 7 - i2;
        int i5 = 8 - i3;
        if (i5 > i4) {
            return;
        }
        while (true) {
            int i6 = HexExtensionsKt.getBYTE_TO_LOWER_CASE_HEX_DIGITS()[(int) ((j >> (i4 << 3)) & 255)];
            int i7 = i + 1;
            dst[i] = (byte) (i6 >> 8);
            i += 2;
            dst[i7] = (byte) i6;
            if (i4 == i5) {
                return;
            } else {
                i4--;
            }
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final String truncateForErrorMessage$UuidKt__UuidKt(String str, int i) {
        if (str.length() <= i) {
            return str;
        }
        StringBuilder sb = new StringBuilder();
        Intrinsics.checkNotNull(str, "null cannot be cast to non-null type java.lang.String");
        String strSubstring = str.substring(0, i);
        Intrinsics.checkNotNullExpressionValue(strSubstring, "substring(...)");
        sb.append(strSubstring);
        sb.append("...");
        return sb.toString();
    }

    public static final Void uuidThrowUnexpectedCharacterException(String inputString, String errorDescription, int i) {
        Intrinsics.checkNotNullParameter(inputString, "inputString");
        Intrinsics.checkNotNullParameter(errorDescription, "errorDescription");
        throw new IllegalArgumentException("Expected " + errorDescription + " at index " + i + ", but was '" + inputString.charAt(i) + '\'');
    }

    public static final Uuid uuidParseHexDashCommonImpl(String hexDashString) {
        Intrinsics.checkNotNullParameter(hexDashString, "hexDashString");
        long j = 0;
        for (int i = 0; i < 8; i++) {
            long j2 = j << 4;
            char cCharAt = hexDashString.charAt(i);
            if ((cCharAt >>> '\b') != 0 || HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt] < 0) {
                uuidThrowUnexpectedCharacterException(hexDashString, "a hexadecimal digit", i);
                throw new KotlinNothingValueException();
            }
            j = j2 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt];
        }
        if (hexDashString.charAt(8) != '-') {
            uuidThrowUnexpectedCharacterException(hexDashString, "'-' (hyphen)", 8);
            throw new KotlinNothingValueException();
        }
        long j3 = 0;
        for (int i2 = 9; i2 < 13; i2++) {
            long j4 = j3 << 4;
            char cCharAt2 = hexDashString.charAt(i2);
            if ((cCharAt2 >>> '\b') != 0 || HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt2] < 0) {
                uuidThrowUnexpectedCharacterException(hexDashString, "a hexadecimal digit", i2);
                throw new KotlinNothingValueException();
            }
            j3 = j4 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt2];
        }
        if (hexDashString.charAt(13) != '-') {
            uuidThrowUnexpectedCharacterException(hexDashString, "'-' (hyphen)", 13);
            throw new KotlinNothingValueException();
        }
        long j5 = 0;
        for (int i3 = 14; i3 < 18; i3++) {
            long j6 = j5 << 4;
            char cCharAt3 = hexDashString.charAt(i3);
            if ((cCharAt3 >>> '\b') != 0 || HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt3] < 0) {
                uuidThrowUnexpectedCharacterException(hexDashString, "a hexadecimal digit", i3);
                throw new KotlinNothingValueException();
            }
            j5 = j6 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt3];
        }
        if (hexDashString.charAt(18) != '-') {
            uuidThrowUnexpectedCharacterException(hexDashString, "'-' (hyphen)", 18);
            throw new KotlinNothingValueException();
        }
        long j7 = 0;
        for (int i4 = 19; i4 < 23; i4++) {
            long j8 = j7 << 4;
            char cCharAt4 = hexDashString.charAt(i4);
            if ((cCharAt4 >>> '\b') != 0 || HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt4] < 0) {
                uuidThrowUnexpectedCharacterException(hexDashString, "a hexadecimal digit", i4);
                throw new KotlinNothingValueException();
            }
            j7 = j8 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt4];
        }
        if (hexDashString.charAt(23) != '-') {
            uuidThrowUnexpectedCharacterException(hexDashString, "'-' (hyphen)", 23);
            throw new KotlinNothingValueException();
        }
        long j9 = 0;
        for (int i5 = 24; i5 < 36; i5++) {
            long j10 = j9 << 4;
            char cCharAt5 = hexDashString.charAt(i5);
            if ((cCharAt5 >>> '\b') != 0 || HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt5] < 0) {
                uuidThrowUnexpectedCharacterException(hexDashString, "a hexadecimal digit", i5);
                throw new KotlinNothingValueException();
            }
            j9 = j10 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt5];
        }
        return Uuid.Companion.fromLongs((j << 32) | (j3 << 16) | j5, (j7 << 48) | j9);
    }

    public static final Uuid uuidParseHexCommonImpl(String hexString) {
        Intrinsics.checkNotNullParameter(hexString, "hexString");
        int i = 0;
        long j = 0;
        while (true) {
            if (i < 16) {
                long j2 = j << 4;
                char cCharAt = hexString.charAt(i);
                if ((cCharAt >>> '\b') == 0 && HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt] >= 0) {
                    j = j2 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt];
                    i++;
                } else {
                    uuidThrowUnexpectedCharacterException(hexString, "a hexadecimal digit", i);
                    throw new KotlinNothingValueException();
                }
            } else {
                long j3 = 0;
                for (int i2 = 16; i2 < 32; i2++) {
                    long j4 = j3 << 4;
                    char cCharAt2 = hexString.charAt(i2);
                    if ((cCharAt2 >>> '\b') == 0 && HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt2] >= 0) {
                        j3 = j4 | HexExtensionsKt.HEX_DIGITS_TO_LONG_DECIMAL[cCharAt2];
                    } else {
                        uuidThrowUnexpectedCharacterException(hexString, "a hexadecimal digit", i2);
                        throw new KotlinNothingValueException();
                    }
                }
                return Uuid.Companion.fromLongs(j, j3);
            }
        }
    }
}
