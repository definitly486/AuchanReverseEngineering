package io.appmetrica.analytics.impl;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Sd extends AbstractC0569rf {
    public Sd(InterfaceC0280gb interfaceC0280gb, String str) {
        super(interfaceC0280gb, str);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final String a(String str, String str2) {
        return this.a.getString(g(str), str2);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final Ol b(String str, String str2) {
        return d(g(str), str2);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public Ol e(String str) {
        return f(g(str));
    }

    public abstract String g(String str);

    public Sd(InterfaceC0280gb interfaceC0280gb) {
        this(interfaceC0280gb, null);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final Ol b(String str, int i) {
        return d(g(str), i);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final int a(String str, int i) {
        return this.a.getInt(g(str), i);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final Ol b(String str, long j) {
        return d(g(str), j);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final Ol b(String str, boolean z) {
        return d(g(str), z);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final long a(String str, long j) {
        return this.a.getLong(g(str), j);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final boolean b(String str) {
        return this.a.a(g(str));
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final boolean a(String str, boolean z) {
        return this.a.getBoolean(g(str), z);
    }
}
