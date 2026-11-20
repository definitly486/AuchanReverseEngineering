package io.appmetrica.analytics.impl;

import android.content.Context;
import java.util.LinkedHashMap;

/* JADX INFO: loaded from: classes3.dex */
public final class So {
    public final Context a;
    public final LinkedHashMap b = new LinkedHashMap();
    public final Oo c;
    public final Oo d;

    public So(Context context) {
        this.a = context;
        C0746ya c0746ya = new C0746ya(context, "appmetrica_vital.dat", Ka.k().w().e(), 0L, 8, null);
        this.c = new Oo(Ka.k().y(), c0746ya);
        this.d = new Oo(new C0621tf(Ka.k().B().e(context)), c0746ya);
    }

    public final Oo a() {
        return this.c;
    }

    public final Oo b() {
        return this.d;
    }
}
