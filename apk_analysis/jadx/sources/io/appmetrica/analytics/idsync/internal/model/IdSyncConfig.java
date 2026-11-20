package io.appmetrica.analytics.idsync.internal.model;

import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class IdSyncConfig {
    private final boolean a;
    private final long b;
    private final List c;

    public IdSyncConfig(boolean z, long j, List<RequestConfig> list) {
        this.a = z;
        this.b = j;
        this.c = list;
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!Intrinsics.areEqual(IdSyncConfig.class, obj != null ? obj.getClass() : null)) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type io.appmetrica.analytics.idsync.internal.model.IdSyncConfig");
        IdSyncConfig idSyncConfig = (IdSyncConfig) obj;
        return this.a == idSyncConfig.a && this.b == idSyncConfig.b && Intrinsics.areEqual(this.c, idSyncConfig.c);
    }

    public final boolean getEnabled() {
        return this.a;
    }

    public final long getLaunchDelay() {
        return this.b;
    }

    public final List<RequestConfig> getRequests() {
        return this.c;
    }

    public int hashCode() {
        return this.c.hashCode() + ((Long.hashCode(this.b) + (Boolean.hashCode(this.a) * 31)) * 31);
    }

    public String toString() {
        return "IdSyncConfig(enabled=" + this.a + ", launchDelay=" + this.b + ", requests=" + this.c + ')';
    }
}
