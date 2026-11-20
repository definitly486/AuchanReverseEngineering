package io.appmetrica.analytics.screenshot.impl;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.m, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0799m {
    public final C0796j a;
    public final C0800n b;
    public final C0797k c;

    public C0799m(C0796j c0796j, C0800n c0800n, C0797k c0797k) {
        this.a = c0796j;
        this.b = c0800n;
        this.c = c0797k;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(C0799m.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.screenshot.impl.config.client.model.ClientSideScreenshotConfig");
        C0799m c0799m = (C0799m) obj;
        return Intrinsics.areEqual(this.a, c0799m.a) && Intrinsics.areEqual(this.b, c0799m.b) && Intrinsics.areEqual(this.c, c0799m.c);
    }

    public final int hashCode() {
        C0796j c0796j = this.a;
        int iHashCode = (c0796j != null ? c0796j.hashCode() : 0) * 31;
        C0800n c0800n = this.b;
        int iHashCode2 = (iHashCode + (c0800n != null ? c0800n.hashCode() : 0)) * 31;
        C0797k c0797k = this.c;
        return iHashCode2 + (c0797k != null ? c0797k.hashCode() : 0);
    }

    public final String toString() {
        return "ClientSideScreenshotConfig(apiCaptorConfig=" + this.a + ", serviceCaptorConfig=" + this.b + ", contentObserverCaptorConfig=" + this.c + ')';
    }

    /* JADX WARN: Illegal instructions before constructor call */
    public C0799m(D d) {
        C0811z c0811zA = d.a();
        C0796j c0796j = c0811zA != null ? new C0796j(c0811zA) : null;
        F fC = d.c();
        C0800n c0800n = fC != null ? new C0800n(fC) : null;
        B b = d.b();
        this(c0796j, c0800n, b != null ? new C0797k(b) : null);
    }
}
