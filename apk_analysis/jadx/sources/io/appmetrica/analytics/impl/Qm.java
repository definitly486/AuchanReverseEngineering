package io.appmetrica.analytics.impl;

import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: loaded from: classes3.dex */
public final class Qm extends Lambda implements Function0 {
    public final /* synthetic */ Rm a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public Qm(Rm rm) {
        super(0);
        this.a = rm;
    }

    @Override // kotlin.jvm.functions.Function0
    public final Object invoke() {
        return this.a.a.j;
    }
}
