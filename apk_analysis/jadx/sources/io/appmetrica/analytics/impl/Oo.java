package io.appmetrica.analytics.impl;

import android.util.Base64;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONException;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Oo {
    public final Qo a;

    public Oo(C0621tf c0621tf, C0746ya c0746ya) {
        this.a = new Qo(c0621tf, c0746ya, new Ro() { // from class: io.appmetrica.analytics.impl.Oo$$ExternalSyntheticLambda0
            @Override // io.appmetrica.analytics.impl.Ro
            public final JSONObject a(JSONObject jSONObject, JSONObject jSONObject2) {
                return Oo.a(jSONObject, jSONObject2);
            }
        });
    }

    public final synchronized void a(C0674vg c0674vg) {
        String str;
        if (c0674vg != null) {
            try {
                str = new String(Base64.encode(c0674vg.a(), 0), Charsets.UTF_8);
            } catch (Throwable th) {
                throw th;
            }
        } else {
            str = null;
        }
        JSONObject jSONObjectA = this.a.a();
        if (!Intrinsics.areEqual(JsonUtils.optStringOrNull(jSONObjectA, "referrer"), str)) {
            this.a.a(jSONObjectA.put("referrer", str));
        }
        Qo qo = this.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }

    public final synchronized void b(String str) {
        JSONObject jSONObjectA = this.a.a();
        if (!Intrinsics.areEqual(JsonUtils.optStringOrNull(jSONObjectA, "device_id_hash"), str)) {
            this.a.a(jSONObjectA.put("device_id_hash", str));
        }
        Qo qo = this.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }

    /* JADX WARN: Code duplicated, block: B:12:0x0026  */
    public final synchronized C0674vg b() {
        C0674vg c0674vg;
        String strOptStringOrNull = JsonUtils.optStringOrNull(this.a.a(), "referrer");
        if (strOptStringOrNull != null) {
            try {
                byte[] bArrDecode = Base64.decode(strOptStringOrNull.getBytes(Charsets.UTF_8), 0);
                if (bArrDecode == null || bArrDecode.length == 0) {
                    c0674vg = null;
                } else {
                    c0674vg = new C0674vg(bArrDecode);
                }
            } catch (Throwable unused) {
            }
        } else {
            c0674vg = null;
        }
        return c0674vg;
    }

    public static final JSONObject a(JSONObject jSONObject, JSONObject jSONObject2) throws JSONException {
        JSONObject jSONObject3 = new JSONObject();
        jSONObject3.put("device_id", JsonUtils.optStringOrNullable(jSONObject2, "device_id", JsonUtils.optStringOrNull(jSONObject, "device_id")));
        jSONObject3.put("device_id_hash", JsonUtils.optStringOrNullable(jSONObject2, "device_id_hash", JsonUtils.optStringOrNull(jSONObject, "device_id_hash")));
        jSONObject3.put("referrer", JsonUtils.optStringOrNullable(jSONObject2, "referrer", JsonUtils.optStringOrNull(jSONObject, "referrer")));
        jSONObject3.put("referrer_checked", JsonUtils.optBooleanOrNullable(jSONObject2, "referrer_checked", JsonUtils.optBooleanOrNullable(jSONObject, "referrer_checked", Boolean.FALSE)));
        jSONObject3.put("last_migration_api_level", Cb.a(jSONObject2, "last_migration_api_level", Cb.a(jSONObject, "last_migration_api_level", -1)));
        return jSONObject3;
    }

    public final synchronized void a(String str) {
        JSONObject jSONObjectA = this.a.a();
        if (!Intrinsics.areEqual(JsonUtils.optStringOrNull(jSONObjectA, "device_id"), str)) {
            this.a.a(jSONObjectA.put("device_id", str));
        }
        Qo qo = this.a;
        Qo.a(qo.a);
        Qo.a(qo.b);
    }

    public final synchronized String a() {
        return JsonUtils.optStringOrNull(this.a.a(), "device_id_hash");
    }
}
