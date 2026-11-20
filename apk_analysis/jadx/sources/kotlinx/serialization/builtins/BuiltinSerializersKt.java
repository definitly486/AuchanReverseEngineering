package kotlinx.serialization.builtins;

import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.Triple;
import com.scanflow.datacapture.barinternal.kotlin.UByte;
import com.scanflow.datacapture.barinternal.kotlin.UByteArray;
import com.scanflow.datacapture.barinternal.kotlin.UInt;
import com.scanflow.datacapture.barinternal.kotlin.UIntArray;
import com.scanflow.datacapture.barinternal.kotlin.ULong;
import com.scanflow.datacapture.barinternal.kotlin.ULongArray;
import com.scanflow.datacapture.barinternal.kotlin.UShort;
import com.scanflow.datacapture.barinternal.kotlin.UShortArray;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.time.Duration;
import com.scanflow.datacapture.barinternal.kotlin.time.Instant;
import com.scanflow.datacapture.barinternal.kotlin.uuid.Uuid;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ArrayListSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.BooleanArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.BooleanSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ByteArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ByteSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CharArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.CharSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.DoubleArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.DoubleSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.DurationSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.FloatArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.FloatSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.InstantSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.IntArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.IntSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.LinkedHashMapSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.LinkedHashSetSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.LongArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.LongSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.MapEntrySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.NothingSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.NullableSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.PairSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ReferenceArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ShortArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ShortSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.StringSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.TripleSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UByteArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UByteSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UIntArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UIntSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ULongArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.ULongSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UShortArraySerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UShortSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UnitSerializer;
import com.scanflow.datacapture.barinternal.kotlinx.serialization.internal.UuidSerializer;
import java.util.List;
import java.util.Map;
import java.util.Set;
import kotlin.jvm.internal.BooleanCompanionObject;
import kotlin.jvm.internal.ByteCompanionObject;
import kotlin.jvm.internal.CharCompanionObject;
import kotlin.jvm.internal.DoubleCompanionObject;
import kotlin.jvm.internal.FloatCompanionObject;
import kotlin.jvm.internal.IntCompanionObject;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.LongCompanionObject;
import kotlin.jvm.internal.Reflection;
import kotlin.jvm.internal.ShortCompanionObject;
import kotlin.jvm.internal.StringCompanionObject;
import kotlin.reflect.KClass;
import kotlinx.serialization.ExperimentalSerializationApi;
import kotlinx.serialization.KSerializer;

/* JADX INFO: compiled from: BuiltinSerializers.kt */
/* JADX INFO: loaded from: classes3.dex */
public final class BuiltinSerializersKt {
    public static final <T> KSerializer<T> getNullable(KSerializer<T> kSerializer) {
        Intrinsics.checkNotNullParameter(kSerializer, "<this>");
        return kSerializer.getDescriptor().isNullable() ? kSerializer : new NullableSerializer(kSerializer);
    }

    public static final <K, V> KSerializer<Pair> PairSerializer(KSerializer<K> keySerializer, KSerializer<V> valueSerializer) {
        Intrinsics.checkNotNullParameter(keySerializer, "keySerializer");
        Intrinsics.checkNotNullParameter(valueSerializer, "valueSerializer");
        return new PairSerializer(keySerializer, valueSerializer);
    }

    public static final <K, V> KSerializer<Map.Entry<K, V>> MapEntrySerializer(KSerializer<K> keySerializer, KSerializer<V> valueSerializer) {
        Intrinsics.checkNotNullParameter(keySerializer, "keySerializer");
        Intrinsics.checkNotNullParameter(valueSerializer, "valueSerializer");
        return new MapEntrySerializer(keySerializer, valueSerializer);
    }

    public static final <A, B, C> KSerializer<Triple> TripleSerializer(KSerializer<A> aSerializer, KSerializer<B> bSerializer, KSerializer<C> cSerializer) {
        Intrinsics.checkNotNullParameter(aSerializer, "aSerializer");
        Intrinsics.checkNotNullParameter(bSerializer, "bSerializer");
        Intrinsics.checkNotNullParameter(cSerializer, "cSerializer");
        return new TripleSerializer(aSerializer, bSerializer, cSerializer);
    }

    public static final KSerializer<Character> serializer(CharCompanionObject charCompanionObject) {
        Intrinsics.checkNotNullParameter(charCompanionObject, "<this>");
        return CharSerializer.INSTANCE;
    }

    public static final KSerializer<char[]> CharArraySerializer() {
        return CharArraySerializer.INSTANCE;
    }

    public static final KSerializer<Byte> serializer(ByteCompanionObject byteCompanionObject) {
        Intrinsics.checkNotNullParameter(byteCompanionObject, "<this>");
        return ByteSerializer.INSTANCE;
    }

    public static final KSerializer<byte[]> ByteArraySerializer() {
        return ByteArraySerializer.INSTANCE;
    }

    @ExperimentalSerializationApi
    public static final KSerializer<UByteArray> UByteArraySerializer() {
        return UByteArraySerializer.INSTANCE;
    }

    public static final KSerializer<Short> serializer(ShortCompanionObject shortCompanionObject) {
        Intrinsics.checkNotNullParameter(shortCompanionObject, "<this>");
        return ShortSerializer.INSTANCE;
    }

    public static final KSerializer<short[]> ShortArraySerializer() {
        return ShortArraySerializer.INSTANCE;
    }

