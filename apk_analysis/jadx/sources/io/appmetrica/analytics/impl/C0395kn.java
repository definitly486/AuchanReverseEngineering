package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.kn, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0395kn extends Pi {
    public C0395kn(Context context, String str) {
        super(context, str, "array");
    }

    @Override // io.appmetrica.analytics.impl.Pi
    public final Object a(int i) {
        return this.a.getResources().getStringArray(i);
    }

    public final String[] b(int i) {
        return this.a.getResources().getStringArray(i);
    }
}
