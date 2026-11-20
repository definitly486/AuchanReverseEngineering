package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import java.util.Map;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.fl, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0264fl {
    public final String a;
    public final C0135al b;
    public final C0238el c;
    public final IBinaryDataHelper d;

    public C0264fl(Context context, C0274g5 c0274g5) {
        c0274g5.a();
        this.a = "session_extras";
        this.b = new C0135al();
        this.c = new C0238el();
        this.d = Ka.k().B().a(context, c0274g5);
    }

    public final Map a() {
        try {
            byte[] bArr = this.d.get(this.a);
            if (bArr != null) {
                if (!(bArr.length == 0)) {
                    return this.b.toModel(this.c.toState(bArr));
                }
            }
        } catch (Throwable unused) {
        }
        C0135al c0135al = this.b;
        this.c.getClass();
        return c0135al.toModel(new C0187cl());
    }
}
