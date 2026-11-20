package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.IReporter;
import java.util.HashMap;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.ch, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0183ch extends AbstractC0131ah {
    public final IReporter b;

    public C0183ch(C0455n5 c0455n5, IReporter iReporter) {
        super(c0455n5);
        this.b = iReporter;
    }

    @Override // io.appmetrica.analytics.impl.AbstractC0131ah
    public final boolean a(C0249f6 c0249f6) {
        C0153bd c0153bd = (C0153bd) C0153bd.c.get(c0249f6.d);
        HashMap map = new HashMap();
        map.put("type", c0153bd.a);
        map.put("delivery_method", c0153bd.b);
        this.b.reportEvent("crash_saved", map);
        return false;
    }
}
