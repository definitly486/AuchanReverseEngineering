package io.appmetrica.analytics.remotepermissions.internal;

import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import io.appmetrica.analytics.coreapi.internal.data.Converter;
import io.appmetrica.analytics.coreapi.internal.data.JsonParser;
import io.appmetrica.analytics.coreapi.internal.permission.PermissionStrategy;
import io.appmetrica.analytics.modulesapi.internal.common.AskForPermissionStrategyModuleProvider;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleRemoteConfig;
import io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint;
import io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration;
import io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigUpdateListener;
import io.appmetrica.analytics.modulesapi.internal.service.ServiceContext;
import io.appmetrica.analytics.remotepermissions.impl.a;
import io.appmetrica.analytics.remotepermissions.impl.c;
import io.appmetrica.analytics.remotepermissions.impl.d;
import io.appmetrica.analytics.remotepermissions.internal.config.FeatureConfig;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class RemotePermissionsModuleEntryPoint extends ModuleServiceEntryPoint<FeatureConfig> implements AskForPermissionStrategyModuleProvider, RemoteConfigUpdateListener<FeatureConfig> {
    private final c a = new c();
    private final a b = new a();
    private final RemotePermissionsModuleEntryPoint c = this;
    private final d d = new d();
    private final String e = "rp";
    private final RemotePermissionsModuleEntryPoint$remoteConfigExtensionConfiguration$1 f = new RemoteConfigExtensionConfiguration<FeatureConfig>() { // from class: io.appmetrica.analytics.remotepermissions.internal.RemotePermissionsModuleEntryPoint$remoteConfigExtensionConfiguration$1
        @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
        public Map<String, Integer> getBlocks() {
            return MapsKt.mapOf(TuplesKt.to("permissions", 1));
        }

        @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
        public List<String> getFeatures() {
            return CollectionsKt.emptyList();
        }

        @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
        public JsonParser<FeatureConfig> getJsonParser() {
            return this.a.a;
        }

        @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
        public Converter<FeatureConfig, byte[]> getProtobufConverter() {
            return this.a.b;
        }

        @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigExtensionConfiguration
        public RemoteConfigUpdateListener<FeatureConfig> getRemoteConfigUpdateListener() {
            return this.a.c;
        }
    };

    @Override // io.appmetrica.analytics.modulesapi.internal.common.AskForPermissionStrategyModuleProvider
    public PermissionStrategy getAskForPermissionStrategy() {
        return this.d;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint
    public String getIdentifier() {
        return this.e;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint
    public RemoteConfigExtensionConfiguration<FeatureConfig> getRemoteConfigExtensionConfiguration() {
        return this.f;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.ModuleServiceEntryPoint
    public void initServiceSide(ServiceContext serviceContext, ModuleRemoteConfig<FeatureConfig> moduleRemoteConfig) {
        Set<String> setEmptySet;
        d dVar = this.d;
        FeatureConfig featuresConfig = moduleRemoteConfig.getFeaturesConfig();
        if (featuresConfig == null || (setEmptySet = featuresConfig.getPermittedPermissions()) == null) {
            setEmptySet = SetsKt.emptySet();
        }
        synchronized (dVar) {
            dVar.a = setEmptySet;
        }
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.service.RemoteConfigUpdateListener
    public void onRemoteConfigUpdated(ModuleRemoteConfig<FeatureConfig> moduleRemoteConfig) {
        Set<String> setEmptySet;
        d dVar = this.d;
        FeatureConfig featuresConfig = moduleRemoteConfig.getFeaturesConfig();
        if (featuresConfig == null || (setEmptySet = featuresConfig.getPermittedPermissions()) == null) {
            setEmptySet = SetsKt.emptySet();
        }
        synchronized (dVar) {
            dVar.a = setEmptySet;
        }
    }
}
