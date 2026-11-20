package com.google.common.flogger.backend.system;

import com.google.common.flogger.context.ContextDataProvider;
import com.google.common.flogger.context.LogLevelMap;
import com.google.common.flogger.context.ScopeType;
import com.google.common.flogger.context.ScopedLoggingContext;
import com.google.common.flogger.context.Tags;

/* JADX INFO: loaded from: classes2.dex */
@Deprecated
public abstract class LoggingContext extends ContextDataProvider {
    private static final ScopedLoggingContext NO_OP_API = new NoOpScopedLoggingContext();

    @Override // com.google.common.flogger.context.ContextDataProvider
    public ScopedLoggingContext getContextApiSingleton() {
        return NO_OP_API;
    }

    private static final class NoOpScopedLoggingContext extends ScopedLoggingContext implements ScopedLoggingContext.LoggingContextCloseable {
        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public boolean addTags(Tags tags) {
            return false;
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public boolean applyLogLevelMap(LogLevelMap logLevelMap) {
            return false;
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext.LoggingContextCloseable, java.io.Closeable, java.lang.AutoCloseable
        public void close() {
        }

        private NoOpScopedLoggingContext() {
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public ScopedLoggingContext.Builder newContext() {
            return new ScopedLoggingContext.Builder() { // from class: com.google.common.flogger.backend.system.LoggingContext.NoOpScopedLoggingContext.1
                @Override // com.google.common.flogger.context.ScopedLoggingContext.Builder
                public ScopedLoggingContext.LoggingContextCloseable install() {
                    return NoOpScopedLoggingContext.this;
                }
            };
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public ScopedLoggingContext.Builder newContext(ScopeType scopeType) {
            return newContext();
        }
    }
}
