package io.appmetrica.analytics.impl;

import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Uo implements InterfaceC0570rg {
    public final Oo a;
    public final String b = "vital";

    public Uo(Oo oo) {
        this.a = oo;
    }

    public final String a() {
        return this.b;
    }

    public final Eg b() {
        C0674vg c0674vgB = this.a.b();
        if (c0674vgB != null) {
            return new Dg(c0674vgB);
        }
        return null;
    }

    public final boolean c() {
        boolean zOptBoolean;
        Oo oo = this.a;
        synchronized (oo) {
            zOptBoolean = oo.a.a().optBoolean("referrer_checked", false);
        }
        return zOptBoolean;
    }

    public final void a(Eg eg) {
        this.a.a(eg.a());
        Oo oo = this.a;
        synchronized (oo) {
            JSONObject jSONObjectA = oo.a.a();
            if (!jSONObjectA.optBoolean("referrer_checked", false)) {
                oo.a.a(jSONObjectA.put("referrer_checked", true));
            }
            Qo qo = oo.a;
            Qo.a(qo.a);
            Qo.a(qo.b);
        }
    }
}
