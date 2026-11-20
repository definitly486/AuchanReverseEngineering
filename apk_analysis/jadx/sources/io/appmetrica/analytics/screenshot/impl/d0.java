package io.appmetrica.analytics.screenshot.impl;

import android.os.Handler;
import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;

/* JADX INFO: loaded from: classes3.dex */
public final class d0 implements P {
    public final ClientContext a;
    public final Q b;
    public final Handler c;
    public volatile boolean d;
    public volatile C0800n e;
    public final a0 f = new a0(this);

    public d0(ClientContext clientContext, Q q) {
        this.a = clientContext;
        this.b = q;
        this.c = clientContext.getClientExecutorProvider().getDefaultExecutor().getHandler();
    }

    @Override // io.appmetrica.analytics.screenshot.impl.P
    public final void a(C0799m c0799m) {
        this.e = c0799m != null ? c0799m.b : null;
    }

    public final String b() {
        return "ServiceScreenshotCaptor";
    }

    @Override // io.appmetrica.analytics.screenshot.impl.P
    public final void a() {
        this.a.getActivityLifecycleRegistry().registerListener(new c0(this), ActivityEvent.RESUMED, ActivityEvent.PAUSED);
    }
}
