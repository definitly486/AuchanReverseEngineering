package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.z, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0761z extends Lambda implements Function1 {
    public final /* synthetic */ C0579s a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0761z(C0579s c0579s) {
        super(1);
        this.a = c0579s;
    }

    @Override // kotlin.jvm.functions.Function1
    public final Object invoke(Object obj) {
        this.a.h = (byte[]) obj;
        return Unit.INSTANCE;
    }
}
