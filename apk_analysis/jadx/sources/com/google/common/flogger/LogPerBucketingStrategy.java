package com.google.common.flogger;

import com.google.common.flogger.util.Checks;
import java.util.HashMap;

/* JADX INFO: loaded from: classes2.dex */
public abstract class LogPerBucketingStrategy<T> {
    private final String name;
    private static final LogPerBucketingStrategy<Object> KNOWN_BOUNDED = new LogPerBucketingStrategy<Object>("KnownBounded") { // from class: com.google.common.flogger.LogPerBucketingStrategy.1
        @Override // com.google.common.flogger.LogPerBucketingStrategy
        protected Object apply(Object obj) {
            return obj;
        }
    };
    private static final LogPerBucketingStrategy<Object> BY_CLASS = new LogPerBucketingStrategy<Object>("ByClass") { // from class: com.google.common.flogger.LogPerBucketingStrategy.2
        @Override // com.google.common.flogger.LogPerBucketingStrategy
        protected Object apply(Object obj) {
            return obj.getClass();
        }
    };
    private static final LogPerBucketingStrategy<Object> BY_CLASS_NAME = new LogPerBucketingStrategy<Object>("ByClassName") { // from class: com.google.common.flogger.LogPerBucketingStrategy.3
        @Override // com.google.common.flogger.LogPerBucketingStrategy
        protected Object apply(Object obj) {
            return obj.getClass().getName();
        }
    };

    protected abstract Object apply(T t);

    public static final LogPerBucketingStrategy<Object> knownBounded() {
        return KNOWN_BOUNDED;
    }

    public static final LogPerBucketingStrategy<Object> byClass() {
        return BY_CLASS;
    }

    public static final LogPerBucketingStrategy<Object> byClassName() {
        return BY_CLASS_NAME;
    }

    public static final LogPerBucketingStrategy<Object> forKnownKeys(Iterable<?> iterable) {
        final HashMap map = new HashMap();
        StringBuilder sb = new StringBuilder("ForKnownKeys(");
        int i = 0;
        for (Object obj : iterable) {
            Checks.checkNotNull(obj, "key");
            if (!map.containsKey(obj)) {
                sb.append(i > 0 ? ", " : "");
                sb.append(obj);
                map.put(obj, Integer.valueOf(i));
                i++;
            }
        }
        Checks.checkArgument(!map.isEmpty(), "knownKeys must not be empty");
        sb.append(")");
        return new LogPerBucketingStrategy<Object>(sb.toString()) { // from class: com.google.common.flogger.LogPerBucketingStrategy.4
            @Override // com.google.common.flogger.LogPerBucketingStrategy
            protected Object apply(Object obj2) {
                return map.get(obj2);
            }
        };
    }

    public static final LogPerBucketingStrategy<Object> byHashCode(final int i) {
        Checks.checkArgument(i > 0, "maxBuckets must be positive");
        return new LogPerBucketingStrategy<Object>("ByHashCode(" + i + ")") { // from class: com.google.common.flogger.LogPerBucketingStrategy.5
            @Override // com.google.common.flogger.LogPerBucketingStrategy
            protected Object apply(Object obj) {
                int iHashCode = obj.hashCode();
                int i2 = i;
                int i3 = iHashCode % i2;
                return Integer.valueOf((i3 + (i2 & (i3 >> 31))) - 128);
            }
        };
    }

    protected LogPerBucketingStrategy(String str) {
        this.name = (String) Checks.checkNotNull(str, "name");
    }

    public final String toString() {
        return LogPerBucketingStrategy.class.getSimpleName() + "[" + this.name + "]";
    }
}
