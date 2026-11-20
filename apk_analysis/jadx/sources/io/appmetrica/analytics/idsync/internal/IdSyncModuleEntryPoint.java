package io.appmetrica.analytics.idsync.internal;

import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreapi.internal.data.JsonParser;
import io.appmetrica.analytics.idsync.impl.C0108c;
import io.appmetrica.analytics.idsync.impl.C0109d;
import io.appmetrica.analytics.idsync.impl.C0110e;
import io.appmetrica.analytics.idsync.impl.h;
import io.appmetrica.analytics.idsync.internal.model.IdSyncConfig;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleRemoteConfig;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint;
import io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration;
import io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigUpdateListener;
import io.appmetrica.analytics.modulesapi.internal.service.ServiceContext;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class IdSyncModuleEntryPoint extends ModuleServiceEntryPoint<IdSyncConfig> implements RemoteConfigUpdateListener<IdSyncConfig> {
    private final C0109d a;
    private final C0108c b;
    private h c;
    private final String d;
    private final IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1 e;

    /* JADX WARN: Type inference failed for: r0v2, types: [io.appmetrica.analytics.idsync.internal.IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1] */
    public IdSyncModuleEntryPoint() {
        C0110e c0110e = new C0110e();
        this.a = new C0109d(c0110e);
        this.b = new C0108c(c0110e);
        this.d = "id-sync";
        this.e = new RemoteConfigExtensionConfiguration<IdSyncConfig>() { // from class: io.appmetrica.analytics.idsync.internal.IdSyncModuleEntryPoint$remoteConfigExtensionConfiguration$1
            @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
            public Map<String, Integer> getBlocks() {
                return MapsKt.mapOf(TuplesKt.to("is", 1));
            }

            @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
            public List<String> getFeatures() {
                return CollectionsKt.listOf("is");
            }

            @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
            public JsonParser<IdSyncConfig> getJsonParser() {
                return this.a.b;
            }

            @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
            public Converter<IdSyncConfig, byte[]> getProtobufConverter() {
                return this.a.a;
            }

            @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
            public RemoteConfigUpdateListener<IdSyncConfig> getRemoteConfigUpdateListener() {
                return this.a;
            }
        };
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint
    public String getIdentifier() {
        return this.d;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint
    public RemoteConfigExtensionConfiguration<IdSyncConfig> getRemoteConfigExtensionConfiguration() {
        return this.e;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint
    public void initServiceSide(ServiceContext serviceContext, ModuleRemoteConfig<IdSyncConfig> moduleRemoteConfig) {
        synchronized (this) {
            try {
                if (this.c == null) {
                    h hVar = new h(serviceContext, moduleRemoteConfig.getIdentifiers());
                    this.c = hVar;
                    IdSyncConfig featuresConfig = moduleRemoteConfig.getFeaturesConfig();
                    if (featuresConfig != null) {
                        hVar.a(featuresConfig, moduleRemoteConfig.getIdentifiers());
                    }
                }
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigUpdateListener
    public synchronized void onRemoteConfigUpdated(ModuleRemoteConfig<IdSyncConfig> moduleRemoteConfig) {
        h hVar;
        IdSyncConfig featuresConfig = moduleRemoteConfig.getFeaturesConfig();
        if (featuresConfig != null && (hVar = this.c) != null) {
            hVar.a(featuresConfig, moduleRemoteConfig.getIdentifiers());
        }
    }
}
