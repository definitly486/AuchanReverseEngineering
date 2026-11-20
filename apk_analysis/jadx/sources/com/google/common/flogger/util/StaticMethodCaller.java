package com.google.common.flogger.util;

/* JADX INFO: loaded from: classes2.dex */
public final class StaticMethodCaller {
    public static <T> T getInstanceFromSystemProperty(String str, Class<T> cls) {
        return (T) getInstanceFromSystemProperty(str, null, cls);
    }

    public static <T> T getInstanceFromSystemProperty(String str, String str2, Class<T> cls) {
        String property = readProperty(str, str2);
        if (property == null) {
            return null;
        }
        int iIndexOf = property.indexOf(35);
        String strSubstring = iIndexOf == -1 ? property : property.substring(0, iIndexOf);
        String strSubstring2 = iIndexOf == -1 ? "getInstance" : property.substring(iIndexOf + 1);
        String str3 = strSubstring + '#' + strSubstring2 + "()";
        try {
            Class<?> cls2 = Class.forName(strSubstring);
            try {
                return cls.cast(cls2.getMethod(strSubstring2, null).invoke(null, null));
            } catch (NoSuchMethodException e) {
                if (iIndexOf != -1 && strSubstring2.equals("getInstance")) {
                    String str4 = "new " + strSubstring + "()";
                    return cls.cast(cls2.getConstructor(null).newInstance(null));
                }
                error("method '%s' does not exist: %s\n", property, e);
                return null;
            }
        } catch (ClassCastException e2) {
            error("cannot cast result of calling '%s' to '%s': %s\n", str3, cls.getName(), e2);
            return null;
        } catch (ClassNotFoundException unused) {
            return null;
        } catch (Exception e3) {
            error("cannot call expected no-argument constructor or static method '%s': %s\n", str3, e3);
            return null;
        }
    }

    private static String readProperty(String str, String str2) {
        Checks.checkNotNull(str, "property name");
        try {
            return System.getProperty(str, str2);
        } catch (SecurityException e) {
            error("cannot read property name %s: %s", str, e);
            return null;
        }
    }

    private static void error(String str, Object... objArr) {
        System.err.println(StaticMethodCaller.class + ": " + String.format(str, objArr));
    }

    private StaticMethodCaller() {
    }
}
