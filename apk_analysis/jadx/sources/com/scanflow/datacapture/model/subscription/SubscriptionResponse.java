package com.scanflow.datacapture.model.subscription;

import androidx.annotation.Keep;
import androidx.core.app.NotificationCompat;
import com.google.gson.annotations.SerializedName;
import com.scanflow.datacapture.model.DeviceInfo;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
@Keep
public final class SubscriptionResponse {
    private String apikey;
    private DeviceInfo deviceInfo;

    @SerializedName("message")
    private final String message;

    @SerializedName("result")
    private Result result;

    @SerializedName(NotificationCompat.CATEGORY_STATUS)
    private final String status;

    public SubscriptionResponse(String message, Result result, String status, DeviceInfo deviceInfo, String str) {
        Intrinsics.checkNotNullParameter(message, "message");
        Intrinsics.checkNotNullParameter(status, "status");
        this.message = message;
        this.result = result;
        this.status = status;
        this.deviceInfo = deviceInfo;
        this.apikey = str;
    }

    public static /* synthetic */ SubscriptionResponse copy$default(SubscriptionResponse subscriptionResponse, String str, Result result, String str2, DeviceInfo deviceInfo, String str3, int i, Object obj) {
        if ((i & 1) != 0) {
            str = subscriptionResponse.message;
        }
        if ((i & 2) != 0) {
            result = subscriptionResponse.result;
        }
        if ((i & 4) != 0) {
            str2 = subscriptionResponse.status;
        }
        if ((i & 8) != 0) {
            deviceInfo = subscriptionResponse.deviceInfo;
        }
        if ((i & 16) != 0) {
            str3 = subscriptionResponse.apikey;
        }
        String str4 = str3;
        String str5 = str2;
        return subscriptionResponse.copy(str, result, str5, deviceInfo, str4);
    }

    public final String component1() {
        return this.message;
    }

    public final Result component2() {
        return this.result;
    }

    public final String component3() {
        return this.status;
    }

    public final DeviceInfo component4() {
        return this.deviceInfo;
    }

    public final String component5() {
        return this.apikey;
    }

    public final SubscriptionResponse copy(String message, Result result, String status, DeviceInfo deviceInfo, String str) {
        Intrinsics.checkNotNullParameter(message, "message");
        Intrinsics.checkNotNullParameter(status, "status");
        return new SubscriptionResponse(message, result, status, deviceInfo, str);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof SubscriptionResponse)) {
            return false;
        }
        SubscriptionResponse subscriptionResponse = (SubscriptionResponse) obj;
        return Intrinsics.areEqual(this.message, subscriptionResponse.message) && Intrinsics.areEqual(this.result, subscriptionResponse.result) && Intrinsics.areEqual(this.status, subscriptionResponse.status) && Intrinsics.areEqual(this.deviceInfo, subscriptionResponse.deviceInfo) && Intrinsics.areEqual(this.apikey, subscriptionResponse.apikey);
    }

    public final String getApikey() {
        return this.apikey;
    }

    public final DeviceInfo getDeviceInfo() {
        return this.deviceInfo;
    }

    public final String getMessage() {
        return this.message;
    }

    public final Result getResult() {
        return this.result;
    }

    public final String getStatus() {
        return this.status;
    }

    public int hashCode() {
        int iHashCode = this.message.hashCode() * 31;
        Result result = this.result;
        int iHashCode2 = (this.status.hashCode() + ((iHashCode + (result == null ? 0 : result.hashCode())) * 31)) * 31;
        DeviceInfo deviceInfo = this.deviceInfo;
        int iHashCode3 = (iHashCode2 + (deviceInfo == null ? 0 : deviceInfo.hashCode())) * 31;
        String str = this.apikey;
        return iHashCode3 + (str != null ? str.hashCode() : 0);
    }

    public final void setApikey(String str) {
        this.apikey = str;
    }

    public final void setDeviceInfo(DeviceInfo deviceInfo) {
        this.deviceInfo = deviceInfo;
    }

    public final void setResult(Result result) {
        this.result = result;
    }

    public String toString() {
        return "SubscriptionResponse(message=" + this.message + ", result=" + this.result + ", status=" + this.status + ", deviceInfo=" + this.deviceInfo + ", apikey=" + this.apikey + ')';
    }
}
