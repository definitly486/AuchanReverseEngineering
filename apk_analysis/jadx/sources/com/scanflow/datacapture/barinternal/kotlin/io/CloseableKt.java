package com.scanflow.datacapture.barinternal.kotlin.io;

import java.io.Closeable;
import java.io.IOException;

/* JADX INFO: compiled from: Closeable.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class CloseableKt {
    public static final void closeFinally(Closeable closeable, Throwable th) throws IOException {
        if (closeable != null) {
            if (th == null) {
                closeable.close();
                return;
            }
            try {
                closeable.close();
            } catch (Throwable th2) {
                com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt.addSuppressed(th, th2);
            }
        }
    }
}
