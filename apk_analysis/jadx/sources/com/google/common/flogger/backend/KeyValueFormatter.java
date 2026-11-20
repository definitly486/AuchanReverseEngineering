package com.google.common.flogger.backend;

import com.google.common.flogger.MetadataKey;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

/* JADX INFO: loaded from: classes2.dex */
public final class KeyValueFormatter implements MetadataKey.KeyValueHandler {
    private static final Set<Class<?>> FUNDAMENTAL_TYPES = new HashSet(Arrays.asList(Boolean.class, Byte.class, Short.class, Integer.class, Long.class, Float.class, Double.class));
    private static final int NEWLINE_LIMIT = 1000;
    private boolean haveSeenValues = false;
    private final StringBuilder out;
    private final String prefix;
    private final String suffix;

    public static void appendJsonFormattedKeyAndValue(String str, Object obj, StringBuilder sb) {
        sb.append(str);
        sb.append('=');
        if (obj == null) {
            sb.append(true);
        } else {
            if (FUNDAMENTAL_TYPES.contains(obj.getClass())) {
                sb.append(obj);
                return;
            }
            sb.append('\"');
            appendEscaped(sb, obj.toString());
            sb.append('\"');
        }
    }

    public KeyValueFormatter(String str, String str2, StringBuilder sb) {
        this.prefix = str;
        this.suffix = str2;
        this.out = sb;
    }

    @Override // com.google.common.flogger.MetadataKey.KeyValueHandler
    public void handle(String str, Object obj) {
        if (this.haveSeenValues) {
            this.out.append(' ');
        } else {
            if (this.out.length() > 0) {
                StringBuilder sb = this.out;
                sb.append((sb.length() > 1000 || this.out.indexOf("\n") != -1) ? '\n' : ' ');
            }
            this.out.append(this.prefix);
            this.haveSeenValues = true;
        }
        appendJsonFormattedKeyAndValue(str, obj, this.out);
    }

    public void done() {
        if (this.haveSeenValues) {
            this.out.append(this.suffix);
        }
    }

    private static void appendEscaped(StringBuilder sb, String str) {
        int i = 0;
        while (true) {
            int iNextEscapableChar = nextEscapableChar(str, i);
            if (iNextEscapableChar != -1) {
                sb.append((CharSequence) str, i, iNextEscapableChar);
                i = iNextEscapableChar + 1;
                char cCharAt = str.charAt(iNextEscapableChar);
                if (cCharAt == '\t') {
                    cCharAt = 't';
                } else if (cCharAt == '\n') {
                    cCharAt = 'n';
                } else if (cCharAt == '\r') {
                    cCharAt = 'r';
                } else if (cCharAt != '\"' && cCharAt != '\\') {
                    sb.append((char) 65533);
                }
                sb.append("\\");
                sb.append(cCharAt);
            } else {
                sb.append((CharSequence) str, i, str.length());
                return;
            }
        }
    }

    private static int nextEscapableChar(String str, int i) {
        while (i < str.length()) {
            char cCharAt = str.charAt(i);
            if (cCharAt < ' ' || cCharAt == '\"' || cCharAt == '\\') {
                return i;
            }
            i++;
        }
        return -1;
    }
}
