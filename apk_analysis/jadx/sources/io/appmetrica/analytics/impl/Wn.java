package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ValidationException;

/* JADX INFO: loaded from: classes3.dex */
public class Wn implements Ko {
    public final Ko a;

    public Wn(Ko ko) {
        this.a = ko;
    }

    @Override // io.appmetrica.analytics.impl.Ko
    public final Io a(Object obj) {
        Io ioA = this.a.a(obj);
        if (ioA.a) {
            return ioA;
        }
        throw new ValidationException(ioA.b);
    }

    public final Ko a() {
        return this.a;
    }
}
