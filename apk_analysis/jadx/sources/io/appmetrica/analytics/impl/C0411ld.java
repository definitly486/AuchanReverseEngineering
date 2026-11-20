package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.executors.IHandlerExecutor;
import io.appmetrica.analytics.modulesapi.internal.client.ModuleClientExecutorProvider;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ld, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0411ld implements ModuleClientExecutorProvider {
    @Override // io.appmetrica.analytics.modulesapi.internal.client.ModuleClientExecutorProvider
    public final IHandlerExecutor getDefaultExecutor() {
        return C0584s4.l().c.a();
    }
}
