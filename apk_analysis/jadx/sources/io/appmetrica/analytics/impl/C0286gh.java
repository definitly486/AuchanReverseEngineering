package io.appmetrica.analytics.impl;

import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.gh, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0286gh extends AbstractC0131ah {
    public final Po b;

    public C0286gh(C0455n5 c0455n5) {
        this(c0455n5, c0455n5.u());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        C0455n5 c0455n5 = this.a;
        if (!this.b.c()) {
            if (!this.b.d()) {
                E9 e9 = c0455n5.n;
                e9.c.b(C0249f6.a(c0249f6, EnumC0721xb.EVENT_TYPE_FIRST_ACTIVATION));
            }
            Po po = this.b;
            synchronized (po) {
                JSONObject jSONObjectA = po.a.a();
                if (!jSONObjectA.optBoolean("first_event_done", false)) {
                    po.a.a(jSONObjectA.put("first_event_done", true));
                }
                Qo qo = po.a;
                Qo.a(qo.a);
                Qo.a(qo.b);
            }
        }
        return false;
    }

    public C0286gh(C0455n5 c0455n5, Po po) {
        super(c0455n5);
        this.b = po;
    }
}
