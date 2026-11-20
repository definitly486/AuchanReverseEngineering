package io.appmetrica.analytics.coreutils.internal.reflection;

import java.lang.reflect.Constructor;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class ReflectionUtils {
    public static final ReflectionUtils INSTANCE = new ReflectionUtils();

    private ReflectionUtils() {
    }

    public static final boolean detectClassExists(String str) {
        return findClass(str) != null;
    }

    public static final Class<?> findClass(String str) {
        try {
            return Class.forName(str, false, ReflectionUtils.class.getClassLoader());
        } catch (Throwable unused) {
            return null;
        }
    }

    public static final boolean isArgumentsOfClasses(Object[] objArr, Class<?>... clsArr) {
        if (objArr.length != clsArr.length) {
            return false;
        }
        int length = objArr.length;
        int i = 0;
        int i2 = 0;
        while (i < length) {
            Object obj = objArr[i];
            int i3 = i2 + 1;
            if (obj == null || !clsArr[i2].isAssignableFrom(obj.getClass())) {
                return false;
            }
            i++;
            i2 = i3;
        }
        return true;
    }

    public static final <T> T loadAndInstantiateClassWithDefaultConstructor(String str, Class<T> cls) {
        Constructor<T> constructor;
        try {
            Class clsLoadClass = loadClass(str, cls);
            if (clsLoadClass != null && (constructor = clsLoadClass.getConstructor(null)) != null) {
                return constructor.newInstance(null);
            }
        } catch (Throwable unused) {
        }
        return null;
    }

    public static final <T> Class<T> loadClass(String str, Class<T> cls) {
        try {
            Class<T> cls2 = (Class<T>) Class.forName(str);
            if (!cls.isAssignableFrom(cls2)) {
                return null;
            }
            Intrinsics.checkNotNull(cls2, "null cannot be cast to non-null type java.lang.Class<T of io.appmetrica.analytics.coreutils.internal.reflection.ReflectionUtils.loadClass>");
            return cls2;
        } catch (Throwable unused) {
            return null;
        }
    }

    public static final /* synthetic */ <T> T loadAndInstantiateClassWithDefaultConstructor(String str) {
        Intrinsics.reifiedOperationMarker(4, "T");
        return (T) loadAndInstantiateClassWithDefaultConstructor(str, Object.class);
    }
}
