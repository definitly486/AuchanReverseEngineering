package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreapi.internal.event.CounterReportApi;
import io.appmetrica.analytics.modulesapi.internal.service.event.ModuleEventServiceHandlerReporter;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.pd, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0515pd implements ModuleEventServiceHandlerReporter {
    public final String a;
    public final boolean b;
    public final E9 c;
    public final C0249f6 d;

    public C0515pd(String str, boolean z, E9 e9, C0249f6 c0249f6) {
        this.a = str;
        this.b = z;
        this.c = e9;
        this.d = c0249f6;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.event.ModuleEventServiceHandlerReporter
    public final String getApiKey() {
        return this.a;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.event.ModuleEventServiceHandlerReporter
    public final boolean isMain() {
        return this.b;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.event.ModuleEventServiceHandlerReporter
    public final void report(CounterReportApi counterReportApi) {
        C0249f6 c0249f6D = C0249f6.d(this.d);
        c0249f6D.d = counterReportApi.getType();
        c0249f6D.e = counterReportApi.getCustomType();
        c0249f6D.setName(counterReportApi.getName());
        String value = counterReportApi.getValue();
        if (value != null) {
            c0249f6D.setValue(value);
        }
        byte[] valueBytes = counterReportApi.getValueBytes();
        if (valueBytes != null) {
            c0249f6D.setValueBytes(valueBytes);
        }
        c0249f6D.g = counterReportApi.getBytesTruncated();
        E9 e9 = this.c;
        e9.a(c0249f6D, C0393kl.a(e9.c.b(c0249f6D), c0249f6D.i));
    }
}
