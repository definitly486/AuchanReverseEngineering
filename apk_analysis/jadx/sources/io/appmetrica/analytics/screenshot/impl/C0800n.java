package io.appmetrica.analytics.screenshot.impl;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.n, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0800n {
    public final boolean a;
    public final long b;

    public C0800n(boolean z, long j) {
        this.a = z;
        this.b = j;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(C0800n.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.screenshot.impl.config.client.model.ClientSideServiceCaptorConfig");
        C0800n c0800n = (C0800n) obj;
        return this.a == c0800n.a && this.b == c0800n.b;
    }

    public final int hashCode() {
        return Long.hashCode(this.b) + (Boolean.hashCode(this.a) * 31);
    }

    public final String toString() {
        return "ClientSideServiceCaptorConfig(enabled=" + this.a + ", delaySeconds=" + this.b + ')';
    }

    public C0800n(F f) {
        this(f.b(), f.a());
    }
}
