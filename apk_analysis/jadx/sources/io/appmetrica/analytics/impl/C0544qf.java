package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.qf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0544qf extends Sd implements To {
    public static final long d = 0;
    public static final int e = -1;
    public static final String f = "";
    public static final String g = "";
    public static final String r = "SESSION_";
    public static final C0595sf h = new C0595sf("PERMISSIONS_CHECK_TIME", null);
    public static final C0595sf i = new C0595sf("PROFILE_ID", null);
    public static final C0595sf j = new C0595sf("APP_ENVIRONMENT", null);
    public static final C0595sf k = new C0595sf("APP_ENVIRONMENT_REVISION", null);
    public static final C0595sf l = new C0595sf("LAST_APP_VERSION_WITH_FEATURES", null);
    public static final C0595sf m = new C0595sf("APPLICATION_FEATURES", null);
    public static final C0595sf n = new C0595sf("CERTIFICATES_SHA1_FINGERPRINTS", null);
    public static final C0595sf o = new C0595sf("VITAL_DATA", null);
    public static final C0595sf p = new C0595sf("SENT_EXTERNAL_ATTRIBUTIONS", null);
    public static final C0595sf q = new C0595sf("AUTO_COLLECTED_DATA_SUBSCRIBERS", null);
    public static final C0595sf s = new C0595sf("MAIN_REPORTER_EVENTS_TRIGGER_CONDITION_MET", null);

    public C0544qf(InterfaceC0280gb interfaceC0280gb) {
        super(interfaceC0280gb);
    }

    public final C0544qf a(C0372k0 c0372k0) {
        synchronized (this) {
            d(j.b, c0372k0.a);
            d(k.b, c0372k0.b);
        }
        return this;
    }

    public final void b(boolean z) {
        d(s.b, z);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf
    public final Set<String> c() {
        return this.a.b();
    }

    public final C0372k0 d() {
        C0372k0 c0372k0;
        synchronized (this) {
            c0372k0 = new C0372k0(this.a.getString(j.b, "{}"), this.a.getLong(k.b, 0L));
        }
        return c0372k0;
    }

    public final String e() {
        return this.a.getString(m.b, "");
    }

    public final Map<String, Long> f() {
        HashMap map = new HashMap();
        try {
            String string = this.a.getString(q.b, null);
            if (!TextUtils.isEmpty(string)) {
                JSONObject jSONObject = new JSONObject(string);
                Iterator<String> itKeys = jSONObject.keys();
                while (itKeys.hasNext()) {
                    String next = itKeys.next();
                    map.put(next, Long.valueOf(jSONObject.getLong(next)));
                }
            }
        } catch (Throwable unused) {
        }
        return map;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf, io.appmetrica.analytics.impl.Ol, io.appmetrica.analytics.impl.To
    public final void flushAsync() {
        this.a.flushAsync();
    }

    public final List<String> g() {
        String str = n.b;
        List list = Collections.EMPTY_LIST;
        String[] strArr = list == null ? null : (String[]) list.toArray(new String[list.size()]);
        String string = this.a.getString(str, null);
        if (!TextUtils.isEmpty(string)) {
            try {
                JSONArray jSONArray = new JSONArray(string);
                strArr = new String[jSONArray.length()];
                for (int i2 = 0; i2 < jSONArray.length(); i2++) {
                    strArr[i2] = jSONArray.optString(i2);
                }
            } catch (Throwable unused) {
            }
        }
        if (strArr == null) {
            return null;
        }
        return Arrays.asList(strArr);
    }

    public final int h() {
        return this.a.getInt(l.b, -1);
    }

    public final long i() {
        return this.a.getLong(h.b, 0L);
    }

    public final String j() {
        return this.a.getString(i.b, null);
    }

    public final Map<Integer, String> k() {
        HashMap map = new HashMap();
        try {
            String string = this.a.getString(p.b, null);
            if (string != null) {
                JSONObject jSONObject = new JSONObject(string);
                Iterator<String> itKeys = jSONObject.keys();
                while (itKeys.hasNext()) {
                    String next = itKeys.next();
                    map.put(Integer.valueOf(Integer.parseInt(next)), jSONObject.getString(next));
                }
            }
        } catch (Throwable unused) {
        }
        return map;
    }

    @Override // io.appmetrica.analytics.impl.To
    public final String b() {
        return this.a.getString(o.b, null);
    }

    public final String h(String str) {
        return this.a.getString(new C0595sf(r, str).b, "");
    }

    public final C0544qf i(String str) {
        return (C0544qf) d(m.b, str);
    }

    public final C0544qf j(String str) {
        return (C0544qf) d(i.b, str);
    }

    public final C0544qf e(String str, String str2) {
        return (C0544qf) d(new C0595sf(r, str).b, str2);
    }

    public final void b(Map<Integer, String> map) {
        JSONObject jSONObject = new JSONObject();
        for (Map.Entry<Integer, String> entry : map.entrySet()) {
            try {
                jSONObject.put(entry.getKey().toString(), entry.getValue());
            } catch (Throwable unused) {
            }
        }
        d(p.b, jSONObject.toString());
    }

    public final C0544qf a(long j2) {
        return (C0544qf) d(h.b, j2);
    }

    public final C0544qf a(int i2) {
        return (C0544qf) d(l.b, i2);
    }

    @Override // io.appmetrica.analytics.impl.Sd
    public final String g(String str) {
        return new C0595sf(str, null).b;
    }

    public final C0544qf a(List<String> list) {
        return (C0544qf) a(n.b, list);
    }

    public final boolean a(boolean z) {
        return this.a.getBoolean(s.b, z);
    }

    @Override // io.appmetrica.analytics.impl.To
    public final void a(String str) {
        d(o.b, str);
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0569rf, io.appmetrica.analytics.impl.To
    public final void a() {
        super.a();
    }

    public final void a(Map<String, Long> map) {
        JSONObject jSONObject = new JSONObject();
        for (Map.Entry<String, Long> entry : map.entrySet()) {
            try {
                jSONObject.put(entry.getKey(), entry.getValue());
            } catch (Throwable unused) {
            }
        }
        d(q.b, jSONObject.toString());
    }
}
