package com.google.common.flogger.backend;

import com.google.common.flogger.parser.ParseException;
import com.google.errorprone.annotations.CanIgnoreReturnValue;

/* JADX INFO: loaded from: classes2.dex */
public final class FormatOptions {
    public static final int ALL_FLAGS = 255;
    private static final FormatOptions DEFAULT;
    private static final long ENCODED_FLAG_INDICES;
    private static final String FLAG_CHARS_ORDERED = " #(+,-0";
    public static final int FLAG_LEFT_ALIGN = 32;
    public static final int FLAG_PREFIX_PLUS_FOR_POSITIVE_VALUES = 8;
    public static final int FLAG_PREFIX_SPACE_FOR_POSITIVE_VALUES = 1;
    public static final int FLAG_SHOW_ALT_FORM = 2;
    public static final int FLAG_SHOW_GROUPING = 16;
    public static final int FLAG_SHOW_LEADING_ZEROS = 64;
    public static final int FLAG_UPPER_CASE = 128;
    public static final int FLAG_USE_PARENS_FOR_NEGATIVE_VALUES = 4;
    private static final int MAX_ALLOWED_PRECISION = 999999;
    private static final int MAX_ALLOWED_WIDTH = 999999;
    private static final int MAX_FLAG_VALUE = 48;
    private static final int MIN_FLAG_VALUE = 32;
    public static final int UNSET = -1;
    private final int flags;
    private final int precision;
    private final int width;

    static boolean checkFlagConsistency(int i, boolean z) {
        int i2;
        if ((i & 9) == 9 || (i2 = i & 96) == 96) {
            return false;
        }
        return i2 == 0 || z;
    }

    static {
        long jCharAt = 0;
        for (int i = 0; i < 7; i++) {
            jCharAt |= (((long) i) + 1) << ((int) (((long) (FLAG_CHARS_ORDERED.charAt(i) - ' ')) * 3));
        }
        ENCODED_FLAG_INDICES = jCharAt;
        DEFAULT = new FormatOptions(0, -1, -1);
    }

    private static int indexOfFlagCharacter(char c) {
        return ((int) ((ENCODED_FLAG_INDICES >>> ((c - ' ') * 3)) & 7)) - 1;
    }

    public static FormatOptions getDefault() {
        return DEFAULT;
    }

    public static FormatOptions of(int i, int i2, int i3) {
        if (!checkFlagConsistency(i, i2 != -1)) {
            throw new IllegalArgumentException("invalid flags: 0x" + Integer.toHexString(i));
        }
        if ((i2 < 1 || i2 > 999999) && i2 != -1) {
            throw new IllegalArgumentException("invalid width: " + i2);
        }
        if ((i3 < 0 || i3 > 999999) && i3 != -1) {
            throw new IllegalArgumentException("invalid precision: " + i3);
        }
        return new FormatOptions(i, i2, i3);
    }

    public static FormatOptions parse(String str, int i, int i2, boolean z) {
        if (i == i2 && !z) {
            return DEFAULT;
        }
        int i3 = z ? 128 : 0;
        while (i != i2) {
            int i4 = i + 1;
            char cCharAt = str.charAt(i);
            if (cCharAt < ' ' || cCharAt > '0') {
                if (cCharAt > '9') {
                    throw ParseException.atPosition("invalid flag", str, i);
                }
                int i5 = cCharAt - '0';
                while (i4 != i2) {
                    int i6 = i4 + 1;
                    char cCharAt2 = str.charAt(i4);
                    if (cCharAt2 == '.') {
                        return new FormatOptions(i3, i5, parsePrecision(str, i6, i2));
                    }
                    char c = (char) (cCharAt2 - '0');
                    if (c >= '\n') {
                        throw ParseException.atPosition("invalid width character", str, i4);
                    }
                    i5 = (i5 * 10) + c;
                    if (i5 > 999999) {
                        throw ParseException.withBounds("width too large", str, i, i2);
                    }
                    i4 = i6;
                }
                return new FormatOptions(i3, i5, -1);
            }
            int iIndexOfFlagCharacter = indexOfFlagCharacter(cCharAt);
            if (iIndexOfFlagCharacter < 0) {
                if (cCharAt == '.') {
                    return new FormatOptions(i3, -1, parsePrecision(str, i4, i2));
                }
                throw ParseException.atPosition("invalid flag", str, i);
            }
            int i7 = 1 << iIndexOfFlagCharacter;
            if ((i3 & i7) != 0) {
                throw ParseException.atPosition("repeated flag", str, i);
            }
            i3 |= i7;
            i = i4;
        }
        return new FormatOptions(i3, -1, -1);
    }

