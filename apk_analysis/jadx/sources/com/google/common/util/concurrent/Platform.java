package com.google.common.util.concurrent;

import com.google.common.annotations.GwtCompatible;
import com.google.common.base.Preconditions;
import java.util.concurrent.TimeUnit;

/* JADX INFO: loaded from: classes2.dex */
@GwtCompatible
final class Platform {
    static boolean isInstanceOfThrowableClass(Throwable th, Class<? extends Throwable> cls) {
        return cls.isInstance(th);
    }

    static void restoreInterruptIfIsInterruptedException(Throwable th) {
        Preconditions.checkNotNull(th);
        if (th instanceof InterruptedException) {
            Thread.currentThread().interrupt();
        }
    }

    static void interruptCurrentThread() {
        Thread.currentThread().interrupt();
    }

    static void rethrowIfErrorOtherThanStackOverflow(Throwable th) {
        Preconditions.checkNotNull(th);
        if ((th instanceof Error) && !(th instanceof StackOverflowError)) {
            throw ((Error) th);
        }
    }

    static <V> V get(AbstractFuture<V> abstractFuture) {
        return abstractFuture.blockingGet();
    }

    static <V> V get(AbstractFuture<V> abstractFuture, long j, TimeUnit timeUnit) {
        return abstractFuture.blockingGet(j, timeUnit);
    }

    private Platform() {
    }
}
