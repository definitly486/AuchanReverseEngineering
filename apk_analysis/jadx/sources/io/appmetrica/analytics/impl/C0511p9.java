package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.p9, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0511p9 extends AbstractC0538q9 {
    public final List a;

    public C0511p9(List<Object> list) {
        this.a = CollectionUtils.unmodifiableListCopy(list);
    }

    public final List<Object> a() {
        return this.a;
    }
}
