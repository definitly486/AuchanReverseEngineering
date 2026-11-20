package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.identifiers.PlatformIdentifiers;
import io.appmetrica.analytics.coreapi.internal.identifiers.SdkIdentifiers;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.SdkEnvironmentProvider;
import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.b6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0146b6 extends BaseRequestConfig.DataSource {
    public final C0706wm a;
    public final SdkEnvironmentProvider b;

    public C0146b6(C0706wm c0706wm, SdkEnvironmentProvider sdkEnvironmentProvider, PlatformIdentifiers platformIdentifiers, Object obj) {
        super(new SdkIdentifiers(c0706wm.c(), c0706wm.a(), c0706wm.b()), sdkEnvironmentProvider, platformIdentifiers, obj);
        this.a = c0706wm;
        this.b = sdkEnvironmentProvider;
    }
}
