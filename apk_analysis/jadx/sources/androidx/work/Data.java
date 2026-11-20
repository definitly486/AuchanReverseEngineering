package androidx.work;

import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import com.scanflow.datacapture.barinternal.kotlin.io.CloseableKt;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Objects;
import java.util.Set;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Reflection;
import kotlin.reflect.KClass;

/* JADX INFO: compiled from: Data_.kt */
/* JADX INFO: loaded from: classes.dex */
public final class Data {
    public static final Companion Companion = new Companion(null);
    public static final Data EMPTY = new Builder().build();
    private final Map values;

    public static final Data fromByteArray(byte[] bArr) {
        return Companion.fromByteArray(bArr);
    }

    public static final byte[] toByteArrayInternalV0(Data data) {
        return Companion.toByteArrayInternalV0(data);
    }

    public static final byte[] toByteArrayInternalV1(Data data) {
        return Companion.toByteArrayInternalV1(data);
    }

    public Data(Data other) {
        Intrinsics.checkNotNullParameter(other, "other");
        this.values = new HashMap(other.values);
    }

    public Data(Map<String, ?> values) {
        Intrinsics.checkNotNullParameter(values, "values");
        this.values = new HashMap(values);
    }

    public final boolean[] getBooleanArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getBooleanArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (Boolean) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.Boolean");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        boolean[] zArr = new boolean[length];
        for (int i = 0; i < length; i++) {
            zArr[i] = ((Boolean) function1.invoke(Integer.valueOf(i))).booleanValue();
        }
        return zArr;
    }

    public final byte[] getByteArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getByteArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (Byte) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.Byte");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        byte[] bArr = new byte[length];
        for (int i = 0; i < length; i++) {
            bArr[i] = ((Number) function1.invoke(Integer.valueOf(i))).byteValue();
        }
        return bArr;
    }

    public final double[] getDoubleArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getDoubleArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (Double) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.Double");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        double[] dArr = new double[length];
        for (int i = 0; i < length; i++) {
            dArr[i] = ((Number) function1.invoke(Integer.valueOf(i))).doubleValue();
        }
        return dArr;
    }

    public final float[] getFloatArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getFloatArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (Float) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.Float");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        float[] fArr = new float[length];
        for (int i = 0; i < length; i++) {
            fArr[i] = ((Number) function1.invoke(Integer.valueOf(i))).floatValue();
        }
        return fArr;
    }

    public final int[] getIntArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getIntArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (Integer) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.Int");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        int[] iArr = new int[length];
        for (int i = 0; i < length; i++) {
            iArr[i] = ((Number) function1.invoke(Integer.valueOf(i))).intValue();
        }
        return iArr;
    }

    public final long[] getLongArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getLongArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (Long) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.Long");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        long[] jArr = new long[length];
        for (int i = 0; i < length; i++) {
            jArr[i] = ((Number) function1.invoke(Integer.valueOf(i))).longValue();
        }
        return jArr;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public final String[] getStringArray(String key) {
        Object[] objArr;
        Intrinsics.checkNotNullParameter(key, "key");
        final Object obj = this.values.get(key);
        if (!(obj instanceof Object[]) || (objArr = (Object[]) obj) == null) {
            return null;
        }
        int length = objArr.length;
        Function1 function1 = new Function1() { // from class: androidx.work.Data$getStringArray$$inlined$getTypedArray$1
            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            {
                super(1);
            }

            public final Object invoke(int i) {
                Object obj2 = ((Object[]) obj)[i];
                if (obj2 != null) {
                    return (String) obj2;
                }
                throw new NullPointerException("null cannot be cast to non-null type kotlin.String");
            }

            @Override // kotlin.jvm.functions.Function1
            public /* bridge */ /* synthetic */ Object invoke(Object obj2) {
                return invoke(((Number) obj2).intValue());
            }
        };
        String[] strArr = new String[length];
        for (int i = 0; i < length; i++) {
            strArr[i] = function1.invoke(Integer.valueOf(i));
        }
        return strArr;
    }

    public final boolean getBoolean(String key, boolean z) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object objValueOf = Boolean.valueOf(z);
        Object obj = this.values.get(key);
        if (obj instanceof Boolean) {
            objValueOf = obj;
        }
        return ((Boolean) objValueOf).booleanValue();
    }

    public final byte getByte(String key, byte b) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object objValueOf = Byte.valueOf(b);
        Object obj = this.values.get(key);
        if (obj instanceof Byte) {
            objValueOf = obj;
        }
        return ((Number) objValueOf).byteValue();
    }

    public final int getInt(String key, int i) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object objValueOf = Integer.valueOf(i);
        Object obj = this.values.get(key);
        if (obj instanceof Integer) {
            objValueOf = obj;
        }
        return ((Number) objValueOf).intValue();
    }

    public final long getLong(String key, long j) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object objValueOf = Long.valueOf(j);
        Object obj = this.values.get(key);
        if (obj instanceof Long) {
            objValueOf = obj;
        }
        return ((Number) objValueOf).longValue();
    }

    public final float getFloat(String key, float f) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object objValueOf = Float.valueOf(f);
        Object obj = this.values.get(key);
        if (obj instanceof Float) {
            objValueOf = obj;
        }
        return ((Number) objValueOf).floatValue();
    }

    public final double getDouble(String key, double d) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object objValueOf = Double.valueOf(d);
        Object obj = this.values.get(key);
        if (obj instanceof Double) {
            objValueOf = obj;
        }
        return ((Number) objValueOf).doubleValue();
    }

    public final String getString(String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        Object obj = this.values.get(key);
        if (obj instanceof String) {
            return (String) obj;
        }
        return null;
    }

    public final Map<String, Object> getKeyValueMap() {
        Map<String, Object> mapUnmodifiableMap = Collections.unmodifiableMap(this.values);
        Intrinsics.checkNotNullExpressionValue(mapUnmodifiableMap, "unmodifiableMap(values)");
        return mapUnmodifiableMap;
    }

    public final byte[] toByteArray() {
        return Companion.toByteArrayInternalV1(this);
    }

    public final <T> boolean hasKeyWithValueOfType(String key, Class<T> klass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(klass, "klass");
        Object obj = this.values.get(key);
        return obj != null && klass.isAssignableFrom(obj.getClass());
    }

    public final int size() {
        return this.values.size();
    }

    /* JADX WARN: Code duplicated, block: B:25:0x005c  */
    public boolean equals(Object obj) {
        boolean zAreEqual;
        if (this == obj) {
            return true;
        }
        if (obj == null || !Intrinsics.areEqual(Data.class, obj.getClass())) {
            return false;
        }
        Data data = (Data) obj;
        Set<String> setKeySet = this.values.keySet();
        if (!Intrinsics.areEqual(setKeySet, data.values.keySet())) {
            return false;
        }
        for (String str : setKeySet) {
            Object obj2 = this.values.get(str);
            Object obj3 = data.values.get(str);
            if (obj2 == null || obj3 == null) {
                zAreEqual = obj2 == obj3;
            } else if (obj2 instanceof Object[]) {
                Object[] objArr = (Object[]) obj2;
                if (obj3 instanceof Object[]) {
                    zAreEqual = ArraysKt.contentDeepEquals(objArr, (Object[]) obj3);
                } else {
                    zAreEqual = Intrinsics.areEqual(obj2, obj3);
                }
            } else {
                zAreEqual = Intrinsics.areEqual(obj2, obj3);
            }
            if (!zAreEqual) {
                return false;
            }
        }
        return true;
    }

    public int hashCode() {
        int iHashCode;
        int i = 0;
        for (Map.Entry entry : this.values.entrySet()) {
            Object value = entry.getValue();
            if (value instanceof Object[]) {
                iHashCode = Objects.hashCode(entry.getKey()) ^ ArraysKt.contentDeepHashCode((Object[]) value);
            } else {
                iHashCode = entry.hashCode();
            }
            i += iHashCode;
        }
        return i * 31;
    }

    public String toString() {
        String str = "Data {" + CollectionsKt.joinToString$default(this.values.entrySet(), null, null, null, 0, null, new Function1() { // from class: androidx.work.Data$toString$1$content$1
            @Override // kotlin.jvm.functions.Function1
            public final CharSequence invoke(Map.Entry entry) {
                Intrinsics.checkNotNullParameter(entry, "<name for destructuring parameter 0>");
                String str2 = (String) entry.getKey();
                Object value = entry.getValue();
                StringBuilder sb = new StringBuilder();
                sb.append(str2);
                sb.append(" : ");
                if (value instanceof Object[]) {
                    value = Arrays.toString((Object[]) value);
                    Intrinsics.checkNotNullExpressionValue(value, "toString(this)");
                }
                sb.append(value);
                return sb.toString();
            }
        }, 31, null) + "}";
        Intrinsics.checkNotNullExpressionValue(str, "StringBuilder().apply(builderAction).toString()");
        return str;
    }

    /* JADX INFO: compiled from: Data_.kt */
    public static final class Builder {
        private final Map values = new LinkedHashMap();

        private final Builder putDirect(String str, Object obj) {
            this.values.put(str, obj);
            return this;
        }

        public final Builder putBoolean(String key, boolean z) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, Boolean.valueOf(z));
        }

        public final Builder putBooleanArray(String key, boolean[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            this.values.put(key, Data_Kt.convertPrimitiveArray(value));
            return this;
        }

        public final Builder putByte(String key, byte b) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, Byte.valueOf(b));
        }

        public final Builder putByteArray(String key, byte[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            this.values.put(key, Data_Kt.convertPrimitiveArray(value));
            return this;
        }

        public final Builder putInt(String key, int i) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, Integer.valueOf(i));
        }

        public final Builder putIntArray(String key, int[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            this.values.put(key, Data_Kt.convertPrimitiveArray(value));
            return this;
        }

        public final Builder putLong(String key, long j) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, Long.valueOf(j));
        }

        public final Builder putLongArray(String key, long[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            this.values.put(key, Data_Kt.convertPrimitiveArray(value));
            return this;
        }

        public final Builder putFloat(String key, float f) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, Float.valueOf(f));
        }

        public final Builder putFloatArray(String key, float[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            this.values.put(key, Data_Kt.convertPrimitiveArray(value));
            return this;
        }

        public final Builder putDouble(String key, double d) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, Double.valueOf(d));
        }

        public final Builder putDoubleArray(String key, double[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            this.values.put(key, Data_Kt.convertPrimitiveArray(value));
            return this;
        }

        public final Builder putString(String key, String str) {
            Intrinsics.checkNotNullParameter(key, "key");
            return putDirect(key, str);
        }

        public final Builder putStringArray(String key, String[] value) {
            Intrinsics.checkNotNullParameter(key, "key");
            Intrinsics.checkNotNullParameter(value, "value");
            return putDirect(key, value);
        }

        public final Builder putAll(Data data) {
            Intrinsics.checkNotNullParameter(data, "data");
            putAll(data.values);
            return this;
        }

        public final Builder put(String key, Object obj) {
            Intrinsics.checkNotNullParameter(key, "key");
            Map map = this.values;
            if (obj == null) {
                obj = null;
            } else {
                KClass orCreateKotlinClass = Reflection.getOrCreateKotlinClass(obj.getClass());
                if (!(Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Boolean.TYPE)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Byte.TYPE)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Integer.TYPE)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Long.TYPE)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Float.TYPE)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Double.TYPE)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(String.class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Boolean[].class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Byte[].class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Integer[].class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Long[].class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Float[].class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Double[].class)) ? true : Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(String[].class)))) {
                    if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(boolean[].class))) {
                        obj = Data_Kt.convertPrimitiveArray((boolean[]) obj);
                    } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(byte[].class))) {
                        obj = Data_Kt.convertPrimitiveArray((byte[]) obj);
                    } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(int[].class))) {
                        obj = Data_Kt.convertPrimitiveArray((int[]) obj);
                    } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(long[].class))) {
                        obj = Data_Kt.convertPrimitiveArray((long[]) obj);
                    } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(float[].class))) {
                        obj = Data_Kt.convertPrimitiveArray((float[]) obj);
                    } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(double[].class))) {
                        obj = Data_Kt.convertPrimitiveArray((double[]) obj);
                    } else {
                        throw new IllegalArgumentException("Key " + key + " has invalid type " + orCreateKotlinClass);
                    }
                }
            }
            map.put(key, obj);
            return this;
        }

        public final Data build() {
            Data data = new Data((Map<String, ?>) this.values);
            Data.Companion.toByteArrayInternalV1(data);
            return data;
        }

        public final Builder putAll(Map<String, ? extends Object> values) {
            Intrinsics.checkNotNullParameter(values, "values");
            for (Map.Entry<String, ? extends Object> entry : values.entrySet()) {
                put(entry.getKey(), entry.getValue());
            }
            return this;
        }
    }

    /* JADX INFO: compiled from: Data_.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final byte[] toByteArrayInternalV0(Data data) {
            Intrinsics.checkNotNullParameter(data, "data");
            try {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                try {
                    ObjectOutputStream objectOutputStream = new ObjectOutputStream(byteArrayOutputStream);
                    try {
                        objectOutputStream.writeInt(data.size());
                        for (Map.Entry entry : data.values.entrySet()) {
                            String str = (String) entry.getKey();
                            Object value = entry.getValue();
                            objectOutputStream.writeUTF(str);
                            objectOutputStream.writeObject(value);
                        }
                        Unit unit = Unit.INSTANCE;
                        CloseableKt.closeFinally(objectOutputStream, null);
                        CloseableKt.closeFinally(byteArrayOutputStream, null);
                        if (byteArrayOutputStream.size() > 10240) {
                            throw new IllegalStateException("Data cannot occupy more than 10240 bytes when serialized");
                        }
                        byte[] byteArray = byteArrayOutputStream.toByteArray();
                        Intrinsics.checkNotNullExpressionValue(byteArray, "{\n                val st…ByteArray()\n            }");
                        return byteArray;
                    } catch (Throwable th) {
                        try {
                            throw th;
                        } catch (Throwable th2) {
                            CloseableKt.closeFinally(objectOutputStream, th);
                            throw th2;
                        }
                    }
                } catch (Throwable th3) {
                    try {
                        throw th3;
                    } catch (Throwable th4) {
                        CloseableKt.closeFinally(byteArrayOutputStream, th3);
                        throw th4;
                    }
                }
            } catch (IOException e) {
                Logger.get().error(Data_Kt.TAG, "Error in Data#toByteArray: ", e);
                return new byte[0];
            }
        }

        private static final void toByteArrayInternalV1$writeHeader(DataOutputStream dataOutputStream) throws IOException {
            dataOutputStream.writeShort(-21521);
            dataOutputStream.writeShort(1);
        }

        private static final void toByteArrayInternalV1$writeArray(DataOutputStream dataOutputStream, Object[] objArr) throws IOException {
            int i;
            KClass orCreateKotlinClass = Reflection.getOrCreateKotlinClass(objArr.getClass());
            if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Boolean[].class))) {
                i = 8;
            } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Byte[].class))) {
                i = 9;
            } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Integer[].class))) {
                i = 10;
            } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Long[].class))) {
                i = 11;
            } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Float[].class))) {
                i = 12;
            } else if (Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(Double[].class))) {
                i = 13;
            } else {
                if (!Intrinsics.areEqual(orCreateKotlinClass, Reflection.getOrCreateKotlinClass(String[].class))) {
                    throw new IllegalArgumentException("Unsupported value type " + Reflection.getOrCreateKotlinClass(objArr.getClass()).getQualifiedName());
                }
                i = 14;
            }
            dataOutputStream.writeByte(i);
            dataOutputStream.writeInt(objArr.length);
            for (Object obj : objArr) {
                if (i == 8) {
                    Boolean bool = obj instanceof Boolean ? (Boolean) obj : null;
                    dataOutputStream.writeBoolean(bool != null ? bool.booleanValue() : false);
                } else if (i == 9) {
                    Byte b = obj instanceof Byte ? (Byte) obj : null;
                    dataOutputStream.writeByte(b != null ? b.byteValue() : (byte) 0);
                } else if (i == 10) {
                    Integer num = obj instanceof Integer ? (Integer) obj : null;
                    dataOutputStream.writeInt(num != null ? num.intValue() : 0);
                } else if (i == 11) {
                    Long l = obj instanceof Long ? (Long) obj : null;
                    dataOutputStream.writeLong(l != null ? l.longValue() : 0L);
                } else if (i == 12) {
                    Float f = obj instanceof Float ? (Float) obj : null;
                    dataOutputStream.writeFloat(f != null ? f.floatValue() : 0.0f);
                } else if (i == 13) {
                    Double d = obj instanceof Double ? (Double) obj : null;
                    dataOutputStream.writeDouble(d != null ? d.doubleValue() : 0.0d);
                } else if (i == 14) {
                    String str = obj instanceof String ? (String) obj : null;
                    if (str == null) {
                        str = "androidx.work.Data-95ed6082-b8e9-46e8-a73f-ff56f00f5d9d";
                    }
                    dataOutputStream.writeUTF(str);
                }
            }
        }

        private static final void toByteArrayInternalV1$writeEntry(DataOutputStream dataOutputStream, String str, Object obj) throws IOException {
            if (obj == null) {
                dataOutputStream.writeByte(0);
            } else if (obj instanceof Boolean) {
                dataOutputStream.writeByte(1);
                dataOutputStream.writeBoolean(((Boolean) obj).booleanValue());
            } else if (obj instanceof Byte) {
                dataOutputStream.writeByte(2);
                dataOutputStream.writeByte(((Number) obj).byteValue());
            } else if (obj instanceof Integer) {
                dataOutputStream.writeByte(3);
                dataOutputStream.writeInt(((Number) obj).intValue());
            } else if (obj instanceof Long) {
                dataOutputStream.writeByte(4);
                dataOutputStream.writeLong(((Number) obj).longValue());
            } else if (obj instanceof Float) {
                dataOutputStream.writeByte(5);
                dataOutputStream.writeFloat(((Number) obj).floatValue());
            } else if (obj instanceof Double) {
                dataOutputStream.writeByte(6);
                dataOutputStream.writeDouble(((Number) obj).doubleValue());
            } else if (obj instanceof String) {
                dataOutputStream.writeByte(7);
                dataOutputStream.writeUTF((String) obj);
            } else if (obj instanceof Object[]) {
                toByteArrayInternalV1$writeArray(dataOutputStream, (Object[]) obj);
            } else {
                throw new IllegalArgumentException("Unsupported value type " + Reflection.getOrCreateKotlinClass(obj.getClass()).getSimpleName());
            }
            dataOutputStream.writeUTF(str);
        }

        public final byte[] toByteArrayInternalV1(Data data) {
            Intrinsics.checkNotNullParameter(data, "data");
            try {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                DataOutputStream dataOutputStream = new DataOutputStream(byteArrayOutputStream);
                try {
                    toByteArrayInternalV1$writeHeader(dataOutputStream);
                    dataOutputStream.writeInt(data.size());
                    for (Map.Entry entry : data.values.entrySet()) {
                        toByteArrayInternalV1$writeEntry(dataOutputStream, (String) entry.getKey(), entry.getValue());
                    }
                    dataOutputStream.flush();
                    if (dataOutputStream.size() > 10240) {
                        throw new IllegalStateException("Data cannot occupy more than 10240 bytes when serialized");
                    }
                    byte[] byteArray = byteArrayOutputStream.toByteArray();
                    CloseableKt.closeFinally(dataOutputStream, null);
                    Intrinsics.checkNotNullExpressionValue(byteArray, "{\n                ByteAr…          }\n            }");
                    return byteArray;
                } catch (Throwable th) {
                    try {
                        throw th;
                    } catch (Throwable th2) {
                        CloseableKt.closeFinally(dataOutputStream, th);
                        throw th2;
                    }
                }
            } catch (IOException e) {
                Logger.get().error(Data_Kt.TAG, "Error in Data#toByteArray: ", e);
                return new byte[0];
            }
        }

        private static final boolean fromByteArray$isObjectStream(ByteArrayInputStream byteArrayInputStream) throws IOException {
            byte[] bArr = new byte[2];
            byteArrayInputStream.read(bArr);
            byte b = (byte) (-21267);
            boolean z = false;
            if (bArr[0] == ((byte) 16777132) && bArr[1] == b) {
                z = true;
            }
            byteArrayInputStream.reset();
            return z;
        }

        private static final void fromByteArray$readHeader(DataInputStream dataInputStream) throws IOException {
            short s = dataInputStream.readShort();
            if (s != -21521) {
                throw new IllegalStateException(("Magic number doesn't match: " + ((int) s)).toString());
            }
            short s2 = dataInputStream.readShort();
            if (s2 == 1) {
                return;
            }
            throw new IllegalStateException(("Unsupported version number: " + ((int) s2)).toString());
        }

        private static final Object fromByteArray$readValue(DataInputStream dataInputStream, byte b) throws IOException {
            if (b == 0) {
                return null;
            }
            if (b == 1) {
                return Boolean.valueOf(dataInputStream.readBoolean());
            }
            if (b == 2) {
                return Byte.valueOf(dataInputStream.readByte());
            }
            if (b == 3) {
                return Integer.valueOf(dataInputStream.readInt());
            }
            if (b == 4) {
                return Long.valueOf(dataInputStream.readLong());
            }
            if (b == 5) {
                return Float.valueOf(dataInputStream.readFloat());
            }
            if (b == 6) {
                return Double.valueOf(dataInputStream.readDouble());
            }
            if (b == 7) {
                return dataInputStream.readUTF();
            }
            int i = 0;
            if (b == 8) {
                int i2 = dataInputStream.readInt();
                Boolean[] boolArr = new Boolean[i2];
                while (i < i2) {
                    boolArr[i] = Boolean.valueOf(dataInputStream.readBoolean());
                    i++;
                }
                return boolArr;
            }
            if (b == 9) {
                int i3 = dataInputStream.readInt();
                Byte[] bArr = new Byte[i3];
                while (i < i3) {
                    bArr[i] = Byte.valueOf(dataInputStream.readByte());
                    i++;
                }
                return bArr;
            }
            if (b == 10) {
                int i4 = dataInputStream.readInt();
                Integer[] numArr = new Integer[i4];
                while (i < i4) {
                    numArr[i] = Integer.valueOf(dataInputStream.readInt());
                    i++;
                }
                return numArr;
            }
            if (b == 11) {
                int i5 = dataInputStream.readInt();
                Long[] lArr = new Long[i5];
                while (i < i5) {
                    lArr[i] = Long.valueOf(dataInputStream.readLong());
                    i++;
                }
                return lArr;
            }
            if (b == 12) {
                int i6 = dataInputStream.readInt();
                Float[] fArr = new Float[i6];
                while (i < i6) {
                    fArr[i] = Float.valueOf(dataInputStream.readFloat());
                    i++;
                }
                return fArr;
            }
            if (b == 13) {
                int i7 = dataInputStream.readInt();
                Double[] dArr = new Double[i7];
                while (i < i7) {
                    dArr[i] = Double.valueOf(dataInputStream.readDouble());
                    i++;
                }
                return dArr;
            }
            if (b == 14) {
                int i8 = dataInputStream.readInt();
                String[] strArr = new String[i8];
                while (i < i8) {
                    String utf = dataInputStream.readUTF();
                    if (Intrinsics.areEqual(utf, "androidx.work.Data-95ed6082-b8e9-46e8-a73f-ff56f00f5d9d")) {
                        utf = null;
                    }
                    strArr[i] = utf;
                    i++;
                }
                return strArr;
            }
            throw new IllegalStateException("Unsupported type " + ((int) b));
        }

        public final Data fromByteArray(byte[] bytes) {
            Intrinsics.checkNotNullParameter(bytes, "bytes");
            if (bytes.length > 10240) {
                throw new IllegalStateException("Data cannot occupy more than 10240 bytes when serialized");
            }
            if (bytes.length == 0) {
                return Data.EMPTY;
            }
            LinkedHashMap linkedHashMap = new LinkedHashMap();
            try {
                ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(bytes);
                int i = 0;
                if (fromByteArray$isObjectStream(byteArrayInputStream)) {
                    ObjectInputStream objectInputStream = new ObjectInputStream(byteArrayInputStream);
                    try {
                        int i2 = objectInputStream.readInt();
                        while (i < i2) {
                            String utf = objectInputStream.readUTF();
                            Intrinsics.checkNotNullExpressionValue(utf, "readUTF()");
                            linkedHashMap.put(utf, objectInputStream.readObject());
                            i++;
                        }
                        CloseableKt.closeFinally(objectInputStream, null);
                    } catch (Throwable th) {
                        try {
                            throw th;
                        } catch (Throwable th2) {
                            CloseableKt.closeFinally(objectInputStream, th);
                            throw th2;
                        }
                    }
                } else {
                    DataInputStream dataInputStream = new DataInputStream(byteArrayInputStream);
                    try {
                        fromByteArray$readHeader(dataInputStream);
                        int i3 = dataInputStream.readInt();
                        while (i < i3) {
                            Object objFromByteArray$readValue = fromByteArray$readValue(dataInputStream, dataInputStream.readByte());
                            String key = dataInputStream.readUTF();
                            Intrinsics.checkNotNullExpressionValue(key, "key");
                            linkedHashMap.put(key, objFromByteArray$readValue);
                            i++;
                        }
                        CloseableKt.closeFinally(dataInputStream, null);
                    } catch (Throwable th3) {
                        try {
                            throw th3;
                        } catch (Throwable th4) {
                            CloseableKt.closeFinally(dataInputStream, th3);
                            throw th4;
                        }
                    }
                }
            } catch (IOException e) {
                Logger.get().error(Data_Kt.TAG, "Error in Data#fromByteArray: ", e);
            } catch (ClassNotFoundException e2) {
                Logger.get().error(Data_Kt.TAG, "Error in Data#fromByteArray: ", e2);
            }
            return new Data(linkedHashMap);
        }
    }
}
