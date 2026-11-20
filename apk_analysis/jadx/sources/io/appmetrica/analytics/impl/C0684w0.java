package io.appmetrica.analytics.impl;

import android.app.Service;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.w0, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0684w0 implements B1 {
    public final Service a;

    public C0684w0(Service service) {
        this.a = service;
    }

    public final void a(int i) {
        this.a.stopSelf(i);
    }
}
