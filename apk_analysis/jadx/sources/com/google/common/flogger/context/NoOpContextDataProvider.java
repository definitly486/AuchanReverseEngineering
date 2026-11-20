package com.google.common.flogger.context;

import com.google.common.flogger.FluentLogger;
import com.google.common.flogger.MetadataKey;
import com.google.common.flogger.StackSize;
import java.util.concurrent.atomic.AtomicBoolean;

/* JADX INFO: loaded from: classes2.dex */
final class NoOpContextDataProvider extends ContextDataProvider {
    private static final ContextDataProvider NO_OP_INSTANCE = new NoOpContextDataProvider();
    private final ScopedLoggingContext noOpContext = new NoOpScopedLoggingContext();

    NoOpContextDataProvider() {
    }

    static final ContextDataProvider getNoOpInstance() {
        return NO_OP_INSTANCE;
    }

    private static final class NoOpScopedLoggingContext extends ScopedLoggingContext implements ScopedLoggingContext.LoggingContextCloseable {
        private final AtomicBoolean haveWarned;

        @Override // com.google.common.flogger.context.ScopedLoggingContext.LoggingContextCloseable, java.io.Closeable, java.lang.AutoCloseable
        public void close() {
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        boolean isNoOp() {
            return true;
        }

        private NoOpScopedLoggingContext() {
            this.haveWarned = new AtomicBoolean();
        }

        private static final class LazyLogger {
            private static final FluentLogger logger = FluentLogger.forEnclosingClass();

            private LazyLogger() {
            }
        }

        /* JADX INFO: Access modifiers changed from: private */
        public void logWarningOnceOnly() {
            if (this.haveWarned.compareAndSet(false, true)) {
                LazyLogger.logger.atWarning().withStackTrace(StackSize.SMALL).log("Scoped logging contexts are disabled; no context data provider was installed.\nTo enable scoped logging contexts in your application, see the site-specific Platform class used to configure logging behaviour.\nDefault Platform: com.google.common.flogger.backend.system.DefaultPlatform");
            }
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public ScopedLoggingContext.Builder newContext() {
            return new ScopedLoggingContext.Builder() { // from class: com.google.common.flogger.context.NoOpContextDataProvider.NoOpScopedLoggingContext.1
                @Override // com.google.common.flogger.context.ScopedLoggingContext.Builder
                public ScopedLoggingContext.LoggingContextCloseable install() {
                    NoOpScopedLoggingContext.this.logWarningOnceOnly();
                    return NoOpScopedLoggingContext.this;
                }
            };
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public ScopedLoggingContext.Builder newContext(ScopeType scopeType) {
            return newContext();
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public boolean addTags(Tags tags) {
            logWarningOnceOnly();
            return super.addTags(tags);
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public <T> boolean addMetadata(MetadataKey<T> metadataKey, T t) {
            logWarningOnceOnly();
            return super.addMetadata(metadataKey, t);
        }

        @Override // com.google.common.flogger.context.ScopedLoggingContext
        public boolean applyLogLevelMap(LogLevelMap logLevelMap) {
            logWarningOnceOnly();
            return super.applyLogLevelMap(logLevelMap);
        }
    }

    @Override // com.google.common.flogger.context.ContextDataProvider
    public ScopedLoggingContext getContextApiSingleton() {
        return this.noOpContext;
    }

    public String toString() {
        return "No-op Provider";
    }
}
