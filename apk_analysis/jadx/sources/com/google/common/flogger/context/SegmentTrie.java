package com.google.common.flogger.context;

import com.google.common.flogger.util.Checks;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

/* JADX INFO: loaded from: classes2.dex */
abstract class SegmentTrie<T> {
    private final T defaultValue;

    public abstract T find(String str);

    public abstract Map<String, T> getEntryMap();

    public static <T> SegmentTrie<T> create(Map<String, ? extends T> map, char c, T t) {
        int size = map.size();
        if (size == 0) {
            return new EmptyTrie(t);
        }
        if (size == 1) {
            Map.Entry<String, ? extends T> next = map.entrySet().iterator().next();
            return new SingletonTrie(next.getKey(), next.getValue(), c, t);
        }
        return new SortedTrie(map, c, t);
    }

    SegmentTrie(T t) {
        this.defaultValue = t;
    }

    public final T getDefaultValue() {
        return this.defaultValue;
    }

    private static final class EmptyTrie<T> extends SegmentTrie<T> {
        EmptyTrie(T t) {
            super(t);
        }

        @Override // com.google.common.flogger.context.SegmentTrie
        public T find(String str) {
            return getDefaultValue();
        }

        @Override // com.google.common.flogger.context.SegmentTrie
        public Map<String, T> getEntryMap() {
            return Collections.EMPTY_MAP;
        }
    }

    private static final class SingletonTrie<T> extends SegmentTrie<T> {
        private final String key;
        private final char separator;
        private final T value;

        SingletonTrie(String str, T t, char c, T t2) {
            super(t2);
            this.key = (String) Checks.checkNotNull(str, "key");
            this.value = t;
            this.separator = c;
        }

        @Override // com.google.common.flogger.context.SegmentTrie
        public T find(String str) {
            String str2 = this.key;
            if (str.regionMatches(0, str2, 0, str2.length()) && (str.length() == this.key.length() || str.charAt(this.key.length()) == this.separator)) {
                return this.value;
            }
            return getDefaultValue();
        }

        @Override // com.google.common.flogger.context.SegmentTrie
        public Map<String, T> getEntryMap() {
            HashMap map = new HashMap();
            map.put(this.key, this.value);
            return Collections.unmodifiableMap(map);
        }
    }

    private static final class SortedTrie<T> extends SegmentTrie<T> {
        private final String[] keys;
        private final int[] parent;
        private final char separator;
        private final List<T> values;

        SortedTrie(Map<String, ? extends T> map, char c, T t) {
            super(t);
            TreeMap treeMap = new TreeMap(map);
            String[] strArr = (String[]) treeMap.keySet().toArray(new String[0]);
            this.keys = strArr;
            this.values = new ArrayList(treeMap.values());
            this.parent = buildParentMap(strArr, c);
            this.separator = c;
        }

        @Override // com.google.common.flogger.context.SegmentTrie
        public T find(String str) {
            int length = str.length();
            int i = 0;
            int iPrefixCompare = prefixCompare(str, this.keys[0], 0);
            if (iPrefixCompare == length) {
                return this.values.get(0);
            }
            if (iPrefixCompare < 0) {
                return getDefaultValue();
            }
            String[] strArr = this.keys;
            int length2 = strArr.length - 1;
            int iPrefixCompare2 = prefixCompare(str, strArr[length2], 0);
            if (iPrefixCompare2 == length) {
                return this.values.get(length2);
            }
            if (iPrefixCompare2 >= 0) {
                return findParent(str, length2, iPrefixCompare2);
            }
            int i2 = ~iPrefixCompare2;
            while (true) {
                int i3 = (i + length2) >>> 1;
                if (i3 == i) {
                    return findParent(str, i, iPrefixCompare);
                }
                int iPrefixCompare3 = prefixCompare(str, this.keys[i3], Math.min(iPrefixCompare, i2));
                if (length == iPrefixCompare3) {
                    return this.values.get(i3);
                }
                if (iPrefixCompare3 >= 0) {
                    i = i3;
                    iPrefixCompare = iPrefixCompare3;
                } else {
                    i2 = ~iPrefixCompare3;
                    length2 = i3;
                }
            }
        }

        private T findParent(String str, int i, int i2) {
            while (!isParent(this.keys[i], str, i2)) {
                i = this.parent[i];
                if (i == -1) {
                    return getDefaultValue();
                }
            }
            return this.values.get(i);
        }

        private boolean isParent(String str, String str2, int i) {
            return str.length() <= i && str2.charAt(str.length()) == this.separator;
        }

        private static int prefixCompare(String str, String str2, int i) {
            if (i < 0) {
                throw new IllegalStateException("lhs=" + str + ", rhs=" + str2 + ", start=" + i);
            }
            int iMin = Math.min(str.length(), str2.length());
            while (i < iMin) {
                int iCharAt = str.charAt(i) - str2.charAt(i);
                if (iCharAt != 0) {
                    return iCharAt < 0 ? ~i : i;
                }
                i++;
            }
            return iMin < str2.length() ? ~iMin : iMin;
        }

        private static int[] buildParentMap(String[] strArr, char c) {
            int[] iArr = new int[strArr.length];
            iArr[0] = -1;
            for (int i = 1; i < strArr.length; i++) {
                iArr[i] = -1;
                String strSubstring = strArr[i];
                while (true) {
                    int iLastIndexOf = strSubstring.lastIndexOf(c);
                    if (iLastIndexOf < 0) {
                        break;
                    }
                    strSubstring = strSubstring.substring(0, iLastIndexOf);
                    int iBinarySearch = Arrays.binarySearch(strArr, 0, i, strSubstring);
                    if (iBinarySearch >= 0) {
                        iArr[i] = iBinarySearch;
                        break;
                    }
                }
            }
            return iArr;
        }

        @Override // com.google.common.flogger.context.SegmentTrie
        public Map<String, T> getEntryMap() {
            LinkedHashMap linkedHashMap = new LinkedHashMap();
            int i = 0;
            while (true) {
                String[] strArr = this.keys;
                if (i < strArr.length) {
                    linkedHashMap.put(strArr[i], this.values.get(i));
                    i++;
                } else {
                    return Collections.unmodifiableMap(linkedHashMap);
                }
            }
        }
    }
}
