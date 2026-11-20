package io.appmetrica.analytics.impl;

import android.content.Context;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.coreapi.internal.identifiers.IdentifierStatus;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import io.appmetrica.analytics.internal.IdentifiersResult;
import java.util.Arrays;
import java.util.Collection;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.nm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0472nm {
    public final HashSet a;
    public final HashMap b;
    public final C0394km c;
    public List d;
    public HashMap e;
    public long f;
    public boolean g;
    public long h;
    public final C0517pf i;
    public final Q j;
    public final T3 k;
    public final P6 l;
    public final C0486oa m;
    public final C0460na n;
    public final Ho o;

    public C0472nm(Context context, C0517pf c0517pf) {
        this(c0517pf, new Q(), new T3(), C0584s4.l().a(context), new P6(), new C0486oa(), new C0460na(), new Ho());
    }

    public final synchronized boolean a(List list) {
        boolean zA;
        boolean z;
        try {
            zA = a(CollectionsKt.intersect(list, AbstractC0628tm.a));
            Iterator it = list.iterator();
            while (true) {
                if (!it.hasNext()) {
                    z = false;
                    break;
                }
                if (this.a.contains((String) it.next())) {
                    z = true;
                    break;
                }
            }
        } catch (Throwable th) {
            throw th;
        }
        return !zA || z || ((AbstractC0628tm.b.currentTimeSeconds() > this.h ? 1 : (AbstractC0628tm.b.currentTimeSeconds() == this.h ? 0 : -1)) > 0) || this.g;
    }

    public final void b(IdentifiersResult identifiersResult) {
        if (a(identifiersResult)) {
            return;
        }
        this.b.put("appmetrica_clids", identifiersResult);
    }

    public final void c() {
        C0539qa c0539qa;
        C0517pf c0517pfD = this.i.i((IdentifiersResult) this.b.get(StartupParamsCallback.APPMETRICA_UUID)).e((IdentifiersResult) this.b.get(StartupParamsCallback.APPMETRICA_DEVICE_ID)).d((IdentifiersResult) this.b.get(StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH)).a((IdentifiersResult) this.b.get("appmetrica_get_ad_url")).b((IdentifiersResult) this.b.get("appmetrica_report_ad_url")).e(this.f).h((IdentifiersResult) this.b.get("appmetrica_clids")).j(Wm.a((Map) this.e)).f((IdentifiersResult) this.b.get("appmetrica_google_adv_id")).g((IdentifiersResult) this.b.get("appmetrica_huawei_oaid")).j((IdentifiersResult) this.b.get("appmetrica_yandex_adv_id")).b(this.g).c(this.l.d).d(this.h);
        C0486oa c0486oa = this.m;
        synchronized (c0486oa) {
            c0539qa = c0486oa.b;
        }
        c0517pfD.a(c0539qa);
    }

    public final synchronized boolean b() {
        return a(Arrays.asList("appmetrica_clids", StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH, StartupParamsCallback.APPMETRICA_DEVICE_ID, "appmetrica_get_ad_url", "appmetrica_report_ad_url", StartupParamsCallback.APPMETRICA_UUID));
    }

    public C0472nm(C0517pf c0517pf, Q q, T3 t3, Pd pd, P6 p6, C0486oa c0486oa, C0460na c0460na, Ho ho) {
        HashSet hashSet = new HashSet();
        this.a = hashSet;
        this.b = new HashMap();
        this.c = new C0394km();
        hashSet.add("appmetrica_google_adv_id");
        hashSet.add("appmetrica_huawei_oaid");
        hashSet.add("appmetrica_yandex_adv_id");
        this.i = c0517pf;
        this.j = q;
        this.k = t3;
        this.l = p6;
        this.m = c0486oa;
        this.n = c0460na;
        this.o = ho;
        a(pd.a(), c0517pf.q());
        a(StartupParamsCallback.APPMETRICA_DEVICE_ID, c0517pf.j());
        a(StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH, c0517pf.i());
        a("appmetrica_get_ad_url", c0517pf.d());
        a("appmetrica_report_ad_url", c0517pf.e());
        b(c0517pf.o());
        a("appmetrica_google_adv_id", c0517pf.l());
        a("appmetrica_huawei_oaid", c0517pf.m());
        a("appmetrica_yandex_adv_id", c0517pf.r());
        p6.a(c0517pf.h());
        c0486oa.a(c0517pf.k());
        this.d = c0517pf.g();
        String strI = c0517pf.i((String) null);
        this.e = strI != null ? Wm.a(strI) : null;
        this.g = c0517pf.a(true);
        this.f = c0517pf.b(0L);
        this.h = c0517pf.n();
        c();
    }

    public final boolean a() {
        IdentifiersResult identifiersResult = (IdentifiersResult) this.b.get("appmetrica_clids");
        if (!a(identifiersResult) && identifiersResult.id.isEmpty()) {
            return Do.a((Map) this.e);
        }
        return true;
    }

    public final void a(IdentifiersResult identifiersResult, IdentifiersResult identifiersResult2) {
        if (identifiersResult != null) {
            Ho ho = this.o;
            String str = identifiersResult.id;
            ho.getClass();
            if (Ho.a(str)) {
                this.b.put(StartupParamsCallback.APPMETRICA_UUID, identifiersResult);
            }
        }
        String str2 = identifiersResult == null ? null : identifiersResult.id;
        String str3 = identifiersResult2.id;
        if (str2 == null || !(str3 == null || str2.equals(str3))) {
            C0263fk c0263fk = Dj.a;
            c0263fk.reportError((str2 == null ? "null_uuid" : "wrong_uuid").concat("_on_client"), "The only true uuid: " + str2 + "; backup uuid: " + str3);
        }
    }

    public static boolean a(IdentifiersResult identifiersResult) {
        return identifiersResult == null || identifiersResult.id == null;
    }

    public final void a(String str, IdentifiersResult identifiersResult) {
        if (identifiersResult == null || StringUtils.isNullOrEmpty(identifiersResult.id)) {
            return;
        }
        this.b.put(str, identifiersResult);
    }

    public final synchronized boolean a(Collection collection) {
        Boolean bool;
        String str;
        try {
            Iterator it = collection.iterator();
            while (it.hasNext()) {
                String str2 = (String) it.next();
                IdentifiersResult identifiersResult = (IdentifiersResult) this.b.get(str2);
                if (identifiersResult == null) {
                    identifiersResult = (IdentifiersResult) this.l.c.get(str2);
                }
                if (identifiersResult == null) {
                    C0539qa c0539qa = this.m.b;
                    if (!Intrinsics.areEqual(str2, "appmetrica_lib_ssl_enabled") || (bool = c0539qa.a) == null) {
                        identifiersResult = null;
                    } else {
                        boolean zBooleanValue = bool.booleanValue();
                        IdentifierStatus identifierStatus = c0539qa.b;
                        String str3 = c0539qa.c;
                        if (zBooleanValue) {
                            str = "true";
                        } else if (!zBooleanValue) {
                            str = "false";
                        } else {
                            throw new NoWhenBranchMatchedException();
                        }
                        identifiersResult = new IdentifiersResult(str, identifierStatus, str3);
                    }
                }
                if ("appmetrica_clids".equals(str2)) {
                    if (this.g || a(identifiersResult) || (identifiersResult.id.isEmpty() && !Do.a((Map) this.e))) {
                        return false;
                    }
                } else if ("appmetrica_lib_ssl_enabled".equals(str2)) {
                    if (identifiersResult == null) {
                        return false;
                    }
                } else if (identifiersResult == null || StringUtils.isNullOrEmpty(identifiersResult.id)) {
                    return false;
                }
            }
            return true;
        } catch (Throwable th) {
            throw th;
        }
    }
}
