package com.google.common.flogger;

import com.google.common.flogger.util.Checks;

/* JADX INFO: loaded from: classes2.dex */
public final class LazyArgs {
    public static <T> LazyArg<T> lazy(LazyArg<T> lazyArg) {
        return (LazyArg) Checks.checkNotNull(lazyArg, "lazy arg");
    }

    private LazyArgs() {
    }
}
