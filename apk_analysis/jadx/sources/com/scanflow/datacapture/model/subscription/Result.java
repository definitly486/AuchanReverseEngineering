package com.scanflow.datacapture.model.subscription;

import androidx.annotation.Keep;
import com.google.gson.annotations.SerializedName;
import com.scanflow.datacapture.barinternal.c.a;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
@Keep
public final class Result {

    @SerializedName("active")
    private final boolean active;

    @SerializedName("analytics_Id")
    private final String analyticsId;

    @SerializedName("isPackageExeed")
    private final boolean isPackageExeed;

    @SerializedName("lastSyncDate")
    private final String lastSyncDate;

    @SerializedName("packageName")
    private final String packageName;

    @SerializedName("subscriptionEndDate")
    private final String subscriptionEndDate;

    @SerializedName("subscriptionStartDate")
    private final String subscriptionStartDate;

    public Result(boolean z, boolean z2, String lastSyncDate, String packageName, String subscriptionEndDate, String subscriptionStartDate, String analyticsId) {
        Intrinsics.checkNotNullParameter(lastSyncDate, "lastSyncDate");
        Intrinsics.checkNotNullParameter(packageName, "packageName");
        Intrinsics.checkNotNullParameter(subscriptionEndDate, "subscriptionEndDate");
        Intrinsics.checkNotNullParameter(subscriptionStartDate, "subscriptionStartDate");
        Intrinsics.checkNotNullParameter(analyticsId, "analyticsId");
        this.active = z;
        this.isPackageExeed = z2;
        this.lastSyncDate = lastSyncDate;
        this.packageName = packageName;
        this.subscriptionEndDate = subscriptionEndDate;
        this.subscriptionStartDate = subscriptionStartDate;
        this.analyticsId = analyticsId;
    }

    public static /* synthetic */ Result copy$default(Result result, boolean z, boolean z2, String str, String str2, String str3, String str4, String str5, int i, Object obj) {
        if ((i & 1) != 0) {
            z = result.active;
        }
        if ((i & 2) != 0) {
            z2 = result.isPackageExeed;
        }
        if ((i & 4) != 0) {
            str = result.lastSyncDate;
        }
        if ((i & 8) != 0) {
            str2 = result.packageName;
        }
        if ((i & 16) != 0) {
            str3 = result.subscriptionEndDate;
        }
        if ((i & 32) != 0) {
            str4 = result.subscriptionStartDate;
        }
        if ((i & 64) != 0) {
            str5 = result.analyticsId;
        }
        String str6 = str4;
        String str7 = str5;
        String str8 = str3;
        String str9 = str;
        return result.copy(z, z2, str9, str2, str8, str6, str7);
    }

    public final boolean component1() {
        return this.active;
    }

    public final boolean component2() {
        return this.isPackageExeed;
    }

    public final String component3() {
        return this.lastSyncDate;
    }

    public final String component4() {
        return this.packageName;
    }

    public final String component5() {
        return this.subscriptionEndDate;
    }

    public final String component6() {
        return this.subscriptionStartDate;
    }

    public final String component7() {
        return this.analyticsId;
    }

    public final Result copy(boolean z, boolean z2, String lastSyncDate, String packageName, String subscriptionEndDate, String subscriptionStartDate, String analyticsId) {
        Intrinsics.checkNotNullParameter(lastSyncDate, "lastSyncDate");
        Intrinsics.checkNotNullParameter(packageName, "packageName");
        Intrinsics.checkNotNullParameter(subscriptionEndDate, "subscriptionEndDate");
        Intrinsics.checkNotNullParameter(subscriptionStartDate, "subscriptionStartDate");
        Intrinsics.checkNotNullParameter(analyticsId, "analyticsId");
        return new Result(z, z2, lastSyncDate, packageName, subscriptionEndDate, subscriptionStartDate, analyticsId);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof Result)) {
            return false;
        }
        Result result = (Result) obj;
        return this.active == result.active && this.isPackageExeed == result.isPackageExeed && Intrinsics.areEqual(this.lastSyncDate, result.lastSyncDate) && Intrinsics.areEqual(this.packageName, result.packageName) && Intrinsics.areEqual(this.subscriptionEndDate, result.subscriptionEndDate) && Intrinsics.areEqual(this.subscriptionStartDate, result.subscriptionStartDate) && Intrinsics.areEqual(this.analyticsId, result.analyticsId);
    }

    public final boolean getActive() {
        return this.active;
    }

    public final String getAnalyticsId() {
        return this.analyticsId;
    }

    public final String getLastSyncDate() {
        return this.lastSyncDate;
    }

    public final String getPackageName() {
        return this.packageName;
    }

    public final String getSubscriptionEndDate() {
        return this.subscriptionEndDate;
    }

    public final String getSubscriptionStartDate() {
        return this.subscriptionStartDate;
    }

    public int hashCode() {
        return this.analyticsId.hashCode() + ((this.subscriptionStartDate.hashCode() + ((this.subscriptionEndDate.hashCode() + ((this.packageName.hashCode() + ((this.lastSyncDate.hashCode() + a.a(this.isPackageExeed, Boolean.hashCode(this.active) * 31, 31)) * 31)) * 31)) * 31)) * 31);
    }

    public final boolean isPackageExeed() {
        return this.isPackageExeed;
    }

    public String toString() {
        return "Result(active=" + this.active + ", isPackageExeed=" + this.isPackageExeed + ", lastSyncDate=" + this.lastSyncDate + ", packageName=" + this.packageName + ", subscriptionEndDate=" + this.subscriptionEndDate + ", subscriptionStartDate=" + this.subscriptionStartDate + ", analyticsId=" + this.analyticsId + ')';
    }
}
