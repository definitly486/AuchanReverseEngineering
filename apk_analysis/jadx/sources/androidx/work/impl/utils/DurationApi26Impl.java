package androidx.work.impl.utils;

import java.time.Duration;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: DurationApi26.kt */
/* JADX INFO: loaded from: classes.dex */
public final class DurationApi26Impl {
    public static final long toMillisCompat(Duration duration) {
        Intrinsics.checkNotNullParameter(duration, "<this>");
        return duration.toMillis();
    }
}
