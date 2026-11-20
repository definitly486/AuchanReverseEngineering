package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.j5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0351j5 {
    public final C0455n5 a;
    public final String b = "[ComponentMigrationToV113]";

    public AbstractC0351j5(C0455n5 c0455n5) {
        this.a = c0455n5;
    }

    public final C0455n5 a() {
        return this.a;
    }

    public final String b() {
        return this.b;
    }

    public abstract boolean b(int i);

    public abstract void c();

    public final void a(int i) {
        if (b(i)) {
            c();
        }
    }
}
