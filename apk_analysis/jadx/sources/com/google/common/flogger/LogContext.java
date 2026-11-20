package com.google.common.flogger;

import com.google.common.flogger.AbstractLogger;
import com.google.common.flogger.LoggingApi;
import com.google.common.flogger.backend.LogData;
import com.google.common.flogger.backend.Metadata;
import com.google.common.flogger.backend.Platform;
import com.google.common.flogger.backend.TemplateContext;
import com.google.common.flogger.context.Tags;
import com.google.common.flogger.parser.MessageParser;
import com.google.common.flogger.util.CallerFinder;
import com.google.common.flogger.util.Checks;
import java.util.Arrays;
import java.util.Iterator;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.TimeUnit;
import java.util.logging.Level;

/* JADX INFO: loaded from: classes2.dex */
public abstract class LogContext<LOGGER extends AbstractLogger<API>, API extends LoggingApi<API>> implements LoggingApi<API>, LogData {
    private static final String LITERAL_VALUE_MESSAGE = new String();
    private Object[] args;
    private final Level level;
    private LogSite logSite;
    private MutableMetadata metadata;
    private RateLimitStatus rateLimitStatus;
    private TemplateContext templateContext;
    private final long timestampNanos;

    protected abstract API api();

    protected abstract LOGGER getLogger();

    protected abstract MessageParser getMessageParser();

    protected abstract API noOp();

    public static final class Key {
        public static final MetadataKey<Throwable> LOG_CAUSE = MetadataKey.single("cause", Throwable.class);
        public static final MetadataKey<Integer> LOG_EVERY_N = MetadataKey.single("ratelimit_count", Integer.class);
        public static final MetadataKey<Integer> LOG_SAMPLE_EVERY_N = MetadataKey.single("sampling_count", Integer.class);
        public static final MetadataKey<DurationRateLimiter.RateLimitPeriod> LOG_AT_MOST_EVERY = MetadataKey.single("ratelimit_period", DurationRateLimiter.RateLimitPeriod.class);
        public static final MetadataKey<Integer> SKIPPED_LOG_COUNT = MetadataKey.single("skipped", Integer.class);
        public static final MetadataKey<Object> LOG_SITE_GROUPING_KEY = new MetadataKey<Object>("group_by", Object.class, true) { // from class: com.google.common.flogger.LogContext.Key.1
            @Override // com.google.common.flogger.MetadataKey
            public void emitRepeated(Iterator<? extends Object> it, MetadataKey.KeyValueHandler keyValueHandler) {
                if (it.hasNext()) {
                    Object next = it.next();
                    if (!it.hasNext()) {
                        keyValueHandler.handle(getLabel(), next);
                        return;
                    }
                    StringBuilder sb = new StringBuilder();
                    sb.append('[');
                    sb.append(next);
                    do {
                        sb.append(',');
                        sb.append(it.next());
                    } while (it.hasNext());
                    String label = getLabel();
                    sb.append(']');
                    keyValueHandler.handle(label, sb.toString());
                }
            }
        };
        public static final MetadataKey<Boolean> WAS_FORCED = MetadataKey.single("forced", Boolean.class);
        public static final MetadataKey<Tags> TAGS = new MetadataKey<Tags>("tags", Tags.class, false) { // from class: com.google.common.flogger.LogContext.Key.2
            @Override // com.google.common.flogger.MetadataKey
            public void emit(Tags tags, MetadataKey.KeyValueHandler keyValueHandler) {
                if (tags == null) {
                    return;
                }
                for (Map.Entry<String, Set<Object>> entry : tags.asMap().entrySet()) {
                    if (!entry.getValue().isEmpty()) {
                        Iterator<Object> it = entry.getValue().iterator();
                        while (it.hasNext()) {
                            keyValueHandler.handle(entry.getKey(), it.next());
                        }
                    } else {
                        keyValueHandler.handle(entry.getKey(), null);
                    }
                }
            }
        };
        public static final MetadataKey<StackSize> CONTEXT_STACK_SIZE = MetadataKey.single("stack_size", StackSize.class);

