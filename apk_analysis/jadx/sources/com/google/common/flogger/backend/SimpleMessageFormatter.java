package com.google.common.flogger.backend;

import com.google.common.flogger.LogContext;
import com.google.common.flogger.MetadataKey;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.Collections;
import java.util.HashSet;
import java.util.Set;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public final class SimpleMessageFormatter {
    private static final LogMessageFormatter DEFAULT_FORMATTER;
    private static final Set<MetadataKey<?>> DEFAULT_KEYS_TO_IGNORE;

    @Deprecated
    public interface SimpleLogHandler {
        void handleFormattedLogMessage(Level level, String str, Throwable th);
    }

    static {
        Set<MetadataKey<?>> setSingleton = Collections.singleton(LogContext.Key.LOG_CAUSE);
        DEFAULT_KEYS_TO_IGNORE = setSingleton;
        DEFAULT_FORMATTER = newFormatter(setSingleton);
    }

    public static LogMessageFormatter getDefaultFormatter() {
        return DEFAULT_FORMATTER;
    }

    public static LogMessageFormatter getSimpleFormatterIgnoring(MetadataKey<?>... metadataKeyArr) {
        if (metadataKeyArr.length == 0) {
            return getDefaultFormatter();
        }
        HashSet hashSet = new HashSet(DEFAULT_KEYS_TO_IGNORE);
        Collections.addAll(hashSet, metadataKeyArr);
        return newFormatter(hashSet);
    }

    @CanIgnoreReturnValue
    public static StringBuilder appendContext(MetadataProcessor metadataProcessor, MetadataHandler<MetadataKey.KeyValueHandler> metadataHandler, StringBuilder sb) {
        KeyValueFormatter keyValueFormatter = new KeyValueFormatter("[CONTEXT ", " ]", sb);
        metadataProcessor.process(metadataHandler, keyValueFormatter);
        keyValueFormatter.done();
        return sb;
    }

    public static String getLiteralLogMessage(LogData logData) {
        return MessageUtils.safeToString(logData.getLiteralArgument());
    }

    public static boolean mustBeFormatted(LogData logData, MetadataProcessor metadataProcessor, Set<MetadataKey<?>> set) {
        return (logData.getTemplateContext() == null && metadataProcessor.keyCount() <= set.size() && set.containsAll(metadataProcessor.keySet())) ? false : true;
    }

    private static LogMessageFormatter newFormatter(Set<MetadataKey<?>> set) {
        return new LogMessageFormatter(set) { // from class: com.google.common.flogger.backend.SimpleMessageFormatter.1
            private final MetadataHandler<MetadataKey.KeyValueHandler> handler;
            final /* synthetic */ Set val$keysToIgnore;

            {
                this.val$keysToIgnore = set;
                this.handler = MetadataKeyValueHandlers.getDefaultHandler(set);
            }

            @Override // com.google.common.flogger.backend.LogMessageFormatter
            public StringBuilder append(LogData logData, MetadataProcessor metadataProcessor, StringBuilder sb) {
                BaseMessageFormatter.appendFormattedMessage(logData, sb);
                return SimpleMessageFormatter.appendContext(metadataProcessor, this.handler, sb);
            }

            @Override // com.google.common.flogger.backend.LogMessageFormatter
            public String format(LogData logData, MetadataProcessor metadataProcessor) {
                if (SimpleMessageFormatter.mustBeFormatted(logData, metadataProcessor, this.val$keysToIgnore)) {
                    return append(logData, metadataProcessor, new StringBuilder()).toString();
                }
                return SimpleMessageFormatter.getLiteralLogMessage(logData);
            }
        };
    }

    @Deprecated
    public static void format(LogData logData, SimpleLogHandler simpleLogHandler) {
        MetadataProcessor metadataProcessorForScopeAndLogSite = MetadataProcessor.forScopeAndLogSite(Metadata.empty(), logData.getMetadata());
        simpleLogHandler.handleFormattedLogMessage(logData.getLevel(), getDefaultFormatter().format(logData, metadataProcessorForScopeAndLogSite), (Throwable) metadataProcessorForScopeAndLogSite.getSingleValue(LogContext.Key.LOG_CAUSE));
    }

    private SimpleMessageFormatter() {
    }
}
