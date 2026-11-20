package io.appmetrica.analytics.impl;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.j8, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0354j8 {
    public final Yc a;

    public AbstractC0354j8() {
        Yc yc = new Yc(0);
        yc.a(EnumC0406l8.c, 0);
        yc.a(EnumC0406l8.d, 1);
        yc.a(EnumC0406l8.e, 2);
        yc.a(EnumC0406l8.f, 3);
        this.a = yc;
    }

    public final Yc a() {
        return this.a;
    }

    public abstract boolean a(Object obj, Object obj2);
}
