package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public final class B0 {
    public static boolean a() {
        boolean z;
        synchronized (A0.class) {
            z = A0.f;
        }
        return z;
    }

    public static void b() {
        synchronized (A0.class) {
            A0.f = true;
        }
    }
}
