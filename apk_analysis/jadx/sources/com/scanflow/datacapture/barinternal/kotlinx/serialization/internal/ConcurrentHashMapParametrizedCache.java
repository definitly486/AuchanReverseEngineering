package com.scanflow.datacapture.barinternal.kotlinx.serialization.internal;

import com.scanflow.datacapture.barinternal.kotlin.Result;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.jvm.JvmClassMappingKt;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;
import kotlin.reflect.KType;
import kotlinx.serialization.KSerializer;

/* JADX INFO: compiled from: Caching.kt */
/* JADX INFO: loaded from: classes3.dex */
final class ConcurrentHashMapParametrizedCache implements ParametrizedSerializerCache {
    private final ConcurrentHashMap cache;
    private final Function2 compute;

    public ConcurrentHashMapParametrizedCache(Function2 compute) {
        Intrinsics.checkNotNullParameter(compute, "compute");
        this.compute = compute;
        this.cache = new ConcurrentHashMap();
    }

    @Override // com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ParametrizedSerializerCache
    /* JADX INFO: renamed from: get-gIAlu-s */
    public Object mo870getgIAlus(KClass key, List types) {
        Object objM681constructorimpl;
        Object objPutIfAbsent;
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(types, "types");
        ConcurrentHashMap concurrentHashMap = this.cache;
        Class javaClass = JvmClassMappingKt.getJavaClass(key);
        Object parametrizedCacheEntry = concurrentHashMap.get(javaClass);
        if (parametrizedCacheEntry == null && (objPutIfAbsent = concurrentHashMap.putIfAbsent(javaClass, (parametrizedCacheEntry = new ParametrizedCacheEntry()))) != null) {
            parametrizedCacheEntry = objPutIfAbsent;
        }
        ParametrizedCacheEntry parametrizedCacheEntry2 = (ParametrizedCacheEntry) parametrizedCacheEntry;
        List list = types;
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(list, 10));
        Iterator it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(new KTypeWrapper((KType) it.next()));
        }
        ConcurrentHashMap concurrentHashMap2 = parametrizedCacheEntry2.serializers;
        Object obj = concurrentHashMap2.get(arrayList);
        if (obj == null) {
            try {
                Result.Companion companion = Result.Companion;
                objM681constructorimpl = Result.m681constructorimpl((KSerializer) this.compute.invoke(key, types));
            } catch (Throwable th) {
                Result.Companion companion2 = Result.Companion;
                objM681constructorimpl = Result.m681constructorimpl(ResultKt.createFailure(th));
            }
            Result resultM680boximpl = Result.m680boximpl(objM681constructorimpl);
            Object objPutIfAbsent2 = concurrentHashMap2.putIfAbsent(arrayList, resultM680boximpl);
            obj = objPutIfAbsent2 == null ? resultM680boximpl : objPutIfAbsent2;
        }
        Intrinsics.checkNotNullExpressionValue(obj, "getOrPut(...)");
        return ((Result) obj).m688unboximpl();
    }
}
