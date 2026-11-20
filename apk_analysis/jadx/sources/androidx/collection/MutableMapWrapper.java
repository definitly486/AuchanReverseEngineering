package androidx.collection;

import com.scanflow.datacapture.barinternal.kotlin.jvm.internal.markers.KMutableMap;
import java.util.Collection;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: ScatterMap.kt */
/* JADX INFO: loaded from: classes.dex */
final class MutableMapWrapper extends MapWrapper implements Map, KMutableMap {
    private MutableEntries _entries;
    private MutableKeys _keys;
    private MutableValues _values;
    private final MutableScatterMap parent;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public MutableMapWrapper(MutableScatterMap parent) {
        super(parent);
        Intrinsics.checkNotNullParameter(parent, "parent");
        this.parent = parent;
    }

    @Override // androidx.collection.MapWrapper
    public Set getEntries() {
        MutableEntries mutableEntries = this._entries;
        if (mutableEntries != null) {
            return mutableEntries;
        }
        MutableEntries mutableEntries2 = new MutableEntries(this.parent);
        this._entries = mutableEntries2;
        return mutableEntries2;
    }

    @Override // androidx.collection.MapWrapper
    public Set getKeys() {
        MutableKeys mutableKeys = this._keys;
        if (mutableKeys != null) {
            return mutableKeys;
        }
        MutableKeys mutableKeys2 = new MutableKeys(this.parent);
        this._keys = mutableKeys2;
        return mutableKeys2;
    }

    @Override // androidx.collection.MapWrapper
    public Collection getValues() {
        MutableValues mutableValues = this._values;
        if (mutableValues != null) {
            return mutableValues;
        }
        MutableValues mutableValues2 = new MutableValues(this.parent);
        this._values = mutableValues2;
        return mutableValues2;
    }

    @Override // androidx.collection.MapWrapper, java.util.Map
    public void clear() {
        this.parent.clear();
    }

    @Override // androidx.collection.MapWrapper, java.util.Map
    public Object remove(Object obj) {
        return this.parent.remove(obj);
    }

    @Override // androidx.collection.MapWrapper, java.util.Map
    public Object put(Object obj, Object obj2) {
        return this.parent.put(obj, obj2);
    }

    @Override // androidx.collection.MapWrapper, java.util.Map
    public void putAll(Map from) {
        Intrinsics.checkNotNullParameter(from, "from");
        for (Map.Entry entry : from.entrySet()) {
            this.parent.set(entry.getKey(), entry.getValue());
        }
    }
}
