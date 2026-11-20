package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.Revenue;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.bj, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public final class C0159bj implements Ko {
    public final Jo a = new Jo();

    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(Revenue revenue) {
        Io io2;
        Jo jo = this.a;
        C0466ng c0466ng = new C0466ng();
        Integer num = revenue.quantity;
        if (num == null || num.intValue() > 0) {
            io2 = new Io(c0466ng, true, "");
        } else {
            io2 = new Io(c0466ng, false, "Invalid quantity value " + num);
        }
        List<Io> listAsList = Arrays.asList(io2);
        jo.getClass();
        return jo.a(listAsList);
    }
}
