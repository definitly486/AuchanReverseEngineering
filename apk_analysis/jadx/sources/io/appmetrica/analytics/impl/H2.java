package io.appmetrica.analytics.impl;

import android.annotation.TargetApi;
import android.app.ActivityManager;
import android.app.usage.UsageStatsManager;
import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.annotations.DoNotInline;
import io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable;
import io.appmetrica.analytics.coreutils.internal.AndroidUtils;
import io.appmetrica.analytics.coreutils.internal.system.SystemServiceUtils;

/* JADX INFO: loaded from: classes3.dex */
@DoNotInline
@TargetApi(28)
public final class H2 {
    public static final H2 a = new H2();

    private H2() {
    }

    public static final K2 a(Context context, final C0504p2 c0504p2) {
        return new K2((J2) SystemServiceUtils.accessSystemServiceByNameSafely(context, "usagestats", "getting app standby bucket", "usageStatsManager", new FunctionWithThrowable() { // from class: io.appmetrica.analytics.impl.H2$$ExternalSyntheticLambda2
            @Override // io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable
            public final Object apply(Object obj) {
                return H2.a(c0504p2, (UsageStatsManager) obj);
            }
        }), (Boolean) SystemServiceUtils.accessSystemServiceByNameSafely(context, "activity", "getting is background restricted", "activityManager", new FunctionWithThrowable() { // from class: io.appmetrica.analytics.impl.H2$$ExternalSyntheticLambda3
            @Override // io.appmetrica.analytics.coreapi.internal.backport.FunctionWithThrowable
            public final Object apply(Object obj) {
                return H2.a((ActivityManager) obj);
            }
        }));
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final J2 a(C0504p2 c0504p2, UsageStatsManager usageStatsManager) {
        int appStandbyBucket = usageStatsManager.getAppStandbyBucket();
        c0504p2.getClass();
        if (!AndroidUtils.isApiAchieved(28)) {
            return null;
        }
        if (AndroidUtils.isApiAchieved(30) && appStandbyBucket == 45) {
            return J2.RESTRICTED;
        }
        if (appStandbyBucket == 5) {
            return J2.EXEMPTED;
        }
        if (appStandbyBucket == 10) {
            return J2.ACTIVE;
        }
        if (appStandbyBucket == 30) {
            return J2.FREQUENT;
        }
        if (appStandbyBucket == 20) {
            return J2.WORKING_SET;
        }
        if (appStandbyBucket == 40) {
            return J2.RARE;
        }
        return null;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final Boolean a(ActivityManager activityManager) {
        return Boolean.valueOf(activityManager.isBackgroundRestricted());
    }
}
