package io.appmetrica.analytics.idsync.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.ActivationBarrierCallback;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.idsync.impl.g, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0112g implements ActivationBarrierCallback {
    public final /* synthetic */ h a;

    public C0112g(h hVar) {
        this.a = hVar;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.ActivationBarrierCallback
    public final void onWaitFinished() {
        C0111f c0111f = this.a.g;
        if (c0111f == null) {
            Intrinsics.throwUninitializedPropertyAccessException("syncRunnable");
            c0111f = null;
        }
        c0111f.run();
    }
}
