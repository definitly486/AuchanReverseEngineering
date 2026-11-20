package io.appmetrica.analytics.impl;

import org.json.JSONObject;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.mj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0443mj extends AbstractC0131ah {
    public final Nf b;

    public C0443mj(C0455n5 c0455n5) {
        this(c0455n5, Ka.k().t());
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        JSONObject jSONObjectOptJSONObject;
        try {
            jSONObjectOptJSONObject = new JSONObject(c0249f6.getValue()).optJSONObject("preloadInfo");
        } catch (Throwable unused) {
            jSONObjectOptJSONObject = null;
        }
        this.b.b(Kf.a(jSONObjectOptJSONObject));
        return false;
    }

    public C0443mj(C0455n5 c0455n5, Nf nf) {
        super(c0455n5);
        this.b = nf;
    }
}
