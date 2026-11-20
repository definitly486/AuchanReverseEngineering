package com.scanflow.datacapture.barinternal.androidx.savedstate.serialization;

import android.os.Bundle;
import com.scanflow.datacapture.barinternal.androidx.core.os.BundleKt;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateReader;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateWriter;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.serialization.SerializationStrategy;
import kotlinx.serialization.descriptors.SerialDescriptor;
import kotlinx.serialization.descriptors.StructureKind;
import kotlinx.serialization.encoding.AbstractEncoder;
import kotlinx.serialization.encoding.CompositeEncoder;
import kotlinx.serialization.modules.SerializersModule;

/* JADX INFO: compiled from: SavedStateEncoder.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SavedStateEncoder extends AbstractEncoder {
    private final SavedStateConfiguration configuration;
    private String key;
    private final Bundle savedState;
    private final SerializersModule serializersModule;

    public final Bundle getSavedState$savedstate_release() {
        return this.savedState;
    }

    public SavedStateEncoder(Bundle savedState, SavedStateConfiguration configuration) {
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

    @Override // kotlinx.serialization.encoding.Encoder
    public SerializersModule getSerializersModule() {
        return this.serializersModule;
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.CompositeEncoder
    public boolean shouldEncodeElementDefault(SerialDescriptor descriptor, int i) {
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        return this.configuration.getEncodeDefaults();
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder
    public boolean encodeElement(SerialDescriptor descriptor, int i) {
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        String elementName = descriptor.getElementName(i);
        this.key = elementName;
        checkDiscriminatorCollisions(this.savedState, elementName);
        return true;
    }

    private final void checkDiscriminatorCollisions(Bundle bundle, String str) {
        if (this.configuration.getClassDiscriminatorMode() == 1) {
            boolean zM554containsimpl = SavedStateReader.m554containsimpl(SavedStateReader.m553constructorimpl(bundle), "type");
            boolean zAreEqual = Intrinsics.areEqual(str, "type");
            if (zM554containsimpl && zAreEqual) {
                throw new IllegalArgumentException("SavedStateEncoder for " + SavedStateReader.m583getStringimpl(SavedStateReader.m553constructorimpl(bundle), "type") + " has property '" + str + "' that conflicts with the class discriminator. You can rename a property with @SerialName annotation.");
            }
        }
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeBoolean(boolean z) {
        SavedStateWriter.m594putBooleanimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, z);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeByte(byte b) {
        SavedStateWriter.m605putIntimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, b);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeShort(short s) {
        SavedStateWriter.m605putIntimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, s);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeInt(int i) {
        SavedStateWriter.m605putIntimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, i);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeLong(long j) {
        SavedStateWriter.m609putLongimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, j);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeFloat(float f) {
        SavedStateWriter.m603putFloatimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, f);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeDouble(double d) {
        SavedStateWriter.m601putDoubleimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, d);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeChar(char c) {
        SavedStateWriter.m596putCharimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, c);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeString(String value) {
        Intrinsics.checkNotNullParameter(value, "value");
        SavedStateWriter.m619putStringimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, value);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeEnum(SerialDescriptor enumDescriptor, int i) {
        Intrinsics.checkNotNullParameter(enumDescriptor, "enumDescriptor");
        SavedStateWriter.m605putIntimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, i);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeNull() {
        SavedStateWriter.m611putNullimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key);
    }

    private final void encodeIntList(List list) {
        SavedStateWriter.m607putIntListimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, list);
    }

    private final void encodeStringList(List list) {
        SavedStateWriter.m621putStringListimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, list);
    }

    private final void encodeBooleanArray(boolean[] zArr) {
        SavedStateWriter.m595putBooleanArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, zArr);
    }

    private final void encodeCharArray(char[] cArr) {
        SavedStateWriter.m597putCharArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, cArr);
    }

    private final void encodeDoubleArray(double[] dArr) {
        SavedStateWriter.m602putDoubleArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, dArr);
    }

    private final void encodeFloatArray(float[] fArr) {
        SavedStateWriter.m604putFloatArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, fArr);
    }

    private final void encodeIntArray(int[] iArr) {
        SavedStateWriter.m606putIntArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, iArr);
    }

    private final void encodeLongArray(long[] jArr) {
        SavedStateWriter.m610putLongArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, jArr);
    }

    private final void encodeStringArray(String[] strArr) {
        SavedStateWriter.m620putStringArrayimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, strArr);
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public CompositeEncoder beginStructure(SerialDescriptor descriptor) {
        Pair[] pairArr;
        Intrinsics.checkNotNullParameter(descriptor, "descriptor");
        if (Intrinsics.areEqual(this.key, "")) {
            putClassDiscriminatorIfRequired(this.configuration, descriptor, this.savedState);
            return this;
        }
        Map mapEmptyMap = MapsKt.emptyMap();
        if (mapEmptyMap.isEmpty()) {
            pairArr = new Pair[0];
        } else {
            ArrayList arrayList = new ArrayList(mapEmptyMap.size());
            for (Map.Entry entry : mapEmptyMap.entrySet()) {
                arrayList.add(TuplesKt.to((String) entry.getKey(), entry.getValue()));
            }
            pairArr = (Pair[]) arrayList.toArray(new Pair[0]);
        }
        Bundle bundleBundleOf = BundleKt.bundleOf((Pair[]) Arrays.copyOf(pairArr, pairArr.length));
        SavedStateWriter.m591constructorimpl(bundleBundleOf);
        SavedStateWriter.m615putSavedStateimpl(SavedStateWriter.m591constructorimpl(this.savedState), this.key, bundleBundleOf);
        putClassDiscriminatorIfRequired(this.configuration, descriptor, bundleBundleOf);
        return new SavedStateEncoder(bundleBundleOf, this.configuration);
    }

    private final void putClassDiscriminatorIfRequired(SavedStateConfiguration savedStateConfiguration, SerialDescriptor serialDescriptor, Bundle bundle) {
        if (savedStateConfiguration.getClassDiscriminatorMode() == 1 && !SavedStateReader.m554containsimpl(SavedStateReader.m553constructorimpl(bundle), "type")) {
            if (Intrinsics.areEqual(serialDescriptor.getKind(), StructureKind.CLASS.INSTANCE) || Intrinsics.areEqual(serialDescriptor.getKind(), StructureKind.OBJECT.INSTANCE)) {
                SavedStateWriter.m619putStringimpl(SavedStateWriter.m591constructorimpl(bundle), "type", serialDescriptor.getSerialName());
            }
        }
    }

    @Override // kotlinx.serialization.encoding.AbstractEncoder, kotlinx.serialization.encoding.Encoder
    public void encodeSerializableValue(SerializationStrategy serializer, Object obj) {
        Intrinsics.checkNotNullParameter(serializer, "serializer");
        if (encodeFormatSpecificTypes(serializer, obj)) {
            return;
        }
        super.encodeSerializableValue(serializer, obj);
    }

    private final boolean encodeFormatSpecificTypes(SerializationStrategy serializationStrategy, Object obj) {
        if (SavedStateEncoder_androidKt.encodeFormatSpecificTypesOnPlatform(this, serializationStrategy, obj)) {
            return true;
        }
        SerialDescriptor descriptor = serializationStrategy.getDescriptor();
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getIntListDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.collections.List<kotlin.Int>");
            encodeIntList((List) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getStringListDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.collections.List<kotlin.String>");
            encodeStringList((List) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getBooleanArrayDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.BooleanArray");
            encodeBooleanArray((boolean[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getCharArrayDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.CharArray");
            encodeCharArray((char[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getDoubleArrayDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.DoubleArray");
            encodeDoubleArray((double[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getFloatArrayDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.FloatArray");
            encodeFloatArray((float[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getIntArrayDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.IntArray");
            encodeIntArray((int[]) obj);
            return true;
        }
        if (Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getLongArrayDescriptor())) {
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.LongArray");
            encodeLongArray((long[]) obj);
            return true;
        }
        if (!Intrinsics.areEqual(descriptor, SavedStateCodecUtilsKt.getStringArrayDescriptor())) {
            return false;
        }
        Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type kotlin.Array<kotlin.String>");
        encodeStringArray((String[]) obj);
        return true;
    }
}
