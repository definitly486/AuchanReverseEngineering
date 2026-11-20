package com.google.common.flogger.backend.system;

import com.google.common.flogger.backend.LoggerBackend;
import java.util.logging.Logger;

/* JADX INFO: loaded from: classes2.dex */
public final class SimpleBackendFactory extends BackendFactory {
    private static final BackendFactory INSTANCE = new SimpleBackendFactory();

    public static BackendFactory getInstance() {
        return INSTANCE;
    }

    private SimpleBackendFactory() {
    }

    @Override // com.google.common.flogger.backend.system.BackendFactory
    public LoggerBackend create(String str) {
        return new SimpleLoggerBackend(Logger.getLogger(str.replace('$', '.')));
    }

    public String toString() {
        return "Default logger backend factory";
    }
}
