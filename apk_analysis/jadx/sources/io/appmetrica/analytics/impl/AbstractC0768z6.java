package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ICrashTransformer;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.z6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0768z6 implements InterfaceC0228eb {
    public final InterfaceC0742y6 a;
    public final ICrashTransformer b;
    public final C0305ha c;

    public AbstractC0768z6(InterfaceC0742y6 interfaceC0742y6, ICrashTransformer iCrashTransformer, C0305ha c0305ha) {
        this.a = interfaceC0742y6;
        this.b = iCrashTransformer;
        this.c = c0305ha;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0228eb
    public final void a(Throwable th, X x) {
        if (this.a.a(th)) {
            ICrashTransformer iCrashTransformer = this.b;
            if (iCrashTransformer == null || th == null || (th = iCrashTransformer.process(th)) != null) {
                C0344io c0344ioA = AbstractC0422lo.a(th, x, null, (String) this.c.b.a(), (Boolean) this.c.c.a());
                Bc bc = (Bc) ((Oh) this).d;
                bc.a.a().a(bc.b).a(c0344ioA);
            }
        }
    }

    public final InterfaceC0742y6 b() {
        return this.a;
    }

    public final ICrashTransformer a() {
        return this.b;
    }
}
