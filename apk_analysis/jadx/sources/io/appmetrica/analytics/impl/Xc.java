package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public final class Xc {
    public final C0499on a;
    public final C0499on b;
    public final D4 c;
    public final PublicLogger d;
    public final String e;

    public Xc(String str, PublicLogger publicLogger) {
        this(new D4(30), new C0499on(50, str.concat("map key"), publicLogger), new C0499on(4000, str.concat("map value"), publicLogger), str, publicLogger);
    }

    public Xc(D4 d4, C0499on c0499on, C0499on c0499on2, String str, PublicLogger publicLogger) {
        this.c = d4;
        this.a = c0499on;
        this.b = c0499on2;
        this.e = str;
        this.d = publicLogger;
    }
}
