package com.google.common.flogger.backend;

import com.google.common.flogger.LogContext;
import com.google.common.flogger.MetadataKey;
import com.google.common.flogger.util.Checks;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;

/* JADX INFO: loaded from: classes2.dex */
public abstract class MetadataHandler<C> {

    public interface RepeatedValueHandler<T, C> {
        void handle(MetadataKey<T> metadataKey, Iterator<T> it, C c);
    }

    public interface ValueHandler<T, C> {
        void handle(MetadataKey<T> metadataKey, T t, C c);
    }

    protected abstract <T> void handle(MetadataKey<T> metadataKey, T t, C c);

    protected <T> void handleRepeated(MetadataKey<T> metadataKey, Iterator<T> it, C c) {
        while (it.hasNext()) {
            handle(metadataKey, it.next(), c);
        }
    }

    public static <C> Builder<C> builder(ValueHandler<Object, C> valueHandler) {
        return new Builder<>(valueHandler);
    }

    public static final class Builder<C> {
        private final ValueHandler<Object, ? super C> defaultHandler;
        private RepeatedValueHandler<Object, ? super C> defaultRepeatedHandler;
        private final Map<MetadataKey<?>, RepeatedValueHandler<?, ? super C>> repeatedValueHandlers;
        private final Map<MetadataKey<?>, ValueHandler<?, ? super C>> singleValueHandlers;
        private static final ValueHandler<Object, Object> IGNORE_VALUE = new ValueHandler<Object, Object>() { // from class: com.google.common.flogger.backend.MetadataHandler.Builder.1
            @Override // com.google.common.flogger.backend.MetadataHandler.ValueHandler
            public void handle(MetadataKey<Object> metadataKey, Object obj, Object obj2) {
            }
        };
        private static final RepeatedValueHandler<Object, Object> IGNORE_REPEATED_VALUE = new RepeatedValueHandler<Object, Object>() { // from class: com.google.common.flogger.backend.MetadataHandler.Builder.2
            @Override // com.google.common.flogger.backend.MetadataHandler.RepeatedValueHandler
            public void handle(MetadataKey<Object> metadataKey, Iterator<Object> it, Object obj) {
            }
        };

        private Builder(ValueHandler<Object, ? super C> valueHandler) {
            this.singleValueHandlers = new HashMap();
            this.repeatedValueHandlers = new HashMap();
            this.defaultRepeatedHandler = null;
            this.defaultHandler = (ValueHandler) Checks.checkNotNull(valueHandler, "default handler");
        }

        @CanIgnoreReturnValue
        public Builder<C> setDefaultRepeatedHandler(RepeatedValueHandler<Object, ? super C> repeatedValueHandler) {
            this.defaultRepeatedHandler = (RepeatedValueHandler) Checks.checkNotNull(repeatedValueHandler, "handler");
            return this;
        }

        @CanIgnoreReturnValue
        public <T> Builder<C> addHandler(MetadataKey<T> metadataKey, ValueHandler<? super T, ? super C> valueHandler) {
            Checks.checkNotNull(metadataKey, "key");
            Checks.checkNotNull(valueHandler, "handler");
            this.repeatedValueHandlers.remove(metadataKey);
            this.singleValueHandlers.put(metadataKey, valueHandler);
            return this;
        }

        @CanIgnoreReturnValue
        public <T> Builder<C> addRepeatedHandler(MetadataKey<? extends T> metadataKey, RepeatedValueHandler<T, ? super C> repeatedValueHandler) {
            Checks.checkNotNull(metadataKey, "key");
            Checks.checkNotNull(repeatedValueHandler, "handler");
            Checks.checkArgument(metadataKey.canRepeat(), "key must be repeating");
            this.singleValueHandlers.remove(metadataKey);
            this.repeatedValueHandlers.put(metadataKey, repeatedValueHandler);
            return this;
        }

