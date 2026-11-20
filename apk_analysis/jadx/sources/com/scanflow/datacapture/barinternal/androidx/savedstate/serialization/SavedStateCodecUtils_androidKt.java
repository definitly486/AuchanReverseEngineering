package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.IBinder;
import android.os.Parcelable;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.CharSequenceSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.DefaultParcelableSerializer;
import com.scanflow.datacapture.barinternal.androidx.savedstate.serialization.serializers.SparseArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.PolymorphicSerializer;
import java.io.Serializable;
import kotlin.jvm.internal.Reflection;
import kotlinx.serialization.builtins.BuiltinSerializersKt;
import kotlinx.serialization.descriptors.SerialDescriptor;

/* JADX INFO: compiled from: SavedStateCodecUtils.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateCodecUtils_androidKt {
    private static final SerialDescriptor charSequenceArrayDescriptor;
    private static final SerialDescriptor charSequenceListDescriptor;
    private static final SerialDescriptor nullablePolymorphicSparseParcelableArrayDescriptor;
    private static final SerialDescriptor parcelableArrayDescriptor;
    private static final SerialDescriptor parcelableListDescriptor;
    private static final SerialDescriptor polymorphicCharSequenceArrayDescriptor;
    private static final SerialDescriptor polymorphicCharSequenceListDescriptor;
    private static final SerialDescriptor polymorphicParcelableArrayDescriptor;
    private static final SerialDescriptor polymorphicParcelableListDescriptor;
    private static final SerialDescriptor polymorphicSparseParcelableArrayDescriptor;
    private static final SerialDescriptor sparseParcelableArrayDescriptor;
    private static final SerialDescriptor polymorphicCharSequenceDescriptor = new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(CharSequence.class)).getDescriptor();
    private static final SerialDescriptor polymorphicParcelableDescriptor = new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(Parcelable.class)).getDescriptor();
    private static final SerialDescriptor polymorphicJavaSerializableDescriptor = new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(Serializable.class)).getDescriptor();
    private static final SerialDescriptor polymorphicIBinderDescriptor = new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(IBinder.class)).getDescriptor();

    public static final SerialDescriptor getPolymorphicCharSequenceDescriptor() {
        return polymorphicCharSequenceDescriptor;
    }

    static {
        DefaultParcelableSerializer defaultParcelableSerializer = DefaultParcelableSerializer.INSTANCE;
        parcelableArrayDescriptor = BuiltinSerializersKt.ArraySerializer(Reflection.getOrCreateKotlinClass(Parcelable.class), defaultParcelableSerializer).getDescriptor();
        polymorphicParcelableArrayDescriptor = BuiltinSerializersKt.ArraySerializer(Reflection.getOrCreateKotlinClass(Parcelable.class), new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(Parcelable.class))).getDescriptor();
        parcelableListDescriptor = BuiltinSerializersKt.ListSerializer(defaultParcelableSerializer).getDescriptor();
        polymorphicParcelableListDescriptor = BuiltinSerializersKt.ListSerializer(new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(Parcelable.class))).getDescriptor();
        CharSequenceSerializer charSequenceSerializer = CharSequenceSerializer.INSTANCE;
        charSequenceArrayDescriptor = BuiltinSerializersKt.ArraySerializer(Reflection.getOrCreateKotlinClass(CharSequence.class), charSequenceSerializer).getDescriptor();
        polymorphicCharSequenceArrayDescriptor = BuiltinSerializersKt.ArraySerializer(Reflection.getOrCreateKotlinClass(CharSequence.class), new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(CharSequence.class))).getDescriptor();
        charSequenceListDescriptor = BuiltinSerializersKt.ListSerializer(charSequenceSerializer).getDescriptor();
        polymorphicCharSequenceListDescriptor = BuiltinSerializersKt.ListSerializer(new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(CharSequence.class))).getDescriptor();
        sparseParcelableArrayDescriptor = new SparseArraySerializer(defaultParcelableSerializer).getDescriptor();
        polymorphicSparseParcelableArrayDescriptor = new SparseArraySerializer(new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(Parcelable.class))).getDescriptor();
        nullablePolymorphicSparseParcelableArrayDescriptor = new SparseArraySerializer(BuiltinSerializersKt.getNullable(new PolymorphicSerializer(Reflection.getOrCreateKotlinClass(Parcelable.class)))).getDescriptor();
    }

    public static final SerialDescriptor getPolymorphicParcelableDescriptor() {
        return polymorphicParcelableDescriptor;
    }

    public static final SerialDescriptor getPolymorphicJavaSerializableDescriptor() {
        return polymorphicJavaSerializableDescriptor;
    }

    public static final SerialDescriptor getPolymorphicIBinderDescriptor() {
        return polymorphicIBinderDescriptor;
    }

    public static final SerialDescriptor getParcelableArrayDescriptor() {
        return parcelableArrayDescriptor;
    }

    public static final SerialDescriptor getPolymorphicParcelableArrayDescriptor() {
        return polymorphicParcelableArrayDescriptor;
    }

    public static final SerialDescriptor getParcelableListDescriptor() {
        return parcelableListDescriptor;
    }

    public static final SerialDescriptor getPolymorphicParcelableListDescriptor() {
        return polymorphicParcelableListDescriptor;
    }

    public static final SerialDescriptor getCharSequenceArrayDescriptor() {
        return charSequenceArrayDescriptor;
    }

    public static final SerialDescriptor getPolymorphicCharSequenceArrayDescriptor() {
        return polymorphicCharSequenceArrayDescriptor;
    }

    public static final SerialDescriptor getCharSequenceListDescriptor() {
        return charSequenceListDescriptor;
    }

    public static final SerialDescriptor getPolymorphicCharSequenceListDescriptor() {
        return polymorphicCharSequenceListDescriptor;
    }

    public static final SerialDescriptor getSparseParcelableArrayDescriptor() {
        return sparseParcelableArrayDescriptor;
    }

    public static final SerialDescriptor getPolymorphicSparseParcelableArrayDescriptor() {
        return polymorphicSparseParcelableArrayDescriptor;
    }

    public static final SerialDescriptor getNullablePolymorphicSparseParcelableArrayDescriptor() {
        return nullablePolymorphicSparseParcelableArrayDescriptor;
    }
}
