package com.scanflow.datacapture.barinternal.kotlin.time;

import java.io.Serializable;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Instant.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class Instant implements Comparable, Serializable {
    private final long epochSeconds;
    private final int nanosecondsOfSecond;
    public static final Companion Companion = new Companion(null);
    private static final Instant MIN = new Instant(-31557014167219200L, 0);
    private static final Instant MAX = new Instant(31556889864403199L, 999999999);

    public Instant(long j, int i) {
        this.epochSeconds = j;
        this.nanosecondsOfSecond = i;
        if (-31557014167219200L > j || j >= 31556889864403200L) {
            throw new IllegalArgumentException("Instant exceeds minimum or maximum instant");
        }
    }

    public final long getEpochSeconds() {
        return this.epochSeconds;
    }

    public final int getNanosecondsOfSecond() {
        return this.nanosecondsOfSecond;
    }

    @Override // java.lang.Comparable
    public int compareTo(Instant other) {
        Intrinsics.checkNotNullParameter(other, "other");
        int iCompare = Intrinsics.compare(this.epochSeconds, other.epochSeconds);
        return iCompare != 0 ? iCompare : Intrinsics.compare(this.nanosecondsOfSecond, other.nanosecondsOfSecond);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Instant)) {
            return false;
        }
        Instant instant = (Instant) obj;
        return this.epochSeconds == instant.epochSeconds && this.nanosecondsOfSecond == instant.nanosecondsOfSecond;
    }

    public int hashCode() {
        return Long.hashCode(this.epochSeconds) + (this.nanosecondsOfSecond * 51);
    }

    public String toString() {
        return InstantKt.formatIso(this);
    }

    /* JADX INFO: compiled from: Instant.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final Instant fromEpochSeconds(long j, long j2) {
            long j3 = j2 / 1000000000;
            if ((j2 ^ 1000000000) < 0 && j3 * 1000000000 != j2) {
                j3--;
            }
            long j4 = j + j3;
            if ((j ^ j4) < 0 && (j3 ^ j) >= 0) {
                return j > 0 ? Instant.Companion.getMAX$kotlin_stdlib() : Instant.Companion.getMIN$kotlin_stdlib();
            }
            if (j4 < -31557014167219200L) {
                return getMIN$kotlin_stdlib();
            }
            if (j4 > 31556889864403199L) {
                return getMAX$kotlin_stdlib();
            }
            long j5 = j2 % 1000000000;
            return new Instant(j4, (int) (j5 + ((((j5 ^ 1000000000) & ((-j5) | j5)) >> 63) & 1000000000)));
        }

        public final Instant fromEpochSeconds(long j, int i) {
            return fromEpochSeconds(j, i);
        }

        public final Instant parse(CharSequence input) {
            Intrinsics.checkNotNullParameter(input, "input");
            return InstantKt.parseIso(input).toInstant();
        }

        public final Instant getMIN$kotlin_stdlib() {
            return Instant.MIN;
        }

        public final Instant getMAX$kotlin_stdlib() {
            return Instant.MAX;
        }
    }
}
