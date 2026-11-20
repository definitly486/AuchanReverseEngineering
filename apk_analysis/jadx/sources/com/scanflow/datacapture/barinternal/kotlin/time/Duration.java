package com.scanflow.datacapture.barinternal.kotlin.time;

import androidx.core.location.LocationRequestCompat;
import com.google.common.flogger.parser.MessageParser;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import okhttp3.internal.http2.Http2Connection;

/* JADX INFO: compiled from: Duration.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Duration implements Comparable {
    private final long rawValue;
    public static final Companion Companion = new Companion(null);
    private static final long ZERO = m791constructorimpl(0);
    private static final long INFINITE = DurationKt.durationOfMillis(4611686018427387903L);
    private static final long NEG_INFINITE = DurationKt.durationOfMillis(-4611686018427387903L);
    private static final long INVALID = m791constructorimpl(9223372036854759646L);

    /* JADX INFO: renamed from: box-impl, reason: not valid java name */
    public static final /* synthetic */ Duration m789boximpl(long j) {
        return new Duration(j);
    }

    /* JADX INFO: renamed from: constructor-impl, reason: not valid java name */
    public static long m791constructorimpl(long j) {
        return j;
    }

    /* JADX INFO: renamed from: equals-impl, reason: not valid java name */
    public static boolean m792equalsimpl(long j, Object obj) {
        return (obj instanceof Duration) && j == ((Duration) obj).m820unboximpl();
    }

    /* JADX INFO: renamed from: equals-impl0, reason: not valid java name */
    public static final boolean m793equalsimpl0(long j, long j2) {
        return j == j2;
    }

    /* JADX INFO: renamed from: hashCode-impl, reason: not valid java name */
    public static int m807hashCodeimpl(long j) {
        return Long.hashCode(j);
    }

    public boolean equals(Object obj) {
        return m792equalsimpl(this.rawValue, obj);
    }

    public int hashCode() {
        return m807hashCodeimpl(this.rawValue);
    }

    /* JADX INFO: renamed from: unbox-impl, reason: not valid java name */
    public final /* synthetic */ long m820unboximpl() {
        return this.rawValue;
    }

    @Override // java.lang.Comparable
    public /* bridge */ /* synthetic */ int compareTo(Object obj) {
        return m819compareToLRDsOJo(((Duration) obj).m820unboximpl());
    }

    private /* synthetic */ Duration(long j) {
        this.rawValue = j;
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX INFO: renamed from: getValue-impl, reason: not valid java name */
    public static final long m806getValueimpl(long j) {
        return j >> 1;
    }

    /* JADX INFO: renamed from: getStorageUnit-impl, reason: not valid java name */
    private static final DurationUnit m805getStorageUnitimpl(long j) {
        return m810isInNanosimpl(j) ? DurationUnit.NANOSECONDS : DurationUnit.MILLISECONDS;
    }

    /* JADX INFO: compiled from: Duration.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        /* JADX INFO: renamed from: fromRawValue-UwyO8pc$kotlin_stdlib, reason: not valid java name */
        public final long m821fromRawValueUwyO8pc$kotlin_stdlib(long j) {
            long jM791constructorimpl = Duration.m791constructorimpl(j);
            if (DurationJvmKt.getDurationAssertionsEnabled()) {
                if (Duration.m810isInNanosimpl(jM791constructorimpl)) {
                    long jM806getValueimpl = Duration.m806getValueimpl(jM791constructorimpl);
                    if (-4611686018426999999L <= jM806getValueimpl && jM806getValueimpl < 4611686018427000000L) {
                        return jM791constructorimpl;
                    }
                    throw new AssertionError(Duration.m806getValueimpl(jM791constructorimpl) + " ns is out of nanoseconds range");
                }
                long jM806getValueimpl2 = Duration.m806getValueimpl(jM791constructorimpl);
                if (-4611686018427387903L >= jM806getValueimpl2 || jM806getValueimpl2 >= 4611686018427387903L) {
                    long jM806getValueimpl3 = Duration.m806getValueimpl(jM791constructorimpl);
                    if (jM806getValueimpl3 != 4611686018427387903L && jM806getValueimpl3 != -4611686018427387903L) {
                        throw new AssertionError(Duration.m806getValueimpl(jM791constructorimpl) + " ms is out of milliseconds range");
                    }
                }
                long jM806getValueimpl4 = Duration.m806getValueimpl(jM791constructorimpl);
                if (-4611686018426L > jM806getValueimpl4 || jM806getValueimpl4 >= 4611686018427L) {
                    return jM791constructorimpl;
                }
                throw new AssertionError(Duration.m806getValueimpl(jM791constructorimpl) + " ms is denormalized");
            }
            return jM791constructorimpl;
        }

        /* JADX INFO: renamed from: getINFINITE-UwyO8pc, reason: not valid java name */
        public final long m822getINFINITEUwyO8pc() {
            return Duration.INFINITE;
        }

        /* JADX INFO: renamed from: getINVALID-UwyO8pc$kotlin_stdlib, reason: not valid java name */
        public final long m823getINVALIDUwyO8pc$kotlin_stdlib() {
            return Duration.INVALID;
        }

        /* JADX INFO: renamed from: parseIsoString-UwyO8pc, reason: not valid java name */
        public final long m824parseIsoStringUwyO8pc(String value) {
            Intrinsics.checkNotNullParameter(value, "value");
            try {
                long duration$default = DurationKt.parseDuration$default(value, true, false, 4, null);
                if (Duration.m793equalsimpl0(duration$default, Duration.Companion.m823getINVALIDUwyO8pc$kotlin_stdlib())) {
                    throw new IllegalStateException("invariant failed");
                }
                return duration$default;
            } catch (IllegalArgumentException e) {
                throw new IllegalArgumentException("Invalid ISO duration string format: '" + value + "'.", e);
            }
        }
    }

    /* JADX INFO: renamed from: unaryMinus-UwyO8pc, reason: not valid java name */
    public static final long m818unaryMinusUwyO8pc(long j) {
        return DurationKt.durationOf(-m806getValueimpl(j), ((int) j) & 1);
    }

    /* JADX INFO: renamed from: plus-LRDsOJo, reason: not valid java name */
    public static final long m814plusLRDsOJo(long j, long j2) {
        if ((((int) j) & 1) != (((int) j2) & 1)) {
            return m809isInMillisimpl(j) ? m787addValuesMixedRangesUwyO8pc(j, m806getValueimpl(j), m806getValueimpl(j2)) : m787addValuesMixedRangesUwyO8pc(j, m806getValueimpl(j2), m806getValueimpl(j));
        }
        if (m810isInNanosimpl(j)) {
            return DurationKt.durationOfNanosNormalized(m806getValueimpl(j) + m806getValueimpl(j2));
        }
        long jAddMillisWithoutOverflow = DurationKt.addMillisWithoutOverflow(m806getValueimpl(j), m806getValueimpl(j2));
        if (jAddMillisWithoutOverflow != 9223372036854759646L) {
            return (jAddMillisWithoutOverflow == 4611686018427387903L || jAddMillisWithoutOverflow == -4611686018427387903L) ? DurationKt.durationOfMillis(jAddMillisWithoutOverflow) : DurationKt.durationOfMillisNormalized(jAddMillisWithoutOverflow);
        }
        throw new IllegalArgumentException("Summing infinite durations of different signs yields an undefined result.");
    }

    /* JADX INFO: renamed from: addValuesMixedRanges-UwyO8pc, reason: not valid java name */
    private static final long m787addValuesMixedRangesUwyO8pc(long j, long j2, long j3) {
        long jNanosToMillis = DurationKt.nanosToMillis(j3);
        long jAddMillisWithoutOverflow = DurationKt.addMillisWithoutOverflow(j2, jNanosToMillis);
        if (-4611686018426L > jAddMillisWithoutOverflow || jAddMillisWithoutOverflow >= 4611686018427L) {
            return DurationKt.durationOfMillis(jAddMillisWithoutOverflow);
        }
        return DurationKt.durationOfNanos(DurationKt.millisToNanos(jAddMillisWithoutOverflow) + (j3 - DurationKt.millisToNanos(jNanosToMillis)));
    }

    /* JADX INFO: renamed from: isNegative-impl, reason: not valid java name */
    public static final boolean m812isNegativeimpl(long j) {
        return j < 0;
    }

    /* JADX INFO: renamed from: isPositive-impl, reason: not valid java name */
    public static final boolean m813isPositiveimpl(long j) {
        return j > 0;
    }

    /* JADX INFO: renamed from: isInfinite-impl, reason: not valid java name */
    public static final boolean m811isInfiniteimpl(long j) {
        return j == INFINITE || j == NEG_INFINITE;
    }

    /* JADX INFO: renamed from: isFinite-impl, reason: not valid java name */
    public static final boolean m808isFiniteimpl(long j) {
        return !m811isInfiniteimpl(j);
    }

    /* JADX INFO: renamed from: getAbsoluteValue-UwyO8pc, reason: not valid java name */
    public static final long m794getAbsoluteValueUwyO8pc(long j) {
        return m812isNegativeimpl(j) ? m818unaryMinusUwyO8pc(j) : j;
    }

    /* JADX INFO: renamed from: compareTo-LRDsOJo, reason: not valid java name */
    public int m819compareToLRDsOJo(long j) {
        return m790compareToLRDsOJo(this.rawValue, j);
    }

    /* JADX INFO: renamed from: compareTo-LRDsOJo, reason: not valid java name */
    public static int m790compareToLRDsOJo(long j, long j2) {
        long j3 = j ^ j2;
        if (j3 < 0 || (((int) j3) & 1) == 0) {
            return Intrinsics.compare(j, j2);
        }
        int i = (((int) j) & 1) - (((int) j2) & 1);
        return m812isNegativeimpl(j) ? -i : i;
    }

    /* JADX INFO: renamed from: getHoursComponent-impl, reason: not valid java name */
    public static final int m795getHoursComponentimpl(long j) {
        if (m811isInfiniteimpl(j)) {
            return 0;
        }
        return (int) (m797getInWholeHoursimpl(j) % ((long) 24));
    }

    /* JADX INFO: renamed from: getMinutesComponent-impl, reason: not valid java name */
    public static final int m802getMinutesComponentimpl(long j) {
        if (m811isInfiniteimpl(j)) {
            return 0;
        }
        return (int) (m799getInWholeMinutesimpl(j) % ((long) 60));
    }

    /* JADX INFO: renamed from: getSecondsComponent-impl, reason: not valid java name */
    public static final int m804getSecondsComponentimpl(long j) {
        if (m811isInfiniteimpl(j)) {
            return 0;
        }
        return (int) (m801getInWholeSecondsimpl(j) % ((long) 60));
    }

    /* JADX INFO: renamed from: getNanosecondsComponent-impl, reason: not valid java name */
    public static final int m803getNanosecondsComponentimpl(long j) {
        long jM806getValueimpl;
        if (m811isInfiniteimpl(j)) {
            return 0;
        }
        if (m809isInMillisimpl(j)) {
            jM806getValueimpl = DurationKt.millisToNanos(m806getValueimpl(j) % ((long) 1000));
        } else {
            jM806getValueimpl = m806getValueimpl(j) % ((long) Http2Connection.DEGRADED_PONG_TIMEOUT_NS);
        }
        return (int) jM806getValueimpl;
    }

    /* JADX INFO: renamed from: toLong-impl, reason: not valid java name */
    public static final long m816toLongimpl(long j, DurationUnit unit) {
        Intrinsics.checkNotNullParameter(unit, "unit");
        if (j == INFINITE) {
            return LocationRequestCompat.PASSIVE_INTERVAL;
        }
        if (j == NEG_INFINITE) {
            return Long.MIN_VALUE;
        }
        return DurationUnitKt__DurationUnitJvmKt.convertDurationUnit(m806getValueimpl(j), m805getStorageUnitimpl(j), unit);
    }

    /* JADX INFO: renamed from: getInWholeDays-impl, reason: not valid java name */
    public static final long m796getInWholeDaysimpl(long j) {
        return m816toLongimpl(j, DurationUnit.DAYS);
    }

    /* JADX INFO: renamed from: getInWholeHours-impl, reason: not valid java name */
    public static final long m797getInWholeHoursimpl(long j) {
        return m816toLongimpl(j, DurationUnit.HOURS);
    }

    /* JADX INFO: renamed from: getInWholeMinutes-impl, reason: not valid java name */
    public static final long m799getInWholeMinutesimpl(long j) {
        return m816toLongimpl(j, DurationUnit.MINUTES);
    }

    /* JADX INFO: renamed from: getInWholeSeconds-impl, reason: not valid java name */
    public static final long m801getInWholeSecondsimpl(long j) {
        return m816toLongimpl(j, DurationUnit.SECONDS);
    }

    /* JADX INFO: renamed from: getInWholeMilliseconds-impl, reason: not valid java name */
    public static final long m798getInWholeMillisecondsimpl(long j) {
        return (m809isInMillisimpl(j) && m808isFiniteimpl(j)) ? m806getValueimpl(j) : m816toLongimpl(j, DurationUnit.MILLISECONDS);
    }

    /* JADX INFO: renamed from: getInWholeNanoseconds-impl, reason: not valid java name */
    public static final long m800getInWholeNanosecondsimpl(long j) {
        long jM806getValueimpl = m806getValueimpl(j);
        if (m810isInNanosimpl(j)) {
            return jM806getValueimpl;
        }
        if (jM806getValueimpl > 9223372036854L) {
            return LocationRequestCompat.PASSIVE_INTERVAL;
        }
        if (jM806getValueimpl < -9223372036854L) {
            return Long.MIN_VALUE;
        }
        return DurationKt.millisToNanos(jM806getValueimpl);
    }

    public String toString() {
        return m817toStringimpl(this.rawValue);
    }

    /* JADX INFO: renamed from: toString-impl, reason: not valid java name */
    public static String m817toStringimpl(long j) {
        if (j == 0) {
            return "0s";
        }
        if (j == INFINITE) {
            return "Infinity";
        }
        if (j == NEG_INFINITE) {
            return "-Infinity";
        }
        boolean zM812isNegativeimpl = m812isNegativeimpl(j);
        StringBuilder sb = new StringBuilder();
        if (zM812isNegativeimpl) {
            sb.append('-');
        }
        long jM794getAbsoluteValueUwyO8pc = m794getAbsoluteValueUwyO8pc(j);
        long jM796getInWholeDaysimpl = m796getInWholeDaysimpl(jM794getAbsoluteValueUwyO8pc);
        int iM795getHoursComponentimpl = m795getHoursComponentimpl(jM794getAbsoluteValueUwyO8pc);
        int iM802getMinutesComponentimpl = m802getMinutesComponentimpl(jM794getAbsoluteValueUwyO8pc);
        int iM804getSecondsComponentimpl = m804getSecondsComponentimpl(jM794getAbsoluteValueUwyO8pc);
        int iM803getNanosecondsComponentimpl = m803getNanosecondsComponentimpl(jM794getAbsoluteValueUwyO8pc);
        int i = 0;
        boolean z = jM796getInWholeDaysimpl != 0;
        boolean z2 = iM795getHoursComponentimpl != 0;
        boolean z3 = iM802getMinutesComponentimpl != 0;
        boolean z4 = (iM804getSecondsComponentimpl == 0 && iM803getNanosecondsComponentimpl == 0) ? false : true;
        if (z) {
            sb.append(jM796getInWholeDaysimpl);
            sb.append('d');
            i = 1;
        }
        if (z2 || (z && (z3 || z4))) {
            int i2 = i + 1;
            if (i > 0) {
                sb.append(' ');
            }
            sb.append(iM795getHoursComponentimpl);
            sb.append('h');
            i = i2;
        }
        if (z3 || (z4 && (z2 || z))) {
            int i3 = i + 1;
            if (i > 0) {
                sb.append(' ');
            }
            sb.append(iM802getMinutesComponentimpl);
            sb.append('m');
            i = i3;
        }
        if (z4) {
            int i4 = i + 1;
            if (i > 0) {
                sb.append(' ');
            }
            if (iM804getSecondsComponentimpl != 0 || z || z2 || z3) {
                m788appendFractionalimpl(j, sb, iM804getSecondsComponentimpl, iM803getNanosecondsComponentimpl, 9, "s", false);
            } else if (iM803getNanosecondsComponentimpl >= 1000000) {
                m788appendFractionalimpl(j, sb, iM803getNanosecondsComponentimpl / MessageParser.MAX_ARG_COUNT, iM803getNanosecondsComponentimpl % MessageParser.MAX_ARG_COUNT, 6, "ms", false);
            } else if (iM803getNanosecondsComponentimpl >= 1000) {
                m788appendFractionalimpl(j, sb, iM803getNanosecondsComponentimpl / 1000, iM803getNanosecondsComponentimpl % 1000, 3, "us", false);
            } else {
                sb.append(iM803getNanosecondsComponentimpl);
                sb.append("ns");
            }
            i = i4;
        }
        if (zM812isNegativeimpl && i > 1) {
            sb.insert(1, '(').append(')');
        }
        return sb.toString();
    }

    /* JADX INFO: renamed from: appendFractional-impl, reason: not valid java name */
    private static final void m788appendFractionalimpl(long j, StringBuilder sb, int i, int i2, int i3, String str, boolean z) {
        sb.append(i);
        if (i2 != 0) {
            sb.append('.');
            String strPadStart = StringsKt.padStart(String.valueOf(i2), i3, '0');
            int i4 = -1;
            int length = strPadStart.length() - 1;
            if (length >= 0) {
                while (true) {
                    int i5 = length - 1;
                    if (strPadStart.charAt(length) != '0') {
                        i4 = length;
                        break;
                    } else if (i5 < 0) {
                        break;
                    } else {
                        length = i5;
                    }
                }
            }
            int i6 = i4 + 1;
            if (!z && i6 < 3) {
                sb.append((CharSequence) strPadStart, 0, i6);
                Intrinsics.checkNotNullExpressionValue(sb, "append(...)");
            } else {
                sb.append((CharSequence) strPadStart, 0, ((i4 + 3) / 3) * 3);
                Intrinsics.checkNotNullExpressionValue(sb, "append(...)");
            }
        }
        sb.append(str);
    }

    /* JADX INFO: renamed from: toIsoString-impl, reason: not valid java name */
    public static final String m815toIsoStringimpl(long j) {
        StringBuilder sb = new StringBuilder();
        if (m812isNegativeimpl(j)) {
            sb.append('-');
        }
        sb.append("PT");
        long jM794getAbsoluteValueUwyO8pc = m794getAbsoluteValueUwyO8pc(j);
        long jM797getInWholeHoursimpl = m797getInWholeHoursimpl(jM794getAbsoluteValueUwyO8pc);
        int iM802getMinutesComponentimpl = m802getMinutesComponentimpl(jM794getAbsoluteValueUwyO8pc);
        int iM804getSecondsComponentimpl = m804getSecondsComponentimpl(jM794getAbsoluteValueUwyO8pc);
        int iM803getNanosecondsComponentimpl = m803getNanosecondsComponentimpl(jM794getAbsoluteValueUwyO8pc);
        long j2 = m811isInfiniteimpl(j) ? 9999999999999L : jM797getInWholeHoursimpl;
        boolean z = false;
        boolean z2 = j2 != 0;
        boolean z3 = (iM804getSecondsComponentimpl == 0 && iM803getNanosecondsComponentimpl == 0) ? false : true;
        if (iM802getMinutesComponentimpl != 0 || (z3 && z2)) {
            z = true;
        }
        if (z2) {
            sb.append(j2);
            sb.append('H');
        }
        if (z) {
            sb.append(iM802getMinutesComponentimpl);
            sb.append('M');
        }
        if (z3 || (!z2 && !z)) {
            m788appendFractionalimpl(j, sb, iM804getSecondsComponentimpl, iM803getNanosecondsComponentimpl, 9, "S", true);
        }
        return sb.toString();
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX INFO: renamed from: isInNanos-impl, reason: not valid java name */
    public static final boolean m810isInNanosimpl(long j) {
        return (((int) j) & 1) == 0;
    }

    /* JADX INFO: renamed from: isInMillis-impl, reason: not valid java name */
    private static final boolean m809isInMillisimpl(long j) {
        return (((int) j) & 1) == 1;
    }
}
