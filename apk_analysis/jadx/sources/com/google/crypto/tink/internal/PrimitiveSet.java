package com.google.crypto.tink.internal;

import com.google.crypto.tink.CryptoFormat;
import com.google.crypto.tink.Key;
import com.google.crypto.tink.KeyStatus;
import com.google.crypto.tink.Parameters;
import com.google.crypto.tink.proto.KeyStatusType;
import com.google.crypto.tink.proto.Keyset;
import com.google.crypto.tink.util.Bytes;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.security.GeneralSecurityException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/* JADX INFO: loaded from: classes2.dex */
public final class PrimitiveSet<P> {
    private final MonitoringAnnotations annotations;
    private final Map<Bytes, List<Entry<P>>> entries;
    private final List<Entry<P>> entriesInKeysetOrder;
    private final Entry<P> primary;
    private final Class<P> primitiveClass;
    private final PrimitiveConstructor.PrimitiveConstructionFunction<Key, P> primitiveConstructionFunction;

    public static final class Entry<P> implements KeysetHandleInterface.Entry {
        private final boolean isPrimary;
        private final Key key;
        private final int keyId;
        private final Bytes outputPrefix;
        private final KeyStatus status;

        private Entry(Bytes bytes, KeyStatus keyStatus, int i, Key key, boolean z) {
            this.outputPrefix = bytes;
            this.status = keyStatus;
            this.keyId = i;
            this.key = key;
            this.isPrimary = z;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public KeyStatus getStatus() {
            return this.status;
        }

        final Bytes getOutputPrefix() {
            return this.outputPrefix;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public int getId() {
            return this.keyId;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public Key getKey() {
            return this.key;
        }

        public Parameters getParameters() {
            Key key = this.key;
            if (key == null) {
                return null;
            }
            return key.getParameters();
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface.Entry
        public boolean isPrimary() {
            return this.isPrimary;
        }
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static <P> void storeEntryInPrimitiveSet(Entry<P> entry, Map<Bytes, List<Entry<P>>> map, List<Entry<P>> list) {
        ArrayList arrayList = new ArrayList();
        arrayList.add(entry);
        List<Entry<P>> listPut = map.put(entry.getOutputPrefix(), Collections.unmodifiableList(arrayList));
        if (listPut != null) {
            ArrayList arrayList2 = new ArrayList();
            arrayList2.addAll(listPut);
            arrayList2.add(entry);
            map.put(entry.getOutputPrefix(), Collections.unmodifiableList(arrayList2));
        }
        list.add(entry);
    }

    Entry<P> getPrimary() {
        return this.primary;
    }

    public MonitoringAnnotations getAnnotations() {
        return this.annotations;
    }

    private class KeysetHandleImpl implements KeysetHandleInterface {
        private KeysetHandleImpl() {
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface
        public KeysetHandleInterface.Entry getPrimary() {
            return PrimitiveSet.this.primary;
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface
        public int size() {
            return PrimitiveSet.this.entriesInKeysetOrder.size();
        }

        @Override // com.google.crypto.tink.internal.KeysetHandleInterface
        public KeysetHandleInterface.Entry getAt(int i) {
            return (KeysetHandleInterface.Entry) PrimitiveSet.this.entriesInKeysetOrder.get(i);
        }
    }

    public KeysetHandleInterface getKeysetHandle() {
        return new KeysetHandleImpl();
    }

    public P getPrimitiveForEntry(KeysetHandleInterface.Entry entry) {
        return this.primitiveConstructionFunction.constructPrimitive(entry.getKey());
    }

    Collection<List<Entry<P>>> getAll() {
        return this.entries.values();
    }

    List<Entry<P>> getAllInKeysetOrder() {
        return Collections.unmodifiableList(this.entriesInKeysetOrder);
    }

    private PrimitiveSet(Map<Bytes, List<Entry<P>>> map, List<Entry<P>> list, Entry<P> entry, MonitoringAnnotations monitoringAnnotations, PrimitiveConstructor.PrimitiveConstructionFunction<Key, P> primitiveConstructionFunction, Class<P> cls) {
        this.entries = map;
        this.entriesInKeysetOrder = list;
        this.primary = entry;
        this.primitiveConstructionFunction = primitiveConstructionFunction;
        this.primitiveClass = cls;
        this.annotations = monitoringAnnotations;
    }

    public Class<P> getPrimitiveClass() {
        return this.primitiveClass;
    }

    public static class Builder<P> {
        private MonitoringAnnotations annotations;
        private Map<Bytes, List<Entry<P>>> entries;
        private final List<Entry<P>> entriesInKeysetOrder;
        private Entry<P> primary;
        private final Class<P> primitiveClass;
        private PrimitiveConstructor.PrimitiveConstructionFunction<Key, P> primitiveConstructionFunction;

        public static /* synthetic */ Object $r8$lambda$uJehxU2nEm2f3Zt3gVst33MVRjQ(Key key) throws GeneralSecurityException {
            throw new GeneralSecurityException("No PrimitiveConstructionFunction specified");
        }

        @CanIgnoreReturnValue
        private Builder<P> addEntry(Key key, Keyset.Key key2, boolean z) throws GeneralSecurityException {
            if (this.entries == null) {
                throw new IllegalStateException("addEntry cannot be called after build");
            }
            if (key2.getStatus() != KeyStatusType.ENABLED) {
                throw new GeneralSecurityException("only ENABLED key is allowed");
            }
            Entry<P> entry = new Entry<>(Bytes.copyFrom(CryptoFormat.getOutputPrefix(key2)), KeyStatus.ENABLED, key2.getKeyId(), key, z);
            PrimitiveSet.storeEntryInPrimitiveSet(entry, this.entries, this.entriesInKeysetOrder);
            if (!z) {
                return this;
            }
            if (this.primary != null) {
                throw new IllegalStateException("you cannot set two primary primitives");
            }
            this.primary = entry;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder<P> add(Key key, Keyset.Key key2) {
            return addEntry(key, key2, false);
        }

        @CanIgnoreReturnValue
        public Builder<P> addPrimary(Key key, Keyset.Key key2) {
            return addEntry(key, key2, true);
        }

        @CanIgnoreReturnValue
        public Builder<P> setAnnotations(MonitoringAnnotations monitoringAnnotations) {
            if (this.entries == null) {
                throw new IllegalStateException("setAnnotations cannot be called after build");
            }
            this.annotations = monitoringAnnotations;
            return this;
        }

        @CanIgnoreReturnValue
        public Builder<P> addPrimitiveConstructor(PrimitiveConstructor.PrimitiveConstructionFunction<Key, P> primitiveConstructionFunction) {
            this.primitiveConstructionFunction = primitiveConstructionFunction;
            return this;
        }

        public PrimitiveSet<P> build() {
            Map<Bytes, List<Entry<P>>> map = this.entries;
            if (map == null) {
                throw new IllegalStateException("build cannot be called twice");
            }
            PrimitiveSet<P> primitiveSet = new PrimitiveSet<>(map, this.entriesInKeysetOrder, this.primary, this.annotations, this.primitiveConstructionFunction, this.primitiveClass);
            this.entries = null;
            return primitiveSet;
        }

        private Builder(Class<P> cls) {
            this.entries = new HashMap();
            this.entriesInKeysetOrder = new ArrayList();
            this.primitiveConstructionFunction = new PrimitiveConstructor.PrimitiveConstructionFunction() { // from class: com.google.crypto.tink.internal.PrimitiveSet$Builder$$ExternalSyntheticLambda0
                @Override // com.google.crypto.tink.internal.PrimitiveConstructor.PrimitiveConstructionFunction
                public final Object constructPrimitive(Key key) {
                    return PrimitiveSet.Builder.$r8$lambda$uJehxU2nEm2f3Zt3gVst33MVRjQ(key);
                }
            };
            this.primitiveClass = cls;
            this.annotations = MonitoringAnnotations.EMPTY;
        }
    }

    public static <P> Builder<P> newBuilder(Class<P> cls) {
        return new Builder<>(cls);
    }
}
