package com.google.common.flogger;

import com.google.common.flogger.backend.Platform;
import com.google.common.flogger.util.Checks;
import java.util.Iterator;

/* JADX INFO: loaded from: classes2.dex */
public class MetadataKey<T> {
    private static final int MAX_CUSTOM_METADATAKEY_RECURSION_DEPTH = 20;
    private final long bloomFilterMask;
    private final boolean canRepeat;
    private final Class<? extends T> clazz;
    private final boolean isCustom;
    private final String label;

    public interface KeyValueHandler {
        void handle(String str, Object obj);
    }

    public static <T> MetadataKey<T> single(String str, Class<? extends T> cls) {
        return new MetadataKey<>(str, cls, false, false);
    }

    public static <T> MetadataKey<T> repeated(String str, Class<T> cls) {
        return new MetadataKey<>(str, cls, true, false);
    }

    protected MetadataKey(String str, Class<? extends T> cls, boolean z) {
        this(str, cls, z, true);
    }

    private MetadataKey(String str, Class<? extends T> cls, boolean z, boolean z2) {
        this.label = Checks.checkMetadataIdentifier(str);
        this.clazz = (Class) Checks.checkNotNull(cls, "class");
        this.canRepeat = z;
        this.isCustom = z2;
        this.bloomFilterMask = createBloomFilterMaskFromSystemHashcode();
    }

    public final String getLabel() {
        return this.label;
    }

    public final T cast(Object obj) {
        return this.clazz.cast(obj);
    }

    public final boolean canRepeat() {
        return this.canRepeat;
    }

    public final void safeEmit(T t, KeyValueHandler keyValueHandler) {
        if (this.isCustom && Platform.getCurrentRecursionDepth() > 20) {
            keyValueHandler.handle(getLabel(), t);
        } else {
            emit(t, keyValueHandler);
        }
    }

    public final void safeEmitRepeated(Iterator<? extends T> it, KeyValueHandler keyValueHandler) {
        Checks.checkState(this.canRepeat, "non repeating key");
        if (this.isCustom && Platform.getCurrentRecursionDepth() > 20) {
            while (it.hasNext()) {
                keyValueHandler.handle(getLabel(), it.next());
            }
        } else {
            emitRepeated(it, keyValueHandler);
        }
    }

    protected void emit(T t, KeyValueHandler keyValueHandler) {
        keyValueHandler.handle(getLabel(), t);
    }

    protected void emitRepeated(Iterator<? extends T> it, KeyValueHandler keyValueHandler) {
        while (it.hasNext()) {
            emit(it.next(), keyValueHandler);
        }
    }

    public final long getBloomFilterMask() {
        return this.bloomFilterMask;
    }

    public final int hashCode() {
        return super.hashCode();
    }

    public final boolean equals(Object obj) {
        return super.equals(obj);
    }

    public final String toString() {
        return getClass().getName() + "/" + this.label + "[" + this.clazz.getName() + "]";
    }

    private long createBloomFilterMaskFromSystemHashcode() {
        int iIdentityHashCode = System.identityHashCode(this);
        long j = 0;
        for (int i = 0; i < 5; i++) {
            j |= 1 << (iIdentityHashCode & 63);
            iIdentityHashCode >>>= 6;
        }
        return j;
    }
}
