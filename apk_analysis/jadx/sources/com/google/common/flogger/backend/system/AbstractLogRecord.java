package com.google.common.flogger.backend.system;

import com.google.common.flogger.LogSite;
import com.google.common.flogger.backend.LogData;
import com.google.common.flogger.backend.LogMessageFormatter;
import com.google.common.flogger.backend.MessageUtils;
import com.google.common.flogger.backend.Metadata;
import com.google.common.flogger.backend.MetadataProcessor;
import com.google.common.flogger.backend.SimpleMessageFormatter;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.Arrays;
import java.util.ResourceBundle;
import java.util.concurrent.TimeUnit;
import java.util.logging.Formatter;
import java.util.logging.Level;
import java.util.logging.LogRecord;

/* JADX INFO: loaded from: classes2.dex */
public abstract class AbstractLogRecord extends LogRecord {
    private final LogData data;
    private final MetadataProcessor metadata;
    private static final Formatter jdkMessageFormatter = new Formatter() { // from class: com.google.common.flogger.backend.system.AbstractLogRecord.1
        @Override // java.util.logging.Formatter
        public String format(LogRecord logRecord) {
            throw new UnsupportedOperationException();
        }
    };
    private static final Object[] NO_PARAMETERS = new Object[0];

    @Override // java.util.logging.LogRecord
    public final void setResourceBundle(ResourceBundle resourceBundle) {
    }

    @Override // java.util.logging.LogRecord
    public final void setResourceBundleName(String str) {
    }

    protected AbstractLogRecord(LogData logData, Metadata metadata) {
        super(logData.getLevel(), null);
        this.data = logData;
        this.metadata = MetadataProcessor.forScopeAndLogSite(metadata, logData.getMetadata());
        LogSite logSite = logData.getLogSite();
        setSourceClassName(logSite.getClassName());
        setSourceMethodName(logSite.getMethodName());
        setLoggerName(logData.getLoggerName());
        setMillis(TimeUnit.NANOSECONDS.toMillis(logData.getTimestampNanos()));
        super.setParameters(NO_PARAMETERS);
    }

    protected AbstractLogRecord(RuntimeException runtimeException, LogData logData, Metadata metadata) {
        this(logData, metadata);
        int iIntValue = logData.getLevel().intValue();
        Level level = Level.WARNING;
        setLevel(iIntValue >= level.intValue() ? logData.getLevel() : level);
        setThrown(runtimeException);
        StringBuilder sb = new StringBuilder("LOGGING ERROR: ");
        sb.append(runtimeException.getMessage());
        sb.append('\n');
        safeAppend(logData, sb);
        setMessage(sb.toString());
    }

    protected LogMessageFormatter getLogMessageFormatter() {
        return SimpleMessageFormatter.getDefaultFormatter();
    }

    @Override // java.util.logging.LogRecord
    public final void setParameters(Object[] objArr) {
        getMessage();
        if (objArr == null) {
            objArr = NO_PARAMETERS;
        }
        super.setParameters(objArr);
    }

    @Override // java.util.logging.LogRecord
    public final Object[] getParameters() {
        return super.getParameters();
    }

    @Override // java.util.logging.LogRecord
    public final void setMessage(String str) {
        if (str == null) {
            str = "";
        }
        super.setMessage(str);
    }

    @Override // java.util.logging.LogRecord
    public final String getMessage() {
        String message = super.getMessage();
        if (message != null) {
            return message;
        }
        String str = getLogMessageFormatter().format(this.data, this.metadata);
        super.setMessage(str);
        return str;
    }

    @CanIgnoreReturnValue
    public final StringBuilder appendFormattedMessageTo(StringBuilder sb) {
        String message = super.getMessage();
        if (message == null) {
            getLogMessageFormatter().append(this.data, this.metadata, sb);
            return sb;
        }
        if (getParameters().length == 0) {
            sb.append(message);
            return sb;
        }
        sb.append(jdkMessageFormatter.formatMessage(this));
        return sb;
    }

    public final String getFormattedMessage() {
        if (getParameters().length == 0) {
            return getMessage();
        }
        return jdkMessageFormatter.formatMessage(this);
    }

    public final LogRecord toMutableLogRecord() {
        LogRecord logRecord = new LogRecord(getLevel(), getFormattedMessage());
        logRecord.setParameters(NO_PARAMETERS);
        logRecord.setSourceClassName(getSourceClassName());
        logRecord.setSourceMethodName(getSourceMethodName());
        logRecord.setLoggerName(getLoggerName());
        logRecord.setMillis(getMillis());
        logRecord.setThrown(getThrown());
        logRecord.setThreadID(getThreadID());
        return logRecord;
    }

    public final LogData getLogData() {
        return this.data;
    }

    public final MetadataProcessor getMetadataProcessor() {
        return this.metadata;
    }

    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append(getClass().getSimpleName());
        sb.append(" {\n  message: ");
        sb.append(getMessage());
        sb.append("\n  arguments: ");
        sb.append(getParameters() != null ? Arrays.asList(getParameters()) : "<none>");
        sb.append('\n');
        safeAppend(getLogData(), sb);
        sb.append("\n}");
        return sb.toString();
    }

    private static void safeAppend(LogData logData, StringBuilder sb) {
        sb.append("  original message: ");
        if (logData.getTemplateContext() == null) {
            sb.append(MessageUtils.safeToString(logData.getLiteralArgument()));
        } else {
            sb.append(logData.getTemplateContext().getMessage());
            sb.append("\n  original arguments:");
            for (Object obj : logData.getArguments()) {
                sb.append("\n    ");
                sb.append(MessageUtils.safeToString(obj));
            }
        }
        Metadata metadata = logData.getMetadata();
        if (metadata.size() > 0) {
            sb.append("\n  metadata:");
            for (int i = 0; i < metadata.size(); i++) {
                sb.append("\n    ");
                sb.append(metadata.getKey(i).getLabel());
                sb.append(": ");
                sb.append(MessageUtils.safeToString(metadata.getValue(i)));
            }
        }
        sb.append("\n  level: ");
        sb.append(MessageUtils.safeToString(logData.getLevel()));
        sb.append("\n  timestamp (nanos): ");
        sb.append(logData.getTimestampNanos());
        sb.append("\n  class: ");
        sb.append(logData.getLogSite().getClassName());
        sb.append("\n  method: ");
        sb.append(logData.getLogSite().getMethodName());
        sb.append("\n  line number: ");
        sb.append(logData.getLogSite().getLineNumber());
    }
}
