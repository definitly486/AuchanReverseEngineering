package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.jvm.functions.Function4;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: LruCache.kt */
/* JADX INFO: loaded from: classes.dex */
public final class LruCacheKt {
    public static final <K, V> LruCache<K, V> lruCache(int i, final Function2<? super K, ? super V, Integer> sizeOf, final Function1<? super K, ? extends V> create, final Function4 onEntryRemoved) {
        Intrinsics.checkNotNullParameter(sizeOf, "sizeOf");
        Intrinsics.checkNotNullParameter(create, "create");
        Intrinsics.checkNotNullParameter(onEntryRemoved, "onEntryRemoved");
        return new LruCache(i) { // from class: androidx.collection.LruCacheKt.lruCache.4
            @Override // androidx.collection.LruCache
            protected int sizeOf(Object key, Object value) {
                Intrinsics.checkNotNullParameter(key, "key");
                Intrinsics.checkNotNullParameter(value, "value");
                return ((Number) sizeOf.invoke(key, value)).intValue();
            }

            @Override // androidx.collection.LruCache
            protected Object create(Object key) {
                Intrinsics.checkNotNullParameter(key, "key");
                return create.invoke(key);
            }

            @Override // androidx.collection.LruCache
            protected void entryRemoved(boolean z, Object key, Object oldValue, Object obj) {
                Intrinsics.checkNotNullParameter(key, "key");
                Intrinsics.checkNotNullParameter(oldValue, "oldValue");
                onEntryRemoved.invoke(Boolean.valueOf(z), key, oldValue, obj);
            }
        };
    }
}