        private Key() {
        }
    }

    static final class MutableMetadata extends Metadata {
        private static final int INITIAL_KEY_VALUE_CAPACITY = 4;
        private Object[] keyValuePairs = new Object[8];
        private int keyValueCount = 0;

        MutableMetadata() {
        }

        @Override // com.google.common.flogger.backend.Metadata
        public int size() {
            return this.keyValueCount;
        }

        @Override // com.google.common.flogger.backend.Metadata
        public MetadataKey<?> getKey(int i) {
            if (i >= this.keyValueCount) {
                throw new IndexOutOfBoundsException();
            }
            return (MetadataKey) this.keyValuePairs[i * 2];
        }

        @Override // com.google.common.flogger.backend.Metadata
        public Object getValue(int i) {
            if (i >= this.keyValueCount) {
                throw new IndexOutOfBoundsException();
            }
            return this.keyValuePairs[(i * 2) + 1];
        }

        private int indexOf(MetadataKey<?> metadataKey) {
            for (int i = 0; i < this.keyValueCount; i++) {
                if (this.keyValuePairs[i * 2].equals(metadataKey)) {
                    return i;
                }
            }
            return -1;
        }

        @Override // com.google.common.flogger.backend.Metadata
        public <T> T findValue(MetadataKey<T> metadataKey) {
            int iIndexOf = indexOf(metadataKey);
            if (iIndexOf != -1) {
                return metadataKey.cast(this.keyValuePairs[(iIndexOf * 2) + 1]);
            }
            return null;
        }

        <T> void addValue(MetadataKey<T> metadataKey, T t) {
            int iIndexOf;
            if (!metadataKey.canRepeat() && (iIndexOf = indexOf(metadataKey)) != -1) {
                this.keyValuePairs[(iIndexOf * 2) + 1] = Checks.checkNotNull(t, "metadata value");
                return;
            }
            int i = (this.keyValueCount + 1) * 2;
            Object[] objArr = this.keyValuePairs;
            if (i > objArr.length) {
                this.keyValuePairs = Arrays.copyOf(objArr, objArr.length * 2);
            }
            this.keyValuePairs[this.keyValueCount * 2] = Checks.checkNotNull(metadataKey, "metadata key");
            this.keyValuePairs[(this.keyValueCount * 2) + 1] = Checks.checkNotNull(t, "metadata value");
            this.keyValueCount++;
        }

        void removeAllValues(MetadataKey<?> metadataKey) {
            int i;
            int iIndexOf = indexOf(metadataKey);
            if (iIndexOf >= 0) {
                int i2 = iIndexOf * 2;
                int i3 = i2 + 2;
                while (true) {
                    i = this.keyValueCount;
                    if (i3 >= i * 2) {
                        break;
                    }
                    Object obj = this.keyValuePairs[i3];
                    if (!obj.equals(metadataKey)) {
                        Object[] objArr = this.keyValuePairs;
                        objArr[i2] = obj;
                        objArr[i2 + 1] = objArr[i3 + 1];
                        i2 += 2;
                    }
                    i3 += 2;
                }
                this.keyValueCount = i - ((i3 - i2) >> 1);
                while (i2 < i3) {
                    this.keyValuePairs[i2] = null;
                    i2++;
                }
            }
        }

        public String toString() {
            StringBuilder sb = new StringBuilder("Metadata{");
            for (int i = 0; i < size(); i++) {
                sb.append(" '");
                sb.append(getKey(i));
                sb.append("': ");
                sb.append(getValue(i));
            }
            sb.append(" }");
            return sb.toString();
        }
    }

    protected LogContext(Level level, boolean z) {
        this(level, z, Platform.getCurrentTimeNanos());
    }

