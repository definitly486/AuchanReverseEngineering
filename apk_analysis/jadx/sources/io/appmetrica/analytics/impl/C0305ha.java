package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ha, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0305ha {
    public final Context a;
    public final C0447mn b;
    public final C0349j3 c;
    public final SafePackageManager d;

    public C0305ha(Context context, C0447mn c0447mn, C0349j3 c0349j3, SafePackageManager safePackageManager) {
        this.a = context;
        this.b = c0447mn;
        this.c = c0349j3;
        this.d = safePackageManager;
    }

    public C0305ha(Context context) {
        this(context, new C0447mn(context, "io.appmetrica.analytics.build_id"), new C0349j3(context, "io.appmetrica.analytics.is_offline"), new SafePackageManager());
    }
}
