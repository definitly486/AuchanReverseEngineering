package com.google.common.flogger;

import com.google.common.flogger.backend.LoggerBackend;
import com.google.common.flogger.backend.Platform;
import com.google.common.flogger.parser.DefaultPrintfMessageParser;
import com.google.common.flogger.parser.MessageParser;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public final class FluentLogger extends AbstractLogger<Api> {
    static final NoOp NO_OP = new NoOp();

    public interface Api extends LoggingApi<Api> {
    }

    private static final class NoOp extends LoggingApi.NoOp<Api> implements Api {
        private NoOp() {
        }
    }

    public static FluentLogger forEnclosingClass() {
        return new FluentLogger(Platform.getBackend(Platform.getCallerFinder().findLoggingClass(FluentLogger.class)));
    }

    FluentLogger(LoggerBackend loggerBackend) {
        super(loggerBackend);
    }

    @Override // com.google.common.flogger.AbstractLogger
    public Api at(Level level) {
        boolean zIsLoggable = isLoggable(level);
        boolean zShouldForceLogging = Platform.shouldForceLogging(getName(), level, zIsLoggable);
        return (zIsLoggable || zShouldForceLogging) ? new Context(level, zShouldForceLogging) : NO_OP;
    }

    final class Context extends LogContext<FluentLogger, Api> implements Api {
        /* JADX INFO: Access modifiers changed from: protected */
        @Override // com.google.common.flogger.LogContext
        public Api api() {
            return this;
        }

        private Context(Level level, boolean z) {
            super(level, z);
        }

        /* JADX INFO: Access modifiers changed from: protected */
        @Override // com.google.common.flogger.LogContext
        public FluentLogger getLogger() {
            return FluentLogger.this;
        }

        /* JADX INFO: Access modifiers changed from: protected */
        @Override // com.google.common.flogger.LogContext
        public Api noOp() {
            return FluentLogger.NO_OP;
        }

        @Override // com.google.common.flogger.LogContext
        protected MessageParser getMessageParser() {
            return DefaultPrintfMessageParser.getInstance();
        }
    }
}
