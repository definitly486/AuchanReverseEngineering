package com.google.common.flogger;

import com.google.common.flogger.LoggingApi;
import com.google.common.flogger.backend.LogData;
import com.google.common.flogger.backend.LoggerBackend;
import com.google.common.flogger.backend.LoggingException;
import com.google.common.flogger.backend.MessageUtils;
import com.google.common.flogger.util.Checks;
import com.google.common.flogger.util.RecursionDepth;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public abstract class AbstractLogger<API extends LoggingApi<API>> {
    private static final int MAX_ALLOWED_RECURSION_DEPTH = 100;
    private final LoggerBackend backend;

    public abstract API at(Level level);

    protected AbstractLogger(LoggerBackend loggerBackend) {
        this.backend = (LoggerBackend) Checks.checkNotNull(loggerBackend, "backend");
    }

    public final API atSevere() {
        return (API) at(Level.SEVERE);
    }

    public final API atWarning() {
        return (API) at(Level.WARNING);
    }

    public final API atInfo() {
        return (API) at(Level.INFO);
    }

    public final API atConfig() {
        return (API) at(Level.CONFIG);
    }

    public final API atFine() {
        return (API) at(Level.FINE);
    }

    public final API atFiner() {
        return (API) at(Level.FINER);
    }

    public final API atFinest() {
        return (API) at(Level.FINEST);
    }

    protected String getName() {
        return this.backend.getLoggerName();
    }

    protected final boolean isLoggable(Level level) {
        return this.backend.isLoggable(level);
    }

    final LoggerBackend getBackend() {
        return this.backend;
    }

    final void write(LogData logData) {
        Checks.checkNotNull(logData, "data");
        try {
            RecursionDepth recursionDepthEnterLogStatement = RecursionDepth.enterLogStatement();
            try {
                if (recursionDepthEnterLogStatement.getValue() <= 100) {
                    this.backend.log(logData);
                } else {
                    reportError("unbounded recursion in log statement", logData);
                }
                recursionDepthEnterLogStatement.close();
            } catch (Throwable th) {
                if (recursionDepthEnterLogStatement != null) {
                    try {
                        recursionDepthEnterLogStatement.close();
                    } catch (Throwable th2) {
                        th.addSuppressed(th2);
                    }
                }
                throw th;
            }
        } catch (RuntimeException e) {
            handleErrorRobustly(e, logData);
        }
    }

    private void handleErrorRobustly(RuntimeException runtimeException, LogData logData) {
        try {
            this.backend.handleError(runtimeException, logData);
        } catch (LoggingException e) {
            throw e;
        } catch (RuntimeException e2) {
            reportError(e2.getClass().getName() + ": " + e2.getMessage(), logData);
            try {
                e2.printStackTrace(System.err);
            } catch (RuntimeException unused) {
            }
        }
    }

    private static void reportError(String str, LogData logData) {
        StringBuilder sb = new StringBuilder();
        sb.append(formatTimestampIso8601(logData));
        sb.append(": logging error [");
        MessageUtils.appendLogSite(logData.getLogSite(), sb);
        sb.append("]: ");
        sb.append(str);
        System.err.println(sb);
        System.err.flush();
    }

    private static String formatTimestampIso8601(LogData logData) {
        return new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSSZ").format(new Date(TimeUnit.NANOSECONDS.toMillis(logData.getTimestampNanos())));
    }
}
