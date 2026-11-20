package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.Bundle;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateReader;
import java.util.List;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.DeserializationStrategy;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.StructureKind;
import kotlinx.serialization.encoding.AbstractDecoder;
import kotlinx.serialization.encoding.CompositeDecoder;
import kotlinx.serialization.modules.SerializersModule;

/* JADX INFO: compiled from: SavedStateDecoder.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SavedStateDecoder extends AbstractDecoder {
    private final SavedStateConfiguration configuration;
    private int index;
    private String key;
    private final Bundle savedState;
    private final SerializersModule serializersModule;

    public final Bundle getSavedState$savedstate_release() {
        return this.savedState;
    }

    public SavedStateDecoder(Bundle savedState, SavedStateConfiguration configuration) {
        Intrinsics.checkNotNullParameter(savedState, "savedState");
        Intrinsics.checkNotNullParameter(configuration, "configuration");
        this.savedState = savedState;
        this.configuration = configuration;
        this.key = "";
        this.serializersModule = configuration.getSerializersModule();
    }

    public final String getKey$savedstate_release() {
        return this.key;
    }

    @Override // kotlinx.serialization.encoding.Decoder, kotlinx.serialization.encoding.CompositeDecoder
    public SerializersModule getSerializersModule() {
        return this.serializersModule;
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.CompositeDecoder
    public int decodeElementIndex(SerialDescriptor descriptor) {
        int iM589sizeimpl;
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        if (Intrinsics.areEqual(descriptor.getKind(), StructureKind.LIST.INSTANCE) || Intrinsics.areEqual(descriptor.getKind(), StructureKind.MAP.INSTANCE)) {
            iM589sizeimpl = SavedStateReader.m589sizeimpl(SavedStateReader.m553constructorimpl(this.savedState));
        } else {
            iM589sizeimpl = descriptor.getElementsCount();
        }
        while (true) {
            int i = this.index;
            if (i >= iM589sizeimpl || !descriptor.isElementOptional(i) || decodeElementIndex$presentInEncoding(this, descriptor, this.index)) {
                break;
            }
            this.index++;
        }
        int i2 = this.index;
        if (i2 >= iM589sizeimpl) {
            return -1;
        }
        this.key = descriptor.getElementName(i2);
        int i3 = this.index;
        this.index = i3 + 1;
        return i3;
    }

    private static final boolean decodeElementIndex$presentInEncoding(SavedStateDecoder savedStateDecoder, SerialDescriptor serialDescriptor, int i) {
        return SavedStateReader.m554containsimpl(SavedStateReader.m553constructorimpl(savedStateDecoder.savedState), serialDescriptor.getElementName(i));
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public boolean decodeBoolean() {
        return SavedStateReader.m556getBooleanimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public byte decodeByte() {
        return (byte) SavedStateReader.m567getIntimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public short decodeShort() {
        return (short) SavedStateReader.m567getIntimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public int decodeInt() {
        return SavedStateReader.m567getIntimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public long decodeLong() {
        return SavedStateReader.m571getLongimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public float decodeFloat() {
        return SavedStateReader.m565getFloatimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public double decodeDouble() {
        return SavedStateReader.m563getDoubleimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public char decodeChar() {
        return SavedStateReader.m558getCharimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public String decodeString() {
        return SavedStateReader.m583getStringimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public int decodeEnum(SerialDescriptor enumDescriptor) {
        Intrinsics.checkNotNullParameter(enumDescriptor, "enumDescriptor");
        return SavedStateReader.m567getIntimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final List decodeIntList() {
        return SavedStateReader.m569getIntListimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final List decodeStringList() {
        return SavedStateReader.m585getStringListimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final boolean[] decodeBooleanArray() {
        return SavedStateReader.m557getBooleanArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final char[] decodeCharArray() {
        return SavedStateReader.m559getCharArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final double[] decodeDoubleArray() {
        return SavedStateReader.m564getDoubleArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final float[] decodeFloatArray() {
        return SavedStateReader.m566getFloatArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final int[] decodeIntArray() {
        return SavedStateReader.m568getIntArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final long[] decodeLongArray() {
        return SavedStateReader.m572getLongArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    private final String[] decodeStringArray() {
        return SavedStateReader.m584getStringArrayimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public CompositeDecoder beginStructure(SerialDescriptor descriptor) {
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        return Intrinsics.areEqual(this.key, "") ? this : new SavedStateDecoder(SavedStateReader.m577getSavedStateimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key), this.configuration);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public boolean decodeNotNullMark() {
        return !SavedStateReader.m588isNullimpl(SavedStateReader.m553constructorimpl(this.savedState), this.key);
    }

    @Override // kotlinx.serialization.encoding.AbstractDecoder, kotlinx.serialization.encoding.Decoder
    public Object decodeSerializableValue(DeserializationStrategy deserializer) {
        Intrinsics.checkNotNullParameter(deserializer, "deserializer");
        Object objDecodeFormatSpecificTypes = decodeFormatSpecificTypes(deserializer);
        return objDecodeFormatSpecificTypes == null ? super.decodeSerializableValue(deserializer) : objDecodeFormatSpecificTypes;
    }

    private final Object decodeFormatSpecificTypes(DeserializationStrategy deserializationStrategy) {
        Object objDecodeFormatSpecificTypesOnPlatform = SavedStateDecoder_androidKt.decodeFormatSpecificTypesOnPlatform(this, deserializationStrategy);
        if (objDecodeFormatSpecificTypesOnPlatform != null) {
            return objDecodeFormatSpecificTypesOnPlatform;
        }
        SerialDescriptor descriptor = deserializationStrategy.getDescriptor();
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getIntListDescriptor())) {
            return decodeIntList();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getStringListDescriptor())) {
            return decodeStringList();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getBooleanArrayDescriptor())) {
            return decodeBooleanArray();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getCharArrayDescriptor())) {
            return decodeCharArray();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getDoubleArrayDescriptor())) {
            return decodeDoubleArray();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getFloatArrayDescriptor())) {
            return decodeFloatArray();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getIntArrayDescriptor())) {
            return decodeIntArray();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getLongArrayDescriptor())) {
            return decodeLongArray();
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getStringArrayDescriptor())) {
            return decodeStringArray();
        }
        return null;
    }
}