    protected LogContext(Level level, boolean z, long j) {
        this.metadata = null;
        this.logSite = null;
        this.rateLimitStatus = null;
        this.templateContext = null;
        this.args = null;
        this.level = (Level) Checks.checkNotNull(level, "level");
        this.timestampNanos = j;
        if (z) {
            addMetadata(Key.WAS_FORCED, Boolean.TRUE);
        }
    }

    @Override // com.google.common.flogger.backend.LogData
    public final Level getLevel() {
        return this.level;
    }

    @Override // com.google.common.flogger.backend.LogData
    @Deprecated
    public final long getTimestampMicros() {
        return TimeUnit.NANOSECONDS.toMicros(this.timestampNanos);
    }

    @Override // com.google.common.flogger.backend.LogData
    public final long getTimestampNanos() {
        return this.timestampNanos;
    }

    @Override // com.google.common.flogger.backend.LogData
    public final String getLoggerName() {
        return getLogger().getBackend().getLoggerName();
    }

    @Override // com.google.common.flogger.backend.LogData
    public final LogSite getLogSite() {
        LogSite logSite = this.logSite;
        if (logSite != null) {
            return logSite;
        }
        throw new IllegalStateException("cannot request log site information prior to postProcess()");
    }

    @Override // com.google.common.flogger.backend.LogData
    public final TemplateContext getTemplateContext() {
        return this.templateContext;
    }

    @Override // com.google.common.flogger.backend.LogData
    public final Object[] getArguments() {
        Checks.checkState(this.templateContext != null, "cannot get arguments unless a template context exists");
        Object[] objArr = this.args;
        if (objArr != null) {
            return objArr;
        }
        throw new IllegalStateException("cannot get arguments before calling log()");
    }

    @Override // com.google.common.flogger.backend.LogData
    public final Object getLiteralArgument() {
        Checks.checkState(this.templateContext == null, "cannot get literal argument if a template context exists");
        Object[] objArr = this.args;
        if (objArr == null) {
            throw new IllegalStateException("cannot get literal argument before calling log()");
        }
        return objArr[0];
    }

    @Override // com.google.common.flogger.backend.LogData
    public final boolean wasForced() {
        MutableMetadata mutableMetadata = this.metadata;
        return mutableMetadata != null && Boolean.TRUE.equals(mutableMetadata.findValue(Key.WAS_FORCED));
    }

    @Override // com.google.common.flogger.backend.LogData
    public final Metadata getMetadata() {
        MutableMetadata mutableMetadata = this.metadata;
        return mutableMetadata != null ? mutableMetadata : Metadata.empty();
    }

    protected final <T> void addMetadata(MetadataKey<T> metadataKey, T t) {
        if (this.metadata == null) {
            this.metadata = new MutableMetadata();
        }
        this.metadata.addValue(metadataKey, t);
    }

    protected final void removeMetadata(MetadataKey<?> metadataKey) {
        MutableMetadata mutableMetadata = this.metadata;
        if (mutableMetadata != null) {
            mutableMetadata.removeAllValues(metadataKey);
        }
    }

    protected boolean postProcess(LogSiteKey logSiteKey) {
        MutableMetadata mutableMetadata = this.metadata;
        if (mutableMetadata != null) {
            if (logSiteKey != null) {
                RateLimitStatus rateLimitStatusCombine = RateLimitStatus.combine(RateLimitStatus.combine(DurationRateLimiter.check(mutableMetadata, logSiteKey, this.timestampNanos), CountingRateLimiter.check(this.metadata, logSiteKey)), SamplingRateLimiter.check(this.metadata, logSiteKey));
                this.rateLimitStatus = rateLimitStatusCombine;
                if (rateLimitStatusCombine == RateLimitStatus.DISALLOW) {
                    return false;
                }
            }
            MutableMetadata mutableMetadata2 = this.metadata;
            MetadataKey<StackSize> metadataKey = Key.CONTEXT_STACK_SIZE;
            StackSize stackSize = (StackSize) mutableMetadata2.findValue(metadataKey);
            if (stackSize != null) {
                removeMetadata(metadataKey);
                Metadata metadata = getMetadata();
                MetadataKey metadataKey2 = Key.LOG_CAUSE;
                addMetadata(metadataKey2, new LogSiteStackTrace((Throwable) metadata.findValue(metadataKey2), stackSize, CallerFinder.getStackForCallerOf(LogContext.class, stackSize.getMaxDepth(), 1)));
            }
        }
        return true;
    }

