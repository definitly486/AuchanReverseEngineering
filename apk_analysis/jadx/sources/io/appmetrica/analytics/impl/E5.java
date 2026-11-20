package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.networktasks.internal.ArgumentsMerger;
import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;

/* JADX INFO: loaded from: classes3.dex */
public abstract class E5 implements InterfaceC0625tj {
    public BaseRequestConfig a;
    public final BaseRequestConfig.RequestConfigLoader b;
    public C0146b6 c;

    public E5(BaseRequestConfig.RequestConfigLoader<Object, C0146b6> requestConfigLoader, C0706wm c0706wm, ArgumentsMerger<Object, Object> argumentsMerger) {
        this.b = requestConfigLoader;
        Ka.k().v().a(this);
        a(new C0146b6(c0706wm, Ka.k().v(), Ka.k().s(), argumentsMerger));
    }

    public final synchronized void a(C0146b6 c0146b6) {
        this.c = c0146b6;
    }

    public final synchronized ArgumentsMerger<Object, Object> b() {
        return (ArgumentsMerger) this.c.componentArguments;
    }

    public final synchronized C0706wm c() {
        return this.c.a;
    }

    public final void d() {
        synchronized (this) {
            this.a = null;
        }
    }

    public final synchronized void e() {
        this.a = null;
    }

    public synchronized void a(Object obj) {
        if (!((ArgumentsMerger) this.c.componentArguments).compareWithOtherArguments(obj)) {
            a(new C0146b6(c(), Ka.I.v(), Ka.I.s(), (ArgumentsMerger) ((ArgumentsMerger) this.c.componentArguments).mergeFrom(obj)));
            e();
        }
    }

    public final synchronized void a(C0706wm c0706wm) {
        a(new C0146b6(c0706wm, Ka.I.v(), Ka.I.s(), b()));
        e();
    }

    public final synchronized BaseRequestConfig a() {
        try {
            if (this.a == null) {
                this.a = this.b.load(this.c);
            }
        } catch (Throwable th) {
            throw th;
        }
        return this.a;
    }
}
