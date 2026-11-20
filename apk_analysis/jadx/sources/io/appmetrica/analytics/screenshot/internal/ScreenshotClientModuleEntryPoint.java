package io.appmetrica.analytics.screenshot.internal;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.modulesapi.internal.client.BundleToServiceConfigConverter;
import io.appmetrica.analytics.modulesapi.internal.client.ClientContext;
import io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint;
import io.appmetrica.analytics.modulesapi.internal.client.ModuleServiceConfig;
import io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigExtensionConfiguration;
import io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigUpdateListener;
import io.appmetrica.analytics.screenshot.impl.C0794h;
import io.appmetrica.analytics.screenshot.impl.C0798l;
import io.appmetrica.analytics.screenshot.impl.C0799m;
import io.appmetrica.analytics.screenshot.impl.C0808w;
import io.appmetrica.analytics.screenshot.impl.C0809x;
import io.appmetrica.analytics.screenshot.impl.D;
import io.appmetrica.analytics.screenshot.impl.G;
import io.appmetrica.analytics.screenshot.impl.P;
import io.appmetrica.analytics.screenshot.impl.S;
import io.appmetrica.analytics.screenshot.internal.config.ParcelableRemoteScreenshotConfig;
import java.util.Iterator;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class ScreenshotClientModuleEntryPoint extends ModuleClientEntryPoint<ParcelableRemoteScreenshotConfig> {
    private C0798l a;
    private S d;
    private final C0794h b = new C0794h();
    private final ScreenshotClientModuleEntryPoint$configUpdateListener$1 c = new ServiceConfigUpdateListener<ParcelableRemoteScreenshotConfig>() { // from class: io.appmetrica.analytics.screenshot.internal.ScreenshotClientModuleEntryPoint$configUpdateListener$1
        @Override // io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigUpdateListener
        public void onServiceConfigUpdated(ModuleServiceConfig<ParcelableRemoteScreenshotConfig> moduleServiceConfig) {
            C0798l c0798l;
            ScreenshotClientModuleEntryPoint screenshotClientModuleEntryPoint = this.a;
            synchronized (screenshotClientModuleEntryPoint) {
                try {
                    ParcelableRemoteScreenshotConfig featuresConfig = moduleServiceConfig.getFeaturesConfig();
                    S s = null;
                    if (featuresConfig != null) {
                        boolean enabled = featuresConfig.getEnabled();
                        D config$screenshot_release = featuresConfig.getConfig$screenshot_release();
                        c0798l = new C0798l(enabled, config$screenshot_release != null ? new C0799m(config$screenshot_release) : null);
                    } else {
                        c0798l = null;
                    }
                    screenshotClientModuleEntryPoint.a = c0798l;
                    if (screenshotClientModuleEntryPoint.d != null) {
                        S s2 = screenshotClientModuleEntryPoint.d;
                        if (s2 == null) {
                            Intrinsics.throwUninitializedPropertyAccessException("screenshotCaptorsController");
                        } else {
                            s = s2;
                        }
                        s.a(screenshotClientModuleEntryPoint.a);
                    }
                    Unit unit = Unit.INSTANCE;
                } catch (Throwable th) {
                    throw th;
                }
            }
        }
    };
    private final String e = "screenshot";
    private final ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1 f = new ServiceConfigExtensionConfiguration<ParcelableRemoteScreenshotConfig>() { // from class: io.appmetrica.analytics.screenshot.internal.ScreenshotClientModuleEntryPoint$serviceConfigExtensionConfiguration$1
        @Override // io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigExtensionConfiguration
        public BundleToServiceConfigConverter<ParcelableRemoteScreenshotConfig> getBundleConverter() {
            return this.a.b;
        }

        @Override // io.appmetrica.analytics.modulesapi.internal.client.ServiceConfigExtensionConfiguration
        public ServiceConfigUpdateListener<ParcelableRemoteScreenshotConfig> getServiceConfigUpdateListener() {
            return this.a.c;
        }
    };

    @Override // io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint
    public String getIdentifier() {
        return this.e;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint
    public ServiceConfigExtensionConfiguration<ParcelableRemoteScreenshotConfig> getServiceConfigExtensionConfiguration() {
        return this.f;
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint
    public void initClientSide(ClientContext clientContext) {
        synchronized (this) {
            try {
                C0809x c0809x = new C0809x(clientContext);
                this.d = new S(AndroidUtils.isApiAchieved(34) ? new C0808w(clientContext, c0809x) : new G(clientContext, c0809x));
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    @Override // io.appmetrica.analytics.modulesapi.internal.client.ModuleClientEntryPoint
    public void onActivated() {
        synchronized (this) {
            try {
                S s = this.d;
                if (s != null) {
                    C0798l c0798l = this.a;
                    Iterator it = s.a.iterator();
                    while (it.hasNext()) {
                        ((P) it.next()).a();
                    }
                    s.a(c0798l);
                }
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
    }
}
