package com.google.common.flogger.context;

import com.google.common.flogger.LoggingScope;
import com.google.common.flogger.backend.Metadata;
import com.google.common.flogger.backend.Platform;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public abstract class ContextDataProvider {
    public abstract ScopedLoggingContext getContextApiSingleton();

    public LoggingScope getScope(ScopeType scopeType) {
        return null;
    }

    public boolean shouldForceLogging(String str, Level level, boolean z) {
        return false;
    }

    public static ContextDataProvider getInstance() {
        return Platform.getContextDataProvider();
    }

    public static ContextDataProvider getNoOpProvider() {
        return NoOpContextDataProvider.getNoOpInstance();
    }

    public Tags getTags() {
        return Tags.empty();
    }

    public Metadata getMetadata() {
        return Metadata.empty();
    }
}
