package io.appmetrica.analytics.screenshot.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class h0 {
    public final e0 a;
    public final i0 b;
    public final f0 c;

    public h0(e0 e0Var, i0 i0Var, f0 f0Var) {
        this.a = e0Var;
        this.b = i0Var;
        this.c = f0Var;
    }

    public final e0 a() {
        return this.a;
    }

    public final f0 b() {
        return this.c;
    }

    public final i0 c() {
        return this.b;
    }

    public final String toString() {
        return "ServiceSideScreenshotConfig(apiCaptorConfig=" + this.a + ", serviceCaptorConfig=" + this.b + ", contentObserverCaptorConfig=" + this.c + ')';
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public h0(T t) {
        C0791e c0791eA = t.a();
        e0 e0Var = c0791eA != null ? new e0(c0791eA) : null;
        X xC = t.c();
        i0 i0Var = xC != null ? new i0(xC) : null;
        C0802p c0802pB = t.b();
        this(e0Var, i0Var, c0802pB != null ? new f0(c0802pB) : null);
    }
}
