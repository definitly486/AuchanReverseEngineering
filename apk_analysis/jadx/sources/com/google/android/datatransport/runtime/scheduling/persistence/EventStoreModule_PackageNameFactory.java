package com.google.android.datatransport.runtime.scheduling.persistence;

import android.content.Context;
import com.google.android.datatransport.runtime.dagger.internal.DaggerGenerated;
import com.google.android.datatransport.runtime.dagger.internal.Factory;
import com.google.android.datatransport.runtime.dagger.internal.Preconditions;
import com.google.android.datatransport.runtime.dagger.internal.QualifierMetadata;
import com.google.android.datatransport.runtime.dagger.internal.ScopeMetadata;
import com.scanflow.datacapture.barinternal.javax.inject.Provider;

/* JADX INFO: loaded from: classes.dex */
@QualifierMetadata({"javax.inject.Named"})
@ScopeMetadata("javax.inject.Singleton")
@DaggerGenerated
public final class EventStoreModule_PackageNameFactory implements Factory<String> {
    private final Provider contextProvider;

    public EventStoreModule_PackageNameFactory(Provider provider) {
        this.contextProvider = provider;
    }

    @Override // com.google.android.datatransport.runtime.dagger.internal.Factory, com.scanflow.datacapture.barinternal.javax.inject.Provider
    public String get() {
        return packageName((Context) this.contextProvider.get());
    }

    public static EventStoreModule_PackageNameFactory create(Provider provider) {
        return new EventStoreModule_PackageNameFactory(provider);
    }

    public static String packageName(Context context) {
        return (String) Preconditions.checkNotNullFromProvides(EventStoreModule.packageName(context));
    }
}
