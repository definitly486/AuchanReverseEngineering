package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.toggle.SimpleThreadSafeToggle;

/* JADX INFO: loaded from: classes3.dex */
public final class V3 extends SimpleThreadSafeToggle {
    public final C0621tf a;

    public V3(C0621tf c0621tf) {
        super(c0621tf.e(), "[ClientApiTrackingStatusToggle]");
        this.a = c0621tf;
    }

    public final void a(boolean z) {
        updateState(z);
        this.a.f(z);
    }
}
