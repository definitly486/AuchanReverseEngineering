package io.appmetrica.analytics.impl;

import kotlin.jvm.internal.Intrinsics;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Qo {
    public final To a;
    public final To b;
    public final Ro c;
    public JSONObject d;

    public Qo(To to, To to2, Ro ro) {
        this.a = to;
        this.b = to2;
        this.c = ro;
    }

    public static JSONObject b(To to) {
        try {
            String strB = to.b();
            return strB != null ? new JSONObject(strB) : new JSONObject();
        } catch (Throwable unused) {
            return new JSONObject();
        }
    }

    public final synchronized JSONObject a() {
        JSONObject jSONObject;
        try {
            if (this.d == null) {
                JSONObject jSONObjectA = this.c.a(b(this.a), b(this.b));
                this.d = jSONObjectA;
                a(jSONObjectA);
            }
            jSONObject = this.d;
            if (jSONObject == null) {
                Intrinsics.throwUninitializedPropertyAccessException("fileContents");
                jSONObject = null;
            }
        } catch (Throwable th) {
            throw th;
        }
        return jSONObject;
    }

    public final synchronized void a(JSONObject jSONObject) {
        String string = jSONObject.toString();
        try {
            this.a.a(string);
        } catch (Throwable unused) {
        }
        try {
            this.b.a(string);
        } catch (Throwable unused2) {
        }
    }

    public static void a(To to) {
        try {
            to.flushAsync();
        } catch (Throwable unused) {
        }
    }
}
