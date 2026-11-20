package io.appmetrica.analytics.impl;

import android.location.Location;
import io.appmetrica.analytics.AppMetricaConfig;
import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class V7 implements InterfaceC0179cd {
    public Location a;
    public Boolean b;
    public Boolean c;
    public Boolean e;
    public boolean h;
    public String i;
    public boolean k;
    public Ji l;
    public Boolean d = Boolean.FALSE;
    public final LinkedHashMap f = new LinkedHashMap();
    public final LinkedHashMap g = new LinkedHashMap();
    public List<String> j = new ArrayList();

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z) {
        Boolean boolValueOf = Boolean.valueOf(z);
        this.b = boolValueOf;
        Ji ji = this.l;
        if (ji != null) {
            ji.a(boolValueOf, this.e, this.c, this.d);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void clearAppEnvironment() {
        this.h = true;
        this.f.clear();
    }

    public final C0450n0 j() {
        return new C0450n0(this.j, this.h);
    }

    public final Location k() {
        return this.a;
    }

    public final Boolean l() {
        return this.c;
    }

    public final Boolean m() {
        return this.e;
    }

    public final Boolean n() {
        return this.b;
    }

    public final boolean o() {
        return this.h;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void putAppEnvironmentValue(String str, String str2) {
        this.f.put(str, str2);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void setDataSendingEnabled(boolean z) {
        Boolean boolValueOf = Boolean.valueOf(z);
        this.e = boolValueOf;
        Ji ji = this.l;
        if (ji != null) {
            ji.a(this.b, boolValueOf, this.c, this.d);
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void setUserProfileID(String str) {
        this.i = str;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(boolean z, boolean z2) {
        boolean z3 = this.c == null;
        boolean zBooleanValue = this.d.booleanValue();
        if (z2 || z3 || !zBooleanValue) {
            this.c = Boolean.valueOf(z);
            Boolean boolValueOf = Boolean.valueOf(z2);
            this.d = boolValueOf;
            Ji ji = this.l;
            if (ji != null) {
                ji.a(this.b, this.e, this.c, boolValueOf);
            }
        }
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(Location location) {
        this.a = location;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str, String str2) {
        this.g.put(str, str2);
    }

    public final AppMetricaConfig a(AppMetricaConfig appMetricaConfig) {
        if (this.k) {
            return appMetricaConfig;
        }
        AppMetricaConfig.Builder builderNewConfigBuilder = AppMetricaConfig.newConfigBuilder(appMetricaConfig.apiKey);
        builderNewConfigBuilder.withDeviceType(appMetricaConfig.deviceType);
        builderNewConfigBuilder.withPreloadInfo(appMetricaConfig.preloadInfo);
        builderNewConfigBuilder.withLocation(appMetricaConfig.location);
        if (Do.a(appMetricaConfig.appVersion)) {
            builderNewConfigBuilder.withAppVersion(appMetricaConfig.appVersion);
        }
        if (Do.a(appMetricaConfig.dispatchPeriodSeconds)) {
            builderNewConfigBuilder.withDispatchPeriodSeconds(appMetricaConfig.dispatchPeriodSeconds.intValue());
        }
        if (Do.a(appMetricaConfig.appBuildNumber)) {
            builderNewConfigBuilder.withAppBuildNumber(appMetricaConfig.appBuildNumber.intValue());
        }
        if (Do.a(appMetricaConfig.maxReportsCount)) {
            builderNewConfigBuilder.withMaxReportsCount(appMetricaConfig.maxReportsCount.intValue());
        }
        if (Do.a(appMetricaConfig.logs) && appMetricaConfig.logs.booleanValue()) {
            builderNewConfigBuilder.withLogs();
        }
        if (Do.a(appMetricaConfig.sessionTimeout)) {
            builderNewConfigBuilder.withSessionTimeout(appMetricaConfig.sessionTimeout.intValue());
        }
        if (Do.a(appMetricaConfig.sessionsAutoTrackingEnabled)) {
            builderNewConfigBuilder.withSessionsAutoTrackingEnabled(appMetricaConfig.sessionsAutoTrackingEnabled.booleanValue());
        }
        if (Do.a(appMetricaConfig.crashReporting)) {
            builderNewConfigBuilder.withCrashReporting(appMetricaConfig.crashReporting.booleanValue());
        }
        if (Do.a(appMetricaConfig.nativeCrashReporting)) {
            builderNewConfigBuilder.withNativeCrashReporting(appMetricaConfig.nativeCrashReporting.booleanValue());
        }
        if (Do.a(appMetricaConfig.locationTracking)) {
            builderNewConfigBuilder.withLocationTracking(appMetricaConfig.locationTracking.booleanValue());
        }
        if (Do.a(appMetricaConfig.advIdentifiersTracking)) {
            builderNewConfigBuilder.withAdvIdentifiersTracking(appMetricaConfig.advIdentifiersTracking.booleanValue());
        }
        if (Do.a(appMetricaConfig.firstActivationAsUpdate)) {
            builderNewConfigBuilder.handleFirstActivationAsUpdate(appMetricaConfig.firstActivationAsUpdate.booleanValue());
        }
        if (Do.a(appMetricaConfig.dataSendingEnabled)) {
            builderNewConfigBuilder.withDataSendingEnabled(appMetricaConfig.dataSendingEnabled.booleanValue());
        }
        if (Do.a(appMetricaConfig.anrMonitoring)) {
            builderNewConfigBuilder.withAnrMonitoring(appMetricaConfig.anrMonitoring.booleanValue());
        }
        if (Do.a(appMetricaConfig.anrMonitoringTimeout)) {
            builderNewConfigBuilder.withAnrMonitoringTimeout(appMetricaConfig.anrMonitoringTimeout.intValue());
        }
        if (Do.a(appMetricaConfig.maxReportsInDatabaseCount)) {
            builderNewConfigBuilder.withMaxReportsInDatabaseCount(appMetricaConfig.maxReportsInDatabaseCount.intValue());
        }
        if (Do.a(appMetricaConfig.crashTransformer)) {
            builderNewConfigBuilder.withCrashTransformer(appMetricaConfig.crashTransformer);
        }
        if (Do.a(appMetricaConfig.userProfileID)) {
            builderNewConfigBuilder.withUserProfileID(appMetricaConfig.userProfileID);
        }
        if (Do.a(appMetricaConfig.revenueAutoTrackingEnabled)) {
            builderNewConfigBuilder.withRevenueAutoTrackingEnabled(appMetricaConfig.revenueAutoTrackingEnabled.booleanValue());
        }
        if (Do.a(appMetricaConfig.appOpenTrackingEnabled)) {
            builderNewConfigBuilder.withAppOpenTrackingEnabled(appMetricaConfig.appOpenTrackingEnabled.booleanValue());
        }
        if (Do.a((Object) appMetricaConfig.customHosts)) {
            builderNewConfigBuilder.withCustomHosts(appMetricaConfig.customHosts);
        }
        LinkedHashMap linkedHashMap = this.f;
        if (!Do.a((Map) linkedHashMap)) {
            for (Map.Entry entry : linkedHashMap.entrySet()) {
                builderNewConfigBuilder.withAppEnvironmentValue((String) entry.getKey(), (String) entry.getValue());
            }
        }
        Map<String, String> map = appMetricaConfig.appEnvironment;
        if (!Do.a((Map) map)) {
            for (Map.Entry<String, String> entry2 : map.entrySet()) {
                builderNewConfigBuilder.withAppEnvironmentValue(entry2.getKey(), entry2.getValue());
            }
        }
        LinkedHashMap linkedHashMap2 = this.g;
        if (!Do.a((Map) linkedHashMap2)) {
            for (Map.Entry entry3 : linkedHashMap2.entrySet()) {
                builderNewConfigBuilder.withErrorEnvironmentValue((String) entry3.getKey(), (String) entry3.getValue());
            }
        }
        Map<String, String> map2 = appMetricaConfig.errorEnvironment;
        if (!Do.a((Map) map2)) {
            for (Map.Entry<String, String> entry4 : map2.entrySet()) {
                builderNewConfigBuilder.withErrorEnvironmentValue(entry4.getKey(), entry4.getValue());
            }
        }
        Map<String, Object> map3 = appMetricaConfig.additionalConfig;
        if (!Do.a((Map) map3)) {
            for (Map.Entry<String, Object> entry5 : map3.entrySet()) {
                builderNewConfigBuilder.withAdditionalConfig(entry5.getKey(), entry5.getValue());
            }
        }
        Boolean bool = this.b;
        if (appMetricaConfig.locationTracking == null && Do.a(bool)) {
            builderNewConfigBuilder.withLocationTracking(bool.booleanValue());
        }
        Location location = this.a;
        if (appMetricaConfig.location == null && Do.a(location)) {
            builderNewConfigBuilder.withLocation(location);
        }
        Boolean bool2 = this.e;
        if (appMetricaConfig.dataSendingEnabled == null && Do.a(bool2)) {
            builderNewConfigBuilder.withDataSendingEnabled(bool2.booleanValue());
        }
        if (!Do.a(appMetricaConfig.userProfileID) && Do.a(this.i)) {
            builderNewConfigBuilder.withUserProfileID(this.i);
        }
        Boolean bool3 = this.c;
        if (appMetricaConfig.advIdentifiersTracking == null && Do.a(bool3)) {
            builderNewConfigBuilder.withAdvIdentifiersTracking(bool3.booleanValue());
        }
        this.k = true;
        this.a = null;
        this.b = null;
        this.c = null;
        this.d = Boolean.FALSE;
        this.e = null;
        this.f.clear();
        this.g.clear();
        this.h = false;
        this.i = null;
        return builderNewConfigBuilder.build();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0179cd
    public final void a(String str) {
        this.j.add(str);
    }

    public final void a(Ji ji) {
        Boolean bool = this.b;
        if (bool != null || this.e != null || this.c != null) {
            ji.a(bool, this.e, this.c, this.d);
        }
        this.l = ji;
    }
}
