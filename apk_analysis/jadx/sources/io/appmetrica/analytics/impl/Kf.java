package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.coreutils.internal.parsing.JsonUtils;
import io.appmetrica.analytics.modulesapi.internal.client.adrevenue.AdRevenueConstants;
import kotlin.jvm.internal.Intrinsics;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Kf implements InterfaceC0432m8 {
    public final String a;
    public final JSONObject b;
    public final boolean c;
    public final boolean d;
    public final EnumC0406l8 e;

    public Kf(String str, JSONObject jSONObject, boolean z, boolean z2, EnumC0406l8 enumC0406l8) {
        this.a = str;
        this.b = jSONObject;
        this.c = z;
        this.d = z2;
        this.e = enumC0406l8;
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0432m8
    public final EnumC0406l8 a() {
        return this.e;
    }

    public final JSONObject b() {
        if (!this.c) {
            return null;
        }
        JSONObject jSONObject = new JSONObject();
        try {
            jSONObject.put("trackingId", this.a);
            if (this.b.length() > 0) {
                jSONObject.put("additionalParams", this.b);
            }
        } catch (Throwable unused) {
        }
        return jSONObject;
    }

    public final JSONObject c() {
        JSONObject jSONObject = new JSONObject();
        try {
            jSONObject.put("trackingId", this.a);
            jSONObject.put("additionalParams", this.b);
            jSONObject.put("wasSet", this.c);
            jSONObject.put("autoTracking", this.d);
            jSONObject.put(AdRevenueConstants.SOURCE_KEY, this.e.a);
        } catch (Throwable unused) {
        }
        return jSONObject;
    }

    public final String toString() {
        return "PreloadInfoState{trackingId='" + this.a + "', additionalParameters=" + this.b + ", wasSet=" + this.c + ", autoTrackingEnabled=" + this.d + ", source=" + this.e + '}';
    }

    public static Kf a(JSONObject jSONObject) {
        EnumC0406l8 enumC0406l8;
        String strOptStringOrNull = JsonUtils.optStringOrNull(jSONObject, "trackingId");
        JSONObject jSONObjectOptJsonObjectOrDefault = JsonUtils.optJsonObjectOrDefault(jSONObject, "additionalParams", new JSONObject());
        int i = 0;
        boolean zOptBooleanOrDefault = JsonUtils.optBooleanOrDefault(jSONObject, "wasSet", false);
        boolean zOptBooleanOrDefault2 = JsonUtils.optBooleanOrDefault(jSONObject, "autoTracking", false);
        String strOptStringOrNull2 = JsonUtils.optStringOrNull(jSONObject, AdRevenueConstants.SOURCE_KEY);
        EnumC0406l8.b.getClass();
        EnumC0406l8[] enumC0406l8ArrValues = EnumC0406l8.values();
        int length = enumC0406l8ArrValues.length;
        while (true) {
            if (i >= length) {
                enumC0406l8 = null;
                break;
            }
            enumC0406l8 = enumC0406l8ArrValues[i];
            if (Intrinsics.areEqual(enumC0406l8.a, strOptStringOrNull2)) {
                break;
            }
            i++;
        }
        if (enumC0406l8 == null) {
            enumC0406l8 = EnumC0406l8.c;
        }
        return new Kf(strOptStringOrNull, jSONObjectOptJsonObjectOrDefault, zOptBooleanOrDefault, zOptBooleanOrDefault2, enumC0406l8);
    }
}
