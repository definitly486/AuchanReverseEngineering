package io.appmetrica.analytics.impl;

import android.util.Pair;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.l0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0398l0 {
    public C0127ad a;
    public long b;
    public boolean c;
    public final Ll d;

    public C0398l0(String str, long j, Ll ll) {
        this.b = j;
        try {
            this.a = new C0127ad(str);
        } catch (Throwable unused) {
            this.a = new C0127ad();
        }
        this.d = ll;
    }

    public final synchronized void a(Pair pair) {
        if (this.d.b(this.a, (String) pair.first, (String) pair.second)) {
            this.c = true;
        }
    }

    public final synchronized String toString() {
        return "Map size " + this.a.size() + ". Is changed " + this.c + ". Current revision " + this.b;
    }

    public final synchronized C0372k0 a() {
        try {
            if (this.c) {
                this.b++;
                this.c = false;
            }
        } catch (Throwable th) {
            throw th;
        }
        return new C0372k0(Cb.b(this.a), this.b);
    }
}
