package io.appmetrica.analytics.idsync.internal.model;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class Preconditions {
    private final NetworkType a;

    public Preconditions(NetworkType networkType) {
        this.a = networkType;
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(Preconditions.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.idsync.internal.model.Preconditions");
        return this.a == ((Preconditions) obj).a;
    }

    public final NetworkType getNetworkType() {
        return this.a;
    }

    public int hashCode() {
        return this.a.hashCode();
    }

    public String toString() {
        return "Preconditions(networkType=" + this.a + ')';
    }
}
