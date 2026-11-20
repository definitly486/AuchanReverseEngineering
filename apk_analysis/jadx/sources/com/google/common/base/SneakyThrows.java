package com.google.common.base;

import com.google.common.annotations.GwtCompatible;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.lang.Throwable;

/* JADX INFO: loaded from: classes2.dex */
@GwtCompatible
final class SneakyThrows<T extends Throwable> {
    @CanIgnoreReturnValue
    static Error sneakyThrow(Throwable th) {
        throw new SneakyThrows().throwIt(th);
    }

    private Error throwIt(Throwable th) throws Throwable {
        throw th;
    }

    private SneakyThrows() {
    }
}
