package androidx.work;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: DelegatingWorkerFactory.kt */
/* JADX INFO: loaded from: classes.dex */
public final class DelegatingWorkerFactoryKt {
    private static final String TAG;

    static {
        String strTagWithPrefix = Logger.tagWithPrefix("DelegatingWkrFctry");
        Intrinsics.checkNotNullExpressionValue(strTagWithPrefix, "tagWithPrefix(\"DelegatingWkrFctry\")");
        TAG = strTagWithPrefix;
    }
}
