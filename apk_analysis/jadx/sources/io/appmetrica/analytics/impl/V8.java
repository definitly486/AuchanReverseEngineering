package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.StringUtils;

/* JADX INFO: loaded from: classes3.dex */
public final class V8 implements Lo {
    public final C0149b9 a;

    public V8() {
        this(new C0149b9());
    }

    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        String str = c0304h9.b;
        return ((InterfaceC0123a9) this.a.a.a(c0304h9.o)).a(str != null ? StringUtils.getUTF8Bytes(str) : new byte[0]);
    }

    public V8(C0149b9 c0149b9) {
        this.a = c0149b9;
    }
}
