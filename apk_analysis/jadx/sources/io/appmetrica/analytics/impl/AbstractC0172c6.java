package io.appmetrica.analytics.impl;

import android.content.Context;
import android.content.pm.ApplicationInfo;
import android.text.TextUtils;
import io.appmetrica.analytics.coreutils.internal.services.SafePackageManager;
import io.appmetrica.analytics.networktasks.internal.BaseRequestConfig;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.c6, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0172c6 extends BaseRequestConfig.ComponentLoader {
    public final SafePackageManager a;

    public AbstractC0172c6(Context context, String str) {
        this(context, str, new SafePackageManager());
    }

    @Override // io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.ComponentLoader, io.appmetrica.analytics.networktasks.internal.BaseRequestConfig.RequestConfigLoader
    /* JADX INFO: renamed from: a */
    public C0198d6 load(C0146b6 c0146b6) {
        C0198d6 c0198d6 = (C0198d6) super.load(c0146b6);
        String packageName = getContext().getPackageName();
        ApplicationInfo applicationInfo = this.a.getApplicationInfo(getContext(), getPackageName(), 0);
        if (applicationInfo != null) {
            int i = applicationInfo.flags;
            c0198d6.a = (i & 2) != 0 ? "1" : CommonUrlParts.Values.FALSE_INTEGER;
            c0198d6.b = (i & 1) == 0 ? CommonUrlParts.Values.FALSE_INTEGER : "1";
        } else if (TextUtils.equals(packageName, getPackageName())) {
            c0198d6.a = (getContext().getApplicationInfo().flags & 2) != 0 ? "1" : CommonUrlParts.Values.FALSE_INTEGER;
            c0198d6.b = (getContext().getApplicationInfo().flags & 1) == 0 ? CommonUrlParts.Values.FALSE_INTEGER : "1";
        } else {
            c0198d6.a = CommonUrlParts.Values.FALSE_INTEGER;
            c0198d6.b = CommonUrlParts.Values.FALSE_INTEGER;
        }
        C0706wm c0706wm = c0146b6.a;
        c0198d6.c = c0706wm;
        c0198d6.setRetryPolicyConfig(c0706wm.t);
        return c0198d6;
    }

    public AbstractC0172c6(Context context, String str, SafePackageManager safePackageManager) {
        super(context, str);
        this.a = safePackageManager;
    }
}
