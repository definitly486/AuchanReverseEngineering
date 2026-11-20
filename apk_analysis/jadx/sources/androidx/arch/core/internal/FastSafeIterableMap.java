package androidx.arch.core.internal;

import java.util.HashMap;
import java.util.Map;

/* JADX INFO: loaded from: classes.dex */
public class FastSafeIterableMap<K, V> extends SafeIterableMap<K, V> {
    private final HashMap mHashMap = new HashMap();

    @Override // androidx.arch.core.internal.SafeIterableMap
    protected SafeIterableMap.Entry get(Object obj) {
        return (SafeIterableMap.Entry) this.mHashMap.get(obj);
    }

    @Override // androidx.arch.core.internal.SafeIterableMap
    public Object putIfAbsent(Object obj, Object obj2) {
        SafeIterableMap.Entry entry = get(obj);
        if (entry != null) {
            return entry.mValue;
        }
        this.mHashMap.put(obj, put(obj, obj2));
        return null;
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // androidx.arch.core.internal.SafeIterableMap
    public Object remove(Object obj) {
        Object objRemove = super.remove(obj);
        this.mHashMap.remove(obj);
        return objRemove;
    }

    public boolean contains(K k) {
        return this.mHashMap.containsKey(k);
    }

    public Map.Entry<K, V> ceil(K k) {
        if (contains(k)) {
            return ((SafeIterableMap.Entry) this.mHashMap.get(k)).mPrevious;
        }
        return null;
    }
}