        /* JADX WARN: Multi-variable type inference failed */
        @CanIgnoreReturnValue
        public Builder<C> ignoring(MetadataKey<?> metadataKey, MetadataKey<?>... metadataKeyArr) {
            checkAndIgnore(metadataKey);
            for (LogContext.Key.AnonymousClass2 anonymousClass2 : metadataKeyArr) {
                checkAndIgnore(anonymousClass2);
            }
            return this;
        }

        @CanIgnoreReturnValue
        public Builder<C> ignoring(Iterable<MetadataKey<?>> iterable) {
            Iterator<MetadataKey<?>> it = iterable.iterator();
            while (it.hasNext()) {
                checkAndIgnore((MetadataKey) it.next());
            }
            return this;
        }

        /* JADX WARN: Multi-variable type inference failed */
        <T> void checkAndIgnore(MetadataKey<T> metadataKey) {
            Checks.checkNotNull(metadataKey, "key");
            if (metadataKey.canRepeat()) {
                addRepeatedHandler(metadataKey, IGNORE_REPEATED_VALUE);
            } else {
                addHandler(metadataKey, IGNORE_VALUE);
            }
        }

        @CanIgnoreReturnValue
        public Builder<C> removeHandlers(MetadataKey<?> metadataKey, MetadataKey<?>... metadataKeyArr) {
            checkAndRemove(metadataKey);
            for (MetadataKey<?> metadataKey2 : metadataKeyArr) {
                checkAndRemove(metadataKey2);
            }
            return this;
        }

        void checkAndRemove(MetadataKey<?> metadataKey) {
            Checks.checkNotNull(metadataKey, "key");
            this.singleValueHandlers.remove(metadataKey);
            this.repeatedValueHandlers.remove(metadataKey);
        }

        public MetadataHandler<C> build() {
            return new MapBasedhandler(this);
        }
    }

    private static final class MapBasedhandler<C> extends MetadataHandler<C> {
        private final ValueHandler<Object, ? super C> defaultHandler;
        private final RepeatedValueHandler<Object, ? super C> defaultRepeatedHandler;
        private final Map<MetadataKey<?>, RepeatedValueHandler<?, ? super C>> repeatedValueHandlers;
        private final Map<MetadataKey<?>, ValueHandler<?, ? super C>> singleValueHandlers;

        private MapBasedhandler(Builder<C> builder) {
            HashMap map = new HashMap();
            this.singleValueHandlers = map;
            HashMap map2 = new HashMap();
            this.repeatedValueHandlers = map2;
            map.putAll(((Builder) builder).singleValueHandlers);
            map2.putAll(((Builder) builder).repeatedValueHandlers);
            this.defaultHandler = ((Builder) builder).defaultHandler;
            this.defaultRepeatedHandler = ((Builder) builder).defaultRepeatedHandler;
        }

        @Override // com.google.common.flogger.backend.MetadataHandler
        protected <T> void handle(MetadataKey<T> metadataKey, T t, C c) {
            ValueHandler<?, ? super C> valueHandler = this.singleValueHandlers.get(metadataKey);
            if (valueHandler != null) {
                valueHandler.handle(metadataKey, t, c);
            } else {
                this.defaultHandler.handle(metadataKey, t, c);
            }
        }

        @Override // com.google.common.flogger.backend.MetadataHandler
        protected <T> void handleRepeated(MetadataKey<T> metadataKey, Iterator<T> it, C c) {
            RepeatedValueHandler<?, ? super C> repeatedValueHandler = this.repeatedValueHandlers.get(metadataKey);
            if (repeatedValueHandler != null) {
                repeatedValueHandler.handle(metadataKey, it, c);
            } else if (this.defaultRepeatedHandler != null && !this.singleValueHandlers.containsKey(metadataKey)) {
                this.defaultRepeatedHandler.handle(metadataKey, it, c);
            } else {
                super.handleRepeated(metadataKey, it, c);
            }
        }
    }
}
