package com.google.common.flogger.context;

import com.google.common.flogger.util.Checks;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.AbstractMap;
import java.util.AbstractSet;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.ConcurrentModificationException;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.NoSuchElementException;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
public final class Tags {
    private final LightweightTagMap map;
    private static final Comparator<Object> VALUE_COMPARATOR = new Comparator<Object>() { // from class: com.google.common.flogger.context.Tags.1
        @Override // java.util.Comparator
        public int compare(Object obj, Object obj2) {
            Type typeOf = Type.of(obj);
            Type typeOf2 = Type.of(obj2);
            return typeOf == typeOf2 ? typeOf.compare(obj, obj2) : typeOf.compareTo(typeOf2);
        }
    };
    private static final Comparator<KeyValuePair> KEY_VALUE_COMPARATOR = new Comparator<KeyValuePair>() { // from class: com.google.common.flogger.context.Tags.2
        @Override // java.util.Comparator
        public int compare(KeyValuePair keyValuePair, KeyValuePair keyValuePair2) {
            int iCompareTo = keyValuePair.key.compareTo(keyValuePair2.key);
            if (iCompareTo != 0) {
                return iCompareTo;
            }
            if (keyValuePair.value == null) {
                return keyValuePair2.value != null ? -1 : 0;
            }
            if (keyValuePair2.value != null) {
                return Tags.VALUE_COMPARATOR.compare(keyValuePair.value, keyValuePair2.value);
            }
            return 1;
        }
    };
    private static final Tags EMPTY_TAGS = new Tags(new LightweightTagMap(Collections.EMPTY_LIST));

    private enum Type {
        BOOLEAN { // from class: com.google.common.flogger.context.Tags.Type.1
            @Override // com.google.common.flogger.context.Tags.Type
            int compare(Object obj, Object obj2) {
                return ((Boolean) obj).compareTo((Boolean) obj2);
            }
        },
        STRING { // from class: com.google.common.flogger.context.Tags.Type.2
            @Override // com.google.common.flogger.context.Tags.Type
            int compare(Object obj, Object obj2) {
                return ((String) obj).compareTo((String) obj2);
            }
        },
        LONG { // from class: com.google.common.flogger.context.Tags.Type.3
            @Override // com.google.common.flogger.context.Tags.Type
            int compare(Object obj, Object obj2) {
                return ((Long) obj).compareTo((Long) obj2);
            }
        },
        DOUBLE { // from class: com.google.common.flogger.context.Tags.Type.4
            @Override // com.google.common.flogger.context.Tags.Type
            int compare(Object obj, Object obj2) {
                return ((Double) obj).compareTo((Double) obj2);
            }
        };

        abstract int compare(Object obj, Object obj2);

        /* JADX INFO: Access modifiers changed from: private */
        public static Type of(Object obj) {
            if (obj instanceof String) {
                return STRING;
            }
            if (obj instanceof Boolean) {
                return BOOLEAN;
            }
            if (obj instanceof Long) {
                return LONG;
            }
            if (obj instanceof Double) {
                return DOUBLE;
            }
            throw new AssertionError("invalid tag type: " + obj.getClass());
        }
    }

    private static final class KeyValuePair {
        private final String key;
        private final Object value;

        private KeyValuePair(String str, Object obj) {
            this.key = str;
            this.value = obj;
        }
    }

    public static final class Builder {
        private final List<KeyValuePair> keyValuePairs = new ArrayList();

        @CanIgnoreReturnValue
        public Builder addTag(String str) {
            return addImpl(str, null);
        }

        @CanIgnoreReturnValue
        public Builder addTag(String str, String str2) {
            Checks.checkArgument(str2 != null, "tag value");
            return addImpl(str, str2);
        }

        @CanIgnoreReturnValue
        public Builder addTag(String str, boolean z) {
            return addImpl(str, Boolean.valueOf(z));
        }

        @CanIgnoreReturnValue
        public Builder addTag(String str, long j) {
            return addImpl(str, Long.valueOf(j));
        }

        @CanIgnoreReturnValue
        public Builder addTag(String str, double d) {
            return addImpl(str, Double.valueOf(d));
        }

        @CanIgnoreReturnValue
        private Builder addImpl(String str, Object obj) {
            this.keyValuePairs.add(new KeyValuePair(Checks.checkMetadataIdentifier(str), obj));
            return this;
        }

        public Tags build() {
            if (this.keyValuePairs.isEmpty()) {
                return Tags.EMPTY_TAGS;
            }
            Collections.sort(this.keyValuePairs, Tags.KEY_VALUE_COMPARATOR);
            return new Tags(new LightweightTagMap(this.keyValuePairs));
        }

