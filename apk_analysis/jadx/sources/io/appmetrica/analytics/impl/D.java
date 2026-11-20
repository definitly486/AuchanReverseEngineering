package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: loaded from: classes3.dex */
public final class D extends Lambda implements Function1 {
    public final /* synthetic */ C0579s a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public D(C0579s c0579s) {
        super(1);
        this.a = c0579s;
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        this.a.j = (byte[]) obj;
        return Unit.INSTANCE;
    }
}
