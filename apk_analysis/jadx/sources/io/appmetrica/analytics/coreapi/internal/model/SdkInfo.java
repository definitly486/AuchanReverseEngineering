package io.appmetrica.analytics.coreapi.internal.model;

import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class SdkInfo {
    private final String a;
    private final String b;
    private final String c;

    public SdkInfo(String str, String str2, String str3) {
        this.a = str;
        this.b = str2;
        this.c = str3;
    }

    public static /* synthetic */ SdkInfo copy$default(SdkInfo sdkInfo, String str, String str2, String str3, int i, Object obj) {
        if ((i & 1) != 0) {
            str = sdkInfo.a;
        }
        if ((i & 2) != 0) {
            str2 = sdkInfo.b;
        }
        if ((i & 4) != 0) {
            str3 = sdkInfo.c;
        }
        return sdkInfo.copy(str, str2, str3);
    }

    public final String component1() {
        return this.a;
    }

    public final String component2() {
        return this.b;
    }

    public final String component3() {
        return this.c;
    }

    public final SdkInfo copy(String str, String str2, String str3) {
        return new SdkInfo(str, str2, str3);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof SdkInfo)) {
            return false;
        }
        SdkInfo sdkInfo = (SdkInfo) obj;
        return Intrinsics.areEqual(this.a, sdkInfo.a) && Intrinsics.areEqual(this.b, sdkInfo.b) && Intrinsics.areEqual(this.c, sdkInfo.c);
    }

    public final String getSdkBuildNumber() {
        return this.b;
    }

    public final String getSdkBuildType() {
        return this.c;
    }

    public final String getSdkVersionName() {
        return this.a;
    }

    public int hashCode() {
        return this.c.hashCode() + ((this.b.hashCode() + (this.a.hashCode() * 31)) * 31);
    }

    public String toString() {
        return "SdkInfo(sdkVersionName=" + this.a + ", sdkBuildNumber=" + this.b + ", sdkBuildType=" + this.c + ')';
    }
}
