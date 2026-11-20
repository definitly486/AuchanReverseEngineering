package io.appmetrica.analytics.screenshot.impl;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.j, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0796j {
    public final boolean a;

    public C0796j(boolean z) {
        this.a = z;
    }

    public final boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(C0796j.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.screenshot.impl.config.client.model.ClientSideApiCaptorConfig");
        return this.a == ((C0796j) obj).a;
    }

    public final int hashCode() {
        return Boolean.hashCode(this.a);
    }

    public final String toString() {
        return "ClientSideApiCaptorConfig(enabled=" + this.a + ')';
    }

    public C0796j(C0811z c0811z) {
        this(c0811z.a());
    }
}
