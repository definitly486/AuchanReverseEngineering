package io.appmetrica.analytics.impl;

import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import io.appmetrica.analytics.networktasks.internal.ConfigProvider;

/* JADX INFO: loaded from: classes3.dex */
public final class Ub implements ConfigProvider {
    public final C0455n5 a;
    public final Lazy b = LazyKt.lazy(new Tb(this));

    public Ub(C0455n5 c0455n5) {
        this.a = c0455n5;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.ConfigProvider
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final C0727xh getConfig() {
        return (C0727xh) this.b.getValue();
    }
}
