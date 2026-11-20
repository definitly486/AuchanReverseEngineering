package com.google.common.hash;

import com.google.common.annotations.GwtIncompatible;
import java.nio.Buffer;

/* JADX INFO: loaded from: classes2.dex */
@GwtIncompatible
final class Java8Compatibility {
    static void clear(Buffer buffer) {
        buffer.clear();
    }

    static void flip(Buffer buffer) {
        buffer.flip();
    }

    static void limit(Buffer buffer, int i) {
        buffer.limit(i);
    }

    static void position(Buffer buffer, int i) {
        buffer.position(i);
    }

    private Java8Compatibility() {
    }
}
