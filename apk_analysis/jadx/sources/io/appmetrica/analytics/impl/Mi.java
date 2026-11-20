package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.ResultReceiver;

/* JADX INFO: loaded from: classes3.dex */
public final class Mi extends Q4 {
    public Mi(N4 n4) {
        super(n4);
    }

    @Override // io.appmetrica.analytics.impl.Q4
    public final boolean a(C0249f6 c0249f6, L4 l4) {
        Bundle bundle = c0249f6.m;
        this.a.a(bundle != null ? (ResultReceiver) bundle.getParcelable("io.appmetrica.analytics.impl.referrer.common.ReferrerResultReceiver") : null);
        return false;
    }
}
