package io.appmetrica.analytics.impl;

import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.Lambda;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0171c5 extends Lambda implements Function0 {
    public final /* synthetic */ Zg a;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public C0171c5(Zg zg) {
        super(0);
        this.a = zg;
    }

    @Override // kotlin.jvm.functions.Function0
    public final Object invoke() {
        return Integer.valueOf(((C0727xh) this.a.a()).i);
    }
}
