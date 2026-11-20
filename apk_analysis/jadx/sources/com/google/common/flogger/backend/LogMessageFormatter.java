package com.google.common.flogger.backend;

import com.google.errorprone.annotations.CanIgnoreReturnValue;

/* JADX INFO: loaded from: classes2.dex */
public abstract class LogMessageFormatter {
    @CanIgnoreReturnValue
    public abstract StringBuilder append(LogData logData, MetadataProcessor metadataProcessor, StringBuilder sb);

    public String format(LogData logData, MetadataProcessor metadataProcessor) {
        return append(logData, metadataProcessor, new StringBuilder()).toString();
    }
}
