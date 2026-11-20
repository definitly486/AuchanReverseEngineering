package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import org.json.JSONException;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Po {
    public final Qo a;

    public Po(C0544qf c0544qf, To to, String str) {
        this.a = new Qo(c0544qf, to, new Ro() { // from class: io.appmetrica.analytics.impl.Po$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.Ro
            public final JSONObject a(JSONObject jSONObject, JSONObject jSONObject2) {
                return Po.a(jSONObject, jSONObject2);
            }
        });
    }

    public static final JSONObject a(JSONObject jSONObject, JSONObject jSONObject2) throws JSONException {
        JSONObject jSONObject3 = new JSONObject();
        Boolean bool = Boolean.FALSE;
        jSONObject3.put("first_event_done", JsonUtils.optBooleanOrNullable(jSONObject2, "first_event_done", JsonUtils.optBooleanOrNullable(jSONObject, "first_event_done", bool)));
        jSONObject3.put("init_event_done", JsonUtils.optBooleanOrNullable(jSONObject2, "init_event_done", JsonUtils.optBooleanOrNullable(jSONObject, "init_event_done", bool)));
        jSONObject3.put("report_request_id", Cb.a(jSONObject2, "report_request_id", Cb.a(jSONObject, "report_request_id", -1)));
        jSONObject3.put("global_number", JsonUtils.optLongOrDefault(jSONObject2, "global_number", JsonUtils.optLongOrDefault(jSONObject, "global_number", 0L)));
        jSONObject3.put("session_id", JsonUtils.optLongOrDefault(jSONObject2, "session_id", JsonUtils.optLongOrDefault(jSONObject, "session_id", -1L)));
        jSONObject3.put("referrer_handled", JsonUtils.optBooleanOrNullable(jSONObject2, "referrer_handled", JsonUtils.optBooleanOrNullable(jSONObject, "referrer_handled", bool)));
        jSONObject3.put("numbers_of_type", JsonUtils.optJsonObjectOrNullable(jSONObject2, "numbers_of_type", JsonUtils.optJsonObjectOrNull(jSONObject, "numbers_of_type")));
        jSONObject3.put("open_id", Cb.a(jSONObject2, "open_id", Cb.a(jSONObject, "open_id", 1)));
        jSONObject3.put("attribution_id", Cb.a(jSONObject2, "attribution_id", Cb.a(jSONObject, "attribution_id", 1)));
        jSONObject3.put("last_migration_api_level", Cb.a(jSONObject2, "last_migration_api_level", Cb.a(jSONObject, "last_migration_api_level", 0)));
        jSONObject3.put("external_attribution_window_start", JsonUtils.optLongOrDefault(jSONObject2, "external_attribution_window_start", JsonUtils.optLongOrDefault(jSONObject, "external_attribution_window_start", -1L)));
        return jSONObject3;
    }

    public final synchronized void b(long j) {
        JSONObject jSONObjectA = this.a.a();
        if (jSONObjectA.optLong("session_id", -1L) != j) {
            this.a.a(jSONObjectA.put("session_id", j));
        }
    }

    public final synchronized boolean c() {
        return this.a.a().optBoolean("first_event_done", false);
    }

    public final synchronized boolean d() {
        return this.a.a().optBoolean("init_event_done", false);
    }

    public final synchronized void c(int i) {
        JSONObject jSONObjectA = this.a.a();
        if (jSONObjectA.optInt("open_id", 1) != i) {
            this.a.a(jSONObjectA.put("open_id", i));
        }
    }

    public final synchronized int b() {
        return this.a.a().optInt("open_id", 1);
    }

    public final synchronized void b(int i) {
        JSONObject jSONObjectA = this.a.a();
        if (jSONObjectA.optInt("last_migration_api_level", 0) != i) {
            this.a.a(jSONObjectA.put("last_migration_api_level", i));
        }
        Qo qo = this.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }

    public final synchronized int a() {
        return this.a.a().optInt("attribution_id", 1);
    }

    public final synchronized void a(int i) {
        JSONObject jSONObjectA = this.a.a();
        if (jSONObjectA.optInt("attribution_id", 1) == i) {
            return;
        }
        this.a.a(jSONObjectA.put("attribution_id", i));
        Qo qo = this.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }

    public final synchronized void a(long j) {
        JSONObject jSONObjectA = this.a.a();
        if (jSONObjectA.optLong("external_attribution_window_start", -1L) != j) {
            this.a.a(jSONObjectA.put("external_attribution_window_start", j));
        }
        Qo qo = this.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }
}
