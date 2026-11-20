package io.appmetrica.analytics.coreutils.internal.buffering;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes3.dex */
public final class MapMergingBuffer<K, V> implements TaskBuffer<Map<K, ? extends V>> {
    private final LinkedHashMap a = new LinkedHashMap();

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public List<Map<K, V>> getAndClear() {
        if (this.a.isEmpty()) {
            return CollectionsKt.emptyList();
        }
        Map map = MapsKt.toMap(this.a);
        this.a.clear();
        return CollectionsKt.listOf(map);
    }

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public boolean isEmpty() {
        return this.a.isEmpty();
    }

    @Override // io.appmetrica.analytics.coreutils.internal.buffering.TaskBuffer
    public void add(Map<K, ? extends V> map) {
        this.a.putAll(map);
    }
}
