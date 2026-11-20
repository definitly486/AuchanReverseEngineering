package io.appmetrica.analytics.impl;

import android.content.Context;
import io.appmetrica.analytics.coreapi.internal.data.IBinaryDataHelper;
import io.appmetrica.analytics.coreapi.internal.data.ProtobufStateStorage;

/* JADX INFO: renamed from: io.appmetrica.analytics.impl.in, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0343in implements InterfaceC0318hn {
    public abstract IBinaryDataHelper a(Context context);

    public abstract ProtobufStateStorage<Object> a(Context context, IBinaryDataHelper iBinaryDataHelper);

    public abstract IBinaryDataHelper b(Context context);

    @Override // io.appmetrica.analytics.impl.InterfaceC0318hn, io.appmetrica.analytics.coreapi.internal.data.ProtobufBinaryStateStorageFactory
    public final ProtobufStateStorage<Object> create(Context context) {
        return a(context, a(context));
    }

    @Override // io.appmetrica.analytics.impl.InterfaceC0318hn, io.appmetrica.analytics.coreapi.internal.data.ProtobufBinaryStateStorageFactory
    public final ProtobufStateStorage<Object> createForMigration(Context context) {
        return a(context, b(context));
    }
}
