package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.modulesapi.internal.client.ProcessDetector;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.a4, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0118a4 implements ProcessDetector {
    @Override // io.appmetrica.analytics.modulesapi.internal.client.ProcessDetector
    public final boolean isMainProcess() {
        return C0584s4.l().a.b();
    }
}
