package com.google.common.flogger.util;

import com.google.errorprone.annotations.CanIgnoreReturnValue;

/* JADX INFO: loaded from: classes2.dex */
public class Checks {
    private static boolean isLetter(char c) {
        if ('a' > c || c > 'z') {
            return 'A' <= c && c <= 'Z';
        }
        return true;
    }

    private Checks() {
    }

    @CanIgnoreReturnValue
    public static <T> T checkNotNull(T t, String str) {
        if (t != null) {
            return t;
        }
        throw new NullPointerException(str + " must not be null");
    }

    public static void checkArgument(boolean z, String str) {
        if (!z) {
            throw new IllegalArgumentException(str);
        }
    }

    public static void checkState(boolean z, String str) {
        if (!z) {
            throw new IllegalStateException(str);
        }
    }

    @CanIgnoreReturnValue
    public static String checkMetadataIdentifier(String str) {
        if (str.isEmpty()) {
            throw new IllegalArgumentException("identifier must not be empty");
        }
        if (!isLetter(str.charAt(0))) {
            throw new IllegalArgumentException("identifier must start with an ASCII letter: " + str);
        }
        for (int i = 1; i < str.length(); i++) {
            char cCharAt = str.charAt(i);
            if (!isLetter(cCharAt) && ((cCharAt < '0' || cCharAt > '9') && cCharAt != '_')) {
                throw new IllegalArgumentException("identifier must contain only ASCII letters, digits or underscore: " + str);
            }
        }
        return str;
    }
}
