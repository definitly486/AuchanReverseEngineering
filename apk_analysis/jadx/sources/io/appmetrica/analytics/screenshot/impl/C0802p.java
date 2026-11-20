package io.appmetrica.analytics.screenshot.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.p, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0802p {
    public final boolean a;
    public final List b;
    public final long c;

    public C0802p(boolean z, List list, long j) {
        this.a = z;
        this.b = list;
        this.c = j;
    }

    public final long a() {
        return this.c;
    }

    public final boolean b() {
        return this.a;
    }

    public final List c() {
        return this.b;
    }

    public final String toString() {
        return "ContentObserverCaptorConfig(enabled=" + this.a + ", mediaStoreColumnNames='" + this.b + "', detectWindowSeconds=" + this.c + ')';
    }

    public C0802p() {
        this(new L().a, ArraysKt.toList(new L().c), new L().b);
    }
}
