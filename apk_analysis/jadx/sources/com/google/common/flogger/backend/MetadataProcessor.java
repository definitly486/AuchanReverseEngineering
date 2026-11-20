package com.google.common.flogger.backend;

import com.google.common.flogger.MetadataKey;
import com.google.common.flogger.util.Checks;
import java.util.AbstractSet;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
public abstract class MetadataProcessor {
    private static final MetadataProcessor EMPTY_PROCESSOR = new MetadataProcessor() { // from class: com.google.common.flogger.backend.MetadataProcessor.1
        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <T> T getSingleValue(MetadataKey<T> metadataKey) {
            return null;
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <C> void handle(MetadataKey<?> metadataKey, MetadataHandler<C> metadataHandler, C c) {
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public int keyCount() {
            return 0;
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <C> void process(MetadataHandler<C> metadataHandler, C c) {
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public Set<MetadataKey<?>> keySet() {
            return Collections.EMPTY_SET;
        }
    };

    public abstract <T> T getSingleValue(MetadataKey<T> metadataKey);

    public abstract <C> void handle(MetadataKey<?> metadataKey, MetadataHandler<C> metadataHandler, C c);

    public abstract int keyCount();

    public abstract Set<MetadataKey<?>> keySet();

    public abstract <C> void process(MetadataHandler<C> metadataHandler, C c);

    public static MetadataProcessor forScopeAndLogSite(Metadata metadata, Metadata metadata2) {
        int size = metadata.size() + metadata2.size();
        if (size == 0) {
            return EMPTY_PROCESSOR;
        }
        if (size <= 28) {
            return getLightweightProcessor(metadata, metadata2);
        }
        return getSimpleProcessor(metadata, metadata2);
    }

    static MetadataProcessor getLightweightProcessor(Metadata metadata, Metadata metadata2) {
        return new LightweightProcessor(metadata, metadata2);
    }

    static MetadataProcessor getSimpleProcessor(Metadata metadata, Metadata metadata2) {
        return new SimpleProcessor(metadata, metadata2);
    }

    private MetadataProcessor() {
    }

    private static final class LightweightProcessor extends MetadataProcessor {
        private static final int MAX_LIGHTWEIGHT_ELEMENTS = 28;
        private final int keyCount;
        private final int[] keyMap;
        private final Metadata logged;
        private final Metadata scope;

        private LightweightProcessor(Metadata metadata, Metadata metadata2) {
            super();
            this.scope = (Metadata) Checks.checkNotNull(metadata, "scope metadata");
            this.logged = (Metadata) Checks.checkNotNull(metadata2, "logged metadata");
            int size = metadata.size() + metadata2.size();
            Checks.checkArgument(size <= 28, "metadata size too large");
            int[] iArr = new int[size];
            this.keyMap = iArr;
            this.keyCount = prepareKeyMap(iArr);
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <C> void process(MetadataHandler<C> metadataHandler, C c) {
            for (int i = 0; i < this.keyCount; i++) {
                int i2 = this.keyMap[i];
                dispatch(getKey(i2 & 31), i2, metadataHandler, c);
            }
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <C> void handle(MetadataKey<?> metadataKey, MetadataHandler<C> metadataHandler, C c) {
            int iIndexOf = indexOf(metadataKey, this.keyMap, this.keyCount);
            if (iIndexOf >= 0) {
                dispatch(metadataKey, this.keyMap[iIndexOf], metadataHandler, c);
            }
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <T> T getSingleValue(MetadataKey<T> metadataKey) {
            Checks.checkArgument(!metadataKey.canRepeat(), "key must be single valued");
            int iIndexOf = indexOf(metadataKey, this.keyMap, this.keyCount);
            if (iIndexOf >= 0) {
                return metadataKey.cast(getValue(this.keyMap[iIndexOf]));
            }
            return null;
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public int keyCount() {
            return this.keyCount;
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public Set<MetadataKey<?>> keySet() {
            return new AbstractSet<MetadataKey<?>>() { // from class: com.google.common.flogger.backend.MetadataProcessor.LightweightProcessor.1
                @Override // java.util.AbstractCollection, java.util.Collection, java.util.Set
                public int size() {
                    return LightweightProcessor.this.keyCount;
                }

                @Override // java.util.AbstractCollection, java.util.Collection, java.lang.Iterable, java.util.Set
                public Iterator<MetadataKey<?>> iterator() {
                    return new Iterator<MetadataKey<?>>() { // from class: com.google.common.flogger.backend.MetadataProcessor.LightweightProcessor.1.1
                        private int i = 0;

                        @Override // java.util.Iterator
                        public boolean hasNext() {
                            return this.i < LightweightProcessor.this.keyCount;
                        }

                        /* JADX WARN: Can't rename method to resolve collision */
                        @Override // java.util.Iterator
                        public MetadataKey<?> next() {
                            LightweightProcessor lightweightProcessor = LightweightProcessor.this;
                            int[] iArr = lightweightProcessor.keyMap;
                            int i = this.i;
                            this.i = i + 1;
                            return lightweightProcessor.getKey(iArr[i] & 31);
                        }

                        @Override // java.util.Iterator
                        public void remove() {
                            throw new UnsupportedOperationException();
                        }
                    };
                }
            };
        }

        private <T, C> void dispatch(MetadataKey<T> metadataKey, int i, MetadataHandler<C> metadataHandler, C c) {
            if (!metadataKey.canRepeat()) {
                metadataHandler.handle(metadataKey, metadataKey.cast(getValue(i)), c);
            } else {
                metadataHandler.handleRepeated(metadataKey, new ValueIterator(metadataKey, i), c);
            }
        }

        private final class ValueIterator<T> implements Iterator<T> {
            private final MetadataKey<T> key;
            private int mask;
            private int nextIndex;

            private ValueIterator(MetadataKey<T> metadataKey, int i) {
                this.key = metadataKey;
                int i2 = i & 31;
                this.nextIndex = i2;
                this.mask = i >>> (i2 + 5);
            }

            @Override // java.util.Iterator
            public boolean hasNext() {
                return this.nextIndex >= 0;
            }

            @Override // java.util.Iterator
            public T next() {
                T tCast = this.key.cast(LightweightProcessor.this.getValue(this.nextIndex));
                int i = this.mask;
                if (i != 0) {
                    int iNumberOfTrailingZeros = Integer.numberOfTrailingZeros(i) + 1;
                    this.mask >>>= iNumberOfTrailingZeros;
                    this.nextIndex += iNumberOfTrailingZeros;
                    return tCast;
                }
                this.nextIndex = -1;
                return tCast;
            }

            @Override // java.util.Iterator
            public void remove() {
                throw new UnsupportedOperationException();
            }
        }

        private int prepareKeyMap(int[] iArr) {
            int iIndexOf;
            long j = 0;
            int i = 0;
            int i2 = 0;
            while (i < iArr.length) {
                MetadataKey<?> key = getKey(i);
                long bloomFilterMask = key.getBloomFilterMask() | j;
                if (bloomFilterMask == j && (iIndexOf = indexOf(key, iArr, i2)) != -1) {
                    iArr[iIndexOf] = key.canRepeat() ? iArr[iIndexOf] | (1 << (i + 4)) : i;
                } else {
                    iArr[i2] = i;
                    i2++;
                }
                i++;
                j = bloomFilterMask;
            }
            return i2;
        }

        private int indexOf(MetadataKey<?> metadataKey, int[] iArr, int i) {
            for (int i2 = 0; i2 < i; i2++) {
                if (metadataKey.equals(getKey(iArr[i2] & 31))) {
                    return i2;
                }
            }
            return -1;
        }

        /* JADX INFO: Access modifiers changed from: private */
        public MetadataKey<?> getKey(int i) {
            int size = this.scope.size();
            return i >= size ? this.logged.getKey(i - size) : this.scope.getKey(i);
        }

        /* JADX INFO: Access modifiers changed from: private */
        public Object getValue(int i) {
            int size = this.scope.size();
            return i >= size ? this.logged.getValue(i - size) : this.scope.getValue(i);
        }
    }

    private static final class SimpleProcessor extends MetadataProcessor {
        private final Map<MetadataKey<?>, Object> map;

        private SimpleProcessor(Metadata metadata, Metadata metadata2) {
            super();
            LinkedHashMap linkedHashMap = new LinkedHashMap();
            addTo(linkedHashMap, metadata);
            addTo(linkedHashMap, metadata2);
            for (Map.Entry entry : linkedHashMap.entrySet()) {
                if (((MetadataKey) entry.getKey()).canRepeat()) {
                    entry.setValue(Collections.unmodifiableList((List) entry.getValue()));
                }
            }
            this.map = Collections.unmodifiableMap(linkedHashMap);
        }

        private static void addTo(Map<MetadataKey<?>, Object> map, Metadata metadata) {
            for (int i = 0; i < metadata.size(); i++) {
                MetadataKey<?> key = metadata.getKey(i);
                Object obj = map.get(key);
                if (key.canRepeat()) {
                    List arrayList = (List) obj;
                    if (arrayList == null) {
                        arrayList = new ArrayList();
                        map.put(key, arrayList);
                    }
                    arrayList.add(key.cast(metadata.getValue(i)));
                } else {
                    map.put(key, key.cast(metadata.getValue(i)));
                }
            }
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <C> void process(MetadataHandler<C> metadataHandler, C c) {
            for (Map.Entry<MetadataKey<?>, Object> entry : this.map.entrySet()) {
                dispatch(entry.getKey(), entry.getValue(), metadataHandler, c);
            }
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <C> void handle(MetadataKey<?> metadataKey, MetadataHandler<C> metadataHandler, C c) {
            Object obj = this.map.get(metadataKey);
            if (obj != null) {
                dispatch(metadataKey, obj, metadataHandler, c);
            }
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public <T> T getSingleValue(MetadataKey<T> metadataKey) {
            Checks.checkArgument(!metadataKey.canRepeat(), "key must be single valued");
            T t = (T) this.map.get(metadataKey);
            if (t != null) {
                return t;
            }
            return null;
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public int keyCount() {
            return this.map.size();
        }

        @Override // com.google.common.flogger.backend.MetadataProcessor
        public Set<MetadataKey<?>> keySet() {
            return this.map.keySet();
        }

        private static <T, C> void dispatch(MetadataKey<T> metadataKey, Object obj, MetadataHandler<C> metadataHandler, C c) {
            if (metadataKey.canRepeat()) {
                metadataHandler.handleRepeated(metadataKey, ((List) obj).iterator(), c);
            } else {
                metadataHandler.handle(metadataKey, obj, c);
            }
        }
    }
}
