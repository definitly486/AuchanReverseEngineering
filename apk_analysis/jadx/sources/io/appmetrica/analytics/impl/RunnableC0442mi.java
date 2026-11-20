package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.mi, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0442mi implements Runnable {
    public final /* synthetic */ List a;
    public final /* synthetic */ C0624ti b;

    public RunnableC0442mi(C0624ti c0624ti, List list) {
        this.b = c0624ti;
        this.a = list;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.b;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportAnr(CollectionUtils.getMapFromList(this.a));
    }
}
