package io.appmetrica.analytics.impl;

import android.content.Context;
import android.location.Location;
import io.appmetrica.analytics.coreapi.internal.system.PermissionExtractor;
import io.appmetrica.analytics.locationapi.internal.CacheArguments;
import io.appmetrica.analytics.locationapi.internal.LastKnownLocationExtractorProvider;
import io.appmetrica.analytics.locationapi.internal.LastKnownLocationExtractorProviderFactory;
import io.appmetrica.analytics.locationapi.internal.LocationClient;
import io.appmetrica.analytics.locationapi.internal.LocationControllerObserver;
import io.appmetrica.analytics.locationapi.internal.LocationFilter;
import io.appmetrica.analytics.locationapi.internal.LocationProvider;
import io.appmetrica.analytics.locationapi.internal.LocationReceiverProvider;
import io.appmetrica.analytics.locationapi.internal.LocationReceiverProviderFactory;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleLocationSourcesServiceController;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.hc, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0307hc implements InterfaceC0281gc, Bm, LocationProvider {
    public final Context a;
    public final InterfaceC0410lc b;
    public final LocationClient c;
    public final Nl d;
    public final Ok e;
    public final LastKnownLocationExtractorProviderFactory f;
    public final LocationReceiverProviderFactory g;

    public C0307hc(Context context, InterfaceC0410lc interfaceC0410lc, LocationClient locationClient) {
        this.a = context;
        this.b = interfaceC0410lc;
        this.c = locationClient;
        C0541qc c0541qc = new C0541qc();
        this.d = new Nl(new C0767z5(c0541qc, Ka.k().p().getAskForPermissionStrategy()));
        this.e = Ka.k().p();
        ((C0488oc) interfaceC0410lc).a(c0541qc, true);
        ((C0488oc) interfaceC0410lc).a(locationClient, true);
        this.f = locationClient.getLastKnownExtractorProviderFactory();
        this.g = locationClient.getLocationReceiverProviderFactory();
    }

    public final Nl a() {
        return this.d;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0281gc, io.appmetrica.analytics.impl.InterfaceC0358jc
    public final void b(Object obj) {
        ((C0488oc) this.b).a(obj);
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final LastKnownLocationExtractorProviderFactory getLastKnownExtractorProviderFactory() {
        return this.f;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final LocationReceiverProviderFactory getLocationReceiverProviderFactory() {
        return this.g;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final PermissionExtractor getPermissionExtractor() {
        return this.d;
    }

    @Override // io.appmetrica.analytics.locationapi.internal.LocationProvider
    public final Location getSystemLocation() {
        return this.c.getSystemLocation();
    }

    @Override // io.appmetrica.analytics.locationapi.internal.LocationProvider
    public final Location getUserLocation() {
        return this.c.getUserLocation();
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0281gc, io.appmetrica.analytics.impl.InterfaceC0358jc
    public final void init() {
        this.c.init(this.a, this.d, Ka.I.d.c(), this.e.d());
        ModuleLocationSourcesServiceController moduleLocationSourcesServiceControllerE = this.e.e();
        if (moduleLocationSourcesServiceControllerE != null) {
            moduleLocationSourcesServiceControllerE.init();
        } else {
            LocationClient locationClient = this.c;
            locationClient.registerSystemLocationSource(locationClient.getLastKnownExtractorProviderFactory().getGplLastKnownLocationExtractorProvider());
            LocationClient locationClient2 = this.c;
            locationClient2.registerSystemLocationSource(locationClient2.getLastKnownExtractorProviderFactory().getNetworkLastKnownLocationExtractorProvider());
        }
        ((C0488oc) this.b).a(this.e.f());
        Ka.I.u.a(this);
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final void registerControllerObserver(LocationControllerObserver locationControllerObserver) {
        ((C0488oc) this.b).a(locationControllerObserver, true);
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final void registerSource(LastKnownLocationExtractorProvider lastKnownLocationExtractorProvider) {
        this.c.registerSystemLocationSource(lastKnownLocationExtractorProvider);
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final void unregisterSource(LastKnownLocationExtractorProvider lastKnownLocationExtractorProvider) {
        this.c.unregisterSystemLocationSource(lastKnownLocationExtractorProvider);
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final void updateLocationFilter(LocationFilter locationFilter) {
        this.c.updateLocationFilter(locationFilter);
    }

    @Override // io.appmetrica.analytics.impl.Bm
    public final void a(C0706wm c0706wm) {
        C0609t3 c0609t3 = c0706wm.x;
        if (c0609t3 != null) {
            long j = c0609t3.a;
            this.c.updateCacheArguments(new CacheArguments(j, ((long) 2) * j));
        }
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final void registerSource(LocationReceiverProvider locationReceiverProvider) {
        this.c.registerSystemLocationSource(locationReceiverProvider);
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.LocationServiceApi
    public final void unregisterSource(LocationReceiverProvider locationReceiverProvider) {
        this.c.unregisterSystemLocationSource(locationReceiverProvider);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0281gc, io.appmetrica.analytics.impl.InterfaceC0358jc
    public final void a(Object obj) {
        ((C0488oc) this.b).b(obj);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0281gc, io.appmetrica.analytics.impl.InterfaceC0358jc
    public final void a(boolean z) {
        ((C0488oc) this.b).a(z);
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0281gc, io.appmetrica.analytics.impl.InterfaceC0358jc
    public final void a(Location location) {
        this.c.updateUserLocation(location);
    }
}
