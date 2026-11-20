package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.we, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0698we implements Ko {
    public final String a;

    public C0698we(String str) {
        this.a = str;
    }

    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(Object obj) {
        if (obj != null) {
            return new Io(this, true, "");
        }
        return new Io(this, false, this.a + " is null.");
    }

    public final String a() {
        return this.a;
    }
}
