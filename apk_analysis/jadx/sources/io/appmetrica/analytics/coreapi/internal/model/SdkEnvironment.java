package io.appmetrica.analytics.coreapi.internal.model;

import java.util.List;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class SdkEnvironment {
    private final AppVersionInfo a;
    private final String b;
    private final ScreenInfo c;
    private final SdkInfo d;
    private final String e;
    private final List f;

    public SdkEnvironment(AppVersionInfo appVersionInfo, String str, ScreenInfo screenInfo, SdkInfo sdkInfo, String str2, List<String> list) {
        this.a = appVersionInfo;
        this.b = str;
        this.c = screenInfo;
        this.d = sdkInfo;
        this.e = str2;
        this.f = list;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public static /* synthetic */ SdkEnvironment copy$default(SdkEnvironment sdkEnvironment, AppVersionInfo appVersionInfo, String str, ScreenInfo screenInfo, SdkInfo sdkInfo, String str2, List list, int i, Object obj) {
        if ((i & 1) != 0) {
            appVersionInfo = sdkEnvironment.a;
        }
        if ((i & 2) != 0) {
            str = sdkEnvironment.b;
        }
        if ((i & 4) != 0) {
            screenInfo = sdkEnvironment.c;
        }
        if ((i & 8) != 0) {
            sdkInfo = sdkEnvironment.d;
        }
        if ((i & 16) != 0) {
            str2 = sdkEnvironment.e;
        }
        if ((i & 32) != 0) {
            list = sdkEnvironment.f;
        }
        String str3 = str2;
        List list2 = list;
        return sdkEnvironment.copy(appVersionInfo, str, screenInfo, sdkInfo, str3, list2);
    }

    public final AppVersionInfo component1() {
        return this.a;
    }

    public final String component2() {
        return this.b;
    }

    public final ScreenInfo component3() {
        return this.c;
    }

    public final SdkInfo component4() {
        return this.d;
    }

    public final String component5() {
        return this.e;
    }

    public final List<String> component6() {
        return this.f;
    }

    public final SdkEnvironment copy(AppVersionInfo appVersionInfo, String str, ScreenInfo screenInfo, SdkInfo sdkInfo, String str2, List<String> list) {
        return new SdkEnvironment(appVersionInfo, str, screenInfo, sdkInfo, str2, list);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof SdkEnvironment)) {
            return false;
        }
        SdkEnvironment sdkEnvironment = (SdkEnvironment) obj;
        return Intrinsics.areEqual(this.a, sdkEnvironment.a) && Intrinsics.areEqual(this.b, sdkEnvironment.b) && Intrinsics.areEqual(this.c, sdkEnvironment.c) && Intrinsics.areEqual(this.d, sdkEnvironment.d) && Intrinsics.areEqual(this.e, sdkEnvironment.e) && Intrinsics.areEqual(this.f, sdkEnvironment.f);
    }

    public final String getAppFramework() {
        return this.b;
    }

    public final AppVersionInfo getAppVersionInfo() {
        return this.a;
    }

    public final String getDeviceType() {
        return this.e;
    }

    public final List<String> getLocales() {
        return this.f;
    }

    public final ScreenInfo getScreenInfo() {
        return this.c;
    }

    public final SdkInfo getSdkInfo() {
        return this.d;
    }

    public int hashCode() {
        return this.f.hashCode() + ((this.e.hashCode() + ((this.d.hashCode() + ((this.c.hashCode() + ((this.b.hashCode() + (this.a.hashCode() * 31)) * 31)) * 31)) * 31)) * 31);
    }

    public String toString() {
        return "SdkEnvironment(appVersionInfo=" + this.a + ", appFramework=" + this.b + ", screenInfo=" + this.c + ", sdkInfo=" + this.d + ", deviceType=" + this.e + ", locales=" + this.f + ')';
    }
}
