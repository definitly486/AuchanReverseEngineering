package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import com.scanflow.datacapture.barinternal.kotlin.jvm.JvmClassMappingKt;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;
import kotlinx.serialization.KSerializer;

/* JADX INFO: compiled from: Caching.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ClassValueCache implements SerializerCache {
    private final ClassValueReferences classValue;
    private final Function1 compute;

    public ClassValueCache(Function1 compute) {
        Intrinsics.checkNotNullParameter(compute, "compute");
        this.compute = compute;
        this.classValue = new ClassValueReferences();
    }

    public final Function1 getCompute() {
        return this.compute;
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.SerializerCache
    public KSerializer get(final KClass key) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object obj = this.classValue.get(JvmClassMappingKt.getJavaClass(key));
        Intrinsics.checkNotNullExpressionValue(obj, "get(...)");
        MutableSoftReference mutableSoftReference = (MutableSoftReference) obj;
        Object orSetWithLock = mutableSoftReference.reference.get();
        if (orSetWithLock == null) {
            orSetWithLock = mutableSoftReference.getOrSetWithLock(new Function0() { // from class: com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ClassValueCache$get$$inlined$getOrSet$1
                @Override // kotlin.jvm.functions.Function0
                public final Object invoke() {
                    return new CacheEntry((KSerializer) this.this$0.getCompute().invoke(key));
                }
            });
        }
        return ((CacheEntry) orSetWithLock).serializer;
    }
}
