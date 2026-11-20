package com.google.common.flogger.context;

import com.google.common.flogger.LoggingScope;
import com.google.common.flogger.MetadataKey;
import com.google.common.flogger.util.Checks;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import com.google.errorprone.annotations.MustBeClosed;
import java.io.Closeable;
import java.util.concurrent.Callable;

/* JADX INFO: loaded from: classes2.dex */
public abstract class ScopedLoggingContext {

    public interface LoggingContextCloseable extends Closeable {
        @Override // java.io.Closeable, java.lang.AutoCloseable
        void close();
    }

    boolean isNoOp() {
        return false;
    }

    public abstract Builder newContext();

    public abstract Builder newContext(ScopeType scopeType);

    public static final class ScopeList {
        private final ScopeType key;
        private final ScopeList next;
        private final LoggingScope scope;

        public static ScopeList addScope(ScopeList scopeList, ScopeType scopeType) {
            return (scopeType == null || lookup(scopeList, scopeType) != null) ? scopeList : new ScopeList(scopeType, scopeType.newScope(), scopeList);
        }

        public static LoggingScope lookup(ScopeList scopeList, ScopeType scopeType) {
            while (scopeList != null) {
                if (scopeType.equals(scopeList.key)) {
                    return scopeList.scope;
                }
                scopeList = scopeList.next;
            }
            return null;
        }

        public ScopeList(ScopeType scopeType, LoggingScope loggingScope, ScopeList scopeList) {
            this.key = (ScopeType) Checks.checkNotNull(scopeType, "scope type");
            this.scope = (LoggingScope) Checks.checkNotNull(loggingScope, "scope");
            this.next = scopeList;
        }
    }

    public static abstract class Builder {
        private Tags tags = null;
        private ContextMetadata.Builder metadata = null;
        private LogLevelMap logLevelMap = null;
        private boolean hasLogLevelMap = false;

        @MustBeClosed
        public abstract LoggingContextCloseable install();

        protected Builder() {
        }

        @CanIgnoreReturnValue
        public final Builder withTags(Tags tags) {
            Checks.checkState(this.tags == null, "tags already set");
            Checks.checkNotNull(tags, "tags");
            this.tags = tags;
            return this;
        }

        @CanIgnoreReturnValue
        public final <T> Builder withMetadata(MetadataKey<T> metadataKey, T t) {
            if (t == null) {
                return this;
            }
            if (this.metadata == null) {
                this.metadata = ContextMetadata.builder();
            }
            this.metadata.add(metadataKey, t);
            return this;
        }

        @CanIgnoreReturnValue
        public final Builder withLogLevelMap(LogLevelMap logLevelMap) {
            Checks.checkState(!this.hasLogLevelMap, "log level map already set");
            this.hasLogLevelMap = true;
            this.logLevelMap = logLevelMap;
            return this;
        }

        public final Runnable wrap(final Runnable runnable) {
            return new Runnable() { // from class: com.google.common.flogger.context.ScopedLoggingContext.Builder.1
                @Override // java.lang.Runnable
                public void run() {
                    LoggingContextCloseable loggingContextCloseableInstall = Builder.this.install();
                    try {
                        runnable.run();
                        boolean z = false;
                    } finally {
                        ScopedLoggingContext.closeAndMaybePropagateError(loggingContextCloseableInstall, true);
                    }
                }
            };
        }

        public final <R> Callable<R> wrap(final Callable<R> callable) {
            return new Callable<R>() { // from class: com.google.common.flogger.context.ScopedLoggingContext.Builder.2
                @Override // java.util.concurrent.Callable
                public R call() {
                    LoggingContextCloseable loggingContextCloseableInstall = Builder.this.install();
                    try {
                        boolean z = false;
                        return (R) callable.call();
                    } finally {
                        ScopedLoggingContext.closeAndMaybePropagateError(loggingContextCloseableInstall, true);
                    }
                }
            };
        }

        public final void run(Runnable runnable) {
            wrap(runnable).run();
        }

        @CanIgnoreReturnValue
        public final <R> R call(Callable<R> callable) {
            return wrap(callable).call();
        }

        @CanIgnoreReturnValue
        public final <R> R callUnchecked(Callable<R> callable) {
            try {
                return (R) call(callable);
            } catch (RuntimeException e) {
                throw e;
            } catch (Exception e2) {
                throw new RuntimeException("checked exception caught during context call", e2);
            }
        }

        protected final Tags getTags() {
            return this.tags;
        }

        protected final ContextMetadata getMetadata() {
            ContextMetadata.Builder builder = this.metadata;
            if (builder != null) {
                return builder.build();
            }
            return null;
        }

        protected final LogLevelMap getLogLevelMap() {
            return this.logLevelMap;
        }
    }

    public static ScopedLoggingContext getInstance() {
        return ContextDataProvider.getInstance().getContextApiSingleton();
    }

    protected ScopedLoggingContext() {
    }

    @Deprecated
    public Builder newScope() {
        return newContext();
    }

    @CanIgnoreReturnValue
    public boolean addTags(Tags tags) {
        Checks.checkNotNull(tags, "tags");
        return false;
    }

    @CanIgnoreReturnValue
    public <T> boolean addMetadata(MetadataKey<T> metadataKey, T t) {
        Checks.checkNotNull(metadataKey, "key");
        Checks.checkNotNull(t, "value");
        return false;
    }

    @CanIgnoreReturnValue
    public boolean applyLogLevelMap(LogLevelMap logLevelMap) {
        Checks.checkNotNull(logLevelMap, "log level map");
        return false;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static void closeAndMaybePropagateError(LoggingContextCloseable loggingContextCloseable, boolean z) {
        try {
            loggingContextCloseable.close();
        } catch (RuntimeException e) {
            if (z) {
                return;
            }
            if (e instanceof InvalidLoggingContextStateException) {
                throw ((InvalidLoggingContextStateException) e);
            }
            throw new InvalidLoggingContextStateException("invalid logging context state", e);
        }
    }

    public static final class InvalidLoggingContextStateException extends IllegalStateException {
        public InvalidLoggingContextStateException(String str, Throwable th) {
            super(str, th);
        }

        public InvalidLoggingContextStateException(String str) {
            super(str);
        }
    }
}
