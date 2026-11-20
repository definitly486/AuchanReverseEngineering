package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.permission.PermissionResolutionStrategy;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.coreutils.internal.cache.CachedDataProvider;
import io.appmetrica.analytics.coreutils.internal.permission.AlwaysAllowPermissionStrategy;
import io.appmetrica.analytics.coreutils.internal.permission.SinglePermissionStrategy;
import io.appmetrica.analytics.coreutils.internal.services.telephony.CellularNetworkTypeExtractor;
import java.util.concurrent.TimeUnit;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0282gd implements Hn {
    public final Context a;
    public final PermissionResolutionStrategy b;
    public final CellularNetworkTypeExtractor c;
    public final CachedDataProvider.CachedData d;

    public C0282gd(Context context) {
        this.a = context;
        this.b = AndroidUtils.isApiAchieved(29) ? new SinglePermissionStrategy(Ka.k().j(), "android.permission.READ_PHONE_STATE") : new AlwaysAllowPermissionStrategy();
        this.c = new CellularNetworkTypeExtractor(context);
        long millis = TimeUnit.SECONDS.toMillis(20L);
        this.d = new CachedDataProvider.CachedData(millis, millis * ((long) 2), "mobile-connection");
    }

    @Override // io.appmetrica.analytics.impl.Hn
    /* JADX INFO: renamed from: b, reason: merged with bridge method [inline-methods] */
    public final synchronized C0256fd a() {
        C0256fd c0256fd;
        try {
            c0256fd = (C0256fd) this.d.getData();
            if (c0256fd == null || this.d.shouldUpdateData()) {
                c0256fd = new C0256fd(this.b.hasNecessaryPermissions(this.a) ? this.c.getNetworkType() : CellularNetworkTypeExtractor.UNKNOWN_NETWORK_TYPE_VALUE);
                this.d.setData(c0256fd);
            }
        } catch (Throwable th) {
            throw th;
        }
        return c0256fd;
    }
}
