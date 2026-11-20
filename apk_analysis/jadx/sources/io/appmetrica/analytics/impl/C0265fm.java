package io.appmetrica.analytics.impl;

import android.os.Bundle;
import android.os.Handler;
import android.text.TextUtils;
import io.appmetrica.analytics.AdvIdentifiersResult;
import io.appmetrica.analytics.StartupParamsCallback;
import io.appmetrica.analytics.coreapi.internal.identifiers.SdkIdentifiers;
import io.appmetrica.analytics.coreutils.internal.collection.CollectionUtils;
import io.appmetrica.analytics.internal.IdentifiersResult;
import io.appmetrica.analytics.logger.appmetrica.internal.PublicLogger;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.WeakHashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.fm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0265fm implements InterfaceC0291gm {
    public static final Map k = Collections.unmodifiableMap(new C0188cm());
    public final Ji b;
    public final C0472nm c;
    public final Handler d;
    public PublicLogger e;
    public HashMap i;
    public final List a = Arrays.asList(StartupParamsCallback.APPMETRICA_UUID, StartupParamsCallback.APPMETRICA_DEVICE_ID, StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH, "appmetrica_get_ad_url", "appmetrica_report_ad_url", "appmetrica_clids");
    public final Object g = new Object();
    public final WeakHashMap h = new WeakHashMap();
    public boolean j = false;
    public final C0214dm f = new C0214dm(this);

    public C0265fm(Ji ji, C0472nm c0472nm, Handler handler) {
        this.b = ji;
        this.c = c0472nm;
        this.d = handler;
    }

    public final void a(StartupParamsCallback startupParamsCallback, List<String> list, Map<String, String> map) {
        synchronized (this.g) {
            try {
                C0472nm c0472nm = this.c;
                c0472nm.getClass();
                if (!Do.a((Map) map) && !Do.a(map, c0472nm.e)) {
                    c0472nm.e = new HashMap(map);
                    c0472nm.g = true;
                    c0472nm.c();
                }
                a(startupParamsCallback, list);
                if (this.c.a((List) list)) {
                    a(list, new C0239em(this, startupParamsCallback), map, true);
                } else {
                    a(new Bundle(), startupParamsCallback);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    /* JADX WARN: Code duplicated, block: B:11:0x0082 A[Catch: all -> 0x007f, TryCatch #0 {all -> 0x007f, blocks: (B:4:0x0063, B:6:0x0071, B:14:0x0096, B:16:0x00c5, B:17:0x00cc, B:19:0x00d2, B:20:0x00d9, B:22:0x00ee, B:25:0x00f9, B:26:0x0105, B:23:0x00f3, B:11:0x0082, B:13:0x008f), top: B:32:0x0063 }] */
    /* JADX WARN: Code duplicated, block: B:13:0x008f A[Catch: all -> 0x007f, TryCatch #0 {all -> 0x007f, blocks: (B:4:0x0063, B:6:0x0071, B:14:0x0096, B:16:0x00c5, B:17:0x00cc, B:19:0x00d2, B:20:0x00d9, B:22:0x00ee, B:25:0x00f9, B:26:0x0105, B:23:0x00f3, B:11:0x0082, B:13:0x008f), top: B:32:0x0063 }] */
    public final void b(Bundle bundle) {
        String str;
        IdentifiersResult identifiersResultA = C0350j4.a(bundle, "Uuid");
        IdentifiersResult identifiersResultA2 = C0350j4.a(bundle, "DeviceId");
        IdentifiersResult identifiersResultA3 = C0350j4.a(bundle, "DeviceIdHash");
        IdentifiersResult identifiersResultA4 = C0350j4.a(bundle, "AdUrlReport");
        IdentifiersResult identifiersResultA5 = C0350j4.a(bundle, "AdUrlGet");
        IdentifiersResult identifiersResultA6 = C0350j4.a(bundle, "Clids");
        IdentifiersResult identifiersResultA7 = C0350j4.a(bundle, "RequestClids");
        IdentifiersResult identifiersResultA8 = C0350j4.a(bundle, "GAID");
        IdentifiersResult identifiersResultA9 = C0350j4.a(bundle, "HOAID");
        IdentifiersResult identifiersResultA10 = C0350j4.a(bundle, "YANDEX_ADV_ID");
        IdentifiersResult identifiersResultA11 = C0350j4.a(bundle, "CUSTOM_SDK_HOSTS");
        long j = bundle.getLong("ServerTimeOffset");
        long j2 = bundle.getLong("NextStartupTime");
        C0539qa c0539qaA = C0350j4.a(bundle);
        Bundle bundle2 = bundle.getBundle("module_configs");
        C0472nm c0472nm = this.c;
        synchronized (c0472nm) {
            try {
                IdentifiersResult identifiersResult = (IdentifiersResult) c0472nm.b.get(StartupParamsCallback.APPMETRICA_UUID);
                if (identifiersResult != null) {
                    Ho ho = c0472nm.o;
                    String str2 = identifiersResult.id;
                    ho.getClass();
                    if (!Ho.a(str2)) {
                        Ho ho2 = c0472nm.o;
                        str = identifiersResultA.id;
                        ho2.getClass();
                        if (Ho.a(str)) {
                            c0472nm.b.put(StartupParamsCallback.APPMETRICA_UUID, identifiersResultA);
                        }
                    }
                } else {
                    Ho ho3 = c0472nm.o;
                    str = identifiersResultA.id;
                    ho3.getClass();
                    if (Ho.a(str)) {
                        c0472nm.b.put(StartupParamsCallback.APPMETRICA_UUID, identifiersResultA);
                    }
                }
                c0472nm.a(StartupParamsCallback.APPMETRICA_DEVICE_ID, identifiersResultA2);
                c0472nm.a(StartupParamsCallback.APPMETRICA_DEVICE_ID_HASH, identifiersResultA3);
                c0472nm.b.put("appmetrica_google_adv_id", identifiersResultA8);
                c0472nm.b.put("appmetrica_huawei_oaid", identifiersResultA9);
                c0472nm.b.put("appmetrica_yandex_adv_id", identifiersResultA10);
                c0472nm.l.a(identifiersResultA11);
                c0472nm.m.a(c0539qaA);
                if (!C0472nm.a(identifiersResultA5)) {
                    c0472nm.b.put("appmetrica_get_ad_url", identifiersResultA5);
                }
                if (!C0472nm.a(identifiersResultA4)) {
                    c0472nm.b.put("appmetrica_report_ad_url", identifiersResultA4);
                }
                c0472nm.f = j;
                T3 t3 = c0472nm.k;
                HashMap map = c0472nm.e;
                HashMap mapA = Cb.a(identifiersResultA7.id);
                t3.getClass();
                if (Do.a((Map) map) ? Do.a((Map) mapA) : map.equals(mapA)) {
                    c0472nm.b.put("appmetrica_clids", identifiersResultA6);
                    c0472nm.g = false;
                }
                c0472nm.h = j2;
                c0472nm.c();
            } catch (Throwable th) {
                throw th;
            }
        }
        C0584s4.l().m().a(bundle2, new SdkIdentifiers(identifiersResultA.id, identifiersResultA2.id, identifiersResultA3.id));
        h();
    }

    public final S6 c() {
        return this.f;
    }

    public final String d() {
        IdentifiersResult identifiersResult = (IdentifiersResult) this.c.b.get(StartupParamsCallback.APPMETRICA_DEVICE_ID);
        if (identifiersResult == null) {
            return null;
        }
        return identifiersResult.id;
    }

    public final C0590sa e() {
        C0539qa c0539qa;
        C0472nm c0472nm = this.c;
        C0460na c0460na = c0472nm.n;
        C0486oa c0486oa = c0472nm.m;
        synchronized (c0486oa) {
            c0539qa = c0486oa.b;
        }
        c0460na.getClass();
        Boolean bool = c0539qa.a;
        return new C0590sa();
    }

    public final long f() {
        return this.c.f;
    }

    public final String g() {
        IdentifiersResult identifiersResult = (IdentifiersResult) this.c.b.get(StartupParamsCallback.APPMETRICA_UUID);
        if (identifiersResult == null) {
            return null;
        }
        return identifiersResult.id;
    }

    public final void h() {
        WeakHashMap weakHashMap = new WeakHashMap();
        for (Map.Entry entry : this.h.entrySet()) {
            List list = (List) entry.getValue();
            if (this.c.a((Collection) list)) {
                weakHashMap.put((StartupParamsCallback) entry.getKey(), list);
            }
        }
        Iterator it = weakHashMap.entrySet().iterator();
        while (it.hasNext()) {
            StartupParamsCallback startupParamsCallback = (StartupParamsCallback) ((Map.Entry) it.next()).getKey();
            if (startupParamsCallback != null) {
                a(new Bundle(), startupParamsCallback);
            }
        }
        weakHashMap.clear();
    }

    public final void i() {
        synchronized (this.g) {
            try {
                if (!this.j || this.c.b()) {
                    this.j = true;
                    a(this.a, this.f, this.i, false);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void a(Bundle bundle) {
        b(bundle, null);
    }

    public final void a(PublicLogger publicLogger) {
        this.e = publicLogger;
    }

    public final void a(List list, S6 s6, Map map, boolean z) {
        T6 t6 = new T6(this.d, s6);
        Ji ji = this.b;
        ji.getClass();
        Bundle bundle = new Bundle();
        bundle.putParcelable("io.appmetrica.analytics.impl.IdentifiersData", new C0617tb(t6, list, map, z));
        EnumC0721xb enumC0721xb = EnumC0721xb.EVENT_TYPE_UNDEFINED;
        PublicLogger anonymousInstance = PublicLogger.getAnonymousInstance();
        Set set = Q9.a;
        C0196d4 c0196d4 = new C0196d4("", "", 1536, 0, anonymousInstance);
        c0196d4.m = bundle;
        V4 v4 = ji.a;
        ji.a(Ji.a(c0196d4, v4), v4, 1, (Map) null);
    }

    public final void a(Map<String, String> map) {
        if (Do.a((Map) map)) {
            return;
        }
        synchronized (this.g) {
            try {
                HashMap mapB = Wm.b(map);
                this.i = mapB;
                this.b.a(mapB);
                C0472nm c0472nm = this.c;
                c0472nm.getClass();
                if (!Do.a((Map) mapB) && !Do.a(mapB, c0472nm.e)) {
                    c0472nm.e = new HashMap(mapB);
                    c0472nm.g = true;
                    c0472nm.c();
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void b(Bundle bundle, StartupParamsCallback startupParamsCallback) {
        synchronized (this.g) {
            try {
                b(bundle);
                h();
                if (startupParamsCallback != null) {
                    a(bundle, startupParamsCallback);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void a(String str) {
        synchronized (this.g) {
            this.b.a(str);
        }
    }

    public final void b(List<String> list) {
        synchronized (this.g) {
            try {
                List list2 = this.c.d;
                if (Do.a((Collection) list)) {
                    if (!Do.a((Collection) list2)) {
                        C0472nm c0472nm = this.c;
                        c0472nm.d = null;
                        c0472nm.i.a((List<String>) null);
                        this.b.a((List) null);
                    }
                } else if (!Do.a(list, list2)) {
                    C0472nm c0472nm2 = this.c;
                    c0472nm2.d = list;
                    c0472nm2.i.a(list);
                    this.b.a(list);
                } else {
                    this.b.a(list2);
                }
            } catch (Throwable th) {
                throw th;
            }
        }
    }

    public final void a(Bundle bundle, StartupParamsCallback startupParamsCallback) {
        EnumC0136am enumC0136am;
        if (this.h.containsKey(startupParamsCallback)) {
            List list = (List) this.h.get(startupParamsCallback);
            if (this.c.a((Collection) list)) {
                startupParamsCallback.onReceive(a(list));
            } else {
                StartupParamsCallback.Reason reason = null;
                if (bundle.containsKey("startup_error_key_code")) {
                    int i = bundle.getInt("startup_error_key_code");
                    enumC0136am = EnumC0136am.UNKNOWN;
                    if (i == 1) {
                        enumC0136am = EnumC0136am.NETWORK;
                    } else if (i == 2) {
                        enumC0136am = EnumC0136am.PARSE;
                    }
                } else {
                    enumC0136am = null;
                }
                if (enumC0136am == null) {
                    if (!this.c.a()) {
                        PublicLogger publicLogger = this.e;
                        if (publicLogger != null) {
                            publicLogger.warning("Clids error. Passed clids: %s, and clids from server are empty.", this.i);
                        }
                        reason = new StartupParamsCallback.Reason("INCONSISTENT_CLIDS");
                    } else {
                        enumC0136am = EnumC0136am.UNKNOWN;
                    }
                }
                if (reason == null) {
                    reason = (StartupParamsCallback.Reason) CollectionUtils.getOrDefault(k, enumC0136am, StartupParamsCallback.Reason.UNKNOWN);
                }
                startupParamsCallback.onRequestError(reason, a(list));
            }
            this.h.remove(startupParamsCallback);
            if (this.h.isEmpty()) {
                C0554r0 c0554r0 = this.b.d;
                synchronized (c0554r0.f) {
                    c0554r0.c = false;
                    c0554r0.c();
                }
            }
        }
    }

    public final void b(String str) {
        synchronized (this.g) {
            this.b.b(str);
        }
    }

    public final Map<String, String> b() {
        IdentifiersResult identifiersResult = (IdentifiersResult) this.c.b.get("appmetrica_clids");
        String str = identifiersResult == null ? null : identifiersResult.id;
        if (!TextUtils.isEmpty(str)) {
            return Cb.a(str);
        }
        return this.i;
    }

    public final StartupParamsCallback.Result a(List list) {
        HashMap map = new HashMap();
        C0472nm c0472nm = this.c;
        synchronized (c0472nm) {
            try {
                Iterator it = list.iterator();
                while (it.hasNext()) {
                    String str = (String) it.next();
                    IdentifiersResult identifiersResult = (IdentifiersResult) c0472nm.b.get(str);
                    if (identifiersResult != null) {
                        map.put(str, c0472nm.c.a(identifiersResult));
                    }
                }
                c0472nm.l.a(list, map);
                c0472nm.m.a(list, map);
            } catch (Throwable th) {
                throw th;
            }
        }
        return new StartupParamsCallback.Result(map);
    }

    public final void a(StartupParamsCallback startupParamsCallback, List list) {
        if (this.h.isEmpty()) {
            C0554r0 c0554r0 = this.b.d;
            synchronized (c0554r0.f) {
                c0554r0.c = true;
                c0554r0.b();
            }
        }
        this.h.put(startupParamsCallback, list);
    }

    public final AdvIdentifiersResult a() {
        C0472nm c0472nm = this.c;
        Q q = c0472nm.j;
        IdentifiersResult identifiersResult = (IdentifiersResult) c0472nm.b.get("appmetrica_google_adv_id");
        IdentifiersResult identifiersResult2 = (IdentifiersResult) c0472nm.b.get("appmetrica_huawei_oaid");
        IdentifiersResult identifiersResult3 = (IdentifiersResult) c0472nm.b.get("appmetrica_yandex_adv_id");
        q.getClass();
        return new AdvIdentifiersResult(Q.a(identifiersResult), Q.a(identifiersResult2), Q.a(identifiersResult3));
    }
}
