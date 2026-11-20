package io.appmetrica.analytics.impl;

import java.util.Collection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.te, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0620te implements Ko {
    public final String a;

    public C0620te(String str) {
        this.a = str;
    }

    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(Collection<Object> collection) {
        if (!Do.a((Collection) collection)) {
            return new Io(this, true, "");
        }
        return new Io(this, false, this.a + " is null or empty.");
    }
}
