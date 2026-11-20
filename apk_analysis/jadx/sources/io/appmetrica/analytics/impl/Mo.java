package io.appmetrica.analytics.impl;

import android.text.TextUtils;
import org.json.JSONObject;

/* JADX INFO: loaded from: classes3.dex */
public final class Mo implements Lo {
    public final V8 a;

    public Mo() {
        this(new V8());
    }

    @Override // io.appmetrica.analytics.impl.Lo
    public final byte[] a(C0304h9 c0304h9, C0727xh c0727xh) {
        if (!((C0455n5) c0727xh.l).B() && !TextUtils.isEmpty(c0304h9.b)) {
            try {
                JSONObject jSONObject = new JSONObject(c0304h9.b);
                jSONObject.remove("preloadInfo");
                c0304h9.b = jSONObject.toString();
            } catch (Throwable unused) {
            }
        }
        return this.a.a(c0304h9, c0727xh);
    }

    public Mo(V8 v8) {
        this.a = v8;
    }
}
