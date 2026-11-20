package com.google.common.flogger.backend;

import com.google.common.flogger.MetadataKey;
import java.util.Iterator;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
public final class MetadataKeyValueHandlers {
    private static final MetadataHandler.ValueHandler<Object, MetadataKey.KeyValueHandler> EMIT_METADATA = new MetadataHandler.ValueHandler<Object, MetadataKey.KeyValueHandler>() { // from class: com.google.common.flogger.backend.MetadataKeyValueHandlers.1
        @Override // com.google.common.flogger.backend.MetadataHandler.ValueHandler
        public void handle(MetadataKey<Object> metadataKey, Object obj, MetadataKey.KeyValueHandler keyValueHandler) {
            metadataKey.safeEmit(obj, keyValueHandler);
        }
    };
    private static final MetadataHandler.RepeatedValueHandler<Object, MetadataKey.KeyValueHandler> EMIT_REPEATED_METADATA = new MetadataHandler.RepeatedValueHandler<Object, MetadataKey.KeyValueHandler>() { // from class: com.google.common.flogger.backend.MetadataKeyValueHandlers.2
        @Override // com.google.common.flogger.backend.MetadataHandler.RepeatedValueHandler
        public void handle(MetadataKey<Object> metadataKey, Iterator<Object> it, MetadataKey.KeyValueHandler keyValueHandler) {
            metadataKey.safeEmitRepeated(it, keyValueHandler);
        }
    };

    public static MetadataHandler.ValueHandler<Object, MetadataKey.KeyValueHandler> getDefaultValueHandler() {
        return EMIT_METADATA;
    }

    public static MetadataHandler.RepeatedValueHandler<Object, MetadataKey.KeyValueHandler> getDefaultRepeatedValueHandler() {
        return EMIT_REPEATED_METADATA;
    }

    public static MetadataHandler.Builder<MetadataKey.KeyValueHandler> getDefaultBuilder(Set<MetadataKey<?>> set) {
        return MetadataHandler.builder(getDefaultValueHandler()).setDefaultRepeatedHandler(getDefaultRepeatedValueHandler()).ignoring(set);
    }

    public static MetadataHandler<MetadataKey.KeyValueHandler> getDefaultHandler(Set<MetadataKey<?>> set) {
        return getDefaultBuilder(set).build();
    }

    private MetadataKeyValueHandlers() {
    }
}
