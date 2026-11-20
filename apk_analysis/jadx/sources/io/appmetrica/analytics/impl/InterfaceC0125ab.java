package io.appmetrica.analytics.impl;

import android.os.Handler;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.coreapi.internal.executors.ICommonExecutor;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ab, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public interface InterfaceC0125ab {
    C0662v4 a();

    void a(AppMetricaConfig appMetricaConfig, InterfaceC0487ob interfaceC0487ob);

    Handler b();

    C0245f2 c();

    Gb d();

    ICommonExecutor getDefaultExecutor();
}
