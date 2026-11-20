package com.google.common.flogger.backend;

import com.google.common.flogger.LogSite;
import com.google.errorprone.annotations.CanIgnoreReturnValue;
import io.appmetrica.analytics.networktasks.internal.CommonUrlParts;
import java.io.IOException;
import java.math.BigInteger;
import java.util.Arrays;
import java.util.Formattable;
import java.util.Formatter;
import java.util.Locale;
import okhttp3.internal.ws.WebSocketProtocol;

/* JADX INFO: loaded from: classes2.dex */
public final class MessageUtils {
    static final Locale FORMAT_LOCALE = Locale.ROOT;
    private static final String NULL_TOSTRING_MESSAGE = "toString() returned null";

    private MessageUtils() {
    }

    @CanIgnoreReturnValue
    public static boolean appendLogSite(LogSite logSite, StringBuilder sb) {
        return LogSiteFormatters.DEFAULT.appendLogSite(logSite, sb);
    }

    public static String safeToString(Object obj) {
        try {
            return toNonNullString(obj);
        } catch (RuntimeException e) {
            return getErrorString(obj, e);
        }
    }

    private static String toNonNullString(Object obj) {
        if (obj == null) {
            return "null";
        }
        if (!obj.getClass().isArray()) {
            String string = obj.toString();
            return string != null ? string : formatErrorMessageFor(obj, NULL_TOSTRING_MESSAGE);
        }
        if (obj instanceof int[]) {
            return Arrays.toString((int[]) obj);
        }
        if (obj instanceof long[]) {
            return Arrays.toString((long[]) obj);
        }
        if (obj instanceof byte[]) {
            return Arrays.toString((byte[]) obj);
        }
        if (obj instanceof char[]) {
            return Arrays.toString((char[]) obj);
        }
        if (obj instanceof short[]) {
            return Arrays.toString((short[]) obj);
        }
        if (obj instanceof float[]) {
            return Arrays.toString((float[]) obj);
        }
        if (obj instanceof double[]) {
            return Arrays.toString((double[]) obj);
        }
        if (obj instanceof boolean[]) {
            return Arrays.toString((boolean[]) obj);
        }
        return Arrays.toString((Object[]) obj);
    }

    public static void safeFormatTo(Formattable formattable, StringBuilder sb, FormatOptions formatOptions) {
        int flags = formatOptions.getFlags();
        int i = flags & 162;
        if (i != 0) {
            i = ((flags & 32) != 0 ? 1 : 0) | ((flags & 128) != 0 ? 2 : 0) | ((flags & 2) != 0 ? 4 : 0);
        }
        int length = sb.length();
        Formatter formatter = new Formatter(sb, FORMAT_LOCALE);
        try {
            formattable.formatTo(formatter, i, formatOptions.getWidth(), formatOptions.getPrecision());
        } catch (RuntimeException e) {
            sb.setLength(length);
            try {
                formatter.out().append(getErrorString(formattable, e));
            } catch (IOException unused) {
            }
        }
    }

    static void appendHex(StringBuilder sb, Number number, FormatOptions formatOptions) {
        boolean zShouldUpperCase = formatOptions.shouldUpperCase();
        long jLongValue = number.longValue();
        if (number instanceof Long) {
            appendHex(sb, jLongValue, zShouldUpperCase);
            return;
        }
        if (number instanceof Integer) {
            appendHex(sb, jLongValue & 4294967295L, zShouldUpperCase);
            return;
        }
        if (number instanceof Byte) {
            appendHex(sb, jLongValue & 255, zShouldUpperCase);
            return;
        }
        if (number instanceof Short) {
            appendHex(sb, jLongValue & WebSocketProtocol.PAYLOAD_SHORT_MAX, zShouldUpperCase);
            return;
        }
        if (number instanceof BigInteger) {
            String string = ((BigInteger) number).toString(16);
            if (zShouldUpperCase) {
                string = string.toUpperCase(FORMAT_LOCALE);
            }
            sb.append(string);
            return;
        }
        throw new IllegalStateException("unsupported number type: " + number.getClass());
    }

    private static void appendHex(StringBuilder sb, long j, boolean z) {
        if (j == 0) {
            sb.append(CommonUrlParts.Values.FALSE_INTEGER);
            return;
        }
        String str = z ? "0123456789ABCDEF" : "0123456789abcdef";
        for (int iNumberOfLeadingZeros = (63 - Long.numberOfLeadingZeros(j)) & (-4); iNumberOfLeadingZeros >= 0; iNumberOfLeadingZeros -= 4) {
            sb.append(str.charAt((int) ((j >>> iNumberOfLeadingZeros) & 15)));
        }
    }

    private static String getErrorString(Object obj, RuntimeException runtimeException) {
        String simpleName;
        try {
            simpleName = runtimeException.toString();
        } catch (RuntimeException e) {
            simpleName = e.getClass().getSimpleName();
        }
        return formatErrorMessageFor(obj, simpleName);
    }

    private static String formatErrorMessageFor(Object obj, String str) {
        return "{" + obj.getClass().getName() + "@" + System.identityHashCode(obj) + ": " + str + "}";
    }
}
