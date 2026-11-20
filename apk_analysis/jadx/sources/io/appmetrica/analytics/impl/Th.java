package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
public final class Th implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ List b;
    public final /* synthetic */ C0624ti c;

    public Th(C0624ti c0624ti, String str, List list) {
        this.c = c0624ti;
        this.a = str;
        this.b = list;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0624ti c0624ti = this.c;
        C0624ti.a(c0624ti.a, c0624ti.d, c0624ti.e).reportEvent(this.a, CollectionUtils.getMapFromList(this.b));
    }
}
