package io.appmetrica.analytics.impl;

import java.util.HashMap;

/* JADX INFO: loaded from: classes3.dex */
public final class Ih {
    public final C0249f6 a;
    public final boolean b;
    public final int c;
    public final HashMap d;
    public final Sh e;

    public Ih(C0249f6 c0249f6, boolean z, int i, HashMap map, Sh sh) {
        this.a = c0249f6;
        this.b = z;
        this.c = i;
        this.d = map;
        this.e = sh;
    }

    public final String toString() {
        return "ReportToSend(report=" + this.a + ", serviceDataReporterType=" + this.c + ", environment=" + this.e + ", isCrashReport=" + this.b + ", trimmedFields=" + this.d + ')';
    }
}
