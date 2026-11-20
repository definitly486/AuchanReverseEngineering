package com.google.android.datatransport.runtime.scheduling.persistence;

import android.content.Context;
import com.google.android.datatransport.runtime.dagger.internal.DaggerGenerated;
import com.google.android.datatransport.runtime.dagger.internal.Factory;
import com.google.android.datatransport.runtime.dagger.internal.QualifierMetadata;
import com.google.android.datatransport.runtime.dagger.internal.ScopeMetadata;
import com.scanflow.datacapture.barinternal.javax.inject.Provider;

/* JADX INFO: loaded from: classes.dex */
@QualifierMetadata({"javax.inject.Named"})
@ScopeMetadata
@DaggerGenerated
public final class SchemaManager_Factory implements Factory<SchemaManager> {
    private final Provider contextProvider;
    private final Provider dbNameProvider;
    private final Provider schemaVersionProvider;

    public SchemaManager_Factory(Provider provider, Provider provider2, Provider provider3) {
        this.contextProvider = provider;
        this.dbNameProvider = provider2;
        this.schemaVersionProvider = provider3;
    }

    @Override // com.google.android.datatransport.runtime.dagger.internal.Factory, com.scanflow.datacapture.barinternal.javax.inject.Provider
    public SchemaManager get() {
        return newInstance((Context) this.contextProvider.get(), (String) this.dbNameProvider.get(), ((Integer) this.schemaVersionProvider.get()).intValue());
    }

    public static SchemaManager_Factory create(Provider provider, Provider provider2, Provider provider3) {
        return new SchemaManager_Factory(provider, provider2, provider3);
    }

    public static SchemaManager newInstance(Context context, String str, int i) {
        return new SchemaManager(context, str, i);
    }
}
