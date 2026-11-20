package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.res.Configuration;
import android.graphics.Point;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import io.appmetrica.analytics.coreapi.internal.model.AppVersionInfo;
import io.appmetrica.analytics.coreapi.internal.model.ScreenInfo;
import io.appmetrica.analytics.coreapi.internal.model.SdkEnvironment;
import io.appmetrica.analytics.coreapi.internal.model.SdkInfo;
import io.appmetrica.analytics.coreapi.internal.servicecomponents.SdkEnvironmentProvider;
import io.appmetrica.analytics.coreutils.internal.services.FrameworkDetector;
import io.appmetrica.analytics.coreutils.internal.services.PackageManagerUtils;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;
import kotlin.jvm.internal.Intrinsics;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.uj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0651uj implements SdkEnvironmentProvider {
    public final Context a;
    public final C0229ec b = new C0229ec();
    public final CopyOnWriteArrayList c = new CopyOnWriteArrayList();
    public SdkEnvironment d;
    public String e;

    public C0651uj(Context context) {
        this.a = context;
        this.d = new SdkEnvironment(new AppVersionInfo(PackageManagerUtils.getAppVersionName(context), PackageManagerUtils.getAppVersionCodeString(context)), FrameworkDetector.framework(), new ScreenInfo(0, 0, 0, 0.0f), new SdkInfo("8.1.0", "50162358", AbstractC0677vj.a()), "phone", C0229ec.a(context.getResources().getConfiguration()));
    }

    public final synchronized void a(ScreenInfo screenInfo) {
        float f;
        if (screenInfo != null) {
            try {
                if (!Intrinsics.areEqual(screenInfo, getSdkEnvironment().getScreenInfo())) {
                    String str = this.e;
                    if (str == null) {
                        Context context = this.a;
                        Point point = new Point(screenInfo.getWidth(), screenInfo.getHeight());
                        SafePackageManager safePackageManager = AbstractC0251f8.a;
                        try {
                            f = context.getResources().getDisplayMetrics().density;
                        } catch (Throwable unused) {
                            f = 0.0f;
                        }
                        if (Float.isNaN(f) || f == 0.0f) {
                            str = "phone";
                        } else {
                            int i = point.x;
                            int i2 = point.y;
                            if (AbstractC0251f8.a(context)) {
                                str = "tv";
                            } else {
                                float f2 = BuiltinOperator.BITWISE_XOR * f;
                                float f3 = i;
                                float f4 = f3 / f2;
                                float f5 = i2;
                                float f6 = f5 / f2;
                                str = (Math.sqrt((double) ((f6 * f6) + (f4 * f4))) >= 7.0d || RangesKt.coerceAtMost(f3 / f, f5 / f) >= 600.0f) ? "tablet" : "phone";
                            }
                        }
                    }
                    this.d = SdkEnvironment.copy$default(getSdkEnvironment(), null, null, screenInfo, null, str, null, 43, null);
                    Iterator it = this.c.iterator();
                    while (it.hasNext()) {
                        ((E5) ((InterfaceC0625tj) it.next())).d();
                    }
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void b(InterfaceC0625tj interfaceC0625tj) {
        this.c.remove(interfaceC0625tj);
    }

    @Override // io.appmetrica.analytics.coreapi.internal.servicecomponents.SdkEnvironmentProvider
    public final SdkEnvironment getSdkEnvironment() {
        SdkEnvironment sdkEnvironment = this.d;
        if (sdkEnvironment != null) {
            return sdkEnvironment;
        }
        Intrinsics.throwUninitializedPropertyAccessException("sdkEnvironment");
        return null;
    }

    public final synchronized void a(String str) {
        if (str != null) {
            if (!Intrinsics.areEqual(str, this.e)) {
                this.e = str;
                if (!Intrinsics.areEqual(str, getSdkEnvironment().getDeviceType())) {
                    this.d = SdkEnvironment.copy$default(getSdkEnvironment(), null, null, null, null, str, null, 47, null);
                    Iterator it = this.c.iterator();
                    while (it.hasNext()) {
                        ((E5) ((InterfaceC0625tj) it.next())).d();
                    }
                }
            }
        }
    }

    public final synchronized void a(String str, String str2) {
        if (str == null) {
            try {
                str = getSdkEnvironment().getAppVersionInfo().getAppVersionName();
            } catch (Throwable th) {
                throw th;
            }
        }
        if (str2 == null) {
            str2 = getSdkEnvironment().getAppVersionInfo().getAppBuildNumber();
        }
        AppVersionInfo appVersionInfo = getSdkEnvironment().getAppVersionInfo();
        if (!Intrinsics.areEqual(appVersionInfo.getAppVersionName(), str) || !Intrinsics.areEqual(appVersionInfo.getAppBuildNumber(), str2)) {
            this.d = SdkEnvironment.copy$default(getSdkEnvironment(), new AppVersionInfo(str, str2), null, null, null, null, null, 62, null);
            Iterator it = this.c.iterator();
            while (it.hasNext()) {
                ((E5) ((InterfaceC0625tj) it.next())).d();
            }
        }
    }

    public final synchronized void a(Configuration configuration) {
        this.b.getClass();
        List listA = C0229ec.a(configuration);
        if (!Intrinsics.areEqual(getSdkEnvironment().getLocales(), listA)) {
            this.d = SdkEnvironment.copy$default(getSdkEnvironment(), null, null, null, null, null, listA, 31, null);
            Iterator it = this.c.iterator();
            while (it.hasNext()) {
                ((E5) ((InterfaceC0625tj) it.next())).d();
            }
        }
    }

    public final void a(InterfaceC0625tj interfaceC0625tj) {
        this.c.add(interfaceC0625tj);
    }
}
