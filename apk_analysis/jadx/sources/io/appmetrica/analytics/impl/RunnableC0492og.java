package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import io.appmetrica.analytics.coreapi.internal.backport.Function;
import java.io.File;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.og, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0492og implements Runnable {
    public final File a;
    public final Function b;
    public final Consumer c;
    public final Consumer d;
    public final C0668va e;
    public final InterfaceC0653ul f;

    public RunnableC0492og(File file, Function function, Consumer consumer, Consumer consumer2, C0668va c0668va, InterfaceC0653ul interfaceC0653ul) {
        this.a = file;
        this.b = function;
        this.c = consumer;
        this.d = consumer2;
        this.e = c0668va;
        this.f = interfaceC0653ul;
    }

    public static final void a(File file) {
    }

    @Override // java.lang.Runnable
    public final void run() {
        if (this.a.exists()) {
            R9 r9B = this.e.b(this.a.getName());
            Consumer consumer = this.c;
            try {
                r9B.a.lock();
                r9B.b.a();
                if (!this.a.exists()) {
                    consumer.consume(this.a);
                    r9B.c();
                    C0668va c0668va = this.e;
                    String name = this.a.getName();
                    synchronized (c0668va) {
                        c0668va.b.remove(name);
                    }
                    return;
                }
                Object objApply = this.b.apply(this.a);
                if (objApply != null) {
                    if (this.f.a(objApply)) {
                        this.d.consume(objApply);
                    } else {
                        consumer = new Consumer() { // from class: io.appmetrica.analytics.impl.og$$ExternalSyntheticLambda0
                            @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
                            public final void consume(Object obj) {
                                RunnableC0492og.a((File) obj);
                            }
                        };
                    }
                }
            } catch (Throwable unused) {
            }
            consumer.consume(this.a);
            r9B.c();
            this.e.a(this.a.getName());
        }
    }
}
