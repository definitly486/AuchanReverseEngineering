package com.google.common.flogger;

import com.google.common.flogger.backend.Metadata;
import com.google.common.flogger.util.Checks;
import java.util.concurrent.ConcurrentHashMap;

/* JADX INFO: loaded from: classes2.dex */
public abstract class LogSiteMap<V> {
    private final ConcurrentHashMap<LogSiteKey, V> concurrentMap = new ConcurrentHashMap<>();

    protected abstract V initialValue();

    protected LogSiteMap() {
    }

    boolean contains(LogSiteKey logSiteKey) {
        return this.concurrentMap.containsKey(logSiteKey);
    }

    public final V get(LogSiteKey logSiteKey, Metadata metadata) {
        V v = this.concurrentMap.get(logSiteKey);
        if (v != null) {
            return v;
        }
        V v2 = (V) Checks.checkNotNull(initialValue(), "initial map value");
        V vPutIfAbsent = this.concurrentMap.putIfAbsent(logSiteKey, v2);
        if (vPutIfAbsent != null) {
            return vPutIfAbsent;
        }
        addRemovalHook(logSiteKey, metadata);
        return v2;
    }

    private void addRemovalHook(final LogSiteKey logSiteKey, Metadata metadata) {
        int size = metadata.size();
        Runnable runnable = null;
        for (int i = 0; i < size; i++) {
            if (LogContext.Key.LOG_SITE_GROUPING_KEY.equals(metadata.getKey(i))) {
                Object value = metadata.getValue(i);
                if (value instanceof LoggingScope) {
                    if (runnable == null) {
                        runnable = new Runnable() { // from class: com.google.common.flogger.LogSiteMap.1
                            @Override // java.lang.Runnable
                            public void run() {
                                LogSiteMap.this.concurrentMap.remove(logSiteKey);
                            }
                        };
                    }
                    ((LoggingScope) value).onClose(runnable);
                }
            }
        }
    }
}