    @ExperimentalSerializationApi
    public static final KSerializer<UShortArray> UShortArraySerializer() {
        return UShortArraySerializer.INSTANCE;
    }

    public static final KSerializer<Integer> serializer(IntCompanionObject intCompanionObject) {
        Intrinsics.checkNotNullParameter(intCompanionObject, "<this>");
        return IntSerializer.INSTANCE;
    }

    public static final KSerializer<int[]> IntArraySerializer() {
        return IntArraySerializer.INSTANCE;
    }

    @ExperimentalSerializationApi
    public static final KSerializer<UIntArray> UIntArraySerializer() {
        return UIntArraySerializer.INSTANCE;
    }

    public static final KSerializer<Long> serializer(LongCompanionObject longCompanionObject) {
        Intrinsics.checkNotNullParameter(longCompanionObject, "<this>");
        return LongSerializer.INSTANCE;
    }

    public static final KSerializer<long[]> LongArraySerializer() {
        return LongArraySerializer.INSTANCE;
    }

    @ExperimentalSerializationApi
    public static final KSerializer<ULongArray> ULongArraySerializer() {
        return ULongArraySerializer.INSTANCE;
    }

    public static final KSerializer<Float> serializer(FloatCompanionObject floatCompanionObject) {
        Intrinsics.checkNotNullParameter(floatCompanionObject, "<this>");
        return FloatSerializer.INSTANCE;
    }

    public static final KSerializer<float[]> FloatArraySerializer() {
        return FloatArraySerializer.INSTANCE;
    }

    public static final KSerializer<Double> serializer(DoubleCompanionObject doubleCompanionObject) {
        Intrinsics.checkNotNullParameter(doubleCompanionObject, "<this>");
        return DoubleSerializer.INSTANCE;
    }

    public static final KSerializer<double[]> DoubleArraySerializer() {
        return DoubleArraySerializer.INSTANCE;
    }

    public static final KSerializer<Boolean> serializer(BooleanCompanionObject booleanCompanionObject) {
        Intrinsics.checkNotNullParameter(booleanCompanionObject, "<this>");
        return BooleanSerializer.INSTANCE;
    }

    public static final KSerializer<boolean[]> BooleanArraySerializer() {
        return BooleanArraySerializer.INSTANCE;
    }

    public static final KSerializer<Unit> serializer(Unit unit) {
        Intrinsics.checkNotNullParameter(unit, "<this>");
        return UnitSerializer.INSTANCE;
    }

    public static final KSerializer<String> serializer(StringCompanionObject stringCompanionObject) {
        Intrinsics.checkNotNullParameter(stringCompanionObject, "<this>");
        return StringSerializer.INSTANCE;
    }

    @ExperimentalSerializationApi
    public static final /* synthetic */ <T, E extends T> KSerializer<E[]> ArraySerializer(KSerializer<E> elementSerializer) {
        Intrinsics.checkNotNullParameter(elementSerializer, "elementSerializer");
        Intrinsics.reifiedOperationMarker(4, "T");
        return ArraySerializer(Reflection.getOrCreateKotlinClass(Object.class), elementSerializer);
    }

    @ExperimentalSerializationApi
    public static final <T, E extends T> KSerializer<E[]> ArraySerializer(KClass<T> kClass, KSerializer<E> elementSerializer) {
        Intrinsics.checkNotNullParameter(kClass, "kClass");
        Intrinsics.checkNotNullParameter(elementSerializer, "elementSerializer");
        return new ReferenceArraySerializer(kClass, elementSerializer);
    }

    public static final <T> KSerializer<List<T>> ListSerializer(KSerializer<T> elementSerializer) {
        Intrinsics.checkNotNullParameter(elementSerializer, "elementSerializer");
        return new ArrayListSerializer(elementSerializer);
    }

    public static final <T> KSerializer<Set<T>> SetSerializer(KSerializer<T> elementSerializer) {
        Intrinsics.checkNotNullParameter(elementSerializer, "elementSerializer");
        return new LinkedHashSetSerializer(elementSerializer);
    }

    public static final <K, V> KSerializer<Map<K, V>> MapSerializer(KSerializer<K> keySerializer, KSerializer<V> valueSerializer) {
        Intrinsics.checkNotNullParameter(keySerializer, "keySerializer");
        Intrinsics.checkNotNullParameter(valueSerializer, "valueSerializer");
        return new LinkedHashMapSerializer(keySerializer, valueSerializer);
    }

    public static final KSerializer<UInt> serializer(UInt.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return UIntSerializer.INSTANCE;
    }

    public static final KSerializer<ULong> serializer(ULong.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return ULongSerializer.INSTANCE;
    }

    public static final KSerializer<UByte> serializer(UByte.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return UByteSerializer.INSTANCE;
    }

    public static final KSerializer<UShort> serializer(UShort.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return UShortSerializer.INSTANCE;
    }

    public static final KSerializer<Duration> serializer(Duration.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return DurationSerializer.INSTANCE;
    }

    public static final KSerializer<Instant> serializer(Instant.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return InstantSerializer.INSTANCE;
    }

    public static final KSerializer<Uuid> serializer(Uuid.Companion companion) {
        Intrinsics.checkNotNullParameter(companion, "<this>");
        return UuidSerializer.INSTANCE;
    }

    @ExperimentalSerializationApi
    public static final KSerializer NothingSerializer() {
        return NothingSerializer.INSTANCE;
    }
}
