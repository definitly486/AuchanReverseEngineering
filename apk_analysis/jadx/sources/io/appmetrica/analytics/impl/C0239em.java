package io.appmetrica.analytics.impl;

import android.os.Bundle;
import io.appmetrica.analytics.StartupParamsCallback;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.em, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0239em implements S6 {
    public final /* synthetic */ StartupParamsCallback a;
    public final /* synthetic */ C0265fm b;

    public C0239em(C0265fm c0265fm, StartupParamsCallback startupParamsCallback) {
        this.b = c0265fm;
        this.a = startupParamsCallback;
    }

    @Override // io.appmetrica.analytics.impl.S6
    public final void a(int i, Bundle bundle) {
        this.b.b(bundle, this.a);
    }
}
