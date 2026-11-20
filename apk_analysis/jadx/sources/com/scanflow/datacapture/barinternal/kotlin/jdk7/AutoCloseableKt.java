package com.scanflow.datacapture.barinternal.kotlin.jdk7;

import com.scanflow.datacapture.barinternal.androidx.lifecycle.viewmodel.internal.ViewModelImpl$$ExternalSyntheticAutoCloseableDispatcher0;
import com.scanflow.datacapture.barinternal.kotlin.ExceptionsKt;

/* JADX INFO: compiled from: AutoCloseableJVM.kt */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AutoCloseableKt {
    public static final void closeFinally(AutoCloseable autoCloseable, Throwable th) throws Exception {
        if (autoCloseable != null) {
            if (th == null) {
                ViewModelImpl$$ExternalSyntheticAutoCloseableDispatcher0.m(autoCloseable);
                return;
            }
            try {
                ViewModelImpl$$ExternalSyntheticAutoCloseableDispatcher0.m(autoCloseable);
            } catch (Throwable th2) {
                ExceptionsKt.addSuppressed(th, th2);
            }
        }
    }
}
