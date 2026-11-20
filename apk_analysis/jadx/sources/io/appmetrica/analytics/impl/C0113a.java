package io.appmetrica.analytics.impl;

import android.content.Context;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0113a {
    public final Context a;

    public C0113a(Context context) {
        this.a = context;
    }

    public final byte[] a() {
        try {
            return AbstractC0332ib.a(new StringBuilder(this.a.getPackageName()).reverse().toString());
        } catch (Throwable unused) {
            return new byte[16];
        }
    }

    public final byte[] b() {
        try {
            return AbstractC0332ib.a(this.a.getPackageName());
        } catch (Throwable unused) {
            return new byte[16];
        }
    }
}
