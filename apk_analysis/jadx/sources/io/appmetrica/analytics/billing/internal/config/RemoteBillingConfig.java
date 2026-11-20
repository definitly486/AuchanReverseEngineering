package io.appmetrica.analytics.billing.internal.config;

import io.appmetrica.analytics.billing.impl.t;

/* JADX INFO: loaded from: classes3.dex */
public final class RemoteBillingConfig {
    private final boolean a;
    private final BillingConfig b;

    public RemoteBillingConfig(boolean z, BillingConfig billingConfig) {
        this.a = z;
        this.b = billingConfig;
    }

    public final BillingConfig getConfig() {
        return this.b;
    }

    public final boolean getEnabled() {
        return this.a;
    }

    public String toString() {
        return "RemoteBillingConfig(enabled=" + this.a + ", config=" + this.b + ')';
    }

    public RemoteBillingConfig() {
        this(new t().a, new BillingConfig());
    }
}
