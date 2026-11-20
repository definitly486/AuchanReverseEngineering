package com.google.common.flogger.context;

import com.google.common.flogger.MetadataKey;
import com.google.common.flogger.backend.Metadata;
import com.google.common.flogger.util.Checks;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/* JADX INFO: loaded from: classes2.dex */
public abstract class ContextMetadata extends Metadata {
    public abstract ContextMetadata concatenate(ContextMetadata contextMetadata);

    abstract Entry<?> get(int i);

    private static final class Entry<T> {
        final MetadataKey<T> key;
        final T value;

        Entry(MetadataKey<T> metadataKey, T t) {
            this.key = (MetadataKey) Checks.checkNotNull(metadataKey, "key");
            this.value = (T) Checks.checkNotNull(t, "value");
        }
    }

    public static final class Builder {
        private static final Entry<?>[] EMPTY_ARRAY = new Entry[0];
        private final List<Entry<?>> entries;

        private Builder() {
            this.entries = new ArrayList(2);
        }

        @CanIgnoreReturnValue
        public <T> Builder add(MetadataKey<T> metadataKey, T t) {
            this.entries.add(new Entry<>(metadataKey, t));
            return this;
        }

        public ContextMetadata build() {
            return new ImmutableScopeMetadata((Entry[]) this.entries.toArray(EMPTY_ARRAY));
        }
    }

    public static Builder builder() {
        return new Builder();
    }

    public static <T> ContextMetadata singleton(MetadataKey<T> metadataKey, T t) {
        return new SingletonMetadata(metadataKey, t);
    }

    public static ContextMetadata none() {
        return EmptyMetadata.INSTANCE;
    }

    private ContextMetadata() {
    }

    @Override // com.google.common.flogger.backend.Metadata
    public MetadataKey<?> getKey(int i) {
        return get(i).key;
    }

    @Override // com.google.common.flogger.backend.Metadata
    public Object getValue(int i) {
        return get(i).value;
    }

    private static final class ImmutableScopeMetadata extends ContextMetadata {
        private final Entry<?>[] entries;

        ImmutableScopeMetadata(Entry<?>[] entryArr) {
            super();
            this.entries = entryArr;
        }

        @Override // com.google.common.flogger.backend.Metadata
        public int size() {
            return this.entries.length;
        }

        @Override // com.google.common.flogger.context.ContextMetadata
        Entry<?> get(int i) {
            return this.entries[i];
        }

        @Override // com.google.common.flogger.backend.Metadata
        public <T> T findValue(MetadataKey<T> metadataKey) {
            Checks.checkArgument(!metadataKey.canRepeat(), "metadata key must be single valued");
            for (int length = this.entries.length - 1; length >= 0; length--) {
                Entry<?> entry = this.entries[length];
                if (entry.key.equals(metadataKey)) {
                    return entry.value;
                }
            }
            return null;
        }

        @Override // com.google.common.flogger.context.ContextMetadata
        public ContextMetadata concatenate(ContextMetadata contextMetadata) {
            int size = contextMetadata.size();
            if (size == 0) {
                return this;
            }
            Entry<?>[] entryArr = this.entries;
            if (entryArr.length == 0) {
                return contextMetadata;
            }
            Entry[] entryArr2 = (Entry[]) Arrays.copyOf(entryArr, entryArr.length + size);
            for (int i = 0; i < size; i++) {
                entryArr2[this.entries.length + i] = contextMetadata.get(i);
            }
            return new ImmutableScopeMetadata(entryArr2);
        }
    }

    private static final class SingletonMetadata extends ContextMetadata {
        private final Entry<?> entry;

        @Override // com.google.common.flogger.backend.Metadata
        public int size() {
            return 1;
        }

        <T> SingletonMetadata(MetadataKey<T> metadataKey, T t) {
            super();
            this.entry = new Entry<>(metadataKey, t);
        }

        @Override // com.google.common.flogger.context.ContextMetadata
        Entry<?> get(int i) {
            if (i == 0) {
                return this.entry;
            }
            throw new IndexOutOfBoundsException();
        }

        @Override // com.google.common.flogger.backend.Metadata
        public <R> R findValue(MetadataKey<R> metadataKey) {
            Checks.checkArgument(!metadataKey.canRepeat(), "metadata key must be single valued");
            if (this.entry.key.equals(metadataKey)) {
                return (R) this.entry.value;
            }
            return null;
        }

        @Override // com.google.common.flogger.context.ContextMetadata
        public ContextMetadata concatenate(ContextMetadata contextMetadata) {
            int size = contextMetadata.size();
            if (size == 0) {
                return this;
            }
            Entry[] entryArr = new Entry[size + 1];
            int i = 0;
            entryArr[0] = this.entry;
            while (i < size) {
                int i2 = i + 1;
                entryArr[i2] = contextMetadata.get(i);
                i = i2;
            }
            return new ImmutableScopeMetadata(entryArr);
        }
    }

    private static final class EmptyMetadata extends ContextMetadata {
        static final ContextMetadata INSTANCE = new EmptyMetadata();

        @Override // com.google.common.flogger.context.ContextMetadata
        public ContextMetadata concatenate(ContextMetadata contextMetadata) {
            return contextMetadata;
        }

        @Override // com.google.common.flogger.backend.Metadata
        public int size() {
            return 0;
        }

        private EmptyMetadata() {
            super();
        }

        @Override // com.google.common.flogger.context.ContextMetadata
        Entry<?> get(int i) {
            throw new IndexOutOfBoundsException();
        }

        @Override // com.google.common.flogger.backend.Metadata
        public <T> T findValue(MetadataKey<T> metadataKey) {
            Checks.checkArgument(!metadataKey.canRepeat(), "metadata key must be single valued");
            return null;
        }
    }
}
