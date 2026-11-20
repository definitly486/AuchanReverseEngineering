package com.google.android.datatransport.runtime.scheduling.persistence;

import com.google.android.datatransport.runtime.dagger.internal.DaggerGenerated;
import com.google.android.datatransport.runtime.dagger.internal.Factory;
import com.google.android.datatransport.runtime.dagger.internal.QualifierMetadata;
import com.google.android.datatransport.runtime.dagger.internal.ScopeMetadata;
import com.google.android.datatransport.runtime.time.Clock;
import com.scanflow.datacapture.barinternal.javax.inject.Provider;

/* JADX INFO: loaded from: classes.dex */
@QualifierMetadata({"com.google.android.datatransport.runtime.time.WallTime", "com.google.android.datatransport.runtime.time.Monotonic", "javax.inject.Named"})
@ScopeMetadata("javax.inject.Singleton")
@DaggerGenerated
public final class SQLiteEventStore_Factory implements Factory<SQLiteEventStore> {
    private final Provider clockProvider;
    private final Provider configProvider;
    private final Provider packageNameProvider;
    private final Provider schemaManagerProvider;
    private final Provider wallClockProvider;

    public SQLiteEventStore_Factory(Provider provider, Provider provider2, Provider provider3, Provider provider4, Provider provider5) {
        this.wallClockProvider = provider;
        this.clockProvider = provider2;
        this.configProvider = provider3;
        this.schemaManagerProvider = provider4;
        this.packageNameProvider = provider5;
    }

    @Override // com.google.android.datatransport.runtime.dagger.internal.Factory, com.scanflow.datacapture.barinternal.javax.inject.Provider
    public SQLiteEventStore get() {
        return newInstance((Clock) this.wallClockProvider.get(), (Clock) this.clockProvider.get(), this.configProvider.get(), this.schemaManagerProvider.get(), this.packageNameProvider);
    }

    public static SQLiteEventStore_Factory create(Provider provider, Provider provider2, Provider provider3, Provider provider4, Provider provider5) {
        return new SQLiteEventStore_Factory(provider, provider2, provider3, provider4, provider5);
    }

    public static SQLiteEventStore newInstance(Clock clock, Clock clock2, Object obj, Object obj2, Provider provider) {
        return new SQLiteEventStore(clock, clock2, (EventStoreConfig) obj, (SchemaManager) obj2, provider);
    }
}
