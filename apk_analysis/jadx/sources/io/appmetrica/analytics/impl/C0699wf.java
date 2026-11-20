package io.appmetrica.analytics.impl;

import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.wf, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0699wf {
    public final String a;
    public final JSONObject b;
    public final EnumC0406l8 c;

    public C0699wf(String str, JSONObject jSONObject, EnumC0406l8 enumC0406l8) {
        this.a = str;
        this.b = jSONObject;
        this.c = enumC0406l8;
    }

    public final String toString() {
        return "Candidate{trackingId='" + this.a + "', additionalParams=" + this.b + ", source=" + this.c + '}';
    }
}
