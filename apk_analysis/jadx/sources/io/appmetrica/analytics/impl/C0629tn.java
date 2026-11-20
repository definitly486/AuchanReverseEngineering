package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.tn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0629tn implements Cdo {
    public final Cdo a;
    public final Object b;

    public C0629tn(Cdo cdo, Object obj) {
        this.a = cdo;
        this.b = obj;
    }

    @Override // io.appmetrica.analytics.impl.Cdo
    public final Object a(Object obj) {
        return obj != this.a.a(obj) ? this.b : obj;
    }
}
