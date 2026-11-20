package com.google.common.flogger.util;

import java.io.Closeable;

/* JADX INFO: loaded from: classes2.dex */
public final class RecursionDepth implements Closeable {
    private static final ThreadLocal<RecursionDepth> holder = new ThreadLocal<RecursionDepth>() { // from class: com.google.common.flogger.util.RecursionDepth.1
        /* JADX INFO: Access modifiers changed from: protected */
        /* JADX WARN: Can't rename method to resolve collision */
        @Override // java.lang.ThreadLocal
        public RecursionDepth initialValue() {
            return new RecursionDepth();
        }
    };
    private int value = 0;

    private static RecursionDepth getRecursionDepth() {
        return holder.get();
    }

    public static int getCurrentDepth() {
        return getRecursionDepth().value;
    }

    public int getValue() {
        return this.value;
    }

    public static RecursionDepth enterLogStatement() {
        RecursionDepth recursionDepth = getRecursionDepth();
        int i = recursionDepth.value + 1;
        recursionDepth.value = i;
        if (i != 0) {
            return recursionDepth;
        }
        throw new AssertionError("Overflow of RecursionDepth (possible error in core library)");
    }

    @Override // java.io.Closeable, java.lang.AutoCloseable
    public void close() {
        int i = this.value;
        if (i > 0) {
            this.value = i - 1;
            return;
        }
        throw new AssertionError("Mismatched calls to RecursionDepth (possible error in core library)");
    }
}
