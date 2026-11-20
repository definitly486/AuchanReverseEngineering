package io.appmetrica.analytics.impl;

import okhttp3.internal.connection.RealConnection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.jl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0367jl {
    public final Po a;

    public C0367jl(Po po) {
        this.a = po;
    }

    public final long a() {
        long jOptLong;
        Po po = this.a;
        synchronized (po) {
            jOptLong = po.a.a().optLong("session_id", -1L);
        }
        long j = RealConnection.IDLE_CONNECTION_HEALTHY_NS;
        if (jOptLong >= RealConnection.IDLE_CONNECTION_HEALTHY_NS) {
            j = 1 + jOptLong;
        }
        this.a.b(j);
        return j;
    }
}
