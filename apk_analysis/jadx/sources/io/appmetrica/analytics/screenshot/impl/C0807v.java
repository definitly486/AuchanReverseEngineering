package io.appmetrica.analytics.screenshot.impl;

import io.appmetrica.analytics.coreapi.internal.lifecycle.ActivityEvent;
import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;

/* JADX INFO: renamed from: io.appmetrica.analytics.screenshot.impl.v, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0807v implements P {
    public final ClientContext a;
    public final Q b;
    public volatile C0797k c;
    public final W d;

    public C0807v(ClientContext clientContext, Q q) {
        this.a = clientContext;
        this.b = q;
        this.d = new W(clientContext, new C0804s(this));
    }

    @Override // io.appmetrica.analytics.screenshot.impl.P
    public final void a(C0799m c0799m) {
        this.c = c0799m != null ? c0799m.c : null;
        this.d.c = this.c;
    }

    public final String b() {
        return "ContentObserverScreenshotCaptor";
    }

    @Override // io.appmetrica.analytics.screenshot.impl.P
    public final void a() {
        this.a.getActivityLifecycleRegistry().registerListener(new C0806u(this), ActivityEvent.RESUMED, ActivityEvent.PAUSED);
    }
}
