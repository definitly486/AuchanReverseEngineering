package io.appmetrica.analytics.coreutils.internal.services;

import kotlin.jvm.internal.DefaultConstructorMarker;

/* JADX INFO: loaded from: classes3.dex */
public final class UtilityServiceConfiguration {
    private final long a;
    private final long b;

    public UtilityServiceConfiguration() {
        this(0L, 0L, 3, null);
    }

    public static /* synthetic */ UtilityServiceConfiguration copy$default(UtilityServiceConfiguration utilityServiceConfiguration, long j, long j2, int i, Object obj) {
        if ((i & 1) != 0) {
            j = utilityServiceConfiguration.a;
        }
        if ((i & 2) != 0) {
            j2 = utilityServiceConfiguration.b;
        }
        return utilityServiceConfiguration.copy(j, j2);
    }

    public final long component1() {
        return this.a;
    }

    public final long component2() {
        return this.b;
    }

    public final UtilityServiceConfiguration copy(long j, long j2) {
        return new UtilityServiceConfiguration(j, j2);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (!(obj instanceof UtilityServiceConfiguration)) {
            return false;
        }
        UtilityServiceConfiguration utilityServiceConfiguration = (UtilityServiceConfiguration) obj;
        return this.a == utilityServiceConfiguration.a && this.b == utilityServiceConfiguration.b;
    }

    public final long getInitialConfigTime() {
        return this.a;
    }

    public final long getLastUpdateConfigTime() {
        return this.b;
    }

    public int hashCode() {
        return Long.hashCode(this.b) + (Long.hashCode(this.a) * 31);
    }

    public String toString() {
        return "UtilityServiceConfiguration(initialConfigTime=" + this.a + ", lastUpdateConfigTime=" + this.b + ')';
    }

    public UtilityServiceConfiguration(long j, long j2) {
        this.a = j;
        this.b = j2;
    }

    public /* synthetic */ UtilityServiceConfiguration(long j, long j2, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? 0L : j, (i & 2) != 0 ? 0L : j2);
    }
}
