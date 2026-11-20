package io.appmetrica.analytics.impl;

import android.location.Location;
import android.os.Bundle;
import io.appmetrica.analytics.AdvIdentifiersResult;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.AppMetricaLibraryAdapterConfig;
import io.appmetrica.analytics.DeferredDeeplinkListener;
import io.appmetrica.analytics.DeferredDeeplinkParametersListener;
import io.appmetrica.analytics.ReporterConfig;
import io.appmetrica.analytics.StartupParamsCallback;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class G0 implements InterfaceC0151bb {
    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.S6
    public final void a(int i, Bundle bundle) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(Location location) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(AppMetricaLibraryAdapterConfig appMetricaLibraryAdapterConfig) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(DeferredDeeplinkListener deferredDeeplinkListener) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(DeferredDeeplinkParametersListener deferredDeeplinkParametersListener) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(ReporterConfig reporterConfig) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str, String str2) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z, boolean z2) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void b(AppMetricaConfig appMetricaConfig) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final InterfaceC0435mb c(ReporterConfig reporterConfig) {
        return new C0650ui();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void clearAppEnvironment() {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final C0590sa d() {
        return new C0590sa();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final String e() {
        return null;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final Map<String, String> g() {
        return null;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final AdvIdentifiersResult h() {
        AdvIdentifiersResult.Details details = AdvIdentifiersResult.Details.INTERNAL_ERROR;
        return new AdvIdentifiersResult(new AdvIdentifiersResult.AdvId(null, details, "Device user is in locked state"), new AdvIdentifiersResult.AdvId(null, details, "Device user is in locked state"), new AdvIdentifiersResult.AdvId(null, details, "Device user is in locked state"));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final Fc i() {
        Sc sc = new Sc();
        return new Fc(sc, new Q7(sc));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void putAppEnvironmentValue(String str, String str2) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void setDataSendingEnabled(boolean z) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void setUserProfileID(String str) {
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb
    public final void a(StartupParamsCallback startupParamsCallback, List<String> list) {
        startupParamsCallback.onRequestError(StartupParamsCallback.Reason.UNKNOWN, null);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0151bb, io.appmetrica.analytics.impl.InterfaceC0487ob
    public final InterfaceC0461nb a() {
        return new C0728xi();
    }
}
