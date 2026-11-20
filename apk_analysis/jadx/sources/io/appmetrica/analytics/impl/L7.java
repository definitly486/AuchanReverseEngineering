package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public abstract class L7 {
    public static final String a(C0727xh c0727xh) {
        JSONObject jSONObject;
        try {
            jSONObject = new JSONObject().put("dId", c0727xh.getDeviceId()).put("uId", c0727xh.getUuid()).put("appVer", c0727xh.getAppVersion()).put("appBuild", c0727xh.getAppBuildNumber()).put("kitBuildType", c0727xh.getAnalyticsSdkBuildType()).put("osVer", c0727xh.getOsVersion()).put("osApiLev", c0727xh.getOsApiLevel()).put("lang", c0727xh.getLocale()).put("root", c0727xh.getDeviceRootStatus()).put("app_debuggable", ((C0198d6) c0727xh).a).put(CommonUrlParts.APP_FRAMEWORK, c0727xh.getAppFramework()).put("attribution_id", c0727xh.r).put("analyticsSdkVersionName", c0727xh.getAnalyticsSdkVersionName()).put("kitBuildNumber", c0727xh.getAnalyticsSdkBuildNumber());
        } catch (Throwable unused) {
            jSONObject = new JSONObject();
        }
        return jSONObject.toString();
    }
}