    private static int parsePrecision(String str, int i, int i2) {
        if (i == i2) {
            throw ParseException.atPosition("missing precision", str, i - 1);
        }
        int i3 = 0;
        for (int i4 = i; i4 < i2; i4++) {
            char cCharAt = (char) (str.charAt(i4) - '0');
            if (cCharAt >= '\n') {
                throw ParseException.atPosition("invalid precision character", str, i4);
            }
            i3 = (i3 * 10) + cCharAt;
            if (i3 > 999999) {
                throw ParseException.withBounds("precision too large", str, i, i2);
            }
        }
        if (i3 != 0 || i2 == i + 1) {
            return i3;
        }
        throw ParseException.withBounds("invalid precision", str, i, i2);
    }

    static int parseValidFlags(String str, boolean z) {
        int i = z ? 128 : 0;
        for (int i2 = 0; i2 < str.length(); i2++) {
            int iIndexOfFlagCharacter = indexOfFlagCharacter(str.charAt(i2));
            if (iIndexOfFlagCharacter < 0) {
                throw new IllegalArgumentException("invalid flags: " + str);
            }
            i |= 1 << iIndexOfFlagCharacter;
        }
        return i;
    }

    private FormatOptions(int i, int i2, int i3) {
        this.flags = i;
        this.width = i2;
        this.precision = i3;
    }

    public FormatOptions filter(int i, boolean z, boolean z2) {
        if (!isDefault()) {
            int i2 = this.flags;
            int i3 = i & i2;
            int i4 = z ? this.width : -1;
            int i5 = z2 ? this.precision : -1;
            if (i3 == 0 && i4 == -1 && i5 == -1) {
                return DEFAULT;
            }
            if (i3 != i2 || i4 != this.width || i5 != this.precision) {
                return new FormatOptions(i3, i4, i5);
            }
        }
        return this;
    }

    public boolean isDefault() {
        return this == getDefault();
    }

    public int getWidth() {
        return this.width;
    }

    public int getPrecision() {
        return this.precision;
    }

    public boolean validate(int i, boolean z) {
        if (isDefault()) {
            return true;
        }
        int i2 = this.flags;
        if (((~i) & i2) != 0) {
            return false;
        }
        if (z || this.precision == -1) {
            return checkFlagConsistency(i2, getWidth() != -1);
        }
        return false;
    }

    public boolean areValidFor(FormatChar formatChar) {
        return validate(formatChar.getAllowedFlags(), formatChar.getType().supportsPrecision());
    }

    public int getFlags() {
        return this.flags;
    }

    public boolean shouldLeftAlign() {
        return (this.flags & 32) != 0;
    }

    public boolean shouldShowAltForm() {
        return (this.flags & 2) != 0;
    }

    public boolean shouldShowLeadingZeros() {
        return (this.flags & 64) != 0;
    }

    public boolean shouldPrefixPlusForPositiveValues() {
        return (this.flags & 8) != 0;
    }

    public boolean shouldPrefixSpaceForPositiveValues() {
        return (this.flags & 1) != 0;
    }

    public boolean shouldShowGrouping() {
        return (this.flags & 16) != 0;
    }

    public boolean shouldUpperCase() {
        return (this.flags & 128) != 0;
    }

    @CanIgnoreReturnValue
    public StringBuilder appendPrintfOptions(StringBuilder sb) {
        if (!isDefault()) {
            int i = this.flags & (-129);
            int i2 = 0;
            while (true) {
                int i3 = 1 << i2;
                if (i3 > i) {
                    break;
                }
                if ((i3 & i) != 0) {
                    sb.append(FLAG_CHARS_ORDERED.charAt(i2));
                }
                i2++;
            }
            int i4 = this.width;
            if (i4 != -1) {
                sb.append(i4);
            }
            if (this.precision != -1) {
                sb.append('.');
                sb.append(this.precision);
            }
        }
        return sb;
    }

    public boolean equals(Object obj) {
        if (obj == this) {
            return true;
        }
        if (obj instanceof FormatOptions) {
            FormatOptions formatOptions = (FormatOptions) obj;
            if (formatOptions.flags == this.flags && formatOptions.width == this.width && formatOptions.precision == this.precision) {
                return true;
            }
        }
        return false;
    }

    public int hashCode() {
        return (((this.flags * 31) + this.width) * 31) + this.precision;
    }
}
