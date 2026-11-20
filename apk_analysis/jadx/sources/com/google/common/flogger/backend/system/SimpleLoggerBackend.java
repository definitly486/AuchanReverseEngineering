package com.google.common.flogger.backend.system;

import com.google.common.flogger.backend.LogData;
import com.google.common.flogger.backend.Platform;
import java.util.logging.Logger;

/* JADX INFO: loaded from: classes2.dex */
public class SimpleLoggerBackend extends AbstractBackend {
    public SimpleLoggerBackend(Logger logger) {
        super(logger);
    }

    @Override // com.google.common.flogger.backend.LoggerBackend
    public void log(LogData logData) {
        log(SimpleLogRecord.create(logData, Platform.getInjectedMetadata()), logData.wasForced());
    }

    @Override // com.google.common.flogger.backend.LoggerBackend
    public void handleError(RuntimeException runtimeException, LogData logData) {
        log(SimpleLogRecord.error(runtimeException, logData, Platform.getInjectedMetadata()), logData.wasForced());
    }
}
