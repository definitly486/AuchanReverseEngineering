package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleReporter;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceModuleCounterReport;
import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.rk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0574rk implements ServiceComponentModuleReporter {
    public final C0455n5 a;
    public final Kk b;

    public C0574rk(C0455n5 c0455n5, Kk kk) {
        this.a = c0455n5;
        this.b = kk;
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.ServiceComponentModuleReporter
    public final void handleReport(ServiceModuleCounterReport serviceModuleCounterReport) {
        this.b.getClass();
        this.a.a(Kk.a(serviceModuleCounterReport));
    }

    public /* synthetic */ C0574rk(C0455n5 c0455n5, Kk kk, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(c0455n5, (i & 2) != 0 ? new Kk() : kk);
    }
}
