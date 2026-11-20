package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import com.google.android.gms.common.internal.ImagesContract;
import io.appmetrica.analytics.coreutils.internal.parsing.RemoteConfigJsonUtils;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import io.appmetrica.analytics.networktasks.internal.RetryPolicyConfig;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.pm, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0524pm {
    public final Xa a;
    public final C0564ra b;
    public final Ti c;
    public final Ue d;
    public final Ym e;
    public final C0687w3 f;
    public final B2 g;
    public final Db h;
    public final Vm i;
    public final Ld j;
    public final Y9 k;

    public C0524pm() {
        this(new Db(), new Xa(), new C0564ra(), new Ti(), new Ue(), new Ym(), new C0687w3(), new B2(), new Vm(), new Ld(), new Y9());
    }

    public final void a(C0654um c0654um, Bb bb) {
        long jOptLong;
        long jOptLong2;
        String string;
        ArrayList arrayListA;
        JSONObject jSONObjectOptJSONObject;
        JSONObject jSONObjectOptJSONObject2;
        JSONObject jSONObjectOptJSONObject3;
        JSONObject jSONObjectOptJSONObject4 = bb.optJSONObject("queries");
        if (jSONObjectOptJSONObject4 != null && (jSONObjectOptJSONObject2 = jSONObjectOptJSONObject4.optJSONObject("list")) != null && (jSONObjectOptJSONObject3 = jSONObjectOptJSONObject2.optJSONObject("host")) != null) {
            c0654um.g = jSONObjectOptJSONObject3.optString(ImagesContract.URL, null);
        }
        Object jSONObject = new JSONObject();
        try {
            jSONObject = bb.get("distribution_customization");
        } catch (Throwable unused) {
        }
        JSONObject jSONObjectOptJSONObject5 = ((JSONObject) jSONObject).optJSONObject("clids");
        if (jSONObjectOptJSONObject5 != null) {
            HashMap map = new HashMap();
            Iterator<String> itKeys = jSONObjectOptJSONObject5.keys();
            while (itKeys.hasNext()) {
                String next = itKeys.next();
                JSONObject jSONObjectOptJSONObject6 = jSONObjectOptJSONObject5.optJSONObject(next);
                if (jSONObjectOptJSONObject6 != null && jSONObjectOptJSONObject6.has("value")) {
                    map.put(next, jSONObjectOptJSONObject6.getString("value"));
                }
            }
            c0654um.j = Wm.a((Map) map);
        }
        JSONObject jSONObjectOptJSONObject7 = bb.optJSONObject(CommonUrlParts.LOCALE);
        String string2 = "";
        c0654um.m = (jSONObjectOptJSONObject7 == null || (jSONObjectOptJSONObject = jSONObjectOptJSONObject7.optJSONObject("country")) == null || !jSONObjectOptJSONObject.optBoolean("reliable", false)) ? "" : jSONObjectOptJSONObject.optString("value", "");
        JSONObject jSONObjectOptJSONObject8 = bb.optJSONObject("time");
        if (jSONObjectOptJSONObject8 != null) {
            try {
                c0654um.l = Long.valueOf(jSONObjectOptJSONObject8.getLong("max_valid_difference_seconds"));
            } catch (Throwable unused2) {
            }
        }
        Mm mm = new Mm();
        JSONObject jSONObjectOptJSONObject9 = bb.optJSONObject("stat_sending");
        if (jSONObjectOptJSONObject9 != null) {
            mm.a = RemoteConfigJsonUtils.extractMillisFromSecondsOrDefault(jSONObjectOptJSONObject9, "disabled_reporting_interval_seconds", mm.a);
        }
        this.e.getClass();
        c0654um.p = new Xm(mm.a);
        this.b.getClass();
        Im im = new Im();
        try {
            Object jSONObject2 = new JSONObject();
            try {
                jSONObject2 = bb.get("features");
            } catch (Throwable unused3) {
            }
            JSONObject jSONObjectOptJSONObject10 = ((JSONObject) jSONObject2).optJSONObject("list");
            if (jSONObjectOptJSONObject10 != null) {
                A4 a4 = new A4();
                a4.a = C0564ra.a(jSONObjectOptJSONObject10, "permissions_collecting", im.a);
                a4.b = C0564ra.a(jSONObjectOptJSONObject10, "features_collecting", im.b);
                a4.c = C0564ra.a(jSONObjectOptJSONObject10, "google_aid", im.c);
                a4.d = C0564ra.a(jSONObjectOptJSONObject10, "sim_info", im.d);
                a4.e = C0564ra.a(jSONObjectOptJSONObject10, "huawei_oaid", im.e);
                a4.f = jSONObjectOptJSONObject10.has("ssl_pinning") ? Boolean.valueOf(jSONObjectOptJSONObject10.getJSONObject("ssl_pinning").getBoolean("enabled")) : null;
                c0654um.b = new C4(a4);
            }
        } catch (Throwable unused4) {
        }
        this.a.getClass();
        try {
            Object jSONObject3 = new JSONObject();
            try {
                jSONObject3 = bb.get("query_hosts");
            } catch (Throwable unused5) {
            }
            JSONObject jSONObjectOptJSONObject11 = ((JSONObject) jSONObject3).optJSONObject("list");
            if (jSONObjectOptJSONObject11 != null) {
                try {
                    string = jSONObjectOptJSONObject11.getJSONObject("get_ad").getJSONArray("urls").getString(0);
                } catch (Throwable unused6) {
                    string = "";
                }
                if (!TextUtils.isEmpty(string)) {
                    c0654um.d = string;
                }
                ArrayList arrayListA2 = Xa.a(jSONObjectOptJSONObject11, "report");
                if (!Do.a((Collection) arrayListA2)) {
                    c0654um.e = arrayListA2;
                }
                try {
                    string2 = jSONObjectOptJSONObject11.getJSONObject("report_ad").getJSONArray("urls").getString(0);
                } catch (Throwable unused7) {
                }
                if (!TextUtils.isEmpty(string2)) {
                    c0654um.f = string2;
                }
                ArrayList arrayListA3 = Xa.a(jSONObjectOptJSONObject11, "startup");
                if (!Do.a((Collection) arrayListA3)) {
                    c0654um.c = arrayListA3;
                }
                ArrayList arrayListA4 = Xa.a(jSONObjectOptJSONObject11, "diagnostic");
                if (!Do.a((Collection) arrayListA4)) {
                    c0654um.n = arrayListA4;
                }
                HashMap map2 = new HashMap();
                Iterator<String> itKeys2 = jSONObjectOptJSONObject11.keys();
                while (itKeys2.hasNext()) {
                    String next2 = itKeys2.next();
                    if (!Xa.a.contains(next2) && (arrayListA = Xa.a(jSONObjectOptJSONObject11, next2)) != null) {
                        map2.put(next2, arrayListA);
                    }
                }
                c0654um.o = map2;
            }
        } catch (Throwable unused8) {
        }
        this.c.getClass();
        Nm nm = new Nm();
        JSONObject jSONObjectOptJSONObject12 = bb.optJSONObject("retry_policy");
        int iOptInt = nm.w;
        int iOptInt2 = nm.x;
        if (jSONObjectOptJSONObject12 != null) {
            iOptInt = jSONObjectOptJSONObject12.optInt("max_interval_seconds", iOptInt);
            iOptInt2 = jSONObjectOptJSONObject12.optInt("exponential_multiplier", nm.x);
        }
        c0654um.q = new RetryPolicyConfig(iOptInt, iOptInt2);
        this.d.getClass();
        if (c0654um.b.a) {
            JSONObject jSONObjectOptJSONObject13 = bb.optJSONObject("permissions_collecting");
            Km km = new Km();
            if (jSONObjectOptJSONObject13 != null) {
                jOptLong = jSONObjectOptJSONObject13.optLong("check_interval_seconds", km.a);
                jOptLong2 = jSONObjectOptJSONObject13.optLong("force_send_interval_seconds", km.b);
            } else {
                jOptLong = km.a;
                jOptLong2 = km.b;
            }
            c0654um.k = new Se(jOptLong, jOptLong2);
        }
        C0687w3 c0687w3 = this.f;
        c0687w3.getClass();
        Fm fm = new Fm();
        JSONObject jSONObjectOptJSONObject14 = bb.optJSONObject("cache_control");
        if (jSONObjectOptJSONObject14 != null) {
            fm.a = RemoteConfigJsonUtils.extractMillisFromSecondsOrDefault(jSONObjectOptJSONObject14, "last_known_location_ttl", fm.a);
        }
        c0687w3.a.getClass();
        c0654um.r = new C0609t3(fm.a);
        this.g.getClass();
        B2.a(c0654um, bb);
        Vm vm = this.i;
        vm.getClass();
        JSONObject jSONObjectOptJSONObject15 = bb.optJSONObject("startup_update");
        Lm lm = new Lm();
        Integer numA = Cb.a(jSONObjectOptJSONObject15, "interval_seconds", null);
        if (numA != null) {
            lm.a = numA.intValue();
        }
        vm.a.getClass();
        c0654um.t = new Tm(lm.a);
        Map<String, C0593sd> mapB = this.j.a.b();
        Kd kd = new Kd(bb);
        LinkedHashMap linkedHashMap = new LinkedHashMap();
        for (Map.Entry<String, C0593sd> entry : mapB.entrySet()) {
            Object objInvoke = kd.invoke(entry);
            if (objInvoke != null) {
                linkedHashMap.put(entry.getKey(), objInvoke);
            }
        }
        c0654um.u = linkedHashMap;
        X9 x9 = this.k.a;
        Hm hm = new Hm();
        JSONObject jSONObjectOptJSONObject16 = bb.optJSONObject("external_attribution");
        if (jSONObjectOptJSONObject16 != null) {
            hm.a = RemoteConfigJsonUtils.extractMillisFromSecondsOrDefault(jSONObjectOptJSONObject16, "collecting_interval_seconds", hm.a);
        }
        x9.getClass();
        c0654um.v = new W9(hm.a);
    }

    public C0524pm(Db db, Xa xa, C0564ra c0564ra, Ti ti, Ue ue, Ym ym, C0687w3 c0687w3, B2 b2, Vm vm, Ld ld, Y9 y9) {
        this.a = xa;
        this.b = c0564ra;
        this.c = ti;
        this.d = ue;
        this.e = ym;
        this.f = c0687w3;
        this.g = b2;
        this.h = db;
        this.i = vm;
        this.j = ld;
        this.k = y9;
    }
}