    protected final boolean updateRateLimiterStatus(RateLimitStatus rateLimitStatus) {
        RateLimitStatus rateLimitStatusCombine = RateLimitStatus.combine(this.rateLimitStatus, rateLimitStatus);
        this.rateLimitStatus = rateLimitStatusCombine;
        return rateLimitStatusCombine != RateLimitStatus.DISALLOW;
    }

    private boolean shouldLog() {
        MutableMetadata mutableMetadata;
        if (this.logSite == null) {
            this.logSite = (LogSite) Checks.checkNotNull(Platform.getCallerFinder().findLogSite(LogContext.class, 1), "logger backend must not return a null LogSite");
        }
        LogSiteKey logSiteKeySpecializeLogSiteKeyFromMetadata = this.logSite;
        if (logSiteKeySpecializeLogSiteKeyFromMetadata != LogSite.INVALID) {
            MutableMetadata mutableMetadata2 = this.metadata;
            if (mutableMetadata2 != null && mutableMetadata2.size() > 0) {
                logSiteKeySpecializeLogSiteKeyFromMetadata = specializeLogSiteKeyFromMetadata(logSiteKeySpecializeLogSiteKeyFromMetadata, this.metadata);
            }
        } else {
            logSiteKeySpecializeLogSiteKeyFromMetadata = null;
        }
        boolean zPostProcess = postProcess(logSiteKeySpecializeLogSiteKeyFromMetadata);
        RateLimitStatus rateLimitStatus = this.rateLimitStatus;
        if (rateLimitStatus == null) {
            return zPostProcess;
        }
        int iCheckStatus = RateLimitStatus.checkStatus(rateLimitStatus, logSiteKeySpecializeLogSiteKeyFromMetadata, this.metadata);
        if (zPostProcess && iCheckStatus > 0 && (mutableMetadata = this.metadata) != null) {
            mutableMetadata.addValue(Key.SKIPPED_LOG_COUNT, Integer.valueOf(iCheckStatus));
        }
        return zPostProcess & (iCheckStatus >= 0);
    }

    static LogSiteKey specializeLogSiteKeyFromMetadata(LogSiteKey logSiteKey, Metadata metadata) {
        Checks.checkNotNull(logSiteKey, "logSiteKey");
        int size = metadata.size();
        for (int i = 0; i < size; i++) {
            if (Key.LOG_SITE_GROUPING_KEY.equals(metadata.getKey(i))) {
                Object value = metadata.getValue(i);
                if (value instanceof LoggingScope) {
                    logSiteKey = ((LoggingScope) value).specialize(logSiteKey);
                } else {
                    logSiteKey = SpecializedLogSiteKey.of(logSiteKey, value);
                }
            }
        }
        return logSiteKey;
    }

