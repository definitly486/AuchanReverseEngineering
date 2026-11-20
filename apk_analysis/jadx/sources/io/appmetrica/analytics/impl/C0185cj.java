package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.Revenue;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.cj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0185cj {
    public final Revenue a;
    public final C0421ln b;
    public final C0629tn c;
    public final C0629tn d;
    public final PublicLogger e;

    public C0185cj(Revenue revenue, PublicLogger publicLogger) {
        this.e = publicLogger;
        this.a = revenue;
        this.b = new C0421ln(30720, "revenue payload", publicLogger);
        this.c = new C0629tn(new C0421ln(184320, "receipt data", publicLogger), "<truncated data was not sent, exceeded the limit of 180kb>");
        this.d = new C0629tn(new C0499on(1000, "receipt signature", publicLogger), "<truncated data was not sent, exceeded the limit of 180kb>");
    }
}