        public String toString() {
            return build().toString();
        }
    }

    public static Builder builder() {
        return new Builder();
    }

    public static Tags empty() {
        return EMPTY_TAGS;
    }

    public static Tags of(String str, String str2) {
        return new Tags(str, str2);
    }

    public static Tags of(String str, boolean z) {
        return new Tags(str, Boolean.valueOf(z));
    }

    public static Tags of(String str, long j) {
        return new Tags(str, Long.valueOf(j));
    }

    public static Tags of(String str, double d) {
        return new Tags(str, Double.valueOf(d));
    }

    private Tags(String str, Object obj) {
        this(new LightweightTagMap(Checks.checkMetadataIdentifier(str), Checks.checkNotNull(obj, "value")));
    }

    private Tags(LightweightTagMap lightweightTagMap) {
        this.map = lightweightTagMap;
    }

    public Map<String, Set<Object>> asMap() {
        return this.map;
    }

    public boolean isEmpty() {
        return this.map.isEmpty();
    }

    public Tags merge(Tags tags) {
        if (tags.isEmpty()) {
            return this;
        }
        return isEmpty() ? tags : new Tags(new LightweightTagMap(this.map, tags.map));
    }

    public boolean equals(Object obj) {
        return (obj instanceof Tags) && ((Tags) obj).map.equals(this.map);
    }

    public int hashCode() {
        return ~this.map.hashCode();
    }

    public String toString() {
        return this.map.toString();
    }

    private static class LightweightTagMap extends AbstractMap<String, Set<Object>> {
        private static final int SMALL_ARRAY_LENGTH = 16;
        private final Object[] array;
        private final Set<Map.Entry<String, Set<Object>>> entrySet;
        private Integer hashCode;
        private final int[] offsets;
        private String toString;
        private static final Comparator<Object> ENTRY_COMPARATOR = new Comparator<Object>() { // from class: com.google.common.flogger.context.Tags.LightweightTagMap.1
            @Override // java.util.Comparator
            public int compare(Object obj, Object obj2) {
                return ((String) ((Map.Entry) obj).getKey()).compareTo((String) ((Map.Entry) obj2).getKey());
            }
        };
        private static final int[] singletonOffsets = {1, 2};

        private static boolean mustResize(int i, int i2) {
            return i > 16 && i * 9 > i2 * 10;
        }

        LightweightTagMap(String str, Object obj) {
            this.entrySet = new SortedArraySet(-1);
            this.hashCode = null;
            this.toString = null;
            this.offsets = singletonOffsets;
            this.array = new Object[]{newEntry(str, 0), obj};
        }

        LightweightTagMap(List<KeyValuePair> list) {
            this.entrySet = new SortedArraySet(-1);
            this.hashCode = null;
            this.toString = null;
            int iCountMapEntries = countMapEntries(list);
            Object[] objArr = new Object[list.size() + iCountMapEntries];
            int[] iArr = new int[iCountMapEntries + 1];
            this.array = maybeResizeElementArray(objArr, makeTagMap(list, iCountMapEntries, objArr, iArr));
            this.offsets = iArr;
        }

        LightweightTagMap(LightweightTagMap lightweightTagMap, LightweightTagMap lightweightTagMap2) {
            this.entrySet = new SortedArraySet(-1);
            this.hashCode = null;
            this.toString = null;
            int size = lightweightTagMap.size() + lightweightTagMap2.size();
            Object[] objArr = new Object[lightweightTagMap.getTotalElementCount() + lightweightTagMap2.getTotalElementCount()];
            int[] iArr = new int[size + 1];
            this.array = adjustOffsetsAndMaybeResize(objArr, iArr, mergeTagMaps(lightweightTagMap, lightweightTagMap2, size, objArr, iArr));
            this.offsets = maybeResizeOffsetsArray(iArr);
        }

        private static int countMapEntries(List<KeyValuePair> list) {
            String str = null;
            int i = 0;
            for (KeyValuePair keyValuePair : list) {
                if (!keyValuePair.key.equals(str)) {
                    str = keyValuePair.key;
                    i++;
                }
            }
            return i;
        }

