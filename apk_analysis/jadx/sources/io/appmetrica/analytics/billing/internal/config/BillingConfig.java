package io.appmetrica.analytics.billing.internal.config;

import io.appmetrica.analytics.billing.impl.s;

/* JADX INFO: loaded from: classes3.dex */
public final class BillingConfig {
    private final int a;
    private final int b;

    public BillingConfig(int i, int i2) {
        this.a = i;
        this.b = i2;
    }

    public final int getFirstCollectingInappMaxAgeSeconds() {
        return this.b;
    }

    public final int getSendFrequencySeconds() {
        return this.a;
    }

    public String toString() {
        return "BillingConfig(sendFrequencySeconds=" + this.a + ", firstCollectingInappMaxAgeSeconds=" + this.b + ')';
    }

    public BillingConfig() {
        this(new s().a, new s().b);
    }
}
