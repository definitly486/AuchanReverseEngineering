package io.appmetrica.analytics.screenshot.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class T {
    public final C0791e a;
    public final X b;
    public final C0802p c;

    public T(C0791e c0791e, X x, C0802p c0802p) {
        this.a = c0791e;
        this.b = x;
        this.c = c0802p;
    }

    public final C0791e a() {
        return this.a;
    }

    public final C0802p b() {
        return this.c;
    }

    public final X c() {
        return this.b;
    }

    public final String toString() {
        return "ScreenshotConfig(apiCaptorConfig=" + this.a + ", serviceCaptorConfig=" + this.b + ", contentObserverCaptorConfig=" + this.c + ')';
    }

    public T() {
        this(new C0791e(), new X(), new C0802p());
    }
}
