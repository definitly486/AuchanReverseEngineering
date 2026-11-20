package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.r1, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class RunnableC0555r1 implements Runnable {
    public final /* synthetic */ String a;
    public final /* synthetic */ List b;
    public final /* synthetic */ C0659v1 c;

    public RunnableC0555r1(C0659v1 c0659v1, String str, List list) {
        this.c = c0659v1;
        this.a = str;
        this.b = list;
    }

    @Override // java.lang.Runnable
    public final void run() {
        C0659v1.a(this.c).reportEvent(this.a, CollectionUtils.getMapFromList(this.b));
    }
}
