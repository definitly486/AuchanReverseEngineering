package com.scanflow.datacapture.barinternal.androidx.savedstate;

import android.os.Bundle;
import android.os.IBinder;
import android.os.Parcelable;
import android.util.Size;
import android.util.SizeF;
import android.util.SparseArray;
import androidx.core.location.LocationRequestCompat;
import com.scanflow.datacapture.barinternal.androidx.core.os.BundleCompat;
import com.scanflow.datacapture.barinternal.kotlin.KotlinNothingValueException;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import com.scanflow.datacapture.barinternal.kotlin.jvm.JvmClassMappingKt;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import kotlin.jvm.internal.Intrinsics;
import kotlin.reflect.KClass;

/* JADX INFO: compiled from: SavedStateReader.android.kt */
/* JADX INFO: loaded from: classes.dex */
public abstract class SavedStateReader {
    /* JADX INFO: renamed from: constructor-impl, reason: not valid java name */
    public static Bundle m553constructorimpl(Bundle source) {
        Intrinsics.checkNotNullParameter(source, "source");
        return source;
    }

    /* JADX INFO: renamed from: getBinder-impl, reason: not valid java name */
    public static final IBinder m555getBinderimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        IBinder binder = bundle.getBinder(key);
        if (binder != null) {
            return binder;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getBoolean-impl, reason: not valid java name */
    public static final boolean m556getBooleanimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        boolean z = bundle.getBoolean(key, false);
        if (z || !bundle.getBoolean(key, true)) {
            return z;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getChar-impl, reason: not valid java name */
    public static final char m558getCharimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        char c = bundle.getChar(key, (char) 0);
        if (c != 0 || bundle.getChar(key, (char) 65535) != 65535) {
            return c;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getCharSequence-impl, reason: not valid java name */
    public static final CharSequence m560getCharSequenceimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        CharSequence charSequence = bundle.getCharSequence(key);
        if (charSequence != null) {
            return charSequence;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getDouble-impl, reason: not valid java name */
    public static final double m563getDoubleimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        double d = bundle.getDouble(key, Double.MIN_VALUE);
        if (d != Double.MIN_VALUE || bundle.getDouble(key, Double.MAX_VALUE) != Double.MAX_VALUE) {
            return d;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getFloat-impl, reason: not valid java name */
    public static final float m565getFloatimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        float f = bundle.getFloat(key, Float.MIN_VALUE);
        if (f != Float.MIN_VALUE || bundle.getFloat(key, Float.MAX_VALUE) != Float.MAX_VALUE) {
            return f;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getInt-impl, reason: not valid java name */
    public static final int m567getIntimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        int i = bundle.getInt(key, Integer.MIN_VALUE);
        if (i != Integer.MIN_VALUE || bundle.getInt(key, Integer.MAX_VALUE) != Integer.MAX_VALUE) {
            return i;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getLong-impl, reason: not valid java name */
    public static final long m571getLongimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        long j = bundle.getLong(key, Long.MIN_VALUE);
        if (j != Long.MIN_VALUE || bundle.getLong(key, LocationRequestCompat.PASSIVE_INTERVAL) != LocationRequestCompat.PASSIVE_INTERVAL) {
            return j;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getParcelable-impl, reason: not valid java name */
    public static final Parcelable m573getParcelableimpl(Bundle bundle, String key, KClass parcelableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(parcelableClass, "parcelableClass");
        Parcelable parcelable = (Parcelable) BundleCompat.getParcelable(bundle, key, JvmClassMappingKt.getJavaClass(parcelableClass));
        if (parcelable != null) {
            return parcelable;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getJavaSerializable-impl, reason: not valid java name */
    public static final Serializable m570getJavaSerializableimpl(Bundle bundle, String key, KClass serializableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(serializableClass, "serializableClass");
        Serializable serializable = BundleCompat.getSerializable(bundle, key, JvmClassMappingKt.getJavaClass(serializableClass));
        if (serializable != null) {
            return serializable;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getSize-impl, reason: not valid java name */
    public static final Size m579getSizeimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        Size size = bundle.getSize(key);
        if (size != null) {
            return size;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getSizeF-impl, reason: not valid java name */
    public static final SizeF m580getSizeFimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        SizeF sizeF = bundle.getSizeF(key);
        if (sizeF != null) {
            return sizeF;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getString-impl, reason: not valid java name */
    public static final String m583getStringimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        String string = bundle.getString(key);
        if (string != null) {
            return string;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getIntList-impl, reason: not valid java name */
    public static final List m569getIntListimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        ArrayList<Integer> integerArrayList = bundle.getIntegerArrayList(key);
        if (integerArrayList != null) {
            return integerArrayList;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getCharSequenceList-impl, reason: not valid java name */
    public static final List m562getCharSequenceListimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        ArrayList<CharSequence> charSequenceArrayList = bundle.getCharSequenceArrayList(key);
        if (charSequenceArrayList != null) {
            return charSequenceArrayList;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getStringList-impl, reason: not valid java name */
    public static final List m585getStringListimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        ArrayList<String> stringArrayList = bundle.getStringArrayList(key);
        if (stringArrayList != null) {
            return stringArrayList;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getStringListOrNull-impl, reason: not valid java name */
    public static final List m586getStringListOrNullimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        return bundle.getStringArrayList(key);
    }

    /* JADX INFO: renamed from: getParcelableList-impl, reason: not valid java name */
    public static final List m576getParcelableListimpl(Bundle bundle, String key, KClass parcelableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(parcelableClass, "parcelableClass");
        ArrayList parcelableArrayList = BundleCompat.getParcelableArrayList(bundle, key, JvmClassMappingKt.getJavaClass(parcelableClass));
        if (parcelableArrayList != null) {
            return parcelableArrayList;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getBooleanArray-impl, reason: not valid java name */
    public static final boolean[] m557getBooleanArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        boolean[] booleanArray = bundle.getBooleanArray(key);
        if (booleanArray != null) {
            return booleanArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getCharArray-impl, reason: not valid java name */
    public static final char[] m559getCharArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        char[] charArray = bundle.getCharArray(key);
        if (charArray != null) {
            return charArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getCharSequenceArray-impl, reason: not valid java name */
    public static final CharSequence[] m561getCharSequenceArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        CharSequence[] charSequenceArray = bundle.getCharSequenceArray(key);
        if (charSequenceArray != null) {
            return charSequenceArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getDoubleArray-impl, reason: not valid java name */
    public static final double[] m564getDoubleArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        double[] doubleArray = bundle.getDoubleArray(key);
        if (doubleArray != null) {
            return doubleArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getFloatArray-impl, reason: not valid java name */
    public static final float[] m566getFloatArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        float[] floatArray = bundle.getFloatArray(key);
        if (floatArray != null) {
            return floatArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getIntArray-impl, reason: not valid java name */
    public static final int[] m568getIntArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        int[] intArray = bundle.getIntArray(key);
        if (intArray != null) {
            return intArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getLongArray-impl, reason: not valid java name */
    public static final long[] m572getLongArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        long[] longArray = bundle.getLongArray(key);
        if (longArray != null) {
            return longArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getStringArray-impl, reason: not valid java name */
    public static final String[] m584getStringArrayimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        String[] stringArray = bundle.getStringArray(key);
        if (stringArray != null) {
            return stringArray;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getParcelableArray-impl, reason: not valid java name */
    public static final Parcelable[] m574getParcelableArrayimpl(Bundle bundle, String key, KClass parcelableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(parcelableClass, "parcelableClass");
        Parcelable[] parcelableArrM575getParcelableArrayOrNullimpl = m575getParcelableArrayOrNullimpl(bundle, key, parcelableClass);
        if (parcelableArrM575getParcelableArrayOrNullimpl != null) {
            return parcelableArrM575getParcelableArrayOrNullimpl;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getParcelableArrayOrNull-impl, reason: not valid java name */
    public static final Parcelable[] m575getParcelableArrayOrNullimpl(Bundle bundle, String key, KClass parcelableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(parcelableClass, "parcelableClass");
        Parcelable[] parcelableArray = BundleCompat.getParcelableArray(bundle, key, JvmClassMappingKt.getJavaClass(parcelableClass));
        if (parcelableArray != null) {
            return parcelableArray;
        }
        return null;
    }

    /* JADX INFO: renamed from: getSparseParcelableArray-impl, reason: not valid java name */
    public static final SparseArray m581getSparseParcelableArrayimpl(Bundle bundle, String key, KClass parcelableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(parcelableClass, "parcelableClass");
        SparseArray sparseArrayM582getSparseParcelableArrayOrNullimpl = m582getSparseParcelableArrayOrNullimpl(bundle, key, parcelableClass);
        if (sparseArrayM582getSparseParcelableArrayOrNullimpl != null) {
            return sparseArrayM582getSparseParcelableArrayOrNullimpl;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getSparseParcelableArrayOrNull-impl, reason: not valid java name */
    public static final SparseArray m582getSparseParcelableArrayOrNullimpl(Bundle bundle, String key, KClass parcelableClass) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(parcelableClass, "parcelableClass");
        return BundleCompat.getSparseParcelableArray(bundle, key, JvmClassMappingKt.getJavaClass(parcelableClass));
    }

    /* JADX INFO: renamed from: getSavedState-impl, reason: not valid java name */
    public static final Bundle m577getSavedStateimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        Bundle bundle2 = bundle.getBundle(key);
        if (bundle2 != null) {
            return bundle2;
        }
        SavedStateReaderKt.keyOrValueNotFoundError(key);
        throw new KotlinNothingValueException();
    }

    /* JADX INFO: renamed from: getSavedStateOrNull-impl, reason: not valid java name */
    public static final Bundle m578getSavedStateOrNullimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        return bundle.getBundle(key);
    }

    /* JADX INFO: renamed from: size-impl, reason: not valid java name */
    public static final int m589sizeimpl(Bundle bundle) {
        return bundle.size();
    }

    /* JADX INFO: renamed from: isEmpty-impl, reason: not valid java name */
    public static final boolean m587isEmptyimpl(Bundle bundle) {
        return bundle.isEmpty();
    }

    /* JADX INFO: renamed from: isNull-impl, reason: not valid java name */
    public static final boolean m588isNullimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        return m554containsimpl(bundle, key) && bundle.get(key) == null;
    }

    /* JADX INFO: renamed from: contains-impl, reason: not valid java name */
    public static final boolean m554containsimpl(Bundle bundle, String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        return bundle.containsKey(key);
    }

    /* JADX INFO: renamed from: toMap-impl, reason: not valid java name */
    public static final Map m590toMapimpl(Bundle bundle) {
        Map mapCreateMapBuilder = MapsKt.createMapBuilder(bundle.size());
        for (String str : bundle.keySet()) {
            Intrinsics.checkNotNull(str);
            mapCreateMapBuilder.put(str, bundle.get(str));
        }
        return MapsKt.build(mapCreateMapBuilder);
    }
}
