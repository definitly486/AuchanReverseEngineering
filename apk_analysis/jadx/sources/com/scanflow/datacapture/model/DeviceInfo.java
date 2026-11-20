package com.scanflow.datacapture.model;

import com.google.gson.annotations.SerializedName;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class DeviceInfo {

    @SerializedName("bundleId")
    private String bundleId;

    @SerializedName("deviceId")
    private String deviceId;

    @SerializedName("deviceMake")
    private String deviceMake;

    @SerializedName("deviceModel")
    private String deviceModel;

    @SerializedName("osVersion")
    private String osVersion;

    @SerializedName("productType")
    private String productType;

    public DeviceInfo() {
        this(null, null, null, null, null, null, 63, null);
    }

    public static /* synthetic */ DeviceInfo copy$default(DeviceInfo deviceInfo, String str, String str2, String str3, String str4, String str5, String str6, int i, Object obj) {
        if ((i & 1) != 0) {
            str = deviceInfo.deviceMake;
        }
        if ((i & 2) != 0) {
            str2 = deviceInfo.deviceModel;
        }
        if ((i & 4) != 0) {
            str3 = deviceInfo.osVersion;
        }
        if ((i & 8) != 0) {
            str4 = deviceInfo.deviceId;
        }
        if ((i & 16) != 0) {
            str5 = deviceInfo.bundleId;
        }
        if ((i & 32) != 0) {
            str6 = deviceInfo.productType;
        }
        String str7 = str5;
        String str8 = str6;
        return deviceInfo.copy(str, str2, str3, str4, str7, str8);
    }

    public final String component1() {
        return this.deviceMake;
    }

    public final String component2() {
        return this.deviceModel;
    }

    public final String component3() {
        return this.osVersion;
    }

    public final String component4() {
        return this.deviceId;
    }

    public final String component5() {
        return this.bundleId;
    }

    public final String component6() {
        return this.productType;
    }

    public final DeviceInfo copy(String deviceMake, String deviceModel, String osVersion, String deviceId, String bundleId, String productType) {
        Intrinsics.checkNotNullParameter(deviceMake, "deviceMake");
        Intrinsics.checkNotNullParameter(deviceModel, "deviceModel");
        Intrinsics.checkNotNullParameter(osVersion, "osVersion");
        Intrinsics.checkNotNullParameter(deviceId, "deviceId");
        Intrinsics.checkNotNullParameter(bundleId, "bundleId");
        Intrinsics.checkNotNullParameter(productType, "productType");
        return new DeviceInfo(deviceMake, deviceModel, osVersion, deviceId, bundleId, productType);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof DeviceInfo)) {
            return false;
        }
        DeviceInfo deviceInfo = (DeviceInfo) obj;
        return Intrinsics.areEqual(this.deviceMake, deviceInfo.deviceMake) && Intrinsics.areEqual(this.deviceModel, deviceInfo.deviceModel) && Intrinsics.areEqual(this.osVersion, deviceInfo.osVersion) && Intrinsics.areEqual(this.deviceId, deviceInfo.deviceId) && Intrinsics.areEqual(this.bundleId, deviceInfo.bundleId) && Intrinsics.areEqual(this.productType, deviceInfo.productType);
    }

    public final String getBundleId() {
        return this.bundleId;
    }

    public final String getDeviceId() {
        return this.deviceId;
    }

    public final String getDeviceMake() {
        return this.deviceMake;
    }

    public final String getDeviceModel() {
        return this.deviceModel;
    }

    public final String getOsVersion() {
        return this.osVersion;
    }

    public final String getProductType() {
        return this.productType;
    }

    public int hashCode() {
        return this.productType.hashCode() + ((this.bundleId.hashCode() + ((this.deviceId.hashCode() + ((this.osVersion.hashCode() + ((this.deviceModel.hashCode() + (this.deviceMake.hashCode() * 31)) * 31)) * 31)) * 31)) * 31);
    }

    public final void setBundleId(String str) {
        Intrinsics.checkNotNullParameter(str, "<set-?>");
        this.bundleId = str;
    }

    public final void setDeviceId(String str) {
        Intrinsics.checkNotNullParameter(str, "<set-?>");
        this.deviceId = str;
    }

    public final void setDeviceMake(String str) {
        Intrinsics.checkNotNullParameter(str, "<set-?>");
        this.deviceMake = str;
    }

    public final void setDeviceModel(String str) {
        Intrinsics.checkNotNullParameter(str, "<set-?>");
        this.deviceModel = str;
    }

    public final void setOsVersion(String str) {
        Intrinsics.checkNotNullParameter(str, "<set-?>");
        this.osVersion = str;
    }

    public final void setProductType(String str) {
        Intrinsics.checkNotNullParameter(str, "<set-?>");
        this.productType = str;
    }

    public String toString() {
        return "DeviceInfo(deviceMake=" + this.deviceMake + ", deviceModel=" + this.deviceModel + ", osVersion=" + this.osVersion + ", deviceId=" + this.deviceId + ", bundleId=" + this.bundleId + ", productType=" + this.productType + ')';
    }

    public DeviceInfo(String deviceMake, String deviceModel, String osVersion, String deviceId, String bundleId, String productType) {
        Intrinsics.checkNotNullParameter(deviceMake, "deviceMake");
        Intrinsics.checkNotNullParameter(deviceModel, "deviceModel");
        Intrinsics.checkNotNullParameter(osVersion, "osVersion");
        Intrinsics.checkNotNullParameter(deviceId, "deviceId");
        Intrinsics.checkNotNullParameter(bundleId, "bundleId");
        Intrinsics.checkNotNullParameter(productType, "productType");
        this.deviceMake = deviceMake;
        this.deviceModel = deviceModel;
        this.osVersion = osVersion;
        this.deviceId = deviceId;
        this.bundleId = bundleId;
        this.productType = productType;
    }

    public /* synthetic */ DeviceInfo(String str, String str2, String str3, String str4, String str5, String str6, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? "" : str, (i & 2) != 0 ? "" : str2, (i & 4) != 0 ? "" : str3, (i & 8) != 0 ? "" : str4, (i & 16) != 0 ? "" : str5, (i & 32) != 0 ? "" : str6);
    }
}