        private int makeTagMap(List<KeyValuePair> list, int i, Object[] objArr, int[] iArr) {
            int i2 = 0;
            int i3 = i;
            String str = null;
            Object obj = null;
            for (KeyValuePair keyValuePair : list) {
                if (!keyValuePair.key.equals(str)) {
                    str = keyValuePair.key;
                    objArr[i2] = newEntry(str, i2);
                    iArr[i2] = i3;
                    i2++;
                    obj = null;
                }
                if (keyValuePair.value != null && !keyValuePair.value.equals(obj)) {
                    obj = keyValuePair.value;
                    objArr[i3] = obj;
                    i3++;
                }
            }
            if (i2 != i) {
                throw new ConcurrentModificationException("corrupted tag map");
            }
            iArr[i] = i3;
            return i3;
        }

        private int mergeTagMaps(LightweightTagMap lightweightTagMap, LightweightTagMap lightweightTagMap2, int i, Object[] objArr, int[] iArr) {
            int iCompareTo;
            Object[] objArr2;
            int[] iArr2;
            int i2 = 0;
            iArr[0] = i;
            Map.Entry<String, SortedArraySet<Object>> entryOrNull = lightweightTagMap.getEntryOrNull(0);
            Map.Entry<String, SortedArraySet<Object>> entryOrNull2 = lightweightTagMap2.getEntryOrNull(0);
            int iCopyEntryAndValues = i;
            int i3 = 0;
            int i4 = 0;
            Map.Entry<String, SortedArraySet<Object>> entryOrNull3 = entryOrNull;
            while (true) {
                if (entryOrNull3 == null && entryOrNull2 == null) {
                    return i4;
                }
                if (entryOrNull3 == null) {
                    iCompareTo = 1;
                } else if (entryOrNull2 == null) {
                    iCompareTo = -1;
                } else {
                    iCompareTo = entryOrNull3.getKey().compareTo(entryOrNull2.getKey());
                    if (iCompareTo == 0) {
                        objArr[i4] = newEntry(entryOrNull3.getKey(), i4);
                        i4++;
                        iCopyEntryAndValues = mergeValues(entryOrNull3.getValue(), entryOrNull2.getValue(), objArr, iCopyEntryAndValues);
                        iArr[i4] = iCopyEntryAndValues;
                        i2++;
                        entryOrNull3 = lightweightTagMap.getEntryOrNull(i2);
                        i3++;
                        entryOrNull2 = lightweightTagMap2.getEntryOrNull(i3);
                    }
                }
                if (iCompareTo < 0) {
                    objArr2 = objArr;
                    iArr2 = iArr;
                    i2++;
                    iCopyEntryAndValues = copyEntryAndValues(entryOrNull3, i4, iCopyEntryAndValues, objArr2, iArr2);
                    entryOrNull3 = lightweightTagMap.getEntryOrNull(i2);
                    i4++;
                } else {
                    objArr2 = objArr;
                    iArr2 = iArr;
                    int iCopyEntryAndValues2 = copyEntryAndValues(entryOrNull2, i4, iCopyEntryAndValues, objArr2, iArr2);
                    i3++;
                    entryOrNull2 = lightweightTagMap2.getEntryOrNull(i3);
                    i4++;
                    iCopyEntryAndValues = iCopyEntryAndValues2;
                    entryOrNull3 = entryOrNull3;
                }
                objArr = objArr2;
                iArr = iArr2;
            }
        }

        private static int mergeValues(SortedArraySet<?> sortedArraySet, SortedArraySet<?> sortedArraySet2, Object[] objArr, int i) {
            int iCompare;
            int i2;
            Object value;
            int i3 = 0;
            int i4 = 0;
            while (true) {
                if (i3 >= sortedArraySet.size() && i4 >= sortedArraySet2.size()) {
                    return i;
                }
                if (i3 == sortedArraySet.size()) {
                    iCompare = 1;
                } else {
                    iCompare = i4 == sortedArraySet2.size() ? -1 : 0;
                }
                if (iCompare == 0) {
                    iCompare = Tags.VALUE_COMPARATOR.compare(sortedArraySet.getValue(i3), sortedArraySet2.getValue(i4));
                }
                if (iCompare < 0) {
                    i2 = i3 + 1;
                    value = sortedArraySet.getValue(i3);
                } else {
                    int i5 = i4 + 1;
                    Object value2 = sortedArraySet2.getValue(i4);
                    if (iCompare == 0) {
                        i3++;
                    }
                    i2 = i3;
                    value = value2;
                    i4 = i5;
                }
                objArr[i] = value;
                i3 = i2;
                i++;
            }
        }

