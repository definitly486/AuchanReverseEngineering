package io.appmetrica.analytics.remotepermissions.impl;

import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.SetsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufConverter;
import io.appmetrica.analytics.remotepermissions.internal.config.FeatureConfig;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Set;

/* JADX INFO: loaded from: classes3.dex */
public final class b implements ProtobufConverter {
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final e fromModel(FeatureConfig featureConfig) {
        e eVar = new e();
        Set<String> permittedPermissions = featureConfig.getPermittedPermissions();
        ArrayList arrayList = new ArrayList(CollectionsKt.collectionSizeOrDefault(permittedPermissions, 10));
        Iterator<T> it = permittedPermissions.iterator();
        while (it.hasNext()) {
            arrayList.add(((String) it.next()).getBytes(Charsets.UTF_8));
        }
        eVar.a = (byte[][]) arrayList.toArray(new byte[0][]);
        return eVar;
    }

    /* JADX WARN: Code duplicated, block: B:9:0x0023  */
    @Override // io.appmetrica.analytics.coreapi.internal.data.Converter
    /* JADX INFO: renamed from: a, reason: merged with bridge method [inline-methods] */
    public final FeatureConfig toModel(e eVar) {
        Set setEmptySet;
        byte[][] bArr = eVar.a;
        if (bArr != null) {
            ArrayList arrayList = new ArrayList(bArr.length);
            for (byte[] bArr2 : bArr) {
                arrayList.add(new String(bArr2, Charsets.UTF_8));
            }
            setEmptySet = CollectionsKt.toSet(arrayList);
            if (setEmptySet == null) {
                setEmptySet = SetsKt.emptySet();
            }
        } else {
            setEmptySet = SetsKt.emptySet();
        }
        return new FeatureConfig(setEmptySet);
    }
}
