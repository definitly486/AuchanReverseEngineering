package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.n1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0451n1 implements Runnable {
    public final /* synthetic */ List a;
    public final /* synthetic */ C0659v1 b;

    public RunnableC0451n1(C0659v1 c0659v1, List list) {
        this.b = c0659v1;
        this.a = list;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.b).reportAnr(CollectionUtils.getMapFromList(this.a));
    }
}
