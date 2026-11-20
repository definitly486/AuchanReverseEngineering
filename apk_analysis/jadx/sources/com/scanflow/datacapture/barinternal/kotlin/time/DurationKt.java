package com.scanflow.datacapture.barinternal.kotlin.time;

import com.google.common.flogger.parser.MessageParser;
import com.scanflow.datacapture.barinternal.kotlin.math.MathKt;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.internal.http2.Http2Connection;

/* JADX INFO: compiled from: Duration.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class DurationKt {

    /* JADX INFO: compiled from: Duration.kt */
    public static final /* synthetic */ class WhenMappings {
        public static final /* synthetic */ int[] $EnumSwitchMapping$0;

        static {
            int[] iArr = new int[DurationUnit.values().length];
            try {
                iArr[DurationUnit.MICROSECONDS.ordinal()] = 1;
            } catch (NoSuchFieldError unused) {
            }
            try {
                iArr[DurationUnit.NANOSECONDS.ordinal()] = 2;
            } catch (NoSuchFieldError unused2) {
            }
            try {
                iArr[DurationUnit.MILLISECONDS.ordinal()] = 3;
            } catch (NoSuchFieldError unused3) {
            }
            try {
                iArr[DurationUnit.SECONDS.ordinal()] = 4;
            } catch (NoSuchFieldError unused4) {
            }
            try {
                iArr[DurationUnit.MINUTES.ordinal()] = 5;
            } catch (NoSuchFieldError unused5) {
            }
            try {
                iArr[DurationUnit.HOURS.ordinal()] = 6;
            } catch (NoSuchFieldError unused6) {
            }
            try {
                iArr[DurationUnit.DAYS.ordinal()] = 7;
            } catch (NoSuchFieldError unused7) {
            }
            $EnumSwitchMapping$0 = iArr;
        }
    }

    public static final long toDuration(int i, DurationUnit unit) {
        Intrinsics.checkNotNullParameter(unit, "unit");
        if (unit.compareTo(DurationUnit.SECONDS) <= 0) {
            return durationOfNanos(DurationUnitKt__DurationUnitJvmKt.convertDurationUnitOverflow(i, unit, DurationUnit.NANOSECONDS));
        }
        return toDuration(i, unit);
    }

    public static final long toDuration(long j, DurationUnit unit) {
        Intrinsics.checkNotNullParameter(unit, "unit");
        DurationUnit durationUnit = DurationUnit.NANOSECONDS;
        long jConvertDurationUnitOverflow = DurationUnitKt__DurationUnitJvmKt.convertDurationUnitOverflow(4611686018426999999L, durationUnit, unit);
        if ((-jConvertDurationUnitOverflow) <= j && j <= jConvertDurationUnitOverflow) {
            return durationOfNanos(DurationUnitKt__DurationUnitJvmKt.convertDurationUnitOverflow(j, unit, durationUnit));
        }
        DurationUnit durationUnit2 = DurationUnit.MILLISECONDS;
        if (unit.compareTo(durationUnit2) >= 0) {
            return durationOfMillis(((long) MathKt.getSign(j)) * DurationUnitKt__DurationUnitKt.convertDurationUnitToMilliseconds(Math.abs(RangesKt.coerceAtLeast(j, -9223372036854775807L)), unit));
        }
        return durationOfMillis(RangesKt.coerceIn(DurationUnitKt__DurationUnitJvmKt.convertDurationUnit(j, unit, durationUnit2), -4611686018427387903L, 4611686018427387903L));
    }

    static /* synthetic */ long parseDuration$default(String str, boolean z, boolean z2, int i, Object obj) {
        if ((i & 4) != 0) {
            z2 = true;
        }
        return parseDuration(str, z, z2);
    }

    private static final long parseDuration(String str, boolean z, boolean z2) {
        int i;
        int i2;
        long defaultStringFormat;
        if (str.length() == 0) {
            if (z2) {
                throw new IllegalArgumentException("The string is empty");
            }
            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
        }
        char cCharAt = str.charAt(0);
        if (cCharAt != '+') {
            i = cCharAt != '-' ? 0 : 1;
            i2 = i;
        } else {
            i = 0;
            i2 = 1;
        }
        boolean z3 = i2 > 0;
        if (str.length() <= i2) {
            if (z2) {
                throw new IllegalArgumentException("No components");
            }
            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
        }
        if (str.charAt(i2) == 'P') {
            defaultStringFormat = parseIsoStringFormat(str, i2 + 1, z2);
        } else {
            if (z) {
                if (z2) {
                    throw new IllegalArgumentException("");
                }
                return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
            }
            if (StringsKt.regionMatches(str, i2, "Infinity", 0, Math.max(str.length() - i2, 8), true)) {
                defaultStringFormat = Duration.Companion.m822getINFINITEUwyO8pc();
            } else {
                defaultStringFormat = parseDefaultStringFormat(str, i2, z3, z2);
            }
        }
        return (i == 0 || Duration.m793equalsimpl0(defaultStringFormat, Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib())) ? defaultStringFormat : Duration.m818unaryMinusUwyO8pc(defaultStringFormat);
    }

    /* JADX WARN: Code duplicated, block: B:33:0x006c  */
    private static final long parseIsoStringFormat(String str, int i, boolean z) {
        int i2;
        int i3;
        char c;
        String str2;
        int i4;
        char cCharAt;
        char cCharAt2;
        int i5;
        char cCharAt3;
        String str3 = "";
        int i6 = i;
        if (i6 == str.length()) {
            if (z) {
                throw new IllegalArgumentException("");
            }
            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
        }
        DurationUnit durationUnit = null;
        long jConvertDurationUnitToMilliseconds = 0;
        long jFractionDigitsToNanos = 0;
        boolean z2 = false;
        while (i6 < str.length()) {
            char cCharAt4 = str.charAt(i6);
            if (cCharAt4 == 'T') {
                if (z2 || (i6 = i6 + 1) == str.length()) {
                    if (z) {
                        throw new IllegalArgumentException(str3);
                    }
                    return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                }
                z2 = true;
            } else {
                LongParser iso = LongParser.Companion.getIso();
                if (iso.allowSign) {
                    char cCharAt5 = str.charAt(i6);
                    if (cCharAt5 == '+') {
                        i2 = i6 + 1;
                        i3 = 1;
                    } else if (cCharAt5 != '-') {
                        i2 = i6;
                        i3 = 1;
                    } else {
                        i2 = i6 + 1;
                        i3 = -1;
                    }
                } else {
                    i2 = i6;
                    i3 = 1;
                }
                while (true) {
                    c = '0';
                    if (i2 >= str.length() || str.charAt(i2) != '0') {
                        break;
                    }
                    i2++;
                }
                long j = 0;
                while (true) {
                    if (i2 >= str.length() || c > (cCharAt2 = str.charAt(i2)) || cCharAt2 >= ':') {
                        str2 = str3;
                        i4 = i2;
                        if (i4 != str.length()) {
                            if (i4 == i6 + ((cCharAt4 == '+' || cCharAt4 == '-') ? 1 : 0)) {
                            }
                        }
                        if (z) {
                            throw new IllegalArgumentException(str2);
                        }
                        return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    }
                    int i7 = cCharAt2 - '0';
                    if (j <= iso.overflowThreshold) {
                        if (j == iso.overflowThreshold) {
                            i5 = i2;
                            if (i7 > iso.lastDigitMax) {
                            }
                        } else {
                            i5 = i2;
                        }
                        j = (j << 3) + (j << 1) + ((long) i7);
                        i2 = i5 + 1;
                        str3 = str3;
                        c = '0';
                    } else {
                        i5 = i2;
                    }
                    String str4 = str3;
                    i4 = i5;
                    while (i4 < str.length() && '0' <= (cCharAt3 = str.charAt(i4)) && cCharAt3 < ':') {
                        i4++;
                    }
                    if (i4 != str.length()) {
                        if (i4 != i6 + ((cCharAt4 == '+' || cCharAt4 == '-') ? 1 : 0)) {
                            j = iso.overflowLimit;
                            str2 = str4;
                        }
                    }
                    if (z) {
                        throw new IllegalArgumentException(str4);
                    }
                    return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    long j2 = j;
                    if (str.charAt(i4) == '.') {
                        int i8 = i4 + 1;
                        FractionalParser fractionalParser = FractionalParser.INSTANCE;
                        int iMin = Math.min(i4 + 7, str.length());
                        int i9 = i8;
                        int i10 = 0;
                        while (i9 < iMin) {
                            char cCharAt6 = str.charAt(i9);
                            if ('0' > cCharAt6 || cCharAt6 >= ':') {
                                break;
                            }
                            i10 = (i10 << 3) + (i10 << 1) + (cCharAt6 - '0');
                            i9++;
                        }
                        for (int i11 = 0; i11 < 6 - (i9 - i8); i11++) {
                            i10 = (i10 << 1) + (i10 << 3);
                        }
                        int iMin2 = Math.min(i9 + 9, str.length());
                        int i12 = i9;
                        int i13 = 0;
                        while (i12 < iMin2) {
                            char cCharAt7 = str.charAt(i12);
                            int i14 = iMin2;
                            if ('0' > cCharAt7 || cCharAt7 >= ':') {
                                break;
                            }
                            i13 = (i13 << 3) + (i13 << 1) + (cCharAt7 - '0');
                            i12++;
                            iMin2 = i14;
                        }
                        int i15 = 9 - (i12 - i9);
                        for (int i16 = 0; i16 < i15; i16++) {
                            i13 = (i13 << 1) + (i13 << 3);
                        }
                        int i17 = i12;
                        while (i17 < str.length() && '0' <= (cCharAt = str.charAt(i17)) && cCharAt < ':') {
                            i17++;
                        }
                        if (i17 == i8 || i17 == str.length() || str.charAt(i17) != 'S') {
                            if (z) {
                                throw new IllegalArgumentException(str2);
                            }
                            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                        }
                        jFractionDigitsToNanos = ((long) i3) * fractionDigitsToNanos((((long) i10) * ((long) Http2Connection.DEGRADED_PONG_TIMEOUT_NS)) + ((long) i13), DurationUnit.SECONDS);
                        i4 = i17;
                    }
                    DurationUnit durationUnitIsoDurationUnitByShortNameOrNull = isoDurationUnitByShortNameOrNull(str, i4);
                    if (durationUnitIsoDurationUnitByShortNameOrNull == null) {
                        String str5 = "Unknown duration unit short name: " + str.charAt(i4);
                        if (z) {
                            throw new IllegalArgumentException(str5);
                        }
                        return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    }
                    if (durationUnit != null && durationUnit.compareTo(durationUnitIsoDurationUnitByShortNameOrNull) <= 0) {
                        if (z) {
                            throw new IllegalArgumentException("Unexpected order of duration components");
                        }
                        return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    }
                    if (durationUnitIsoDurationUnitByShortNameOrNull == DurationUnit.DAYS) {
                        if (z2) {
                            if (z) {
                                throw new IllegalArgumentException(str2);
                            }
                            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                        }
                        jConvertDurationUnitToMilliseconds = ((long) i3) * DurationUnitKt__DurationUnitKt.convertDurationUnitToMilliseconds(j2, durationUnitIsoDurationUnitByShortNameOrNull);
                    } else {
                        if (!z2) {
                            if (z) {
                                throw new IllegalArgumentException(str2);
                            }
                            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                        }
                        long jAddMillisWithoutOverflow = addMillisWithoutOverflow(jConvertDurationUnitToMilliseconds, ((long) i3) * DurationUnitKt__DurationUnitKt.convertDurationUnitToMilliseconds(j2, durationUnitIsoDurationUnitByShortNameOrNull));
                        if (jAddMillisWithoutOverflow == 9223372036854759646L) {
                            if (z) {
                                throw new IllegalArgumentException(str2);
                            }
                            return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                        }
                        jConvertDurationUnitToMilliseconds = jAddMillisWithoutOverflow;
                    }
                    i6 = i4 + 1;
                    str3 = str2;
                    durationUnit = durationUnitIsoDurationUnitByShortNameOrNull;
                }
            }
        }
        return Duration.m814plusLRDsOJo(toDuration(jConvertDurationUnitToMilliseconds, DurationUnit.MILLISECONDS), toDuration(jFractionDigitsToNanos, DurationUnit.NANOSECONDS));
    }

    private static final long parseDefaultStringFormat(String str, int i, boolean z, boolean z2) {
        boolean z3;
        int shortNameLength;
        boolean z4;
        int i2;
        long j;
        long j2;
        long jFractionDigitsToNanos;
        int i3;
        char cCharAt;
        char cCharAt2;
        char cCharAt3;
        int length = str.length();
        boolean z5 = !z;
        if (z && str.charAt(i) == '(' && str.charAt(length - 1) == ')') {
            shortNameLength = i + 1;
            length--;
            if (shortNameLength == length) {
                if (z2) {
                    throw new IllegalArgumentException("No components");
                }
                return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
            }
            z3 = true;
        } else {
            z3 = z5;
            shortNameLength = i;
        }
        DurationUnit durationUnitDefaultDurationUnitByShortNameOrNull = null;
        long jAddMillisWithoutOverflow = 0;
        long j3 = 0;
        boolean z6 = true;
        while (shortNameLength < length) {
            if (!z6 && z3) {
                while (shortNameLength < str.length() && str.charAt(shortNameLength) == ' ') {
                    shortNameLength++;
                }
            }
            LongParser longParser = LongParser.Companion.getDefault();
            int i4 = (longParser.allowSign && ((cCharAt3 = str.charAt(shortNameLength)) == '+' || cCharAt3 == '-')) ? shortNameLength + 1 : shortNameLength;
            while (i4 < str.length() && str.charAt(i4) == '0') {
                i4++;
            }
            long j4 = 0;
            while (true) {
                if (i4 < str.length()) {
                    char cCharAt4 = str.charAt(i4);
                    z3 = z3;
                    if ('0' <= cCharAt4 && cCharAt4 < ':') {
                        int i5 = cCharAt4 - '0';
                        if (j4 <= longParser.overflowThreshold) {
                            long j5 = j3;
                            if (j4 != longParser.overflowThreshold || i5 <= longParser.lastDigitMax) {
                                j4 = ((long) i5) + (j4 << 3) + (j4 << 1);
                                i4++;
                                z3 = z3;
                                j3 = j5;
                            }
                        }
                        while (i4 < str.length() && '0' <= (cCharAt2 = str.charAt(i4)) && cCharAt2 < ':') {
                            i4++;
                        }
                        if (z2) {
                            throw new IllegalArgumentException("");
                        }
                        return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    }
                } else {
                    z3 = z3;
                }
                long j6 = j3;
                if (i4 == shortNameLength || i4 == length) {
                    if (z2) {
                        throw new IllegalArgumentException("");
                    }
                    return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                }
                boolean z7 = str.charAt(i4) == '.';
                if (z7) {
                    int i6 = i4 + 1;
                    FractionalParser fractionalParser = FractionalParser.INSTANCE;
                    int iMin = Math.min(i4 + 7, str.length());
                    int i7 = i6;
                    int i8 = 0;
                    while (true) {
                        if (i7 >= iMin) {
                            z4 = z7;
                            break;
                        }
                        char cCharAt5 = str.charAt(i7);
                        z4 = z7;
                        if ('0' > cCharAt5 || cCharAt5 >= ':') {
                            break;
                        }
                        i8 = (i8 << 3) + (i8 << 1) + (cCharAt5 - '0');
                        i7++;
                        z7 = z4;
                    }
                    for (int i9 = 0; i9 < 6 - (i7 - i6); i9++) {
                        i8 = (i8 << 1) + (i8 << 3);
                    }
                    int iMin2 = Math.min(i7 + 9, str.length());
                    int i10 = i7;
                    int i11 = 0;
                    while (true) {
                        if (i10 >= iMin2) {
                            i3 = i10;
                            break;
                        }
                        int i12 = iMin2;
                        char cCharAt6 = str.charAt(i10);
                        i3 = i10;
                        if ('0' > cCharAt6 || cCharAt6 >= ':') {
                            break;
                        }
                        i11 = (i11 << 3) + (i11 << 1) + (cCharAt6 - '0');
                        i10 = i3 + 1;
                        iMin2 = i12;
                    }
                    for (int i13 = 0; i13 < 9 - (i3 - i7); i13++) {
                        i11 = (i11 << 1) + (i11 << 3);
                    }
                    int i14 = i3;
                    while (i14 < str.length() && '0' <= (cCharAt = str.charAt(i14)) && cCharAt < ':') {
                        i14++;
                    }
                    if (i14 == i6 || i14 == length) {
                        if (z2) {
                            throw new IllegalArgumentException("");
                        }
                        return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    }
                    j = (((long) i8) * ((long) Http2Connection.DEGRADED_PONG_TIMEOUT_NS)) + ((long) i11);
                    i2 = i4;
                    i4 = i14;
                } else {
                    z4 = z7;
                    i2 = -1;
                    j = 0;
                }
                durationUnitDefaultDurationUnitByShortNameOrNull = defaultDurationUnitByShortNameOrNull(str, i4);
                if (durationUnitDefaultDurationUnitByShortNameOrNull == null) {
                    String str2 = "Unknown duration unit short name: " + str.charAt(i4);
                    if (z2) {
                        throw new IllegalArgumentException(str2);
                    }
                    return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                }
                if (durationUnitDefaultDurationUnitByShortNameOrNull != null && durationUnitDefaultDurationUnitByShortNameOrNull.compareTo(durationUnitDefaultDurationUnitByShortNameOrNull) <= 0) {
                    if (z2) {
                        throw new IllegalArgumentException("Unexpected order of duration components");
                    }
                    return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                }
                int i15 = WhenMappings.$EnumSwitchMapping$0[durationUnitDefaultDurationUnitByShortNameOrNull.ordinal()];
                if (i15 == 1) {
                    jAddMillisWithoutOverflow += j4 / 1000;
                    if (jAddMillisWithoutOverflow <= 4611686018426L) {
                        j2 = (j4 % 1000) * 1000;
                        j6 = j2;
                    }
                } else if (i15 == 2) {
                    long j7 = MessageParser.MAX_ARG_COUNT;
                    jAddMillisWithoutOverflow += j4 / j7;
                    j2 = j6 + (j4 % j7);
                    j6 = j2;
                } else {
                    jAddMillisWithoutOverflow = addMillisWithoutOverflow(jAddMillisWithoutOverflow, DurationUnitKt__DurationUnitKt.convertDurationUnitToMilliseconds(j4, durationUnitDefaultDurationUnitByShortNameOrNull));
                }
                shortNameLength = getShortNameLength(durationUnitDefaultDurationUnitByShortNameOrNull) + i4;
                if (!z4) {
                    j3 = j6;
                    z6 = false;
                } else {
                    if (shortNameLength < length) {
                        if (z2) {
                            throw new IllegalArgumentException("Fractional component must be last");
                        }
                        return Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib();
                    }
                    if (durationUnitDefaultDurationUnitByShortNameOrNull.compareTo(DurationUnit.MINUTES) >= 0 && shortNameLength - i2 > 15) {
                        jFractionDigitsToNanos = parseFractionFallback(str, i2, shortNameLength - getShortNameLength(durationUnitDefaultDurationUnitByShortNameOrNull), durationUnitDefaultDurationUnitByShortNameOrNull);
                    } else {
                        jFractionDigitsToNanos = fractionDigitsToNanos(j, durationUnitDefaultDurationUnitByShortNameOrNull);
                    }
                    z6 = false;
                    j3 = j6 + jFractionDigitsToNanos;
                }
            }
        }
        return Duration.m814plusLRDsOJo(toDuration(jAddMillisWithoutOverflow, DurationUnit.MILLISECONDS), toDuration(j3, DurationUnit.NANOSECONDS));
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long addMillisWithoutOverflow(long j, long j2) {
        if (j != 4611686018427387903L && j != -4611686018427387903L) {
            return (j2 == 4611686018427387903L || j2 == -4611686018427387903L) ? j2 : RangesKt.coerceIn(j + j2, -4611686018427387903L, 4611686018427387903L);
        }
        if ((-4611686018427387903L >= j2 || j2 >= 4611686018427387903L) && (j2 ^ j) < 0) {
            return 9223372036854759646L;
        }
        return j;
    }

    private static final long parseFractionFallback(String str, int i, int i2, DurationUnit durationUnit) {
        Intrinsics.checkNotNull(str, "null cannot be cast to non-null type java.lang.String");
        String strSubstring = str.substring(i, i2);
        Intrinsics.checkNotNullExpressionValue(strSubstring, "substring(...)");
        return MathKt.roundToLong(Double.parseDouble(strSubstring) * getFallbackFractionMultiplier(durationUnit));
    }

    private static final long fractionDigitsToNanos(long j, DurationUnit durationUnit) {
        return MathKt.roundToLong(j * getFractionMultiplier(durationUnit));
    }

    private static final DurationUnit defaultDurationUnitByShortNameOrNull(String str, int i) {
        char cCharAt = str.charAt(i);
        char cCharAt2 = i < StringsKt.getLastIndex(str) ? str.charAt(i + 1) : (char) 0;
        if (cCharAt == 'd') {
            return DurationUnit.DAYS;
        }
        if (cCharAt == 'h') {
            return DurationUnit.HOURS;
        }
        if (cCharAt == 's') {
            return DurationUnit.SECONDS;
        }
        if (cCharAt == 'u') {
            if (cCharAt2 == 's') {
                return DurationUnit.MICROSECONDS;
            }
            return null;
        }
        if (cCharAt == 'm') {
            return cCharAt2 == 's' ? DurationUnit.MILLISECONDS : DurationUnit.MINUTES;
        }
        if (cCharAt == 'n' && cCharAt2 == 's') {
            return DurationUnit.NANOSECONDS;
        }
        return null;
    }

    private static final DurationUnit isoDurationUnitByShortNameOrNull(String str, int i) {
        char cCharAt = str.charAt(i);
        if (cCharAt == 'D') {
            return DurationUnit.DAYS;
        }
        if (cCharAt == 'H') {
            return DurationUnit.HOURS;
        }
        if (cCharAt == 'M') {
            return DurationUnit.MINUTES;
        }
        if (cCharAt != 'S') {
            return null;
        }
        return DurationUnit.SECONDS;
    }

    private static final double getFractionMultiplier(DurationUnit durationUnit) {
        switch (WhenMappings.$EnumSwitchMapping$0[durationUnit.ordinal()]) {
            case 1:
                return 1.0E-12d;
            case 2:
                return 1.0E-15d;
            case 3:
                return 1.0E-9d;
            case 4:
                return 1.0E-6d;
            case 5:
                return 6.0E-5d;
            case 6:
                return 0.0036d;
            case 7:
                return 0.0864d;
            default:
                throw new IllegalStateException(("Unknown unit: " + durationUnit).toString());
        }
    }

    private static final long getFallbackFractionMultiplier(DurationUnit durationUnit) {
        int i = WhenMappings.$EnumSwitchMapping$0[durationUnit.ordinal()];
        if (i == 5) {
            return 60000000000L;
        }
        if (i == 6) {
            return 3600000000000L;
        }
        if (i == 7) {
            return 86400000000000L;
        }
        throw new IllegalStateException(("Invalid unit: " + durationUnit + " for fallback fraction multiplier").toString());
    }

    private static final int getShortNameLength(DurationUnit durationUnit) {
        int i = WhenMappings.$EnumSwitchMapping$0[durationUnit.ordinal()];
        return (i == 1 || i == 2 || i == 3) ? 2 : 1;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long nanosToMillis(long j) {
        return j / ((long) MessageParser.MAX_ARG_COUNT);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long millisToNanos(long j) {
        return j * ((long) MessageParser.MAX_ARG_COUNT);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long durationOfNanos(long j) {
        return Duration.Companion.m821fromRawValueUwyO8pc$kotlin_stdlib(j << 1);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long durationOfMillis(long j) {
        return Duration.Companion.m821fromRawValueUwyO8pc$kotlin_stdlib((j << 1) + 1);
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long durationOf(long j, int i) {
        return Duration.Companion.m821fromRawValueUwyO8pc$kotlin_stdlib((j << 1) + ((long) i));
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long durationOfNanosNormalized(long j) {
        if (-4611686018426999999L <= j && j < 4611686018427000000L) {
            return durationOfNanos(j);
        }
        return durationOfMillis(nanosToMillis(j));
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final long durationOfMillisNormalized(long j) {
        if (-4611686018426L <= j && j < 4611686018427L) {
            return durationOfNanos(millisToNanos(j));
        }
        return durationOfMillis(RangesKt.coerceIn(j, -4611686018427387903L, 4611686018427387903L));
    }
}
