package io.appmetrica.analytics.impl;

import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0754yi implements Ko {
    public final Map a;

    public C0754yi(Map<String, ?> map) {
        this.a = map;
    }

    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(String str) {
        return this.a.containsKey(str) ? new Io(this, false, String.format("Failed to activate AppMetrica with provided apiKey ApiKey %s has already been used by another reporter.", str)) : new Io(this, true, "");
    }
}
