package com.google.common.flogger.backend.system;

import com.google.common.flogger.LogContext;
import com.google.common.flogger.backend.LogData;
import com.google.common.flogger.backend.Metadata;

/* JADX INFO: loaded from: classes2.dex */
public final class SimpleLogRecord extends AbstractLogRecord {
    public static SimpleLogRecord create(LogData logData, Metadata metadata) {
        return new SimpleLogRecord(logData, metadata);
    }

    @Deprecated
    public static SimpleLogRecord create(LogData logData) {
        return create(logData, Metadata.empty());
    }

    public static SimpleLogRecord error(RuntimeException runtimeException, LogData logData, Metadata metadata) {
        return new SimpleLogRecord(runtimeException, logData, metadata);
    }

    @Deprecated
    public static SimpleLogRecord error(RuntimeException runtimeException, LogData logData) {
        return error(runtimeException, logData, Metadata.empty());
    }

    private SimpleLogRecord(LogData logData, Metadata metadata) {
        super(logData, metadata);
        setThrown((Throwable) getMetadataProcessor().getSingleValue(LogContext.Key.LOG_CAUSE));
        getMessage();
    }

    private SimpleLogRecord(RuntimeException runtimeException, LogData logData, Metadata metadata) {
        super(runtimeException, logData, metadata);
    }
}
