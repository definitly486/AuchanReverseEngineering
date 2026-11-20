package com.google.common.flogger.context;

import com.google.common.flogger.FluentLogger;
import com.google.common.flogger.MetadataKey;
import com.google.common.flogger.StackSize;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes2.dex */
public final class ScopedLoggingContexts {
    private static final FluentLogger logger = FluentLogger.forEnclosingClass();

    private static boolean warnOnFailure(boolean z) {
        if (!z && !ScopedLoggingContext.getInstance().isNoOp()) {
            logger.atWarning().atMostEvery(5, TimeUnit.MINUTES).withStackTrace(StackSize.SMALL).log("***** An attempt to add metadata to the current logging context failed. *****\nCalls to static methods in 'ScopedLoggingContexts' may fail when there is no existing context available.\nTo ensure metadata is available to log statements, create a new context via 'ScopedLoggingContexts.newContext()' and add metadata to it explicitly.\n");
        }
        return z;
    }

    private ScopedLoggingContexts() {
    }

    public static ScopedLoggingContext.Builder newContext() {
        return ScopedLoggingContext.getInstance().newContext();
    }

    public static ScopedLoggingContext.Builder newContext(ScopeType scopeType) {
        return ScopedLoggingContext.getInstance().newContext(scopeType);
    }

    @CanIgnoreReturnValue
    public static boolean addTags(Tags tags) {
        return warnOnFailure(ScopedLoggingContext.getInstance().addTags(tags));
    }

    @CanIgnoreReturnValue
    public static <T> boolean addMetadata(MetadataKey<T> metadataKey, T t) {
        return warnOnFailure(ScopedLoggingContext.getInstance().addMetadata(metadataKey, t));
    }

    @CanIgnoreReturnValue
    public static boolean applyLogLevelMap(LogLevelMap logLevelMap) {
        return warnOnFailure(ScopedLoggingContext.getInstance().applyLogLevelMap(logLevelMap));
    }
}
