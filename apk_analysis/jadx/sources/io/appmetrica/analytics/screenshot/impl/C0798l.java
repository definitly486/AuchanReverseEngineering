package io.appmetrica.analytics.screenshot.impl;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.l, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0798l {
    public final boolean a;
    public final C0799m b;

    public C0798l(boolean z, C0799m c0799m) {
        this.a = z;
        this.b = c0799m;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(C0798l.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.screenshot.impl.config.client.model.ClientSideRemoteScreenshotConfig");
        C0798l c0798l = (C0798l) obj;
        return this.a == c0798l.a && Intrinsics.areEqual(this.b, c0798l.b);
    }

    public final int hashCode() {
        int iHashCode = Boolean.hashCode(this.a) * 31;
        C0799m c0799m = this.b;
        return iHashCode + (c0799m != null ? c0799m.hashCode() : 0);
    }

    public final String toString() {
        return "ClientSideRemoteScreenshotConfig(enabled=" + this.a + ", config=" + this.b + ')';
    }
}
