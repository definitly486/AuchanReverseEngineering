package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import io.appmetrica.analytics.AppMetricaConfig;
import io.appmetrica.analytics.coreapi.internal.identifiers.IdentifierStatus;
import io.appmetrica.analytics.coreapi.internal.model.ScreenInfo;
import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import io.appmetrica.analytics.internal.IdentifiersResult;
import java.util.Collection;
import java.util.List;
import org.json.JSONArray;
import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.pf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0517pf extends Sd {
    public static final C0595sf d = new C0595sf("UUID_RESULT", null);
    public static final C0595sf e = new C0595sf("DEVICE_ID_RESULT", null);
    public static final C0595sf f = new C0595sf("DEVICE_ID_HASH_RESULT", null);
    public static final C0595sf g = new C0595sf("AD_URL_GET_RESULT", null);
    public static final C0595sf h = new C0595sf("AD_URL_REPORT_RESULT", null);
    public static final C0595sf i = new C0595sf("CUSTOM_HOSTS", null);
    public static final C0595sf j = new C0595sf("SERVER_TIME_OFFSET", null);
    public static final C0595sf k = new C0595sf("RESPONSE_CLIDS_RESULT", null);
    public static final C0595sf l = new C0595sf("CUSTOM_SDK_HOSTS", null);
    public static final C0595sf m = new C0595sf("CLIENT_CLIDS", null);
    public static final C0595sf n = new C0595sf("DEFERRED_DEEP_LINK_WAS_CHECKED", null);
    public static final C0595sf o = new C0595sf("API_LEVEL", null);
    public static final C0595sf p = new C0595sf("NEXT_STARTUP_TIME", null);
    public static final C0595sf q = new C0595sf("GAID", null);
    public static final C0595sf r = new C0595sf("HOAID", null);
    public static final C0595sf s = new C0595sf("YANDEX_ADV_ID", null);
    public static final C0595sf t = new C0595sf("CLIENT_CLIDS_CHANGED_AFTER_LAST_IDENTIFIERS_UPDATE", null);
    public static final C0595sf u = new C0595sf("SCREEN_INFO", null);
    public static final C0595sf v = new C0595sf("SCREEN_SIZE_CHECKED_BY_DEPRECATED", null);
    public static final C0595sf w = new C0595sf("FEATURES", null);
    public static final C0595sf x = new C0595sf("APPMETRICA_CLIENT_CONFIG", null);

    public C0517pf(InterfaceC0280gb interfaceC0280gb) {
        super(interfaceC0280gb);
    }

    public final boolean a(boolean z) {
        return this.a.getBoolean(t.b, z);
    }

    public final long b(long j2) {
        return this.a.getLong(j.a, j2);
    }

    public final C0517pf c(IdentifiersResult identifiersResult) {
        return a(l.b, identifiersResult);
    }

    public final IdentifiersResult d() {
        return h(g.b);
    }

    public final C0517pf f(IdentifiersResult identifiersResult) {
        return a(q.b, identifiersResult);
    }

    public final List<String> g() {
        String string = this.a.getString(i.b, null);
        if (TextUtils.isEmpty(string)) {
            return null;
        }
        return Cb.b(string);
    }

    public final IdentifiersResult h() {
        return h(l.b);
    }

    public final IdentifiersResult i() {
        return h(f.b);
    }

    public final IdentifiersResult j() {
        return h(e.b);
    }

    public final C0539qa k() {
        String string = this.a.getString(w.b, null);
        try {
            if (!TextUtils.isEmpty(string)) {
                JSONObject jSONObject = new JSONObject(string);
                return new C0539qa(JsonUtils.optBooleanOrNull(jSONObject, "libSslEnabled"), IdentifierStatus.from(JsonUtils.optStringOrNull(jSONObject, "STATUS")), JsonUtils.optStringOrNull(jSONObject, "ERROR_EXPLANATION"));
            }
        } catch (Throwable unused) {
        }
        return new C0539qa(null, IdentifierStatus.UNKNOWN, null);
    }

    public final IdentifiersResult l() {
        return h(q.b);
    }

    public final IdentifiersResult m() {
        return h(r.b);
    }

    public final long n() {
        return this.a.getLong(p.b, 0L);
    }

    public final IdentifiersResult o() {
        return h(k.b);
    }

    public final ScreenInfo p() {
        return Cb.e(this.a.getString(u.b, null));
    }

    public final IdentifiersResult q() {
        return h(d.b);
    }

    public final IdentifiersResult r() {
        return h(s.b);
    }

    public final boolean s() {
        return this.a.getBoolean(n.b, false);
    }

    public final boolean t() {
        return this.a.getBoolean(v.b, false);
    }

    public final C0517pf u() {
        return (C0517pf) d(n.b, true);
    }

    public final void v() {
        d(v.b, true);
    }

    public final IdentifiersResult e() {
        return h(h.b);
    }

    public final long a(long j2) {
        return this.a.getLong(o.b, j2);
    }

    public final C0517pf b(IdentifiersResult identifiersResult) {
        return a(h.b, identifiersResult);
    }

    public final C0517pf c(long j2) {
        return (C0517pf) d(o.b, j2);
    }

    public final C0517pf d(IdentifiersResult identifiersResult) {
        return a(f.b, identifiersResult);
    }

    public final AppMetricaConfig.Builder f() {
        String string = this.a.getString(x.b, null);
        if (string == null) {
            return null;
        }
        return new X3().a(string);
    }

    public final IdentifiersResult h(String str) {
        IdentifiersResult identifiersResult;
        try {
            String string = this.a.getString(str, null);
            if (string != null) {
                JSONObject jSONObject = new JSONObject(string);
                identifiersResult = new IdentifiersResult(JsonUtils.optStringOrNull(jSONObject, "ID"), IdentifierStatus.from(JsonUtils.optStringOrNull(jSONObject, "STATUS")), JsonUtils.optStringOrNull(jSONObject, "ERROR_EXPLANATION"));
            } else {
                identifiersResult = null;
            }
        } catch (Throwable unused) {
        }
        return identifiersResult == null ? new IdentifiersResult(null, IdentifierStatus.UNKNOWN, "no identifier in preferences") : identifiersResult;
    }

    public final C0517pf i(IdentifiersResult identifiersResult) {
        return a(d.b, identifiersResult);
    }

    public final C0517pf j(IdentifiersResult identifiersResult) {
        return a(s.b, identifiersResult);
    }

    public final C0517pf e(IdentifiersResult identifiersResult) {
        return a(e.b, identifiersResult);
    }

    public final C0517pf g(IdentifiersResult identifiersResult) {
        return a(r.b, identifiersResult);
    }

    public final C0517pf a(IdentifiersResult identifiersResult) {
        return a(g.b, identifiersResult);
    }

    public final C0517pf b(boolean z) {
        return (C0517pf) d(t.b, z);
    }

    public final C0517pf d(long j2) {
        return (C0517pf) d(p.b, j2);
    }

    public final String i(String str) {
        return this.a.getString(m.b, str);
    }

    public final C0517pf j(String str) {
        return (C0517pf) d(m.b, str);
    }

    public final C0517pf e(long j2) {
        return (C0517pf) d(j.b, j2);
    }

    @Override // io.appmetrica.analytics.impl.Sd
    public final String g(String str) {
        return new C0595sf(str, null).b;
    }

    public final C0517pf a(List<String> list) {
        return (C0517pf) d(i.b, Do.a((Collection) list) ? null : new JSONArray((Collection) list).toString());
    }

    public final C0517pf h(IdentifiersResult identifiersResult) {
        return a(k.b, identifiersResult);
    }

    public final C0517pf a(C0539qa c0539qa) {
        String str = w.b;
        JSONObject jSONObject = new JSONObject();
        try {
            jSONObject.putOpt("libSslEnabled", c0539qa.a).put("STATUS", c0539qa.b.getValue()).putOpt("ERROR_EXPLANATION", c0539qa.c);
        } catch (Throwable unused) {
        }
        return (C0517pf) d(str, jSONObject.toString());
    }

    @Override // io.appmetrica.analytics.impl.Sd, io.appmetrica.analytics.impl.AbstractC0569rf
    /* JADX INFO: renamed from: k, reason: merged with bridge method [inline-methods] */
    public final C0517pf e(String str) {
        return (C0517pf) f(new C0595sf(str, null).b);
    }

    public final void a(ScreenInfo screenInfo) {
        d(u.b, Cb.a(screenInfo));
    }

    public final void a(AppMetricaConfig appMetricaConfig) {
        d(x.b, appMetricaConfig.toJson());
    }

    public final C0517pf a(String str, IdentifiersResult identifiersResult) {
        String string;
        if (identifiersResult != null) {
            try {
                JSONObject jSONObject = new JSONObject();
                try {
                    jSONObject.put("ID", identifiersResult.id).put("STATUS", identifiersResult.status.getValue()).put("ERROR_EXPLANATION", identifiersResult.errorExplanation);
                } catch (Throwable unused) {
                }
                string = jSONObject.toString();
            } catch (Throwable unused2) {
                string = null;
            }
        } else {
            string = null;
        }
        if (string != null) {
            d(str, string);
        }
        return this;
    }
}
