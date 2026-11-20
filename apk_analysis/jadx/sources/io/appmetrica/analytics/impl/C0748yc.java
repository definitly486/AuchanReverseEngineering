package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.Collection;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0748yc {
    public final Zg a;
    public final L9 b;
    public final F4 c;
    public final C0544qf d;
    public final C0197d5 e;
    public final Qc f = new Qc();
    public final Lazy g = LazyKt.lazy(new C0722xc(this));

    public C0748yc(C0173c7 c0173c7, Zg zg, L9 l9, F4 f4, C0544qf c0544qf) {
        this.a = zg;
        this.b = l9;
        this.c = f4;
        this.d = c0544qf;
        this.e = new C0197d5(c0173c7, zg);
    }

    public final List<Z8> a() {
        return this.e.a();
    }

    public final List<Z8> b() {
        return CollectionsKt.plus((Collection) CollectionsKt.listOf(this.e.c), (Iterable) CollectionsKt.listOf((Z8) this.g.getValue()));
    }
}
