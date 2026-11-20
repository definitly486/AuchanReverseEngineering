package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.Parcelable;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceArraySerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceListSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.DefaultJavaSerializableSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.DefaultParcelableSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.IBinderSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.ParcelableArraySerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.ParcelableListSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SparseParcelableArraySerializer;
import com.scanflow.datacapture.barinternal.kotlin.jvm.JvmClassMappingKt;
import java.util.Arrays;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;
import kotlin.reflect.KClass;
import kotlinx.serialization.DeserializationStrategy;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.encoding.Decoder;

/* JADX INFO: compiled from: SavedStateDecoder.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateDecoder_androidKt {
    public static final Object decodeFormatSpecificTypesOnPlatform(SavedStateDecoder savedStateDecoder, DeserializationStrategy strategy) {
        Intrinsics.checkNotNullParameter(savedStateDecoder, "<this>");
        Intrinsics.checkNotNullParameter(strategy, "strategy");
        SerialDescriptor descriptor = strategy.getDescriptor();
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicCharSequenceDescriptor())) {
            return CharSequenceSerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicParcelableDescriptor())) {
            return DefaultParcelableSerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicJavaSerializableDescriptor())) {
            return DefaultJavaSerializableSerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicIBinderDescriptor())) {
            return IBinderSerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getCharSequenceArrayDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicCharSequenceArrayDescriptor())) {
            return CharSequenceArraySerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getCharSequenceListDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicCharSequenceListDescriptor())) {
            return CharSequenceListSerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getParcelableArrayDescriptor())) {
            Parcelable[] parcelableArrDeserialize = ParcelableArraySerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
            return Arrays.copyOf(parcelableArrDeserialize, parcelableArrDeserialize.length, JvmClassMappingKt.getJavaClass(getArrayKClass(strategy)));
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicParcelableArrayDescriptor())) {
            return ParcelableArraySerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getParcelableListDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicParcelableListDescriptor())) {
            return ParcelableListSerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getSparseParcelableArrayDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicSparseParcelableArrayDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getNullablePolymorphicSparseParcelableArrayDescriptor())) {
            return SparseParcelableArraySerializer.INSTANCE.deserialize((Decoder) savedStateDecoder);
        }
        return null;
    }

    private static final KClass getArrayKClass(DeserializationStrategy deserializationStrategy) {
        Object objDeserialize = deserializationStrategy.deserialize(EmptyArrayDecoder.INSTANCE);
        Intrinsics.checkNotNull(objDeserialize);
        return Reflection.getOrCreateKotlinClass(objDeserialize.getClass());
    }
}