    private void logImpl(String str, Object... objArr) {
        this.args = objArr;
        for (int i = 0; i < objArr.length; i++) {
            Object obj = objArr[i];
            if (obj instanceof LazyArg) {
                objArr[i] = ((LazyArg) obj).evaluate();
            }
        }
        if (str != LITERAL_VALUE_MESSAGE) {
            this.templateContext = new TemplateContext(getMessageParser(), str);
        }
        Tags injectedTags = Platform.getInjectedTags();
        if (!injectedTags.isEmpty()) {
            Metadata metadata = getMetadata();
            MetadataKey metadataKey = Key.TAGS;
            Tags tags = (Tags) metadata.findValue(metadataKey);
            if (tags != null) {
                injectedTags = injectedTags.merge(tags);
            }
            addMetadata(metadataKey, injectedTags);
        }
        getLogger().write(this);
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API withInjectedLogSite(LogSite logSite) {
        if (this.logSite == null && logSite != null) {
            this.logSite = logSite;
        }
        return (API) api();
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API withInjectedLogSite(String str, String str2, int i, String str3) {
        return (API) withInjectedLogSite(LogSite.injectedLogSite(str, str2, i, str3));
    }

    @Override // com.google.common.flogger.LoggingApi
    public final boolean isEnabled() {
        return wasForced() || getLogger().isLoggable(this.level);
    }

    @Override // com.google.common.flogger.LoggingApi
    public final <T> API with(MetadataKey<T> metadataKey, T t) {
        Checks.checkNotNull(metadataKey, "metadata key");
        if (t != null) {
            addMetadata(metadataKey, t);
        }
        return (API) api();
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // com.google.common.flogger.LoggingApi
    public final API with(MetadataKey<Boolean> metadataKey) {
        return (API) with(metadataKey, Boolean.TRUE);
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // com.google.common.flogger.LoggingApi
    public <T> API per(T t, LogPerBucketingStrategy<? super T> logPerBucketingStrategy) {
        return t != null ? (API) with(Key.LOG_SITE_GROUPING_KEY, logPerBucketingStrategy.apply(t)) : (API) api();
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API per(Enum<?> r2) {
        return (API) with(Key.LOG_SITE_GROUPING_KEY, r2);
    }

    @Override // com.google.common.flogger.LoggingApi
    public API per(LoggingScopeProvider loggingScopeProvider) {
        return (API) with(Key.LOG_SITE_GROUPING_KEY, loggingScopeProvider.getCurrentScope());
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API withCause(Throwable th) {
        return (API) with(Key.LOG_CAUSE, th);
    }

    @Override // com.google.common.flogger.LoggingApi
    public API withStackTrace(StackSize stackSize) {
        if (Checks.checkNotNull(stackSize, "stack size") != StackSize.NONE) {
            addMetadata(Key.CONTEXT_STACK_SIZE, stackSize);
        }
        return (API) api();
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API every(int i) {
        return (API) everyImpl(Key.LOG_EVERY_N, i, "rate limit");
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API onAverageEvery(int i) {
        return (API) everyImpl(Key.LOG_SAMPLE_EVERY_N, i, "sampling");
    }

    /* JADX WARN: Multi-variable type inference failed */
    private API everyImpl(MetadataKey<Integer> metadataKey, int i, String str) {
        if (wasForced()) {
            return (API) api();
        }
        if (i <= 0) {
            throw new IllegalArgumentException(str + " count must be positive");
        }
        if (i > 1) {
            addMetadata(metadataKey, Integer.valueOf(i));
        }
        return (API) api();
    }

    @Override // com.google.common.flogger.LoggingApi
    public final API atMostEvery(int i, TimeUnit timeUnit) {
        if (wasForced()) {
            return (API) api();
        }
        if (i < 0) {
            throw new IllegalArgumentException("rate limit period cannot be negative");
        }
        if (i > 0) {
            addMetadata(Key.LOG_AT_MOST_EVERY, DurationRateLimiter.newRateLimitPeriod(i, timeUnit));
        }
        return (API) api();
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log() {
        if (shouldLog()) {
            logImpl(LITERAL_VALUE_MESSAGE, "");
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str) {
        if (shouldLog()) {
            logImpl(LITERAL_VALUE_MESSAGE, str);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj) {
        if (shouldLog()) {
            logImpl(str, obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2) {
        if (shouldLog()) {
            logImpl(str, obj, obj2);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4, obj5);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4, obj5, obj6);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4, obj5, obj6, obj7);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4, obj5, obj6, obj7, obj8);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9, Object obj10) {
        if (shouldLog()) {
            logImpl(str, obj, obj2, obj3, obj4, obj5, obj6, obj7, obj8, obj9, obj10);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, Object obj2, Object obj3, Object obj4, Object obj5, Object obj6, Object obj7, Object obj8, Object obj9, Object obj10, Object... objArr) {
        if (shouldLog()) {
            Object[] objArr2 = new Object[objArr.length + 10];
            objArr2[0] = obj;
            objArr2[1] = obj2;
            objArr2[2] = obj3;
            objArr2[3] = obj4;
            objArr2[4] = obj5;
            objArr2[5] = obj6;
            objArr2[6] = obj7;
            objArr2[7] = obj8;
            objArr2[8] = obj9;
            objArr2[9] = obj10;
            System.arraycopy(objArr, 0, objArr2, 10, objArr.length);
            logImpl(str, objArr2);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, boolean z) {
        if (shouldLog()) {
            logImpl(str, obj, Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, char c) {
        if (shouldLog()) {
            logImpl(str, obj, Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, byte b) {
        if (shouldLog()) {
            logImpl(str, obj, Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, short s) {
        if (shouldLog()) {
            logImpl(str, obj, Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, int i) {
        if (shouldLog()) {
            logImpl(str, obj, Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, long j) {
        if (shouldLog()) {
            logImpl(str, obj, Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, float f) {
        if (shouldLog()) {
            logImpl(str, obj, Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, Object obj, double d) {
        if (shouldLog()) {
            logImpl(str, obj, Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, Object obj) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, Object obj) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, Object obj) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, Object obj) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, Object obj) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, Object obj) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, Object obj) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, Object obj) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), obj);
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, boolean z2) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Boolean.valueOf(z2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, boolean z) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, boolean z) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, boolean z) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, boolean z) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, boolean z) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, boolean z) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, boolean z) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Boolean.valueOf(z));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, char c) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, char c2) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Character.valueOf(c2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, char c) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, char c) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, char c) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, char c) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, char c) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, char c) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Character.valueOf(c));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, byte b) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, byte b) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, byte b2) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Byte.valueOf(b2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, byte b) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, byte b) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, byte b) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, byte b) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, byte b) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Byte.valueOf(b));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, short s) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, short s) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, short s) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, short s2) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Short.valueOf(s2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, short s) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, short s) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, short s) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, short s) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Short.valueOf(s));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, int i) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, int i) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, int i) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, int i) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, int i2) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Integer.valueOf(i2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, int i) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, int i) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, int i) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Integer.valueOf(i));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, long j) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, long j) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, long j) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, long j) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, long j) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, long j2) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Long.valueOf(j2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, long j) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, long j) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Long.valueOf(j));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, float f) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, float f) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, float f) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, float f) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, float f) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, float f) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, float f2) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Float.valueOf(f2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, float f) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Float.valueOf(f));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, boolean z, double d) {
        if (shouldLog()) {
            logImpl(str, Boolean.valueOf(z), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, char c, double d) {
        if (shouldLog()) {
            logImpl(str, Character.valueOf(c), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, byte b, double d) {
        if (shouldLog()) {
            logImpl(str, Byte.valueOf(b), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, short s, double d) {
        if (shouldLog()) {
            logImpl(str, Short.valueOf(s), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, int i, double d) {
        if (shouldLog()) {
            logImpl(str, Integer.valueOf(i), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, long j, double d) {
        if (shouldLog()) {
            logImpl(str, Long.valueOf(j), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, float f, double d) {
        if (shouldLog()) {
            logImpl(str, Float.valueOf(f), Double.valueOf(d));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void log(String str, double d, double d2) {
        if (shouldLog()) {
            logImpl(str, Double.valueOf(d), Double.valueOf(d2));
        }
    }

    @Override // com.google.common.flogger.LoggingApi
    public final void logVarargs(String str, Object[] objArr) {
        if (shouldLog()) {
            logImpl(str, Arrays.copyOf(objArr, objArr.length));
        }
    }
}
