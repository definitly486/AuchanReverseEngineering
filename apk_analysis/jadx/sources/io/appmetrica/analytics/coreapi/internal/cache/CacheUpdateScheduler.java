package io.appmetrica.analytics.coreapi.internal.cache;

/* JADX INFO: loaded from: classes3.dex */
public interface CacheUpdateScheduler {
    void onStateUpdated();

    void scheduleUpdateIfNeededNow();
}
