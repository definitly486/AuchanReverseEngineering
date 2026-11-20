package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.d5, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0197d5 {
    public final N5 a;
    public final Zc b;
    public final Zc c;

    public C0197d5(C0173c7 c0173c7, Zg zg) {
        Oe oe = new Oe(c0173c7);
        this.a = new N5(c0173c7);
        this.b = new Zc(oe, new C0171c5(zg));
        this.c = new Zc(oe, C0145b5.a);
    }

    public final List<Z8> a() {
        return CollectionsKt.listOf((Object[]) new Z8[]{this.a, this.b});
    }

    public final List<Z8> b() {
        return CollectionsKt.listOf(this.c);
    }
}
