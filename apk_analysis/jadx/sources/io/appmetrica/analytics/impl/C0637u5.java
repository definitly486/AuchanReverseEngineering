package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.io.IExecutionPolicy;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.u5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0637u5 extends Lambda implements Function1 {
    public static final C0637u5 a = new C0637u5();

    public C0637u5() {
        super(1);
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        return ((IExecutionPolicy) obj).description();
    }
}
