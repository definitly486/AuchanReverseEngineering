package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;

/* JADX INFO: loaded from: classes3.dex */
public abstract class Ud implements InterfaceC0708wo, InterfaceC0660v2 {
    public final String a;
    public final int b;
    public final Ko c;
    public final W2 d;
    public PublicLogger e = PublicLogger.getAnonymousInstance();

    public Ud(int i, String str, Ko ko, W2 w2) {
        this.b = i;
        this.a = str;
        this.c = ko;
        this.d = w2;
    }

    public final C0734xo a() {
        C0734xo c0734xo = new C0734xo();
        c0734xo.b = this.b;
        c0734xo.a = this.a.getBytes();
        c0734xo.d = new C0786zo();
        c0734xo.c = new C0760yo();
        return c0734xo;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0708wo
    public abstract /* synthetic */ void a(C0682vo c0682vo);

    public final W2 b() {
        return this.d;
    }

    public final String c() {
        return this.a;
    }

    public final Ko d() {
        return this.c;
    }

    public final int e() {
        return this.b;
    }

    public final boolean f() {
        Io ioA = this.c.a(this.a);
        if (ioA.a) {
            return true;
        }
        this.e.warning("Attribute " + this.a + " of type " + ((String) AbstractC0293go.a.get(this.b)) + " is skipped because " + ioA.b, new Object[0]);
        return false;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0708wo
    public final void a(PublicLogger publicLogger) {
        this.e = publicLogger;
    }
}
