package io.appmetrica.analytics.impl;

import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.mk, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0444mk extends AbstractC0131ah {
    public C0444mk(C0455n5 c0455n5) {
        super(c0455n5);
    }

    public static final void b(C0444mk c0444mk) {
        Po po = c0444mk.a.t;
        synchronized (po) {
            JSONObject jSONObjectA = po.a.a();
            if (!jSONObjectA.optBoolean("referrer_handled", false)) {
                po.a.a(jSONObjectA.put("referrer_handled", true));
            }
            Qo qo = po.a;
            Qo.a(qo.a);
            Qo.a(qo.b);
        }
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        if (b()) {
            return false;
        }
        C0778zg c0778zgU = Ka.I.u();
        C0418lk c0418lk = new C0418lk(this);
        c0778zgU.getClass();
        c0778zgU.a.a(new C0236ej(c0418lk));
        return false;
    }

    public final boolean b() {
        boolean zOptBoolean;
        Po po = this.a.t;
        synchronized (po) {
            zOptBoolean = po.a.a().optBoolean("referrer_handled", false);
        }
        return zOptBoolean;
    }
}
