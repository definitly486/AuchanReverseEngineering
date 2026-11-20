package io.appmetrica.analytics.impl;

import android.os.HandlerThread;
import io.appmetrica.analytics.coreapi.internal.executors.IInterruptionSafeThread;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.yb, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class HandlerThreadC0747yb extends HandlerThread implements IInterruptionSafeThread {
    public volatile boolean a;

    public HandlerThreadC0747yb(String str) {
        super(str);
        this.a = true;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.executors.IInterruptionSafeThread
    public final synchronized boolean isRunning() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.executors.IInterruptionSafeThread
    public final synchronized void stopRunning() {
        this.a = false;
        interrupt();
    }
}
