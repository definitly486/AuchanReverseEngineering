package com.google.crypto.tink.internal;

import com.google.crypto.tink.annotations.Alpha;

/* JADX INFO: loaded from: classes2.dex */
@Alpha
public interface MonitoringClient {

    public interface Logger {
        void log(int i, long j);

        void logFailure();
    }

    Logger createLogger(KeysetHandleInterface keysetHandleInterface, MonitoringAnnotations monitoringAnnotations, String str, String str2);
}