        private int copyEntryAndValues(Map.Entry<String, SortedArraySet<Object>> entry, int i, int i2, Object[] objArr, int[] iArr) {
            SortedArraySet<Object> value = entry.getValue();
            int end = value.getEnd() - value.getStart();
            System.arraycopy(value.getValuesArray(), value.getStart(), objArr, i2, end);
            objArr[i] = newEntry(entry.getKey(), i);
            int i3 = i2 + end;
            iArr[i + 1] = i3;
            return i3;
        }

        private static Object[] adjustOffsetsAndMaybeResize(Object[] objArr, int[] iArr, int i) {
            Object[] objArr2;
            int i2 = iArr[0];
            int i3 = i2 - i;
            if (i3 == 0) {
                return objArr;
            }
            for (int i4 = 0; i4 <= i; i4++) {
                iArr[i4] = iArr[i4] - i3;
            }
            int i5 = iArr[i];
            int i6 = i5 - i;
            if (mustResize(objArr.length, i5)) {
                objArr2 = new Object[i5];
                System.arraycopy(objArr, 0, objArr2, 0, i);
            } else {
                objArr2 = objArr;
            }
            System.arraycopy(objArr, i2, objArr2, i, i6);
            return objArr2;
        }

        private static Object[] maybeResizeElementArray(Object[] objArr, int i) {
            return mustResize(objArr.length, i) ? Arrays.copyOf(objArr, i) : objArr;
        }

        private static int[] maybeResizeOffsetsArray(int[] iArr) {
            int i = iArr[0] + 1;
            return mustResize(iArr.length, i) ? Arrays.copyOf(iArr, i) : iArr;
        }

        private Map.Entry<String, SortedArraySet<Object>> newEntry(String str, int i) {
            return new AbstractMap.SimpleImmutableEntry(str, new SortedArraySet(i));
        }

        private Map.Entry<String, SortedArraySet<Object>> getEntryOrNull(int i) {
            if (i < this.offsets[0]) {
                return (Map.Entry) this.array[i];
            }
            return null;
        }

        private int getTotalElementCount() {
            return this.offsets[size()];
        }

        @Override // java.util.AbstractMap, java.util.Map
        public Set<Map.Entry<String, Set<Object>>> entrySet() {
            return this.entrySet;
        }

        class SortedArraySet<T> extends AbstractSet<T> {
            final int index;

            SortedArraySet(int i) {
                this.index = i;
            }

            Object[] getValuesArray() {
                return LightweightTagMap.this.array;
            }

            Object getValue(int i) {
                return LightweightTagMap.this.array[getStart() + i];
            }

            int getStart() {
                if (this.index == -1) {
                    return 0;
                }
                return LightweightTagMap.this.offsets[this.index];
            }

            int getEnd() {
                return LightweightTagMap.this.offsets[this.index + 1];
            }

            private Comparator<Object> getComparator() {
                if (this.index != -1) {
                    return Tags.VALUE_COMPARATOR;
                }
                return LightweightTagMap.ENTRY_COMPARATOR;
            }

            @Override // java.util.AbstractCollection, java.util.Collection, java.util.Set
            public int size() {
                return getEnd() - getStart();
            }

            @Override // java.util.AbstractCollection, java.util.Collection, java.util.Set
            public boolean contains(Object obj) {
                return Arrays.binarySearch(LightweightTagMap.this.array, getStart(), getEnd(), obj, getComparator()) >= 0;
            }

            @Override // java.util.AbstractCollection, java.util.Collection, java.lang.Iterable, java.util.Set
            public Iterator<T> iterator() {
                return new Iterator<T>() { // from class: com.google.common.flogger.context.Tags.LightweightTagMap.SortedArraySet.1
                    private int n = 0;

                    @Override // java.util.Iterator
                    public boolean hasNext() {
                        return this.n < SortedArraySet.this.size();
                    }

                    @Override // java.util.Iterator
                    public T next() {
                        int i = this.n;
                        if (i < SortedArraySet.this.size()) {
                            T t = (T) LightweightTagMap.this.array[SortedArraySet.this.getStart() + i];
                            this.n = i + 1;
                            return t;
                        }
                        throw new NoSuchElementException();
                    }

                    @Override // java.util.Iterator
                    public void remove() {
                        throw new UnsupportedOperationException();
                    }
                };
            }
        }

        @Override // java.util.AbstractMap, java.util.Map
        public int hashCode() {
            if (this.hashCode == null) {
                this.hashCode = Integer.valueOf(super.hashCode());
            }
            return this.hashCode.intValue();
        }

        @Override // java.util.AbstractMap
        public String toString() {
            if (this.toString == null) {
                this.toString = super.toString();
            }
            return this.toString;
        }
    }
}
