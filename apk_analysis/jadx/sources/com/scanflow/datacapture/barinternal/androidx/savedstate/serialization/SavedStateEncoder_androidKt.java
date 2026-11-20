package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.IBinder;
import android.os.Parcelable;
import android.util.SparseArray;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceArraySerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceListSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.DefaultJavaSerializableSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.DefaultParcelableSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.IBinderSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.ParcelableArraySerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.ParcelableListSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SparseParcelableArraySerializer;
import java.io.Serializable;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.SerializationStrategy;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.encoding.Encoder;

/* JADX INFO: compiled from: SavedStateEncoder.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateEncoder_androidKt {
    public static final boolean encodeFormatSpecificTypesOnPlatform(SavedStateEncoder savedStateEncoder, SerializationStrategy strategy, Object obj) {
        Intrinsics.checkNotNullParameter(savedStateEncoder, "<this>");
        Intrinsics.checkNotNullParameter(strategy, "strategy");
        SerialDescriptor descriptor = strategy.getDescriptor();
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicCharSequenceDescriptor())) {
            CharSequenceSerializer charSequenceSerializer = CharSequenceSerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.CharSequence");
            charSequenceSerializer.serialize((Encoder) savedStateEncoder, (CharSequence) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicParcelableDescriptor())) {
            DefaultParcelableSerializer defaultParcelableSerializer = DefaultParcelableSerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type android.os.Parcelable");
            defaultParcelableSerializer.serialize((Encoder) savedStateEncoder, (Parcelable) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicJavaSerializableDescriptor())) {
            DefaultJavaSerializableSerializer defaultJavaSerializableSerializer = DefaultJavaSerializableSerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type java.io.Serializable");
            defaultJavaSerializableSerializer.serialize((Encoder) savedStateEncoder, (Serializable) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicIBinderDescriptor())) {
            IBinderSerializer iBinderSerializer = IBinderSerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type android.os.IBinder");
            iBinderSerializer.serialize((Encoder) savedStateEncoder, (IBinder) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getCharSequenceArrayDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicCharSequenceArrayDescriptor())) {
            CharSequenceArraySerializer charSequenceArraySerializer = CharSequenceArraySerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.Array<kotlin.CharSequence>");
            charSequenceArraySerializer.serialize((Encoder) savedStateEncoder, (CharSequence[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getCharSequenceListDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicCharSequenceListDescriptor())) {
            CharSequenceListSerializer charSequenceListSerializer = CharSequenceListSerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.collections.List<kotlin.CharSequence>");
            charSequenceListSerializer.serialize((Encoder) savedStateEncoder, (List) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getParcelableArrayDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicParcelableArrayDescriptor())) {
            ParcelableArraySerializer parcelableArraySerializer = ParcelableArraySerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.Array<android.os.Parcelable>");
            parcelableArraySerializer.serialize((Encoder) savedStateEncoder, (Parcelable[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getParcelableListDescriptor()) || Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicParcelableListDescriptor())) {
            ParcelableListSerializer parcelableListSerializer = ParcelableListSerializer.INSTANCE;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.collections.List<android.os.Parcelable>");
            parcelableListSerializer.serialize((Encoder) savedStateEncoder, (List) obj);
            return true;
        }
        if (!Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getSparseParcelableArrayDescriptor()) && !Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getPolymorphicSparseParcelableArrayDescriptor()) && !Intrinsics.areEqual(descriptor, SavedStateCodecUtils_androidKt.getNullablePolymorphicSparseParcelableArrayDescriptor())) {
            return false;
        }
        SparseParcelableArraySerializer sparseParcelableArraySerializer = SparseParcelableArraySerializer.INSTANCE;
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type android.util.SparseArray<android.os.Parcelable>");
        sparseParcelableArraySerializer.serialize((Encoder) savedStateEncoder, (SparseArray) obj);
        return true;
    }
}
