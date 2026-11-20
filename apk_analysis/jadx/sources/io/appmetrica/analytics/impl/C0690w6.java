package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreapi.internal.backport.Consumer;
import java.io.File;
import java.util.concurrent.Executor;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.w6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0690w6 implements Consumer {
    public final Executor a;
    public final C0209dh b;

    public C0690w6(Context context, InterfaceC0612t6 interfaceC0612t6, EnumC0721xb enumC0721xb, InterfaceC0653ul interfaceC0653ul, Executor executor, String str, D6 d6) {
        this.a = executor;
        this.b = new C0209dh(context, interfaceC0612t6, enumC0721xb, interfaceC0653ul, d6);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.backport.Consumer
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final void consume(File file) {
        if (file == null) {
            return;
        }
        Executor executor = this.a;
        C0209dh c0209dh = this.b;
        Jb jb = c0209dh.d;
        Consumer consumer = c0209dh.f;
        Context context = c0209dh.a;
        if (C0668va.c == null) {
            synchronized (Reflection.getOrCreateKotlinClass(C0668va.class)) {
                try {
                    if (C0668va.c == null) {
                        C0668va.c = new C0668va(context);
                    }
                    Unit unit = Unit.INSTANCE;
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
        C0668va c0668va = C0668va.c;
        if (c0668va == null) {
            Intrinsics.throwUninitializedPropertyAccessException("INSTANCE");
            c0668va = null;
        }
        executor.execute(new RunnableC0492og(file, jb, jb, consumer, c0668va, c0209dh.b));
    }
}
