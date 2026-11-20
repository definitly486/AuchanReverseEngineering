package io.appmetrica.analytics.impl;

import io.appmetrica.analytics.ecommerce.ECommerceReferrer;

/* JADX INFO: loaded from: classes3.dex */
public final class Gg {
    public final String a;
    public final String b;
    public final C0599sj c;

    public Gg(ECommerceReferrer eCommerceReferrer) {
        this(eCommerceReferrer.getType(), eCommerceReferrer.getIdentifier(), eCommerceReferrer.getScreen() == null ? null : new C0599sj(eCommerceReferrer.getScreen()));
    }

    public final String toString() {
        return "ReferrerWrapper{type='" + this.a + "', identifier='" + this.b + "', screen=" + this.c + '}';
    }

    public Gg(String str, String str2, C0599sj c0599sj) {
        this.a = str;
        this.b = str2;
        this.c = c0599sj;
    }
}
