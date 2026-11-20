package io.appmetrica.analytics.impl;

import android.content.Context;
import javax.net.ssl.SSLSocketFactory;

/* JADX INFO: loaded from: classes3.dex */
public final class Rl implements X2 {
    public final Context a;

    public Rl(Context context) {
        this.a = context;
    }

    @Override // io.appmetrica.analytics.impl.X2, io.appmetrica.analytics.impl.Bm
    public final void a(C0706wm c0706wm) {
    }

    @Override // io.appmetrica.analytics.coreapi.internal.io.SslSocketFactoryProvider
    public final SSLSocketFactory getSslSocketFactory() {
        return null;
    }

    public final Context a() {
        return this.a;
    }
}
