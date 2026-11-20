package io.appmetrica.analytics.impl;

import android.net.Uri;
import android.text.TextUtils;
import io.appmetrica.analytics.coreapi.internal.control.DataSendingRestrictionController;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdTrackingInfoResult;
import io.appmetrica.analytics.coreapi.internal.identifiers.AdvertisingIdsHolder;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import io.appmetrica.analytics.networktasks.internal.IParamsAppender;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.om, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0498om implements IParamsAppender {
    public final Ce a;
    public final Id b;
    public final C0204dc c = new C0204dc();

    public C0498om(Ce ce, Id id) {
        this.a = ce;
        this.b = id;
    }

    @Override // io.appmetrica.analytics.networktasks.internal.IParamsAppender
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final void appendParams(Uri.Builder builder, C0602sm c0602sm) {
        String str;
        builder.path("analytics/startup");
        builder.appendQueryParameter(this.a.a(CommonUrlParts.DEVICE_ID), c0602sm.getDeviceId());
        a(builder, Ka.I.h(), this.c);
        builder.appendQueryParameter(this.a.a(CommonUrlParts.APP_SET_ID), c0602sm.getAppSetId());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.APP_SET_ID_SCOPE), c0602sm.getAppSetIdScope());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.APP_PLATFORM), c0602sm.getAppPlatform());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.PROTOCOL_VERSION), c0602sm.getProtocolVersion());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.ANALYTICS_SDK_VERSION_NAME), c0602sm.getAnalyticsSdkVersionName());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.MODEL), c0602sm.getModel());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.MANUFACTURER), c0602sm.getManufacturer());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.OS_VERSION), c0602sm.getOsVersion());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.SCREEN_WIDTH), String.valueOf(c0602sm.getScreenWidth()));
        builder.appendQueryParameter(this.a.a(CommonUrlParts.SCREEN_HEIGHT), String.valueOf(c0602sm.getScreenHeight()));
        builder.appendQueryParameter(this.a.a(CommonUrlParts.SCREEN_DPI), String.valueOf(c0602sm.getScreenDpi()));
        builder.appendQueryParameter(this.a.a(CommonUrlParts.SCALE_FACTOR), String.valueOf(c0602sm.getScaleFactor()));
        builder.appendQueryParameter(this.a.a(CommonUrlParts.LOCALE), c0602sm.getLocale());
        builder.appendQueryParameter(this.a.a(CommonUrlParts.DEVICE_TYPE), c0602sm.getDeviceType());
        builder.appendQueryParameter(this.a.a("queries"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("query_hosts"), String.valueOf(2));
        String strA = this.a.a("features");
        List<String> listG = ((Ok) this.b).g();
        String[] strArr = {this.a.a("permissions_collecting"), this.a.a("features_collecting"), this.a.a("google_aid"), this.a.a("huawei_oaid"), this.a.a("sim_info"), this.a.a("ssl_pinning")};
        ArrayList arrayList = new ArrayList(listG);
        arrayList.addAll(Arrays.asList(strArr));
        builder.appendQueryParameter(strA, StringUtils.wrapFeatures((String[]) arrayList.toArray(new String[0])));
        builder.appendQueryParameter(this.a.a(CommonUrlParts.APP_ID), c0602sm.getPackageName());
        builder.appendQueryParameter(this.a.a("app_debuggable"), ((C0198d6) c0602sm).a);
        if (c0602sm.l) {
            String str2 = c0602sm.m;
            if (!TextUtils.isEmpty(str2)) {
                builder.appendQueryParameter(this.a.a("country_init"), str2);
            }
        } else {
            builder.appendQueryParameter(this.a.a("detect_locale"), String.valueOf(1));
        }
        I3 i3 = c0602sm.i;
        if (!Do.a(i3.a)) {
            builder.appendQueryParameter(this.a.a("distribution_customization"), String.valueOf(1));
            builder.appendQueryParameter(this.a.a("clids_set"), Wm.a(i3.a));
            int iOrdinal = i3.b.ordinal();
            if (iOrdinal == 1) {
                str = "api";
            } else if (iOrdinal != 2) {
                str = iOrdinal != 3 ? "" : "retail";
            } else {
                str = "satellite";
            }
            builder.appendQueryParameter(this.a.a("clids_set_source"), str);
            String str3 = c0602sm.f;
            String strA2 = c0602sm.g;
            if (TextUtils.isEmpty(str3)) {
                Eg eg = c0602sm.o.b;
                C0674vg c0674vgA = eg == null ? null : eg.a();
                if (c0674vgA != null) {
                    str3 = c0674vgA.a;
                    strA2 = AbstractC0648ug.a(c0674vgA.d);
                }
            }
            if (!TextUtils.isEmpty(str3)) {
                builder.appendQueryParameter(this.a.a("install_referrer"), str3);
                if (strA2 == null) {
                    strA2 = "null";
                }
                builder.appendQueryParameter(this.a.a("install_referrer_source"), strA2);
            }
        }
        String uuid = c0602sm.getUuid();
        if (!TextUtils.isEmpty(uuid)) {
            builder.appendQueryParameter(this.a.a(CommonUrlParts.UUID), uuid);
        }
        builder.appendQueryParameter(this.a.a("time"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("stat_sending"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("retry_policy"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("cache_control"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("permissions_collecting"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("app_system_flag"), ((C0198d6) c0602sm).b);
        builder.appendQueryParameter(this.a.a("attribution"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("startup_update"), String.valueOf(1));
        builder.appendQueryParameter(this.a.a("external_attribution"), String.valueOf(1));
        Map<String, Integer> mapC = ((Ok) this.b).c();
        for (String str4 : mapC.keySet()) {
            builder.appendQueryParameter(str4, String.valueOf(mapC.get(str4)));
        }
    }

    public final void a(Uri.Builder builder, DataSendingRestrictionController dataSendingRestrictionController, C0204dc c0204dc) {
        c0204dc.getClass();
        AdvertisingIdsHolder identifiers = Ka.I.c().getIdentifiers();
        if (identifiers != null && !dataSendingRestrictionController.isRestrictedForSdk()) {
            AdTrackingInfoResult google = identifiers.getGoogle();
            if (!google.isValid()) {
                builder.appendQueryParameter(this.a.a(CommonUrlParts.ADV_ID), "");
            } else {
                builder.appendQueryParameter(this.a.a(CommonUrlParts.ADV_ID), google.mAdTrackingInfo.advId);
            }
            AdTrackingInfoResult huawei = identifiers.getHuawei();
            if (!huawei.isValid()) {
                builder.appendQueryParameter(this.a.a(CommonUrlParts.HUAWEI_OAID), "");
            } else {
                builder.appendQueryParameter(this.a.a(CommonUrlParts.HUAWEI_OAID), huawei.mAdTrackingInfo.advId);
            }
            AdTrackingInfoResult yandex = identifiers.getYandex();
            if (!yandex.isValid()) {
                builder.appendQueryParameter(this.a.a(CommonUrlParts.YANDEX_ADV_ID), "");
                return;
            } else {
                builder.appendQueryParameter(this.a.a(CommonUrlParts.YANDEX_ADV_ID), yandex.mAdTrackingInfo.advId);
                return;
            }
        }
        builder.appendQueryParameter(this.a.a(CommonUrlParts.ADV_ID), "");
        builder.appendQueryParameter(this.a.a(CommonUrlParts.HUAWEI_OAID), "");
        builder.appendQueryParameter(this.a.a(CommonUrlParts.YANDEX_ADV_ID), "");
    }
}
