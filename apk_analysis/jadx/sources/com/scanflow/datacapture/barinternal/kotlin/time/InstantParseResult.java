package com.scanflow.datacapture.barinternal.kotlin.time;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: Instant.kt */
/* JADX INFO: loaded from: classes3.dex */
interface InstantParseResult {
    Instant toInstant();

    /* JADX INFO: compiled from: Instant.kt */
    public static final class Success implements InstantParseResult {
        private final long epochSeconds;
        private final int nanosecondsOfSecond;

        public Success(long j, int i) {
            this.epochSeconds = j;
            this.nanosecondsOfSecond = i;
        }

        @Override // com.scanflow.datacapture.barinternal.kotlin.time.InstantParseResult
        public Instant toInstant() {
            long j = this.epochSeconds;
            Instant.Companion companion = Instant.Companion;
            if (j < companion.getMIN$kotlin_stdlib().getEpochSeconds() || this.epochSeconds > companion.getMAX$kotlin_stdlib().getEpochSeconds()) {
                throw new InstantFormatException("The parsed date is outside the range representable by Instant (Unix epoch second " + this.epochSeconds + ')');
            }
            return companion.fromEpochSeconds(this.epochSeconds, this.nanosecondsOfSecond);
        }
    }

    /* JADX INFO: compiled from: Instant.kt */
    public static final class Failure implements InstantParseResult {
        private final String error;
        private final CharSequence input;

        public Failure(String error, CharSequence input) {
            Intrinsics.checkNotNullParameter(error, "error");
            Intrinsics.checkNotNullParameter(input, "input");
            this.error = error;
            this.input = input;
        }

        @Override // com.scanflow.datacapture.barinternal.kotlin.time.InstantParseResult
        public Instant toInstant() {
            throw new InstantFormatException(this.error + " when parsing an Instant from \"" + InstantKt.truncateForErrorMessage(this.input, 64) + '\"');
        }
    }
}
