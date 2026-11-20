package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers;

import android.annotation.SuppressLint;
import android.util.SparseArray;
import com.scanflow.datacapture.barinternal.kotlin.Lazy;
import com.scanflow.datacapture.barinternal.kotlin.LazyKt;
import com.scanflow.datacapture.barinternal.kotlin.LazyThreadSafetyMode;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ArrayListSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.IntSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PluginExceptionsKt;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PluginGeneratedSerialDescriptor;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.SerializationConstructorMarker;
import java.util.ArrayList;
import java.util.List;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.KSerializer;
import kotlinx.serialization.Serializable;
import kotlinx.serialization.SerializationStrategy;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.encoding.CompositeEncoder;
import kotlinx.serialization.encoding.Decoder;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: BuiltInSerializer.android.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SparseArraySerializer implements KSerializer {
    private final SerialDescriptor descriptor;
    private final KSerializer surrogateSerializer;

    public SparseArraySerializer(KSerializer elementSerializer) {
        Intrinsics.checkNotNullParameter(elementSerializer, "elementSerializer");
        KSerializer kSerializerSerializer = SparseArraySurrogate.Companion.serializer(elementSerializer);
        this.surrogateSerializer = kSerializerSerializer;
        this.descriptor = kSerializerSerializer.getDescriptor();
    }

    @Override // kotlinx.serialization.KSerializer, kotlinx.serialization.SerializationStrategy, kotlinx.serialization.DeserializationStrategy
    public SerialDescriptor getDescriptor() {
        return this.descriptor;
    }

    @Override // kotlinx.serialization.SerializationStrategy
    public void serialize(Encoder encoder, SparseArray value) {
        Intrinsics.checkNotNullParameter(encoder, "encoder");
        Intrinsics.checkNotNullParameter(value, "value");
        int size = value.size();
        ArrayList arrayList = new ArrayList(size);
        for (int i = 0; i < size; i++) {
            arrayList.add(Integer.valueOf(value.keyAt(i)));
        }
        int size2 = value.size();
        ArrayList arrayList2 = new ArrayList(size2);
        for (int i2 = 0; i2 < size2; i2++) {
            arrayList2.add(value.valueAt(i2));
        }
        encoder.encodeSerializableValue(this.surrogateSerializer, new SparseArraySurrogate(arrayList, arrayList2));
    }

    @Override // kotlinx.serialization.DeserializationStrategy
    public SparseArray deserialize(Decoder decoder) {
        Intrinsics.checkNotNullParameter(decoder, "decoder");
        SparseArraySurrogate sparseArraySurrogate = (SparseArraySurrogate) decoder.decodeSerializableValue(this.surrogateSerializer);
        if (sparseArraySurrogate.getKeys().size() != sparseArraySurrogate.getValues().size()) {
            throw new IllegalArgumentException("Failed requirement.");
        }
        SparseArray sparseArray = new SparseArray(sparseArraySurrogate.getKeys().size());
        int size = sparseArraySurrogate.getKeys().size();
        for (int i = 0; i < size; i++) {
            sparseArray.append(((Number) sparseArraySurrogate.getKeys().get(i)).intValue(), sparseArraySurrogate.getValues().get(i));
        }
        return sparseArray;
    }

    /* JADX INFO: Access modifiers changed from: private */
    /* JADX INFO: compiled from: BuiltInSerializer.android.kt */
    @Serializable
    @SuppressLint({"UnsafeOptInUsageError"})
    static final class SparseArraySurrogate<T> {
        private static final SerialDescriptor $cachedDescriptor;
        private final List keys;
        private final List values;
        public static final Companion Companion = new Companion(null);
        private static final Lazy[] $childSerializers = {LazyKt.lazy(LazyThreadSafetyMode.PUBLICATION, new Function0() { // from class: com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SparseArraySerializer$SparseArraySurrogate$$ExternalSyntheticLambda0
            @Override // kotlin.jvm.functions.Function0
            public final Object invoke() {
                return SparseArraySerializer.SparseArraySurrogate._childSerializers$_anonymous_();
            }
        }), null};

        /* JADX INFO: Access modifiers changed from: private */
        public static final /* synthetic */ KSerializer _childSerializers$_anonymous_() {
            return new ArrayListSerializer(IntSerializer.INSTANCE);
        }

        /* JADX INFO: compiled from: BuiltInSerializer.android.kt */
        public static final class Companion {
            private Companion() {
            }

            public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
                this();
            }

            public final <T> KSerializer<SparseArraySurrogate<T>> serializer(KSerializer<T> typeSerial0) {
                Intrinsics.checkNotNullParameter(typeSerial0, "typeSerial0");
                return new SparseArraySerializer$SparseArraySurrogate$$serializer(typeSerial0);
            }
        }

        static {
            PluginGeneratedSerialDescriptor pluginGeneratedSerialDescriptor = new PluginGeneratedSerialDescriptor("androidx.savedstate.serialization.serializers.SparseArraySerializer.SparseArraySurrogate", null, 2);
            pluginGeneratedSerialDescriptor.addElement("keys", false);
            pluginGeneratedSerialDescriptor.addElement("values", false);
            $cachedDescriptor = pluginGeneratedSerialDescriptor;
        }

        public /* synthetic */ SparseArraySurrogate(int i, List list, List list2, SerializationConstructorMarker serializationConstructorMarker) {
            if (3 != (i & 3)) {
                PluginExceptionsKt.throwMissingFieldException(i, 3, $cachedDescriptor);
            }
            this.keys = list;
            this.values = list2;
        }

        public static final /* synthetic */ void write$Self$savedstate_release(SparseArraySurrogate sparseArraySurrogate, CompositeEncoder compositeEncoder, SerialDescriptor serialDescriptor, KSerializer kSerializer) {
            compositeEncoder.encodeSerializableElement(serialDescriptor, 0, (SerializationStrategy) $childSerializers[0].getValue(), sparseArraySurrogate.keys);
            compositeEncoder.encodeSerializableElement(serialDescriptor, 1, new ArrayListSerializer(kSerializer), sparseArraySurrogate.values);
        }

        public SparseArraySurrogate(List keys, List values) {
            Intrinsics.checkNotNullParameter(keys, "keys");
            Intrinsics.checkNotNullParameter(values, "values");
            this.keys = keys;
            this.values = values;
        }

        public final List getKeys() {
            return this.keys;
        }

        public final List getValues() {
            return this.values;
        }
    }
}
