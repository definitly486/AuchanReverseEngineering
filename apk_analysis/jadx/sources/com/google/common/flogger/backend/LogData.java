package com.google.common.flogger.backend;

import com.google.common.flogger.LogSite;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public interface LogData {
    Object[] getArguments();

    Level getLevel();

    Object getLiteralArgument();

    LogSite getLogSite();

    String getLoggerName();

    Metadata getMetadata();

    TemplateContext getTemplateContext();

    @Deprecated
    long getTimestampMicros();

    long getTimestampNanos();

    boolean wasForced();
}
